using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace Apress.ExpertDotNet.CircularFormOwnerDraw
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private enum ListBoxContents { Colors, Shapes, Nothing };
		private ListBoxContents itemSetToDisplay = ListBoxContents.Nothing;
		private const int nButtons = 2;
		private Button [] buttons;

		private string [] colors = { "red", "orange", "yellow", "green",
									   "blue", "indigo", "violet" };
		private Color[] colorStructs = { Color.Red, Color.Orange, Color.Yellow,
										   Color.Green, Color.Blue, Color.Indigo,
										   Color.Violet };
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
			this.lbResults.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.lbResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbResults.ItemHeight = 24;
			this.lbResults.Location = new System.Drawing.Point(160, 32);
			this.lbResults.Name = "lbResults";
			this.lbResults.Size = new System.Drawing.Size(168, 172);
			this.lbResults.TabIndex = 2;
			this.lbResults.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lbResults_MeasureItem);
			this.lbResults.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbResults_DrawItem);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(488, 266);
			this.Controls.Add(this.lbResults);
			this.Controls.Add(this.btnShapes);
			this.Controls.Add(this.btnColors);
			this.MinimumSize = new System.Drawing.Size(350, 250);
			this.Name = "Form1";
			this.Text = "CircularFormOwnerDraw";
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


		private void lbResults_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
		{
			switch(this.itemSetToDisplay)
			{
				case ListBoxContents.Colors:
					PaintListBoxColors(e);
					break;
				case ListBoxContents.Shapes:
					PaintListBoxShapes(e);
					break;
				case ListBoxContents.Nothing:
					return;
			}
		}
		private void PaintListBoxShapes(DrawItemEventArgs e)
		{
			e.Graphics.FillRectangle(new SolidBrush(e.BackColor), e.Bounds);
			e.Graphics.DrawString(this.shapes[e.Index], e.Font, 
				new SolidBrush(e.ForeColor), 
				e.Bounds.Left + GetListBoxLeft(e.Bounds.Bottom), e.Bounds.Top);
		}

		private int GetListBoxLeft(int y)
		{
			double yOverH = ((double)y) / ((double)lbResults.Height);
			double sqrt = Math.Sqrt(1.0 - yOverH * yOverH);
			return (int)((1.0 - sqrt) * ((double)lbResults.Width) / 2.0);
		}

		private void PaintListBoxColors(DrawItemEventArgs e)
		{
			Color leftColor = e.BackColor;
			string text = null;
			Brush brush = null;
			Color rightColor = this.colorStructs[e.Index];
			text = this.colors[e.Index];
			brush = new LinearGradientBrush(e.Bounds, leftColor, rightColor,
				LinearGradientMode.Horizontal);
			e.Graphics.FillRectangle(brush, e.Bounds);
			e.Graphics.DrawString(text, e.Font, new SolidBrush(e.ForeColor),
				e.Bounds.Left + GetListBoxLeft(e.Bounds.Bottom), e.Bounds.Top);
		}


		private void lbResults_MeasureItem(object sender, System.Windows.Forms.MeasureItemEventArgs e)
		{
			if (itemSetToDisplay == ListBoxContents.Colors)
				e.ItemHeight += (2 * e.Index);
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
			itemSetToDisplay = ListBoxContents.Colors;
			lbResults.Items.AddRange(this.colors);
		}

		private void btnShapes_Click(object sender, System.EventArgs e)
		{
			lbResults.Items.Clear();
			itemSetToDisplay = ListBoxContents.Shapes;
			lbResults.Items.AddRange(this.shapes);
		}

		private void SetListBoxLocation()
		{
			int lbHeight = (this.ClientSize.Height * 8) / 9;
			int lbWidth = (this.ClientSize.Width) / 3;
			this.lbResults.Location = new Point(this.Width / 3, 5);
			this.lbResults.Size = new Size(lbWidth, lbHeight);

			int titleBarHeight = this.ClientTopLeft.Y;
			int remainingHeight = this.Height - titleBarHeight;
			GraphicsPath outline = new GraphicsPath();
			outline.AddLine(0, 0, lbWidth, 0);
			Rectangle twiceClientRect = new Rectangle(0, -lbHeight, lbWidth,
				(int)(1.9  * lbHeight));
			outline.AddArc(twiceClientRect, 0, 180);
			Region rgn = new Region(outline);
			this.lbResults.Region = rgn;
		}

	}
}
