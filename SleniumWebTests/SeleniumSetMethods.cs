using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SleniumWebTests
{
    public static class SeleniumSetMethods
    {
        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value);
        }
        public static void Click(this IWebElement element)
        {
            element.Click();
        }
        public static void SelectDropDown(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByValue(value);
        }
        
    }
}

