using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

public class SeleniumTests : IDisposable
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;
    private const string BaseUrl = "https://localhost:7263";

    public SeleniumTests()
    {
        var options = new ChromeOptions();
        options.AddArgument("--ignore-certificate-errors");
        options.AddArgument("--allow-insecure-localhost");
        options.AddArgument("--headless"); 

        _driver = new ChromeDriver(options);
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
    }

    [Fact]
    public void Login_And_Scrape_Products()
    {
        _driver.Navigate().GoToUrl($"{BaseUrl}/login");

        var loginInput = _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input[placeholder='Логін']")));
        var passwordInput = _driver.FindElement(By.CssSelector("input[placeholder='Пароль']"));

        loginInput.SendKeys("admin");
        passwordInput.SendKeys("1234");

        // Клікаємо на кнопку Увійти
        var btn = _driver.FindElement(By.XPath("//button[contains(text(), 'Увійти')]"));
        btn.Click();

        // Чекаємо переходу
        _wait.Until(d => d.Url.Contains("/profile") || d.Url == $"{BaseUrl}/");

        // Йдемо на головну
        _driver.Navigate().GoToUrl($"{BaseUrl}/");

        // Перевіряємо картки
        var cards = _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.ClassName("card")));
        Assert.NotEmpty(cards);
    }

    public void Dispose()
    {
        _driver?.Quit();
        _driver?.Dispose();
    }
}