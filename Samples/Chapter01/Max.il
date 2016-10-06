// Sums the numbers between a given range
.assembly extern mscorlib {}
.assembly Max
{
	.ver 1:0:1:0
}

.module Max

.namespace Apress.ExpertDotNet.Max
{
	.class public auto ansi EntryPoint extends [mscorlib]System.Object
	{
		.method static void
		Main() cil managed
		{
			.maxstack 2
			.locals init (int32, int32) 
			.entrypoint
			ldstr "Input First number."
			call 	void [mscorlib]System.Console::WriteLine(string)
			call string [mscorlib]System.Console::ReadLine()
			call int32 [mscorlib]System.Int32::Parse(string)
			stloc.0

			ldstr "Input Second number."
			call 	void [mscorlib]System.Console::WriteLine(string)
			call string [mscorlib]System.Console::ReadLine()
			call int32 [mscorlib]System.Int32::Parse(string)
			stloc.1

			ldloca.s	0
			ldloca.s	1
			call int8 Apress.ExpertDotNet.Max.MathUtils::Max(int32 &, int32 &)

			ldstr "Index of larger number was "
			call void [mscorlib]System.Console::Write(string)
			call void [mscorlib]System.Console::WriteLine(int32)

			ldstr "After maximizing numbers, the numbers are "
			call void [mscorlib]System.Console::WriteLine(string)
			ldloc.0
			call void [mscorlib]System.Console::WriteLine(int32)
			ldloc.1
			call void [mscorlib]System.Console::WriteLine(int32)
			ldstr "Thank you!"
			call 	void [mscorlib]System.Console::WriteLine(string)
			ret
		}
	}

	.class MathUtils extends [mscorlib]System.Object
	{
		// Max works out which of two numbers is greater.
		// returns the index of the greater number
		// or -1 if numbers are equal
		// and sets lower number to equal higher one
		.method assembly static int8
		Max(int32 &, int32 &)	cil managed
		{
			.maxstack 2
			.locals init (int32, int32)

			// copy argument values to locals
			ldarg.0
			ldind.i4
			stloc.0
			ldarg.1
			ldind.i4
			stloc.1

			// now start comparing their values
			ldloc.0
			ldloc.1
			blt.s FirstIsLess

			ldloc.0
			ldloc.1
			bgt.s FirstIsBigger

			// both numbers are equal
			ldc.i4.m1
			ret
			
FirstIsLess:
			ldarg.0
			ldloc.1
			stind.i4
			ldc.i4.1
			ret

FirstIsBigger:
			ldarg.1
			ldloc.0
			stind.i4
			ldc.i4.0
			ret
		}
	}
}