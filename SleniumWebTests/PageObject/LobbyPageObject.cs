using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleniumWebTests.LobbyPageObject
{
    public class LobbyPageObject
    {
        public LobbyPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "button.collect-button")]
        public IWebElement ButtonCollect { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.balance.balance-coins>div.score>span")]
        public IWebElement BalanceCoins { get; set; }

        [FindsBy(How = How.CssSelector, Using = "p.icon-bell.envelope.unread")]
        public IWebElement Notifications { get; set; }

        [FindsBy(How = How.CssSelector, Using = "li.item")]
        public IWebElement BonusItem { get; set; }

        [FindsBy(How = How.CssSelector, Using = "li:nth-child(1) > div > div > i")]
        public IWebElement ButtonWorld { get; set; }

        [FindsBy(How = How.CssSelector, Using = "ul>li.position-3")]
        public IWebElement ThirdGame { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.back.ng-star-inserted")]
        public IWebElement BackButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "li:nth-child(2)>div>div>i")]
        public IWebElement ButtonSkillGames { get; set; }

        [FindsBy(How = How.CssSelector, Using = "li:nth-child(3)>div>div>i")]
        public IWebElement MyProfile { get; set; }

        [FindsBy(How = How.CssSelector, Using = "li:nth-child(4)>div>div>i")]
        public IWebElement Promotions { get; set; }

        [FindsBy(How = How.CssSelector, Using = "li:nth-child(5)>div>div>i")]
        public IWebElement LeaderBoard { get; set; }

        [FindsBy(How = How.CssSelector, Using = "li:nth-child(6)>div>div>i")]
        public IWebElement Tournaments { get; set; }

        [FindsBy(How = How.CssSelector, Using = "li:nth-child(7)>div>div>i")]
        public IWebElement Challenges { get; set; }

        [FindsBy(How = How.CssSelector, Using = "span.settings")]
        public IWebElement SettingsButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.logout>button.custom-btn")]
        public IWebElement LogoutButton { get; set; }

        
    }
}
