using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace VeduBoxUnitTest.Assertion
{
    class AssertionCustom{
        public static long EXPECTED_CONDITION_TIMEOUT = 30;
        private static int EXPECTED_CONDITION_POLLING_INTERVAL = 5;
        //private static int USER_WAIT_IN_MS = 1000;

        public static void assertElementVisible(String errorMessage, IWebDriver driver, By by){
            try{
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(EXPECTED_CONDITION_TIMEOUT));
                wait.IgnoreExceptionTypes(typeof(WebDriverException));
                wait.Message = errorMessage;
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
            } catch (Exception e) {
                Console.WriteLine("Hata; " + e);
                Assert.Fail(errorMessage + " (tried for " + EXPECTED_CONDITION_TIMEOUT + " second(s) with 5 seconds interval)");
            }
        }
        public static void assertTextToBePresentInElementLocated(IWebDriver driver, By by, String textExpected, String errorMessage){
            try{
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(EXPECTED_CONDITION_TIMEOUT));
                wait.IgnoreExceptionTypes(typeof(WebDriverException));
                wait.PollingInterval = TimeSpan.FromMilliseconds(EXPECTED_CONDITION_POLLING_INTERVAL);
                wait.Timeout = TimeSpan.FromSeconds(EXPECTED_CONDITION_TIMEOUT);
                wait.Message = errorMessage;
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(driver.FindElement(by), textExpected));
            }catch (Exception e){
                Console.WriteLine("Hata; " + e);
                Assert.Fail(errorMessage + " (tried for " + EXPECTED_CONDITION_TIMEOUT + " second(s) with 5 seconds interval)");
            }
        }
    }
}
