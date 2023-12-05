using CodeIntegratorPrototype.Exceptions;
using CodeIntegratorPrototype.SyntaxUnits;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeIntegratorPrototype.Models
{
    internal class ScriptDescription
    {
        public string Name { get; set; }
        public string Namespace { get; set; }
        public string ClassName { get; set; }
        public string SourceFile { get; set; }


        public ArrayList Modifiers { get; set; }
        public ArrayList Attributes { get; set; }
        public ArrayList Parameters { get; set; }


        public ArrayList ScriptComponents { get; set; }
        public ScriptDescription(string name)
        {
            this.Name = name; 
            this.Modifiers = new ArrayList();
            this.Parameters = new ArrayList();
            this.Attributes = new ArrayList();
            this.ScriptComponents = new ArrayList();
        }

        public ScriptDescription(string name, string @namespace, string className, string sourceFile) : this(name)
        {
            Namespace = @namespace;
            ClassName = className;
            SourceFile = sourceFile;
        }

        public void AddScriptComponent(ScriptComponent component)
        {

        }

        internal void PrintOut(int indent)
        {
            string indentString = "";
            for (int i = 0; i < indent; i++)
            {
                indentString += "\t";
            }

            Console.WriteLine(indentString + "Script name:" + this.Name);
            foreach (ScriptComponent scriptComponent in this.ScriptComponents)
            {
                scriptComponent.PrintOut(indent + 1);
            }
        }

        internal void ProcessBody(BlockSyntax body, PomsList pomsList)
        {
            Dictionary<string, string> instancesDeclaredList = new Dictionary<string, string>();
            string currentPomInstance = "";
            ScriptComponent scriptComponent = new ScriptComponent();

            foreach (SyntaxNode line in body.ChildNodes())
            {
                Console.WriteLine("Found line:" + line);

                SyntaxToken syntaxToken = line.GetFirstToken();
                Console.WriteLine("Found token --->>> " + syntaxToken.ToString());

                if (pomsList.LookupPomDescription(syntaxToken.ToString()))
                {
                    Console.WriteLine("Found instantiation");
                    scriptComponent = new ScriptComponent();
                    this.ScriptComponents.Add(scriptComponent);
                    scriptComponent.ClassName = syntaxToken.ToString();

                    currentPomInstance = syntaxToken.GetNextToken().ToString();
                    if (!instancesDeclaredList.ContainsKey(currentPomInstance))
                    {
                        instancesDeclaredList.Add(currentPomInstance, syntaxToken.ToString());
                    }
                }
                else
                {
                    if (syntaxToken.ToString().Equals(currentPomInstance))
                    {
                        SyntaxToken nextToken = syntaxToken.GetNextToken();
                        if (nextToken.ToString().Equals("."))
                        {
                            nextToken = nextToken.GetNextToken();
                            if (pomsList.LookupPomClassAndMethod(scriptComponent.ClassName, nextToken.ToString()))
                            {
                                Console.WriteLine("Found method usage");
                                ScriptComponentStep scriptComponentStep = new ScriptComponentStep();
                                scriptComponentStep.codeLine = line.ToString();
                                scriptComponentStep.MethodName = nextToken.ToString();

                                nextToken = nextToken.GetNextToken();
                                if (nextToken.ToString().Equals("("))
                                {
                                    nextToken = nextToken.GetNextToken();
                                    while (!nextToken.ToString().Equals(")"))
                                    {
                                        //nextToken = nextToken.GetNextToken();
                                        scriptComponentStep.parametersList.Add(nextToken.ToString());
                                        nextToken = nextToken.GetNextToken();
                                        if (nextToken.ToString().Equals(","))
                                        {
                                            nextToken = nextToken.GetNextToken();
                                        }
                                    }
                                }

                                scriptComponent.scriptComponentSteps.Add(scriptComponentStep);
                            }
                            else
                            {
                                throw new UnableToParseTestCodeException(line, "Unable to find method in POM.");
                            }
                        }
                        else
                        {
                            throw new UnableToParseTestCodeException(line, "Unable to determine method call. Last token was not '.' character.");
                        }
                    } else if (syntaxToken.ToString().Equals("Assert")) {
                        ScriptComponentStep scriptComponentStep = new ScriptComponentStep();
                        scriptComponentStep.codeLine = line.ToString();
                        scriptComponentStep.MethodName = syntaxToken.ToString();
                        SyntaxToken nextToken = syntaxToken.GetNextToken();
                        scriptComponentStep.MethodName += nextToken.ToString();
                        nextToken = nextToken.GetNextToken();
                        scriptComponentStep.MethodName += nextToken.ToString();

                        nextToken = nextToken.GetNextToken();

                        Console.WriteLine(syntaxToken.Parent);
                        Console.WriteLine(syntaxToken.Parent.GetType());
                        Console.WriteLine(syntaxToken.Parent.Parent);
                        Console.WriteLine(syntaxToken.Parent.Parent.GetType());
                        Console.WriteLine(syntaxToken.Parent.Parent.Parent);
                        Console.WriteLine(syntaxToken.Parent.Parent.Parent.GetType());
                        //Console.WriteLine(((MethodCallExpression)(syntaxToken.Parent.Parent.Parent)).Arguments);
                        //Console.WriteLine(syntaxToken.SyntaxTree);
                        if (nextToken.ToString().Equals("("))
                        {
                            nextToken = nextToken.GetNextToken();
                            while (!nextToken.ToString().Equals(")"))
                            {
                                //nextToken = nextToken.GetNextToken();
                                scriptComponentStep.parametersList.Add(nextToken.ToString());
                                nextToken = nextToken.GetNextToken();
                                if (nextToken.ToString().Equals(","))
                                {
                                    nextToken = nextToken.GetNextToken();
                                }
                            }
                        }

                        scriptComponent.scriptComponentSteps.Add(scriptComponentStep);
                    }
                    else
                    {
                        if (syntaxToken.GetNextToken().ToString().Equals("="))
                        {
                            if (instancesDeclaredList.ContainsKey(syntaxToken.ToString()))
                            {
                                scriptComponent = new ScriptComponent();
                                this.ScriptComponents.Add(scriptComponent);
                                scriptComponent.ClassName = instancesDeclaredList[syntaxToken.ToString()]; // TODO: capitalise (cheap shot approach) or use lookup to get class name (better way)
                                currentPomInstance = syntaxToken.ToString();
                            }
                        }
                        else
                        {
                            //throw new UnableToParseTestCodeException(line, "Next line does not match current components class.");
                        }
                    }
                }
            }
        }
    }
}
