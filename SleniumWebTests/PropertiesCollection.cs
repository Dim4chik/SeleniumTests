using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleniumWebTests
{
    enum PropertyType
    {
        Id,
        Name,
        LinkText,
        CssName,
        ClassName
    }
    partial class PropertiesCollection
    {
        public static IWebDriver driver { get; set; }
    }
    partial class PropertiesCollection
    {
        public static IWebElement element { get; set; }
    }

}
