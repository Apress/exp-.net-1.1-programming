using System;
using System.Security;
using System.Security.Permissions;
using System.Drawing;
using System.Reflection;

[assembly:AssemblyKeyFile("ApressWMDDetectors.snk")]
[assembly: AssemblyVersion("1.0.1.0")]
[assembly: AllowPartiallyTrustedCallers()]

namespace Apress.Expert.WMDDetector
{
	public class WMDDetectorDriver
	{
		public string ReadValue()
		{
			WMDDetectorPermission perm = new WMDDetectorPermission(WMDDetectorPermissions.Read);
			perm.Demand();
			return "Warning: potentially dangerous IT Managers detected in the vicinity. Suggest go to yellow alert";
		}
	}
}
