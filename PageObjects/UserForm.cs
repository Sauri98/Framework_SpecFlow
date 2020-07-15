using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FrameworkTest_Specflow.PageObjects
{
    class UserForm
    {
        public static void userForm()
        {
            IList<IWebElement> automationtools = PropertiesDr.driver.FindElements(By.TagName("span"));
            foreach (IWebElement ele in automationtools)
            {
                if (ele.Text.Equals("User Form"))
                {
                    ele.Click();
                    break;
                }
            }
            IWebElement element = PropertiesDr.driver.FindElement(By.XPath(".//a[contains(@href,'index.html')]"));
            element.Click();
            Thread.Sleep(3000);
        }
        //Enter text
        public static void EnterText(string element, string value, PropertyType elementtype)
        {
            if (elementtype == PropertyType.Id)
                PropertiesDr.driver.FindElement(By.Id(element)).SendKeys(value);
            if (elementtype == PropertyType.Name)
                PropertiesDr.driver.FindElement(By.Name(element)).SendKeys(value);



        }
        //Click into a button,checkbox,option
        public static void Click(string element, PropertyType elementtype)
        {
            if (elementtype == PropertyType.Id)
                PropertiesDr.driver.FindElement(By.Id(element)).Click();
            if (elementtype == PropertyType.Name)
                PropertiesDr.driver.FindElement(By.Name(element)).Click();
        }
        //Selecting a drop down control
        public static void SelectDropDown(string element, string value, PropertyType elementtype)
        {
            if (elementtype == PropertyType.Id)
                new SelectElement(PropertiesDr.driver.FindElement(By.Id(element))).SelectByText(value);
            if (elementtype == PropertyType.Name)
                new SelectElement(PropertiesDr.driver.FindElement(By.Name(element))).SelectByText(value);
        }
    }
}
