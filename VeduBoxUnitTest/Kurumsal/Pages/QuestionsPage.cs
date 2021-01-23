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

        private string USER;
        private IWebDriver _driver;
        private IJavaScriptExecutor JS_EXECUTOR;
        private readonly By BUTTON_ADD_NEW_QUESTION = By.CssSelector("button[ui-sref='veduBox.testExam.questions.new']");
        private readonly By BUTTON_BATCH_CREATE_QUESTION = By.CssSelector("button[ui-sref='veduBox.testExam.questions.batchCreate']");
        private readonly By INPUT_QUESTION = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div[2]/div[2]/form/div[1]/div[2]/div/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private readonly By INPUT_POINT = By.Id("teacherQuesPoolPoint");
        private readonly By BUTTON_DELETE_CHOICE_5 = By.XPath("(//*[@id='teacherQuesPoolChoiceAnsDel'])[5]");
        private readonly By INPUT_ANSWER_A = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div[2]/div[2]/form/div[1]/div[12]/div/div/div[2]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private readonly By INPUT_ANSWER_B = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div[2]/div[2]/form/div[1]/div[12]/div/div/div[3]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private readonly By INPUT_ANSWER_C = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div[2]/div[2]/form/div[1]/div[12]/div/div/div[4]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private readonly By INPUT_ANSWER_D = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div[2]/div[2]/form/div[1]/div[12]/div/div/div[5]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private readonly By INPUT_RIGHT_ANSWER = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div[2]/div[2]/form/div[1]/div[12]/div/div/div[4]/div/div[1]/div/label/input");
        private readonly By INPUT_IS_PUBLIC = By.Id("teacherQuesPoolPublic");
        private readonly By INPUT_IS_EDITABLE = By.Id("teacherQuesPoolEdit");
        private readonly By BUTTON_SUBMIT = By.Id("teacherQuesPoolSaveBtn");
        private readonly By ALERT_SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private readonly By INPUT_SEARCH_BOX = By.CssSelector("input.form-control.vedu-search");
        private readonly By BUTTON_THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private readonly By BUTTON_DELETE_SINGLE_QUESTION_POPUP = By.CssSelector("a[ng-click='delete(question.questionId)']");
        private readonly By BUTTON_QUESTION_TYPE = By.Id("teacherQuesPoolTypeQues");
        private readonly By INPUT_ANSWER_TRUE = By.XPath("(//*[@id='teacherQuesPoolChoiceCorrectAns'])[1]");
        private readonly By INPUT_ANSWER_FALSE = By.XPath("(//*[@id='teacherQuesPoolChoiceCorrectAns'])[2]");
        private readonly By INPUT_BATCH_FILE = By.Id("html_btn");
        private readonly By BUTTON_UPLOAD_EXCEL = By.CssSelector("button[ng-click='uploadFile()']");
        private readonly By BUTTON_QUESTION_LIST_ACCEPT = By.CssSelector("a[ng-click='accept()']");
        private readonly By INPUT_MATCHING_1 = By.XPath("//*[@id='questionForm']/div[1]/div[12]/div/div/div[2]/div/div[3]/textarea");
        private readonly By BUTTON_MATCHING_2 = By.XPath("//*[@id='questionForm']/div[1]/div[12]/div/div/div[3]/div/div[3]/textarea");
        private readonly By BUTTON_MATCHING_INPUT_3_DELETE = By.XPath("(//*[@id='teacherQuesPoolChoiceAnsDel'])[3]");
        private readonly By INPUT_ORDERING_1 = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div[2]/div[2]/form/div[1]/div[12]/div/div/div[2]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private readonly By INPUT_ORDERING_2 = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div[2]/div[2]/form/div[1]/div[12]/div/div/div[3]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private readonly By INPUT_ORDERING_3 = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div[2]/div[2]/form/div[1]/div[12]/div/div/div[4]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private readonly By BUTTON_ORDERING_ADD = By.CssSelector("button[ng-click*='addChoice']");
        private readonly By INPUT_ORDERING_4 = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div[2]/div[2]/form/div[1]/div[12]/div/div/div[5]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private readonly By INPUT_MULTIPLE_CHOICE_ANSWER1 = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div[2]/div[2]/form/div[1]/div[12]/div/div/div[2]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private readonly By INPUT_MULTIPLE_CHOICE_ANSWER2 = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div[2]/div[2]/form/div[1]/div[12]/div/div/div[3]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private readonly By INPUT_MULTIPLE_CHOICE_ANSWER3 = By.XPath("/html/body/div[3]/div/section/div/div/div[3]/div/div[2]/div[2]/form/div[1]/div[12]/div/div/div[4]/div/div[2]/vedu-box-text-angular/text-angular/div[2]/div[3]");

        public QuestionsPage(IWebDriver wd, string user) : base(wd) {
            USER = user;
            _driver = wd;
            JS_EXECUTOR = (IJavaScriptExecutor)_driver;
        }
        public QuestionsPage ClickAddNewButton(){
            Click(BUTTON_ADD_NEW_QUESTION);
            return this;
        }
        public QuestionsPage EnterExcelFile(){
            JS_EXECUTOR.ExecuteScript("document.getElementById('html_btn').style.display = 'block';");
            Type(
                INPUT_BATCH_FILE,
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Docs\\soru_yukleme_excel.xlsx"))
            );
            return this;
        }
        public QuestionsPage ClickUploadExcelButton() {
            Click(BUTTON_UPLOAD_EXCEL);
            return this;
        }
        public QuestionsPage ClickBatchCreateButton(){
            Click(BUTTON_BATCH_CREATE_QUESTION);
            return this;
        }
        public QuestionsPage ClickQuestionListAcceptButton(){
            Click(BUTTON_QUESTION_LIST_ACCEPT);
            return this;
        }
        public QuestionsPage RefreshPage(){
            _driver.Navigate().Refresh();
            return this;
        }
        public QuestionsPage TypeQuestionInput(string question){
            Type(INPUT_QUESTION, question);
            return this;
        }
        public QuestionsPage EnterPoint(int point){
            Type(INPUT_POINT, point);
            return this;
        }
        public QuestionsPage ClickDeleteButtonLastElementOfAnswers(){
            Click(BUTTON_DELETE_CHOICE_5);
            return this;
        }
        public QuestionsPage SelectQuestionType(string type){
            SelectDropDown(BUTTON_QUESTION_TYPE, type);
            return this;
        }
        public QuestionsPage SelectTrueFalseAnswer(bool answer){
            if (answer == true) Click(INPUT_ANSWER_TRUE);
            if (answer == false) Click(INPUT_ANSWER_FALSE);
            return this;
        }
        public QuestionsPage EnterAnswerA(string answer){
            Type(INPUT_ANSWER_A, answer);
            return this;
        }
        public QuestionsPage EnterAnswerB(string answer){
            Type(INPUT_ANSWER_B, answer);
            return this;
        }
        public QuestionsPage EnterAnswerC(string answer){
            Type(INPUT_ANSWER_C, answer);
            return this;
        }
        public QuestionsPage EnterAnswerD(string answer){
            Type(INPUT_ANSWER_D, answer);
            return this;
        }
        public QuestionsPage ClickRigthAnswerAsC(){
            Click(INPUT_RIGHT_ANSWER);
            return this;
        }
        public QuestionsPage ClickIsPublic(){
            if (IsSelected(INPUT_IS_PUBLIC) == false)
                Click(INPUT_IS_PUBLIC);
            return this;
        }
        public QuestionsPage ClickIsEditable(){
            if (IsSelected(INPUT_IS_EDITABLE) == false)
                Click(INPUT_IS_EDITABLE);
            return this;
        }
        public QuestionsPage SelectTestCategory(string testCategories){
            string[] names = testCategories.Split(',');
            foreach (var name in names){
                Click(By.XPath("//a[contains(text(), '" + name + "')]"));
            }
            return this;
        }
        public QuestionsPage Submit(){
            Click(BUTTON_SUBMIT);
            return this;
        }
        public QuestionsPage Assert(){
            AssertionCustom.AssertElementVisible("Element Not Found", Driver, ALERT_SUCCESS);
            return this;
        }
        public QuestionsPage SearchNewlyAddedQuestionByNameAndDeleteIt(string name){
            SearchNewlyAddedQuestionByName(name);
            try{
                ClickThreePoints();
            }catch (Exception e){
                Console.WriteLine("Error while clicking 3dots. Looks like there is no record. Returning null." + e.Message);
                return null;
            }
            ClickDeleteSingleQuestionPopup();
            Assert();
            return this;
        }
        public QuestionsPage SearchNewlyAddedQuestionByName(string name){
            Type(INPUT_SEARCH_BOX, name);
            Sleepms(1000);
            return this;
        }
        public QuestionsPage ClickThreePoints(){
            Click(BUTTON_THREE_POINTS);
            return this;
        }
        public QuestionsPage ClickDeleteSingleQuestionPopup(){
            Click(BUTTON_DELETE_SINGLE_QUESTION_POPUP);
            return this;
        }
        public QuestionsPage EnterMatching1(string value){
            Type(INPUT_MATCHING_1, value);
            return this;
        }
        public QuestionsPage EnterMatching2(string value){
            Type(BUTTON_MATCHING_2, value);
            return this;
        }
        public QuestionsPage EnterOrdering1(string value){
            Type(INPUT_ORDERING_1, value);
            return this;
        }
        public QuestionsPage EnterOrdering2(string value){
            Type(INPUT_ORDERING_2, value);
            return this;
        }
        public QuestionsPage EnterOrdering3(string value) {
            Type(INPUT_ORDERING_3, value);
            return this;
        }
        public QuestionsPage ClickAddChoice(){
            Click(BUTTON_ORDERING_ADD);
            return this;
        }
        public QuestionsPage EnterOrdering4(string value){
            Type(INPUT_ORDERING_4, value);
            return this;
        }
        public QuestionsPage Delete3ThMatchingInput(){
            Click(BUTTON_MATCHING_INPUT_3_DELETE);
            return this;
        }
        public QuestionsPage Answer1ForMultipleChoice(string answer){
            Type(INPUT_MULTIPLE_CHOICE_ANSWER1, answer);
            return this;
        }
        public QuestionsPage Answer2ForMultipleChoice(string answer){
            Type(INPUT_MULTIPLE_CHOICE_ANSWER2, answer);
            return this;
        }
        public QuestionsPage Answer3ForMultipleChoice(string answer){
            Type(INPUT_MULTIPLE_CHOICE_ANSWER3, answer);
            return this;
        }
    }
}