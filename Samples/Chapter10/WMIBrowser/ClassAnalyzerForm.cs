using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Management;
using System.Diagnostics;
using System.Collections.Specialized;

namespace Apress.ExpertDotNet.WMIBrowser
{
	/// <summary>
	/// Summary description for ClassAnalyzerForm.
	/// </summary>
	public class ClassAnalyzerForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		ManagementObject [] instances;
		ManagementClass mgmtClass;
		string className;

		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ListBox lbInstances;
		private System.Windows.Forms.ListView lvProperties;
		private System.Windows.Forms.ColumnHeader hdrName;
		private System.Windows.Forms.ColumnHeader hdrValue;
		private System.Windows.Forms.ListBox lbMethods;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;

		public ClassAnalyzerForm(string className)
		{
			InitializeComponent();
			this.className = className;
			this.Text = this.className;
			mgmtClass = new ManagementClass(this.className);
			mgmtClass.Get();
			AddInstances();
			AddProperties(mgmtClass);
			AddMethods();
		}

		void AddInstances()
		{
			try
			{
				ManagementObjectCollection instances = mgmtClass.GetInstances();
				ArrayList tempInstances = new ArrayList();
				ArrayList tempIndices = new ArrayList();
				foreach (ManagementObject instance in instances)
				{
					int index = this.lbInstances.Items.Add(instance["__RelPath"].ToString());
					tempInstances.Add(instance);
					tempIndices.Add(index);
				}

				this.instances = new ManagementObject [tempInstances.Count];
				for (int i=0 ; i<tempInstances.Count ; i++)
					this.instances[(int)tempIndices[i]] = (ManagementObject)tempInstances[i];
			}
			catch (Exception e)
			{
				this.lbInstances.Items.Add("ERROR:" + e.Message);
			}
		}
		void AddProperties(ManagementObject mgmtObj)
		{
			lvProperties.Items.Clear();
			try
			{
				foreach (PropertyData instance in mgmtObj.Properties)
				{
					ListViewItem prop = new ListViewItem(instance.Name);
					if (instance.IsArray)
						prop.SubItems.Add("<Array>");
					else
					{
						object value =instance.Value;
						if (value == null)
							prop.SubItems.Add("<No value>");
						else
							prop.SubItems.Add(value.ToString());
					}
					this.lvProperties.Items.Add(prop);
				}
			}
			catch (Exception e)
			{
				this.lvProperties.Items.Add("ERROR:" + e.Message);
			}
		}
		void AddMethods()
		{
			try
			{
				foreach (MethodData instance in mgmtClass.Methods)
				{
					this.lbMethods.Items.Add(instance.Name);
				}
			}
			catch (Exception e)
			{
				this.lbMethods.Items.Add("ERROR:" + e.Message);
			}
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
			this.lbInstances = new System.Windows.Forms.ListBox();
			this.lvProperties = new System.Windows.Forms.ListView();
			this.hdrName = new System.Windows.Forms.ColumnHeader();
			this.hdrValue = new System.Windows.Forms.ColumnHeader();
			this.lbMethods = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lbInstances
			// 
			this.lbInstances.HorizontalScrollbar = true;
			this.lbInstances.Location = new System.Drawing.Point(0, 24);
			this.lbInstances.Name = "lbInstances";
			this.lbInstances.Size = new System.Drawing.Size(264, 212);
			this.lbInstances.TabIndex = 0;
			this.lbInstances.SelectedIndexChanged += new System.EventHandler(this.lbInstances_SelectedIndexChanged);
			// 
			// lvProperties
			// 
			this.lvProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.hdrName,
																						   this.hdrValue});
			this.lvProperties.Location = new System.Drawing.Point(272, 24);
			this.lvProperties.Name = "lvProperties";
			this.lvProperties.Size = new System.Drawing.Size(480, 312);
			this.lvProperties.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvProperties.TabIndex = 3;
			this.lvProperties.View = System.Windows.Forms.View.Details;
			// 
			// hdrName
			// 
			this.hdrName.Text = "Name";
			this.hdrName.Width = 137;
			// 
			// hdrValue
			// 
			this.hdrValue.Text = "Value";
			this.hdrValue.Width = 152;
			// 
			// lbMethods
			// 
			this.lbMethods.Location = new System.Drawing.Point(0, 264);
			this.lbMethods.Name = "lbMethods";
			this.lbMethods.Size = new System.Drawing.Size(264, 69);
			this.lbMethods.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Instances";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 248);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "Methods";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(240, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "Properties";
			// 
			// ClassAnalyzerForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(760, 341);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label3,
																		  this.label2,
																		  this.label1,
																		  this.lbInstances,
																		  this.lvProperties,
																		  this.lbMethods});
			this.Name = "ClassAnalyzerForm";
			this.Load += new System.EventHandler(this.ClassAnalyzerForm_Load);
			this.ResumeLayout(false);

		}
		#endregion


		private void ClassAnalyzerForm_Load(object sender, System.EventArgs e)
		{
		}

		private void lbInstances_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			AddProperties(instances[lbInstances.SelectedIndex]);
		}
	}
}
