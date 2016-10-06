using System;
using System.Threading;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Apress.ExpertDotNet.AsyncDelegates
{
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
			string output = "\n" + context + "\n   " +
				ThreadDescription(Thread.CurrentThread);
			Console.WriteLine(output);
		}
	}

	public class DataRetriever 
	{
		public string GetAddress(string name)
		{
			ThreadUtils.DisplayThreadInfo("In GetAddress...");

			// Simulate waiting to get results off database servers
			Thread.Sleep(1000);
			if (name == "Simon")
				return "Simon lives in Lancaster";
			else if (name == "Julian")
				return "Julian lives in Birmingham";
			else
				throw new ArgumentException("The name " + name +
					" is not in the database", "name");
		}

		public delegate string GetAddressDelegate(string name);

		public void GetAddressSync(string name)
		{
			try
			{
				GetAddressDelegate dc = new GetAddressDelegate(this.GetAddress);
				string result = dc(name);
				Console.WriteLine("\nSync: " + result);
			}
			catch (Exception ex)
			{
				Console.WriteLine("\nSync: a problem occurred: " + ex.Message);
			}
		}

		public void GetAddressAsyncWait(string name)
		{
			GetAddressDelegate dc = new GetAddressDelegate(this.GetAddress);

			IAsyncResult ar = dc.BeginInvoke(name, null, null); 

			// Main thread can in principle do other work now
			try
			{
				string result = dc.EndInvoke(ar);
				Console.WriteLine("\nAsync waiting : "+ result);
			}
			catch (Exception ex)
			{
				Console.WriteLine("\nAsync waiting, a problem occurred : " +
					ex.Message);
			}
		}

		public void GetResultsOnCallback(IAsyncResult ar)
		{
			GetAddressDelegate del = (GetAddressDelegate)
				((AsyncResult)ar).AsyncDelegate;

			try
			{
				string result;
				result = del.EndInvoke(ar);
				Console.WriteLine("\nOn CallBack: result is " + result);
			}
			catch (Exception ex)
			{
				Console.WriteLine("\nOn CallBack, problem occurred: " + ex.Message);
			}
		}

		public void GetAddressAsync(string name)
		{
			GetAddressDelegate dc = new GetAddressDelegate(this.GetAddress);
	
			AsyncCallback cb = new AsyncCallback(this.GetResultsOnCallback);
			IAsyncResult ar = dc.BeginInvoke(name, cb, null); 
		}

	}
	public class EntryPoint 
	{
		public static void Main()
		{
			Thread.CurrentThread.Name = "Main Thread";
			DataRetriever dr = new DataRetriever();
	
			dr.GetAddressSync("Simon");
			dr.GetAddressSync("Julian");
			dr.GetAddressSync("Steve");
			dr.GetAddressAsync("Simon");
			dr.GetAddressAsync("Julian");
			dr.GetAddressAsync("Steve");
			dr.GetAddressAsyncWait("Simon");
			dr.GetAddressAsyncWait("Julian");
			dr.GetAddressAsyncWait("Steve");
		}
	}
}
