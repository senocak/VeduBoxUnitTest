using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class PoolTestsPage : Page{
        private static string _user;
        private static By ADD_BUTTON = By.XPath("(//button[@ui-sref='veduBox.testExam.tests.new'])[1]");
        private static By NAME = By.CssSelector("input[ng-model='test.name']");
        private static By DESCRIPTION = By.CssSelector("textarea[ng-model='test.description']");
        private static By DURATION = By.CssSelector("input[ng-model='test.duration']");
        private static By IS_PUBLIC = By.CssSelector("input[ng-model='test.isPublic']");
        private static By OPTICAL_MARKER = By.CssSelector("input[ng-model='test.opticalMarkerEnabled']");
        private static By IS_DOCUMENT = By.CssSelector("input[ng-model='test.hasDocument']");
        private static By CHOOSE_FILE = By.CssSelector("input[ng-model='test.fileName']");
        private static By RESOURCE_TYPE_DOC_FILE = By.Id("resourceTypeDocFile");
        private static By IS_SHUFFLE = By.CssSelector("input[ng-model='test.isShuffleEnabled']");
        private static By NUMBER_OF_TESTQUESTIONS = By.CssSelector("input[ng-model='test.numberOfTestQuestions']");
        private static By EACH_POINT = By.CssSelector("input[ng-model='test.eachQuestionPoint']");
        private static By NUMBER_OF_CHOICES = By.CssSelector("input[ng-model='test.numberOfQuestionChoices']");
        private static By FIRST_ANSWER = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div/div[2]/div/div[1]/div/div[1]/div/div[16]/div[1]/input");
        private static By SECOND_ANSWER = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div/div[2]/div/div[1]/div/div[1]/div/div[16]/div[2]/input");
        private static By THIRD_ANSWER = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div/div[2]/div/div[1]/div/div[1]/div/div[16]/div[3]/input");
        private static By FOURTH_ANSWER = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div/div[2]/div/div[1]/div/div[1]/div/div[16]/div[4]/input");
        private static By FIFTH_ANSWER = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div/div[2]/div/div[1]/div/div[1]/div/div[16]/div[5]/input");
        private static By SIXTH_ANSWER = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div/div[2]/div/div[1]/div/div[1]/div/div[16]/div[6]/input");
        private static By SEVENTH_ANSWER = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div/div[2]/div/div[1]/div/div[1]/div/div[16]/div[7]/input");
        private static By EIGHTH_ANSWER = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div/div[2]/div/div[1]/div/div[1]/div/div[16]/div[8]/input");
        private static By CATEGORY = By.XPath("//a[@class='jstree-anchor'][contains(text(),'BurakTestKategori')]");
        private static By SAVE_BUTTON = By.CssSelector("button[ng-click='save()']");
        private static By SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private static By SEARCH_BOX = By.CssSelector("input.form-control.vedu-search");
        private static By THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private static By DELETE_POLLTEST = By.CssSelector("a[ng-click='delete(test.testId)']");
        private static By ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        public PoolTestsPage(IWebDriver wd, string user) : base(wd){
            _user = user;
        }
        public PoolTestsPage clickAddButton(){
            click(ADD_BUTTON);
            return this;
        }
        public PoolTestsPage enterName(string Name){
            type(NAME, Name);
            return this;
        }
        public PoolTestsPage enterDescription(string Description){
            type(DESCRIPTION, Description);
            return this;
        }
        public PoolTestsPage enterDuration(int Duration){
            type(DURATION, Duration);
            return this;
        }
        public PoolTestsPage selectIsPublic(){
            if (isSelected(IS_PUBLIC) == false)
                click(IS_PUBLIC);
            return this;
        }
        public PoolTestsPage selectIsOpticalMarker(){
            if (isSelected(OPTICAL_MARKER) == false)
                click(OPTICAL_MARKER);
            return this;
        }
        public PoolTestsPage selectIsDocument(){
            if (isSelected(IS_DOCUMENT) == false)
                click(IS_DOCUMENT);
            return this;
        }
        public PoolTestsPage selectFile(){
            type(
                CHOOSE_FILE,
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Docs\\file.png"))
            );
            return this;
        }
        public PoolTestsPage selectIsShuffle(){
            if (isSelected(IS_SHUFFLE) == false)
                click(IS_SHUFFLE);
            return this;
        }
        public PoolTestsPage enterQuestionNumber(int questionNumber){
            type(NUMBER_OF_TESTQUESTIONS, questionNumber);
            return this;
        }
        public PoolTestsPage enterPointsofEach(int points){
            type(EACH_POINT, points);
            return this;
        }

        public PoolTestsPage enterNumberOfChoices(int choicesNumber){
            type(NUMBER_OF_CHOICES, choicesNumber);
            return this;
        }
        public PoolTestsPage enterFirstAnswer(string firstAnswer) {
            type(FIRST_ANSWER, firstAnswer);
            return this;
        }
        public PoolTestsPage enterSecondAnswer(string secondAnswer){
            type(SECOND_ANSWER, secondAnswer);
            return this;
        }
        public PoolTestsPage enterThirdAnswer(string thirdAnswer){
            type(THIRD_ANSWER, thirdAnswer);
            return this;
        }
        public PoolTestsPage enterFourthAnswer(string fourthAnswer){
            type(FOURTH_ANSWER, fourthAnswer);
            return this;
        }
        public PoolTestsPage enterFifthAnswer(string fifthAnswer){
            type(FIFTH_ANSWER, fifthAnswer);
            return this;
        }
        public PoolTestsPage enterSixthAnswer(string sixthAnswer){
            type(SIXTH_ANSWER, sixthAnswer);
            return this;
        }
        public PoolTestsPage enterSeventhAnswer(string seventhAnswer){
            type(SEVENTH_ANSWER, seventhAnswer);
            return this;
        }
        public PoolTestsPage enterEighthAnswer(string eighthAnswer){
            type(EIGHTH_ANSWER, eighthAnswer);
            return this;
        }
        public PoolTestsPage selectCategory(){
            click(CATEGORY);
            return this;
        }
        public PoolTestsPage clickSaveButton(){
            click(SAVE_BUTTON);
            return this;
        }
        public PoolTestsPage assert(){
            AssertionCustom.assertElementVisible("Element Not Found", driver, SUCCESS);
            return this;
        }
        public PoolTestsPage searchNewlyAddedPollTestByName(string Name){
            type(SEARCH_BOX, Name);
            sleepms(1000);
            return this;
        }
        public PoolTestsPage clickThreePoints(){
            click(THREE_POINTS);
            return this;
        }
        public PoolTestsPage clickDelete()
        {

            click(DELETE_POLLTEST);
            return this;
        }
        public PoolTestsPage clickAreYouSureOK(){
            click(ARE_U_SURE_OK);
            return this;
        }
        public PoolTestsPage clearSearchBox(){
            clear(SEARCH_BOX);
            return this;
        }
        public PoolTestsPage searchNewlyAddedPollTestByNameAndDeleteIt(string Name){
            searchNewlyAddedPollTestByName(Name);
            try{
                clickThreePoints();
            }catch (Exception e){
                Console.WriteLine("Error:" + e.Message);
                return null;
            }
            clickDelete();
            clickAreYouSureOK();
            assert();
            return this;
        }

    }
}
