using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ta_morele.PageObjects
{
    class Helper
    {
        private readonly IWebDriver browser;

        public Helper(IWebDriver browser)
        {
            this.browser = browser;
        }

        protected HelperElementsMap Map
        {
            get
            {
                return new HelperElementsMap(this.browser);
            }
        }

        public void CookieBannerClick()
        {
            if (this.Map.CookieBannerDisp.Count() > 0)
            {
                this.Map.CookieBannerAgree.Click();
            }
        }

        public bool WarningButtonExists()
        {
            return this.Map.WarninBannerDisp.Count() > 0;
        }
    }
}
