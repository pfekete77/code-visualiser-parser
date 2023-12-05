// using Microsoft.CodeAnalysis.CSharp;
// using Microsoft.CodeAnalysis.CSharp.Syntax;

// var syntaxTree = CSharpSyntaxTree.ParseText(
// @"using System;
// using System.Collections;
// using System.Linq;
// using System.Text;

// namespace HelloWorldApplication
// {
// class LoginPage
// {
// public static main(string args[]) {
//     string tmp = ""None""
// }
// [PlainEnglishMethodName(""Enter username"")]
// public void EnterUsername(string username, string usernameType) {
//     int i = 0;
//     string tmp1 = 'a string';
//     string tmp2 = 'another string';
// }

// [PlainEnglishMethodName(""Enter password"")]
// public void EnterPassword(string password) {
//     int j = 0;
// }

// [PlainEnglishMethodName(""Click login button"")]
// public void ClickLoginButton() {
//     int k = 0;
// }
// }");

// var root = syntaxTree.GetRoot() as CompilationUnitSyntax;

// var namespaceSyntax = root.Members.OfType<NamespaceDeclarationSyntax>().First();

// var programClassSyntax = namespaceSyntax.Members.OfType<ClassDeclarationSyntax>().First();

// var mainMethodSyntax = programClassSyntax.Members.OfType<MethodDeclarationSyntax>().First();

// Console.WriteLine(mainMethodSyntax.ToString());

// var tmp = mainMethodSyntax.Modifiers;

// Console.WriteLine(tmp.ToString());

// Console.WriteLine();
// Console.WriteLine(programClassSyntax.ToString());

// foreach (var element in programClassSyntax.Members)
// {
//     Console.WriteLine();
//     Console.WriteLine("Modifiers:");
//     foreach (var modifier in element.Modifiers)
//     {
//         Console.WriteLine(modifier.ToString());
//     }
//     Console.WriteLine("Attributes:");
//     foreach (var attribute in element.AttributeLists)
//     {
//         Console.WriteLine(attribute.ToString());
//     }
//     if (element.GetType().Equals(typeof(MethodDeclarationSyntax)))
//     {
//         Console.WriteLine("Method name:");
//         Console.WriteLine(((MethodDeclarationSyntax)element).Identifier);
//         Console.WriteLine("Parameters:");
//         ParameterListSyntax parameterList = ((MethodDeclarationSyntax)element).ParameterList;
//         foreach (var parameter in parameterList.Parameters)
//         {
//             Console.WriteLine(parameter.ToString());
//         }
//         int ctr = 0;
//         Console.WriteLine("Body:");
//         //Console.WriteLine(((MethodDeclarationSyntax)element).Body.ToString());
//         BlockSyntax block = ((MethodDeclarationSyntax)element).Body;
        
//         foreach (var line in block.ChildNodes())
//         {
//             ctr++;
//             Console.WriteLine("" + ctr + ":" + line.ToString());
//         }
//     }
//     Console.WriteLine("Code:");
//     Console.WriteLine(element);
// }

