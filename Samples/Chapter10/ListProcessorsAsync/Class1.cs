using System;
using System.Management;

namespace ListProcessorsAsync
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		static void Main()
		{
			ManagementObjectSearcher processorSearcher = new ManagementObjectSearcher(
				"SELECT Name, CurrentClockSpeed FROM Win32_Processor");

			ManagementOperationObserver observer = new ManagementOperationObserver();
			CallBackClass callBackObject = new CallBackClass();
			observer.Completed += new
				CompletedEventHandler(callBackObject.OnAllProcessors);
			observer.ObjectReady += new 
				ObjectReadyEventHandler(callBackObject.OnNextProcessor);

			processorSearcher.Get(observer);
			Console.WriteLine("Retrieving processors. Hit any key to terminate");
			Console.ReadLine();
		}
		class CallBackClass
		{
			int totalProcessors = 0;

			public void OnNextProcessor(object sender, ObjectReadyEventArgs e)
			{
				ManagementObject processor = (ManagementObject)e.NewObject;
				Console.WriteLine("Next processor object arrived:");
				Console.WriteLine("\t{0}, {1} MHz", processor["Name"],
					processor["CurrentClockSpeed"]);
				++totalProcessors;
			}

			public void OnAllProcessors(object sender, CompletedEventArgs e)
			{
				if (totalProcessors > 1)
					Console.WriteLine("\n{0} processors", totalProcessors);
				else
					Console.WriteLine("\n{0} processor", totalProcessors);
			}
		}
	}
}
