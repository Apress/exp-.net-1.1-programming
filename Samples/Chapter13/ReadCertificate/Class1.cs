using System;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace CreateCertificate
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			string filePath;
			OpenFileDialog dlg = new OpenFileDialog();
			if (dlg.ShowDialog() != DialogResult.OK)
				return;
			filePath = dlg.FileName;
			Console.WriteLine(filePath);
			X509Certificate cert = X509Certificate.CreateFromCertFile(filePath);
			Console.WriteLine("Name:\t\t" + cert.GetName());
			Console.WriteLine("Algorithm:\t" + cert.GetKeyAlgorithm());
			Console.WriteLine("Valid from:\t" + cert.GetEffectiveDateString());
			Console.WriteLine("Valid to:\t" + cert.GetExpirationDateString());
			Console.WriteLine("Issuer:\t\t" + cert.GetIssuerName());
		}
	}
}
