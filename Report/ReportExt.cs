//using AventStack.ExtentReports;
//using AventStack.ExtentReports.Reporter;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Reflection;
//using System.Text;
//using NUnit.Framework;
//using NUnit.Framework.Interfaces;
//using System.Threading;
//using FrameworkTest_Specflow;
//using TechTalk.SpecFlow;
//using AventStack.ExtentReports.Reporter.Configuration;
//using AventStack.ExtentReports.Gherkin.Model;

//namespace FrameworkTest
//{
//    public class ReportExt
//    {
//        //static ExtentHtmlReporter htmlReporter;
//        //static ExtentReports reports;
//        //static ExtentTest test;
//        //static IWebDriver driver;
//        private static ExtentTest _featureName;
//        private static ExtentTest _scenario;
//        private static ExtentReports _extent;
//        private static ScenarioContext _scenarioContext;
//        public static string ProjectDir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\.."));
//        public ReportExt(ScenarioContext scenarioContext)
//        {
//            _scenarioContext = scenarioContext;
//        }
//        public static void reportInitialize()
//        {
//            //var fileName =  "Report.html";
//            //htmlReporter = new ExtentHtmlReporter(@"C:\Users\SaurabhG2\source\repos\FrameworkTest\Report" + fileName);

//            //reports = new ExtentReports();
//            //reports.AttachReporter(htmlReporter);
//            //reports = new ExtentReports();
//            //var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\netcoreapp2.2", "");
//            //DirectoryInfo di = Directory.CreateDirectory(dir + "\\Test_Execution_Reports");
//            //var htmlreporter = new ExtentHtmlReporter(dir + "\\Test_Execution_Reports" + "\\Automation_Report" + ".html");
//            //reports.AttachReporter(htmlreporter);

//            var _path = Path.Combine(ProjectDir, "Extent Reports");
//            Directory.CreateDirectory(_path);
//            var htmlReporter = new ExtentHtmlReporter(_path + "//");
//            htmlReporter.Config.Theme = Theme.Dark;
//            _extent = new ExtentReports();
//            _extent.AttachReporter(htmlReporter);

//        }

//        public static void flushReport()
//        {
//            _extent.Flush();
//        }

//        public static void BeforeFeature(FeatureContext featureContext)
//        {
//            //test = reports.CreateTest(TestContext.CurrentContext.Test.Name);
//            //test.Log(Status.Info, "Test Started");
//            _featureName = _extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
//        }

//        public static void BeforeScenario()
//        {
//            _scenario = _featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
//        }
//        //public static void AfterTest()
//        //{
//        //    var status = TestContext.CurrentContext.Result.Outcome.Status;
//        //    var stacktrace = "" + TestContext.CurrentContext.Result.StackTrace + "";
//        //    var errormessage = TestContext.CurrentContext.Result.Message;
//        //    Status logstatus;
//        //    switch (status)
//        //    {
//        //        case TestStatus.Failed:
//        //            logstatus = Status.Fail;
//        //            string screenShotPath = Capture(PropertiesDr.driver, TestContext.CurrentContext.Test.Name);
//        //            test.Log(logstatus, "Test ended with " + logstatus + " – " + errormessage);
//        //            test.Log(logstatus, "Snapshot below: " + test.AddScreenCaptureFromPath(screenShotPath));
//        //            break;



//        //        case TestStatus.Skipped:
//        //            logstatus = Status.Skip;
//        //            test.Log(logstatus, "Test ended with " + logstatus);
//        //            break;



//        //        default:
//        //            logstatus = Status.Pass;
//        //            test.Log(logstatus, "Test ended with " + logstatus);
//        //            break;
//        //    }

//        //}

//        //private static string Capture(IWebDriver driver, string screenShotName)
//        //{
//        //    string localpath = "";
//        //    try
//        //    {
//        //        Thread.Sleep(4000);
//        //        ITakesScreenshot ts = (ITakesScreenshot)driver;
//        //        Screenshot screenshot = ts.GetScreenshot();
//        //        string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
//        //        var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
//        //        DirectoryInfo di = Directory.CreateDirectory(dir + "\\Test_Execution_Reports\\Defect_Screenshots\\");
//        //        // string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "\\Test_Execution_Reports\\Defect_Screenshots\\" + screenShotName + ".png";
//        //        string finalpth = di + screenShotName + ".png";
//        //        localpath = new Uri(finalpth).LocalPath;
//        //        screenshot.SaveAsFile(localpath);
//        //    }
//        //    catch (Exception e)
//        //    {
//        //        throw (e);
//        //    }
//        //    return localpath;
//        //}

//        public static void AfterStep()
//        {
//            var steptype = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
//            if (_scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.OK)
//            {
//                if (steptype == "Given")
//                {
//                    _scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
//                }
//                else if (steptype == "When")
//                {
//                    _scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);

//                }
//                else if (steptype == "Then")
//                {
//                    _scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);

//                }
//            }
//            if(_scenarioContext.ScenarioExecutionStatus != ScenarioExecutionStatus.OK)
//            {
//                if(_scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.StepDefinitionPending)
//                {
//                    if (steptype == "Given")
//                    {
//                        _scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("This step has been skipped");
//                    }
//                    else if (steptype == "When")
//                    {
//                        _scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("This step has been skipped"); 

//                    }
//                    else if (steptype == "Then")
//                    {
//                        _scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("This step has been skipped"); 

//                    }

//                }
//                if(_scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.BindingError ||
//                    _scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.TestError||
//                    _scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.UndefinedStep)
//                {
//                    if (steptype == "Given")
//                    {
//                        _scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
//                    }
//                    else if (steptype == "When")
//                    {
//                        _scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);

//                    }
//                    else if (steptype == "Then")
//                    {
//                        _scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);

//                    }

//                }

//            }
//        }
//    }
//}
