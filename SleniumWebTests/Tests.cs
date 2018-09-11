using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SleniumWebTests;
using SleniumWebTests.ChallangesPageObject;
using SleniumWebTests.LobbyPageObject;
using SleniumWebTests.LoginPageObject;
using SleniumWebTests.ProfilePageObject;
using SleniumWebTests.SkillGamePageObject;
using SleniumWebTests.TournamentsPageObject;
using SleniumWebTests.WorldPageObject;
using System;
using System.Linq;
using System.Threading;
class Tests
{

    static void Main()
    {
    }
    [SetUp]
    public void Initialize()
    {
        var options = new ChromeOptions();
        options.AddArgument("mute-audio");
        PropertiesCollection.driver = new ChromeDriver(options);
        string url = "http://172.16.45.50:9001/#/login";
        PropertiesCollection.driver.Manage().Window.Maximize();
        PropertiesCollection.driver.Navigate().GoToUrl(url);
        System.Threading.Thread.Sleep(5000);
        Console.WriteLine("Initialize");
    }
    [Test]
    public void Login()
    {
        LoginPageObject page = new LoginPageObject();
        System.Threading.Thread.Sleep(2000);
        page.Username.SendKeys("com@yopmail.com");
        page.Password.SendKeys("com@yopmail.com1");
        WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(10));
        wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button.mt-sm-1")));
        if (page.ButtonLogin.Enabled)
        {
            page.ButtonLogin.Click();
            System.Threading.Thread.Sleep(5000);
            Assert.AreEqual(@"http://172.16.45.50:9001/#/lobby", PropertiesCollection.driver.Url);
        }
        else
        {
            throw new ArgumentException("Button is unavaliable");
        }
        System.Threading.Thread.Sleep(4000);
    }
    [TearDown]
    public void CleanUp()
    {
        PropertiesCollection.driver.Close();
        Console.WriteLine("CleanUp");
    }
    [Test]
    public void LoginAsGuest()
    {
        LoginPageObject page = new LoginPageObject();
        WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(10));
        wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button.guest")));
        //SeleniumSetMethods.WaitUntilBeClickable(page.Guest.ToString(), "CssSelector");
        page.ButtonGuest.Click();
        Thread.Sleep(4000);
        Assert.AreEqual(@"http://172.16.45.50:9001/#/lobby", PropertiesCollection.driver.Url);
        Thread.Sleep(4000);

    }
    [Test]
    public void ForgotPassword()
    {
        LoginPageObject page = new LoginPageObject();

        page.ForgotPassword.Click();
        page.SendEmail.SendKeys("com@yopmail.com");
        WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(10));
        wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button.custom-btn")));
        page.ButtonOK.Click();
        Thread.Sleep(4000);
        PropertiesCollection.driver.SwitchTo().ActiveElement();
        string expectedMessage = "THANKS!";
        string message = PropertiesCollection.driver.FindElement(By.CssSelector("div>mat-card-title")).Text;
        Assert.AreEqual(expectedMessage, message);
        page.ButtonOK.Click();
        System.Threading.Thread.Sleep(4000);
    }
    [Test]
    public void RegisterNow()
    {
        LoginPageObject page = new LoginPageObject();

        page.RegisterNow.Click();
        PropertiesCollection.driver.SwitchTo().ActiveElement();
        page.Username.SendKeys("com@yopmail.com");
        page.Password.SendKeys("com@yopmail.com1");
        WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(10));
        wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button.mt-1")));
        page.RegisterButton.Click();
        Thread.Sleep(8000);
        Assert.AreEqual(@"http://172.16.45.50:9001/#/lobby", PropertiesCollection.driver.Url);
    }
    [Test]
    public void UncheckPP()
    {
        LoginPageObject page = new LoginPageObject();
        page.CheckBoxPP.Click();
        var disabledButton = page.ButtonGuest.GetAttribute("disabled");
        if (disabledButton == null)
        {
            throw new ArgumentException("Button is avaliable");
        }

    }
    [Test]
    public void LoginAsGuestAndCollectBonus()
    {
        LoginPageObject login = new LoginPageObject();

        Thread.Sleep(3000);
        WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(10));
        wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button.guest")));
        login.ButtonGuest.Click();
        Thread.Sleep(10000);
        Assert.AreEqual(@"http://172.16.45.50:9001/#/lobby", PropertiesCollection.driver.Url);
        Thread.Sleep(4000);
        PropertiesCollection.driver.Navigate().Refresh();
        Thread.Sleep(8000);
        LobbyPageObject LobbyPage = new LobbyPageObject();
        var balanceCoinsBefore = LobbyPage.BalanceCoins.Text;
        decimal cBalBefore = 0;
        bool bb = Decimal.TryParse(balanceCoinsBefore, out cBalBefore);
        LobbyPage.Notifications.Click();
        LobbyPage.BonusItem.Click();
        Thread.Sleep(2000);
        PropertiesCollection.driver.SwitchTo().ActiveElement();
        Thread.Sleep(4000);
        LobbyPage.ButtonCollect.Click();
        Thread.Sleep(4000);
        var balanceAfterCollect = LobbyPage.BalanceCoins.Text;
        decimal cBalAfter = 0;
        bool ba = Decimal.TryParse(balanceAfterCollect, out cBalAfter);
        Thread.Sleep(4000);
        if (cBalBefore < cBalAfter)
        {
            Console.WriteLine("Balance compared, Everything OK");
        }
        if (cBalBefore > cBalAfter)
        {
            throw new ArgumentException("Balance before less than after");
        }
        Thread.Sleep(3000);
    }
    [Test]
    public void LoginStartGame()
    {
        LoginPageObject LoginPage = new LoginPageObject();
        WorldPageObject world = new WorldPageObject();
        WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(10));
        LoginPage.Username.SendKeys("com@yopmail.com");
        LoginPage.Password.SendKeys("com@yopmail.com1");
        wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button.mt-sm-1")));
        LoginPage.ButtonLogin.Click();
        Thread.Sleep(4000);
        Assert.AreEqual(@"http://172.16.45.50:9001/#/lobby", PropertiesCollection.driver.Url);
        Thread.Sleep(2000);
        LobbyPageObject LobbyPage = new LobbyPageObject();
        //PropertiesCollection.driver.SwitchTo().ActiveElement();
        //Thread.Sleep(4000);
        //LobbyPage.ButtonCollect.Click();
        Thread.Sleep(4000);
        LobbyPage.ButtonWorld.Click();
        Thread.Sleep(4000);
        world.Paris.Click();
        PropertiesCollection.driver.SwitchTo().ActiveElement();
        Thread.Sleep(2000);
        world.FirstCasino.Click();
        Thread.Sleep(4000);
        LobbyPage.ThirdGame.Click();
        Thread.Sleep(4000);
    }
    [Test]
    public void VerifyMainMenuButtons()
    {
        LoginPageObject LoginPage = new LoginPageObject();
        WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(10));
        WaitClass.WaitForElementMethod(LoginPage.ButtonGuest);
        LoginPage.ClickGuestLoginButton();
        Assert.AreEqual(@"http://172.16.45.50:9001/#/lobby", PropertiesCollection.driver.Url);
        Thread.Sleep(2000);
        LobbyPageObject LobbyPage = new LobbyPageObject();
        PropertiesCollection.driver.SwitchTo().ActiveElement();
        Thread.Sleep(4000);
        LobbyPage.ButtonCollect.Click();
        Thread.Sleep(4000);
        LobbyPage.ButtonWorld.Click();
        Thread.Sleep(3000);
        Assert.AreEqual(@"http://172.16.45.50:9001/#/world", PropertiesCollection.driver.Url);
        wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("li:nth-child(1)>div>div>div.info-block>p.title")));
        wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.back.ng-star-inserted")));
        LobbyPage.BackButton.Click();
        Thread.Sleep(3000);
        LobbyPage.ButtonSkillGames.Click();
        Thread.Sleep(3000);
        Assert.AreEqual(@"http://172.16.45.50:9001/#/skillgames", PropertiesCollection.driver.Url);
        var skillheader = PropertiesCollection.driver.FindElement(By.CssSelector("div>h2")).Text;
        Assert.AreEqual("SKILL GAMES", skillheader);
        LobbyPage.BackButton.Click();
        Thread.Sleep(3000);
        LobbyPage.MyProfile.Click();
        Thread.Sleep(3000);
        Assert.AreEqual(@"http://172.16.45.50:9001/#/profile", PropertiesCollection.driver.Url);
        var profileheader = PropertiesCollection.driver.FindElement(By.CssSelector("div>h2")).Text;
        Assert.AreEqual("PROFILE", profileheader);
        LobbyPage.BackButton.Click();
        Thread.Sleep(3000);
        LobbyPage.Promotions.Click();
        Thread.Sleep(3000);
        Assert.AreEqual(@"http://172.16.45.50:9001/#/promotions", PropertiesCollection.driver.Url);
        var promotionheader = PropertiesCollection.driver.FindElement(By.CssSelector("div>h2")).Text;
        Assert.AreEqual("PROMOTIONS", promotionheader);
        LobbyPage.BackButton.Click();
        Thread.Sleep(3000);
        LobbyPage.LeaderBoard.Click();
        Thread.Sleep(3000);
        Assert.AreEqual(@"http://172.16.45.50:9001/#/leaderboard", PropertiesCollection.driver.Url);
        var leaderheader = PropertiesCollection.driver.FindElement(By.CssSelector("div>h2")).Text;
        Assert.AreEqual("LEADERBOARD", leaderheader);
        LobbyPage.BackButton.Click();
        Thread.Sleep(3000);
        LobbyPage.Tournaments.Click();
        Thread.Sleep(3000);
        Assert.AreEqual(@"http://172.16.45.50:9001/#/tournaments", PropertiesCollection.driver.Url);
        var tournamentsheader = PropertiesCollection.driver.FindElement(By.CssSelector("div>h2")).Text;
        Assert.AreEqual("TOURNAMENTS", tournamentsheader);
        LobbyPage.BackButton.Click();
        Thread.Sleep(3000);
        LobbyPage.Challenges.Click();
        Thread.Sleep(3000);
        Assert.AreEqual(@"http://172.16.45.50:9001/#/challenges", PropertiesCollection.driver.Url);
        var challengesheader = PropertiesCollection.driver.FindElement(By.CssSelector("div>h2")).Text;
        Assert.AreEqual("CHALLENGES", challengesheader);
        Thread.Sleep(4000);
        LobbyPage.SettingsButton.Click();
        PropertiesCollection.driver.SwitchTo().ActiveElement();
        LobbyPage.LogoutButton.Click();
        Thread.Sleep(3000);
        wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button.guest")));
        Assert.AreEqual(@"http://172.16.45.50:9001/#/login", PropertiesCollection.driver.Url);
        Thread.Sleep(4000);
    }
    [Test]
    public void LoginAsGuestAndRegister()
    {
        LoginPageObject LoginPage = new LoginPageObject();
        LobbyPageObject LobbyPage = new LobbyPageObject();
        ProfilePageObject ProfilePage = new ProfilePageObject();
        WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(10));
        wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button.guest")));
        LoginPage.ButtonGuest.Click();
        Thread.Sleep(4000);
        Assert.AreEqual(@"http://172.16.45.50:9001/#/lobby", PropertiesCollection.driver.Url);
        Thread.Sleep(4000);
        PropertiesCollection.driver.SwitchTo().ActiveElement();
        LobbyPage.ButtonCollect.Click();
        Thread.Sleep(2000);
        LobbyPage.MyProfile.Click();
        Thread.Sleep(2000);
        ProfilePage.Register.Click();
        Thread.Sleep(2000);
        PropertiesCollection.driver.SwitchTo().ActiveElement();
        ProfilePage.Username.SendKeys("com@yopmail.com");
        Thread.Sleep(2000);
        ProfilePage.Password.SendKeys("com@yopmail.com1");
        Thread.Sleep(2000);
        WaitClass.WaitForElementMethod(ProfilePage.RegisterButton);
        ProfilePage.RegisterButton.Click();
        Thread.Sleep(3000);
        WaitClass.WaitForElementMethod(LobbyPage.ButtonCollect);
        Thread.Sleep(3000);
        LobbyPage.ButtonCollect.Click();
        Thread.Sleep(3000);
        WaitClass.WaitForElementMethod(ProfilePage.ResendEmailButton);
        ProfilePage.ResendEmailButton.Click();
        Thread.Sleep(3000);
        PropertiesCollection.driver.SwitchTo().ActiveElement();
        string expectedMessage = "THANKS!";
        string message = PropertiesCollection.driver.FindElement(By.CssSelector("div>mat-card-title")).Text;
        Assert.AreEqual(expectedMessage, message);
        ProfilePage.ButtonOKResendEmail.Click();
    }
    [Test]
    public void LoginVerifySkillGames()
    {
        LoginPageObject page = new LoginPageObject();
        LobbyPageObject lobby = new LobbyPageObject();
        SkillGamePageObject skillPage = new SkillGamePageObject();
        WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(10));
        page.Username.SendKeys("com@yopmail.com");
        page.Password.SendKeys("com@yopmail.com1");
        wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button.mt-sm-1")));
        page.ButtonLogin.Click();
        Thread.Sleep(6000);
        Assert.AreEqual(@"http://172.16.45.50:9001/#/lobby", PropertiesCollection.driver.Url);
        Thread.Sleep(4000);
        wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("li:nth-child(2)>div>div>i")));
        lobby.ButtonSkillGames.Click();
        Thread.Sleep(2000);
        for (int i = 1; i < 4; i++)
        {
            int[] gamesId = { 100661, 100663, 100667, 100662, 100666 };

            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector($"div.owl-stage-outer>div>div:nth-child({i})>div>div:nth-child(1)>div>button")));
            PropertiesCollection.driver.FindElement(By.CssSelector($"div.owl-stage-outer>div>div:nth-child({i})>div>div:nth-child(1)>div>button")).Click();
            int gameID = gamesId[i - 1];
            Thread.Sleep(3000);
            Assert.AreEqual($"http://172.16.45.50:9001/#/games/{gameID}", PropertiesCollection.driver.Url);
            skillPage.BackButton.Click();

        }
        for (int i = 1; i < 3; i++)
        {
            int[] gamesId = { 100661, 100663, 100667, 100662, 100666 };

            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector($"div.owl-stage-outer>div>div:nth-child({i})>div>div:nth-child(2)>div>button")));
            PropertiesCollection.driver.FindElement(By.CssSelector($"div.owl-stage-outer>div>div:nth-child({i})>div>div:nth-child(2)>div>button")).Click();
            int gameID = gamesId[i + 2];
            Thread.Sleep(3000);
            Assert.AreEqual($"http://172.16.45.50:9001/#/games/{gameID}", PropertiesCollection.driver.Url);
            skillPage.BackButton.Click();
        }
    }
    [Test]
    public void LoginAndCreateNewChallange()
    {
        LoginPageObject page = new LoginPageObject();
        LobbyPageObject lobby = new LobbyPageObject();
        ChallangesPageObject challanges = new ChallangesPageObject();
        page.Username.SendKeys("com@yopmail.com");
        page.Password.SendKeys("com@yopmail.com1");
        WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(10));
        wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button.mt-sm-1")));
        page.ButtonLogin.Click();
        Thread.Sleep(4000);
        Assert.AreEqual(@"http://172.16.45.50:9001/#/lobby", PropertiesCollection.driver.Url);
        //Thread.Sleep(3000);
        //PropertiesCollection.driver.FindElement(By.CssSelector("app-modal-daily-bonus>div>mat-card>mat-card-content")).Click();
        //lobby.ButtonCollect.Click();
        Thread.Sleep(4000);
        lobby.Challenges.Click();
        Thread.Sleep(2000);
        challanges.NewChallangeButton.Click();
        Thread.Sleep(2000);
        challanges.FirstGameInChallangeList.Click();
        Thread.Sleep(2000);
        challanges.SecondGameInChallangeList.Click();
        string gameNameSelected = PropertiesCollection.driver.FindElement(By.CssSelector("div.game-block>p.game-title")).Text;
        challanges.CreateChallangeButton.Click();
        Thread.Sleep(4000);
        string gameNameInChallange = PropertiesCollection.driver.FindElement(By.CssSelector("h5.name")).Text;
        Assert.AreEqual(gameNameSelected, gameNameInChallange.ToUpper());
        challanges.BackButton.Click();
        Thread.Sleep(3000);
        string gameNameInChalangesBlock = PropertiesCollection.driver.FindElement(By.CssSelector("div.header-block>p")).Text;
        Assert.AreEqual(gameNameSelected, gameNameInChalangesBlock);
    }
   
    [Test]
    public void LoginEditProfile()
    {
        LoginPageObject page = new LoginPageObject();
        ProfilePageObject profile = new ProfilePageObject();
        LobbyPageObject lobby = new LobbyPageObject();
        System.Threading.Thread.Sleep(2000);
        page.Username.SendKeys("com@yopmail.com");
        page.Password.SendKeys("com@yopmail.com1");
        WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(10));
        wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button.mt-sm-1")));
        if (page.ButtonLogin.Enabled)
        {
            page.ButtonLogin.Click();
            System.Threading.Thread.Sleep(5000);
            Assert.AreEqual(@"http://172.16.45.50:9001/#/lobby", PropertiesCollection.driver.Url);
        }
        else
        {
            throw new ArgumentException("Button is unavaliable");
        }
        System.Threading.Thread.Sleep(4000);
        lobby.MyProfile.Click();
        Thread.Sleep(2000);
        profile.ButtonEditProfile.Click();
        Thread.Sleep(2000);
        profile.NickNameField.Clear();
        profile.NickNameField.SendKeys("SomeNewNick");
        PropertiesCollection.driver.FindElement(By.CssSelector("#item-select>div>div.wrap.text-left.item-selected>div>i")).Click();
        Thread.Sleep(2000);
        PropertiesCollection.driver.FindElement(By.CssSelector("#item-select>div>div:nth-child(4)>span")).Click();
        Thread.Sleep(2000);
        WaitClass.WaitForElementMethod(profile.EditProfileSaveBtn);
        profile.EditProfileSaveBtn.Click();
        Thread.Sleep(4000);
    }

    [Test]
    public void LoginAddNewFriend()
    {
        LoginPageObject page = new LoginPageObject();
        LobbyPageObject lobby = new LobbyPageObject();
        ProfilePageObject profile = new ProfilePageObject();
        System.Threading.Thread.Sleep(2000);
        page.Username.SendKeys("com@yopmail.com");
        page.Password.SendKeys("com@yopmail.com1");
        WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(10));
        wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button.mt-sm-1")));
        if (page.ButtonLogin.Enabled)
        {
            page.ButtonLogin.Click();
            System.Threading.Thread.Sleep(5000);
            Assert.AreEqual(@"http://172.16.45.50:9001/#/lobby", PropertiesCollection.driver.Url);
        }
        else
        {
            throw new ArgumentException("Button is unavaliable");
        }
        System.Threading.Thread.Sleep(2000);
        lobby.MyProfile.Click();
        Thread.Sleep(2000);
        wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div:nth-child(2)>div>div.glass-button.text-uppercase.d-flex.flex-column>span:nth-child(2)")));
        profile.AddFriend.Click();
        Thread.Sleep(2000);
        profile.SearchFriends.SendKeys("Guest");

        var element = PropertiesCollection.driver.FindElements(By.CssSelector("div.friends-list-container>perfect-scrollbar")).FirstOrDefault();
        element.Click();
        Thread.Sleep(2000);
        profile.AddSelectedFriend.Click();
        profile.FriendsRequest.Click();
        Thread.Sleep(2000);
        profile.DeclineFriendRequest.Click();
        Thread.Sleep(2000);
        profile.AreYouSureCancelFriendRequestYes.Click();
        Thread.Sleep(4000);
    }
    [Test]
    public void LoginPlayDevGame()
    {
        LoginPageObject LoginPage = new LoginPageObject();
        WorldPageObject world = new WorldPageObject();
        WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(10));
        LoginPage.Username.SendKeys("com@yopmail.com");
        LoginPage.Password.SendKeys("com@yopmail.com1");
        wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button.mt-sm-1")));
        LoginPage.ButtonLogin.Click();
        Thread.Sleep(4000);
        Assert.AreEqual(@"http://172.16.45.50:9001/#/lobby", PropertiesCollection.driver.Url);
        Thread.Sleep(2000);
        LobbyPageObject LobbyPage = new LobbyPageObject();
        //PropertiesCollection.driver.SwitchTo().ActiveElement();
        //Thread.Sleep(4000);
        //LobbyPage.ButtonCollect.Click();
        Thread.Sleep(3000);
        LobbyPage.ButtonWorld.Click();
        Thread.Sleep(3000);
        world.Paris.Click();
        PropertiesCollection.driver.SwitchTo().ActiveElement();
        Thread.Sleep(2000);
        world.FirstCasino.Click();
        Thread.Sleep(3000);
        world.DevGame.Click();
        Thread.Sleep(3000);

        var balanceCoinsBefore = LobbyPage.BalanceCoins.Text;
        decimal coinsBalBefore = 0;
        bool balancebefore = Decimal.TryParse(balanceCoinsBefore, out coinsBalBefore);
        PropertiesCollection.driver.SwitchTo().Frame(0);
        var selectList = PropertiesCollection.driver.FindElement(By.CssSelector("select#betValue.game__bet-selector"));
        SelectElement SelectDropdown = new SelectElement(selectList);
        SelectDropdown.SelectByValue("1400");
        Thread.Sleep(2000);
        world.DoBet.Click();
        Thread.Sleep(3000);
        PropertiesCollection.driver.SwitchTo().ParentFrame();
        var balanceCoinsBet = LobbyPage.BalanceCoins.Text;
        decimal balanceBet = 0;
        bool balBet = Decimal.TryParse(balanceCoinsBet, out balanceBet);
        if (coinsBalBefore - 1400 != balanceBet)
        {
            throw new Exception("Balance does not Change");
        }
        PropertiesCollection.driver.SwitchTo().Frame(0);
        world.MakeWin.Click();
        Thread.Sleep(3000);
        PropertiesCollection.driver.SwitchTo().ParentFrame();
        var balanceCoinsWin = LobbyPage.BalanceCoins.Text;
        decimal balanceWin = 0;
        bool bWin = Decimal.TryParse(balanceCoinsWin, out balanceWin);
        if (balanceBet != balanceWin - 5000)
        {
            throw new Exception("Balance does not Change");
        }
        Thread.Sleep(4000);
    }

    [Test]
    public void VerifyLevelUp()
    {
        LoginPageObject LoginPage = new LoginPageObject();
        WorldPageObject world = new WorldPageObject();
        WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(10));
        LoginPage.Username.SendKeys("com@yopmail.com");
        LoginPage.Password.SendKeys("com@yopmail.com1");
        wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button.mt-sm-1")));
        LoginPage.ButtonLogin.Click();
        Thread.Sleep(4000);
        Assert.AreEqual(@"http://172.16.45.50:9001/#/lobby", PropertiesCollection.driver.Url);
        Thread.Sleep(2000);
        LobbyPageObject LobbyPage = new LobbyPageObject();
        PropertiesCollection.driver.SwitchTo().ActiveElement();
        Thread.Sleep(4000);
        LobbyPage.ButtonCollect.Click();
        Thread.Sleep(3000);
        LobbyPage.ButtonWorld.Click();
        Thread.Sleep(3000);
        world.Paris.Click();
        PropertiesCollection.driver.SwitchTo().ActiveElement();
        Thread.Sleep(2000);
        world.FirstCasino.Click();
        Thread.Sleep(3000);
        world.DevGame.Click();
        Thread.Sleep(3000);

        var Level = world.Level.Text;
        decimal levelBefore = 0;
        bool balancebefore = Decimal.TryParse(Level, out levelBefore);
        PropertiesCollection.driver.SwitchTo().Frame(0);
        var selectList = PropertiesCollection.driver.FindElement(By.CssSelector("select#betValue.game__bet-selector"));
        SelectElement SelectDropdown = new SelectElement(selectList);
        SelectDropdown.SelectByValue("1400");
        Thread.Sleep(2000);
        world.DoBet.Click();
        Thread.Sleep(3000);
        world.DoBet.Click();
        Thread.Sleep(3000);
        PropertiesCollection.driver.SwitchTo().ParentFrame();
        var LevelAfter = world.Level.Text;
        decimal levelAfter = 0;
        bool balanceAfter = Decimal.TryParse(LevelAfter, out levelAfter);
        if (levelBefore == levelAfter)
        {
            throw new Exception("Level does not change");
        }

        Thread.Sleep(3000);
    }

    [Test]
    public void PlayTournament()
    {
        LoginPageObject LoginPage = new LoginPageObject();
        WorldPageObject world = new WorldPageObject();
        TournamentsPageObject tournaments = new TournamentsPageObject();
        WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(60));
        LoginPage.Username.SendKeys("com@yopmail.com");
        LoginPage.Password.SendKeys("com@yopmail.com1");
        wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button.mt-sm-1")));
        LoginPage.ButtonLogin.Click();
        Thread.Sleep(4000);
        Assert.AreEqual(@"http://172.16.45.50:9001/#/lobby", PropertiesCollection.driver.Url);
        Thread.Sleep(2000);
        LobbyPageObject LobbyPage = new LobbyPageObject();
        LobbyPage.Tournaments.Click();
        Thread.Sleep(4000);
        var GemsBefore = tournaments.BalanceGems.Text;
        decimal gemsBefore = 0;
        bool gemsres = Decimal.TryParse(GemsBefore, out gemsBefore);
        int avTours = PropertiesCollection.driver.FindElements(By.CssSelector("h5.name")).Count;
        for (int i = 1; i <= avTours; i++)
        {
            var t = PropertiesCollection.driver.FindElement(By.CssSelector($"div:nth-child({i})>div>div>h5")).Text;
            bool res = t.Equals("UNSTOPPABLE TOUR");
            if (res == true )
            {
                PropertiesCollection.driver.FindElement(By.CssSelector($"div>div:nth-child({i})>div>div>button>span")).Click();
                break;
            } 
        }
        Thread.Sleep(3000);
        PropertiesCollection.driver.SwitchTo().Frame(0);
        tournaments.MakeWin.Click();
        PropertiesCollection.driver.SwitchTo().ParentFrame();
        wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button.collect-button")));
        tournaments.ButtonCollect.Click();
        Thread.Sleep(4000);
        tournaments.AfterWinTournamentOK.Click();
        var GemsAfter = tournaments.BalanceGems.Text;
        decimal gemsAfter = 0;
        bool gemsparse = Decimal.TryParse(GemsAfter, out gemsAfter);
        if (gemsBefore == gemsAfter)
        {
            throw new Exception("Gems does not change");
        }
        Thread.Sleep(4000);

    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            