using System;
using System.Reflection;
using System.Diagnostics;


//[assembly: Debuggable(true, true)]

namespace SJR.TestApps.Profiling
{
	class EntryPoint
	{
		static void Main(string[] args)
		{
			// find out whether the CLR thinks optimizations are supposed to be on or off
			Assembly asm = Assembly.GetExecutingAssembly();
			object[] attrs = asm.GetCustomAttributes( typeof(DebuggableAttribute), false );
			if ( attrs != null && attrs.Length >= 1 ) 
			{
				for (int i=0 ; i < attrs.Length ; i++)
				{
					DebuggableAttribute da = attrs[i] as DebuggableAttribute;
					Console.WriteLine( "IsJITOptimizerDisabled: {0}", 
						da.IsJITOptimizerDisabled );
					Console.WriteLine( "IsJITTrackingEnabled: {0}", da.IsJITTrackingEnabled );
				}
			}
			else
				Console.WriteLine( "DebuggableAttribute not present." );

			int nIters = 100000000;

			ProfileProperty(nIters);
			ProfileField(nIters);
			ProfileProperty(nIters);
			ProfileField(nIters);
		}

		static void ProfileField(int nIters)
		{
			TestClass test = new TestClass();
			DateTime startTime, endTime;
			startTime = DateTime.Now;
			for (int i=0 ; i < nIters ; i++)
			{
				test.x += i;
				test.x/=2;
			}
			endTime = DateTime.Now;
			Console.WriteLine("Using field: " + (endTime - startTime).ToString());
			Console.WriteLine(test.x);
		}


		static void ProfileProperty(int nIters)
		{
			TestClass test = new TestClass();
			DateTime startTime, endTime;
			startTime = DateTime.Now;
			for (int i=0 ; i < nIters ; i++)
			{
				test.X += i;
				test.X/=2;
			}
			endTime = DateTime.Now;
			Console.WriteLine("Using property: " + (endTime - startTime).ToString());
			Console.WriteLine(test.X);
		}
	}

	class TestClass
	{
		public int x;

		public int X
		{
			get
			{
				return x;
			}
			set
			{
				x = value;
			}
		}
	}
}
