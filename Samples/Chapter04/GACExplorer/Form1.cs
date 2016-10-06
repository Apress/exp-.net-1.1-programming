using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace GACExplorer
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.ListView lvFiles;
		private FolderTreeView tvFolders;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private string assemblyFolder = null;

		public Form1()
		{
			// before compiling you'll need to change this string to match your computer
			assemblyFolder = Environment.GetEnvironmentVariable("windir") + @"\assembly";
			InitializeComponent();
			tvFolders.Initialize();
			lvFiles.View = View.Details;
			lvFiles.Columns.Add("File", 150, HorizontalAlignment.Right);
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
			this.tvFolders = new FolderTreeView(this.assemblyFolder);
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.lvFiles = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			// 
			// tvFolders
			// 
			this.tvFolders.DoubleClick += new EventHandler(this.treeView_DoubleClick);
			this.tvFolders.KeyPress += new KeyPressEventHandler(this.treeView_KeyPress);
			this.tvFolders.Dock = System.Windows.Forms.DockStyle.Left;
			this.tvFolders.ImageIndex = -1;
			this.tvFolders.Name = "tvFolders";
			this.tvFolders.SelectedImageIndex = -1;
			this.tvFolders.Size = new System.Drawing.Size(180, 373);
			this.tvFolders.TabIndex = 0;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(180, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 373);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// lvFiles
			// 
			this.lvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvFiles.Location = new System.Drawing.Point(124, 0);
			this.lvFiles.Name = "lvFiles";
			this.lvFiles.Size = new System.Drawing.Size(309, 373);
			this.lvFiles.TabIndex = 2;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(492, 373);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lvFiles,
																		  this.splitter1,
																		  this.tvFolders});
			this.Name = "Form1";
			this.Text = "GAC Explorer";
			this.ResumeLayout(false);

		}
		#endregion

		private void ReplaceListViewContents(FolderTreeNode ftn)
		{
			string path = ftn.FolderPath;
			lvFiles.Items.Clear();
			DirectoryInfo info = new DirectoryInfo(ftn.FolderPath);
			foreach (FileInfo file in info.GetFiles())
			{
				lvFiles.Items.Add(file.Name);
			}
		}

		private void treeView_DoubleClick(object sender, System.EventArgs e)
		{
			FolderTreeNode ftn = tvFolders.SelectedNode as FolderTreeNode;
			ReplaceListViewContents(ftn);
		}

		private void treeView_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
			{
				FolderTreeNode ftn = tvFolders.SelectedNode as FolderTreeNode;
				ReplaceListViewContents(ftn);
			}		
		}

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
