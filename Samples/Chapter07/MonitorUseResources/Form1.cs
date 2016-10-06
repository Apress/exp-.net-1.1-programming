using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Apress.ExpertDotNet.MonitorUseResources
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
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbGen0Collections;
		private System.Windows.Forms.TextBox tbGen1Collections;
		private System.ComponentModel.IContainer components;

		PerformanceCounter pcGen0Collections = new PerformanceCounter();
		private System.Windows.Forms.Timer timer;
		PerformanceCounter pcGen1Collections = new PerformanceCounter();

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.pcGen0Collections = new PerformanceCounter(".NET CLR Memory",
				"# Gen 0 Collections", "MonitorUseResou");
			this.pcGen0Collections.BeginInit();
			this.pcGen1Collections = new PerformanceCounter(".NET CLR Memory",
				"# Gen 1 Collections", "MonitorUseResou");
			this.pcGen1Collections.BeginInit();

			this.label1.Text = this.pcGen0Collections.CounterName;
			this.label2.Text = this.pcGen1Collections.CounterName;

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
			this.components = new System.ComponentModel.Container();
			this.btn1MB = new System.Windows.Forms.Button();
			this.btnCleanupArrays = new System.Windows.Forms.Button();
			this.btnEmptyWorkingSet = new System.Windows.Forms.Button();
			this.btn50MB = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.tbGen1Collections = new System.Windows.Forms.TextBox();
			this.tbGen0Collections = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
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
			this.statusBar.Location = new System.Drawing.Point(0, 192);
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
			// groupBox3
			// 
			this.groupBox3.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.tbGen1Collections,
																					this.tbGen0Collections,
																					this.label2,
																					this.label1});
			this.groupBox3.Location = new System.Drawing.Point(8, 112);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(272, 72);
			this.groupBox3.TabIndex = 8;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Performance Counters";
			// 
			// tbGen1Collections
			// 
			this.tbGen1Collections.Location = new System.Drawing.Point(160, 40);
			this.tbGen1Collections.Name = "tbGen1Collections";
			this.tbGen1Collections.ReadOnly = true;
			this.tbGen1Collections.Size = new System.Drawing.Size(104, 20);
			this.tbGen1Collections.TabIndex = 3;
			this.tbGen1Collections.Text = "";
			// 
			// tbGen0Collections
			// 
			this.tbGen0Collections.Location = new System.Drawing.Point(160, 16);
			this.tbGen0Collections.Name = "tbGen0Collections";
			this.tbGen0Collections.ReadOnly = true;
			this.tbGen0Collections.Size = new System.Drawing.Size(104, 20);
			this.tbGen0Collections.TabIndex = 2;
			this.tbGen0Collections.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(136, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "label2";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			// 
			// timer
			// 
			this.timer.Enabled = true;
			this.timer.Interval = 1000;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(296, 214);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.groupBox3,
																		  this.statusBar,
																		  this.btn50MB,
																		  this.btnEmptyWorkingSet,
																		  this.btn1MB,
																		  this.groupBox1,
																		  this.groupBox2});
			this.Name = "Form1";
			this.Text = "MonitorUseResources Sample";
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
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

		private void timer_Tick(object sender, System.EventArgs e)
		{
			this.tbGen0Collections.Text = 
				this.pcGen0Collections.NextValue().ToString();
			this.tbGen1Collections.Text = this.pcGen1Collections.NextValue().ToString();
		}
	}
}
