using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages
{
    class QuestionsAndAnswersPage : Page
    {
        private static readonly By NEW_TICKET = By.CssSelector("a[ui-sref='veduBox.student.me.studentQuestions.new']");
        private static readonly By COURSE = By.CssSelector("select[ng-model='selectedCourse']");
        private static readonly By SUBJECT = By.CssSelector("input[ng-model='studentQuestion.subject']");
        private static readonly By NEXT_BUTTON = By.CssSelector("span[translate='common.next']");
        private static readonly By UPLOAD_PICTURE = By.Id("askUploadImage");
        private static readonly By SEND_BUTTON = By.CssSelector("span[translate='common.send']");
        private static readonly By SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private static readonly By MESSAGE = By.XPath("/html/body/div[3]/div/section/div/div[1]/div/div/div/div/form/div/div[1]/fieldset[3]/div/div/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private static readonly By VIEW_DETAIL = By.CssSelector("span[ng-click='getMessageDetails(questionAndAnswer.id,questionAndAnswer.instructorName)']");
        private static readonly By ANSWER_FIELD = By.XPath("/html/body/div[3]/div/section/div/div[1]/div/section/div[2]/div/table/tbody/tr[2]/td/div[3]/div[1]/div[2]/div/div/vedu-box-text-angular/text-angular/div[2]/div[3]/p");
        private static readonly By REPLY_BUTTON = By.CssSelector("div[translate='studentQuestion.Reply']");
        private static readonly By DELETE_TICKET = By.XPath("(//span[@translate='routeStates.teacher.me.courses.edit.deleteTicket'])[1]");
        private static readonly By ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private static string _user;
        public QuestionsAndAnswersPage(IWebDriver wd, string user) : base(wd)
        {
            _user = user;
        }
        public QuestionsAndAnswersPage clickNewTicket()
        {
            click(NEW_TICKET);
            return this;
        }
        public QuestionsAndAnswersPage SelectCourse(string courseName)
        {
            selectDropDown(COURSE, courseName);
            return this;
        }
        public QuestionsAndAnswersPage enterSubject(string subject)
        {
            type(SUBJECT,subject);
            return this;
        }
        public QuestionsAndAnswersPage enterMessage(string message)
        {
            type(MESSAGE, message);
            return this;
        }
        public QuestionsAndAnswersPage clickNextButton()
        {
            click(NEXT_BUTTON);
            return this;
        }
        public QuestionsAndAnswersPage selectFile()
        {
            type(
                    UPLOAD_PICTURE,
                    Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Docs\\file.png"))
                );

            return this;
        }
        public QuestionsAndAnswersPage clickSendButton()
        {
            click(SEND_BUTTON);
            return this;
        }
        public QuestionsAndAnswersPage assert()
        {
            AssertionCustom.assertElementVisible("Element Not Found", driver, SUCCESS);
            return this;
        }
        public QuestionsAndAnswersPage checkQuestionIsExist()
        {
            try
            {
                openViewDetail();
            }
            catch (Exception e)
            {
                Console.WriteLine("View(for question) was not found: " + e.Message);
                return null;
            }
            clickDeleteThisTicket();
            clickAreUSure();
            assert();
            return this;
        }
        public QuestionsAndAnswersPage deleteNewAddedQuestions()
        {
            openViewDetail(); 
            clickDeleteThisTicket();
            clickAreUSure();
            assert();
            return this;
        }
        public QuestionsAndAnswersPage openViewDetail()
        {
            click(VIEW_DETAIL);
            Console.WriteLine("Clicked view element");
            return this;
        }
        public QuestionsAndAnswersPage enterAnswer(string answer)
        {
            type(ANSWER_FIELD, answer);
            return this;
        }
        public QuestionsAndAnswersPage clickReplyButton()
        {
            click(REPLY_BUTTON);
            Console.WriteLine("Clicked reply button");
            return this;
        }
        public QuestionsAndAnswersPage clickDeleteThisTicket()
        {
            click(DELETE_TICKET);
            Console.WriteLine("Clicked delete this ticket");
            return this;
        }
        public QuestionsAndAnswersPage clickAreUSure()
        {
            click(ARE_U_SURE_OK);
            Console.WriteLine("Clicked delete this ticket");
            return this;
        }
    }
}
