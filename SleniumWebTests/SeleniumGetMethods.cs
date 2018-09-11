using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleniumWebTests.PageObject
{
    class SeleniumGetMethods
    {
        public static string GetText(IWebElement element)
        {
            return element.GetAttribute("value");
        }
        public static bool IsAttribtuePresent(IWebElement element, string attribute)
        {
            bool result = false;
                string value = element.GetAttribute(attribute);
                if (value != null)
                {
                    result = true;
                }
           return result;
        }

    }
}
