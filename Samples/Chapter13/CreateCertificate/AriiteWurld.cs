using System;
using System.Windows.Forms;
using System.Drawing;

namespace Apress.ExpertDotNet.SignedForm
{
	public class EntryPoint
	{
		static void Main() 
		{
			Form form = new Form();
			form.Text = "Ariite, Wurld!";
			form.Size = new Size(200,200);
			Application.Run(form);
		}
	}
}
