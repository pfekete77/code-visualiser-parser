using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CodeIntegratorPrototype.SyntaxUnits
{
    internal class TestClassDescription
    {
        public string ClassName { get; set; }

        public ArrayList TestsList { get; set; }

        public TestClassDescription() {
            this.TestsList = new ArrayList();
        }

        internal void Print()
        {
            Console.WriteLine("    ClassName:" + ClassName);
            Console.WriteLine("    Tests:" + TestsList.Count);
            for (int i = 0; i < TestsList.Count; i++)
            {
                ((TestDescription)TestsList[i]).Print();
            }
        }
    }
}
