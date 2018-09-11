using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleniumWebTests.TournamentsPageObject
{
    public class TournamentsPageObject
    {
        public TournamentsPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }
         
        [FindsBy(How = How.CssSelector, Using = "div.side.left>div.back")]
        public IWebElement BackButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "h5.name")]
        public IWebElement TournamentHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#autoPlay")]
        public IWebElement AutoPlay { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#makeWin")]
        public IWebElement MakeWin { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.collect-button")]
        public IWebElement ButtonCollect { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.balance.balance-gems>div.score>span")]
        public IWebElement BalanceGems { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.close-button")]
        public IWebElement AfterWinTournamentOK { get; set; }

    }
}
