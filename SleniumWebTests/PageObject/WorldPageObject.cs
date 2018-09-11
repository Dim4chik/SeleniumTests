using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleniumWebTests.WorldPageObject
{
    public class WorldPageObject
    {
        public WorldPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }
 
        [FindsBy(How = How.CssSelector, Using = "i.btn-icon.icon-games")]
        public IWebElement ButtonWorld { get; set; }

        [FindsBy(How = How.CssSelector, Using = "li.position-3.ng-star-inserted>div>div>div.info-block")]
        public IWebElement GameFreshFruit { get; set; }

        [FindsBy(How = How.CssSelector, Using = "li:nth-child(1)>div>div>div.info-block>p.title")]
        public IWebElement Paris { get; set; }

        [FindsBy(How = How.CssSelector, Using = "li:nth-child(1)>div>div>div.info-block>p")]
        public IWebElement FirstCasino { get; set; }

        [FindsBy(How = How.CssSelector, Using = "ul>li.position-0")]
        public IWebElement DevGame { get; set; }

        [FindsBy(How = How.CssSelector, Using = "ul>li.position-3")]
        public IWebElement ThirdGame { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#doBet")]
        public IWebElement DoBet { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#makeWin")]
        public IWebElement MakeWin { get; set; }

        [FindsBy(How = How.ClassName, Using = "lvl")]
        public IWebElement Level { get; set; }
    }
}
