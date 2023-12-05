using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeIntegratorPrototype.SyntaxUnits
{
    internal class MethodDescription
    {
        public String Name { get; set; }
        public String ClassName { get; set; }
        public ArrayList Modifiers { get; set; }
        public ArrayList Attributes { get; set; }
        public ArrayList Parameters { get; set; }

        public MethodDescription() {
            this.Modifiers = new ArrayList();
            this.Attributes = new ArrayList();
            this.Parameters = new ArrayList();
        }

        public void Print()
        {
            Console.WriteLine("    Name:" + Name);
            Console.WriteLine("    ClassName:" + ClassName);
            Console.WriteLine("    Modifiers:" + Modifiers.Count);
            for (int i=0; i<Modifiers.Count; i++)
            {
                Console.WriteLine("        " + (i + 1).ToString() + ":" + Modifiers[i]);
            }
            Console.WriteLine("    Attributes:" + Attributes.Count);
            for (int i=0; i<Attributes.Count; i++)
            {
                Console.WriteLine("        " + (i + 1).ToString() + ":" + Attributes[i]);
            }
            Console.WriteLine("    Parameters:" + Parameters.Count);
            for (int i=0; i<Parameters.Count; i++)
            {
                Console.WriteLine("        " + (i + 1).ToString() + ":" + Parameters[i]);
            }
        }
    }
}
