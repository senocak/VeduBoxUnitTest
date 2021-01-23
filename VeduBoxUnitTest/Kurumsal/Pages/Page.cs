using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class Page : ILoadableComponent{
        
        private static int EXPECTED_CONDITION_TIMEOUT = 15;
        private static int EXPECTED_CONDITION_POLLING_INTERVAL = 5;
        private static int USER_WAIT_IN_MS = 1000;
        public ILoadableComponent Load(){
            return this;
        }
        protected IWebDriver Driver;
        public Page(IWebDriver wd){
            Driver = wd;
        }
        public void Type<P, T>(P p, T t){
            if ((p == null)){
                throw new Exception(p + "is null");
            }else if (!(p is IWebElement) && !(p is By)){
                throw new Exception(p + "parameter type not supported by tap function");
            }
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(Driver);
            wait.Timeout = TimeSpan.FromSeconds(EXPECTED_CONDITION_TIMEOUT);
            wait.PollingInterval = TimeSpan.FromMilliseconds(EXPECTED_CONDITION_POLLING_INTERVAL);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(ElementNotVisibleException));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
            wait.IgnoreExceptionTypes(typeof(WebDriverTimeoutException));
            wait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));
            wait.Until(
                drv =>{
                    IWebElement el = p is By ? Driver.FindElement((By)(Object)p) : ((IWebElement)p);
                    el.Clear();
                    el.SendKeys(t.ToString());
                    return el;
                }
            );
            Sleepms(USER_WAIT_IN_MS);
        }

        public void Click<T>(T p) {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(EXPECTED_CONDITION_TIMEOUT));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(ElementNotVisibleException));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
            wait.IgnoreExceptionTypes(typeof(WebDriverTimeoutException));
            wait.Until(
                drv => {
                    IWebElement el = p is By ? Driver.FindElement((By)(Object)p) : ((IWebElement)p);
                    try{
                        Actions actions = new Actions(Driver);
                        actions.MoveToElement(el);
                        actions.Perform();
                    }catch(Exception e){
                        Console.WriteLine("Action error is occured during move to element. error is : " + e.Message);
                    }
                    el.Click();
                    return el;
                }
            );
            Sleepms(USER_WAIT_IN_MS);
        }

        public void Clear<T>(T p){
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(EXPECTED_CONDITION_TIMEOUT));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(ElementNotVisibleException));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
            wait.IgnoreExceptionTypes(typeof(WebDriverTimeoutException));
            wait.Until(
                drv => {
                    IWebElement el = p is By ? Driver.FindElement((By)(Object)p) : ((IWebElement)p);
                    el.Clear();
                    return el;
                }
            );
            Sleepms(USER_WAIT_IN_MS);
        }

        public void Scroll<T>(T p){
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(EXPECTED_CONDITION_TIMEOUT));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(ElementNotVisibleException));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
            wait.IgnoreExceptionTypes(typeof(TimeoutException));
            wait.Until(
                drv => {
                    IWebElement el = Driver.FindElement((By)(Object)p);
                    IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
                    js.ExecuteAsyncScript("arguments[0].scrollIntoView();", el);
                        return el;
                    }
                );
            Sleepms(USER_WAIT_IN_MS);
        }

        public  void SelectDropDown<P, T>(P p, T text){
            IWebElement el = Driver.FindElement((By)(Object)p);
            SelectElement selectElement = new SelectElement(el);
            selectElement.SelectByText(text.ToString());
            Sleepms(USER_WAIT_IN_MS);
        }
        public static void Sleepms(int time){
            Thread.Sleep(time);
        }
        public Boolean IsSelected<T>(T t){
            return Driver.FindElement((By)(Object)t).Selected;
        }
        public string GetAttribute<T, P>(T t, P attribute){
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(EXPECTED_CONDITION_TIMEOUT));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(ElementNotVisibleException));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
            wait.IgnoreExceptionTypes(typeof(TimeoutException));
            return wait.Until(
                drv => {
                    return Driver.FindElement((By)(Object)t).GetAttribute(attribute.ToString());
                }
            );
        }
    }
}
