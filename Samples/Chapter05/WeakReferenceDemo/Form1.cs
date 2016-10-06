using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Apress.ExpertDotNet.WeakReferenceDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private const int DataArrayLength = 500000;
		private const int ItemsInListBox = 20;
		private WeakReference wr;

		private System.Windows.Forms.Button btnShowData;
		private System.Windows.Forms.Button btnForceCollection;
		private System.Windows.Forms.ListBox lbData;
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
			this.btnShowData = new System.Windows.Forms.Button();
			this.btnForceCollection = new System.Windows.Forms.Button();
			this.lbData = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// btnShowData
			// 
			this.btnShowData.Location = new System.Drawing.Point(8, 8);
			this.btnShowData.Name = "btnShowData";
			this.btnShowData.TabIndex = 0;
			this.btnShowData.Text = "&Show Data";
			this.btnShowData.Click += new System.EventHandler(this.btnShowData_Click);
			// 
			// btnForceCollection
			// 
			this.btnForceCollection.Location = new System.Drawing.Point(96, 8);
			this.btnForceCollection.Name = "btnForceCollection";
			this.btnForceCollection.Size = new System.Drawing.Size(96, 23);
			this.btnForceCollection.TabIndex = 1;
			this.btnForceCollection.Text = "Force Collection";
			this.btnForceCollection.Click += new System.EventHandler(this.btnForceCollection_Click);
			// 
			// lbData
			// 
			this.lbData.Location = new System.Drawing.Point(8, 40);
			this.lbData.Name = "lbData";
			this.lbData.Size = new System.Drawing.Size(272, 212);
			this.lbData.TabIndex = 2;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lbData,
																		  this.btnForceCollection,
																		  this.btnShowData});
			this.Name = "Form1";
			this.Text = "Weak Reference Demo";
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

		private void btnShowData_Click(object sender, System.EventArgs e)
		{
			RefreshData();
		}

		private void btnForceCollection_Click(object sender, System.EventArgs e)
		{
			GC.Collect();		
		}

		private void RefreshData()
		{
			Cursor.Current = Cursors.WaitCursor;
			lbData.Items.Clear();
			lbData.Items.Add("Retrieving data. Please wait ...");
			lbData.Refresh();
			string[] dataArray;

			if (wr == null || wr.Target == null)
			{
				dataArray = new string[DataArrayLength];
				string text = " Created " + DateTime.Now.ToString("f");
				for (int i=0 ; i<DataArrayLength ; i++)
					dataArray[i] = "Element " + i.ToString() + text;
				wr = new WeakReference(dataArray);
			}
			else
				dataArray = (string[])wr.Target;


			string [] tempStrings = new String[ItemsInListBox];
			for (int i=0 ; i<ItemsInListBox ; i++)
				tempStrings[i] = dataArray[i];

			lbData.Items.Clear();
			lbData.Items.AddRange(tempStrings);
			Cursor.Current = Cursors.Default;
		}
	}
}