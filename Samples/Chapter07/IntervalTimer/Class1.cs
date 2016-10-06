using System;
using System.Runtime.InteropServices;

namespace IntervalTimer
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			int quantity = 0;
			IntervalTimer timer = new IntervalTimer();
			for (int numTests = 0 ; numTests < 3 ; numTests++)
			{
				timer.Start();
				timer.Stop();
				Console.WriteLine("Just starting and stopping timer: ");
				Console.WriteLine("     " + timer.ToString());

				timer.Start();
				for (int i=0 ; i<1000 ; i++)
					quantity += i;
				timer.Stop();
				Console.WriteLine("counting to 1000: ");
				Console.WriteLine("     " + timer.ToString());
			}
			Console.WriteLine("\nquantity is " + quantity);
		}
	}


	public class IntervalTimer
	{
		[DllImport("kernel32.dll")]
		static extern private int QueryPerformanceCounter(out long count);

		[DllImport("kernel32.dll")]
		static extern private int QueryPerformanceFrequency(out long count);


		public enum TimerState {NotStarted, Stopped, Started}

		private TimerState state;
		private long ticksAtStart;
		private long intervalTicks;
		private static long frequency;
		private static int decimalPlaces;
		private static string formatString;
		private static bool initialized = false;


		public IntervalTimer()
		{
			if (!initialized)
			{
				QueryPerformanceFrequency(out frequency);
				decimalPlaces = (int)Math.Log10(frequency);
				formatString = String.Format("Interval: {{0:F{0}}} seconds ({{1}} ticks)", decimalPlaces);
				initialized = true;
			}
			state = TimerState.NotStarted;
		}

		public void Start()
		{
			state = TimerState.Started;
			ticksAtStart = CurrentTicks;
		}

		public void Stop()
		{
			intervalTicks = CurrentTicks - ticksAtStart;
			state = TimerState.Stopped;
		}

		public float GetSeconds()
		{
			if (state != TimerState.Stopped)
				throw new TimerNotStoppedException();
			return (float)intervalTicks/(float)frequency;
		}

		public long GetTicks()
		{
			if (state != TimerState.Stopped)
				throw new TimerNotStoppedException();
			return intervalTicks;
		}

		private long CurrentTicks
		{
			get
			{
				long ticks;
				QueryPerformanceCounter(out ticks);
				return ticks;
			}
		}

		public override string ToString()
		{
			if (state != TimerState.Stopped)
				return "Interval timer, state: " + state.ToString();
			return String.Format(formatString, GetSeconds(), intervalTicks);
		}

	}
	
	public class TimerNotStoppedException : ApplicationException
	{
		public TimerNotStoppedException()
			: base("Timer is either still running or has not been started")
		{
		}
	}
}
