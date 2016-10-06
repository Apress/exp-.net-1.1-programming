using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Apress.ExpertDotNet.UseResources
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	/// 

	public class MegaByteClass
	{
		int [][] array = new int[100][];

		public MegaByteClass()
		{
			for (int i=0 ; i<100 ; i++)
				array[i] = new int[2600];
		}
	}

	public class Form1 : System.Windows.Forms.Form
	{
		[DllImport("psapi.dll")]
		static extern int EmptyWorkingSet(IntPtr hProcess);
		
		private ArrayList arrays = new ArrayList();

		private System.Windows.Forms.Button btn1MB;
		private System.Windows.Forms.Button btnCleanupArrays;
		private System.Windows.Forms.Button btnEmptyWorkingSet;
		private System.Windows.Forms.Button btn50MB;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
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

		public void AddArray()
		{	
			arrays.Add(new MegaByteClass());
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
			this.btn1MB = new System.Windows.Forms.Button();
			this.btnCleanupArrays = new System.Windows.Forms.Button();
			this.btnEmptyWorkingSet = new System.Windows.Forms.Button();
			this.btn50MB = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// btn1MB
			// 
			this.btn1MB.Location = new System.Drawing.Point(16, 32);
			this.btn1MB.Name = "btn1MB";
			this.btn1MB.Size = new System.Drawing.Size(96, 23);
			this.btn1MB.TabIndex = 0;
			this.btn1MB.Text = "Allocate 1MB";
			this.btn1MB.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnCleanupArrays
			// 
			this.btnCleanupArrays.Location = new System.Drawing.Point(8, 48);
			this.btnCleanupArrays.Name = "btnCleanupArrays";
			this.btnCleanupArrays.Size = new System.Drawing.Size(104, 23);
			this.btnCleanupArrays.TabIndex = 2;
			this.btnCleanupArrays.Text = "Cleanup Arrays";
			this.btnCleanupArrays.Click += new System.EventHandler(this.btnCleanupArrays_Click);
			// 
			// btnEmptyWorkingSet
			// 
			this.btnEmptyWorkingSet.Location = new System.Drawing.Point(160, 32);
			this.btnEmptyWorkingSet.Name = "btnEmptyWorkingSet";
			this.btnEmptyWorkingSet.Size = new System.Drawing.Size(112, 23);
			this.btnEmptyWorkingSet.TabIndex = 3;
			this.btnEmptyWorkingSet.Text = "Empty Working Set";
			this.btnEmptyWorkingSet.Click += new System.EventHandler(this.btnEmptyWorkingSet_Click);
			// 
			// btn50MB
			// 
			this.btn50MB.Location = new System.Drawing.Point(16, 64);
			this.btn50MB.Name = "btn50MB";
			this.btn50MB.Size = new System.Drawing.Size(96, 23);
			this.btn50MB.TabIndex = 4;
			this.btn50MB.Text = "Allocate 50MB";
			this.btn50MB.Click += new System.EventHandler(this.btn50MB_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(8, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(128, 88);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Allocate Memory";
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 112);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(296, 22);
			this.statusBar.TabIndex = 6;
			this.statusBar.Text = "No arrays allocated";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.btnCleanupArrays});
			this.groupBox2.Location = new System.Drawing.Point(152, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(128, 88);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Free Memory";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(296, 134);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.statusBar,
																		  this.btn50MB,
																		  this.btnEmptyWorkingSet,
																		  this.btn1MB,
																		  this.groupBox1,
																		  this.groupBox2});
			this.Name = "Form1";
			this.Text = "UseResources Sample";
			this.groupBox2.ResumeLayout(false);
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

		private void button1_Click(object sender, System.EventArgs e)
		{
			AddArray();
			this.statusBar.Text = arrays.Count.ToString() + " MB allocated";
		}

		private void btnCleanupArrays_Click(object sender, System.EventArgs e)
		{
			arrays.Clear();
			this.statusBar.Text = "No arrays allocated";
			GC.Collect(GC.MaxGeneration);
		}


		private void btnEmptyWorkingSet_Click(object sender, System.EventArgs e)
		{
			IntPtr hThisProcess = Process.GetCurrentProcess().Handle;
			EmptyWorkingSet(hThisProcess);
		}

		private void btn50MB_Click(object sender, System.EventArgs e)
		{
			for (int i=0 ; i<50 ; i++)
			{
				AddArray();
				this.statusBar.Text = arrays.Count.ToString() + " MB added";
				this.statusBar.Refresh();
			}
		}
	}
}
