using CodeIntegratorPrototype.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeIntegratorPrototype.UI.Pages
{
    internal class LoginPage
    {
        protected IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        [PlainEnglishMethodName("Enter username")]
        public void SetUsername(string username)
        {
            Console.WriteLine("Setting username:" + username);
        }

        public void SetPassword(string password)
        {
            Console.WriteLine("Setting password:" + password);
        }

        public void ClickLoginButton()
        {
            Console.WriteLine("Clicking login button...");
        }
    }
}
