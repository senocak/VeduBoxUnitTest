using OpenQA.Selenium;
using System;
using System.Globalization;
using System.Linq;
using VeduBoxUnitTest.Assertion;
using VeduBoxUnitTest.Utils;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class LivePage : Page{
        private readonly By BUTTON_ADD_NEW = By.Id("liveLesson-addNew");
        private readonly By SELECT_COURSE = By.Id("liveLesson-selectCourseModal");
        private readonly By BUTTON_MEETING_TYPE_BASIC = By.Id("liveLessons-addNewModalTypeVideoMeetingBasic");
        private readonly By BUTTON_MEETING_TYPE_PRO = By.Id("liveLessons-addNewModalTypeVideoMeetingPro");
        private readonly By BUTTON_MEETING_TYPE_WEBINAR = By.Id("liveLessons-addNewModalTypeVideoWebinar");
        private readonly By BUTTON_COURSE_OK = By.Id("liveLesson-selectCourseModalConfirm");
        private readonly By INPUT_TITLE = By.Id("liveLessons-addNewModalCourseInput");
        private readonly By SELECT_TIME_HOUR = By.Id("liveLessons-addNewModalTimeHoursSelect");
        private readonly By SELECT_TIME_MIN = By.Id("liveLessons-addNewModalTimeMinutesSelect");
        private readonly By SELECT_TIMEZONE = By.Id("liveLessons-addNewModalTimeZonesSelect");
        private readonly By SELECT_DURATION = By.Id("liveLessons-addNewModalSelectDuration");
        private readonly By SELECT_REGISTRATION_LIMIT = By.Id("liveLessons-addNewModalRegistrationLimitInput");
        private readonly By DIV_DESCRIPTION = By.CssSelector("div[ng-model='html']");
        private readonly By SELECT_TRAINER = By.Id("liveLessons-addNewModalTeacherSelect");
        private readonly By CHECKBOX_PRIVATE = By.Id("liveLessons-addNewModalPrivateCheckbox");
        private readonly By BUTTON_SUBMIT = By.Id("liveLessons-addNewModalSave");
        private readonly By ALERT_SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private readonly By ALERT_ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private readonly By BUTTON_REGISTER = By.Id("liveLesson-sessionStatusRegister");
        private readonly By BUTTON_LIVE_RECORD = By.Id("liveLesson-sessionShowDetails");
        private readonly By BUTTON_RECORD_DETAIL = By.Id("liveLesson-sessionLink");
        private readonly By BUTTON_QUERY = By.Id("liveLesson-query");
        private readonly By BUTTON_COPY = By.CssSelector("input[ng-click='copyClicked()']");
        private readonly By INPUT_QUERY_START_DATE_LIVE_LESSONS_ADD_NEW_MODEL_SELECT_DATA = By.XPath("(//input[@id='liveLessons-addNewModalSelectDate'])[1]");
        private readonly By INPUT_QUERY_END_DATE_LIVE_LESSONS_ADD_NEW_MODEL_SELECT_DATA = By.XPath("(//input[@id='liveLessons-addNewModalSelectDate'])[2]");
        private readonly By BUTTON_QUERY_START_DATE_OPEN_DATEPICKER = By.CssSelector("button[ng-click*='queryStartDate']");
        private readonly By BUTTON_QUERY_END_DATE_OPEN_DATEPICKER = By.CssSelector("button[ng-click*='queryDueDate']");
        private readonly By BUTTON_QUERY_START_DATE_CHOOSE_YEAR = By.XPath("(//button[@ng-click='toggleMode()'])[2]");
        private readonly By BUTTON_QUERY_END_DATE_CHOOSE_YEAR = By.XPath("(//button[@ng-click='toggleMode()'])[3]");
        private readonly By BUTTON_QUERY_START_DATE_GO_PREVIOUS_YEAR = By.XPath("(//button[@ng-click='move(-1)'])[2]");
        private readonly By BUTTON_QUERY_END_DATE_GO_PREVIOUS_YEAR = By.XPath("(//button[@ng-click='move(-1)'])[3]");
        private readonly By BUTTON_QUERY_START_DATE_GO_NEXT_YEAR = By.XPath("(//button[@ng-click='move(1)'])[2]");
        private readonly By BUTTON_QUERY_END_DATE_GO_NEXT_YEAR = By.XPath("(//button[@ng-click='move(1)'])[3]");
        private readonly By SELECT_QUERY_START_HOUR = By.XPath("(//select[@id='liveLessons-addNewModalTimeHoursSelect'])[1]");
        private readonly By SELECT_QUERY_END_HOUR = By.XPath("(//select[@id='liveLessons-addNewModalTimeHoursSelect'])[2]");
        private readonly By SELECT_QUERY_START_MINUTE = By.XPath("(//select[@id='liveLessons-addNewModalTimeMinutesSelect'])[1]");
        private readonly By SELECT_QUERY_END_MINUTE = By.XPath("(//select[@id='liveLessons-addNewModalTimeMinutesSelect'])[2]");
        private readonly By BUTTON_QUERY_SEARCH = By.CssSelector("button[ng-click*='searchLiveLessonsInRange()']");
        private readonly By BUTTON_QUERY_CLOSE = By.Id("liveLesson-selectCourseModalCancel");
        private readonly By BUTTON_GO_TO_DATE_CHOOSE_YEAR =By.XPath("/html/body/div[3]/div/section/div/div[2]/div[2]/div[2]/ul/li/div/table/thead/tr[1]/th[2]/button");
        private readonly By BUTTON_GO_TO_DATE_PREVIOUS_YEAR = By.XPath("//*[@id='mainSection']/div/div[2]/div[2]/div[2]/ul/li/div/table/thead/tr[1]/th[1]/button");
        private readonly By BUTTON_GO_TO_DATE_NEXT_YEAR = By.XPath("//*[@id='mainSection']/div/div[2]/div[2]/div[2]/ul/li/div/table/thead/tr[1]/th[3]/button");
        private readonly By BUTTON_SET_DATE_CHOOSE_YEAR = By.XPath("//*[@id='liveLessonForm']/div[1]/div[5]/div[2]/div/p/ul/li/div/table/thead/tr/th[2]/button");
        private readonly By BUTTON_SET_DATE_PREVIOUS_YEAR = By.XPath("//*[@id='liveLessonForm']/div[1]/div[5]/div[2]/div/p/ul/li/div/table/thead/tr/th[1]/button");
        private readonly By BUTTON_SET_DATE_NEXT_YEAR = By.XPath("//*[@id='liveLessonForm']/div[1]/div[5]/div[2]/div/p/ul/li/div/table/thead/tr/th[3]/button");
        private readonly By ASSERT_START = By.XPath("//*[@id='mainSection']/div/div[2]/div[3]/div/div[3]/div[3]/div/div/div[6]/button");
        private readonly By SELECT_TIME = By.XPath("//*[@id='pageBody']/div[2]/div[2]/div[1]/div[2]/table/tbody/tr[9]/td[3]/a[1]");
        private readonly By BUTTON_LIVE_REGISTER = By.XPath("//*[@id='mainSection']/div/div[2]/div[3]/div/div[3]/div[3]/div[2]/div/div[6]/div/button[1]");
        private readonly By INPUT_LIVE_LESSON_SELECT_DATE = By.Id("liveLesson-selectDate");
        private readonly By INPUT_LIVE_LESSONS_ADD_NEW_MODAL_SELECT_DATE = By.Id("liveLessons-addNewModalSelectDate");
        private readonly By BUTTON_LIVE_LESSONS_ADD_NEW_MODAL_SELECT_DATE_PİCKER = By.CssSelector("button[ng-click='openDatepicker($event,(n-1))']");
        private readonly By ZOOM_LINK = By.CssSelector("label[ng-click*='zoom']");
        private readonly By CONFIRMED = By.CssSelector("a[ng-bind*='entities.liveLesson.confirmed']");
        private readonly By EXPORT_ALL = By.CssSelector("span[translate='common.exportAll']");
        private readonly By ATTENDEES = By.Id("liveLesson-sessionShowAttenders");
        private readonly By CLICK_TO_COPY = By.CssSelector("span[translate='common.clickToCopy']");
        private readonly By CANCEL_IN_DETAILS = By.CssSelector("button[ng-click='close()']");
        private readonly By CANCEL_AFTER_EXPORT = By.CssSelector("span[translate='common.cancel']");
        private readonly By BUTTON_DETAIL_DELETE = By.Id("liveLesson-sessionDel");
        private string USER;
        
        public string RandomString(int length){
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[new Random().Next(s.Length)]).ToArray());
        }
        public LivePage(IWebDriver wd, string user) : base(wd){
            USER = user;
        }
        public LivePage AddNew(){
            try{
                Click(BUTTON_ADD_NEW);
            }catch(Exception e){
                Console.WriteLine("Error occured in AddNew in Live page, user: " + USER + ", Error is: " + e.Message);
            }
            Console.WriteLine(USER + ": clicked AddNew element in Live Page");
            return this;
        }
        public LivePage SelectCourse(string courseName){
            SelectDropDown(SELECT_COURSE, courseName);
            return this;
        }
        public LivePage SubmitSelectedCourse(){
            Click(BUTTON_COURSE_OK);
            return this;
        }
        public LivePage SelectMeetingType(string type){
            try{
                if (type == Constants.MeetingType.Pro.ToString())
                    Click(BUTTON_MEETING_TYPE_PRO);
                else if (type == Constants.MeetingType.Basic.ToString())
                    Click(BUTTON_MEETING_TYPE_BASIC);
                else if (type == Constants.MeetingType.Webinar.ToString())
                    Click(BUTTON_MEETING_TYPE_WEBINAR);
                else
                    throw new Exception("Meeting Type is incorrect or null.");
                Console.WriteLine("Meeting Type is selected as :" + type);
            }catch (Exception e) {
                Console.WriteLine("Error occured during selecting metting type. Error is: " + e);
            }
            return this;
        }
        public LivePage EnterTitle(string title){
            Type(INPUT_TITLE, title);
            return this;
        }
        public LivePage Register(){
            Click(BUTTON_LIVE_REGISTER);
            return this;
        }
        public LivePage SetDate(int yearParam = 0, string monthParam = null, string dayParam = null){
            int year = yearParam == 0 ? Utils.Dates.GetCurrentYear() : yearParam;
            string month = monthParam == null ? Utils.Dates.GetCurrentMonth() : monthParam;
            string day = dayParam == null ? Utils.Dates.GetCurrentDay() : dayParam;

            string getCurrentValueOfInput = GetAttribute(INPUT_LIVE_LESSONS_ADD_NEW_MODAL_SELECT_DATE, "value");
            string[] words = getCurrentValueOfInput.Split('/');
            int getCurrentValueOfInputYear = Int32.Parse(words[2]);
            int getCurrentValueOfInputMonth = Int32.Parse(words[1]);
            string getCurrentValueOfInputDay = words[0];

            try{
                Click(BUTTON_LIVE_LESSONS_ADD_NEW_MODAL_SELECT_DATE_PİCKER);
                Click(BUTTON_SET_DATE_CHOOSE_YEAR);
                if (year != getCurrentValueOfInputYear){
                    if (year < getCurrentValueOfInputYear){
                        for (int i = getCurrentValueOfInputYear; i > year; i--){
                            Click(BUTTON_SET_DATE_PREVIOUS_YEAR);
                        }
                    }else{
                        for (int i = getCurrentValueOfInputYear; i < year; i++){
                            Click(BUTTON_SET_DATE_NEXT_YEAR);
                        }
                    }
                }
                Click(By.XPath("//span[contains(text(),'" + month + "')]"));
                Click(By.XPath("(//span[@class='ng-binding' and contains(text(),'" + day + "')])[2]"));
            }catch (Exception e){
                Console.WriteLine("Element not found:" + e);
            }
            Sleepms(500);
            return this;
       }
       public LivePage SetQueryStartDate(int yearParam = 0, string monthParam = null, string dayParam = null){
            int year = yearParam == 0 ? Utils.Dates.GetCurrentYear() : yearParam;
            string month = monthParam == null ? Utils.Dates.GetCurrentMonth() : monthParam;
            string day = dayParam == null ? Utils.Dates.GetCurrentDay() : dayParam;

            string getCurrentValueOfInput = GetAttribute(INPUT_QUERY_START_DATE_LIVE_LESSONS_ADD_NEW_MODEL_SELECT_DATA, "value");
            string[] words = getCurrentValueOfInput.Split('/');
            int getCurrentValueOfInputYear = Int32.Parse(words[2]);
            int getCurrentValueOfInputMonth = Int32.Parse(words[1]);
            string getCurrentValueOfInputDay = words[0];

            try{
                Click(BUTTON_QUERY_START_DATE_OPEN_DATEPICKER);
                Console.WriteLine("clicked start date picker");
                Click(BUTTON_QUERY_START_DATE_CHOOSE_YEAR);
                Console.WriteLine("clicked start date choose year");
                if (year != getCurrentValueOfInputYear) {
                    if (year < getCurrentValueOfInputYear){
                        for (int i = getCurrentValueOfInputYear; i > year; i--){
                            Click(BUTTON_QUERY_START_DATE_GO_PREVIOUS_YEAR);
                        }
                    }else{
                        for (int i = getCurrentValueOfInputYear; i < year; i++){
                            Click(BUTTON_QUERY_START_DATE_GO_NEXT_YEAR);
                        }
                    }
                }
                Click(By.XPath("//span[contains(text(),'" + month + "')]"));
                Click(By.XPath("(//span[@class='ng-binding' and contains(text(),'" + day + "')])[2]"));
            }catch (Exception e){
                Console.WriteLine("Element not found:" + e);
            }
            Sleepms(500);
            return this;
       }
       public LivePage SetQueryEndDate(int yearParam = 0, string monthParam = null, string dayParam = null){
            int year = yearParam == 0 ? Utils.Dates.GetCurrentYear() : yearParam;
            string month = monthParam == null ? Utils.Dates.GetCurrentMonth() : monthParam;
            string day = dayParam == null ? Utils.Dates.GetCurrentDay() : dayParam;

            string getCurrentValueOfInput = GetAttribute(INPUT_QUERY_END_DATE_LIVE_LESSONS_ADD_NEW_MODEL_SELECT_DATA, "value");
            string[] words = getCurrentValueOfInput.Split('/');
            int getCurrentValueOfInputYear = Int32.Parse(words[2]);
            int getCurrentValueOfInputMonth = Int32.Parse(words[1]);
            string getCurrentValueOfInputDay = words[0];

            try{
                Click(BUTTON_QUERY_END_DATE_OPEN_DATEPICKER);
                Console.WriteLine("clicked end date picker");
                Click(BUTTON_QUERY_END_DATE_CHOOSE_YEAR);
                Console.WriteLine("clicked start date choose year");
                if (year != getCurrentValueOfInputYear){
                    if (year < getCurrentValueOfInputYear){
                        for (int i = getCurrentValueOfInputYear; i > year; i--){
                            Click(BUTTON_QUERY_END_DATE_GO_PREVIOUS_YEAR);
                        }
                    }else {
                        for (int i = getCurrentValueOfInputYear; i < year; i++){
                            Click(BUTTON_QUERY_END_DATE_GO_NEXT_YEAR);
                            Console.WriteLine("clicked end date go to next year " +i + " times" );
                        }
                    }
                }
                Click(By.XPath("//span[contains(text(),'" + month + "')]"));
                Console.WriteLine("clicked end date month " + month + " successfully");
                Click(By.XPath("(//span[@class='ng-binding' and contains(text(),'" + day + "')])[3]"));
              
                 Console.WriteLine("clicked start date day " + day + " successfully");
            }catch (Exception e){
                Console.WriteLine("Element not found:" + e);
            }
            Sleepms(500);
            return this;
        }
       public LivePage SetQueryStartHour(string startHourParam = null){
            string hour = startHourParam == null ? Utils.Dates.GetCurrentHour() : startHourParam;
            SelectDropDown(SELECT_QUERY_START_HOUR, hour);
            return this;
       }
       public LivePage SetQueryStartMinute(string startMinuteParam = null){
            string minute = startMinuteParam == null ? Utils.Dates.GetCurrentHour() : startMinuteParam;
            SelectDropDown(SELECT_QUERY_START_MINUTE, minute);
            return this;
       }
       public LivePage SetQueryEndHour(string endHourParam = null){
            string hour = endHourParam == null ? Utils.Dates.GetCurrentHour() : endHourParam;
            SelectDropDown(SELECT_QUERY_END_HOUR, hour);
            return this;
       }
       public LivePage SetQueryEndMinute(string endMinuteParam = null){
            string minute = endMinuteParam == null ? Utils.Dates.GetCurrentHour() : endMinuteParam;
            SelectDropDown(SELECT_QUERY_END_MINUTE, minute);
            return this;
       }
       public LivePage ClickSearch(){
            Click(BUTTON_QUERY_SEARCH);
            return this;
       }
       public LivePage VerifyCourseName(string courseName){ 
           Assertion.AssertionCustom.AssertElementVisible("CourseName "+courseName+ " is not visible",Driver,
               By.XPath("//td[@class='ng-binding' and contains(text(),'" + courseName + "')]"));
          return this;
       }
       public LivePage ClickCloseButton(){
            Click(BUTTON_QUERY_CLOSE);
            return this;
       }
       public LivePage SelectTime(){
            try{
                Click(SELECT_TIME);
            }catch (Exception e){
                Console.WriteLine("Error occured in adding time to Live record, user: " + USER + ", Error: " + e);
            }
            return this;
       }
       public LivePage SaveScheduleButton(){
            try{
                Click(By.CssSelector("button[ng-click='saveMultiple()']"));
            }catch (Exception e){
                Console.WriteLine("Error occured in clicking save button to Schedule page, user: " + USER + ", Error: " + e);
            }
            return this;
       }
       public LivePage CheckLiveIsExist(){
            try{
                OpenLiveRecordDetail();
            }catch (Exception e){
                Console.WriteLine("Live not found: " + e.Message);
                return null;
            }
            ClickDeleteButtonInRecordDetail();
            ClickAreUSure();
            AssertLive();
            return this;
       }
       public LivePage ClickDeleteButtonInRecordDetail(){
            Click(BUTTON_DETAIL_DELETE);
            return this;
       }
       public LivePage ClickAreUSure(){
            Click(ALERT_ARE_U_SURE_OK);
            return this;
       }
       public LivePage ClickLinkInRecordDetail(){
            Click(BUTTON_RECORD_DETAIL);
            return this;
       }
       public LivePage ClickZoomInLink(){
            Click(ZOOM_LINK);
            return this;
       }
       public LivePage ClickToCopy(){
            Click(CLICK_TO_COPY);
            return this;
       }
       public LivePage ClickToCancel(){
            Click(CANCEL_IN_DETAILS);
            Sleepms(1000);
            return this;
       }
       public LivePage ClickToCancelAfterExport(){
            Click(CANCEL_AFTER_EXPORT);
            Sleepms(1000);
            return this;
       }
       public LivePage ClickAttendees(){
            Click(ATTENDEES);
            return this;
       }
       public LivePage ClickConfirmed(){
            Click(CONFIRMED);
            return this;
       }
       public LivePage ClickExportAll() {
            Click(EXPORT_ALL);
            return this;
       }
       public WebinarPage GoToWebinar(){
            try{
                OpenLiveRecordDetail();
                Click(BUTTON_RECORD_DETAIL);
                ClickCopyButton();
            }catch (Exception e){
                Console.WriteLine("Error occured in deleting Live record, user: " + USER + ", Error: " + e);
            }
            return new WebinarPage(Driver, USER);
       }
       public LivePage OpenLiveRecordDetail(){
            Click(BUTTON_LIVE_RECORD);
            return this;
       }
       private void ClickCopyButton() {
            Driver.Url = Driver.FindElement(BUTTON_COPY).GetAttribute("ng-click-copy");
       }
       public LivePage AssertStart(){
            try{
                AssertionCustom.AssertElementVisible("Element Not Found", Driver, ASSERT_START);
            }catch (Exception e){
                Console.WriteLine("Error occured in deleting Live record, user: " + USER + ", Error: " + e);
            }
            return this;
       }
       public LivePage SetTimezone(string timeZone){
            SelectDropDown(SELECT_TIMEZONE, timeZone);
            return this;
       }
       public LivePage SetHour(string hourParam = null){
            string hour = hourParam == null ? Utils.Dates.GetCurrentHour() : hourParam;
            SelectDropDown(SELECT_TIME_HOUR, hour);
            return this;
       }
       public LivePage SetMinute(string minuteParam = null){
            string minute = minuteParam == null ? Utils.Dates.GetCurrentMinute() : minuteParam;
            SelectDropDown(SELECT_TIME_MIN, minute);
            return this;
       }
        public LivePage SetDuration(int duration){
            SelectDropDown(SELECT_DURATION, duration);
            return this;
        }
        public LivePage SetRegistrationLimit(int limit){
            Type(SELECT_REGISTRATION_LIMIT, limit);
            return this;
        }
        public LivePage SetDescription(String description){
            Type(DIV_DESCRIPTION, description);
            return this;
        }
        public LivePage SetTrainer(string trainer){
            SelectDropDown(SELECT_TRAINER, trainer);
            return this;
        }
        public LivePage SetPrivate(){
            if (!IsSelected(CHECKBOX_PRIVATE))
                Click(CHECKBOX_PRIVATE);
            else
                Console.WriteLine("Already private is selected");
            return this;
        }
        public LivePage Submit(){
            Click(BUTTON_SUBMIT);
            return this;
        }
        public LivePage AssertLive(){
            AssertionCustom.AssertElementVisible("Element Not Found", Driver, ALERT_SUCCESS);
            return this;
        }
        public LivePage GoDate(int yearParam = 0, string monthParam = null, string dayParam = null){
            int year = yearParam == 0 ? Utils.Dates.GetCurrentYear() : yearParam;
            string month = monthParam == null ? Utils.Dates.GetCurrentMonth() : monthParam;
            string day = dayParam == null ? Utils.Dates.GetCurrentDay() : dayParam;

            string getCurrentValueOfInput = GetAttribute(INPUT_LIVE_LESSON_SELECT_DATE, "value");
            string[] words = getCurrentValueOfInput.Split('-');
            int getCurrentValueOfInputYear = Int32.Parse(words[0]);
            int getCurrentValueOfInputMonth = Int32.Parse(words[1]);
            string getCurrentValueOfInputDay = words[2];

            try{
                Click(INPUT_LIVE_LESSON_SELECT_DATE);
                Click(BUTTON_GO_TO_DATE_CHOOSE_YEAR);
                if (year != getCurrentValueOfInputYear){
                    if (year < getCurrentValueOfInputYear){
                        for (int i = getCurrentValueOfInputYear; i > year; i--){
                            Click(BUTTON_GO_TO_DATE_PREVIOUS_YEAR);
                        }
                    }else{
                        for (int i = getCurrentValueOfInputYear; i < year; i++){
                            Click(BUTTON_GO_TO_DATE_NEXT_YEAR);
                        }
                    }
                }
                Click(By.XPath("//span[contains(text(),'" + month + "')]"));
                Click(By.XPath("(//span[@class='ng-binding' and contains(text(),'" + day + "')])"));
            }catch(Exception e){
                Console.WriteLine("Element not found:" + e);
            }
            Sleepms(500);
            return this;
        }
        public LivePage StudentRegister(){
            Click(BUTTON_REGISTER);
            return this;
        }
        public LivePage ClickQueryButton(){
            Click(BUTTON_QUERY);
            return this;
        }
    }
}
