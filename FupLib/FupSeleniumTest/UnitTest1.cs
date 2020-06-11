using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace FupSeleniumTest
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly string DriverDirectory = "C:\\SeleniumWebdrivers";
        private static IWebDriver _driver;

        // https://www.automatetheplanet.com/mstest-cheat-sheet/
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            //_driver = new ChromeDriver(DriverDirectory); // fast
            _driver = new FirefoxDriver(DriverDirectory);  // slow
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }


        [TestMethod]
        public void TestApiPost()
        {
            _driver.Navigate().GoToUrl("file:///C:/Users/Bendover/Desktop/schoo/pr%C3%B8veeksamen/Web-Applikation/index.html");
            string title = _driver.Title;
            Assert.AreEqual("Document", title);

            IWebElement inputField = _driver.FindElement(By.CssSelector("[placeholder='lastbil']"));
            inputField.SendKeys("test");

            IWebElement inputField1 = _driver.FindElement(By.CssSelector("[placeholder='chauffor']"));
            inputField1.SendKeys("test");

            IWebElement inputField2 = _driver.FindElement(By.CssSelector("[placeholder='dato']"));
            inputField2.SendKeys("20-10-2010");

            IWebElement inputField3 = _driver.FindElement(By.CssSelector("[placeholder='antalKm']"));
            inputField3.SendKeys("2000");

            IWebElement inputField4 = _driver.FindElement(By.CssSelector("[placeholder='gennemsnit']"));
            inputField4.SendKeys("5000");

            IWebElement submitbtn = _driver.FindElement(By.CssSelector(".btn-success"));
            submitbtn.Click(); // press Return

            IWebElement resultElement = _driver.FindElement(By.CssSelector("output"));
            string message = resultElement.Text;
            Assert.AreEqual("response 201", message);
        }


    }
}

