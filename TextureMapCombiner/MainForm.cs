using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextureMapCombiner
{
	public partial class MainForm : Form
	{
		#region Fields

		/// <summary>
		/// Last dropped image file path
		/// </summary>
		/// <remarks>
		/// Store last dropped image path which will be sugested in save dialog.
		/// </remarks>
		private string lastFilePath = null;

		#endregion

		public MainForm()
		{
			InitializeComponent();

			this.SetupPictureBox(this.redChanelPic);
			this.SetupPictureBox(this.greenChanelPic);
			this.SetupPictureBox(this.blueChanelPic);
			this.SetupPictureBox(this.alphaChanelPic);

			this.MaximumSize = this.Size;
			this.MinimumSize = this.Size;
		}

		#region Event handlers

		/// <summary>
		/// On droppable area enter
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;
		}

		/// <summary>
		/// On drop
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDragDrop(object sender, DragEventArgs e)
		{
			PictureBox pb = (PictureBox) sender;

			string file = ((string[]) e.Data.GetData(DataFormats.FileDrop)).FirstOrDefault();

			if (!string.IsNullOrWhiteSpace(file))
			{
				pb.Image = Image.FromFile(file);
				this.lastFilePath = file;
			}
		}

		/// <summary>
		/// Clear set images
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void clearBtn_Click(object sender, EventArgs e)
		{
			this.alphaChanelPic.Image = null;
			this.redChanelPic.Image = null;
			this.greenChanelPic.Image = null;
			this.blueChanelPic.Image = null;
		}

		/// <summary>
		/// On save btn
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void saveBtn_Click(object sender, EventArgs e)
		{
			Stream saveStream = null;
			SaveFileDialog saveDialog = new SaveFileDialog();

			saveDialog.Filter = "All files (*.*)|*.*|PNG files (*.png)|*.png";
			saveDialog.FilterIndex = 2;
			saveDialog.RestoreDirectory = true;
			saveDialog.DefaultExt = "png";
			saveDialog.InitialDirectory = Path.GetDirectoryName(this.lastFilePath);

			if (saveDialog.ShowDialog() == DialogResult.OK)
			{
				this.saveBtn.Enabled = false;
				this.clearBtn.Enabled = false;
				this.statusLabel.Text = "In progress...";

				try
				{
					var bitmaps = this.GetArgbBitmaps();
					var finalTask = this.CombineBitmaps(bitmaps);

					finalTask.ContinueWith(t =>
					{
						try
						{
							var final = finalTask.Result;

							using (saveStream = saveDialog.OpenFile())
							{
								// Save IMG
								final.Save(saveStream, ImageFormat.Png);
								saveStream.Close();
							}

							final.Dispose();
							bitmaps[0].Dispose();
							bitmaps[1].Dispose();
							bitmaps[2].Dispose();
							bitmaps[3].Dispose();

							this.statusLabel.Text = "";
							this.saveBtn.Enabled = true;
							this.clearBtn.Enabled = true;
							MessageBox.Show("Texture map saved");
						}
						catch (Exception ex)
						{
							MessageBox.Show("ERROR: " + ex.Message);
						}
					});
				}
				catch (Exception ex)
				{
					MessageBox.Show("ERROR: " + ex.Message);
				}
			}
		}

		#endregion

		#region Private methods

		/// <summary>
		/// Setup picturebox for drag&drop
		/// </summary>
		/// <param name="pictureBox"></param>
		private void SetupPictureBox(PictureBox pictureBox)
		{
			pictureBox.AllowDrop = true;
			pictureBox.DragEnter += OnDragEnter;
			pictureBox.DragDrop += OnDragDrop;
		}

		/// <summary>
		/// Combine bitmaps
		/// </summary>
		/// <param name="bitmaps"></param>
		/// <returns></returns>
		private async Task<Bitmap> CombineBitmaps(Bitmap[] bitmaps)
		{
			var size = bitmaps[0].Size;

			// Producer/consumer collection
			using (BlockingCollection<PixelData> data = new BlockingCollection<PixelData>())
			{
				int cpuCount = Environment.ProcessorCount / 2;
				int partWidth = size.Width / cpuCount;

				List<Task> tasks = new List<Task>();
				int from = 0, to = partWidth;

				for (int cpu = cpuCount - 1; cpu >= 0; cpu--)
				{
					tasks.Add(this.CombineBitmapsPart(bitmaps, data, from, to, size.Height));

					if (cpu == 1) // before last
					{
						from += partWidth;
						to = size.Width;
					}
					else
					{
						from += partWidth;
						to += partWidth;
					}
				}

				var final = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
				var consumerTask = this.ConsumeData(data, final);

				// Wait for producers
				var whenAll = Task.WhenAll(tasks);
				tasks.ForEach(t => t.Start());
				await whenAll.ConfigureAwait(false);
				data.CompleteAdding();

				await consumerTask.ConfigureAwait(false);
				return final;
			}
		}

		private Task ConsumeData(BlockingCollection<PixelData> data, Bitmap final)
		{
			return Task.Run(() =>
			{
				try
				{
					while (!data.IsCompleted)
					{
						PixelData pixelData = data.Take();
						final.SetPixel(pixelData.x, pixelData.y, pixelData.color);
					}
				}
				catch (InvalidOperationException)
				{
					// An InvalidOperationException means that Take() was called on a completed collection
				}
			});
		}

		/// <summary>
		/// Combine parts of bitmaps in separated core
		/// </summary>
		/// <param name="bitmapsOrigin"></param>
		/// <param name="data"></param>
		/// <param name="fromWidth"></param>
		/// <param name="toWidth"></param>
		/// <param name="sizeHeight"></param>
		/// <returns></returns>
		private Task CombineBitmapsPart(Bitmap[] bitmapsOrigin, BlockingCollection<PixelData> data, int fromWidth,
			int toWidth, int sizeHeight)
		{
			var bitmaps = bitmapsOrigin.Select(x => (Bitmap) x.Clone()).ToArray();

			var t = new Task(() =>
			{
				for (int width = fromWidth; width < toWidth; width++)
				{
					for (int height = 0; height < sizeHeight; height++)
					{
						var color = Color.FromArgb(
							bitmaps[0].GetPixel(width, height)
								.R, // Just pick some channel for alpha, it should be gray-scale
							bitmaps[1].GetPixel(width, height).R,
							bitmaps[2].GetPixel(width, height).G,
							bitmaps[3].GetPixel(width, height).B
						);

						data.Add(new PixelData(width, height, color));
					}
				}

				foreach (var bitmap in bitmaps)
				{
					bitmap.Dispose();
				}
			}, TaskCreationOptions.LongRunning);

			return t;
		}

		/// <summary>
		/// Return Bitmap array with textures as [ Alpha, Red, Green, Blue  ] channels
		/// </summary>
		/// <returns></returns>
		private Bitmap[] GetArgbBitmaps()
		{
			var images = new List<Image>();
			this.AddImageIfExists(this.redChanelPic, images);
			this.AddImageIfExists(this.greenChanelPic, images);
			this.AddImageIfExists(this.blueChanelPic, images);
			this.AddImageIfExists(this.alphaChanelPic, images);

			if (images.Count == 0 || !this.ValidateTextureSizes(images))
			{
				return null;
			}

			Size size = images.First().Size;

			var bitmaps = new[]
			{
				this.alphaChanelPic.Image == null
					? EmptyBitmap(size, Color.White)
					: new Bitmap(this.alphaChanelPic.Image),
				this.redChanelPic.Image == null
					? new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb)
					: new Bitmap(this.redChanelPic.Image),
				this.greenChanelPic.Image == null
					? new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb)
					: new Bitmap(this.greenChanelPic.Image),
				this.blueChanelPic.Image == null
					? new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb)
					: new Bitmap(this.blueChanelPic.Image)
			};

			return bitmaps;
		}

		/// <summary>
		/// Get empty bitmap with given size and color
		/// </summary>
		/// <param name="size"></param>
		/// <param name="color"></param>
		/// <returns></returns>
		private static Bitmap EmptyBitmap(Size size, Color color)
		{
			var bitmap = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);

			using (var g = Graphics.FromImage(bitmap))
			{
				g.Clear(color);
			}

			return bitmap;
		}

		/// <summary>
		/// Validate that all texture sizes match
		/// </summary>
		private bool ValidateTextureSizes(List<Image> images)
		{
			// Check if file sizes match
			if (!images.All(a => images.All(b => a.Size.Width == b.Size.Width && a.Size.Height == b.Size.Height)))
			{
				MessageBox.Show("All texture sizes must match.");
				return false;
			}

			return true;
		}

		/// <summary>
		/// Add image from picturebox to list if image set
		/// </summary>
		/// <param name="picBox"></param>
		/// <param name="images"></param>
		private void AddImageIfExists(PictureBox picBox, List<Image> images)
		{
			if (picBox.Image != null)
			{
				images.Add(picBox.Image);
			}
		}

		#endregion
	}
}