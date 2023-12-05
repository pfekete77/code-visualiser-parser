using CodeIntegratorPrototype.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeIntegratorPrototype.Models
{
    internal class ScriptComponent
    {
        public string ClassName;

        public ArrayList scriptComponentSteps = new ArrayList();
        public ScriptComponent() { }

        internal void PrintOut(int indentAmount) { 
            string indentString = ConsoleOutputHelper.GetIndentString(indentAmount);
            Console.WriteLine(indentString + "Script component class name:" + ClassName);
            foreach (ScriptComponentStep scriptComponentStep in scriptComponentSteps)      
            {                
                scriptComponentStep.PrintOut(indentAmount + 1);
            }
        }
    }
}
