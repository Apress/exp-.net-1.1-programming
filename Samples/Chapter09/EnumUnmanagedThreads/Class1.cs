using System;
using System.Diagnostics;

namespace Apress.ExpertDotNetSamples.Threading.EnumUnmanagedThreads
{
	class Class1
	{
		[STAThread]
		static void Main()
		{
			ProcessThreadCollection ptc = Process.GetCurrentProcess().Threads;
			Console.WriteLine("{0} threads in process", ptc.Count);
			foreach (ProcessThread pt in ptc)
			{
				Console.WriteLine("ID: {0}, State: {1}, Priority: {2}", pt.Id,
					pt.ThreadState, pt.PriorityLevel);
			}
		}
	}
}
