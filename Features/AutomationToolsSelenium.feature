Feature: AutomationToolsSelenium

Scenario: SeleniumIDEVerfication
	Given I am in user form page 
	When  I navigated to Selenium IDE 
	Then  Selenium IDE page should be displayed

Scenario: SeleniumRcVerification
	Given I am in Selenium IDE page
	When I navigated to Selenium Rc
	Then Selenium Rc page should be displayed

Scenario: SeleniumWebDriverVerification
	Given I am in Selenium Rc page
	When I navigated to Selenium WebDriver
	Then Selenium WebDriver page should be displayed

Scenario: UserFormVerification
	Given I am in Selenium WebDriver page
	When I navigated to UserForm and Passing the value to the form
	