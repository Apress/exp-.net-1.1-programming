using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace Apress.ExpertDotNet.BltFromScreen
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		[DllImport("gdi32.dll")]
		static extern int BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth,
			int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc,
			int swRop);

		[DllImport("gdi32.dll")]
		static extern IntPtr CreateCompatibleDC(IntPtr hdc);

		[DllImport("gdi32.dll")]
		static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth,
			int nHeight);

		[DllImport("gdi32.dll")]
		static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

		[DllImport("gdi32.dll")]
		static extern int DeleteObject(IntPtr hgdiobj);

		const int SRCCOPY = 0xcc0020;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuFileGetScreenshot;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuFileGetScreenshot = new System.Windows.Forms.MenuItem();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.radioButton1,
																					this.checkBox1,
																					this.button1});
			this.groupBox1.Location = new System.Drawing.Point(24, 64);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 120);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(24, 24);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(24, 64);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.TabIndex = 1;
			this.checkBox1.Text = "checkBox1";
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(24, 88);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.TabIndex = 2;
			this.radioButton1.Text = "radioButton1";
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuFileGetScreenshot});
			this.menuItem1.Text = "&File";
			// 
			// menuFileGetScreenshot
			// 
			this.menuFileGetScreenshot.Index = 0;
			this.menuFileGetScreenshot.Text = "&GetScreenshot";
			this.menuFileGetScreenshot.Click += new System.EventHandler(this.menuFileGetScreenshot_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(248, 198);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.groupBox1});
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "BltFromScreen";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			e.Graphics.DrawString("Hello", new Font("Ariel", 12, FontStyle.Bold),
				Brushes.Indigo, new Point(10,10));
		}

		private void menuFileGetScreenshot_Click(object sender, System.EventArgs e)
		{
			Refresh();
			GrabScreenshot();
		}
		private void GrabScreenshot()
		{
			int width = this.ClientSize.Width;
			int height = this.ClientSize.Height;

			Graphics screen = this.CreateGraphics();
			IntPtr hdcScreen = screen.GetHdc();

			IntPtr hdcMemory = CreateCompatibleDC(hdcScreen);
			IntPtr hBitmap = CreateCompatibleBitmap(hdcScreen, width, height);
			IntPtr hOldBitmap = SelectObject(hdcMemory, hBitmap);

			int result = BitBlt(hdcMemory, 0, 0, width, height, hdcScreen, 0, 0,
				SRCCOPY);
			Image screenShot = Image.FromHbitmap(hBitmap);
			screenShot.Save("Screenshot.bmp", ImageFormat.Bmp);

			SelectObject(hdcMemory, hOldBitmap);
			screen.ReleaseHdc(hdcScreen);

			DeleteObject(hdcMemory);
			DeleteObject(hBitmap);
			MessageBox.Show("Screenshot saved in Screenshot.bmp");
		}
	}
}
