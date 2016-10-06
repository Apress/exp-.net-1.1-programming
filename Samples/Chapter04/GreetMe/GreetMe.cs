using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.Globalization;
using System.Threading;

[assembly: AssemblyVersion("1.0.1.0")]
[assembly: AssemblyCulture("")]		
//[assembly: AssemblyDelaySign(true)]
[assembly: AssemblyKeyFile("ExpertDotNet.snk")]


namespace Apress.ExpertDotNet.GreetMeSample
{
	public class GreetingControl : System.Windows.Forms.Control
	{
		private Label greeting = new Label();
		private Button btnShowFlag = new Button();

		public GreetingControl()
		{
			ResourceManager resManager = new ResourceManager("strings", Assembly.GetExecutingAssembly());
			this.ClientSize = new Size(150,100);
			greeting.Text = resManager.GetString("Greeting");
			greeting.Location = new Point(20,20);
			greeting.Parent = this;
			btnShowFlag.Text = resManager.GetString("ButtonCaption");
			btnShowFlag.Location = new Point(20,50);
			btnShowFlag.Size = new Size(100,30);
			btnShowFlag.Parent = this;
			btnShowFlag.Click += new EventHandler(btnShowFlag_Click);
			btnShowFlag.TabIndex = 0;
		}

		void btnShowFlag_Click(object sender, System.EventArgs e)
		{
			FlagDlg dlg = new FlagDlg();
			dlg.ShowDialog();
		}
	}
}
