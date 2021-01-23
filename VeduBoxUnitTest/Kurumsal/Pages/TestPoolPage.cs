using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class TestPoolPage : Page{

        private string USER;
        private readonly By BUTTON_ADD = By.XPath("(//button[@ui-sref='veduBox.testExam.tests.new'])[1]");
        private readonly By INPUT_NAME = By.CssSelector("input[ng-model='test.name']");
        private readonly By DIV_DESCRIPTION = By.CssSelector("textarea[ng-model='test.description']");
        private readonly By INPUT_DURATION = By.CssSelector("input[ng-model='test.duration']");
        private readonly By CHECK_IS_PUBLIC = By.CssSelector("input[ng-model='test.isPublic']");
        private readonly By CHECK_OPTICAL_MARKER = By.CssSelector("input[ng-model='test.opticalMarkerEnabled']");
        private readonly By CHECK_IS_DOCUMENT = By.CssSelector("input[ng-model='test.hasDocument']");
        private readonly By INPUT_CHOOSE_FILE = By.CssSelector("input[ng-model='test.fileName']");
        private readonly By BUTTON_RESOURCE_TYPE_DOC_FILE = By.Id("resourceTypeDocFile");
        private readonly By CHECK_IS_SHUFFLE = By.CssSelector("input[ng-model='test.isShuffleEnabled']");
        private readonly By INPUT_NUMBER_OF_TEST_QUESTIONS = By.CssSelector("input[ng-model='test.numberOfTestQuestions']");
        private readonly By INPUT_EACH_POINT = By.CssSelector("input[ng-model='test.eachQuestionPoint']");
        private readonly By INPUT_NUMBER_OF_CHOICES = By.CssSelector("input[ng-model='test.numberOfQuestionChoices']");
        private readonly By CHECK_IS_RETURN_BETWEEN_QUESTIONS = By.CssSelector("input[ng-model='test.isReturnEnabled']");
        private readonly By INPUT_FIRST_ANSWER = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div/div[2]/div/div[1]/div/div[1]/div/div[16]/div[1]/input");
        private readonly By INPUT_SECOND_ANSWER = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div/div[2]/div/div[1]/div/div[1]/div/div[16]/div[2]/input");
        private readonly By INPUT_THIRD_ANSWER = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div/div[2]/div/div[1]/div/div[1]/div/div[16]/div[3]/input");
        private readonly By INPUT_FOURTH_ANSWER = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div/div[2]/div/div[1]/div/div[1]/div/div[16]/div[4]/input");
        private readonly By INPUT_FIFTH_ANSWER = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div/div[2]/div/div[1]/div/div[1]/div/div[16]/div[5]/input");
        private readonly By INPUT_SIXTH_ANSWER = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div/div[2]/div/div[1]/div/div[1]/div/div[16]/div[6]/input");
        private readonly By INPUT_SEVENTH_ANSWER = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div/div[2]/div/div[1]/div/div[1]/div/div[16]/div[7]/input");
        private readonly By INPUT_EIGHTH_ANSWER = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div/div[2]/div/div[1]/div/div[1]/div/div[16]/div[8]/input");
        private readonly By BUTTON_NEXT = By.XPath("//*[@id='mainSection']/div/div/div[3]/div/div/div[2]/div/div[2]/div/div/button[4]");
        private readonly By INPUT_SEARCH_QUESTION = By.XPath("//*[@id='step2']/div[2]/div[1]/div/div[1]/div[2]/div[6]/input");
        private readonly By BUTTON_SAVE = By.CssSelector("button[ng-click='save()']");
        private readonly By ALERT_SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private readonly By INPUT_SEARCH_BOX = By.CssSelector("input.form-control.vedu-search");
        private readonly By BUTTON_THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private readonly By BUTTON_DELETE_POLL_TEST = By.CssSelector("a[ng-click='delete(test.testId)']");
        private readonly By BUTTON_SET = By.CssSelector("button[ng-click='setSelectedQuestions(question)']");
        private readonly By ALERT_ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        public TestPoolPage(IWebDriver wd, string user) : base(wd){
            USER = user;
        }
        public TestPoolPage ClickAddButton(){
            Click(BUTTON_ADD);
            return this;
        }
        public TestPoolPage EnterName(string name){
            Type(INPUT_NAME, name);
            return this;
        }
        public TestPoolPage EnterDescription(string description){
            Type(DIV_DESCRIPTION, description);
            return this;
        }
        public TestPoolPage EnterDuration(int duration){
            Type(INPUT_DURATION, duration);
            return this;
        }
        public TestPoolPage SelectIsPublic(){
            if (IsSelected(CHECK_IS_PUBLIC) == false)
                Click(CHECK_IS_PUBLIC);
            return this;
        }
        public TestPoolPage SelectIsOpticalMarker(){
            if (IsSelected(CHECK_OPTICAL_MARKER) == false)
                Click(CHECK_OPTICAL_MARKER);
            return this;
        }
        public TestPoolPage SelectIsDocument(){
            if (IsSelected(CHECK_IS_DOCUMENT) == false)
                Click(CHECK_IS_DOCUMENT);
            return this;
        }
        public TestPoolPage ClickSetButton(){
            Click(BUTTON_SET);
            return this;
        }
        public TestPoolPage SelectFile(){
            Type(
                INPUT_CHOOSE_FILE,
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Docs\\file.png"))
            );
            return this;
        }
        public TestPoolPage SelectIsShuffle(){
            if (IsSelected(CHECK_IS_SHUFFLE) == false)
                Click(CHECK_IS_SHUFFLE);
            return this;
        }
        public TestPoolPage EnterQuestionNumber(int questionNumber){
            Type(INPUT_NUMBER_OF_TEST_QUESTIONS, questionNumber);
            return this;
        }
        public TestPoolPage EnterPointsofEach(int points){
            Type(INPUT_EACH_POINT, points);
            return this;
        }
        public TestPoolPage ClickIsReturnBetweenQuestions(){
            if (IsSelected(CHECK_IS_RETURN_BETWEEN_QUESTIONS) == false)
                Click(CHECK_IS_RETURN_BETWEEN_QUESTIONS);
            return this;
        }
        public TestPoolPage EnterNumberOfChoices(int choicesNumber){
            Type(INPUT_NUMBER_OF_CHOICES, choicesNumber);
            return this;
        }
        public TestPoolPage EnterFirstAnswer(string firstAnswer) {
            Type(INPUT_FIRST_ANSWER, firstAnswer);
            return this;
        }
        public TestPoolPage EnterSecondAnswer(string secondAnswer){
            Type(INPUT_SECOND_ANSWER, secondAnswer);
            return this;
        }
        public TestPoolPage EnterThirdAnswer(string thirdAnswer){
            Type(INPUT_THIRD_ANSWER, thirdAnswer);
            return this;
        }
        public TestPoolPage EnterFourthAnswer(string fourthAnswer){
            Type(INPUT_FOURTH_ANSWER, fourthAnswer);
            return this;
        }
        public TestPoolPage EnterFifthAnswer(string fifthAnswer){
            Type(INPUT_FIFTH_ANSWER, fifthAnswer);
            return this;
        }
        public TestPoolPage EnterSixthAnswer(string sixthAnswer){
            Type(INPUT_SIXTH_ANSWER, sixthAnswer);
            return this;
        }
        public TestPoolPage EnterSeventhAnswer(string seventhAnswer){
            Type(INPUT_SEVENTH_ANSWER, seventhAnswer);
            return this;
        }
        public TestPoolPage EnterEighthAnswer(string eighthAnswer){
            Type(INPUT_EIGHTH_ANSWER, eighthAnswer);
            return this;
        }
        public TestPoolPage SelectTestCategory(string testCategories){
            string[] names = testCategories.Split(',');
            foreach (var name in names){
                Click(By.XPath("//a[contains(text(), '" + name + "')]"));
            }
            return this;
        }
        public TestPoolPage ClickSaveButton(){
            Click(BUTTON_SAVE);
            return this;
        }
        public TestPoolPage Assert(){
            AssertionCustom.AssertElementVisible("Element Not Found", Driver, ALERT_SUCCESS);
            return this;
        }
        public TestPoolPage EnterQuestionName(string name){
            Type(INPUT_SEARCH_QUESTION, name);
            return this;
        }
        public TestPoolPage SearchNewlyAddedPollTestByName(string name){
            Type(INPUT_SEARCH_BOX, name);
            Sleepms(1000);
            return this;
        }
        public TestPoolPage ClickThreePoints(){
            Click(BUTTON_THREE_POINTS);
            return this;
        }
        public TestPoolPage ClickNextButton(){
            Click(BUTTON_NEXT);
            return this;
        }
        public TestPoolPage ClickDeleteTest(){
            Click(BUTTON_DELETE_POLL_TEST);
            return this;
        }
        public TestPoolPage ClickAreUSure(){
            Click(ALERT_ARE_U_SURE_OK);
            return this;
        }
        public TestPoolPage ClearSearchBox(){
            Clear(INPUT_SEARCH_BOX);
            return this;
        }
        public TestPoolPage SearchNewlyAddedPollTestByNameAndDeleteIt(string name){
            SearchNewlyAddedPollTestByName(name);
            try{
                ClickThreePoints();
            }catch (Exception e){
                Console.WriteLine("Error:" + e.Message);
                return null;
            }
            ClickDeleteTest();
            ClickAreUSure();
            Assert();
            return this;
        }
    }
}