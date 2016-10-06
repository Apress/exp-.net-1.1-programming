using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using Microsoft.CSharp;
using Microsoft.VisualBasic;
using Microsoft.JScript;
//using Microsoft.V

namespace Apress.ExpertDotNet.CodeDomMultiLanguage
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		static CodeCompileUnit GenerateProgram(string message, int nDisplays)
		{
			// Create Main method
			CodeEntryPointMethod mainMethod = new CodeEntryPointMethod();
			mainMethod.Name = "Main";

			// generate this expression: Console
			CodeTypeReferenceExpression consoleType = new
				CodeTypeReferenceExpression();
			consoleType.Type = new CodeTypeReference(typeof(Console));

			// generate this statement: int i=0;
			CodeVariableDeclarationStatement declareI = new CodeVariableDeclarationStatement();
			declareI.Name = "i";
			declareI.InitExpression = new CodePrimitiveExpression(0);
			declareI.Type = new CodeTypeReference(typeof(int));

			// generate this expression: i;
			CodeVariableReferenceExpression iVar = new CodeVariableReferenceExpression(declareI.Name);

			// generate this statement: i=i+1;
			CodeAssignStatement incrI = new CodeAssignStatement();
			incrI.Left = iVar;
			incrI.Right = new CodeBinaryOperatorExpression(iVar, CodeBinaryOperatorType.Add, new CodePrimitiveExpression(1));

			// generate this for loop: for (int i=0 ; i<nDisplays ; i++)
			CodeIterationStatement forLoop = new CodeIterationStatement();
			forLoop.InitStatement = declareI;
			forLoop.TestExpression = new CodeBinaryOperatorExpression(iVar, CodeBinaryOperatorType.LessThan, new CodePrimitiveExpression(nDisplays));
			forLoop.IncrementStatement = incrI;

			// Set up the argument list to pass to Console.WriteLine()
			CodeExpression[] writeLineArgs = new CodeExpression[1];
			CodePrimitiveExpression arg0 = new CodePrimitiveExpression(message);
			writeLineArgs[0] = arg0;

			// generate this statement: Console.WriteLine(message)
			CodeMethodReferenceExpression writeLineRef = new
				CodeMethodReferenceExpression(consoleType, "WriteLine");
			CodeMethodInvokeExpression writeLine = new 
				CodeMethodInvokeExpression(writeLineRef, writeLineArgs);

			// insert Console.WriteLine() statement into for loop
			forLoop.Statements.Add(writeLine);

			// add the for loop to the Main() method
			mainMethod.Statements.Add(forLoop);

			// Add a return statement to the Main() method
			CodeMethodReturnStatement ret = new CodeMethodReturnStatement();
			mainMethod.Statements.Add(ret);

			// Add Main() method to a class
			CodeTypeDeclaration theClass = new CodeTypeDeclaration();
			theClass.Members.Add(mainMethod);
			theClass.Name = "EntryPoint";

			// Add namespace and add class
			CodeNamespace ns = new CodeNamespace("Apress.ExpertDotNet.CodeDomSample");
			ns.Imports.Add(new CodeNamespaceImport("System"));
			ns.Types.Add(theClass);

			// Create whole program (code compile unit)
			CodeCompileUnit unit = new CodeCompileUnit();
			unit.Namespaces.Add(ns);

			return unit;
		}
		
		static void Main()
		{
			Console.WriteLine("What string do you want the custom program to display?");
			string message = Console.ReadLine();
			Console.WriteLine("How many times do you want the program to display this message?");
			int nDisplays = int.Parse(Console.ReadLine());
			CodeCompileUnit unit = GenerateProgram(message, nDisplays);

			// Set up options for source code style
			CodeGeneratorOptions opts = new CodeGeneratorOptions();
			opts.BracingStyle = "C";
			opts.IndentString = "\t";

			// Create code generators and write code files
			CodeDomProvider[] providers = new CodeDomProvider[3];
			providers[0] = new CSharpCodeProvider();
			providers[1] = new VBCodeProvider();
			providers[2] = new JScriptCodeProvider();
//			providers[3] = new VJSharpCodeProvider();
			string[] fileNames = { "MyCodeCS.cs", "MyCodeVB.vb", "MyCodeJS.js" };

			for(int i=0 ; i< providers.Length; i++)
			{
				ICodeGenerator gen = providers[i].CreateGenerator();
				StreamWriter sw = new StreamWriter(fileNames[i]);
				gen.GenerateCodeFromCompileUnit(unit, sw, opts);
				sw.Close();
			}

			string[] assemblyFileNames = { "MyCodeCS.exe", "MyCodeVB.exe",
											 "MyCodeJS.exe" };
			CompilerParameters compilerParams = new CompilerParameters();
			compilerParams.GenerateExecutable = true;
			for (int i=0; i<providers.Length; i++)
			{
				ICodeCompiler compiler = providers[i].CreateCompiler();
				compilerParams.OutputAssembly = assemblyFileNames[i];
				compiler.CompileAssemblyFromFile(compilerParams, fileNames[i]);
			}
		}

	}
}
