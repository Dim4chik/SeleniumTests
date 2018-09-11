using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleniumWebTests.SkillGamePageObject
{
    public class SkillGamePageObject
    {
        public SkillGamePageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "div.owl-stage-outer>div>div:nth-child(1)>div>div:nth-child(1)>div>button")]
        public IWebElement FirstGame { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.side.left>div.back")]
        public IWebElement BackButton { get; set; }


    }
}
