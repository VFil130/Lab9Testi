using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using LabWork.Tests.Pages;

namespace LabWork.Tests.Tests
{
    [TestFixture]
    public class ContactFormNegativeTest
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
        public void SubmitContactForm_WithEmptyNameField()
        {
            contactPage.GoToUrl("C:/Users/Vlad/Desktop/LabTeasts/Lab4/TestProjectLab4/contact.html");
            var validEmail = "test@example.com";
            var validPhone = "+79991234567";
            var validMessage = "Это тестовое сообщение, но имя не заполнено.";

            contactPage.SubmitFormWithEmptyName(validEmail, validPhone, validMessage);

            Assert.That(contactPage.IsNameErrorVisible(), Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}