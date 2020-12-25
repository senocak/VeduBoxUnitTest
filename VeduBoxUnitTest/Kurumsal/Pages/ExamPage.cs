using OpenQA.Selenium;
using System;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages
{
    class ExamPage : Page{
        private static readonly By SEARCH_BOX = By.CssSelector("input.form-control.vedu-search");
        private static readonly By THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private static readonly By DELETE_EXAM = By.CssSelector("a[ng-click='delete(exam.id)']");
        private static readonly By ADD_NEW = By.CssSelector("button[ui-sref='veduBox.teacher.me.exams.new']");
        private static readonly By NAME = By.CssSelector("input[ng-model='exam.name']");
        private static readonly By DESCRIPTION = By.CssSelector("div[ng-model='html']");
        private static readonly By NEXT_BUTTON = By.CssSelector("button[ng-click='goToStep(2)']");
        private static readonly By SEARCH_TEST_INPUT = By.XPath("//*[@id='step2']/div/div[1]/div/div[1]/div[2]/div[4]/input");
        private static readonly By SET_BUTTON_TEST = By.CssSelector("button[ng-click='setSelectedTests(test)']");
        private static readonly By SAVE_BUTTON = By.CssSelector("button[ng-click='goToStep(3)']");
        private static readonly By REPEAT_NUMBER = By.CssSelector("input[ng-model='exam.repeatNumber']");
        private static readonly By SELECT_FIRST_EXAM = By.XPath("//*[@id='student_my_exam']/div[2]/div/div/div/div[1]/div/div[1]/table/tbody/tr[1]/td[7]/button");
        private static readonly By START_EXAM_BUTTON = By.CssSelector("button[ng-click='gotoStep(2)']");
        private static readonly By FINISH_EXAM_BUTTON = By.CssSelector("button[ng-click='FinishExam()']");
        private static readonly By SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private static readonly By ARE_U_SURE_OK = By.CssSelector("button.msc-ok");

        private static string _user;
        public ExamPage(IWebDriver wd, string user) : base(wd){
            _user = user;
        }
        public ExamPage getFirstExam(){
            click(SELECT_FIRST_EXAM);
            return this;
        }
        public ExamPage clickStartExamButton(){
            click(START_EXAM_BUTTON);
            return this;
        }
        public ExamPage clickFinishExamButton(){
            click(FINISH_EXAM_BUTTON);
            return this;
        }
        public ExamPage assert(){
            AssertionCustom.assertElementVisible("Element Not Found", driver, SUCCESS);
            return this;
        }
        public ExamPage clickAreUSure(){
            click(ARE_U_SURE_OK);
            return this;
        }
        public ExamPage click3Points(){
            click(THREE_POINTS);
            return this;
        }
        public ExamPage clickDeleteExamButton(){
            click(DELETE_EXAM);
            return this;
        }
        public ExamPage searchNewlyAddedExamAndDelete(string exam){
            searchNewlyAddedExam(exam);
            try{
                click3Points();
            }catch (Exception e){
                Console.WriteLine("Error:" + e.Message);
                return null;
            }
            clickDeleteExamButton();
            clickAreUSure();
            assert();
            return this;
        }
        public ExamPage searchNewlyAddedExam(string exam){
            type(SEARCH_BOX, exam);
            sleepms(1000);
            return this;
        }
        public ExamPage clickAddNew(){
            click(ADD_NEW);
            return this;
        }
        public ExamPage enterName(string name){
            type(NAME, name);
            return this;
        }
        public ExamPage enterDescription(string description){
            type(DESCRIPTION, description);
            return this;
        }
        public ExamPage enterRepeatNumber(int repeatNumber)
        {
            type(REPEAT_NUMBER, repeatNumber);
            return this;
        }
        public ExamPage selectCatalogs(string catalog){
            string[] names = catalog.Split(',');
            foreach (var name in names){
                click(By.XPath("//a[contains(text(), '" + name + "')]"));
            }
            return this;
        }
        public ExamPage clickNextButton(){
            click(NEXT_BUTTON);
            return this;
        }
        public ExamPage setTests(string tests){
            string[] names = tests.Split(',');
            foreach (var name in names){
                searchTestList(name);
                try{
                    click(SET_BUTTON_TEST);
                }catch (Exception e){
                    Console.WriteLine("Test not found. " + name + ", exception is: " + e.Message);
                }
            }
            return this;
        }
        public ExamPage searchTestList(string test){
            type(SEARCH_TEST_INPUT, test);
            return this;
        }
        public ExamPage clickSaveButton(){
            click(SAVE_BUTTON);
            return this;
        }
    }
}
