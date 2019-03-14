using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace ta_morele.PageObjects
{
    class LoginPageElementsMap
    {
        private readonly IWebDriver browser;

        public LoginPageElementsMap(IWebDriver browser)
        {
            this.browser = browser;
        }

        public IWebElement LogInButton
        {
            get
            {
                return this.browser.FindElement(By.XPath("//button[contains(text(),'Zaloguj się')]"));
            }
        }

        public ReadOnlyCollection<IWebElement> WarningMessage
        {
            get
            {
                return this.browser.FindElements(By.XPath("//div[@class='form-control-error']"));
            }
        }

        public IWebElement EmailField
        {
            get
            {
                return this.browser.FindElement(By.XPath("//input[@id='username']"));
            }
        }

        public IWebElement PasswordField
        {
            get
            {
                return this.browser.FindElement(By.XPath("//input[@name='_password']"));
            }
        }

        public IWebElement Logo
        {
            get
            {
                return this.browser.FindElement(By.XPath("//img[@src='/assets/src/images/store_identifiers/img-logo-morele.svg']"));
            }
        }
    }
}
