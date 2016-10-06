using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.IO;

namespace Apress.ExpertDotNet.CodeDomHelloWorld
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		// generate CodeDOM for code that displays message nDisplays times.
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


		[STAThread]
		static void Main(string[] args)
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

			// Create code generator and write code file
			CSharpCodeProvider cscp = new CSharpCodeProvider();
			ICodeGenerator gen = cscp.CreateGenerator();
			StreamWriter sw = new StreamWriter("MyCode.cs");
			gen.GenerateCodeFromCompileUnit(unit, sw, opts);
			sw.Close();

			CompilerParameters compilerParams = new CompilerParameters();
			compilerParams.GenerateExecutable = true;
			compilerParams.OutputAssembly = "MyCode.exe";
			ICodeCompiler compiler = cscp.CreateCompiler();
			compiler.CompileAssemblyFromFile(compilerParams, "MyCode.cs");
		}

	}
}
