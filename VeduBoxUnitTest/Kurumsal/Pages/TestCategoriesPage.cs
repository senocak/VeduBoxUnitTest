using System;
using OpenQA.Selenium;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages {
    class TestCategoriesPage : Page {
        private String USER;
        private readonly By BUTTON_ADD = By.CssSelector("a[ng-click='ctrl.category={ id: 0 }']");
        private readonly By DELETE_ADD = By.CssSelector("button[ng-click='ctrl.delete()']");
        private readonly By ALERT_ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private readonly By ALERT_SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private readonly By INPUT_NAME = By.CssSelector("input[ng-model='ctrl.category.name']");
        private readonly By SUBMIT_ADD = By.XPath("//*[@id='mainSection']/div/div[1]/div[2]/div[2]/div[1]/fieldset/form/div/div[2]/button[1]");

        public TestCategoriesPage(IWebDriver wd, string user) : base(wd) {
            USER = user;
        }
        public TestCategoriesPage ClickAddButton(){
            Click(BUTTON_ADD);
            return this;
        }
        public TestCategoriesPage EnterName(string name){
            Type(INPUT_NAME, name);
            return this;
        }
        public TestCategoriesPage SubmitAdd(){
            Click(SUBMIT_ADD);
            return this;
        }
        public TestCategoriesPage ClickDeleteButton(){
            Click(DELETE_ADD);
            return this;
        }
        public TestCategoriesPage ClickAreUSure(){
            Click(ALERT_ARE_U_SURE_OK);
            return this;
        }
        public TestCategoriesPage ClickName(string name){
            Click(By.XPath("//*[contains(text(),'" + name + "')]"));
            return this;
        }
        public TestCategoriesPage SearchTestCategoryAndDeleteIt(string name){
            try {
                ClickName(name);
                ClickDeleteButton();
                ClickAreUSure();
                Assert();
            }catch (Exception e) {
                Console.WriteLine("Error occured in SearchTestCategoryAndDeleteIt. Error is: " + e.Message);
                return null;
            }
            return this;
        }
        public TestCategoriesPage Assert(){
            AssertionCustom.AssertElementVisible("Element Not Found", Driver, ALERT_SUCCESS);
            return this;
        }
    }
}