.assembly extern mscorlib {}

.assembly Arrays
{
	.ver 1:0:1:0
}

.module Arrays.exe

 
.namespace Apress.ExpertDotNet.Arrays
{	
	.class EntryPoint extends [mscorlib]System.Object
	{

		.method static void
		Main() cil managed
		{
			.maxstack 4
			.locals init (int32 counter, int32[] thearray) 
			.entrypoint

// set up aray
			ldc.i4.s	10
			dup
			stloc.0
			
			newarr	int32
			stloc.1

Loop:
// test if we have counted down to zero yet
			ldloc.0
			brfalse.s	Finish

// decrement counter
			ldloc.0	
			ldc.i4.1
			sub				
			stloc.0

			ldloc.1
			ldloc.0

// get stack ready to store element
			dup
			ldc.i4.4
			mul
			stelem.i4
			
			br.s	Loop

Finish:
// display element no. 3 of array
			ldstr "Element no. 3 is "
			call void [mscorlib]System.Console::Write(string)
			ldloc.1
			ldc.i4.3
			ldelem.i4
			call void [mscorlib]System.Console::WriteLine(int32)

// display length of array
			ldstr "Length of array is "
			call void [mscorlib]System.Console::Write(string)
			ldloc.1
			ldlen
			call void [mscorlib]System.Console::WriteLine(int32)


			ret			
		}

	}
}