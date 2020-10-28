using OpenQA.Selenium;
using System;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages
{
    class ExamPage : Page
    {
        private static By SELECT_FIRST_EXAM = By.XPath("//*[@id='student_my_exam']/div[2]/div/div/div/div[1]/div/div[1]/table/tbody/tr[1]/td[7]/button");
        private static By START_EXAM_BUTTON = By.CssSelector("button[ng-click='gotoStep(2)']");
        private static By FINISH_EXAM_BUTTON = By.CssSelector("button[ng-click='FinishExam()']");
        private static By SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private static By ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
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

        public ExamPage clickAreYouSure(){
            click(ARE_U_SURE_OK);
            return this;
        }
    }
}
