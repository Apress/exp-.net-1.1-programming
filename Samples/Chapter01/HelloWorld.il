// HelloWorld.il
// This is our first IL Program!
.assembly extern mscorlib {}

.assembly HelloWorld 
{
   .ver 1:0:1:0
}

.module HelloWorld.exe

.method static void Main() cil managed
{
   .maxstack 1 
   .entrypoint

   ldstr   "Hello, World"
   call    void [mscorlib]System.Console::WriteLine(string)
   ret
}
