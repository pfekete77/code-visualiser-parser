using CodeIntegratorPrototype.SyntaxUnits;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeIntegratorPrototype.Extraction
{
    internal class MethodsExtraction
    {
        private string codefileText = "";
        public MethodsExtraction(string codefile)
        {
            codefileText = File.ReadAllText(codefile);
        }
        public ArrayList GetMethodsList()
        {
            ArrayList result = new ArrayList();

            var syntaxTree = CSharpSyntaxTree.ParseText(codefileText);

            var root = syntaxTree.GetRoot() as CompilationUnitSyntax;

            foreach (var namespaceSyntax in root.Members.OfType<NamespaceDeclarationSyntax>()) 
            { 
                foreach (var classSyntax in namespaceSyntax.Members.OfType<ClassDeclarationSyntax>())
                {
                    foreach (var methodSyntax in classSyntax.Members.OfType<MethodDeclarationSyntax>()) 
                    {
                        MethodDescription methodDescription = new MethodDescription();
                        methodDescription.Name = methodSyntax.Identifier.ToString();
                        methodDescription.ClassName = methodSyntax.Identifier.ToString();
                        
                        foreach (var parameter in methodSyntax.ParameterList.Parameters)
                        {
                            Console.WriteLine("Found parameter:" + parameter.ToString());
                            methodDescription.Parameters.Add(parameter.ToString());
                        }

                        foreach (var attribute in methodSyntax.AttributeLists)
                        {
                            Console.WriteLine("Found attribute:" + attribute.ToString());
                            methodDescription.Attributes.Add(attribute.ToString());
                        }

                        foreach (var modifier in methodSyntax.Modifiers)
                        {
                            Console.WriteLine("Found modifier:" + modifier.ToString());
                            methodDescription.Modifiers.Add(modifier.ToString());
                        }

                        result.Add(methodDescription);
                    }
                }

            }

            return result;
        }
    }
}
