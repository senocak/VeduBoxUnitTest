using System;
using System.IO;
using OpenQA.Selenium;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages
{
    class BlogPage : Page {
        private string USER;
        private IJavaScriptExecutor JS;
        private readonly By BUTTON_DELETE = By.CssSelector("button[ng-click='delete(category.categoryId)']");
        private readonly By ALERT_ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private readonly By ALERT_SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private readonly By INPUT_NAME = By.CssSelector("input[ng-model='blogCategoryName']");
        private readonly By SUBMIT_UPDATE = By.CssSelector("button[ng-click='updateCategory()']");
        private readonly By SUBMIT_ADD = By.CssSelector("button[ng-click='saveCategory()']");

        public BlogPage(IWebDriver wd, string user) : base(wd) {
            USER = user;
            JS = (IJavaScriptExecutor)wd;
        }
        public BlogPage EnterName(string name){
            Type(INPUT_NAME, name);
            return this;
        }
        public BlogPage SubmitUpdate(){
            Click(SUBMIT_UPDATE);
            return this;
        }
        public BlogPage SubmitAdd(){
            Click(SUBMIT_ADD);
            return this;
        }
        public BlogPage ClickAreUSure(){
            Click(ALERT_ARE_U_SURE_OK);
            return this;
        }
        public BlogPage Click3Points(string name){
            Click(By.XPath("//*[text()='"+name+"']/following-sibling::td[2]/div/button"));
            return this;
        }
        public BlogPage ClickUpdateButtonIn3PointsBy(string name){
            Click(By.XPath("//*[text()='"+name+"']/following-sibling::td[2]/div/ul/button[1]"));
            return this;
        }
        public BlogPage ClickDeleteIn3PointsBy(string name){
            Click(By.XPath("//*[text()='"+name+"']/following-sibling::td[2]/div/ul/button[2]"));
            return this;
        }
        public BlogPage SearchBlogCategoryAndDeleteIt(string name){
            try {
                Click3Points(name);
                ClickDeleteIn3PointsBy(name);
                ClickAreUSure();
                Assert();
            }catch (Exception e) {
                Console.WriteLine("Error occured in SearchTestCategoryAndDeleteIt. Error is: " + e.Message);
                return null;
            }
            return this;
        }
        public BlogPage Assert(){
            AssertionCustom.AssertElementVisible("Element Not Found", Driver, ALERT_SUCCESS);
            return this;
        }
    }
}