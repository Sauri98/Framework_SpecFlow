using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;


using FrameworkTest_Specflow.Test_cases;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace FrameworkTest_Specflow
{
    [Binding]
    public class Hooks
    {
        private static ExtentTest _featureName;
        private static ExtentTest _scenario;
        private static ExtentReports _extent;
        private static ScenarioContext _scenarioContext;
        public static string ProjectDir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\.."));

        //public Hooks(ScenarioContext scenarioContext)
        //{
        //    _scenarioContext =  scenarioContext;
        //}
        //public static IWebDriver driver;
        [BeforeTestRun]
        public static void OneTimeSetup()
        {
            //ReportExt.reportInitialize();
            var _path = Path.Combine(ProjectDir, "Extent Reports");
            Directory.CreateDirectory(_path);
            var htmlReporter = new ExtentHtmlReporter(_path + "//");
            htmlReporter.Config.Theme = Theme.Dark;
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);

            LoginPage.Login();
        
        }
        [BeforeScenario]
        public static void Initialize(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            //ReportExt.BeforeScenario();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            _scenario = _featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
            //driver = new ChromeDriver();
            if (PropertiesDr.driver == null)
            {
                
                LoginPage.Login();
               
            }


        }
        [AfterStep]
        public static void AfterStep()
        {
            //ReportExt.AfterStep();
            var steptype = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (_scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.OK)
            {
                if (steptype == "Given")
                {
                    _scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (steptype == "When")
                {
                    _scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);

                }
                else if (steptype == "Then")
                {
                    _scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);

                }
            }
            if (_scenarioContext.ScenarioExecutionStatus != ScenarioExecutionStatus.OK)
            {
                if (_scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.StepDefinitionPending)
                {
                    if (steptype == "Given")
                    {
                        _scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("This step has been skipped");
                    }
                    else if (steptype == "When")
                    {
                        _scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("This step has been skipped");

                    }
                    else if (steptype == "Then")
                    {
                        _scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("This step has been skipped");

                    }

                }
                if (_scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.BindingError ||
                    _scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.TestError ||
                    _scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.UndefinedStep)
                {
                    if (steptype == "Given")
                    {
                        _scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                    }
                    else if (steptype == "When")
                    {
                        _scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);

                    }
                    else if (steptype == "Then")
                    {
                        _scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);

                    }

                }

            }
        }

        


        [AfterTestRun]
        public static void OneTimeTearDown()
        {
            // ReportExt.flushReport();
            _extent.Flush();
            if (PropertiesDr.driver != null)
            {
                PropertiesDr.driver.Quit();
            }
            
        }

        [AfterScenario]
        public static void CleanUp()
        {
            //ReportExt.AfterTest();
            if (TestContext.CurrentContext.Result.Outcome.ToString().Equals("Failed"))
            {
                //PropertiesDr.driver.Quit();
                PropertiesDr.driver = null;
            }
        }

        [BeforeFeature]
        public static void beforefeature(FeatureContext featureContext)
        {
            //ReportExt.BeforeFeature(featureContext);
            _featureName = _extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

    }
}
