using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkTest_Specflow.Test_cases
{
    class LoginPage
    {
        public static void Login()
        {


            PropertiesDr.driver.Url = "http://www.executeautomation.com/demosite/Login.html";
            PropertiesDr.driver.Manage().Window.Maximize();
            
            IWebElement username = PropertiesDr.driver.FindElement(By.Name("UserName"));
            IWebElement password = PropertiesDr.driver.FindElement(By.Name("Password"));
            IWebElement login = PropertiesDr.driver.FindElement(By.XPath(".//input[contains(@type, 'submit')]"));
            username.SendKeys("admin");
            password.SendKeys("admin");
            login.Click();
        }


    }

}
