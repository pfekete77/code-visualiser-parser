using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace CodeIntegratorPrototype.Utils
{
    internal class ConsoleOutputHelper
    {
        public static string GetIndentString(int indentAmount)
        {
            string indentString = "";
            for (int i = 0; i < indentAmount; i++)
            {
                indentString += "\t";
            }
            return indentString;
        }
    }
}
