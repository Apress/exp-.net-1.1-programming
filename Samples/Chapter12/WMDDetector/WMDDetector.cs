using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.Security;

[assembly:AssemblyKeyFile("ApressWMDDetectors.snk")]
[assembly: AssemblyVersion("1.0.1.0")]

namespace Apress.Expert.WMDDetector
{

	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnRead;
		private System.Windows.Forms.TextBox tbResult;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			InitializeComponent();

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
			this.btnRead = new System.Windows.Forms.Button();
			this.tbResult = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnRead
			// 
			this.btnRead.Location = new System.Drawing.Point(16, 16);
			this.btnRead.Name = "btnRead";
			this.btnRead.TabIndex = 0;
			this.btnRead.Text = "Check for WMDs";
			this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
			this.btnRead.Size = new Size(100, 25);
			// 
			// tbResult
			// 
			this.tbResult.Location = new System.Drawing.Point(130, 50);
			this.tbResult.Multiline = true;
			this.tbResult.Name = "tbResult";
			this.tbResult.ReadOnly = true;
			this.tbResult.Size = new System.Drawing.Size(300, 80);
			this.tbResult.TabIndex = 1;
			this.tbResult.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(130, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "WMD Results:";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(480, 140);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label1,
																		  this.tbResult,
																		  this.btnRead});
			this.Name = "Form1";
			this.Text = "WMDDetector";
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

		private void btnRead_Click(object sender, System.EventArgs e)
		{
			try
			{
				WMDDetectorDriver driver = new WMDDetectorDriver();
				this.tbResult.Text = driver.ReadValue();
			}
			catch (SecurityException ex)
			{
				this.tbResult.Text = "SecurityException: " + ex.Message;
			}
			catch (Exception ex)
			{
				this.tbResult.Text = "Exception: " + ex.Message;
			}
		}
	}
}
