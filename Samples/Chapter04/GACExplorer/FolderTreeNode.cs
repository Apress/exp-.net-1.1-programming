using System;
using System.IO;
using System.Windows.Forms;

namespace GACExplorer 
{
	public class DummyFolderNode : TreeNode
	{
		public DummyFolderNode() : base("Dummy")
		{
		}
	}

	public class FolderTreeNode : TreeNode
	{
		string parent;
		string name;
		string path;
		bool exists;

		public FolderTreeNode(DirectoryInfo folder)
			:	base(folder.Name)
		{
			this.parent = folder.Parent.FullName;
			this.name = folder.Name;
			this.path = folder.FullName;
			this.exists = folder.Exists;
			if (this.exists && GetSubFolders(folder).Length > 0)
				this.Nodes.Add(new DummyFolderNode());
		}

		public int AddSubFolders()
		{
			ClearDummyNodes();
			DirectoryInfo folder = new DirectoryInfo(path);
			this.exists = folder.Exists;
			int i = 0;
			if (this.exists)
			{
				foreach (DirectoryInfo child in GetSubFolders(folder))
				{
					this.Nodes.Add(new FolderTreeNode(child));
					++i;
				}
			}
			return i;
		}

		public void RemoveSubFolders()
		{
			bool subFolders = false;
			for(int i = this.Nodes.Count-1 ; i >= 0 ; i--)//TreeNode child in this.Nodes)
			{
				TreeNode child = this.Nodes[i];
				if (child is FolderTreeNode)
				{
					this.Nodes.RemoveAt(i);
					subFolders = true;
				}
			}
			if (subFolders)
				this.Nodes.Add(new DummyFolderNode());
		}

		public void ClearDummyNodes()
		{
			foreach (TreeNode child in this.Nodes)
			{
				if (child is DummyFolderNode)
					this.Nodes.Remove(child);
			}
		}

		public static DirectoryInfo [] GetSubFolders(DirectoryInfo info)
		{
			DirectoryInfo [] result = new DirectoryInfo[0];
			try
			{
				result = info.GetDirectories();
			}
			catch (Exception e)
			{
			}
			return result;
		}

		public string FolderPath
		{
			get
			{
				return path;
			}
		}
	}
}
