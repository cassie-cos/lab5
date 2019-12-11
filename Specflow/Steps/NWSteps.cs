using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumBasicsDemo;
using System;
using TechTalk.SpecFlow;

namespace SpecflowTests.Steps
{
    [Binding]
    public class NWSteps
    {
        private IWebDriver driver;

        [Given(@"I open ""(.*)"" url")]
        public void GivenIOpenUrl(string url)
        {
            driver = new ChromeDriver();
            driver.Url = url;
        }
        
        [When(@"I login with ""(.*)"" username and ""(.*)"" password")]
        public void WhenILoginWithUsernameAndPassword(string login, string password)
        {
            new LoginPage(driver).Login(login, password);
        }
        
        [Then(@"Login is successfull")]
        public void ThenLoginIsSuccessfull()
        {
            Assert.IsTrue(new MainPage(driver).isLoginSuccessfull(), "Login failed");
        }

        [When(@"I click All Product link")]
        public void WhenIClickAllProductLink()
        {
            driver.FindElement(By.LinkText("All Products")).Click();
        }

        [Then(@"Open the All Product page")]
        public void ThenOpenTheAllProductPage()
        {
            Assert.IsTrue(new MainPage(driver).AllProductsPageOpen(), "All Product failed");
        }

        [When(@"I click Create new")]
        public void WhenIClickCreateNew()
        {
            driver.FindElement(By.LinkText("Create new")).Click();
        }


        [Then(@"Open Product Editing page")]
        public void ThenOpenProductEditingPage()
        {
            Assert.IsTrue(new MainPage(driver).isProductEditing(), "Product editing open failed");
        }

        [Then(@"I create New Product")]
        public void ThenICreateNewProduct()
        {
            driver.FindElement(By.Id("ProductName")).SendKeys("test");
            driver.FindElement(By.XPath("//option[. = 'Beverages']")).Click();
            driver.FindElement(By.XPath("//option[. = 'Tokyo Traders']")).Click();
            driver.FindElement(By.Id("UnitPrice")).SendKeys("80");
            driver.FindElement(By.Id("QuantityPerUnit")).SendKeys("30 in");
            driver.FindElement(By.Id("UnitsInStock")).SendKeys("40");
            driver.FindElement(By.Id("UnitsOnOrder")).SendKeys("40");
            driver.FindElement(By.Id("ReorderLevel")).SendKeys("5");
            driver.FindElement(By.CssSelector(".btn")).Click();
        }

        [Then(@"I check if the product exists")]
        public void ThenICheckIfTheProductExists()
        {
            driver.FindElement(By.LinkText("test")).Click();
            Assert.AreEqual(driver.FindElement(By.Id("ProductName")).GetAttribute("value"), "test");
            Assert.AreEqual(driver.FindElement(By.XPath("//option[. = 'Beverages']")).GetAttribute("text"), "Beverages");
            Assert.AreEqual(driver.FindElement(By.XPath("//option[. = 'Tokyo Traders']")).GetAttribute("text"), "Tokyo Traders");
            Assert.AreEqual(driver.FindElement(By.Id("UnitPrice")).GetAttribute("value"), "80,0000");
            Assert.AreEqual(driver.FindElement(By.Id("QuantityPerUnit")).GetAttribute("value"), "30 in");
            Assert.AreEqual(driver.FindElement(By.Id("UnitsInStock")).GetAttribute("value"), "40");
            Assert.AreEqual(driver.FindElement(By.Id("UnitsOnOrder")).GetAttribute("value"), "40");
            Assert.AreEqual(driver.FindElement(By.Id("ReorderLevel")).GetAttribute("value"), "5");
            driver.FindElement(By.LinkText("All Products")).Click();
        }

        [Then(@"Delete New Product")]
        public void ThenDeleteNewProduct()
        {
            driver.FindElement(By.XPath("/html/body/div[3]/table/tbody/tr[78]/td[12]/a")).Click();
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }

        [Then(@"Logout")]
        public void ThenLogout()
        {
            driver.FindElement(By.XPath(".//*[text()='Logout']")).Click();
            Assert.IsTrue(new MainPage(driver).isLogoutSuccessfull(), "Logout failed");
        }

        [Then(@"close browser")]
        public void Thenclosebrowser()
        {
            driver.Close();
        }

    }

}

