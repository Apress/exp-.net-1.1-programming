using System;
using System.Management;

namespace Apress.ExpertDotNet.MonitorDisplaySettings
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		static void Main()
		{
			WqlEventQuery query = new WqlEventQuery(
				"SELECT * FROM __InstanceModificationEvent " +
				"WITHIN 2 WHERE TargetInstance ISA \"Win32_DisplayConfiguration\" " +
				"AND TargetInstance.PelsWidth < 1024 AND PreviousInstance.PelsWidth " +
				">= 1024");
			ManagementEventWatcher watcher = new ManagementEventWatcher(query);
			CallbackClass callback = new CallbackClass();
			watcher.EventArrived += new EventArrivedEventHandler(
				callback.DisplayProblemCallback);
    
			watcher.Start();
			Console.WriteLine("Monitoring display settings.");
			Console.WriteLine("Hit return to stop monitoring and exit.");
			Console.ReadLine();             
			watcher.Stop();
		}

	}
	public class CallbackClass 
	{
		public void DisplayProblemCallback(object sender, EventArrivedEventArgs e) 
		{
			Console.WriteLine("Warning! Display settings have dropped " +
				"below 1024x768");
		}
	}

}
