using OpenQA.Selenium;
using System;
using System.Globalization;
using System.Linq;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages
{
    class LivePage : Page
    {
        private static readonly By ADD_NEW = By.Id("liveLesson-addNew");
        private static readonly By COURSE = By.Id("liveLesson-selectCourseModal");
        //private static string COURSE_VALUE = "deneme";
        private static readonly By MEETING_TYPE_BASIC = By.Id("liveLessons-addNewModalTypeVideoMeetingBasic");
        private static readonly By MEETING_TYPE_PRO = By.Id("liveLessons-addNewModalTypeVideoMeetingPro");
        private static readonly By MEETING_TYPE_WEBINAR = By.Id("liveLessons-addNewModalTypeVideoWebinar");
        private static readonly By COURSE_OK_BUTTON = By.Id("liveLesson-selectCourseModalConfirm");
        private static readonly By TITLE = By.Id("liveLessons-addNewModalCourseInput");
        //private static string DATE = "input[ng-model='startDates[n-1]']";
        private static readonly By TIME_HOUR = By.Id("liveLessons-addNewModalTimeHoursSelect");
        private static readonly By TIME_MIN = By.Id("liveLessons-addNewModalTimeMinutesSelect");
        private static readonly By TIMEZONE = By.Id("liveLessons-addNewModalTimeZonesSelect");
        private static readonly By DURATION = By.Id("liveLessons-addNewModalSelectDuration");
        private static readonly By REGISTRATION_LIMIT = By.Id("liveLessons-addNewModalRegistrationLimitInput");
        private static readonly By DESCRIPTION = By.CssSelector("div[ng-model='html']"); // id: taTextElement5949993084175542
        private static readonly By TRAINER = By.Id("liveLessons-addNewModalTeacherSelect");
        private static readonly By PRIVATE = By.Id("liveLessons-addNewModalPrivateCheckbox");
        private static readonly By SUBMIT = By.Id("liveLessons-addNewModalSave");
        private static readonly By SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private static readonly By ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private static readonly By REGISTER = By.Id("liveLesson-sessionStatusRegister");
        private static readonly By LIVE_RECORD = By.Id("liveLesson-sessionShowDetails");
        private static readonly By RECORD_DETAIL_BUTTON = By.Id("liveLesson-sessionLink");
        private static readonly By QUERY_BUTTON = By.Id("liveLesson-query");
        private static readonly By COPY_BUTTON = By.CssSelector("input[ng-click='copyClicked()']");
        private static readonly By QUERY_START_DATE_LIVE_LESSONS_ADD_NEW_MODEL_SELECT_DATA = By.XPath("(//input[@id='liveLessons-addNewModalSelectDate'])[1]");
        private static readonly By QUERY_END_DATE_LIVE_LESSONS_ADD_NEW_MODEL_SELECT_DATA = By.XPath("(//input[@id='liveLessons-addNewModalSelectDate'])[2]");
        private static readonly By QUERY_START_DATE_OPEN_DATEPICKER = By.CssSelector("button[ng-click*='queryStartDate']");
        private static readonly By QUERY_END_DATE_OPEN_DATEPICKER = By.CssSelector("button[ng-click*='queryDueDate']");
        private static readonly By QUERY_START_DATE_CHOOSE_YEAR = By.XPath("(//button[@ng-click='toggleMode()'])[2]");
        private static readonly By QUERY_END_DATE_CHOOSE_YEAR = By.XPath("(//button[@ng-click='toggleMode()'])[3]");
        private static readonly By QUERY_START_DATE_GO_PREVIOUS_YEAR = By.XPath("(//button[@ng-click='move(-1)'])[2]");
        private static readonly By QUERY_END_DATE_GO_PREVIOUS_YEAR = By.XPath("(//button[@ng-click='move(-1)'])[3]");
        private static readonly By QUERY_START_DATE_GO_NEXT_YEAR = By.XPath("(//button[@ng-click='move(1)'])[2]");
        private static readonly By QUERY_END_DATE_GO_NEXT_YEAR = By.XPath("(//button[@ng-click='move(1)'])[3]");
        private static readonly By QUERY_START_HOUR = By.XPath("(//select[@id='liveLessons-addNewModalTimeHoursSelect'])[1]");
        private static readonly By QUERY_END_HOUR = By.XPath("(//select[@id='liveLessons-addNewModalTimeHoursSelect'])[2]");
        private static readonly By QUERY_START_MINUTE = By.XPath("(//select[@id='liveLessons-addNewModalTimeMinutesSelect'])[1]");
        private static readonly By QUERY_END_MINUTE = By.XPath("(//select[@id='liveLessons-addNewModalTimeMinutesSelect'])[2]");
        private static readonly By QUERY_SEARCH_BUTTON = By.CssSelector("button[ng-click*='searchLiveLessonsInRange()']");
        private static readonly By QUERY_CLOSE_BUTTON = By.Id("liveLesson-selectCourseModalCancel");
        private static readonly By GO_TO_DATE_CHOOSE_YEAR =By.XPath("/html/body/div[3]/div/section/div/div[2]/div[2]/div[2]/ul/li/div/table/thead/tr[1]/th[2]/button");
        private static readonly By GO_TO_DATE_PREVIOUS_YEAR = By.XPath("//*[@id='mainSection']/div/div[2]/div[2]/div[2]/ul/li/div/table/thead/tr[1]/th[1]/button");
        private static readonly By GO_TO_DATE_NEXT_YEAR = By.XPath("//*[@id='mainSection']/div/div[2]/div[2]/div[2]/ul/li/div/table/thead/tr[1]/th[3]/button");
        private static readonly By SET_DATE_CHOOSE_YEAR = By.XPath("//*[@id='liveLessonForm']/div[1]/div[5]/div[2]/div/p/ul/li/div/table/thead/tr/th[2]/button");
        private static readonly By SET_DATE_PREVIOUS_YEAR = By.XPath("//*[@id='liveLessonForm']/div[1]/div[5]/div[2]/div/p/ul/li/div/table/thead/tr/th[1]/button");
        private static readonly By SET_DATE_NEXT_YEAR = By.XPath("//*[@id='liveLessonForm']/div[1]/div[5]/div[2]/div/p/ul/li/div/table/thead/tr/th[3]/button");
        private static readonly By ASSERT_START = By.XPath("//*[@id='mainSection']/div/div[2]/div[3]/div/div[3]/div[3]/div/div/div[6]/button");
        private static readonly By SELECT_TIME = By.XPath("//*[@id='pageBody']/div[2]/div[2]/div[1]/div[2]/table/tbody/tr[9]/td[3]/a[1]");
        private static readonly By LIVE_REGISTER = By.XPath("//*[@id='mainSection']/div/div[2]/div[3]/div/div[3]/div[3]/div[2]/div/div[6]/div/button[1]");
        private static readonly By LiveLessonSelectDate = By.Id("liveLesson-selectDate");
        private static readonly By LiveLessonsAddNewModalSelectDate = By.Id("liveLessons-addNewModalSelectDate");
        private static readonly By LiveLessonsAddNewModalSelectDatePicker = By.CssSelector("button[ng-click='openDatepicker($event,(n-1))']");

       public static string RandomString(int length){
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[new Random().Next(s.Length)]).ToArray());
        }
        //private static string titleRandom = RandomString(10);
        private static string _user;
   
        public LivePage(IWebDriver wd, string user) : base(wd){
            _user = user;
        }
        public LivePage AddNew(){
            try{
                click(ADD_NEW);
            }catch(Exception e){
                Console.WriteLine("Error occured in AddNew in Live page, user: " + _user + ", Error is: " + e.Message);
            }
            Console.WriteLine(_user + ": clicked AddNew element in Live Page");
            return this;
        }
        public LivePage SelectCourse(string course_name){
            selectDropDown(COURSE, course_name);
            return this;
        }
        public LivePage SubmitSelectedCourse(){
            click(COURSE_OK_BUTTON);
            return this;
        }
        public LivePage selectMeetingType(string type){
            try{
                if (type == "pro")
                    click(MEETING_TYPE_PRO);
                else if (type == "basic")
                    click(MEETING_TYPE_BASIC);
                else if (type == "webinar")
                    click(MEETING_TYPE_WEBINAR);
                else
                    throw new Exception("Meeting Type is incorrect or null.");
                Console.WriteLine("Meeting Type is selected as :" + type);
            }catch (Exception e) {
                Console.WriteLine("Error occured during selecting metting type. Error is: " + e);
            }
            return this;
        }
        public LivePage enterTitle(string title){
            type(TITLE, title);
            return this;
        }

        public LivePage register(){
            click(LIVE_REGISTER);
            return this;
        }
        public LivePage setDate(int yearParam = 0, string monthParam = null, string dayParam = null){
            int year = yearParam == 0 ? Utils.Dates.getCurrentYear() : yearParam;
            string month = monthParam == null ? Utils.Dates.getCurrentMonth() : monthParam;
            string day = dayParam == null ? Utils.Dates.getCurrentDay() : dayParam;

            string getCurrentValueOfInput = getAttribute(LiveLessonsAddNewModalSelectDate, "value");
            string[] words = getCurrentValueOfInput.Split('/');
            int getCurrentValueOfInputYear = Int32.Parse(words[2]);
            int getCurrentValueOfInputMonth = Int32.Parse(words[1]);
            string getCurrentValueOfInputDay = words[0];

            try{
                click(LiveLessonsAddNewModalSelectDatePicker);
                click(SET_DATE_CHOOSE_YEAR);
                if (year != getCurrentValueOfInputYear){
                    if (year < getCurrentValueOfInputYear){
                        for (int i = getCurrentValueOfInputYear; i > year; i--){
                            click(SET_DATE_PREVIOUS_YEAR);
                        }
                    }else{
                        for (int i = getCurrentValueOfInputYear; i < year; i++){
                            click(SET_DATE_NEXT_YEAR);
                        }
                    }
                }
                click(By.XPath("//span[contains(text(),'" + month + "')]"));
                click(By.XPath("(//span[@class='ng-binding' and contains(text(),'" + day + "')])[2]"));
            }catch (Exception e){
                Console.WriteLine("Element not found:" + e);
            }
            sleepms(500);
            return this;
        }

        public LivePage setQueryStartDate(int yearParam = 0, string monthParam = null, string dayParam = null)
        {
            int year = yearParam == 0 ? Utils.Dates.getCurrentYear() : yearParam;
            string month = monthParam == null ? Utils.Dates.getCurrentMonth() : monthParam;
            string day = dayParam == null ? Utils.Dates.getCurrentDay() : dayParam;

            string getCurrentValueOfInput = getAttribute(QUERY_START_DATE_LIVE_LESSONS_ADD_NEW_MODEL_SELECT_DATA, "value");
            string[] words = getCurrentValueOfInput.Split('/');
            int getCurrentValueOfInputYear = Int32.Parse(words[2]);
            int getCurrentValueOfInputMonth = Int32.Parse(words[1]);
            string getCurrentValueOfInputDay = words[0];

            try
            {
                click(QUERY_START_DATE_OPEN_DATEPICKER);
                Console.WriteLine("clicked start date picker");
                click(QUERY_START_DATE_CHOOSE_YEAR);
                Console.WriteLine("clicked start date choose year");
                if (year != getCurrentValueOfInputYear)
                {
                    if (year < getCurrentValueOfInputYear)
                    {
                        for (int i = getCurrentValueOfInputYear; i > year; i--)
                        {
                            click(QUERY_START_DATE_GO_PREVIOUS_YEAR);
                        }
                    }
                    else
                    {
                        for (int i = getCurrentValueOfInputYear; i < year; i++)
                        {
                            click(QUERY_START_DATE_GO_NEXT_YEAR);
                        }
                    }
                }
                click(By.XPath("//span[contains(text(),'" + month + "')]"));
                Console.WriteLine("clicked start date month " + month + " successfully");
                click(By.XPath("(//span[@class='ng-binding' and contains(text(),'" + day + "')])[2]"));
                Console.WriteLine("clicked start date day " + day + " successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Element not found:" + e);
            }
            sleepms(500);
            return this;
        }

        public LivePage setQueryEndDate(int yearParam = 0, string monthParam = null, string dayParam = null)
        {
            int year = yearParam == 0 ? Utils.Dates.getCurrentYear() : yearParam;
            string month = monthParam == null ? Utils.Dates.getCurrentMonth() : monthParam;
            string day = dayParam == null ? Utils.Dates.getCurrentDay() : dayParam;

            string getCurrentValueOfInput = getAttribute(QUERY_END_DATE_LIVE_LESSONS_ADD_NEW_MODEL_SELECT_DATA, "value");
            string[] words = getCurrentValueOfInput.Split('/');
            int getCurrentValueOfInputYear = Int32.Parse(words[2]);
            int getCurrentValueOfInputMonth = Int32.Parse(words[1]);
            string getCurrentValueOfInputDay = words[0];
        

            try
            {
                click(QUERY_END_DATE_OPEN_DATEPICKER);
                Console.WriteLine("clicked end date picker");
                click(QUERY_END_DATE_CHOOSE_YEAR);
                Console.WriteLine("clicked start date choose year");
                if (year != getCurrentValueOfInputYear)
                {
                    if (year < getCurrentValueOfInputYear)
                    {
                        for (int i = getCurrentValueOfInputYear; i > year; i--)
                        {
                            click(QUERY_END_DATE_GO_PREVIOUS_YEAR);
                        }
                    }
                    else
                    {
                        for (int i = getCurrentValueOfInputYear; i < year; i++)
                        {
                            click(QUERY_END_DATE_GO_NEXT_YEAR);
                            Console.WriteLine("clicked end date go to next year " +i + " times" );
                        }
                    }
                }
                click(By.XPath("//span[contains(text(),'" + month + "')]"));
                Console.WriteLine("clicked end date month " + month + " successfully");
                click(By.XPath("(//span[@class='ng-binding' and contains(text(),'" + day + "')])[3]"));
              
                 Console.WriteLine("clicked start date day " + day + " successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Element not found:" + e);
            }
            sleepms(500);
            return this;
        }
        public LivePage setQueryStartHour(string startHourParam = null)
        {
            string hour = startHourParam == null ? Utils.Dates.getCurrentHour() : startHourParam;
            selectDropDown(QUERY_START_HOUR, hour);
            return this;
        }
        public LivePage setQueryStartMinute(string startMinuteParam = null)
        {
            string minute = startMinuteParam == null ? Utils.Dates.getCurrentHour() : startMinuteParam;
            selectDropDown(QUERY_START_MINUTE, minute);
            return this;
        }
        public LivePage setQueryEndHour(string endHourParam = null)
        {
            string hour = endHourParam == null ? Utils.Dates.getCurrentHour() : endHourParam;
            selectDropDown(QUERY_END_HOUR, hour);
            return this;
        }
        public LivePage setQueryEndMinute(string endMinuteParam = null)
        {
            string minute = endMinuteParam == null ? Utils.Dates.getCurrentHour() : endMinuteParam;
            selectDropDown(QUERY_END_MINUTE, minute);
            return this;
        }
        public LivePage clickSearch()
        {
            click(QUERY_SEARCH_BUTTON);
            return this;
        }
        public LivePage verifyCourseName(string courseName)
        {

            Assertion.AssertionCustom.assertElementVisible("CourseName "+courseName+ " is not visible",driver,
               By.XPath("//td[@class='ng-binding' and contains(text(),'" + courseName + "')]"));
          return this;
        }
        public LivePage clickCloseButton()
        {
            click(QUERY_CLOSE_BUTTON);
            return this;
        }



        public LivePage selectTime(){
            try{
                click(SELECT_TIME);
            }catch (Exception e){
                Console.WriteLine("Error occured in adding time to Live record, user: " + _user + ", Error: " + e);
            }
            return this;
        }

        public LivePage saveScheduleButton(){
            try{
                click(By.CssSelector("button[ng-click='saveMultiple()']"));
            }catch (Exception e){
                Console.WriteLine("Error occured in clicking save button to Schedule page, user: " + _user + ", Error: " + e);
            }
            return this;
        }

        public LivePage checkLiveIsExist(){
            try{
                openLiveRecordDetail();
            }catch (Exception e){
                Console.WriteLine("Live not found: " + e.Message);
                return null;
            }
            clickDeleteButtonInRecordDetail();
            clickAreUSure();
            assertLive();
            return this;
        }
        public LivePage clickDeleteButtonInRecordDetail(){
            click(By.Id("liveLesson-sessionDel"));
            Console.WriteLine("Clicked delete button in record detail");
            return this;
        }
        public LivePage clickAreUSure(){
            click(ARE_U_SURE_OK);
            Console.WriteLine("Clicked ARE_U_SURE_OK in popup");
            return this;
        }
        public WebinarPage goToWebinar(){
            try{
                openLiveRecordDetail();
                clickRECORD_DETAIL_BUTTON();
                clickCopyButton();
            }catch (Exception e){
                Console.WriteLine("Error occured in deleting Live record, user: " + _user + ", Error: " + e);
            }
            return new WebinarPage(driver, _user);
        }
        public LivePage openLiveRecordDetail(){
            click(LIVE_RECORD);
            return this;
        }
        private void clickRECORD_DETAIL_BUTTON(){
            click(RECORD_DETAIL_BUTTON);
        }
        private void clickCopyButton() {
            driver.Url = driver.FindElement(COPY_BUTTON).GetAttribute("ng-click-copy");
        }
        public LivePage assertStart(){
            try{
                AssertionCustom.assertElementVisible("Element Not Found", driver, ASSERT_START);
            }catch (Exception e){
                Console.WriteLine("Error occured in deleting Live record, user: " + _user + ", Error: " + e);
            }
            return this;
        }
        public LivePage setTimezone(string timeZone){
            selectDropDown(TIMEZONE, timeZone);
            return this;
        }
        public LivePage setHour(string hourParam = null){
            string hour = hourParam == null ? Utils.Dates.getCurrentHour() : hourParam;
            selectDropDown(TIME_HOUR, hour);
            return this;
        }
        public LivePage setMinute(string minuteParam = null){
            string minute = minuteParam == null ? Utils.Dates.getCurrentMinute() : minuteParam;
            selectDropDown(TIME_MIN, minute);
            return this;
        }
        public LivePage setDuration(int duration){
            selectDropDown(DURATION, duration);
            return this;
        }
        public LivePage setRegistrationLimit(int limit){
            type(REGISTRATION_LIMIT, limit);
            return this;
        }
        public LivePage setDescription(String description){
            type(DESCRIPTION, description);
            return this;
        }
        public LivePage setTrainer(string trainer){
            selectDropDown(TRAINER, trainer);
            return this;
        }
        public LivePage setPrivate(){
            if (!isSelected(PRIVATE))
                click(PRIVATE);
            else
                Console.WriteLine("Already private is selected");
            return this;
        }
        public LivePage submit(){
            click(SUBMIT);
            return this;
        }
        public LivePage assertLive(){
            AssertionCustom.assertElementVisible("Element Not Found", driver, SUCCESS);
            return this;
        }

        public LivePage goDate(int yearParam = 0, string monthParam = null, string dayParam = null){
            int year = yearParam == 0 ? Utils.Dates.getCurrentYear() : yearParam;
            string month = monthParam == null ? Utils.Dates.getCurrentMonth() : monthParam;
            string day = dayParam == null ? Utils.Dates.getCurrentDay() : dayParam;

            string getCurrentValueOfInput = getAttribute(LiveLessonSelectDate, "value");
            string[] words = getCurrentValueOfInput.Split('-');
            int getCurrentValueOfInputYear = Int32.Parse(words[0]);
            int getCurrentValueOfInputMonth = Int32.Parse(words[1]);
            string getCurrentValueOfInputDay = words[2];

            try{
                click(LiveLessonSelectDate);
                click(GO_TO_DATE_CHOOSE_YEAR);
                if (year != getCurrentValueOfInputYear){
                    if (year < getCurrentValueOfInputYear){
                        for (int i = getCurrentValueOfInputYear; i > year; i--){
                            click(GO_TO_DATE_PREVIOUS_YEAR);
                        }
                    }else{
                        for (int i = getCurrentValueOfInputYear; i < year; i++){
                            click(GO_TO_DATE_NEXT_YEAR);
                        }
                    }
                }
                click(By.XPath("//span[contains(text(),'" + month + "')]"));
                click(By.XPath("(//span[@class='ng-binding' and contains(text(),'" + day + "')])"));
            }catch(Exception e){
                Console.WriteLine("Element not found:" + e);
            }
            sleepms(500);
            return this;
        }

        public LivePage studentRegister(){
            click(REGISTER);
            return this;
        }

        public LivePage clickQueryButton()
        {
            click(QUERY_BUTTON);
            return this;
        }
    }
}
