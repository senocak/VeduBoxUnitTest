using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeduBoxUnitTest.Assertion;
using OpenQA.Selenium.Support.Extensions;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class QuestionsPage : Page{

        private static string _user;
        private IWebDriver _driver;
        private IJavaScriptExecutor _js;
        private static By ADD_NEW_QUESTION_BUTTON = By.CssSelector("button[ui-sref='veduBox.testExam.questions.new']");
        private static By BATCH_CREATE_QUESTION_BUTTON = By.CssSelector("button[ui-sref='veduBox.testExam.questions.batchCreate']");
        private static By QUESTION_INPUT = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div[2]/div[2]/form/div[1]/div[2]/div/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private static By POINT_INPUT = By.Id("teacherQuesPoolPoint");
        private static By DELETE_CHOICE_5 = By.XPath("(//*[@id='teacherQuesPoolChoiceAnsDel'])[5]");
        private static By ANSWER_A_INPUT = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div[2]/div[2]/form/div[1]/div[12]/div/div/div[2]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private static By ANSWER_B_INPUT = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div[2]/div[2]/form/div[1]/div[12]/div/div/div[3]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private static By ANSWER_C_INPUT = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div[2]/div[2]/form/div[1]/div[12]/div/div/div[4]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private static By ANSWER_D_INPUT = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div[2]/div[2]/form/div[1]/div[12]/div/div/div[5]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private static By RIGHT_ANSWER_INPUT = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div[2]/div[2]/form/div[1]/div[12]/div/div/div[4]/div/div[1]/div/label/input");
        private static By IS_PUBLIC_INPUT = By.Id("teacherQuesPoolPublic");
        private static By IS_EDITABLE_INPUT= By.Id("teacherQuesPoolEdit");
        private static By SUBMIT_BUTTON= By.Id("teacherQuesPoolSaveBtn");
        private static By SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private static By SEARCH_BOX = By.CssSelector("input.form-control.vedu-search");
        private static By THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private static By DELETE_SINGLE_QUESTION_POPUP = By.CssSelector("a[ng-click='delete(question.questionId)']");
        private static By QUESTION_TYPE = By.Id("teacherQuesPoolTypeQues");
        private static By ANSWER_TRUE = By.XPath("(//*[@id='teacherQuesPoolChoiceCorrectAns'])[1]");
        private static By ANSWER_FALSE = By.XPath("(//*[@id='teacherQuesPoolChoiceCorrectAns'])[2]");
        private static By BATCH_FILE_INPUT = By.Id("html_btn");
        private static By UPLOAD_EXCEL_BUTTON = By.CssSelector("button[ng-click='uploadFile()']");
        private static By QUESTION_LIST_ACCEPT_BUTTON = By.CssSelector("a[ng-click='accept()']");
        private static readonly By MATCHING_INPUT_1 = By.XPath("//*[@id='questionForm']/div[1]/div[12]/div/div/div[2]/div/div[3]/textarea");
        private static readonly By MATCHING_INPUT_2 = By.XPath("//*[@id='questionForm']/div[1]/div[12]/div/div/div[3]/div/div[3]/textarea");
        private static readonly By MATCHING_INPUT_3_DELETE_BUTTON = By.XPath("(//*[@id='teacherQuesPoolChoiceAnsDel'])[3]");
        private static readonly By MULTIPLE_CHOICE_ANSWER1_INPUT = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div[2]/div[2]/form/div[1]/div[12]/div/div/div[2]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private static readonly By MULTIPLE_CHOICE_ANSWER2_INPUT = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div[2]/div[2]/form/div[1]/div[12]/div/div/div[3]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private static readonly By MULTIPLE_CHOICE_ANSWER3_INPUT = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div[2]/div[2]/form/div[1]/div[12]/div/div/div[4]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");

        public QuestionsPage(IWebDriver wd, string user) : base(wd) {
            _user = user;
            _driver = wd;
            _js = (IJavaScriptExecutor)_driver;
        }
        public QuestionsPage clickAddNewButton(){
            click(ADD_NEW_QUESTION_BUTTON);
            return this;
        }
        public QuestionsPage enterExcelFile(){
            _js.ExecuteScript("document.getElementById('html_btn').style.display = 'block';");
            type(
                BATCH_FILE_INPUT,
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Docs\\soru_yukleme_excel.xlsx"))
            );
            return this;
        }
        public QuestionsPage clickUploadExcelButton() {
            click(UPLOAD_EXCEL_BUTTON);
            return this;
        }
        public QuestionsPage clickBatchCreateButton(){
            click(BATCH_CREATE_QUESTION_BUTTON);
            return this;
        }
        public QuestionsPage clickQuestionListAcceptButton(){
            click(QUESTION_LIST_ACCEPT_BUTTON);
            return this;
        }
        public QuestionsPage refreshPage(){
            _driver.Navigate().Refresh();
            return this;
        }
        public QuestionsPage typeQuestionInput(string question){
            type(QUESTION_INPUT, question);
            return this;
        }
        public QuestionsPage enterPoint(int point){
            type(POINT_INPUT, point);
            return this;
        }
        public QuestionsPage clickDeleteButtonLastElementOfAnswers(){
            click(DELETE_CHOICE_5);
            return this;
        }
        public QuestionsPage selectQuestionType(string type){
            selectDropDown(QUESTION_TYPE, type);
            return this;
        }
        public QuestionsPage selectTrueFalseAnswer(bool answer){
            if (answer == true) click(ANSWER_TRUE);
            if (answer == false) click(ANSWER_FALSE);
            return this;
        }
        public QuestionsPage enterAnswerA(string answer){
            type(ANSWER_A_INPUT, answer);
            return this;
        }
        public QuestionsPage enterAnswerB(string answer){
            type(ANSWER_B_INPUT, answer);
            return this;
        }
        public QuestionsPage enterAnswerC(string answer){
            type(ANSWER_C_INPUT, answer);
            return this;
        }
        public QuestionsPage enterAnswerD(string answer){
            type(ANSWER_D_INPUT, answer);
            return this;
        }
        public QuestionsPage clickRigthAnswerAsC(){
            click(RIGHT_ANSWER_INPUT);
            return this;
        }
        public QuestionsPage clickIsPublic(){
            if (isSelected(IS_PUBLIC_INPUT) == false)
                click(IS_PUBLIC_INPUT);
            return this;
        }
        public QuestionsPage clickIsEDITABLE(){
            if (isSelected(IS_EDITABLE_INPUT) == false)
                click(IS_EDITABLE_INPUT);
            return this;
        }
        public QuestionsPage selectTestCategory(string testCategories){
            string[] names = testCategories.Split(',');
            foreach (var name in names){
                click(By.XPath("//a[contains(text(), '" + name + "')]"));
            }
            return this;
        }
        public QuestionsPage submit(){
            click(SUBMIT_BUTTON);
            return this;
        }
        public QuestionsPage assert(){
            AssertionCustom.assertElementVisible("Element Not Found", driver, SUCCESS);
            return this;
        }
        public QuestionsPage searchNewlyAddedQuestionByNameAndDeleteIt(string name){
            searchNewlyAddedQuestionByName(name);
            try{
                clickThreePoints();
            }catch (Exception e){
                Console.WriteLine("Error while clicking 3dots. Looks like there is no record. Returning null." + e.Message);
                return null;
            }
            clickDeleteSingleQuestionPopup();
            assert();
            return this;
        }
        public QuestionsPage searchNewlyAddedQuestionByName(string name){
            type(SEARCH_BOX, name);
            sleepms(1000);
            return this;
        }
        public QuestionsPage clickThreePoints(){
            click(THREE_POINTS);
            return this;
        }
        public QuestionsPage clickDeleteSingleQuestionPopup(){
            click(DELETE_SINGLE_QUESTION_POPUP);
            return this;
        }
        public QuestionsPage enterMatching1(string value){
            type(MATCHING_INPUT_1, value);
            return this;
        }
        public QuestionsPage enterMatching2(string value){
            type(MATCHING_INPUT_2, value);
            return this;
        }
        public QuestionsPage delete3thMatchingInput(){
            click(MATCHING_INPUT_3_DELETE_BUTTON);
            return this;
        }
        public QuestionsPage answer1ForMultipleChoice(string answer){
            type(MULTIPLE_CHOICE_ANSWER1_INPUT, answer);
            return this;
        }
        public QuestionsPage answer2ForMultipleChoice(string answer){
            type(MULTIPLE_CHOICE_ANSWER2_INPUT, answer);
            return this;
        }
        public QuestionsPage answer3ForMultipleChoice(string answer){
            type(MULTIPLE_CHOICE_ANSWER3_INPUT, answer);
            return this;
        }

        
    }
}
