using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleniumWebTests.ProfilePageObject
{
    public class ProfilePageObject
    {
        public ProfilePageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "button.custom-btn.custom-btn-sm.mb-1.mt-2")]
        public IWebElement Register { get; set; }

        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement Username { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.mt-0")]
        public IWebElement RegisterButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.custom-btn-sm.mb-2.mt-1")]
        public IWebElement ResendEmailButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "mat-card-footer>button.custom-btn")]
        public IWebElement ButtonOKResendEmail { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.btn-style-5.custom-btn-sm.mb-2")]
        public IWebElement ButtonEditProfile { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.formData-name.mt-2.pb-3>input")]
        public IWebElement NickNameField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.custom-btn.edit-profile__btn")]
        public IWebElement EditProfileSaveBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.custom-btn.edit-profile__btn")]
        public IWebElement Gender { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div:nth-child(2)>div>div.glass-button.text-uppercase.d-flex.flex-column>span:nth-child(2)")]
        public IWebElement AddFriend { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.col.search-col>input")]
        public IWebElement SearchFriends { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.additional-info.mt-1>div>button")]
        public IWebElement AddSelectedFriend { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.board-header.d-flex.justify-content-start>div>div:nth-child(3)")]
        public IWebElement FriendsRequest { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.d-flex.justify-content-center>button")]
        public IWebElement DeclineFriendRequest { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.ml-5.btn-style-3")]
        public IWebElement AreYouSureCancelFriendRequestYes { get; set; }
    }
}

