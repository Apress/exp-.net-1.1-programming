// This is a HelloWorld app with a class!
.assembly extern mscorlib {}
.assembly HelloWorldClass 
{
   .ver 1:0:1:0
}

.module HelloWorldClass.exe

.namespace Apress.ExpertDotNet.ILChapter.HelloWorldClass
{
   .class public auto ansi EntryPoint extends [mscorlib]System.Object
   {
      .method public static void DisplayHelloWorld() cil managed
      {
         .maxstack 1 
         .entrypoint
         ldstr   "Hello, World"
         call    void [mscorlib]System.Console::WriteLine(string)
         ret
      }
   }
}
