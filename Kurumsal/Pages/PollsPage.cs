using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages
{
    class PollsPage : Page
    {
        private static string _user;
        private static By ADD_BUTTON = By.XPath("(//*[@translate='common.add'])[1]");
        private static By INPUT_NAME = By.CssSelector("input[ng-model='poll.name']");
        private static By INPUT_DESCRIPTION = By.CssSelector("textarea[ng-model='poll.description']");
        private static By REPEAT_NUMBER = By.CssSelector("input[ng-model='poll.repeatNumber']");
        public static By ISMANDATORY = By.CssSelector("input[ng-model='poll.isMandatory']");
        private static By NEXT_BUTTON = By.CssSelector("button[ng-click='goToStep(2)']");
        private static By SET_QUESTION = By.XPath("//button[@ng-click='setSelectedQuestions(question)']");
        private static By SAVE_BUTTON = By.CssSelector("span[translate='common.save']");
        private static By SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private static By SEARCH_BOX = By.CssSelector("input.form-control.vedu-search");
        private static By THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private static By DELETE_POLL = By.CssSelector("button[ng-click='delete(poll)']");
        private static By ARE_U_SURE_OK = By.CssSelector("button.msc-ok");

        private static By INPUT_QUESTION_LIST_SEARCH = By.XPath("//*[@id='step2']/div[1]/div/div[1]/div[2]/div[4]/input");

        

        public PollsPage(IWebDriver wd, string user) : base(wd)
        {
            _user = user;
        }

        public PollsPage clickAddButton()
        {
            click(ADD_BUTTON);
            return this;
        }
        public PollsPage enterName(string Name)
        {
            type(INPUT_NAME, Name);
            return this;
        }
        public PollsPage enterDescription(string Description)
        {
            type(INPUT_DESCRIPTION, Description);
            return this;
        }
        public PollsPage enterRepeatNumber(int RepeatNumber)
        {
            type(REPEAT_NUMBER, RepeatNumber);
            return this;
        }
        public PollsPage selectIsMandatory()
        {
            if (isSelected(ISMANDATORY) == false)
            click(ISMANDATORY);
            return this;
        }

        public PollsPage setDate(int year, string month, string day)
        {
            click(By.XPath("//*[@id='step1']/div[12]/div/p/span/button/i"));
            Console.WriteLine("date picker was opened");
            click(By.XPath("(//button[@ng-click='toggleMode()'])[2]"));
            Console.WriteLine("second button was clicked");
            if (year < 2020)
            {
                for (int i = 2020; i > year; i--)
                {
                    Console.WriteLine("year is older than 2020 so is going to " + year);
                    click(By.XPath("(//button[@ng-click='move(-1)'])[1]"));
                }
            }
            if (year > 2020)
            {
                for (int i = 2020; i < year; i++)
                {
                    Console.WriteLine("year is newer than 2020 so is going to " + year);
                    click(By.XPath("(//button[@ng-click='move(-1)'])[1]"));
                }
            }
            click(By.XPath("//span[contains(text(),'" + month + "')]"));
            click(By.XPath("(//span[@class='ng-binding' and contains(text(),'" + day + "')])[2]"));
            sleepms(500);
            return this;
        }
        public PollsPage clickNextButton()
        {
            click(NEXT_BUTTON);
            return this;
        }
        public PollsPage searchQuestion(string question){
            type(INPUT_QUESTION_LIST_SEARCH, question);
            return this;
        }
        public PollsPage setSetQuestion(){
            click(SET_QUESTION);
            return this;
        }
        public PollsPage clickSaveButton()
        {
            click(SAVE_BUTTON);
            return this;
        }
        public PollsPage assert()
        {
            AssertionCustom.assertElementVisible("Element Not Found", driver, SUCCESS);
            return this;
        }

        public PollsPage searchNewlyAddedPollByName(string Name)
        {
            type(SEARCH_BOX, Name);
            sleepms(1000);
            return this;
        }

        public PollsPage clickThreePoints()
        {

            click(THREE_POINTS);
            return this;
        }
        public PollsPage clickDelete()
        {
           
                click(DELETE_POLL);
                return this;
        }
        public PollsPage clickAreYouSureOK()
        {

            click(ARE_U_SURE_OK);
            return this;
        }

        public PollsPage clearSearchBox()
        {

            clear(SEARCH_BOX);
            return this;
        }

        public PollsPage checkPollIsExist(string Name)
        {
            searchNewlyAddedPollByName(Name);
            try
            {
                clickThreePoints();
            }
            catch (Exception e)
            {
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
