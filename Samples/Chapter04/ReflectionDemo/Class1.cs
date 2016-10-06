using System;
using System.Reflection;

namespace Apress.AdvDotnet.ReflectionDemo
{

	class Class1
	{
		static void Main(string[] args)
		{
			string windir = Environment.GetEnvironmentVariable("windir");
			Assembly ass = Assembly.LoadFrom(windir + @"\Microsoft.NET\Framework\v1.1.4322\System.Drawing.dll");
			foreach (Type type in ass.GetTypes())
			{
				Console.WriteLine(type.ToString());
			}
		}
	}
}
