using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SleniumWebTests.LoginPageObject
{
    public class LoginPageObject
    {
        public LoginPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }
        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement Username { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.mt-sm-1")]
        public IWebElement ButtonLogin { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.guest")]
        public IWebElement ButtonGuest { get; set; }

        [FindsBy(How = How.CssSelector, Using = "li>p.ng-star-inserted")]
        public IWebElement IncorrectPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "li.mb-1")]
        public IWebElement ForgotPassword { get; set; }

        [FindsBy(How = How.Name, Using = "forgot")]
        public IWebElement SendEmail { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.custom-btn")]
        public IWebElement ButtonOK { get; set; }

        [FindsBy(How = How.CssSelector, Using = "form>a")]
        public IWebElement RegisterNow { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.mt-1")]
        public IWebElement RegisterButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "p>label")]
        public IWebElement CheckBoxPP { get; set; }

        public void ClickGuestLoginButton()
        {
            ButtonGuest.Click();
            Thread.Sleep(4000);
        }

        
    }
}
