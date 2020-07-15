using FrameworkTest_Specflow.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace FrameworkTest_Specflow.Steps
{
    [Binding]
    public class AutomationToolsSeleniumSteps
    {
        [Given(@"I am in user form page")]
        public void GivenIAmInUserFormPage()
        {
            Assert.IsTrue(Selenium.VerifyResults("User Form"), "Header is invalid");
        }

        [When(@"I navigated to Selenium IDE")]
        public void WhenINavigatedToSeleniumIDE()
        {
            Selenium.NavigationElements();

            Selenium.AutomationSubmenu("Selenium");
            Selenium.SeleniumSubmenuNavigation("Selenium IDE");
        }

        [Then(@"Selenium IDE page should be displayed")]
        public void ThenSeleniumIDEPageShouldBeDisplayed()
        {
            Assert.IsTrue(Selenium.VerifyResults("Selenium IDE"), "Header is invalid");
        }

        [Given(@"I am in Selenium IDE page")]
        public void GivenIAmInSeleniumIDEPage()
        {
            Assert.IsTrue(Selenium.VerifyResults("Selenium IDE"), "Header is invalid");
        }

        [When(@"I navigated to Selenium Rc")]
        public void WhenINavigatedToSeleniumRc()
        {
            Selenium.NavigationElements();
            Selenium.AutomationSubmenu("Selenium");
            Selenium.SeleniumSubmenuNavigation("Selenium RC");
            
        }

        [Then(@"Selenium Rc page should be displayed")]
        public void ThenSeleniumRcPageShouldBeDisplayed()
        {
            Assert.IsTrue(Selenium.VerifyResults("Selenium RC"), "Header is invalid");
        }

        [Given(@"I am in Selenium Rc page")]
        public void GivenIAmInSeleniumRcPage()
        {
            Assert.IsTrue(Selenium.VerifyResults("Selenium RC"), "Header is invalid");
        }

        [When(@"I navigated to Selenium WebDriver")]
        public void WhenINavigatedToSeleniumWebDriver()
        {
            Selenium.NavigationElements();
            Selenium.AutomationSubmenu("Selenium");
            Selenium.SeleniumSubmenuNavigation("Selenium WebDriver");
            Assert.IsTrue(Selenium.VerifyResults("Selenium WebDriver"), "Header is invalid");
        }

        [Then(@"Selenium WebDriver page should be displayed")]
        public void ThenSeleniumWebDriverPageShouldBeDisplayed()
        {
            Assert.IsTrue(Selenium.VerifyResults("Selenium WebDriver"), "Header is invalid");
        }

        [Given(@"I am in Selenium WebDriver page")]
        public void GivenIAmInSeleniumWebDriverPage()
        {
            Assert.IsTrue(Selenium.VerifyResults("Selenium WebDriver"), "Header is invalid");
        }

        [When(@"I navigated to UserForm and Passing the value to the form")]
        public void WhenINavigatedToUserFormAndPassingTheValueToTheForm()
        {
            UserForm.userForm();

            //title
            UserForm.SelectDropDown("TitleId", "Mr.", PropertyType.Id);
            //Initial
            UserForm.EnterText("Initial", "Saurabh", PropertyType.Name);
            //Click
            UserForm.Click("Save", PropertyType.Name);
        }




    }
}
