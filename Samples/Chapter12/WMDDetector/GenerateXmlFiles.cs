using System;
using System.IO;
using System.Security;
using System.Security.Permissions;

namespace Apress.Expert.WMDDetector
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
		static void Main(string[] args)
		{
			WritePermission("WMDDetectorPermission.xml");
			WritePermissionSet("ReadWMDDetector.xml");
		}

		static void WritePermission(string file)
		{
			WMDDetectorPermission perm = 
				new WMDDetectorPermission(WMDDetectorPermissions.Read);
			StreamWriter sw = new StreamWriter(file);
			sw.Write(perm.ToXml());
			sw.Close();
		}

		static void WritePermissionSet(string file)
		{
			WMDDetectorPermission perm = 
				new WMDDetectorPermission(WMDDetectorPermissions.Read);
			NamedPermissionSet pset = 
				new NamedPermissionSet("ReadWMDDetector");
			pset.Description = "WMD Detector Permission Set";
			pset.SetPermission(perm);
			StreamWriter sw = new StreamWriter(file);
			sw.Write(pset.ToXml());
			sw.Close();
		}
	}
}
