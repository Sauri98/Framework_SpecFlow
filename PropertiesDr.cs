using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkTest_Specflow
{
    enum PropertyType
    {
        Id,
        Name,
        LinkText,
        CssName,
        ClassName
    }
    class PropertiesDr
    {


        public static IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

    }
}
