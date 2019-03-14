using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace morele_ta.PageObjects
{
    class MainPageElementsMap
    {
        private readonly IWebDriver browser;

        public MainPageElementsMap(IWebDriver browser)
        {
            this.browser = browser;
        }

        public IWebElement LaptopCategory
        {
            get
            {
                return this.browser.FindElement(By.XPath("//span[contains(text(),'Laptopy')]"));
            }
        }

        public IWebElement SearchField
        {
            get
            {
                return this.browser.FindElement(By.XPath("//div[@class='h-quick-search']//input[@placeholder='szukaj np. Samsung Galaxy S9']"));
            }


        }

        public IWebElement UnderCategorySearch
        {
            get
            {
                return this.browser.FindElement(By.XPath("//div[contains(@class,'ma-result-item ma-item-active')]"));
                
            }
        }

        public IWebElement PageUpButton
        {
            get
            {
                return this.browser.FindElement(By.XPath("//button[@type='button']//i[@class='icon-arrow-right-circle']"));
            }
        }

        public ReadOnlyCollection<IWebElement> CookieBannerDisp
        {
            get
            {
                return this.browser.FindElements(By.XPath("//div[@class='cookie-box-container']"));
            }
        }

        public IWebElement CookieBannerAgree
        {
            get
            {
                return this.browser.FindElement(By.XPath("//button[contains(text(),'Zgadzam się')]"));
                
            }
        }

        public IWebElement LoginButton
        {
            get
            {
                return this.browser.FindElement(By.XPath("//span[contains(text(),'Zaloguj się')]"));
            }
        }

        public ReadOnlyCollection<IWebElement> NumerOfItemsInCart
        {
            get
            {
                return this.browser.FindElements(By.XPath("//span[@class='icon-basket-count small-basket-count']"));
                
            }
        }


    }
}
