using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace ta_morele.PageObjects
{
    class LoginPage
    {
        private readonly IWebDriver browser;
        private readonly string url = @"https://www.morele.net/";

        public LoginPage(IWebDriver browser)
        {
            this.browser = browser;
        }

        protected LoginPageElementsMap Map
        {
            get
            {
                return new LoginPageElementsMap(this.browser);
            }
        }

        public void LogInButtonClick()
        {
            this.Map.LogInButton.Click();
        }

        public bool WarningMessageExists()
        {
            return this.Map.WarningMessage.Count() > 0;
        }

        public void UserFieldSendKey(string text)
        {
            this.Map.EmailField.SendKeys(text);
        }

        public void PasswordFieldSendKey(string text)
        {
            this.Map.PasswordField.SendKeys(text);
        }

        public void LogoClick()
        {
            this.Map.Logo.Click();
        }
    }
}
