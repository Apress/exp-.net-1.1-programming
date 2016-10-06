.assembly extern mscorlib {}
.assembly extern Clock {.ver 1:0:1:0 }

.assembly TestClock 
{
	.ver 1:0:1:0
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


			// set Hours to 6
			ldloca.s	clock
			ldc.i4.6
			stfld unsigned int8 [Clock]Apress.ExpertDotNet.ClockSample.Clock::Hours

			ldstr "Hours are "
			call void [mscorlib]System.Console::Write(string)
			ldloca.s	clock
			ldfld unsigned int8 [Clock]Apress.ExpertDotNet.ClockSample.Clock::Hours
			call void [mscorlib]System.Console::WriteLine(int32)

			ret
		}

	}
}