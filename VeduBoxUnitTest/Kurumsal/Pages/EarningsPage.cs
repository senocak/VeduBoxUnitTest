using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class EarningsPage : Page{
        private string USER;
        private readonly By INPUT_SEARCH = By.XPath("//*[@id='mainSection']/div/div[1]/div[2]/div/div/div/div[1]/div/div[1]/div/div[2]/input");

        public EarningsPage(IWebDriver wd, string user) : base(wd){
            USER = user;
        }
        public EarningsPage SearchEntry(string value){
            Type(INPUT_SEARCH, value);
            return this;
        }
        public EarningsPage AssertSubjectIsVisible(string title){
            AssertionCustom.AssertElementVisible("Element Not Found", Driver, By.XPath("//*[contains(text(), '" + title + "')]"));
            return this;
        }
    }
}
