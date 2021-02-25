using System;
using System.IO;
using OpenQA.Selenium;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages {
    class ImagePoolPage : Page {
        private String USER;
        private IJavaScriptExecutor JS;
        private readonly By BUTTON_ADD = By.CssSelector("a[ng-click='category={ id: 0 }']");
        private readonly By DELETE_ADD = By.CssSelector("button[ng-click='delete()']");
        private readonly By ALERT_ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private readonly By ALERT_SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private readonly By INPUT_NAME = By.CssSelector("input[ng-model='category.name']");
        private readonly By SUBMIT_UPDATE = By.CssSelector("button[ng-click='saveImage()']");
        private readonly By SUBMIT_ADD = By.XPath("//*[@id='mainSection']/div/div[1]/div[2]/div[1]/div[2]/div[1]/fieldset/form/div[1]/div[2]/button[1]");
        private readonly string INPUT_IMAGE_FILE_ID = "fileBtn";
        private readonly By INPUT_IMAGE_TEXT = By.CssSelector("input[ng-model='image.text']");

        public ImagePoolPage(IWebDriver wd, string user) : base(wd) {
            USER = user;
            JS = (IJavaScriptExecutor)wd;
        }
        public ImagePoolPage ClickAddButton(){
            Click(BUTTON_ADD);
            return this;
        }
        public ImagePoolPage EnterName(string name){
            Type(INPUT_NAME, name);
            return this;
        }
        public ImagePoolPage SubmitUpdate(){
            Click(SUBMIT_UPDATE);
            return this;
        }
        public ImagePoolPage SubmitAdd(){
            Click(SUBMIT_ADD);
            return this;
        }
        public ImagePoolPage ClickDeleteButton(){
            Click(DELETE_ADD);
            return this;
        }
        public ImagePoolPage ClickAreUSure(){
            Click(ALERT_ARE_U_SURE_OK);
            return this;
        }
        public ImagePoolPage ClickName(string name){
            Click(By.XPath("//*[contains(text(),'" + name + "')]"));
            return this;
        }
        public ImagePoolPage EnterImage(){
            JS.ExecuteScript("document.getElementById('"+INPUT_IMAGE_FILE_ID+"').style.display = 'block';");
            Type(
                By.Id(INPUT_IMAGE_FILE_ID),
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Docs\\file.png"))
            );
            return this;
        }
        public ImagePoolPage EnterImageText(string name){
            Type(INPUT_IMAGE_TEXT, name);
            return this;
        }
        
        public ImagePoolPage SearchImageCategoryAndDeleteIt(string name){
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
        public ImagePoolPage Assert(){
            AssertionCustom.AssertElementVisible("Element Not Found", Driver, ALERT_SUCCESS);
            return this;
        }
    }
}