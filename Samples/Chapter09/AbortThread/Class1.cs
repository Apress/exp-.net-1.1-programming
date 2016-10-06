using System;
using System.Threading;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Text;


namespace Apress.ExpertDotNetSamples.Threading.AbortThread
{

	public delegate string GetAddressDelegate();

	public class ThreadUtils
	{
		public static string ThreadDescription(Thread thread)
		{
			StringBuilder sb = new StringBuilder(100);
			if (thread.Name != null && thread.Name != "")
			{
				sb.Append(thread.Name);
				sb.Append(",  ");
			}
			sb.Append("hash: ");
			sb.Append(thread.GetHashCode());
			sb.Append(",  pool: ");
			sb.Append(thread.IsThreadPoolThread);
			sb.Append(",  backgrnd: ");
			sb.Append(thread.IsBackground);
			sb.Append(",  state: ");
			sb.Append(thread.ThreadState);
			return sb.ToString();
		}

		public static void DisplayThreadInfo(string context)
		{
			string output = "\n" + context + "\n   " + ThreadDescription(Thread.CurrentThread);
			Console.WriteLine(output);
		}
	}


	public enum ResultStatus {Waiting, Done, Failed};



	public class DataRetriever 
	{	
		private readonly string name;
		private string address;
		private ResultStatus status = ResultStatus.Waiting;

		public void GetAddressSync()
		{
			string address = null;
			ResultStatus status = ResultStatus.Done;
			try
			{
				address = GetAddress();
				status = ResultStatus.Done;
			}
			catch(ThreadAbortException)
			{
				address = "Operation aborted";
				status = ResultStatus.Failed;
			}
			catch(ArgumentException e)
			{
				address = e.Message;
				status = ResultStatus.Failed;
			}
			finally
			{
				lock(this)
				{
					this.address = address;
					this.status = status;
				}
			}
		}
		public DataRetriever(string name)
		{
			this.name = name;
		}

		public void GetResults(out string name, out string address, out ResultStatus status)
		{
			name = this.name;
			lock (this)
			{
				address = this.address;
				status = this.status;
			}
		}

		public string GetAddress()
		{
			ThreadUtils.DisplayThreadInfo("In GetAddress...");
			// simulate waiting to get results off database servers
			Thread.Sleep(1000);
			if (name == "Simon")
				return "Simon lives in Lancaster";
			else if (name == "Julian")
			{
				Thread.Sleep(6000);
				return "Julian lives in Birmingham";
			}
			else
			{
				Thread.Sleep(1500);
				throw new ArgumentException("The name " + name + " is not in the database");
			}
		}
	
	}

	public class EntryPoint 
	{
		public static void Main()
		{
			ThreadStart workerEntryPoint;
			Thread [] workerThreads = new Thread[3];
			DataRetriever [] drs = new DataRetriever[3];
			string [] names = {"Simon", "Julian",
								  "Steve"};
		
			for (int i=0 ; i< 3 ; i++)
			{
				drs[i] = new DataRetriever(names[i]);
				workerEntryPoint = new ThreadStart(drs[i].GetAddressSync);
				workerThreads[i] = new Thread(workerEntryPoint);
				workerThreads[i].Start();
			}

			ManualResetEvent endProcessEvent = new ManualResetEvent(false);
			CheckResults resultsChecker = new CheckResults(endProcessEvent, drs,
				workerThreads);
			resultsChecker.InitializeTimer();

			endProcessEvent.WaitOne();
			EntryPoint.OutputResults(drs);
		}

		public static void OutputResults(DataRetriever [] drs)
		{
			foreach (DataRetriever dr in drs)
			{
				string name;
				string address;
				ResultStatus status;
				dr.GetResults(out name, out address, out status);
				Console.WriteLine("Name: {0}, Status : {1}, Result: {2}", name, status, address);
			}
		}
	}

	class CheckResults
	{
		private ManualResetEvent endProcessEvent;
		private DataRetriever[] drs;
		private Thread[] workerThreads;
		private int nTriesToGo = 10;
		private Timer timer;

		public CheckResults(ManualResetEvent endProcessEvent, DataRetriever[] drs,
			Thread[] workerThreads)
		{
			this.endProcessEvent = endProcessEvent;
			this.drs = drs;
			this.workerThreads = workerThreads;
		}

		public void InitializeTimer()
		{
			TimerCallback timerCallback = new TimerCallback(this.CheckResultStatus);
			timer = new Timer(timerCallback, null, 0, 500);
		}

		public void CheckResultStatus(object state)
		{
			Interlocked.Decrement(ref nTriesToGo);
			int nResultsToGo = 0;
			foreach(DataRetriever dr in drs)
			{
				string name;
				string address;
				ResultStatus status;
				dr.GetResults(out name, out address, out status);
				if (status == ResultStatus.Waiting)
					++nResultsToGo;
			}
			if (nResultsToGo == 0)
			{
				endProcessEvent.Set();
				return;
			}
			else
			{
				Console.WriteLine("{0} of {1} results returned",
					drs.Length -nResultsToGo, drs.Length);
			}
			if (nTriesToGo == 0)
			{
				timer.Change(Timeout.Infinite, Timeout.Infinite);
				TerminateWorkerThreads();
				endProcessEvent.Set();
			}

		}

		private void TerminateWorkerThreads()
		{
			foreach (Thread thread in workerThreads)
			{
				if (thread.IsAlive)
				{
					thread.Abort();
					thread.Join();
				}
			}
		}

	}
}