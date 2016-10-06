.assembly extern mscorlib {}

.assembly EnumDemo
{
	.ver 1:0:1:0
}

.module EnumDemo.exe


.namespace Apress.ExpertDotNet.EnumDemo
{
	.class public auto ansi sealed AmOrPm extends [mscorlib]System.Enum
	{
		.field public specialname rtspecialname int32 value__
		.field public static literal valuetype Apress.ExpertDotNet.EnumDemo.AmOrPm Am = int32(0x0)
		.field public static literal valuetype Apress.ExpertDotNet.EnumDemo.AmOrPm Pm = int32(0x1)
	}

	.class public auto ansi EntryPoint extends [mscorlib]System.Object
	{

		.method static void
		Main() cil managed
		{
			.maxstack 2 
			.entrypoint
			.locals init (valuetype Apress.ExpertDotNet.EnumDemo.AmOrPm time)

			// initialize the local variable to 1 (=Pm)
			ldc.i4.1
			stloc.0

			// write out time as a number
			ldstr "Value of enum (as number) is "
			call void [mscorlib]System.Console::WriteLine(string)
			ldloc.0
			call void [mscorlib]System.Console::WriteLine(int32)

			// write out time as a string
			ldstr "Value of enum (as string) is "
			call void [mscorlib]System.Console::WriteLine(string)
			ldloc.0
			box Apress.ExpertDotNet.EnumDemo.AmOrPm
			call instance string [mscorlib]System.Enum::ToString()
			call void [mscorlib]System.Console::WriteLine(string)

			ret
		}
	}
}