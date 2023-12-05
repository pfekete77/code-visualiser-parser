using CodeIntegratorPrototype.SyntaxUnits;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CodeIntegratorPrototype.Extraction
{
    internal class TestsExtraction
    {
        private string codefileText = "";

        public TestsExtraction(string codefile) {
            codefileText = File.ReadAllText(codefile);
        }

        public ArrayList GetTestClassList()
        {
            ArrayList result = new ArrayList();

            var syntaxTree = CSharpSyntaxTree.ParseText(codefileText);

            var root = syntaxTree.GetRoot() as CompilationUnitSyntax;

            foreach (var namespaceSyntax in root.Members.OfType<NamespaceDeclarationSyntax>())
            {
                foreach (var classSyntax in namespaceSyntax.Members.OfType<ClassDeclarationSyntax>())
                {
                    TestClassDescription testClassDescription = new TestClassDescription();
                    testClassDescription.ClassName = classSyntax.Identifier.ToString();

                    foreach (var methodSyntax in classSyntax.Members.OfType<MethodDeclarationSyntax>())
                    {
                        foreach (var attribute in methodSyntax.AttributeLists)
                        {
                            if (attribute.ToString().Equals("[TestMethod]"))
                            {
                                Console.WriteLine("Found a test method:" + methodSyntax.Identifier.ToString());

                                TestDescription testDescription = new TestDescription();
                                testDescription.Name = methodSyntax.Identifier.ToString();

                                foreach (var attributeAgain in methodSyntax.AttributeLists)
                                {
                                    Console.WriteLine("Found attribute:" + attributeAgain.ToString());
                                    testDescription.Attributes.Add(attributeAgain);
                                }
                                foreach (var modifier in methodSyntax.Modifiers)
                                {
                                    Console.WriteLine("Found modifier:" + modifier.ToString());
                                    testDescription.Modifiers.Add(modifier.ToString());
                                }
                                foreach (var parameter in methodSyntax.ParameterList.Parameters)
                                {
                                    Console.WriteLine("Found parameter:" + parameter.ToString());
                                    testDescription.Parameters.Add(parameter.ToString());
                                }


                                foreach (var line in methodSyntax.Body.ChildNodes())
                                {
                                    Console.WriteLine("Found line:" + line.ToString());
                                    testDescription.CodeList.Add(line.ToString());
                                    testDescription.CodeListNodes.Add(line);
                                }


                                testClassDescription.TestsList.Add(testDescription);

                                break;
                            }

                        }
                        
                    }
                    result.Add(testClassDescription);
                }

            }
            return result;
        }
    }
}
