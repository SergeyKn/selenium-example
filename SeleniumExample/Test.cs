using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using Xunit;

namespace SeleniumExample
{
    public class Test
    {
        [Fact]
        public void TestMehod()
        {
            var credentials = JsonConvert.DeserializeObject<Credentials>(File.ReadAllText(@"d:\credentials.json"));

            IWebDriver driver = new ChromeDriver();
            var account = new Account(driver, credentials);
            account.Login();
            account.Pay("Electricity", "", "Test", "0");
        }
    }
}
