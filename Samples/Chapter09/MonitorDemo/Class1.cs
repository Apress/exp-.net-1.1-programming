using System;
using System.Threading;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Diagnostics;
using System.Text;


namespace Apress.ExpertDotNetSamples.Threading.MonitorDemo
{
	//	public delegate float SomeDelegate(int input, ref int refparam, out int output);

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

		public void GetResultsOnCallback(IAsyncResult ar)
		{
			GetAddressDelegate del = (GetAddressDelegate)((AsyncResult)ar).AsyncDelegate;

			try
			{
				string result;
				result = del.EndInvoke(ar);
				lock(this)
				{
					this.address = result;
					this.status = ResultStatus.Done;
				}
			}
			catch (Exception ex)
			{
				lock(this)
				{
					this.address = ex.Message;
					this.status = ResultStatus.Failed;
				}
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
				return "Julian lives in Birmingham";
			else
				throw new ArgumentException("The name " + name + " is not in the database");
		}
	
	

		public void GetAddressAsync()
		{
			GetAddressDelegate dc = new GetAddressDelegate(this.GetAddress);
			AsyncCallback cb = new AsyncCallback(this.GetResultsOnCallback);
			IAsyncResult ar = dc.BeginInvoke(cb, null); 
		}

	}

	public class EntryPoint 
	{
		public static void Main()
		{
			Thread.CurrentThread.Name = "Main Thread";
			DataRetriever [] drs = new DataRetriever[3];
			string [] names = {"Simon", "Julian",
								  "Steve"};
		
			for (int i=0 ; i< 3 ; i++)
			{
				drs[i] = new DataRetriever(names[i]);
				drs[i].GetAddressAsync();
			}

			Thread.Sleep(2500);
			OutputResults(drs);
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
}