// AddConsts sample
.assembly extern mscorlib {}

.assembly AddConsts 
{
   .ver 1:0:1:0
}

.module AddConsts.exe

.method static void
Main() cil managed
{
   .entrypoint
   .maxstack 2
 

   ldstr     "The sum of the numbers is "
   call      void [mscorlib]System.Console::Write(string)
   ldc.i4.s  47
   ldc.i4    345
   add
   call      void [mscorlib]System.Console::WriteLine(int32)
   ret
}
