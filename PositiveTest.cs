using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using LabWork.Tests.Pages;

namespace LabWork.Tests.Tests
{
    [TestFixture]
    public class ContactFormPositiveTest
    {
        private IWebDriver driver;
        private ContactPage contactPage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            contactPage = new ContactPage(driver);
        }

        [Test]
        public void SubmitContactForm_WithValidData()
        {
            contactPage.GoToUrl("C:/Users/Vlad/Desktop/LabTeasts/Lab4/TestProjectLab4/contact.html");
            var validName = "Иван Иванов";
            var validEmail = "test@example.com";
            var validPhone = "+79991234567";
            var validMessage = "Это тестовое сообщение для проверки контактной формы.";

            contactPage.FillOutForm(validName, validEmail, validPhone, validMessage);
            contactPage.SubmitForm();

            Assert.That(contactPage.IsSuccessMessageVisible(), Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}