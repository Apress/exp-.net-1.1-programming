using System;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;

namespace EmitHelloWorld
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		public static void Main() 
		{
			AssemblyName assemblyName = new AssemblyName();
			assemblyName.Name = "HelloWorld";
			assemblyName.Version = new Version("1.0.1.0");

			AssemblyBuilder assembly = Thread.GetDomain().
				DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Save);

			ModuleBuilder module;
			module = assembly.DefineDynamicModule("MainModule", "HelloWorld.exe");

			MethodBuilder mainMethod = module.DefineGlobalMethod("Main",
				MethodAttributes.Static | MethodAttributes.Public, typeof(void), Type.EmptyTypes);

			Type[] writeLineParams = { typeof(string) };
			MethodInfo writeLineMethod = typeof(Console).GetMethod("WriteLine",
				writeLineParams);
			ILGenerator constructorIL = mainMethod.GetILGenerator();
			constructorIL.Emit(OpCodes.Ldstr, "Hello, World!");
			constructorIL.Emit(OpCodes.Call, writeLineMethod);
			constructorIL.Emit(OpCodes.Ret);

			module.CreateGlobalFunctions();

			assembly.SetEntryPoint(mainMethod, PEFileKinds.ConsoleApplication);

			// specifies file name of assembly (previous file name was for module) -
			// happened to be same file
			assembly.Save("HelloWorld.exe");
		}
	}
}
