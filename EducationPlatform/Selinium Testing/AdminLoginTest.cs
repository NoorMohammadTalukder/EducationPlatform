using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace EducationPlatform.Selinium_Testing
{
    public class AdminLoginTest
    {
        static void Main(string[] args)
        {
            Console.Write("test case started ");
            //create the reference for the browser  
            IWebDriver driver = new ChromeDriver();
            // navigate to URL  
            driver.Navigate().GoToUrl("https://localhost:44394/Admin/AdminLogin");
            Thread.Sleep(2000);
            // identify the Google search text box  
            IWebElement ele = driver.FindElement(By.Name("Email"));
            //enter the value in the google search text box  
            ele.SendKeys("noor@gmail.com");
            Thread.Sleep(2000);

            // identify the Google search text box  
            IWebElement ele2 = driver.FindElement(By.Name("Password"));
            //enter the value in the google search text box  
            ele.SendKeys("123456");
            Thread.Sleep(2000);
            //identify the google search button  
            IWebElement ele3 = driver.FindElement(By.Name("Submit"));
            // click on the Google search button  
            ele3.Click();
            Thread.Sleep(3000);
            //close the browser  
            driver.Close();
            Console.Write("test case ended ");
        }
    }
}