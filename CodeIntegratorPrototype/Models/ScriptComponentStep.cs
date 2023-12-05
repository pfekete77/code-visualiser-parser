using CodeIntegratorPrototype.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeIntegratorPrototype.Models
{
    internal class ScriptComponentStep
    {
        public string codeLine;
        public string MethodName;
        public ArrayList parametersList = new ArrayList();

        public ScriptComponentStep() { } 

        internal void PrintOut(int indentAmount)
        {
            string indentString = ConsoleOutputHelper.GetIndentString(indentAmount);
            Console.WriteLine(indentString + "method name:" + MethodName);
            bool firstLineFlag = true;
            foreach (var parameter in parametersList)
            {
                Console.WriteLine(indentString + "    parameter:" + parameter.ToString());
            }
        }
    }
}
