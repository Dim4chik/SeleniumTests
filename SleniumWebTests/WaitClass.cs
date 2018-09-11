using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleniumWebTests
{
    public class WaitClass
    {
        public static bool WaitForElementMethod(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(10));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                try
                {
                    return element.Enabled;
                }
                
                catch (Exception ex)
                {
                    return false;
                }
            });
            return wait.Until(waitForElement);
        }
    }
}