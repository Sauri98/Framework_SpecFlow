using FrameworkTest_Specflow.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkTest_Specflow.Test_cases
{
    class AutomationTools_Selenium
    {
        public static void SeleniumWebDriverVerification()
        {
            Selenium.NavigationElements();
            Selenium.AutomationSubmenu("Selenium");
            Selenium.SeleniumSubmenuNavigation("Selenium WebDriver");
            Assert.IsTrue(Selenium.VerifyResults("Selenium WebDriver"), "Header is invalid");

        }

        public static void SeleniumRcVerification()
        {
            Selenium.NavigationElements();
            Selenium.AutomationSubmenu("Selenium");
            Selenium.SeleniumSubmenuNavigation("Selenium RC");
            Assert.IsTrue(Selenium.VerifyResults("Selenium RC"), "Header is invalid");

        }

        public static void SeleniumIDEVerification()
        {
            Selenium.NavigationElements();

            Selenium.AutomationSubmenu("Selenium");
            Selenium.SeleniumSubmenuNavigation("Selenium IDE");
            Assert.IsTrue(Selenium.VerifyResults("Selenium IDE"), "Header is invalid");

        }


    }
}
