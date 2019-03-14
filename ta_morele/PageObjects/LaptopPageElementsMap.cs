using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ta_morele.PageObjects
{
    class LaptopPageElementsMap
    {
        private readonly IWebDriver browser;

        public LaptopPageElementsMap(IWebDriver browser)
        {
            this.browser = browser;
        }

        public IWebElement AddToCart
        {
            get
            {
                return this.browser.FindElement(By.XPath("//div[@class='cat-product card product-swipe-preview']//a[@class='btn btn-red btn-get-warranty btn-block btn-add-to-basket font-semibold']"));

            }
        }

        public IWebElement AddToCartSecond
        {
            get
            {
                return this.browser.FindElement(By.XPath("//div[@class='cat-list-products']//div[2]//div[1]//div[2]//div[2]//div[4]//a[1]"));

            }
        }
        public IWebElement OptionsOfLaptopSale
        {
            get
            {
                return this.browser.FindElement(By.XPath("//i[@class='icon-css-close']"));

            }
        }

        
    }
}
