using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleniumWebTests.ChallangesPageObject
{
    public class ChallangesPageObject
    {
        public ChallangesPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }
 
        [FindsBy(How = How.CssSelector, Using = "button.new-challenge")]
        public IWebElement NewChallangeButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.owl-stage-outer>div>div:nth-child(1)>div>div")]
        public IWebElement FirstGameInChallangeList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.owl-stage-outer>div>div:nth-child(2)>div>div")]
        public IWebElement SecondGameInChallangeList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.custom-btn.create-btn")]
        public IWebElement CreateChallangeButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.side.left>div.back")]
        public IWebElement BackButton { get; set; }
    }
}
