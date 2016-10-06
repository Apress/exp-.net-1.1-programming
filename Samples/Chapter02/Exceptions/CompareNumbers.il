// Compare the values of two numbers typed in by user
.assembly extern mscorlib {}
.assembly CompareNumbers
{
	.ver 1:0:1:0
}

.module CompareNumbers.exe

.namespace Apress.ExpertDotNet.CompareNumbers
{
	.class public auto ansi EntryPoint extends [mscorlib]System.Object
	{
		.method static void
		Main() cil managed
		{
			.maxstack 2 
			.entrypoint
			.try
			{
				.try
				{
					ldstr "Input first number."
					call 	void [mscorlib]System.Console::WriteLine(string)
					call string [mscorlib]System.Console::ReadLine()
					call int32 [mscorlib]System.Int32::Parse(string)
					ldstr "Input second number."
					call 	void [mscorlib]System.Console::WriteLine(string)
					call string [mscorlib]System.Console::ReadLine()
					call int32 [mscorlib]System.Int32::Parse(string)
					ble.s	FirstSmaller
						ldstr "The first number was larger than the second one"
					call 	void [mscorlib]System.Console::WriteLine(string)
					leave.s Finish
FirstSmaller:
					ldstr "The first number was less than or equal to the second one"
					call 	void [mscorlib]System.Console::WriteLine(string)
					leave.s Finish
				}
				catch [mscorlib]System.Exception
				{
					pop
					ldstr "That wasn't a number"
					call void [mscorlib]System.Console::WriteLine(string)
					leave.s Finish
				}
			}
			finally
			{
				ldstr "Thank you!"
				call 	void [mscorlib]System.Console::WriteLine(string)
				endfinally
			}
			Finish:
			ret
		}
	}
}