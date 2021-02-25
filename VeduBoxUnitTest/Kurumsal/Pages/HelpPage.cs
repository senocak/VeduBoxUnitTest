using System;
using OpenQA.Selenium;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages {
    class HelpPage : Page {
        private string USER;
        private IJavaScriptExecutor JS;
        private readonly By A_ADD_CATEGORY = By.CssSelector("a[ng-click='help={ id: 0, isPublic : true }']");
        private readonly By BUTTON_DELETE = By.CssSelector("button[ng-click='delete()']");
        private readonly By ALERT_ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private readonly By ALERT_SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private readonly By INPUT_NAME = By.CssSelector("input[ng-model='help.name']");
        private readonly By SUBMIT_UPDATE = By.CssSelector("button[ng-show='help.id>0']");
        private readonly By SUBMIT_ADD = By.CssSelector("button[ng-show='help.id==0']");
        private readonly By BUTTON_ADD_ITEM = By.CssSelector("button[ng-click='addItem(subject.id)']");
        private readonly By BUTTON_STEP_2 = By.CssSelector("button[ng-click='step = 2']");
        private readonly By INPUT_DOCUMENT_TITLE = By.Id("txtName");
        private readonly By INPUT_DOCUMENT_DESC = By.Id("txtDescription");
        private readonly By INPUT_DOCUMENT_DESC = By.Id("txtDescription");
        
        
        
        public HelpPage(IWebDriver wd, string user) : base(wd) {
            USER = user;
            JS = (IJavaScriptExecutor)wd;
        }
        public HelpPage ClickAddButton() {
            Click(A_ADD_CATEGORY);
            return this;
        }
        public HelpPage EnterName(string name){
            Type(INPUT_NAME, name);
            return this;
        }
        public HelpPage SubmitUpdate(){
            Click(SUBMIT_UPDATE);
            return this;
        }
        public HelpPage SubmitAdd(){
            Click(SUBMIT_ADD);
            return this;
        }
        public HelpPage ClickAreUSure(){
            Click(ALERT_ARE_U_SURE_OK);
            return this;
        }
        public HelpPage ClickName(string name){
            Click(By.XPath("//*[text()='"+name+"']"));
            return this;
        }
        public HelpPage ClickDeleteButton(){
            Click(BUTTON_DELETE);
            return this;
        }
        public HelpPage SearchCategoryAndDeleteIt(string name){
            try {
                ClickName(name);
                ClickDeleteButton();
                ClickAreUSure();
                Assert();
            }catch (Exception e) {
                Console.WriteLine("Error occured in SearchCategoryAndDeleteIt. Error is: " + e.Message);
                return null;
            }
            return this;
        }
        public HelpPage Assert(){
            AssertionCustom.AssertElementVisible("Element Not Found", Driver, ALERT_SUCCESS);
            return this;
        }
        public HelpPage ClickAddItemButton() {
            Click(BUTTON_ADD_ITEM);
            return this;
        }
        public HelpPage SelectCategoryItem(string item) {
            if (item == "document") {
                item = "1";
            }else if (item == "video") {
                item = "2";
            }else if (item == "link") {
                item = "3";
            }else if (item == "embed_code") {
                item = "4";
            }else {
                throw new Exception("Undefined Category item");
            }
            Click(By.CssSelector("span[ng-click='resourceTypeId = "+item+"']"));
            return this;
        }
        public HelpPage ClickStep2Button() {
            Click(BUTTON_STEP_2);
            return this;
        }
        public HelpPage EnterDocumentTitle(string title) {
            Type(INPUT_DOCUMENT_TITLE, title);
            return this;
        }
        public HelpPage EnterDocumentDesc(string desc) {
            Type(INPUT_DOCUMENT_DESC, desc);
            return this;
        }
        public HelpPage SelectFile(){
            Type(
                INPUT_RESOURCE_TYPE_DOC_FILE,
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Docs\\file.png"))
            );
            return this;
        }
    }
}