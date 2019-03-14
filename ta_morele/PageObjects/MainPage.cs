using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace morele_ta.PageObjects
{
    class MainPage
    {
        private readonly IWebDriver browser;
        private readonly string url = @"https://www.morele.net/";

        public MainPage(IWebDriver browser)
        {
            this.browser = browser;
        }

        protected MainPageElementsMap Map
        {
            get
            {
                return new MainPageElementsMap(this.browser);
            }
        }

        public void Navigate()
        {
            this.browser.Navigate().GoToUrl(this.url);
            this.browser.Manage().Window.Maximize();
        }

        static public void ClickOnCategory(object obj, string methodName, params object[] parameters)
        {
            var objType = typeof(MainPageElementsMap);
            var method = objType.GetMethod(methodName);
            var elem = method.Invoke(obj, parameters);
            IWebElement webel = (IWebElement)elem;
            webel.Click();

        }

        public void SearchGo (string text)
        {
            this.Map.SearchField.SendKeys(text);
            this.Map.UnderCategorySearch.Click();
        }

        public void UpButtonClick()
        {
            this.Map.PageUpButton.Click();
        }

        public void CookieBannerClick()
        {
            if (this.Map.CookieBannerDisp.Count() > 0)
            {
                this.Map.CookieBannerAgree.Click();
            }
            
        }

        public void LoginButtonClick()
        {
            this.Map.LoginButton.Click();
        }

        public int NumberOfItemsInCart()
        {
            var numberOfElements = 0;
            if (this.Map.NumerOfItemsInCart.Count() > 0)
            {
                numberOfElements = int.Parse(this.Map.NumerOfItemsInCart[0].Text);

            }
            return numberOfElements;
        }

    }


}
