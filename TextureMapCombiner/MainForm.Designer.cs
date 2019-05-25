using System.Drawing;

namespace TextureMapCombiner
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}

			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mainPanel = new System.Windows.Forms.Panel();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.saveBtn = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.redChanelPic = new System.Windows.Forms.PictureBox();
			this.greenChanelPic = new System.Windows.Forms.PictureBox();
			this.blueChanelPic = new System.Windows.Forms.PictureBox();
			this.alphaChanelPic = new System.Windows.Forms.PictureBox();
			this.clearBtn = new System.Windows.Forms.Button();
			this.statusLabel = new System.Windows.Forms.Label();
			this.mainPanel.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) (this.redChanelPic)).BeginInit();
			((System.ComponentModel.ISupportInitialize) (this.greenChanelPic)).BeginInit();
			((System.ComponentModel.ISupportInitialize) (this.blueChanelPic)).BeginInit();
			((System.ComponentModel.ISupportInitialize) (this.alphaChanelPic)).BeginInit();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.Controls.Add(this.statusLabel);
			this.mainPanel.Controls.Add(this.clearBtn);
			this.mainPanel.Controls.Add(this.label8);
			this.mainPanel.Controls.Add(this.label7);
			this.mainPanel.Controls.Add(this.label6);
			this.mainPanel.Controls.Add(this.label5);
			this.mainPanel.Controls.Add(this.label4);
			this.mainPanel.Controls.Add(this.label3);
			this.mainPanel.Controls.Add(this.label2);
			this.mainPanel.Controls.Add(this.label1);
			this.mainPanel.Controls.Add(this.saveBtn);
			this.mainPanel.Controls.Add(this.tableLayoutPanel1);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Location = new System.Drawing.Point(0, 0);
			this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 50);
			this.mainPanel.Size = new System.Drawing.Size(1042, 1089);
			this.mainPanel.TabIndex = 0;
			// 
			// label8
			// 
			this.label8.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (50)))), ((int) (((byte) (255)))),
				((int) (((byte) (255)))), ((int) (((byte) (255)))));
			this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point, ((byte) (238)));
			this.label8.Location = new System.Drawing.Point(920, 580);
			this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 25);
			this.label8.TabIndex = 9;
			this.label8.Text = "Smoothness";
			this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (50)))), ((int) (((byte) (255)))),
				((int) (((byte) (255)))), ((int) (((byte) (255)))));
			this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point, ((byte) (238)));
			this.label7.Location = new System.Drawing.Point(400, 580);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 25);
			this.label7.TabIndex = 8;
			this.label7.Text = "Detail";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (50)))), ((int) (((byte) (255)))),
				((int) (((byte) (255)))), ((int) (((byte) (255)))));
			this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point, ((byte) (238)));
			this.label6.Location = new System.Drawing.Point(920, 60);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 25);
			this.label6.TabIndex = 7;
			this.label6.Text = "AO";
			this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (50)))), ((int) (((byte) (255)))),
				((int) (((byte) (255)))), ((int) (((byte) (255)))));
			this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point, ((byte) (238)));
			this.label5.Location = new System.Drawing.Point(400, 60);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 25);
			this.label5.TabIndex = 6;
			this.label5.Text = "Metallic";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (50)))), ((int) (((byte) (255)))),
				((int) (((byte) (255)))), ((int) (((byte) (255)))));
			this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point, ((byte) (238)));
			this.label4.Location = new System.Drawing.Point(870, 530);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(160, 40);
			this.label4.TabIndex = 5;
			this.label4.Text = "A channel";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (50)))), ((int) (((byte) (255)))),
				((int) (((byte) (255)))), ((int) (((byte) (255)))));
			this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point, ((byte) (238)));
			this.label3.Location = new System.Drawing.Point(345, 530);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(160, 40);
			this.label3.TabIndex = 4;
			this.label3.Text = "B channel";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (50)))), ((int) (((byte) (255)))),
				((int) (((byte) (255)))), ((int) (((byte) (255)))));
			this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point, ((byte) (238)));
			this.label2.Location = new System.Drawing.Point(870, 10);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(160, 40);
			this.label2.TabIndex = 3;
			this.label2.Text = "G channel";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (50)))), ((int) (((byte) (255)))),
				((int) (((byte) (255)))), ((int) (((byte) (255)))));
			this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point, ((byte) (238)));
			this.label1.Location = new System.Drawing.Point(345, 10);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 40);
			this.label1.TabIndex = 2;
			this.label1.Text = "R channel";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// saveBtn
			// 
			this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
				System.Windows.Forms.AnchorStyles.Right)));
			this.saveBtn.Location = new System.Drawing.Point(957, 1045);
			this.saveBtn.Margin = new System.Windows.Forms.Padding(0, 0, 10, 10);
			this.saveBtn.Name = "saveBtn";
			this.saveBtn.Size = new System.Drawing.Size(75, 35);
			this.saveBtn.TabIndex = 1;
			this.saveBtn.Text = "Save";
			this.saveBtn.UseVisualStyleBackColor = true;
			this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(
				new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(
				new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.redChanelPic, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.greenChanelPic, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.blueChanelPic, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.alphaChanelPic, 1, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(
				new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(
				new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1042, 1039);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// redChanelPic
			// 
			this.redChanelPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.redChanelPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.redChanelPic.Cursor = System.Windows.Forms.Cursors.Hand;
			this.redChanelPic.Dock = System.Windows.Forms.DockStyle.Fill;
			this.redChanelPic.Location = new System.Drawing.Point(4, 3);
			this.redChanelPic.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.redChanelPic.Name = "redChanelPic";
			this.redChanelPic.Size = new System.Drawing.Size(513, 513);
			this.redChanelPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.redChanelPic.TabIndex = 0;
			this.redChanelPic.TabStop = false;
			// 
			// greenChanelPic
			// 
			this.greenChanelPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.greenChanelPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.greenChanelPic.Cursor = System.Windows.Forms.Cursors.Hand;
			this.greenChanelPic.Dock = System.Windows.Forms.DockStyle.Fill;
			this.greenChanelPic.Location = new System.Drawing.Point(525, 3);
			this.greenChanelPic.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.greenChanelPic.Name = "greenChanelPic";
			this.greenChanelPic.Size = new System.Drawing.Size(513, 513);
			this.greenChanelPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.greenChanelPic.TabIndex = 1;
			this.greenChanelPic.TabStop = false;
			// 
			// blueChanelPic
			// 
			this.blueChanelPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.blueChanelPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.blueChanelPic.Cursor = System.Windows.Forms.Cursors.Hand;
			this.blueChanelPic.Dock = System.Windows.Forms.DockStyle.Fill;
			this.blueChanelPic.Location = new System.Drawing.Point(4, 522);
			this.blueChanelPic.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.blueChanelPic.Name = "blueChanelPic";
			this.blueChanelPic.Size = new System.Drawing.Size(513, 514);
			this.blueChanelPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.blueChanelPic.TabIndex = 2;
			this.blueChanelPic.TabStop = false;
			// 
			// alphaChanelPic
			// 
			this.alphaChanelPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.alphaChanelPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.alphaChanelPic.Cursor = System.Windows.Forms.Cursors.Hand;
			this.alphaChanelPic.Dock = System.Windows.Forms.DockStyle.Fill;
			this.alphaChanelPic.Location = new System.Drawing.Point(525, 522);
			this.alphaChanelPic.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.alphaChanelPic.Name = "alphaChanelPic";
			this.alphaChanelPic.Size = new System.Drawing.Size(513, 514);
			this.alphaChanelPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.alphaChanelPic.TabIndex = 3;
			this.alphaChanelPic.TabStop = false;
			// 
			// clearBtn
			// 
			this.clearBtn.Location = new System.Drawing.Point(870, 1045);
			this.clearBtn.Name = "clearBtn";
			this.clearBtn.Size = new System.Drawing.Size(75, 35);
			this.clearBtn.TabIndex = 10;
			this.clearBtn.Text = "Clear";
			this.clearBtn.UseVisualStyleBackColor = true;
			this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
			// 
			// statusLabel
			// 
			this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point, ((byte) (238)));
			this.statusLabel.Location = new System.Drawing.Point(12, 1045);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(852, 35);
			this.statusLabel.TabIndex = 11;
			this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1042, 1089);
			this.Controls.Add(this.mainPanel);
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(1058, 1128);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Texture Maps Combiner";
			this.mainPanel.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) (this.redChanelPic)).EndInit();
			((System.ComponentModel.ISupportInitialize) (this.greenChanelPic)).EndInit();
			((System.ComponentModel.ISupportInitialize) (this.blueChanelPic)).EndInit();
			((System.ComponentModel.ISupportInitialize) (this.alphaChanelPic)).EndInit();
			this.ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button saveBtn;
		private System.Windows.Forms.PictureBox redChanelPic;
		private System.Windows.Forms.PictureBox greenChanelPic;
		private System.Windows.Forms.PictureBox blueChanelPic;
		private System.Windows.Forms.PictureBox alphaChanelPic;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button clearBtn;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.Panel mainPanel;
	}
}