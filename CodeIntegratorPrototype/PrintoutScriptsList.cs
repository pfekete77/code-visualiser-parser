using CodeIntegratorPrototype.Extraction;
using CodeIntegratorPrototype.LookupTables;
using CodeIntegratorPrototype.Models;
using CodeIntegratorPrototype.SyntaxUnits;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeIntegratorPrototype
{
    internal class PrintoutScriptsList
    {
        static ScriptsList scriptsList;
        static PageObjectModelTable pageObjectModelTable;
        static PomsList pomsList;
        public static string ProjectFolder;

        public static void Printout()
        {
            pomsList.PrintOut();
            scriptsList.PrintOut();
        }

        public static void ExtractPageObjectModel()
        {
            pomsList = new PomsList("test-project");

            string pomFolder = ProjectFolder + @"\UI";
            ProcessPomInFolder(pomFolder);
        }
        public static void ExtractTests()
        {
            scriptsList = new ScriptsList("test-project");

            string testsFolder = ProjectFolder + @"\Tests";
            ProcessTestsInFolder(testsFolder);
        }

        static void ProcessPomInFolder(string folder)
        {
            foreach (var item in Directory.EnumerateFileSystemEntries(folder))
            {
                Console.WriteLine("Found:" + item);
                if (File.Exists(item))
                {
                    ProcessPomInFile(item);
                }
                else if (Directory.Exists(item))
                {
                    ProcessPomInFolder(item);
                }
            }
        }

        static void ProcessPomInFile(string filename)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(File.ReadAllText(filename));
            var root = syntaxTree.GetRoot() as CompilationUnitSyntax;

            Console.WriteLine("Found namespaces->" + root.Members.OfType<NamespaceDeclarationSyntax>().Count());
            foreach (var namespaceSyntax in root.Members.OfType<NamespaceDeclarationSyntax>())
            {
                Console.WriteLine("Found namespace:" + namespaceSyntax.Name.ToString());
                foreach (var classSyntax in namespaceSyntax.Members.OfType<ClassDeclarationSyntax>())
                {
                    Console.WriteLine("Found class:" + classSyntax.Identifier.ToString());
                    PomDescription pomDescription = new PomDescription(classSyntax.Identifier.ToString());

                    foreach (var constructorSyntax in classSyntax.Members.OfType<ConstructorDeclarationSyntax>())
                    {
                        Console.WriteLine("Found constructor:" + constructorSyntax.Identifier.ToString());
                        PomConstructorDescription pomConstructorDescription = new PomConstructorDescription(constructorSyntax.Identifier.ToString(),
                            classSyntax.Identifier.ToString(),
                            namespaceSyntax.Name.ToString());
                            
                        pomDescription.pomConstructors.Add(pomConstructorDescription);
                    }
                    foreach (var methodSyntax in classSyntax.Members.OfType<MethodDeclarationSyntax>())
                    {
                        Console.WriteLine("Found method:" + methodSyntax.Identifier.ToString());
                        PomMethodDescription pomMethodDescription = new PomMethodDescription(methodSyntax.Identifier.ToString(),
                            classSyntax.Identifier.ToString(),
                            namespaceSyntax.Name.ToString());

                        pomDescription.pomMethods.Add(pomMethodDescription);
                    }

                    pomsList.PomDescriptionsList.Add(pomDescription);
                }
            }
        }

        static void ProcessTestsInFolder(string folder)
        {
            foreach (var item in Directory.EnumerateFileSystemEntries(folder))
            {
                Console.WriteLine("Found:" + item);
                if (File.Exists(item))
                {
                    ProcessTestsInFile(item);
                }
                else if (Directory.Exists(item))
                {
                    ProcessTestsInFolder(item);
                }
            }
        }

        static void ProcessTestsInFile(string file)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(File.ReadAllText(file));
            var root = syntaxTree.GetRoot() as CompilationUnitSyntax;

            Console.WriteLine("Found namespaces->" + root.Members.OfType<NamespaceDeclarationSyntax>().Count());
            foreach (var namespaceSyntax in root.Members.OfType<NamespaceDeclarationSyntax>())
            {
                foreach (var classSyntax in namespaceSyntax.Members.OfType<ClassDeclarationSyntax>())
                {
                    foreach (var methodSyntax in classSyntax.Members.OfType<MethodDeclarationSyntax>())
                    {
                        foreach (var attribute in methodSyntax.AttributeLists)
                        {
                            if (attribute.ToString().Equals("[TestMethod]"))
                            {
                                Console.WriteLine("Found a test method:" + methodSyntax.Identifier.ToString());

                                ScriptDescription scriptDescription = new ScriptDescription(methodSyntax.Identifier.ToString(),
                                                                                            namespaceSyntax.Name.ToString(),
                                                                                            classSyntax.Identifier.ToString(),
                                                                                            file);

                                foreach (var attributeAgain in methodSyntax.AttributeLists)
                                {
                                    Console.WriteLine("Found attribute:" + attributeAgain.ToString());
                                    scriptDescription.Attributes.Add(attributeAgain);
                                }
                                foreach (var modifier in methodSyntax.Modifiers)
                                {
                                    Console.WriteLine("Found modifier:" + modifier.ToString());
                                    scriptDescription.Modifiers.Add(modifier.ToString());
                                }
                                foreach (var parameter in methodSyntax.ParameterList.Parameters)
                                {
                                    Console.WriteLine("Found parameter:" + parameter.ToString());
                                    scriptDescription.Parameters.Add(parameter.ToString());
                                }

                                scriptDescription.ProcessBody(methodSyntax.Body, pomsList);

                                scriptsList.ScriptDescriptionsList.Add(scriptDescription);
                                break;
                            }
                        }
                    }
                }
            }
        }

        
    }
}
