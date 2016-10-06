// Sums the numbers between a given range
.assembly extern mscorlib {}
.assembly SumBetween
{
	.ver 1:0:1:0
}

.module SumBetween

.namespace Apress.ExpertDotNet.SumBetween
{
	.class public auto ansi EntryPoint extends [mscorlib]System.Object
	{
		.method static void
		Main() cil managed
		{
			.maxstack 2 
			.entrypoint
			ldstr "Input lower number."
			call 	void [mscorlib]System.Console::WriteLine(string)
			call string [mscorlib]System.Console::ReadLine()
			call int32 [mscorlib]System.Int32::Parse(string)
			ldstr "Input higher number."
			call 	void [mscorlib]System.Console::WriteLine(string)
			call string [mscorlib]System.Console::ReadLine()
			call int32 [mscorlib]System.Int32::Parse(string)
			call int32 Apress.ExpertDotNet.SumBetween.MathUtils::SumBetween(int32, int32)

			ldstr "The sum is "
			call 	void [mscorlib]System.Console::Write(string)
			call 	void [mscorlib]System.Console::WriteLine(int32)

			ldstr "Thank you!"
			call 	void [mscorlib]System.Console::WriteLine(string)
			ret
		}


	}


	.class MathUtils extends [mscorlib]System.Object
	{
		.method assembly static int32
		SumBetween(int32 lower, int32 higher)	cil managed
		{
			.maxstack 2
			.locals init (int32, int32)
			// local.0 is index, local.1 is running total

			// initialize count
			ldarg.0
			stloc.0

Loop:
			ldloc.0
			ldarg.1
			bgt Finished
				// increment running total
				ldloc.0
				ldloc.1
				add
				stloc.1

				// increment count
				ldloc.0
				ldc.i4.1
				add
				stloc.0
				br.s	Loop

Finished:
			ldloc.1
			ret
		}
	}
}