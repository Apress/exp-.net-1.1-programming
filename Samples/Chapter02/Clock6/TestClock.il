.assembly extern mscorlib {}
.assembly extern Clock
{
	.ver 5:0:1:0
}

.assembly TestClock 
{
	.ver 6:0:1:0
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
			.locals init (class [Clock]Apress.ExpertDotNet.ClockSample.Clock) 
			.entrypoint

			// initialize
			ldc.i4.s 6      // To initialize hours to 6
			newobj   void [Clock]Apress.ExpertDotNet.ClockSample.Clock::.ctor(unsigned int8)
			stloc.0


			ldstr "Hours are "
			call void [mscorlib]System.Console::Write(string)
			ldloc.0
			call instance unsigned int8 [Clock]Apress.ExpertDotNet.ClockSample.Clock::get_Hours()
			call void [mscorlib]System.Console::WriteLine(int32)

			ret
		}

	}
}