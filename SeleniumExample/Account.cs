using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumExample
{
    class Account
    {
        private readonly IWebDriver driver;
        private readonly string name;
        private readonly string accountId;
        private readonly string customerId;
        private readonly string password;

        public Account(IWebDriver driver, Credentials credentials)
        {
            this.driver = driver;
            name = credentials.Name;
            accountId = credentials.AccountId;
            customerId = credentials.CustomerId;
            password = credentials.Password;
        }

        public void Login()
        {
            driver.Url = "https://banking.westpac.com.au/wbc/banking/handler?TAM_OP=login&segment=personal&logout=false";

            IWebElement user = driver.FindElement(By.Id("fakeusername"));
            user.SendKeys(customerId);

            IWebElement passwordElement = driver.FindElement(By.Id("password"));
            passwordElement.SendKeys(password);

            IWebElement loginButton = driver.FindElement(By.Id("signin"));
            loginButton.Click();
        }

        public void Pay(string payee, string reference, string description, string amount)
        {
            driver.Url = "https://banking.westpac.com.au/secure/banking/overview/payments/paysomeone";

            IWebElement payeeName = driver.FindElement(By.Id("Form_PayeeName"));
            payeeName.SendKeys(payee);
            payeeName.SendKeys(Keys.Return);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            IWebElement payeeReference = wait.Until(d => d.FindElement(By.Id("Form_PayeeReference")));
            payeeReference.SendKeys(reference);

            IWebElement payeeDescription = driver.FindElement(By.Id("Form_PayeeDescription"));
            payeeDescription.SendKeys(description);


            //Form_FromAccountId            

            IWebElement payerName = driver.FindElement(By.Id("Form_PayerName"));
            payerName.SendKeys(name);

            IWebElement payerDescription = driver.FindElement(By.Id("Form_PayerDescription"));
            payerDescription.SendKeys(description);

            IWebElement amountToPay = driver.FindElement(By.Id("Form_Amount"));
            amountToPay.SendKeys(amount);

            IWebElement submit = driver.FindElement(By.XPath(".//*[@type='submit"));
            submit.Click();
        }
    }
}
