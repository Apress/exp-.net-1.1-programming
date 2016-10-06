.assembly extern mscorlib {}
.assembly Blobs
{
	.ver 1:0:1:0
}

.module Blobs.exe



.namespace Apress.ExpertDotNet.DataDemo
{
	.class public explicit sealed AnsiString extends [mscorlib]System.ValueType
	{
		.size 14
	}
	.data HelloWorldData = bytearray(48 65 6c 6c 6f 2c 20 57 6f 72 6c 64 0)
	.data HelloData = bytearray(48 65 6c 6c 6f 0 0 0 0 0 0 0 0)

	.field public static valuetype Apress.ExpertDotNet.DataDemo.AnsiString HelloWorld at HelloWorldData
	.field public static valuetype Apress.ExpertDotNet.DataDemo.AnsiString Hello at HelloData

	.method public static pinvokeimpl("user32.dll" winapi)
		int32 MessageBox(native int hWnd, int8* text, int8* caption, unsigned int32 type) {}

	.class public auto ansi EntryPoint extends [mscorlib]System.Object
	{

		.method static void
		Main() cil managed
		{
			.maxstack 4 
			.entrypoint

			ldc.i4.0
			ldsflda valuetype Apress.ExpertDotNet.DataDemo.AnsiString HelloWorld
			ldsflda valuetype Apress.ExpertDotNet.DataDemo.AnsiString Hello
			ldc.i4.1
			call int32 MessageBox(native int, int8*, int8*, unsigned int32)
			pop
			ret
		}
	}

}