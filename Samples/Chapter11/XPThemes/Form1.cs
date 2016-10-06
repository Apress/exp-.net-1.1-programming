using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace XPThemes
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.CheckBox cbXP;
		private System.Windows.Forms.Button btnClickMe;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ListBox lbResults;
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
			this.cbXP = new System.Windows.Forms.CheckBox();
			this.btnClickMe = new System.Windows.Forms.Button();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lbResults = new System.Windows.Forms.ListBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbXP
			// 
			this.cbXP.Checked = true;
			this.cbXP.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbXP.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbXP.Location = new System.Drawing.Point(32, 8);
			this.cbXP.Name = "cbXP";
			this.cbXP.Size = new System.Drawing.Size(176, 24);
			this.cbXP.TabIndex = 0;
			this.cbXP.Text = "Use XP Themes for buttons";
			this.cbXP.CheckedChanged += new System.EventHandler(this.cbXP_CheckedChanged);
			// 
			// btnClickMe
			// 
			this.btnClickMe.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnClickMe.Location = new System.Drawing.Point(16, 56);
			this.btnClickMe.Name = "btnClickMe";
			this.btnClickMe.TabIndex = 1;
			this.btnClickMe.Text = "Click Me";
			this.btnClickMe.Click += new System.EventHandler(this.btnClickMe_Click);
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(16, 88);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(152, 23);
			this.progressBar.TabIndex = 3;
			// 
			// radioButton1
			// 
			this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioButton1.Location = new System.Drawing.Point(184, 56);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(72, 24);
			this.radioButton1.TabIndex = 4;
			this.radioButton1.Text = "Choice 1";
			// 
			// radioButton2
			// 
			this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioButton2.Location = new System.Drawing.Point(184, 80);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(72, 24);
			this.radioButton2.TabIndex = 5;
			this.radioButton2.Text = "Choice 2";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.lbResults});
			this.groupBox1.Location = new System.Drawing.Point(8, 40);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(272, 224);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Controls";
			// 
			// lbResults
			// 
			this.lbResults.Location = new System.Drawing.Point(16, 88);
			this.lbResults.Name = "lbResults";
			this.lbResults.Size = new System.Drawing.Size(240, 121);
			this.lbResults.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 270);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.radioButton2,
																		  this.radioButton1,
																		  this.progressBar,
																		  this.btnClickMe,
																		  this.cbXP,
																		  this.groupBox1});
			this.Name = "Form1";
			this.Text = "XP Themes";
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

		private void cbXP_CheckedChanged(object sender, System.EventArgs e)
		{
			if (cbXP.Checked)
				SetXPTheme();
			else
				SetPreXPStyle();
		}

		public void SetXPTheme()
		{
			foreach (Control control in this.Controls)
			{
				if (control is ButtonBase)
					((ButtonBase)control).FlatStyle = FlatStyle.System;
			}
			this.Invalidate();
		}

		public void SetPreXPStyle()
		{
			foreach (Control control in this.Controls)
			{
				if (control is ButtonBase)
					((ButtonBase)control).FlatStyle = FlatStyle.Standard;
			}
			this.Invalidate();
		}

		private void btnClickMe_Click(object sender, System.EventArgs e)
		{
			progressBar.Increment(5);
			lbResults.Items.Add("I've been clicked!");
		}
	}
}
