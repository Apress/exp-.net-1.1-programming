using System;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;

namespace Apress.ExpertDotNet.EmitClass
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		public static void Main() 
		{
			AssemblyName assemblyName = new AssemblyName();
			assemblyName.Name = "Utilities";
			assemblyName.Version = new Version("1.0.1.0");

			AssemblyBuilder assembly = Thread.GetDomain().
				DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);

			ModuleBuilder module;
			module = assembly.DefineDynamicModule("MainModule", "Utilities.dll");

			TypeBuilder utilsTypeBldr = module.DefineType("Apress.ExpertDotNet.EmitClass.Utilities", 
				TypeAttributes.Class | TypeAttributes.Public, typeof(System.Object));

			FieldBuilder nameFld = utilsTypeBldr.DefineField("a", typeof(string),
				FieldAttributes.PrivateScope);

			MethodBuilder toStringMethod = utilsTypeBldr.DefineMethod("ToString",
				MethodAttributes.Public | MethodAttributes.Virtual, typeof(string),
				null);

			ILGenerator toStringIL = toStringMethod.GetILGenerator();
			toStringIL.Emit(OpCodes.Ldarg_0);
			toStringIL.Emit(OpCodes.Ldfld, nameFld);
			toStringIL.Emit(OpCodes.Ret);

			Type[] constructorParamList = { typeof(string) };
			ConstructorInfo objectConstructor = (typeof(System.Object)).
				GetConstructor(new Type[0]);
			ConstructorBuilder constructor = utilsTypeBldr.DefineConstructor(
				MethodAttributes.Public, CallingConventions.Standard,
				constructorParamList);
			constructor.DefineParameter(1, ParameterAttributes.None, "name");
			ILGenerator constructorIL = constructor.GetILGenerator();
			constructorIL.Emit(OpCodes.Ldarg_0);
			constructorIL.Emit(OpCodes.Call, objectConstructor);
			constructorIL.Emit(OpCodes.Ldarg_0);
			constructorIL.Emit(OpCodes.Ldarg_1);
			constructorIL.Emit(OpCodes.Stfld, nameFld);
			constructorIL.Emit(OpCodes.Ret);

			Type utilsType = utilsTypeBldr.CreateType();
			object utils = Activator.CreateInstance(utilsType, new object[] {
																				 "New Object!"} );
			object name = utilsType.InvokeMember("ToString",
				BindingFlags.InvokeMethod, null, utils, null);
			Console.WriteLine("ToString() returned: " + (string)name);

			assembly.Save("Utilities.dll");
		}

	}
}
