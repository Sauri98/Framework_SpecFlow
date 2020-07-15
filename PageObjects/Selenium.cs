using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkTest_Specflow.PageObjects
{
    public class Selenium
    {

        private static By automationTools = By.Id("Automation Tools");
        private static By selenium = By.Id("Selenium");
        IWebElement seleniumwebdriver = PropertiesDr.driver.FindElement(By.Id("Selenium WebDriver"));
        IWebElement seleniumRc = PropertiesDr.driver.FindElement(By.Id("Selenium RC"));
        IWebElement SeleniumIDE = PropertiesDr.driver.FindElement(By.Id("Selenium IDE"));
        //static Actions ac = new Actions(PropertiesDr.driver);
        //main menu- automation tool
        public static void NavigationElements()
        {
            //Thread.Sleep(3000);
            PropertiesDr.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


            IWebElement automationtools1 = PropertiesDr.driver.FindElement(automationTools);

            //Actions ac = new Actions(PropertiesDr.driver);
            WebDriverWait wait = new WebDriverWait(PropertiesDr.driver, new TimeSpan(0, 0, 10));
            wait.Until(driver => PropertiesDr.driver.FindElement(automationTools).Displayed);
            Actions ac = new Actions(PropertiesDr.driver);
            ac.MoveToElement(automationtools1).Build().Perform();
            //automationtools1.Click();

            //Thread.Sleep(3000);

        }

        //should click selenium option
        public static void AutomationSubmenu(string submenu)
        {
            try
            {
                PropertiesDr.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                //Thread.Sleep(3000);
                //WebDriverWait wait = new WebDriverWait(PropertiesDr.driver, TimeSpan.FromSeconds(60));
                //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[@id='Selenium']")));
                WebDriverWait wait = new WebDriverWait(PropertiesDr.driver, new TimeSpan(0, 0, 10));
                wait.Until(driver => PropertiesDr.driver.FindElement(By.XPath("//span[@id='" + submenu + "']")).Displayed);
                IWebElement seleniumMenu = PropertiesDr.driver.FindElement(By.XPath("//span[@id='" + submenu + "']"));
                Actions ac = new Actions(PropertiesDr.driver);
                ac.MoveToElement(seleniumMenu).Build().Perform();
                //if (seleniumMenu.Displayed)
                //{
                //    seleniumMenu.Click();

                //    // Thread.Sleep(3000);
                //}

            }
            catch (Exception e)
            {

                throw e;
            }



            // WebDriverWait wait = new WebDriverWait(PropertiesDr.driver, TimeSpan.FromSeconds(3));
            // wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@id = 'Selenium')")));
            //seleniumMenu.Click();

            //Thread.Sleep(3);

        }

        public static void SeleniumSubmenuNavigation(string submenu)
        {
            PropertiesDr.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //Thread.Sleep(3000);
            IWebElement submenuNav = PropertiesDr.driver.FindElement(By.Id(submenu));

            //ac.MoveToElement(submenuNav).Build().Perform();

            //WebDriverWait wait = new WebDriverWait(PropertiesDr.driver, new TimeSpan(0, 0, 10));
            //wait.Until(driver => PropertiesDr.driver.FindElement(By.Id(submenu)).Displayed);
            submenuNav.Click();

            //Thread.Sleep(3000);
        }



        public static bool VerifyResults(string header)
        {
            IWebElement result = PropertiesDr.driver.FindElement(By.TagName("h2"));
            if (result.Text.Equals(header))
            {
                return true;
            }

            return false;

        }
    }
}
