using Microsoft.CodeAnalysis;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeIntegratorPrototype.SyntaxUnits
{
    internal class TestDescription
    {
        public string Name { get; set; }
        public ArrayList Modifiers { get; set; }
        public ArrayList Attributes { get; set; }
        public ArrayList Parameters { get; set; }
        public ArrayList CodeList { get; set; }
        public ArrayList CodeListNodes { get; set; }

        public TestDescription()
        {
            this.Modifiers = new ArrayList();
            this.Parameters = new ArrayList();
            this.Attributes = new ArrayList();
            this.CodeList = new ArrayList();
            this.CodeListNodes = new ArrayList();
        }

        internal void PrintNodeOrTokenList(SyntaxNodeOrToken syntaxNodeOrToken)
        {
            if (syntaxNodeOrToken.IsToken == false)
            {
                foreach (var nodeOrToken in syntaxNodeOrToken.ChildNodesAndTokens())
                {
                    PrintNodeOrTokenList(nodeOrToken);
                }
            }
            else
            {
                Console.WriteLine("            " + syntaxNodeOrToken.ToString());
            }
        }
        internal void Print()
        {
            Console.WriteLine("    Name:" + Name);
            Console.WriteLine("    Modifiers:" + Modifiers.Count);
            for (int i = 0; i < Modifiers.Count; i++)
            {
                Console.WriteLine("        " + (i + 1).ToString() + ":" + Modifiers[i]);
            }
            Console.WriteLine("    Attributes:" + Attributes.Count);
            for (int i = 0; i < Attributes.Count; i++)
            {
                Console.WriteLine("        " + (i + 1).ToString() + ":" + Attributes[i]);
            }
            Console.WriteLine("    Parameters:" + Parameters.Count);
            for (int i = 0; i < Parameters.Count; i++)
            {
                Console.WriteLine("        " + (i + 1).ToString() + ":" + Parameters[i]);
            }
            Console.WriteLine("    Code list:");
            for (int i = 0; i < CodeList.Count; i++)
            {
                Console.WriteLine("        " + (i + 1).ToString() + ":" + CodeList[i]);
            }
            Console.WriteLine("    Code list nodes:");
            for (int i = 0; i < CodeListNodes.Count; i++)
            {
                Console.WriteLine("        " + (i + 1).ToString());
                foreach (var nodesAndTokens in ((SyntaxNode)CodeListNodes[i]).ChildNodesAndTokens()) 
                {
                    PrintNodeOrTokenList(nodesAndTokens);
                }
            }
        }
    }
}
