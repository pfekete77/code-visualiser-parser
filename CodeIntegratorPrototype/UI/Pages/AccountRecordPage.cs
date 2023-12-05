using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeIntegratorPrototype.UI.Pages
{
    internal class AccountRecordPage
    {
        public AccountRecordPage(IWebDriver driver)
        {

        }

        internal string GetAccountType()
        {
            Console.WriteLine("Getting account type...");
            return "<<<account type>>>";
        }

        internal string GetEmail()
        {
            Console.WriteLine("Getting email...");
            return "<<<email>>>";
        }

        internal string GetUsername()
        {
            Console.WriteLine("Getting username...");
            return "<<<username>>>";
        }
    }
}
