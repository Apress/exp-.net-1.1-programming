.assembly CompareNumbers {}
.method static void Main() cil managed
{
   .maxstack 2 
   .entrypoint

   ldstr   "Input first number."
   call    void [mscorlib]System.Console::WriteLine(string)
   call    string [mscorlib]System.Console::ReadLine()
   call    int32 [mscorlib]System.Int32::Parse(string)
   ldstr   "Input second number."
   call    void [mscorlib]System.Console::WriteLine(string)
   call    string [mscorlib]System.Console::ReadLine()
   call    int32 [mscorlib]System.Int32::Parse(string)
   ble.s   FirstSmaller
   ldstr   "The first number was larger than the second one"
   call    void [mscorlib]System.Console::WriteLine(string)
 

   br.s    Finish

FirstSmaller:
   ldstr   "The first number was less than or equal to the second one"
   call    void [mscorlib]System.Console::WriteLine(string)

Finish:
   ldstr   "Thank you!"
   call    void [mscorlib]System.Console::WriteLine(string)
   ret
}
