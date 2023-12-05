using Microsoft.CodeAnalysis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeIntegratorPrototype.Models
{
    internal class PomsList
    {
        public string Name { get; set; }
        public ArrayList PomDescriptionsList { get; set; }

        public PomsList(string name) {
            this.Name = name;
            this.PomDescriptionsList = new ArrayList();
        }

        public void PrintOut()
        {
            Console.WriteLine("Name:" + this.Name);
            foreach (PomDescription pomDescription in PomDescriptionsList)
            {
                pomDescription.PrintOut(1);
            }
        }

        internal bool LookupPomDescription(string syntaxNodeOrToken)
        {
            foreach (PomDescription pomDescription in PomDescriptionsList)
            {
                if (pomDescription.Name.Equals(syntaxNodeOrToken))
                {
                    return true;
                }
            }
            return false;
        }

        internal bool LookupPomClassAndMethod(string className, string methodName)
        {
            foreach (PomDescription pomDescription in PomDescriptionsList)
            {
                if (pomDescription.Name.Equals(className))
                {
                    foreach (PomMethodDescription pomMethodDescription in pomDescription.pomMethods)
                    {
                        if (pomMethodDescription.Name.Equals(methodName))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
