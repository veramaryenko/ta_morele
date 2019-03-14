using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ta_morele.PageObjects
{
    class HelperElementsMap
    {
        private readonly IWebDriver browser;

        public HelperElementsMap(IWebDriver browser)
        {
            this.browser = browser;
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

        public ReadOnlyCollection<IWebElement> WarninBannerDisp
        {
            get
            {
                return this.browser.FindElements(By.XPath("//div[@class='mn-item mn-type-danger mn-item-push']"));
            }
        }
    }
}
