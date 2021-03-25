using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class SupportPage : Page{
        private string USER;
        private IJavaScriptExecutor JS;
        private readonly By INPUT_SUBJECT = By.CssSelector("input[ng-model='ticket.subject']");
        private readonly By TEXTAREA_DESCRIPTION = By.CssSelector("textarea[ng-model='ticket.description']");
        private readonly string INPUT_IMAGE_FILE_ID = "fileBtn";
        private readonly By CHECKBOX_NEW_COURSE_DEMAND = By.CssSelector("input[ng-model='ticket.isCourseDemand']");
        private readonly By BUTTON_SUBMIT = By.CssSelector("button[ng-click='sendTicket()']");
        private readonly By ALERT_SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");

        public SupportPage(IWebDriver wd, string user) : base(wd){
            USER = user;
            JS = (IJavaScriptExecutor)wd;
        }
        public SupportPage EnterSubject(string entry){
            Type(INPUT_SUBJECT, entry);
            return this;
        }
        public SupportPage EnterDesc(string desc){
            Type(TEXTAREA_DESCRIPTION, desc);
            return this;
        }
        public SupportPage EnterImage(){
            JS.ExecuteScript("document.getElementById('"+INPUT_IMAGE_FILE_ID+"').style.display = 'block';");
            Type(
                By.Id(INPUT_IMAGE_FILE_ID),
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Docs\\file.png"))
            );
            return this;
        }
        public SupportPage SetNewCourseDemand(bool value = false){
            if ((value == true && IsSelected(CHECKBOX_NEW_COURSE_DEMAND) == false) || 
                (value == false && IsSelected(CHECKBOX_NEW_COURSE_DEMAND) == true)) {
                Click(CHECKBOX_NEW_COURSE_DEMAND);
            }
            return this;
        }
        public SupportPage ClickSubmit(){
            Click(BUTTON_SUBMIT);
            return this;
        }
        public SupportPage Assert() {
            AssertionCustom.AssertElementVisible("Element Not Found", Driver, ALERT_SUCCESS);
            return this;
        }
    }
}