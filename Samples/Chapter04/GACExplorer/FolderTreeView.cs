using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace GACExplorer
{
	public class FolderTreeView : System.Windows.Forms.TreeView
	{
		private System.ComponentModel.Container components = null;
		private string assemblyFolder;

		public FolderTreeView(string assemblyFolder)
		{
			InitializeComponent();

			this.assemblyFolder = assemblyFolder;
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		public void Initialize()
		{
			this.Nodes.Clear();
			DirectoryInfo folder = new DirectoryInfo(assemblyFolder);
			this.Nodes.Add(new FolderTreeNode(folder));
/*			foreach (DirectoryInfo child in folder.GetDirectories())
			{
				this.Nodes.Add(new FolderTreeNode(child));
			}*/
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// FolderTreeView
			// 
			this.DoubleClick += new System.EventHandler(this.FolderTreeView_DoubleClick);
			this.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.FolderTreeView_BeforeCollapse);
			this.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.FolderTreeView_BeforeExpand);

		}
		#endregion

		private void FolderTreeView_DoubleClick(object sender, System.EventArgs e)
		{
			FolderTreeNode ftn = this.SelectedNode as FolderTreeNode;
			//			ftn.Open();	
			ftn.Expand();
		}

		private void FolderTreeView_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == '\n')
			{
				FolderTreeNode ftn = this.SelectedNode as FolderTreeNode;
				//				ftn.Open();
				ftn.Expand();
			}
		}

		private void FolderTreeView_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			TreeNode node = e.Node;
			FolderTreeNode folderNode = node as FolderTreeNode;
			if (folderNode != null)
				folderNode.AddSubFolders();
		}

		private void FolderTreeView_BeforeCollapse(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			TreeNode node = e.Node;
			FolderTreeNode folderNode = node as FolderTreeNode;
			if (folderNode != null)
				folderNode.RemoveSubFolders();
		}
	}
}
