using CodeIntegratorPrototype.LookupTables;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeIntegratorPrototype.Models
{
    internal class ScriptsList
    {
        public string Name { get; set; }
        
        public PageObjectModelTable pageObjectModelTable { get; set; }
        public ArrayList ScriptDescriptionsList { get; set; }  
        public ScriptsList(string name) {
            this.Name = name;
            this.ScriptDescriptionsList = new ArrayList();
        }

        public void PrintOut()
        {
            Console.WriteLine("Name:" + Name);
            foreach (ScriptDescription scriptDescription in ScriptDescriptionsList) {
                scriptDescription.PrintOut(1);
            }
        }

    }
}
