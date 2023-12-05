using CodeIntegratorPrototype.Extraction;
using CodeIntegratorPrototype.SyntaxUnits;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeIntegratorPrototype
{
    internal class BasicPrintoutFromMethodDescriptions
    {
        public static void Printout()
        {
            MethodsExtraction methodsExtraction = new MethodsExtraction(@"C:\Users\4221\source\repos\CodeIntegratorPrototype\CodeIntegratorPrototype\UI\Pages\LoginPage.cs");
            ArrayList methodsList = methodsExtraction.GetMethodsList();

            int ctr = 0;
            foreach (var method in methodsList)
            {
                ctr++;
                Console.WriteLine("");
                Console.WriteLine("Method #" + ctr);
                ((MethodDescription)method).Print();
            }
        }
    }
}
