using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OpenQA.Selenium.PrintOptions;

namespace CodeIntegratorPrototype.UI.Pages
{
    internal class HomePage
    {
        public HomePage(IWebDriver driver)
        {

        }

        public void WaitForModalSpinner()
        {
            Console.WriteLine("Waiting for no modal spinner...");
        }

        public void NavigateToPage(string pageName)
        {
            Console.WriteLine("Navigating to " + pageName + "...");
        }
    }
}
