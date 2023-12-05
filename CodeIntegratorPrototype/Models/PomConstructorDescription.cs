using OpenQA.Selenium.DevTools.V112.Debugger;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeIntegratorPrototype.Models
{
    internal class PomConstructorDescription
    {
        public string Name { get; set; }
        public string ClassName { get; set; }
        public string Namespace { get; set; }
        public ArrayList Attributes { get; set; }
        public ArrayList Modifiers { get; set; }
        public ArrayList Parameters { get; set; }

        public PomConstructorDescription(string name, string className, string @namespace)
        {
            Name = name;
            ClassName = className;
            Namespace = @namespace;
            Attributes = new ArrayList();
            Modifiers = new ArrayList();
            Parameters = new ArrayList();
        }

        internal void PrintOut(int indentAmount)
        {
            string indentString = Utils.ConsoleOutputHelper.GetIndentString(indentAmount);

            Console.WriteLine(indentString + "Name:" + Name);
        }
    }
}
