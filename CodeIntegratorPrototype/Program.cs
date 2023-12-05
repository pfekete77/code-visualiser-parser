using CodeIntegratorPrototype;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

//BasicPrintoutDirectFromCodeAnalyzer.Printout();

//BasicPrintoutFromMethodDescriptions.Printout();

Console.WriteLine();
Console.WriteLine();

//BasicPrintoutFromTestClassDescription.Printout();

PrintoutScriptsList.ProjectFolder = @"C:\Users\4221\source\repos\CodeIntegratorPrototype\CodeIntegratorPrototype";
PrintoutScriptsList.ExtractPageObjectModel();
PrintoutScriptsList.ExtractTests();
PrintoutScriptsList.Printout();


