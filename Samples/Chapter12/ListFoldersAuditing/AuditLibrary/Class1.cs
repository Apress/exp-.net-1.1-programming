using System;
using System.Security;
using System.Security.Permissions;
using System.IO;
using System.Reflection;

namespace Apress.ExpertDotNet.ListFolders
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Auditor
	{
		public static void DoAudit()
		{
			// Make auditing entries
			string auditFilePath = @"C:\ExpertDotNetAuditText.txt";
			FileIOPermission ioperm = new FileIOPermission(
				PermissionState.Unrestricted);
			ioperm.Assert();
			StreamWriter sw = new StreamWriter(auditFilePath, true);
			sw.WriteLine("Audit invoked at " + DateTime.Now.ToString());
			sw.WriteLine("   from assembly at " +
				Assembly.GetEntryAssembly().CodeBase);
			sw.WriteLine("   " + Assembly.GetEntryAssembly().FullName);
			sw.WriteLine();
			sw.Close();
			CodeAccessPermission.RevertAssert();
		}
	}
}
