using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;

namespace InitialUpdate
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox lbInitData;
		private System.Windows.Forms.Button button1;
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

		private void Initialize()
		{
			this.BeginInvoke(new AddItemDelegate(AddItem), new object[] { "Initializing..." });
			Thread.Sleep(1500);

			this.BeginInvoke(new AddItemDelegate(AddItem), new object[] { "Preparing Table Definitions" });
			Thread.Sleep(1500);

			this.BeginInvoke(new AddItemDelegate(AddItem), new object[] { "Loading Database" });
			Thread.Sleep(1500);

			this.BeginInvoke(new AddItemDelegate(AddItem), new object[] { "Done" });
			this.BeginInvoke(new ReadyFormDelegate(DoneInitialize));
		}

		private delegate void AddItemDelegate(string item);
		private delegate void ReadyFormDelegate();

		private void AddItem(string item )
		{
			lbInitData.Items.Add(item);
		}

		private void DoneInitialize()
		{
			this.button1.Enabled = true;
		}


		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lbInitData = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lbInitData
			// 
			this.lbInitData.Name = "lbInitData";
			this.lbInitData.Size = new System.Drawing.Size(224, 95);
			this.lbInitData.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Enabled = false;
			this.button1.Location = new System.Drawing.Point(8, 104);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(88, 24);
			this.button1.TabIndex = 1;
			this.button1.Text = "DoSomething";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(224, 134);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button1,
																		  this.lbInitData});
			this.Name = "Form1";
			this.Text = "InitialUpdate Sample";
			this.Load += new System.EventHandler(this.Form1_Load);
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

		private void Form1_Load(object sender, System.EventArgs e)
		{
			Thread initThread = new Thread(new ThreadStart(Initialize));
			initThread.Start();
		}
	}
}
