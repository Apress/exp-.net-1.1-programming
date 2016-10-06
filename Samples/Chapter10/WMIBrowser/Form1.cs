using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Management;

namespace Apress.ExpertDotNet.WMIBrowser
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		int count;
		private System.Windows.Forms.StatusBar statusValue;
		private System.Windows.Forms.TreeView tvNamespaces;
		private System.Windows.Forms.Button btnDetails;
		private System.Windows.Forms.ListBox lbClasses;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
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

			this.tvNamespaces.Nodes.Clear();//.Items.Clear();
			this.AddNamespacesToList();

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
			this.statusValue = new System.Windows.Forms.StatusBar();
			this.lbClasses = new System.Windows.Forms.ListBox();
			this.tvNamespaces = new System.Windows.Forms.TreeView();
			this.btnDetails = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// statusValue
			// 
			this.statusValue.Location = new System.Drawing.Point(0, 327);
			this.statusValue.Name = "statusValue";
			this.statusValue.Size = new System.Drawing.Size(584, 22);
			this.statusValue.TabIndex = 2;
			this.statusValue.Text = "statusBar1";
			// 
			// lbClasses
			// 
			this.lbClasses.Location = new System.Drawing.Point(288, 72);
			this.lbClasses.Name = "lbClasses";
			this.lbClasses.Size = new System.Drawing.Size(288, 251);
			this.lbClasses.Sorted = true;
			this.lbClasses.TabIndex = 4;
			// 
			// tvNamespaces
			// 
			this.tvNamespaces.ImageIndex = -1;
			this.tvNamespaces.Location = new System.Drawing.Point(0, 72);
			this.tvNamespaces.Name = "tvNamespaces";
			this.tvNamespaces.SelectedImageIndex = -1;
			this.tvNamespaces.Size = new System.Drawing.Size(280, 251);
			this.tvNamespaces.Sorted = true;
			this.tvNamespaces.TabIndex = 5;
			this.tvNamespaces.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvNamespaces_AfterSelect);
			// 
			// btnDetails
			// 
			this.btnDetails.Location = new System.Drawing.Point(488, 8);
			this.btnDetails.Name = "btnDetails";
			this.btnDetails.Size = new System.Drawing.Size(80, 23);
			this.btnDetails.TabIndex = 6;
			this.btnDetails.Text = "Class Details";
			this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 48);
			this.label1.Name = "label1";
			this.label1.TabIndex = 7;
			this.label1.Text = "Namespaces";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(296, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "Classes";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(256, 32);
			this.label3.TabIndex = 9;
			this.label3.Text = "Select a class and the click the Class Details button to see instances, methods a" +
				"nd properties";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(584, 349);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label3,
																		  this.label2,
																		  this.label1,
																		  this.btnDetails,
																		  this.tvNamespaces,
																		  this.lbClasses,
																		  this.statusValue});
			this.Name = "Form1";
			this.Text = "WMI Browser";
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

		private void AddNamespacesToList() 
		{
			try 
			{
				string nsName = @"\\.\root";
				TreeNode node = new TreeNode(nsName);
				node.Tag = nsName;
				this.tvNamespaces.Nodes.Add(node);
				RecurseAddSubNamespaces(nsName, node);
				node.Expand();
			}
			catch (Exception e)   
			{
				this.statusValue.Text = "ERROR: " + e.Message;
			}
		}

		void RecurseAddSubNamespaces(string nsName, TreeNode parent)
		{
			ManagementClass nsClass = new ManagementClass(nsName + ":__namespace");
			foreach(ManagementObject ns in nsClass.GetInstances()) 
			{
				string childName = ns["Name"].ToString();
				TreeNode childNode = new TreeNode(childName);
				string fullPath = nsName + @"\" + childName;
				childNode.Tag = fullPath;
				parent.Nodes.Add(childNode);
				RecurseAddSubNamespaces(fullPath, childNode);
				count++;
			}
		}

		private void tvNamespaces_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			AddClasses(e.Node.Tag.ToString());
		}

		void AddClasses(string ns)
		{
			lbClasses.Items.Clear();
			count = 0;
			try 
			{   
				ManagementObjectSearcher searcher = new ManagementObjectSearcher(
					ns, "select * from meta_class");               
				foreach (ManagementClass wmiClass in searcher.Get()) 
				{
					this.lbClasses.Items.Add(wmiClass["__CLASS"].ToString());
					count++;
				}
				this.statusValue.Text = count + " classes found in selected namespace.";
			}
			catch (Exception ex) 
			{
				this.statusValue.Text = ex.Message;
			}
		}

		private void btnDetails_Click(object sender, System.EventArgs e)
		{
			string classPath = this.tvNamespaces.SelectedNode.Tag.ToString() 
				+ ":" + this.lbClasses.SelectedItem.ToString();
			ClassAnalyzerForm subForm = new ClassAnalyzerForm(classPath);
			subForm.ShowDialog();
		}
	}
}


