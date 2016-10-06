.assembly extern mscorlib {}
.assembly Invalid {}
.module Invalid.exe
 
.method static void Main() cil managed
{
   .entrypoint
   .maxstack 2

   ldc.i4   47
   ldc.r8   32.4
   mul
   call     void [mscorlib]System.Console::WriteLine(int32)
   ldc.i4   52 
   ret
}
