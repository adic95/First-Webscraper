using System;
using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Scraper2
{
    class Program
    {
        public static IWebDriver m_driver;
        private static IWebElement m_signInbtn;
        private static IWebElement m_usernameTb;
        private static IWebElement m_passwordTb;
        private static IWebElement m_loginBtn;
        private static IWebElement m_newBtn;
        private static IWebElement m_repoNametb;
        private static IWebElement m_privateBtn;
        private static IWebElement m_createBtn;
        public static IWebElement m_RtgBtn;
        private static string m_repoName;
        private static ReadOnlyCollection<IWebElement> m_elements;
        static void Main(string[] args)
        {

            //ChromeOptions options = new ChromeOptions();
            //options.AddArgument("headless");
            m_driver = new ChromeDriver(@"C:\Users\Adi\Desktop\Scaper\Scraper\bin\Debug\netcoreapp3.1");
            m_driver.Url = "https://github.com/";
            Login();
            CreateRepo();
            //m_RtgBtn = m_driver.FindElement(By.XPath("/html/body/div[4]/div/div/div/main/div[1]/div/div/a[1]"));
            WebDriverWait wait = new WebDriverWait(m_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[4]/div/main/div[2]/nav/span[2]/a")));
            m_driver.Quit();

        }

        static void Login()
        {
            m_signInbtn = m_driver.FindElement(By.XPath("/html/body/div[1]/header/div/div[2]/div[2]/a[1]"));
            m_signInbtn.Click();
            m_usernameTb = m_driver.FindElement(By.XPath("/html/body/div[3]/main/div/form/div[3]/input[1]"));
            m_passwordTb = m_driver.FindElement(By.XPath("/html/body/div[3]/main/div/form/div[3]/input[2]"));
            Console.WriteLine("Enter your username/e-mail address:");
            m_usernameTb.SendKeys(Console.ReadLine());
            Console.WriteLine("Enter your password:");
            m_passwordTb.SendKeys(Console.ReadLine());
            m_loginBtn = m_driver.FindElement(By.XPath("/html/body/div[3]/main/div/form/div[3]/input[8]"));
            m_loginBtn.Click();
        }

        static void CreateRepo()
        {
            m_newBtn = m_driver.FindElement(By.XPath("/html/body/div[4]/div/aside[1]/div[2]/div[2]/div/h2/a"));
            m_newBtn.Click();
            m_repoNametb = m_driver.FindElement(By.XPath("/html/body/div[4]/main/div/form/div[2]/auto-check/dl/dd/input"));
            Console.WriteLine("Enter the Repo name");
            m_repoName = Console.ReadLine();
            m_repoNametb.SendKeys(m_repoName);
            Thread.Sleep(2000);



            m_privateBtn = m_driver.FindElement(By.XPath("/html/body/div[4]/main/div/form/div[3]/div[2]/label/input"));
            m_privateBtn.Click();
            Thread.Sleep(2000);
            m_createBtn = m_driver.FindElement(By.XPath("/html/body/div[4]/main/div/form/div[3]/button"));
            m_createBtn.Click();
        }
    }
}
