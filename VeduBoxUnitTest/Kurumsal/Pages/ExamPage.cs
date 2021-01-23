using OpenQA.Selenium;
using System;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class ExamPage : Page{
        private readonly By INPUT_SEARCH_BOX = By.CssSelector("input.form-control.vedu-search");
        private readonly By BUTTON_THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private readonly By A_DELETE_EXAM = By.CssSelector("a[ng-click='delete(exam.id)']");
        private readonly By BUTTON_ADD_NEW = By.CssSelector("button[ui-sref='veduBox.teacher.me.exams.new']");
        private readonly By INPUT_NAME = By.CssSelector("input[ng-model='exam.name']");
        private readonly By DIV_DESCRIPTION = By.CssSelector("div[ng-model='html']");
        private readonly By BUTTON_NEXT = By.CssSelector("button[ng-click='goToStep(2)']");
        private readonly By INPUT_SEARCH_TEST = By.XPath("//*[@id='step2']/div/div[1]/div/div[1]/div[2]/div[4]/input");
        private readonly By BUTTON_SET_BUTTON_TEST = By.CssSelector("button[ng-click='setSelectedTests(test)']");
        private readonly By BUTTON_SAVE = By.CssSelector("button[ng-click='goToStep(3)']");
        private readonly By INPUT_REPEAT_NUMBER = By.CssSelector("input[ng-model='exam.repeatNumber']");
        private readonly By SELECT_FIRST_EXAM = By.XPath("//*[@id='student_my_exam']/div[2]/div/div/div/div[1]/div/div[1]/table/tbody/tr[1]/td[7]/button");
        private readonly By BUTTON_START_EXAM = By.CssSelector("button[ng-click='gotoStep(2)']");
        private readonly By BUTTON_FINISH_EXAM = By.CssSelector("button[ng-click='FinishExam()']");
        private readonly By ALERT_ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private readonly By ALERT_SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");

        private string USER;
        public ExamPage(IWebDriver wd, string user) : base(wd){
            USER = user;
        }
        public ExamPage GetFirstExam(){
            Click(SELECT_FIRST_EXAM);
            return this;
        }
        public ExamPage ClickStartExamButton(){
            Click(BUTTON_START_EXAM);
            return this;
        }
        public ExamPage ClickFinishExamButton(){
            Click(BUTTON_FINISH_EXAM);
            return this;
        }
        public ExamPage Assert(){
            AssertionCustom.AssertElementVisible("Element Not Found", Driver, ALERT_SUCCESS);
            return this;
        }
        public ExamPage ClickAreUSure(){
            Click(ALERT_ARE_U_SURE_OK);
            return this;
        }
        public ExamPage Click3Points(){
            Click(BUTTON_THREE_POINTS);
            return this;
        }
        public ExamPage ClickDeleteExamButton(){
            Click(A_DELETE_EXAM);
            return this;
        }
        public ExamPage SearchNewlyAddedExamAndDelete(string exam){
            SearchNewlyAddedExam(exam);
            try{
                Click3Points();
            }catch (Exception e){
                Console.WriteLine("Error:" + e.Message);
                return null;
            }
            ClickDeleteExamButton();
            ClickAreUSure();
            Assert();
            return this;
        }
        public ExamPage SearchNewlyAddedExam(string exam){
            Type(INPUT_SEARCH_BOX, exam);
            Sleepms(1000);
            return this;
        }
        public ExamPage ClickAddNew(){
            Click(BUTTON_ADD_NEW);
            return this;
        }
        public ExamPage EnterName(string name){
            Type(INPUT_NAME, name);
            return this;
        }
        public ExamPage EnterDescription(string description){
            Type(DIV_DESCRIPTION, description);
            return this;
        }
        public ExamPage EnterRepeatNumber(int repeatNumber){
            Type(INPUT_REPEAT_NUMBER, repeatNumber);
            return this;
        }
        public ExamPage SelectCatalogs(string catalog){
            string[] names = catalog.Split(',');
            foreach (var name in names){
                Click(By.XPath("//a[contains(text(), '" + name + "')]"));
            }
            return this;
        }
        public ExamPage ClickNextButton(){
            Click(BUTTON_NEXT);
            return this;
        }
        public ExamPage SetTests(string tests){
            string[] names = tests.Split(',');
            foreach (var name in names){
                SearchTestList(name);
                try{
                    Click(BUTTON_SET_BUTTON_TEST);
                }catch (Exception e){
                    Console.WriteLine("Test not found. " + name + ", exception is: " + e.Message);
                }
            }
            return this;
        }
        public ExamPage SearchTestList(string test){
            Type(INPUT_SEARCH_TEST, test);
            return this;
        }
        public ExamPage ClickSaveButton(){
            Click(BUTTON_SAVE);
            return this;
        }
    }
}
