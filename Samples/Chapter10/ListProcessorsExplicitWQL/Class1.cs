using System;
using System.Management;

namespace Apress.ExpertDotNet.ListProcessorsExplicitWQL
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		static void Main()
		{
			int totalProcessors = 0;
			ManagementObjectSearcher processorSearcher = 
				new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
			foreach (ManagementObject processor in processorSearcher.Get())
			{
				++totalProcessors;
				Console.WriteLine("{0}, {1} MHz", processor["Name"],
					processor["CurrentClockSpeed"]);
			}
			if (totalProcessors > 1)
				Console.WriteLine("\n{0} processors", totalProcessors);
			else
				Console.WriteLine("\n{0} processor", totalProcessors);
		}

	}
}
