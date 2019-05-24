using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
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
				try
				{
					using (saveStream = saveDialog.OpenFile())
					{
						var bitmaps = this.GetArgbBitmaps();
						var size = bitmaps[0].Size;

						var final = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);

						for (int width = 0; width < size.Width; width++)
						{
							for (int height = 0; height < size.Height; height++)
							{
								final.SetPixel(width, height, Color.FromArgb(
									bitmaps[0].GetPixel(width, height)
										.R, // Just pick some channel for alpha, it should be gray-scale
									bitmaps[1].GetPixel(width, height).R,
									bitmaps[2].GetPixel(width, height).G,
									bitmaps[3].GetPixel(width, height).B
								));
							}
						}

						// Save IMG
						final.Save(saveStream, ImageFormat.Png);

						saveStream.Close();
						final.Dispose();
						bitmaps[0].Dispose();
						bitmaps[1].Dispose();
						bitmaps[2].Dispose();
						bitmaps[3].Dispose();

						MessageBox.Show("Texture map saved");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("ERROR: " + ex.Message);
				}
			}
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
			
			var bitmaps = new []
			{
				this.alphaChanelPic.Image == null ? EmptyBitmap(size, Color.White) : new Bitmap(this.alphaChanelPic.Image),
				this.redChanelPic.Image == null ? new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb) : new Bitmap(this.redChanelPic.Image),
				this.greenChanelPic.Image == null ? new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb) : new Bitmap(this.greenChanelPic.Image),
				this.blueChanelPic.Image == null ? new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb) : new Bitmap(this.blueChanelPic.Image)
			};

			return bitmaps;
		}

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

		private void AddImageIfExists(PictureBox picBox, List<Image> images)
		{
			if (picBox.Image != null)
			{
				images.Add(picBox.Image);
			}
		}

		#endregion

		#region Private methods

		private void SetupPictureBox(PictureBox pictureBox)
		{
			pictureBox.AllowDrop = true;
			pictureBox.DragEnter += OnDragEnter;
			pictureBox.DragDrop += OnDragDrop;
		}

		#endregion
	}
}