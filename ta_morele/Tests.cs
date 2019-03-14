using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;
using morele_ta.PageObjects;
using OpenQA.Selenium.Remote;
using ta_morele.PageObjects;

namespace morele_ta
{
    [TestClass]
    public class Tests
    {

        public RemoteWebDriver Driver { get; set; }
        static MainPage mainPage;
        static LoginPage loginPage;
        static Helper helper;
        static LaptopsPage laptopsPage;

        [TestInitialize]
        public void SetUpTest()
        {
            this.Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            mainPage = new MainPage(this.Driver);
            loginPage = new LoginPage(this.Driver);
            helper = new Helper(this.Driver);
            laptopsPage = new LaptopsPage(this.Driver);

        }

        [TestCleanup]
        public void TearDownTest()
        {
            this.Driver.Quit();
        }

        [TestMethod]
        public void GotoLaptopCategory()
        {
            mainPage.Navigate();
            var elementMap = new MainPageElementsMap(this.Driver);
            MainPage.ClickOnCategory(elementMap, "get_LaptopCategory", null);
            String actualURL = Driver.Url;
            Assert.AreEqual("https://www.morele.net/laptopy/laptopy/notebooki-laptopy-ultrabooki-31/", actualURL);

        }

        [TestMethod]
        public void SearchVerification()
        {
            mainPage.Navigate();
            mainPage.SearchGo("Laptopy");
            String actualURL = Driver.Url;
            Assert.AreEqual("https://www.morele.net/wyszukiwarka/0/0/,,,,,,,,,,,,/1/?q=Laptopy", actualURL);
        }

        [TestMethod]
        public void UpButtonVerification()
        {
            mainPage.Navigate();
            Driver.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            mainPage.CookieBannerClick();
            mainPage.UpButtonClick();
            System.Threading.Thread.Sleep(1000);
            var pageOffset =  Driver.ExecuteScript("return window.pageYOffset;");
            Assert.IsTrue((long)pageOffset == 0L);
        }

        [TestMethod]
        public void EmptyLoginFormularVer() {
            mainPage.Navigate();
            mainPage.LoginButtonClick();
            helper.CookieBannerClick();
            loginPage.LogInButtonClick();
            Assert.IsTrue(loginPage.WarningMessageExists());
        }

        [TestMethod]
        public void SendIncorrectDataToEmail()
        {
            mainPage.Navigate();
            mainPage.LoginButtonClick();
            helper.CookieBannerClick();
            loginPage.UserFieldSendKey(")@#'$%^&*");
            loginPage.LogInButtonClick();
            Assert.IsTrue(loginPage.WarningMessageExists());
        }

        [TestMethod]
            public void TryLogInWithNotExistingUser()
        {
            mainPage.Navigate();
            mainPage.LoginButtonClick();
            helper.CookieBannerClick();
            loginPage.UserFieldSendKey("notexistingmail@gmail.com");
            loginPage.PasswordFieldSendKey("12Qwerty");
            loginPage.LogInButtonClick();
            Assert.IsTrue(helper.WarningButtonExists());
        }

        [TestMethod]
        public void LogoGoHomeRedirection()
        {
            mainPage.Navigate();
            mainPage.LoginButtonClick();
            helper.CookieBannerClick();
            loginPage.LogoClick();
            String actualURL = Driver.Url;
            Assert.AreEqual("https://www.morele.net/", actualURL);
        }

        [TestMethod]
        public void AddingItemToCart() {
            mainPage.Navigate();
            var elementMap = new MainPageElementsMap(this.Driver);
            MainPage.ClickOnCategory(elementMap, "get_LaptopCategory", null);
            helper.CookieBannerClick();
            laptopsPage.AddToCartClick();
            System.Threading.Thread.Sleep(1000);
            Assert.AreEqual(1, mainPage.NumberOfItemsInCart());
        }

        [TestMethod]
        public void AddingTwoItemsToCart()
        {
            mainPage.Navigate();
            var elementMap = new MainPageElementsMap(this.Driver);
            MainPage.ClickOnCategory(elementMap, "get_LaptopCategory", null);
            helper.CookieBannerClick();
            laptopsPage.AddToCartClick();
            laptopsPage.OptionsOfLaptopSale();
            System.Threading.Thread.Sleep(1000);
            laptopsPage.AddSecondItemToCartClick();
            laptopsPage.OptionsOfLaptopSale();
            System.Threading.Thread.Sleep(1000);
            Assert.AreEqual(2, mainPage.NumberOfItemsInCart());
        }

    }
}
