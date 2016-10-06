using System;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace Apress.ExpertDotNet.GreetMeVSNet
{
	public class TestHarness : System.Windows.Forms.Form
	{
		private Apress.ExpertDotNet.GreetMeVSNet.GreetingControl greetingControl1;

		private void InitializeComponent()
		{
			this.greetingControl1 = new Apress.ExpertDotNet.GreetMeVSNet.GreetingControl();
			this.SuspendLayout();
			// 
			// greetingControl1
			// 
			this.greetingControl1.Location = new System.Drawing.Point(16, 8);
			this.greetingControl1.Name = "greetingControl1";
			this.greetingControl1.Size = new System.Drawing.Size(144, 120);
			this.greetingControl1.TabIndex = 0;
			// 
			// TestHarness
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(248, 118);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.greetingControl1});
			this.Name = "TestHarness";
			this.Text = "GreetMe VS.NET";
			this.ResumeLayout(false);

		}

		public TestHarness()
		{
			InitializeComponent();
		}

	}

	public class EntryPoint
	{
		static void Main(string [] args) 
		{
			if (args.Length > 0)
			{
				try
				{
					Thread.CurrentThread.CurrentUICulture = new
						CultureInfo(args[0]);
				}
				catch (ArgumentException)
				{
					MessageBox.Show("The first parameter passed in " +
						"must be a valid culture string");
				}
			}
			Application.Run(new TestHarness());
		}
	}
}
