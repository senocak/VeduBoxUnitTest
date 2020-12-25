using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class EarningsPage : Page{
        private static string _user;
        private static readonly By SEARCH = By.XPath("//*[@id='mainSection']/div/div[1]/div[2]/div/div/div/div[1]/div/div[1]/div/div[2]/input");

        public EarningsPage(IWebDriver wd, string user) : base(wd){
            _user = user;
        }
        public EarningsPage searchEntry(string value){
            type(SEARCH, value);
            return this;
        }
        public EarningsPage assertSubjectIsVisible(string title){
            AssertionCustom.assertElementVisible("Element Not Found", driver, By.XPath("//*[contains(text(), '" + title + "')]"));
            return this;
        }
    }
}
