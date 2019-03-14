using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ta_morele.PageObjects
{
    class LaptopsPage
    {
        private readonly IWebDriver browser;

        public LaptopsPage(IWebDriver browser)
        {
            this.browser = browser;
        }

        protected LaptopPageElementsMap Map
        {
            get
            {
                return new LaptopPageElementsMap(this.browser);
            }
        }

        public void AddToCartClick()
        {
            this.Map.AddToCart.Click();
        }

        public void AddSecondItemToCartClick()
        {
            this.Map.AddToCartSecond.Click();
        }

        public void OptionsOfLaptopSale()
        {
            this.Map.OptionsOfLaptopSale.Click();
        }
    }
}
