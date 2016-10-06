.assembly extern mscorlib {}

.assembly CompareNumbers2
{
   .ver 1:0:1:0
}

.module CompareNumbers2.exe

.namespace Apress.ExpertDotNet.CompareNumbers2
{
   .class MathUtils extends [mscorlib]System.Object
   {
      .method public static bool
      FirstIsGreater(int32 x, int32 y) cil managed
      {
         .maxstack 2
         ldarg.0
 

         ldarg.1
         ble.s     FirstSmaller
            ldc.i4.1
            ret
FirstSmaller:
            ldc.i4.0
            ret
      }

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
         call    bool Apress.ExpertDotNet.CompareNumbers2.
                          MathUtils::FirstIsGreater(int32, int32)
         brfalse.s  FirstSmaller
            ldstr   "The first number was larger than the second one"
            call    void [mscorlib]System.Console::WriteLine(string)
            br.s    Finish

FirstSmaller:
            ldstr   "The first number was less than or equal to the " +
                    "second one"
            call    void [mscorlib]System.Console::WriteLine(string)

Finish:
         ldstr   "Thank you!"
         call    void [mscorlib]System.Console::WriteLine(string)
         ret
      }

   }
} 
