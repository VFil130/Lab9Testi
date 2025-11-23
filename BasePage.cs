using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LabWork.Tests.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected void ClickElement(By locator)
        {
            Wait.Until(d => d.FindElement(locator)).Click();
        }

        protected void EnterText(By locator, string text)
        {
            var element = Wait.Until(d => d.FindElement(locator));
            element.Clear();
            element.SendKeys(text);
        }

        protected string GetElementText(By locator)
        {
            return Wait.Until(d => d.FindElement(locator)).Text;
        }

        protected bool IsElementVisible(By locator)
        {
            try
            {
                return Wait.Until(d => d.FindElement(locator)).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
    public class ContactPage : BasePage
    {
        private By NameInput => By.Id("name");
        private By EmailInput => By.Id("email");
        private By PhoneInput => By.Id("phone");
        private By MessageTextArea => By.Id("message");
        private By SubmitButton => By.CssSelector("button[type='submit']");
        private By SuccessMessage => By.Id("success-message");
        private By NameValidationError => By.Id("name-error");
        private By EmailValidationError => By.Id("email-error");
        private By PhoneValidationError => By.Id("phone-error");
        private By MessageValidationError => By.Id("message-error");

        public ContactPage(IWebDriver driver) : base(driver) { }

        public void GoToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void FillOutForm(string name, string email, string phone, string message)
        {
            EnterText(NameInput, name);
            EnterText(EmailInput, email);
            EnterText(PhoneInput, phone);
            EnterText(MessageTextArea, message);
        }

        public void SubmitForm()
        {
            ClickElement(SubmitButton);
        }

        public string GetSuccessMessage()
        {
            return GetElementText(SuccessMessage);
        }

        public string GetNameValidationError()
        {
            return GetElementText(NameValidationError);
        }

        public string GetEmailValidationError()
        {
            return GetElementText(EmailValidationError);
        }

        public bool IsSuccessMessageVisible()
        {
            return IsElementVisible(SuccessMessage);
        }

        public bool IsNameErrorVisible()
        {
            return IsElementVisible(NameValidationError);
        }

        public void SubmitFormWithEmptyName(string email, string phone, string message)
        {
            EnterText(EmailInput, email);
            EnterText(PhoneInput, phone);
            EnterText(MessageTextArea, message);
            SubmitForm();
        }
    }
}