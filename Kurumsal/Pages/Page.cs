using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class Page : ILoadableComponent{
        private static int EXPECTED_CONDITION_TIMEOUT = 15;
        private static int EXPECTED_CONDITION_POLLING_INTERVAL = 5;
        private static int USER_WAIT_IN_MS = 1000;

        public ILoadableComponent Load(){
            return this;
        }
        protected IWebDriver driver;
        public Page(IWebDriver wd){
            driver = wd;
        }
        public void type<P, T>(P p, T t){
            if ((p == null)){
                throw new Exception(p + "is null");
            }else if (!(p is IWebElement) && !(p is By)){
                throw new Exception(p + "parameter type not supported by tap function");
            }
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(EXPECTED_CONDITION_TIMEOUT);
            wait.PollingInterval = TimeSpan.FromMilliseconds(EXPECTED_CONDITION_POLLING_INTERVAL);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(ElementNotVisibleException));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
            wait.IgnoreExceptionTypes(typeof(WebDriverTimeoutException));
            wait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));

           // wait.Message = "Element to be searched not found";
            wait.Until(
                drv =>{
                    IWebElement el = null;
                    if (p is By){
                        el = driver.FindElement((By)(Object)p);
                    }else{
                        el = ((IWebElement)p);
                    }
                    el.Clear();
                    el.SendKeys(t.ToString());
                    return el;
                }
            );
            sleepms(USER_WAIT_IN_MS);
        }

        public void click<T>(T p)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(EXPECTED_CONDITION_TIMEOUT));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(ElementNotVisibleException));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
            wait.IgnoreExceptionTypes(typeof(WebDriverTimeoutException));
            wait.Until(
                drv => {
                    //IWebElement el = p is By ? driver.FindElement((By)(Object)p) : (IWebElement)p;
                    IWebElement el = null;
                    if (p is By){
                        el = driver.FindElement((By)(Object)p);
                    }else{
                        el = ((IWebElement)p);
                    }
                    el.Click();
                    return el;
                }
            );
            sleepms(USER_WAIT_IN_MS);
        }

        public void clear<T>(T p)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(EXPECTED_CONDITION_TIMEOUT));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(ElementNotVisibleException));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
            wait.IgnoreExceptionTypes(typeof(WebDriverTimeoutException));
            wait.Until(
                drv => {
                    //IWebElement el = p is By ? driver.FindElement((By)(Object)p) : (IWebElement)p;
                    IWebElement el = null;
                    if (p is By)
                    {
                        el = driver.FindElement((By)(Object)p);
                    }
                    else
                    {
                        el = ((IWebElement)p);
                    }
                    el.Clear();
                    return el;
                }
            );
            sleepms(USER_WAIT_IN_MS);
        }

        public void scroll<T>(T p){
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(EXPECTED_CONDITION_TIMEOUT));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(ElementNotVisibleException));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
            wait.IgnoreExceptionTypes(typeof(TimeoutException));
            wait.Until(
                drv => {
                    IWebElement el = driver.FindElement((By)(Object)p);
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    js.ExecuteAsyncScript("arguments[0].scrollIntoView();", el);
                        return el;
                    }
                );
            sleepms(USER_WAIT_IN_MS);
        }

        public  void selectDropDown<P, T>(P p, T text){
            IWebElement el = driver.FindElement((By)(Object)p);
            SelectElement selectElement = new SelectElement(el);
            selectElement.SelectByText(text.ToString());
            sleepms(USER_WAIT_IN_MS);
        }
        public static void sleepms(int time){
            Thread.Sleep(time);
        }
        public Boolean isSelected<T>(T t){
            return driver.FindElement((By)(Object)t).Selected;
        }
    }
}
