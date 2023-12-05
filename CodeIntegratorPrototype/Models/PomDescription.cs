using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeIntegratorPrototype.Models
{
    internal class PomDescription
    {
        public string Name { get; set; }
        public ArrayList pomConstructors {  get; set; }
        public ArrayList pomMethods { get; set; }

        public PomDescription(string name) {
            this.Name = name;
            this.pomConstructors = new ArrayList();
            this.pomMethods = new ArrayList();
        }

        public void PrintOut(int indentAmount)
        {
            string indentString = Utils.ConsoleOutputHelper.GetIndentString(indentAmount);

            Console.WriteLine(indentString + "POM Name:" + this.Name);
            Console.WriteLine(indentString + "Constructors:");
            foreach (PomConstructorDescription pomConstructorDescription in pomConstructors)
            {
                pomConstructorDescription.PrintOut(indentAmount+1);
            }
            Console.WriteLine(indentString + "Methods:");
            foreach (PomMethodDescription pomMethodDescription in pomMethods)
            {
                pomMethodDescription.PrintOut(indentAmount + 1);
            }
        }
    }
}
