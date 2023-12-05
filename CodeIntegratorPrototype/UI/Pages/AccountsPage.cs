using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeIntegratorPrototype.UI.Pages
{
    internal class AccountsPage
    {
        public AccountsPage(IWebDriver driver)
        {

        }

        public void ClickNewAccountButton()
        {
            Console.WriteLine("Clicking new account button...");
        }

        internal void OpenAccountRecord(string username)
        {
            Console.WriteLine("Opening account record... [" + username + "]");
        }
    }
}
