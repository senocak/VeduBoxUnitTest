using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class StudentsPage : Page{
        private string USER;
        private IJavaScriptExecutor JS;

        private readonly By BUTTON_ADMIN_ADD_NEW = By.CssSelector("button[ui-sref='veduBox.admin.students.new']");
        private readonly By BUTTON_INSTRUCTOR_ADD_NEW = By.CssSelector("button[ui-sref='veduBox.teacher.students.new']");
        private readonly By INPUT_FIRSTNAME = By.CssSelector("input[ng-model='student.firstName']");
        private readonly By INPUT_LASTNAME = By.CssSelector("input[ng-model='student.lastName']");
        private readonly By SELECT_BRANCH = By.CssSelector("select[ng-model='student.branchId']");
        private readonly By INPUT_EMAIL = By.CssSelector("input[ng-model='student.email']");
        private readonly By INPUT_USER_NAME = By.CssSelector("input[ng-model='student.userName']");
        private readonly By INPUT_PASSWORD = By.CssSelector("input[ng-model='student.password']");
        private readonly By TEXTAREA_DESCRIPTION = By.CssSelector("textarea[ng-model='student.description']");
        private readonly By INPUT_EMAIL_CONFIRMED = By.CssSelector("input[ng-model='student.emailConfirmed']");
        private readonly By INPUT_GDPR_POLICY = By.CssSelector("input[ng-model='student.gdprAccepted']");
        private readonly By BUTTON_SUBMIT = By.CssSelector("button[type='submit']:nth-child(1)");
        private readonly By ALERT_SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private readonly By INPUT_SEARCH_BOX = By.CssSelector("input.form-control.vedu-search");
        private readonly By BUTTON_THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private readonly By A_DELETE_USER = By.CssSelector("a[ng-click='delete(user)']");
        private readonly By ALERT_ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private readonly By BUTTON_BATCH = By.XPath("//*[@id='mainSection']/div/div[1]/div[2]/div/div[1]/div/div[4]");
        private readonly By BUTTON_BATCH_CREATE = By.CssSelector("button[ui-sref='veduBox.admin.students.batchCreate ']");
        private readonly By INPUT_BATCH_FILE = By.Id("html_btn");
        private readonly By SELECT_BRANCH_BATCH_CREATE = By.CssSelector("select[ng-model='branchId']");
        private readonly By SELECT_CATALOG_SUBSCRIPTION_BATCH_CREATE = By.CssSelector("select[ng-model='packageDetailId']");
        private readonly By BUTTON_CATALOG_ADD_BATCH_CREATE = By.CssSelector("button[ng-click='addPackageDetail()']");
        private readonly By BUTTON_UPLOAD_BATCH_CREATE = By.CssSelector("button[ng-click='uploadFile()']");
        private readonly By BUTTON_ACCEPT_BATCH_CREATE = By.CssSelector("a[ng-click='accept()']");
        private readonly By CHECKBOX_ACCEPT_GPDR_BATCH_CREATE = By.CssSelector("input[ng-model='gdprAccepted']");

        public StudentsPage(IWebDriver wd, string user) : base(wd){
            USER = user;
            JS = (IJavaScriptExecutor)wd;
        }
        public StudentsPage AddNew(){
            if(USER == "admin"){
                click(BUTTON_ADMIN_ADD_NEW);
            }else if(USER == "instructor"){
                click(BUTTON_INSTRUCTOR_ADD_NEW);
            }
            return this;
        }
        public StudentsPage SetFirstName(string firstName){
            type(INPUT_FIRSTNAME, firstName);
            return this;
        }
        public StudentsPage SetLastName(string lastName){
            type(INPUT_LASTNAME, lastName);
            return this;
        }
        public StudentsPage SelectBranch(string branchName){
            selectDropDown(SELECT_BRANCH, branchName);
            return this;
        }
        public StudentsPage SetEmail(string email){
            type(INPUT_EMAIL, email);
            return this;
        }
        public StudentsPage SetUserName(string userName){
            type(INPUT_USER_NAME, userName);
            return this;
        }
        public StudentsPage SetPassword(string password){
            type(INPUT_PASSWORD, password);
            return this;
        }
        public StudentsPage SetCatalog(params string[] catalogNames){
            foreach (string catalogName in catalogNames){
                click(By.XPath("//a[contains(text(), '" + catalogName + "')]"));
            }
            return this;
        }
        public StudentsPage SetDescription(string description){
            type(TEXTAREA_DESCRIPTION, description);
            return this;
        }
        public StudentsPage SetEmailConfirmed(){
            if (!isSelected(INPUT_EMAIL_CONFIRMED))
                click(INPUT_EMAIL_CONFIRMED);
            else
                Console.WriteLine("Already EMAIL_CONFIRMED is selected");
            return this;
        }
        public StudentsPage SetGpdrPolicy(){
            if (!isSelected(INPUT_GDPR_POLICY))
                click(INPUT_GDPR_POLICY);
            else
                Console.WriteLine("Already GDPR_POLICY is selected");
            return this;
        }
        public StudentsPage Submit(){
            click(BUTTON_SUBMIT);
            return this;
        }
        public StudentsPage Assert(){
            AssertionCustom.assertElementVisible("Element Not Found", driver, ALERT_SUCCESS);
            return this;
        }
        public StudentsPage SearchNewlyAddedUserByEmail(string email){
            type(INPUT_SEARCH_BOX, email);
            sleepms(1000);
            return this;
        }
        public StudentsPage SearchNewlyAddedUserByEmailAndDeleteIt(string email){
            SearchNewlyAddedUserByEmail(email);
            try{
                Click3Points();
            }catch (Exception e){
                Console.WriteLine("Error:" + e.Message);
                return null;
            }
            ClickDeleteUserButton();
            ClickAreUSure();
            Assert();
            return this;
        }
        public StudentsPage Click3Points(){
            click(BUTTON_THREE_POINTS);
            return this;
        }
        public StudentsPage ClickDeleteUserButton(){
            click(A_DELETE_USER);
            return this;
        }
        public StudentsPage ClickAreUSure(){
            click(ALERT_ARE_U_SURE_OK);
            return this;
        }
        public StudentsPage ClickBatchButton(){
            click(BUTTON_BATCH);
            return this;
        }
        public StudentsPage ClickBatchCreateButton(){
            click(BUTTON_BATCH_CREATE);
            return this;
        }
        public StudentsPage EnterExcelFile(){
            JS.ExecuteScript("document.getElementById('html_btn').style.display = 'block';");
            type(
                INPUT_BATCH_FILE,
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Docs\\student_batch_excel.xlsx"))
            );
            return this;
        }
        public StudentsPage SelectBranchBatchCreate(string branch){
            selectDropDown(SELECT_BRANCH_BATCH_CREATE, branch);
            return this;
        }
        public StudentsPage SetCatalogBatchCreate(string catalog){
            selectDropDown(SELECT_CATALOG_SUBSCRIPTION_BATCH_CREATE, catalog);
            return this;
        }
        public StudentsPage ClickAddCatalogButtonBatchCreate(){
            click(BUTTON_CATALOG_ADD_BATCH_CREATE);
            return this;
        }
        public StudentsPage ClickUploadButtonBatchCreate(){
            click(BUTTON_UPLOAD_BATCH_CREATE);
            return this;
        }
        public StudentsPage ClickAcceptButtonBatchCreate(){
            click(BUTTON_ACCEPT_BATCH_CREATE);
            return this;
        }
        public StudentsPage SetGpdrPolicyBatchCreate(){
            click(CHECKBOX_ACCEPT_GPDR_BATCH_CREATE);
            return this;
        }
        
    }
}