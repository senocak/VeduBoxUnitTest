using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class BranchPage : Page{
        
        private static string USER;
        private readonly By BUTTON_ADD = By.CssSelector("button[ng-click='branch={ id: 0 }']");
        private readonly By INPUT_NAME = By.CssSelector("input[ng-model='branch.name']");
        private readonly By INPUT_LIMIT = By.CssSelector("input[ng-model='branch.userLimitCount']");
        private readonly By BUTTON_SAVE = By.CssSelector("button[class='btn btn-default btn-oval mb5'][type='submit']");
        private readonly By BUTTON_DELETE = By.CssSelector("button[ng-click='delete()']");
        private readonly By INPUT_SEARCH_BOX = By.Id("search");
        private readonly By ALERT_SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private readonly By ALERT_ARE_U_SURE_OK = By.CssSelector("button.msc-ok");

        public BranchPage(IWebDriver wd, string user) : base(wd){
            USER = user;
        }
        public BranchPage ClickAddButton(){
            Click(BUTTON_ADD);
            return this;
        }
        public BranchPage EnterName(string name){
            Type(INPUT_NAME, name);
            return this;
        }
        public BranchPage EnterLimit(int limit){
            Type(INPUT_LIMIT, limit);
            return this;
        }
        public BranchPage ClickSaveButton(){
            Click(BUTTON_SAVE);
            return this;
        }
        public BranchPage Assert(){
            AssertionCustom.AssertElementVisible("Element Not Found", Driver, ALERT_SUCCESS);
            return this;
        }
        public BranchPage SearchNewlyAddedBranchByNameAndDeleteItAndAssertIt(string name){
            SearchNewlyAddedBranchByName(name);
            try{
                SelectBranch(name);
            }catch (Exception e){
                Console.WriteLine("Error while selecting branch. Looks like there is no record. Returning null." + e.Message);
                return null;
            }
            DeleteNewlyAddedBranch();
            ClickAreYouSure();
            Assert();
            return this;
        }
        public BranchPage SearchNewlyAddedBranchByName(string name){
            Type(INPUT_SEARCH_BOX, name);
            Sleepms(1000);
            return this;
        }
        public BranchPage SelectBranch(string name){
            Click(By.XPath("//a[contains(text(), '" + name + "')]"));
            return this;
        }
        public BranchPage DeleteNewlyAddedBranch(){
            Click(BUTTON_DELETE);
            return this;
        }
        public BranchPage ClickAreYouSure(){
            Click(ALERT_ARE_U_SURE_OK);
            return this;
        }
    }
}
