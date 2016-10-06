using System;
//using System.Collections;
using System.ComponentModel;
using System.Drawing;
//using System.Data;
using System.Windows.Forms;
using System.Reflection;
//using System.Runtime.CompilerServices;
using System.Resources;
using System.Globalization;
using System.Threading;


namespace Apress.ExpertDotNet.GreetMeSample
{
	public class FlagDlg : Form
	{
		private PictureBox flagCtrl = new PictureBox();

		public FlagDlg()
		{
			ResourceManager resManager = new ResourceManager("Strings", Assembly.GetExecutingAssembly());
			this.Text = resManager.GetString("DialogCaption") + " " + Thread.CurrentThread.CurrentUICulture.ToString();
			resManager = new ResourceManager("Flags", Assembly.GetExecutingAssembly());
			this.ClientSize = new Size(150,100);
			flagCtrl.Image = (Image)resManager.GetObject("Flag");
			flagCtrl.Location = new Point(20,20);
			flagCtrl.Parent = this;
		}

	}
}