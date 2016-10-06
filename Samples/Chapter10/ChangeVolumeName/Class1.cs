using System;
using System.Management;

namespace ChangeVolumeName
{
	class Class1
	{

		[STAThread]
		static void Main()
		{
			ManagementObject cDrive = new ManagementObject(
				"Win32_LogicalDisk.DeviceID=\"C:\"");
			cDrive.Get();
			cDrive["VolumeName"] = "Changed";
			cDrive.Put();
		}
	}
}
