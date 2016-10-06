.assembly extern mscorlib {}
.assembly extern Clock { .ver 3:0:1:0 }
 
.assembly TestClock 
{
	.ver 3:0:1:0
}

.module TestClock.exe

.namespace Apress.ExpertDotNet.ClockSample
{	
	.class EntryPoint extends [mscorlib]System.Object
	{

		.method static void
		Main() cil managed
		{
			.maxstack 2
			.locals init (valuetype [Clock]Apress.ExpertDotNet.ClockSample.Clock clock) 
			.entrypoint

			// initialize
			ldloca.s	clock
			call instance void [Clock]Apress.ExpertDotNet.ClockSample.Clock::.ctor()

			ldstr "Hours are "
			call void [mscorlib]System.Console::Write(string)
			ldloca.s	clock
			call instance unsigned int8 [Clock]Apress.ExpertDotNet.ClockSample.Clock::get_Hours()
			call void [mscorlib]System.Console::WriteLine(int32)

			ret
		}

	}
}