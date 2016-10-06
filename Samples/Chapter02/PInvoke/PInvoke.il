.assembly extern mscorlib {}
.assembly PInvoke
{
	.ver 1:0:1:0
}
.module PInvoke.exe

.method public static pinvokeimpl("user32.dll" winapi)
		int32 MessageBox(native int hWnd, string text, string caption, unsigned int32 type) {}


.namespace Apress.ExpertDotNet.PInvokeDemo
{

	.class public auto ansi EntryPoint extends [mscorlib]System.Object
	{

		.method static void
		Main() cil managed
		{
			.maxstack 4 
			.entrypoint

			ldc.i4.0
			ldstr "Hello, World"
			ldstr "Hello"
			ldc.i4.1
			call int32 MessageBox(native int, string, string, unsigned int32)
			pop
			ret
		}
	}
}