using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DontWantToClose
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		const uint WM_QUERYENDSESSION = 0x011;
		const uint ENDSESSION_LOGOFF = 0x80000000;

		private System.Windows.Forms.CheckBox cbAllowCloseShutdown;
		private System.Windows.Forms.CheckBox cbAllowCloseLogOff;
		private System.Windows.Forms.StatusBar statusBar;
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

		protected override void WndProc(ref Message msg)
		{
			if (msg.Msg == WM_QUERYENDSESSION)
			{
				if (((int)msg.LParam & ENDSESSION_LOGOFF) > 0)
				{
					if (!this.cbAllowCloseLogOff.Checked)
					{
						msg.Result = IntPtr.Zero;
						this.statusBar.Text = "Prevented a log off attempt";
						return;
					}
				}
				else
				{
					if (!this.cbAllowCloseShutdown.Checked)
					{
						msg.Result = IntPtr.Zero;
						this.statusBar.Text = "Prevented a shutdown attempt";
						return;
					}
				}
			}
			base.WndProc(ref msg);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cbAllowCloseShutdown = new System.Windows.Forms.CheckBox();
			this.cbAllowCloseLogOff = new System.Windows.Forms.CheckBox();
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.SuspendLayout();
			// 
			// cbAllowCloseShutdown
			// 
			this.cbAllowCloseShutdown.Location = new System.Drawing.Point(24, 8);
			this.cbAllowCloseShutdown.Name = "cbAllowCloseShutdown";
			this.cbAllowCloseShutdown.Size = new System.Drawing.Size(160, 24);
			this.cbAllowCloseShutdown.TabIndex = 0;
			this.cbAllowCloseShutdown.Text = "Allow Close on Shutdown";
			// 
			// cbAllowCloseLogOff
			// 
			this.cbAllowCloseLogOff.Location = new System.Drawing.Point(24, 48);
			this.cbAllowCloseLogOff.Name = "cbAllowCloseLogOff";
			this.cbAllowCloseLogOff.Size = new System.Drawing.Size(144, 24);
			this.cbAllowCloseLogOff.TabIndex = 1;
			this.cbAllowCloseLogOff.Text = "Allow Close on LogOff";
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 96);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(232, 22);
			this.statusBar.TabIndex = 2;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(232, 118);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.statusBar,
																		  this.cbAllowCloseLogOff,
																		  this.cbAllowCloseShutdown});
			this.Name = "Form1";
			this.Text = "DontWantToClose";
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

	}
}
