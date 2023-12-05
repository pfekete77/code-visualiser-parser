using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeIntegratorPrototype.UI.Components
{
    internal class NewAccountModal
    {
        public NewAccountModal(IWebDriver driver)
        {

        }

        public void SelectAccountType(string accountType)
        {
            Console.WriteLine("Selecting account type...");
        }

        public void EnterAccountName(string accountName)
        {
            Console.WriteLine("Enter account name...");
        }

        public void EnterEmailAddress(string emailAddress) { Console.WriteLine("Entering email..."); }

        public void ClickCreateButton() { Console.WriteLine("Clicking create button..."); }
    }
}
