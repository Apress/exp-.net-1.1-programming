using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;

namespace Apress.ExpertDotNet.AbortableOperation
{
	/// <summary>
	/// Summary description for AbortDialog.
	/// </summary>
	public class AbortDialog : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Button btnCancel;

		Form1 mainForm;
		public AbortDialog(Form1 mainForm)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.mainForm = mainForm;
		}

		public void SetProgress(int progress)
		{
			int increment = progress - progressBar1.Value;
			Debug.Assert(increment >= 0);
			this.progressBar1.Increment(increment);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			btnCancel.Enabled = false;
			mainForm.CancelAsyncOperation();
		}


		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(8, 8);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(200, 23);
			this.progressBar1.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(8, 40);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// AbortDialog
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(216, 70);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnCancel,
																		  this.progressBar1});
			this.Name = "AbortDialog";
			this.Text = "Retrieving Data...";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
