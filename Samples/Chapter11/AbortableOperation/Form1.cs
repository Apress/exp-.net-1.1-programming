using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Diagnostics;

namespace Apress.ExpertDotNet.AbortableOperation
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		public delegate void ResultsReturnedDelegate (string result);

		private Thread backgroundThread;
		private AbortDialog abortDialog; 
		private System.Windows.Forms.Button btnData;
		private System.Windows.Forms.TextBox tbData;
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
			this.btnData = new System.Windows.Forms.Button();
			this.tbData = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnData
			// 
			this.btnData.Location = new System.Drawing.Point(8, 8);
			this.btnData.Name = "btnData";
			this.btnData.TabIndex = 0;
			this.btnData.Text = "&Get Data";
			this.btnData.Click += new System.EventHandler(this.btnData_Click);
			// 
			// tbData
			// 
			this.tbData.Location = new System.Drawing.Point(8, 40);
			this.tbData.Multiline = true;
			this.tbData.Name = "tbData";
			this.tbData.Size = new System.Drawing.Size(320, 144);
			this.tbData.TabIndex = 1;
			this.tbData.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(336, 190);
			this.Controls.Add(this.tbData);
			this.Controls.Add(this.btnData);
			this.Name = "Form1";
			this.Text = "Abortable Operation";
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

		private void btnData_Click(object sender, System.EventArgs e)
		{
			this.tbData.Clear();
			ThreadStart entryPoint = new ThreadStart(RetrieveData);
			backgroundThread = new Thread(entryPoint);
			backgroundThread.Start();
			abortDialog = new AbortDialog(this);
			abortDialog.Show();
		}

		private delegate void SetProgressDelegate(int i);

		private void RetrieveData()
		{
			try
			{
				for (int i=5 ; i<=100 ; i+=5)
				{
					Thread.Sleep(500);
					SetProgressDelegate setProgress = new SetProgressDelegate(abortDialog.SetProgress);
					BeginInvoke(setProgress, new object[] {i});
				}
				string [] results = new String[1];
				results[0] = @"Apress is a great book publisher!

Check out ASP Today at http://www.asptoday.com for articles about advanced ASP.NET coding
Latest articles:
   Building a Media Encoding System Part 3
   Project Estimation for Developers";
				ResultsReturnedDelegate resultsReturned = new
					ResultsReturnedDelegate(this.OnResultsReturned);
				BeginInvoke(resultsReturned, results);
			}
			finally
			{
				// Simulate it takes a short time to and clean up resources
				Thread.Sleep(1000);
			}
		}

		public void CancelAsyncOperation()
		{
			Debug.Assert(abortDialog != null);
			backgroundThread.Abort();

			abortDialog.Text = "Aborting...";
			backgroundThread.Join();
			abortDialog.Close();
			abortDialog.Dispose();
		}
		public void OnResultsReturned(string result)
		{
			this.tbData.Text = result;
			this.abortDialog.Close();
			this.abortDialog.Dispose();
		}
	}
}
