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
    internal class BasicPrintoutFromTestClassDescription
    {
        public static void Printout()
        {
            TestsExtraction testsExtraction = new TestsExtraction(@"C:\Users\4221\source\repos\CodeIntegratorPrototype\CodeIntegratorPrototype\Tests\TC02_CreateNewAccount.cs");
            ArrayList testClassList = testsExtraction.GetTestClassList();

            int ctr = 0;
            foreach (var testClass in testClassList)
            {
                ctr++;
                Console.WriteLine("");
                Console.WriteLine("Class #" + ctr);
                ((TestClassDescription)testClass).Print();
            }
        }
    }
}
