using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace Apress.ExpertDotNet.CircularForm
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private const int nButtons = 2;
		private Button [] buttons;

		private string [] colors = { "red", "orange", "yellow", "green",
									   "blue", "indigo", "violet" };
		private string [] shapes = { "square", "circle", "triangle",
									   "hexagon", "pentagon" };

		private System.Windows.Forms.Button btnColors;
		private System.Windows.Forms.Button btnShapes;
		private System.Windows.Forms.ListBox lbResults;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			InitializeComponent();

			buttons = new Button[nButtons];
			buttons[0] = btnColors;
			buttons[1] = btnShapes;
			SetButtonRegions();
			DoResize();

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
			this.btnColors = new System.Windows.Forms.Button();
			this.btnShapes = new System.Windows.Forms.Button();
			this.lbResults = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// btnColors
			// 
			this.btnColors.BackColor = System.Drawing.SystemColors.ControlDark;
			this.btnColors.Location = new System.Drawing.Point(16, 32);
			this.btnColors.Name = "btnColors";
			this.btnColors.TabIndex = 0;
			this.btnColors.Text = "List Colors";
			this.btnColors.Click += new System.EventHandler(this.btnColors_Click);
			// 
			// btnShapes
			// 
			this.btnShapes.BackColor = System.Drawing.SystemColors.ControlDark;
			this.btnShapes.Location = new System.Drawing.Point(16, 72);
			this.btnShapes.Name = "btnShapes";
			this.btnShapes.TabIndex = 1;
			this.btnShapes.Text = "List Shapes";
			this.btnShapes.Click += new System.EventHandler(this.btnShapes_Click);
			// 
			// lbResults
			// 
			this.lbResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbResults.ItemHeight = 24;
			this.lbResults.Location = new System.Drawing.Point(160, 32);
			this.lbResults.Name = "lbResults";
			this.lbResults.Size = new System.Drawing.Size(168, 172);
			this.lbResults.TabIndex = 2;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(488, 266);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lbResults,
																		  this.btnShapes,
																		  this.btnColors});
			this.MinimumSize = new System.Drawing.Size(350, 250);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Layout += new System.Windows.Forms.LayoutEventHandler(this.Form1_Layout);
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

		private void Form1_Layout(object sender, System.Windows.Forms.LayoutEventArgs e)
		{
			DoResize();
		}

		private void DoResize()
		{
			SetFormRegion();
			SetButtonLocations();
			SetListBoxLocation();
		}

		private void SetButtonRegions()
		{
			int width = this.buttons[0].Width;
			int height = this.buttons[0].Height;
			GraphicsPath outline = new GraphicsPath();
			Rectangle twiceButtonRect = new Rectangle(-width, 0, 2 * width, height);
			outline.AddArc(twiceButtonRect, -90, 180);
			outline.AddLine(0, height, 0, 0);
			Region rgn = new Region(outline);
			foreach (Button button in this.buttons)
				button.Region = rgn;
		}

		private void SetFormRegion()
		{
			int titleBarHeight = this.ClientTopLeft.Y;
			int remainingHeight = this.Height - titleBarHeight;
			GraphicsPath outline = new GraphicsPath();
			outline.AddLine(0, titleBarHeight, 0, 0);
			outline.AddLine(0,0,this.Width,0);
			outline.AddLine(Width, 0, Width, titleBarHeight);

			// twiceClientRect covers area below title bar and equal
			// area above it, to set bounds for ellipse
			Rectangle twiceClientRect = new Rectangle(0, titleBarHeight -
				remainingHeight, this.Width, 2 * remainingHeight);
			outline.AddArc(twiceClientRect, 0, 180);
			Region rgn = new Region(outline);
			this.Region = rgn;
		}

		public Point ClientTopLeft
		{
			get
			{
				Point pt = PointToScreen(new Point(0, 0));
				return new Point(pt.X - this.Location.X, pt.Y - this.Location.Y);
			}
		}

		private void SetListBoxLocation()
		{
			this.lbResults.Location = new Point(this.Width / 3, 5);
			this.lbResults.Size = new Size(this.Width / 3,
				(this.ClientSize.Height * 2) / 3);
		}


		private int LeftBorderY2X(int y)
		{
			int titleBarHeight = this.ClientTopLeft.Y;
			int remainingHeight = this.Height - titleBarHeight;
			double yOverH = ((double)y) / ((double)remainingHeight);
			double sqrt = Math.Sqrt(1.0 - yOverH * yOverH);
			return (int)((1.0 - sqrt) * ((double)this.Width) / 2.0);
		}

		private void SetButtonLocations()
		{
			for (int i=0; i<nButtons; i++)
			{
				int y = 5 + (int)((double)(this.buttons[0].Height * i) * 1.7);
				int x = LeftBorderY2X(y + this.buttons[i].Height);
				this.buttons[i].Location = new Point(x, y);
			}
		}

		private void btnColors_Click(object sender, System.EventArgs e)
		{
			lbResults.Items.Clear();
			lbResults.Items.AddRange(this.colors);
		}

		private void btnShapes_Click(object sender, System.EventArgs e)
		{
			lbResults.Items.Clear();
			lbResults.Items.AddRange(this.shapes);
		}


	}
}
