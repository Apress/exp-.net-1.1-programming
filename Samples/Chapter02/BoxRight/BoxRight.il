.assembly BoxWrong
{
	.ver 1:0:1:0
}

.module BoxWrong
.assembly extern mscorlib {}
 
.namespace Apress.ExpertDotNet.BoxWrong
{	
	.class EntryPoint extends [mscorlib]System.Object
	{

		.method static void
		Main() cil managed
		{
			.maxstack 1
			.locals init (int32) 
			.entrypoint
	
			ldstr "The number is "
			call void [mscorlib]System.Console::Write(string)
			ldc.i4.s	-45
			box	int32	// assuming we need to box for some other reason
			unbox	int32
			call instance string int32::ToString()
			call void [mscorlib]System.Console::WriteLine(string)
			ret			
		}

	}
}