using System;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace Apress.ExpertDotNet.GreetMeSample
{
	public class TestHarness : System.Windows.Forms.Form
	{
		private GreetingControl greetCtrl = new GreetingControl();

		public TestHarness()
		{
			this.Text = "GreetMe Test Form";
			greetCtrl.Parent = this;
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
					Thread.CurrentThread.CurrentUICulture = new CultureInfo(args[0]);
				}
				catch (ArgumentException)
				{
					MessageBox.Show("Any parameter passed in must be a valid culture string");
				}
			}
			Application.Run(new TestHarness());
		}
	}
}
