using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Security;
using System.Security.Permissions;

namespace Apress.ExpertDotNet.ListFolders
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnNoCheck;
		private System.Windows.Forms.RadioButton rblNoChecks;
		private System.Windows.Forms.RadioButton rblTryCatch;
		private System.Windows.Forms.RadioButton rblPermissions;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox lbFolders;
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
			this.btnNoCheck = new System.Windows.Forms.Button();
			this.lbFolders = new System.Windows.Forms.ListBox();
			this.rblNoChecks = new System.Windows.Forms.RadioButton();
			this.rblTryCatch = new System.Windows.Forms.RadioButton();
			this.rblPermissions = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnNoCheck
			// 
			this.btnNoCheck.Location = new System.Drawing.Point(16, 112);
			this.btnNoCheck.Name = "btnNoCheck";
			this.btnNoCheck.Size = new System.Drawing.Size(96, 23);
			this.btnNoCheck.TabIndex = 0;
			this.btnNoCheck.Text = "Show Folders";
			this.btnNoCheck.Click += new System.EventHandler(this.btnNoCheck_Click);
			// 
			// lbFolders
			// 
			this.lbFolders.Location = new System.Drawing.Point(176, 48);
			this.lbFolders.Name = "lbFolders";
			this.lbFolders.Size = new System.Drawing.Size(272, 134);
			this.lbFolders.TabIndex = 2;
			// 
			// rblNoChecks
			// 
			this.rblNoChecks.Checked = true;
			this.rblNoChecks.Location = new System.Drawing.Point(16, 24);
			this.rblNoChecks.Name = "rblNoChecks";
			this.rblNoChecks.Size = new System.Drawing.Size(144, 24);
			this.rblNoChecks.TabIndex = 3;
			this.rblNoChecks.TabStop = true;
			this.rblNoChecks.Text = "No Security Checks";
			// 
			// rblTryCatch
			// 
			this.rblTryCatch.Location = new System.Drawing.Point(16, 48);
			this.rblTryCatch.Name = "rblTryCatch";
			this.rblTryCatch.Size = new System.Drawing.Size(128, 24);
			this.rblTryCatch.TabIndex = 4;
			this.rblTryCatch.Text = "try...catch block only";
			// 
			// rblPermissions
			// 
			this.rblPermissions.Location = new System.Drawing.Point(16, 72);
			this.rblPermissions.Name = "rblPermissions";
			this.rblPermissions.Size = new System.Drawing.Size(152, 24);
			this.rblPermissions.TabIndex = 5;
			this.rblPermissions.Text = "Check Permissions First";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(176, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(192, 23);
			this.label1.TabIndex = 6;
			this.label1.Text = "Click button to show folders under C:\\";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(472, 198);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.rblPermissions);
			this.Controls.Add(this.rblTryCatch);
			this.Controls.Add(this.rblNoChecks);
			this.Controls.Add(this.lbFolders);
			this.Controls.Add(this.btnNoCheck);
			this.Name = "Form1";
			this.Text = "ListFoldersC";
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

		private void btnNoCheck_Click(object sender, System.EventArgs e)
		{
			if (this.rblNoChecks.Checked)
				ListFolders();
			else if (this.rblTryCatch.Checked)
				ListFoldersTryCatchOnly();
			else
				ListFoldersCheckPermissionsFirst();
		}

		private void ListFolders()
		{
		}

		private void ListFoldersTryCatchOnly()
		{
			this.lbFolders.Items.Clear();
			try
			{
				Auditor.DoAudit();
				DirectoryInfo c = new DirectoryInfo(@"C:\");
				foreach (DirectoryInfo folder in c.GetDirectories())
				{
					this.lbFolders.Items.Add(folder.FullName);
				}
			}
			catch(SecurityException ex)
			{
				string text = "You do not have permissions to carry out this operation.\n" +
					"Details of failure: " + ex.Message;
				MessageBox.Show( text,
					"Permission denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ListFoldersCheckPermissionsFirst()
		{
			try
			{
				FileIOPermission perm = new FileIOPermission(FileIOPermissionAccess.Read, @"C:\");
				perm.Demand();
				ListFolders();
			}
			catch(SecurityException ex)
			{
				string text = "You do not have permissions to carry out this operation.\n" +
					"Details of failure: " + ex.Message;
				MessageBox.Show( text,
					"Permission denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

	}
}
