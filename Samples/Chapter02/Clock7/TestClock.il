.assembly extern mscorlib {}
.assembly extern Clock
{
	.ver 7:0:1:0
}

.assembly TestClock 
{
	.ver 7:0:1:0
}

.module TestClock2
 
.namespace Apress.ExpertDotNet.ClockSample
{	
	.class EntryPoint extends [mscorlib]System.Object
	{

		.method static void
		Main() cil managed
		{
			.maxstack 2
			.locals init (class [Clock]Apress.ExpertDotNet.ClockSample.Clock) 
			.entrypoint

			// initialize
			newobj void [Clock]Apress.ExpertDotNet.ClockSample.Clock::.ctor()
			stloc.0

			ldstr "The time is "
			call void [mscorlib]System.Console::Write(string)
			ldloc.0
			callvirt instance string [Clock]Apress.ExpertDotNet.ClockSample.Clock::ToString()
			call void [mscorlib]System.Console::WriteLine(string)

			ret
		}

	}
}