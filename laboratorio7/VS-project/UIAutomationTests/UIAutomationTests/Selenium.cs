using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UIAutomationTests
{
    public class Selenium
    {
        IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void Enter_To_List_Of_Countries_Test()
        {
            //Arrange
            //Abre una nueva ventana
            var URL = "http://localhost:8080/";

            //Act
            //Navega la pagina que se necesita probar
            _driver.Navigate().GoToUrl(URL);

            //Assert
            //No es un buen ejemplo de assert, use uno diferente
            Assert.IsNotNull(_driver);
        }

        [Test]
        public void Create_Country_Test()
        {
            // Arrange
            var URL = "http://localhost:8080/";
            _driver.Navigate().GoToUrl(URL);

            // Act
            var addCountryButton = _driver.FindElement(By.CssSelector("a[href='/pais'] .btn-outline-secondary"));
            addCountryButton.Click();

            Thread.Sleep(1000);

            _driver.FindElement(By.Id("name")).SendKeys("Nicaragua");
            _driver.FindElement(By.Id("continente")).SendKeys("América");
            _driver.FindElement(By.Id("idioma")).SendKeys("Español");

            var submitButton = _driver.FindElement(By.CssSelector(".btn-success"));
            submitButton.Click();

            Thread.Sleep(5000);

            // Assert
            var countryNames = _driver.FindElements(By.CssSelector("td:first-child"));
            Assert.IsTrue(countryNames.Any(name => name.Text.Contains("Nicaragua")));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}