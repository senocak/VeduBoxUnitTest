using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class TestsPage : Page{
        private static string _user;
        private static By NAME = By.CssSelector("input[ng-model='test.name']");
        private static By TIME = By.CssSelector("input[ng-model='test.duration']");
        private static By IS_PUBLIC_INPUT = By.CssSelector("input[ng-model='test.isPublic']");
        private static By IS_ANSWER_OPTICAL_MARKER = By.CssSelector("input[ng-model='test.opticalMarkerEnabled']");
        private static By IS_RETURN_BETWEEN_QUESTIONS = By.CssSelector("input[ng-model='test.isReturnEnabled']");
        private static By NEXT_BUTTON = By.XPath("//*[@id='mainSection']/div/div/div[3]/div/div/div[2]/div/div[2]/div/div/button[4]");
        private static By SEARCH_QUESTION_INPUT = By.XPath("//*[@id='step2']/div[2]/div[1]/div/div[1]/div[2]/div[6]/input");
        private static By SET_BUTTON = By.CssSelector("button[ng-click='setSelectedQuestions(question)']");
        private static By SUBMIT_BUTTON = By.CssSelector("button[ng-click='save()']");
        private static By SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private static By SEARCH_TEST_INPUT = By.CssSelector("input[ng-model='filter.$']");
        private static By THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private static By DELETE_COURSE = By.CssSelector("a[ng-click='delete(test.testId)']");
        private static By ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private static By ADD_NEW_BUTTON = By.CssSelector("button[ui-sref='veduBox.testExam.tests.new']");
        public TestsPage(IWebDriver wd, string user) : base(wd){
            _user = user;
        }
        public TestsPage clickAddButton(){
            click(ADD_NEW_BUTTON);
            return this;
        }
        public TestsPage enterName(String name){
            type(NAME, name);
            return this;
        }
        public TestsPage enterTime(int time){
            type(TIME, time);
            return this;
        }
        public TestsPage clickIsPublic(){
            if (isSelected(IS_PUBLIC_INPUT) == false)
                click(IS_PUBLIC_INPUT);
            return this;
        }
        public TestsPage clickIsAnswerSheetEnabled(){
            if (isSelected(IS_ANSWER_OPTICAL_MARKER) == false)
                click(IS_ANSWER_OPTICAL_MARKER);
            return this;
        }
        public TestsPage clickIsReturnBetweenQuestions(){
            if (isSelected(IS_RETURN_BETWEEN_QUESTIONS) == false)
                click(IS_RETURN_BETWEEN_QUESTIONS);
            return this;
        }
        public TestsPage selectTestCategory(string testCategories){
            string[] names = testCategories.Split(',');
            foreach (var name in names){
                click(By.XPath("//a[contains(text(), '" + name + "')]"));
            }
            return this;
        }
        public TestsPage clickNextButton(){
            click(NEXT_BUTTON);
            return this;
        }
        public TestsPage enterQuestionName(string name){
            type(SEARCH_QUESTION_INPUT, name);
            return this;
        }
        public TestsPage clickSetButton(){
            click(SET_BUTTON);
            return this;
        }
        public TestsPage submit(){
            click(SUBMIT_BUTTON);
            return this;
        }
        public TestsPage assert(){
            AssertionCustom.assertElementVisible("Element Not Found", driver, SUCCESS);
            return this;
        }
        public TestsPage enterSearchTest(string name){
            type(SEARCH_TEST_INPUT, name);
            return this;
        }
        public TestsPage deleteNewlyAddedTest(){
            click(THREE_POINTS);
            click(DELETE_COURSE);
            click(ARE_U_SURE_OK);
            return this;
        }
    }
}
