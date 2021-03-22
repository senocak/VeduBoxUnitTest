using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using VeduBoxUnitTest.Kurumsal.Pages;
using VeduBoxUnitTest.Utils;

namespace VeduBoxUnitTest.StepDefinitions{
    [Binding]
    public class StepDefinitionsCommon{
        private ScenarioContext _scenarioContext;
        private readonly int NEXT_YEAR = 2;
        private readonly int NEXT_DAY = 23;

        public StepDefinitionsCommon(ScenarioContext scenarioContext){
            _scenarioContext = scenarioContext;
        }
        public static IWebDriver Driver;
        [BeforeScenario]
        public void BeforeWebScenarioStudent(){
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--lang=en");
            Driver = new ChromeDriver(options);
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
        }
        [AfterScenario]
        [Obsolete]
        public void After(){
            if (_scenarioContext.TestError != null){
                //WebBrowser.Driver.CaptureScreenShot(_scenarioContext.ScenarioInfo.Title);
                Console.WriteLine("Title:" + ScenarioContext.Current.ScenarioInfo.Title + " is failed.");
            }
         Driver.Quit();
        }
        [Given(@"Open Kurumsal Login Page")]
        public void GivenOpenKurumsalLoginPage(){
            new OpenUrl(Driver).OpenPage();
        }
        [Given(@"Login as ""(.*)""")]
        public void WhenLoginAs(string user) {
            var username = "";
            var password = "";
            if (user == Constants.Roles.Admin.ToString()){
                username = "defaultadmin";
                password = "12345";
            }else if (user == Constants.Roles.Instructor.ToString()){
                username = "defaultinstructor";
                password = "12345";
            }else if (user == Constants.Roles.Student.ToString()){
                username = "defaultstudent";
                password = "12345";
            }else if (user == Constants.Roles.Parent.ToString()){
                username = "defaultparent";
                password = "12345";
            }else{
                string[] words = user.Split('@');
                if(words[0] == Constants.Roles.Custom.ToString()){
                    string[] infos = words[1].Split(':');
                    if (infos[0] == null || infos[0] == "" || infos[1] == null || infos[1] == ""){
                        throw new Exception("You have to define a user.");
                    }
                    username = infos[0];
                    password = infos[1];
                }else{
                    throw new Exception("Unrecognized user format.");
                }
            }
            new LoginPage(Driver).EnterUsername(username).EnterPassword(password).Submit();
        }
        [Given(@"admin checks live is exist")]
        public void GivenAdminChecksLiveİsExist(){
            new HomePage(Driver)
                .OpenLivePage(Constants.Roles.Admin.ToString())
                .GoDate(Utils.Dates.GetNextYear(NEXT_YEAR), Utils.Dates.GetNextMonth(Months.April), Utils.Dates.GetNextDay(NEXT_DAY))
                .CheckLiveIsExist();
        }
        [Given(@"admin adds new live with")]
        public void ThenAddNewLiveWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenLivePage(Constants.Roles.Admin.ToString())
                .AddNew()
                .SelectCourse(dictionary["course_name"])
                .SubmitSelectedCourse()
                .SetDate(Utils.Dates.GetNextYear(NEXT_YEAR), Utils.Dates.GetNextMonth(Months.April), Utils.Dates.GetNextDay(NEXT_DAY))
                .SelectMeetingType(dictionary["meetingType"])
                .EnterTitle(dictionary["title"])
                .SetHour()
                .SetTimezone(dictionary["timezone"])
                .SetDuration(Int32.Parse(dictionary["duration"]))
                .SetRegistrationLimit(Int32.Parse(dictionary["registrationLimit"]))
                .SetDescription(dictionary["description"])
                //.setTrainer("test eğitmen")
                .SetStudent(dictionary.ContainsKey("student") ? dictionary["student"] : null)
                .Submit()
                .AssertLive();
        }
        
        [Then(@"admin query live")]
        public void AdminQueryAddedLive(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenLivePage(Constants.Roles.Admin.ToString())
                .ClickQueryButton()
                .SetQueryStartDate(Utils.Dates.GetNextYear(NEXT_YEAR), Utils.Dates.GetNextMonth(Months.April), Utils.Dates.GetNextDay(NEXT_DAY))
                .SetQueryEndDate(Utils.Dates.GetNextYear(NEXT_YEAR+1), Utils.Dates.GetNextMonth(Months.April), Utils.Dates.GetNextDay(NEXT_DAY))
                .SetQueryStartHour(dictionary["startHourParam"])
                .SetQueryStartMinute(dictionary["startMinuteParam"])
                .SetQueryEndHour(dictionary["endHourParam"])
                .SetQueryEndMinute(dictionary["endMinuteParam"])
                .ClickSearch()
                .VerifyCourseName(dictionary["courseName"])
                .ClickCloseButton();
        }
        [Then(@"admin deletes live")]
        public void AdminDeleteAddedLive(){
            new HomePage(Driver)
                .OpenLivePage(Constants.Roles.Admin.ToString())
                .GoDate(Utils.Dates.GetNextYear(NEXT_YEAR), Utils.Dates.GetNextMonth(Months.April), Utils.Dates.GetNextDay(NEXT_DAY))
                .OpenLiveRecordDetail()
                .ClickDeleteButtonInRecordDetail()
                .ClickAreUSure()
                .AssertLive();
        }
        [Then(@"admin copies zoom link")]
        public void AdminCopiesZoomLink(){
            new HomePage(Driver)
                .OpenLivePage(Constants.Roles.Admin.ToString())
                //.goDate(Utils.Dates.getNextYear(NEXT_YEAR), Utils.Dates.getNextMonth(NEXT_MONTH), Utils.Dates.getNextDay(NEXT_DAY))
                .OpenLiveRecordDetail()
                .ClickLinkInRecordDetail()
                .ClickZoomInLink()
                .ClickToCopy()
                .AssertLive()
                .ClickToCancel()
                .OpenLiveRecordDetail();
        }
        [Then(@"admin exports attendees report")]
        public void AdminExportsAttendeesReport() {
            new HomePage(Driver)
                .OpenLivePage(Constants.Roles.Admin.ToString())
                .OpenLiveRecordDetail()
                .ClickAttendees()
                .ClickConfirmed()
                .ClickExportAll()
                .ClickToCancelAfterExport()
                .OpenLiveRecordDetail();
        }
        [Given(@"admin adds new user with")]
        public void AdminAddsNewUserWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                    .OpenStudentsPage(Constants.Roles.Admin.ToString())
                    .AddNew()
                    .SetFirstName(dictionary["firstName"])
                    .SetLastName(dictionary["lastName"])
                    .SelectBranch(dictionary["branch"])
                    .SetEmail(dictionary["email"])
                    .SetUserName(dictionary["userName"])
                    .SetPassword(dictionary["password"])
                    .SetCatalog(dictionary["catalog"])
                    .SetDescription(dictionary["description"])
                    .SetEmailConfirmed()
                    .SetGpdrPolicy()
                    .Submit()
                    .Assert();
        }
        [Given(@"admin checks user is exist")]
        public void GivenAdminChecksUserİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                    .OpenStudentsPage(Constants.Roles.Admin.ToString())
                    .SearchNewlyAddedUserByEmailAndDeleteIt(dictionary["email"]);
        }
        [Then(@"Delete User")]
        public void DeleteUser(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenStudentsPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedUserByEmail(dictionary["email"])
                .Click3Points()
                .ClickDeleteUserButton()
                .ClickAreUSure()
                .Assert();
        }
        [Given(@"admin adds new course with")]
        public void AddNewCourse(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            Console.WriteLine(dictionary["category"]);
            new HomePage(Driver)
                .OpenCoursesPage(Constants.Roles.Admin.ToString())
                .AddNew()
                .SetName(dictionary["name"])
                .SetTags(dictionary["tags"])
                .SetCreateCourseDescription(dictionary["description"])
                .SelectCategory(dictionary["category"])
                .SelectTeacher(dictionary["teacher"])
                .SetCatalog(dictionary["catalog"])
                .Submit()
                .Assert();
        }

        [Then(@"instructor deletes live")]
        public void InstructorDeleteAddedLive(){
            new HomePage(Driver)
                .OpenLivePage(Constants.Roles.Instructor.ToString())
                .GoDate()
                .OpenLiveRecordDetail()
                .ClickDeleteButtonInRecordDetail()
                .ClickAreUSure()
                .AssertLive();
        }
        [Given(@"admin checks course is exist")]
        public void GivenAdminChecksCourseİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenCoursesPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedCourseByName(dictionary["name"])
                .DeleteAndAssertNewlyAddedCourseIfIsExist();
        }
        [Then(@"admin deletes added Course")]
        public void ThenAdminDeletesAddedCourse(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenCoursesPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedCourseByName(dictionary["name"])
                .DeleteNewlyAddedCourse()
                .Assert();
        }
        [Given(@"instructor checks live is exist")]
        public void GivenİnstructorChecksLiveİsExist(){
            new HomePage(Driver)
                .OpenLivePage(Constants.Roles.Admin.ToString())
                .GoDate()
                .CheckLiveIsExist();
        }
        [Given(@"instructor adds new live with")]
        public void GivenİnstructorAddsNewLiveWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenLivePage(Constants.Roles.Instructor.ToString())
                .AddNew()
                .SelectCourse(dictionary["course_name"])
                .SubmitSelectedCourse()
                .SetDate()
                .SelectMeetingType(dictionary["meetingType"])
                .EnterTitle(dictionary["title"])
                .SetHour()
                .SetTimezone(dictionary["timezone"])
                .SetDuration(Int32.Parse(dictionary["duration"]))
                .SetRegistrationLimit(Int32.Parse(dictionary["registrationLimit"]))
                .SetDescription(dictionary["description"])
                .Submit()
                .AssertLive();
        }
        [Then(@"instructor query live")]
        public void InstructorQueryAddedLive(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenLivePage(Constants.Roles.Instructor.ToString())
                .ClickQueryButton()
                .SetQueryStartDate()
                .SetQueryEndDate()
                .SetQueryStartHour(dictionary["startHourParam"])
                .SetQueryStartMinute(dictionary["startMinuteParam"])
                .SetQueryEndHour(dictionary["endHourParam"])
                .SetQueryEndMinute(dictionary["endMinuteParam"])
                .ClickSearch()
                .VerifyCourseName(dictionary["courseName"])
                .ClickCloseButton();
        }
        [Then(@"verify start live and delete live with")]
        public void ThenVerifyStartLiveAndDeleteLiveWith(){
            new LivePage(Driver, Constants.Roles.Admin.ToString())
                //.goDate(YEAR, MONTH, DAY)
                .AssertStart()
                .OpenLiveRecordDetail()
                .ClickDeleteButtonInRecordDetail()
                .ClickAreUSure();
        }
        [Then(@"student verify start live")]
        public void ThenStudentVerifyStartLive(){
            new HomePage(Driver)
                .OpenLivePage(Constants.Roles.Student.ToString())
                .GoDate()
                .StudentRegister()
                .AssertStart();
        }
        [Given(@"instructor checks student is exist")]
        public void GivenİnstructorChecksStudentİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenStudentsPage(Constants.Roles.Instructor.ToString())
                .SearchNewlyAddedUserByEmailAndDeleteIt(dictionary["email"]);
        }
        [Given(@"instructor adds new student with")]
        public void GivenİnstructorAddsNewStudentWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenStudentsPage(Constants.Roles.Instructor.ToString())
                .AddNew()
                .SetFirstName(dictionary["firstName"])
                .SetLastName(dictionary["lastName"])
                .SelectBranch(dictionary["branch"])
                .SetEmail(dictionary["email"])
                .SetUserName(dictionary["userName"])
                .SetPassword(dictionary["password"])
                .SetCatalog(dictionary["catalog"])
                .SetEmailConfirmed()
                .SetGpdrPolicy()
                .Submit()
                .Assert();
        }
        [Then(@"instructor delete student")]
        public void ThenİnstructorDeleteStudent(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new StudentsPage(Driver, Constants.Roles.Instructor.ToString())
                .SearchNewlyAddedUserByEmail(dictionary["email"])
                .Click3Points()
                .ClickDeleteUserButton()
                .ClickAreUSure()
                .Assert();
        }
        [Given(@"instructor checks course is exist")]
        public void GivenİnstructorChecksCourseİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                    .OpenCoursesPage(Constants.Roles.Instructor.ToString())
                    .SearchNewlyAddedCourseByName(dictionary["name"])
                    .DeleteAndAssertNewlyAddedCourseIfIsExist();
        }
        [Given(@"instructor adds new course with")]
        public void GivenİnstructorAddsNewCourseWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                    .OpenCoursesPage(Constants.Roles.Instructor.ToString())
                    .AddNew()
                    .SetName(dictionary["name"])
                    .SelectCategory(dictionary["category"])
                    .Submit()
                    .Assert();
        }
        [Then(@"instructor delete course")]
        public void ThenİnstructorDeleteCourse(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenCoursesPage(Constants.Roles.Instructor.ToString())
                    .SearchNewlyAddedCourseByName(dictionary["name"])
                    .DeleteAndAssertNewlyAddedCourseIfIsExist();
        }
        [Given(@"instructor adds subject with")]
        public void ThenİnstructorAddsSubject(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new CoursesPage(Driver, Constants.Roles.Instructor.ToString())
                    .SearchNewlyAddedCourseByName(dictionary["course"])
                    .OpenCourseDetail(dictionary["course"])
                    .OpenCourseUpdate()
                    .AddSubject()
                    .EnterSubjectTitle(dictionary["title"])
                    .SaveSubjectTitle()
                    .Assert()
                    .FinishEditing()
                    .AssertSubjectIsVisible(dictionary["title"]);
            new HomePage(Driver).OpenCoursesPage(Constants.Roles.Instructor.ToString());
        }
        [Given(@"instructor adds new webinar with")]
        public void GivenİnstructorAddsNewWebinarWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenLivePage(Constants.Roles.Instructor.ToString())
                .AddNew()
                .SelectCourse(dictionary["course_name"])
                .SubmitSelectedCourse()
                .SetDate()
                .SelectMeetingType(dictionary["meetingType"])
                .EnterTitle(dictionary["title"])
                .SetHour()
                .SetTimezone(dictionary["timezone"])
                .SetDuration(Int32.Parse(dictionary["duration"]))
                .SetRegistrationLimit(Int32.Parse(dictionary["registrationLimit"]))
                .SetDescription(dictionary["description"])
                .Submit()
                .AssertLive();
        }
        [Then(@"instructor copies webinar URL with")]
        public void ThenInstructorCopiesWebinarUrlWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                    .OpenLivePage(Constants.Roles.Instructor.ToString())
                    //.goDate(YEAR, MONTH, DAY)
                    .GoToWebinar()
                    .EnterFirstName(dictionary["firstName"])
                    .EnterLastName(dictionary["lastName"])
                    .EnterEmail(dictionary["email"])
                    .EnterConfirmEmail(dictionary["confirmEmail"])
                   // .SetAgreePolicy()
                   // .SetGpdrPolicy()
                    .ClickCreateAccount()
                    .AssertEmailSentText();
        }
        [Then(@"instructor deletes webinar with")]
        public void ThenİnstructorDeletesWebinarWith(){
            new HomePage(Driver).OpenLivePage(Constants.Roles.Instructor.ToString());
            new LivePage(Driver, Constants.Roles.Instructor.ToString())
                    .GoDate()
                    .OpenLiveRecordDetail()
                    .ClickDeleteButtonInRecordDetail()
                    .ClickAreUSure()
                    .AssertLive();
        }
        [Then(@"student registers live")]
        public void ThenStudentRegistersLive(){
            new HomePage(Driver)
                .OpenLivePage(Constants.Roles.Instructor.ToString())
                .GoDate()
                .StudentRegister()
                .AssertLive();
        }
        [Then(@"student takes exam")]
        public void ThenStudentTakesExam(){
            new HomePage(Driver)
                .OpenExamPage(Constants.Roles.Student.ToString())
                .GetFirstExam()
                .ClickStartExamButton()
                .ClickFinishExamButton()
                .ClickAreUSure()
                .Assert();
        }
        [Then(@"student purchase course")]
        public void ThenStudentPurchaseCourse(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenPortalPage(Constants.Roles.Student.ToString())
                .SearchEntry(dictionary["entry"])
                .ClickView()
                //.selectLogin()
                .SelectContinue()
                .SelectIsAgree()
                .ClickNext()
                .EnterName(dictionary["name"])
                .EnterSurName(dictionary["surname"])
                .EnterCity(dictionary["city"])
                .EnterDistrict(dictionary["district"])
                .EnterPhone(dictionary["phone"])
                .EnterAddress(dictionary["address"])
                .ClickNext()
                .EnterCardName(dictionary["cardName"])
                .EnterCardNumber(dictionary["cardNumber"])
                .EnterCardDate(dictionary["cardDate"])
                .EnterCardCvc(dictionary["cardCVC"])
                .ClickPayButton();
        }
        [Then(@"Student add course package purchase and reflection")]
        public void ThenStudentAddCoursePackagePurchaseAndReflection(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenPortalPage(Constants.Roles.Student.ToString())
                .ClickCoursesPackages()
                .SearchCoursesPackageEntry(dictionary["entry"])
                .ClickCoursePackagesView()
                .SelectCoursesPackageContinue()
                //.closeDismiss()
                .SelectIsAgree()
                .ClickNext()
                .EnterPackageName(dictionary["name"])
                .EnterPackageSurname(dictionary["surname"])
                .EnterPackageCity(dictionary["city"])
                .EnterPackageCountry(dictionary["country"])
                .EnterPackagePhone(dictionary["phone"])
                .EnterPackageAddress(dictionary["address"])
                .SelectSameDelivery()
                .ClickNext()
                .EnterCardName(dictionary["cardName"])
                .EnterCardNumber(dictionary["cardNumber"])
                .EnterCardDate(dictionary["cardDate"])
                .EnterCardCvc(dictionary["cardCVC"])
                 .ClickPayButton()
                 .AssertPaymentIsOk();
        }
        [Then(@"Student verifies course package is exist on Courses")]
        public void ThenStudentVerifiesCoursePackageİsExistOnCourses(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenCoursesPage(Constants.Roles.Student.ToString())
                .SearchNewlyAddedCourseByName(dictionary["Name"])
                .AssertSubjectIsVisible(dictionary["title"]);
        }
        [Then(@"Student make portal shopping both course and course package")]
        public void ThenStudentMakePortalShoppingBothCourseAndCoursePackage(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenPortalPage(Constants.Roles.Student.ToString())
                .SearchEntry(dictionary["course"])
                .AddToCart()
                .ClickCoursesPackages()
                .SearchCoursesPackageEntry(dictionary["coursePackage"])
                .AddtoCoursePackageCart()
                .GoToCart()
                .SelectCoursesPackageContinue()
                .SelectIsAgree()
                .ClickNext()
                .EnterPackageName(dictionary["name"])
                .EnterPackageSurname(dictionary["surname"])
                .EnterPackageCity(dictionary["city"])
                .EnterPackageCountry(dictionary["country"])
                .EnterPackagePhone(dictionary["phone"])
                .EnterPackageAddress(dictionary["address"])
                .SelectSameDelivery()
                .ClickNext()
                .EnterCardName(dictionary["cardName"])
                .EnterCardNumber(dictionary["cardNumber"])
                .EnterCardDate(dictionary["cardDate"])
                .EnterCardCvc(dictionary["cardCVC"])
                .ClickPayButton()
                .AssertPaymentIsOk();
        }
        [Given(@"instructor adds file source with")]
        public void GivenİnstructorAddsFileSourceWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new CoursesPage(Driver, Constants.Roles.Instructor.ToString())
                    .SearchNewlyAddedCourseByName(dictionary["course"])
                    .OpenCourseDetail(dictionary["course"])
                    .OpenCourseUpdate()
                    .AddResource()
                    .ClickResourceTypeDoc()
                    //.clickOkAfterType()
                    .EnterResourceTitle(dictionary["title"])
                    .EnterResourceDescription(dictionary["desc"])
                    .SelectDownloadable()
                    .SelectUserReviewEnableForDoc()
                    .SelectFile()
                    .ClickSaveButton()
                    .Assert();
            new HomePage(Driver).OpenCoursesPage(Constants.Roles.Instructor.ToString());
        }
        [Given(@"instructor adds video source with")]
        public void GivenİnstructorAddsVideoSourceWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new CoursesPage(Driver, Constants.Roles.Instructor.ToString())
                    .SearchNewlyAddedCourseByName(dictionary["course"])
                    .OpenCourseDetail(dictionary["course"])
                    .OpenCourseUpdate()
                    .AddResource()
                    .ClickResourceTypeVideo()
                    .ClickVimeo()
                    //.clickOkAfterType()
                    .EnterResourceTitle(dictionary["title"])
                    .EnterResourceDescription(dictionary["desc"])
                    .SelectVideo1()
                    .ClickUpload()
                    .SelectCourseVideoPrev()
                    .SelectCourseVideoDownloadable()
                    .SelectVideoForward()
                    .SelectVideoUserReview()
                    .WaitUntilFileIsUploaded()
                    .ClickCourseVideoSubmit()
                    .Assert();
            new HomePage(Driver).OpenCoursesPage(Constants.Roles.Instructor.ToString());
        }
        [Then(@"Verify earnings payment")]
        public void ThenVerifyEarningsPayment(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenEarningsPage(Constants.Roles.Admin.ToString())
                .SearchEntry(dictionary["name"]);
        }
        [Given(@"instructor adds video with vimeo")]
        public void GivenİnstructorAddsVideoWithVimeo(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new CoursesPage(Driver, Constants.Roles.Instructor.ToString())
                    .SearchNewlyAddedCourseByName(dictionary["course"])
                    .OpenCourseDetail(dictionary["course"])
                    .OpenCourseUpdate()
                    .AddResource()
                    .ClickResourceTypeVideo()
                    .ClickVimeo()
                    //.clickOkAfterType()
                    .EnterResourceTitle(dictionary["title"])
                    .EnterResourceDescription(dictionary["desc"])
                    .SelectVimeoId()
                    .EnterVimeoId(dictionary["vimeo_id"])
                    .SelectCourseVideoDownloadable()
                    .SelectVideoForward()
                    .SelectCourseVideoPrev()
                    .SelectVideoUserReview()
                    .ClickCourseExistingVideoSubmit()
                    .Assert();
            new HomePage(Driver).OpenCoursesPage(Constants.Roles.Instructor.ToString());
        }
        [Given(@"instructor adds content as link")]
        public void GivenİnstructorAddsContentAsLink(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new CoursesPage(Driver, Constants.Roles.Instructor.ToString())
                    .SearchNewlyAddedCourseByName(dictionary["course"])
                    .OpenCourseDetail(dictionary["course"])
                    .OpenCourseUpdate()
                    .AddResource()
                    .ClickResourceTypeLink()
                   // .clickOkAfterType()
                    .EnterResourceTitle(dictionary["title"])
                    .SetDescription(dictionary["desc"])
                    .EnterLink(dictionary["link"])
                    .SelectVideoUserReview()
                    .ClickResourceLinkSave()
                    .Assert();
            new HomePage(Driver).OpenCoursesPage(Constants.Roles.Instructor.ToString());
        }
        [Given(@"instructor adds content as embed code")]
        public void GivenİnstructorAddsContentAsEmbedCode(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new CoursesPage(Driver, Constants.Roles.Instructor.ToString())
                    .SearchNewlyAddedCourseByName(dictionary["course"])
                    .OpenCourseDetail(dictionary["course"])
                    .OpenCourseUpdate()
                    .AddResource()
                    .ClickResourceTypeEmbedCode()
                    //.clickOkAfterType()
                    .EnterResourceTitle(dictionary["title"])
                    .SetEmbeddedDescription(dictionary["desc"])
                    .EnterEmbedCode(dictionary["embed_code"])
                    .SelectVideoUserReview()
                    .ClickResourceLinkSave()
                    .Assert();
            new HomePage(Driver).OpenCoursesPage(Constants.Roles.Instructor.ToString());
        }
        [Given(@"instructor checks question is exist")]
        public void GivenInstructorChecksMultipleChoiceQuestionİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenQuestionsPage(Constants.Roles.Instructor.ToString())
                .SearchNewlyAddedQuestionByNameAndDeleteIt(dictionary["name"]);
        }
        [Given(@"instructor adds multiple choice question with")]
        public void GivenİnstructorAddsMultipleChoiceQuestionWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenQuestionsPage(Constants.Roles.Instructor.ToString())
                .ClickAddNewButton()
                .TypeQuestionInput(dictionary["question"])
                .EnterPoint(Int32.Parse(dictionary["point"]))
                .ClickDeleteButtonLastElementOfAnswers()
                .EnterAnswerA(dictionary["choiceA"])
                .EnterAnswerB(dictionary["choiceB"])
                .EnterAnswerC(dictionary["choiceC"])
                .EnterAnswerD(dictionary["choiceD"])
                .ClickRigthAnswerAsC()
                .ClickIsPublic()
                .ClickIsEditable()
                .SelectTestCategory(dictionary["TestCategory"])
                .Submit()
                .Assert();
        }
        [Then(@"instructor deletes question with")]
        public void ThenInstructorDeletesQuestionWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new QuestionsPage(Driver, Constants.Roles.Instructor.ToString())
                    .SearchNewlyAddedQuestionByName(dictionary["name"])
                    .ClickThreePoints()
                    .ClickDeleteSingleQuestionPopup()
                    .Assert();
        }
        [Given(@"instructor batch create question with")]
        public void GivenİnstructorBatchCreateQuestionWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new QuestionsPage(Driver, Constants.Roles.Instructor.ToString())
                    .ClickBatchCreateButton()
                    .EnterExcelFile()
                    .SelectTestCategory(dictionary["TestCategory"])
                    .ClickUploadExcelButton()
                    .ClickQuestionListAcceptButton()
                    .RefreshPage();
            new HomePage(Driver).OpenQuestionsPage(Constants.Roles.Instructor.ToString());
        }
        [Given(@"instructor adds true false question with")]
        public void GivenİnstructorAddsTrueFalseQuestionWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenQuestionsPage(Constants.Roles.Instructor.ToString())
                .ClickAddNewButton()
                .TypeQuestionInput(dictionary["question"])
                .SelectQuestionType("True False")
                .EnterPoint(Int32.Parse(dictionary["point"]))
                .SelectTrueFalseAnswer(false)
                .ClickIsPublic()
                .ClickIsEditable()
                .SelectTestCategory(dictionary["TestCategory"])
                .Submit()
                .Assert();
        }
        [Given(@"instructor adds open_ended question with")]
        public void GivenİnstructorAddsOpen_EndedQuestionWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenQuestionsPage(Constants.Roles.Instructor.ToString())
                .ClickAddNewButton()
                .TypeQuestionInput(dictionary["question"])
                .SelectQuestionType("Open-Ended")
                .EnterPoint(Int32.Parse(dictionary["point"]))
                .ClickIsPublic()
                .ClickIsEditable()
                .SelectTestCategory(dictionary["TestCategory"])
                .Submit()
                .Assert();
        }
        [Given(@"instructor adds matching question with")]
        public void GivenİnstructorAddsMatchingQuestionWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenQuestionsPage(Constants.Roles.Instructor.ToString())
                .ClickAddNewButton()
                .TypeQuestionInput(dictionary["question"])
                .SelectQuestionType("Matching")
                .EnterPoint(Int32.Parse(dictionary["point"]))
                .EnterMatching1(dictionary["matching1"])
                .EnterMatching2(dictionary["matching2"])
                .Delete3ThMatchingInput()
                .ClickIsPublic()
                .ClickIsEditable()
                .SelectTestCategory(dictionary["TestCategory"])
                .Submit()
                .Assert();
        }
        [Given(@"instructor adds ordering question with")]
        public void GivenİnstructorAddsOrderingQuestionWith(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenQuestionsPage(Constants.Roles.Instructor.ToString())
                .ClickAddNewButton()
                .TypeQuestionInput(dictionary["question"])
                .EnterPoint(Int32.Parse(dictionary["point"]))
                 .SelectQuestionType("Ordering")
                .EnterOrdering1(dictionary["ordering1"])
                .EnterOrdering2(dictionary["ordering2"])
                .EnterOrdering3(dictionary["ordering3"])
                .ClickAddChoice()
                .EnterOrdering4(dictionary["ordering4"])
                .ClickIsPublic()
                .ClickIsEditable()
                .SelectTestCategory(dictionary["TestCategory"])
                .Submit()
                .Assert();
        }
        [Given(@"instructor adds fill in the blanks question with")]
        public void GivenİnstructorAddsFillInTheBlanksQuestionWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenQuestionsPage(Constants.Roles.Instructor.ToString())
                .ClickAddNewButton()
                .TypeQuestionInput(dictionary["question"])
                .SelectQuestionType("Fill In The Blanks")
                .EnterPoint(Int32.Parse(dictionary["point"]))
                .ClickIsPublic()
                .ClickIsEditable()
                .SelectTestCategory(dictionary["TestCategory"])
                .Submit()
                .Assert();
        }
        [Given(@"instructor adds multiple answer question with")]
        public void GivenİnstructorAddsMultipleAnswerQuestionWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenQuestionsPage(Constants.Roles.Instructor.ToString())
                .ClickAddNewButton()
                .TypeQuestionInput(dictionary["question"])
                .SelectQuestionType("Multiple Answer")
                .EnterPoint(Int32.Parse(dictionary["point"]))
                .Answer1ForMultipleChoice(dictionary["answer1"])
                .Answer2ForMultipleChoice(dictionary["answer2"])
                .Answer3ForMultipleChoice(dictionary["answer3"])
                .ClickIsPublic()
                .ClickIsEditable()
                .SelectTestCategory(dictionary["TestCategory"])
                .Submit()
                .Assert();
        }

        [Given(@"instructor checks test poll question is exist")]
        public void GivenİnstructorChecksTestPollQuestionİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenTestPoolPage(Constants.Roles.Instructor.ToString())
                .SearchNewlyAddedPollTestByNameAndDeleteIt(dictionary["name"]);
        }

        [Given(@"instructor adds test pool multiple choice with")]
        public void GivenİnstructorAddsMultipleChoiceTestPollWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenTestPoolPage(Constants.Roles.Instructor.ToString())
                .ClickAddButton()
                .EnterName(dictionary["name"])
                .EnterDuration(Int32.Parse(dictionary["time"]))
                .SelectIsPublic()
                .ClickIsReturnBetweenQuestions()
                .SelectTestCategory(dictionary["TestCategory"])
                .ClickNextButton()
                .EnterQuestionName(dictionary["question"])
                .ClickSetButton()
                .ClickSaveButton()
                .Assert();
        }
        [Given(@"instructor delete tests with")]
        public void GivenİnstructorDeleteTestsWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new TestPoolPage(Driver, Constants.Roles.Instructor.ToString())
                .SearchNewlyAddedPollTestByName(dictionary["name"])
                .ClickThreePoints()
                .ClickDeleteTest()
                .ClickAreUSure()
                .Assert();
            new HomePage(Driver).OpenQuestionsPage(Constants.Roles.Instructor.ToString());
        }
        [Then(@"admin adds new branch")]
        public void ThenAdminAddsNewBranch(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenBranchPage(Constants.Roles.Instructor.ToString())
                .ClickAddButton()
                .EnterName(dictionary["name"])
                .EnterLimit(Int32.Parse(dictionary["limit"]))
                .ClickSaveButton()
                .Assert();
        }
        [Given(@"admin checks branch is exist")]
        public void GivenAdminChecksBranchİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenBranchPage(Constants.Roles.Instructor.ToString())
                .SearchNewlyAddedBranchByNameAndDeleteItAndAssertIt(dictionary["name"]);
        }
        [Then(@"admin deletes added branch")]
        public void ThenAdminDeletesAddedBranch(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenBranchPage(Constants.Roles.Instructor.ToString())
                .SearchNewlyAddedBranchByName(dictionary["name"])
                .SelectBranch(dictionary["name"])
                .DeleteNewlyAddedBranch()
                .ClickAreYouSure()
                .Assert();
        }
        [Then(@"admin adds instructor")]
        public void ThenAdminAddsİnstructor(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenTeachersPage(Constants.Roles.Admin.ToString())
                .ClickAddButton()
                .EnterFirstName(dictionary["first_name"])
                .EnterLastName(dictionary["last_name"])
                .SelectBranchName(dictionary["branch"])
                .EnterEmailName(dictionary["email"])
                .EnterUserNameName(dictionary["username"])
                .EnterPasswordName(dictionary["password"])
                .SelectIsGuidanceTeacher()
                .SelectGpdrPolicy()
                .ClickSaveButton()
                .Assert();
        }
        [Then(@"admin adds role to instructor")]
        public void ThenAdminAddsRoleToİnstructor(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new TeachersPage(Driver, Constants.Roles.Admin.ToString())
                .SearchNewlyAddedModeratorByName(dictionary["name"])
                .ClickThreePoints()
                .ClickRolesInThreePoints()
                .SelectRole(dictionary["role1"])
                .SelectRole(dictionary["role2"])
                .ClickRoleSaveButton();
        }
        [Given(@"admin checks instructor is exist")]
        public void GivenAdminChecksİnstructorİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenTeachersPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedModeratorByNameAndDeleteIt(dictionary["name"]);
        }
        [Then(@"admin delete instructor")]
        public void ThenAdminDeleteİnstructor(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new TeachersPage(Driver, Constants.Roles.Admin.ToString())
                .SearchNewlyAddedModeratorByName(dictionary["name"])
                .ClickThreePoints()
                .ClickDeleteInThreePoints()
                .ClickAreYouSure()
                .Assert();
        }
        [Given(@"admin checks announcement is exist")]
        public void GivenAdminChecksAnnouncementİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenAnnouncementsPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedAnnouncementAndDeleteIt(dictionary["name"]);
        }
        [Given(@"admin adds new announcement with")]
        public void GivenAdminAddsNewAnnouncementWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
               .OpenAnnouncementsPage(Constants.Roles.Admin.ToString())
               .ClickAddButton()
               .EnterTitle(dictionary["title"])
               .EnterDesc(dictionary["description"])
               .SelectShowToStudents()
               .SelectShowToTeachers()
               .SelectShowToParents()
               //.EnterEndDate()
               .ClickSaveButton()
               .Assert();
        }
        [Then(@"admin deletes announcement")]
        public void ThenAdminDeletesAnnouncementİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenAnnouncementsPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedAnnouncement(dictionary["name"])
                .Click3Points()
                .ClickDeleteButton()
                .ClickAreUSure()
                .Assert();
        }
        [Given(@"admin checks parent is exist")]
        public void GivenAdminChecksParentİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenParentPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedParentAndDeleteIt(dictionary["email"]);
        }
        [Then(@"admin adds parent")]
        public void ThenAdminAddsParent(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenParentPage(Constants.Roles.Admin.ToString())
                .ClickAddButton()
                .EnterFirstName(dictionary["first_name"])
                .EnterLastName(dictionary["last_name"])
                .ClickAnotherChildButton()
                .SelectFirstBranchName(dictionary["firstBranchName"])
                .SelectFirstStudents(dictionary["firstStudents"])
                .ClickAnotherChildButton()
                .SelectSecondBranchName(dictionary["secondBranchName"])
                .SelectSecondStudents(dictionary["secondStudents"])
                .EnterEmail(dictionary["email"])
                .EnterUserName(dictionary["username"])
                .EnterPassword(dictionary["password"])
                //.clickGenerate()
                .SelectGpdr()
                .ClickSaveButton()
                .Assert();
        }
        [Then(@"admin adds role to parent")]
        public void ThenAdminAddsRoleToParent(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenParentPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedParent(dictionary["email"])
                .Click3Points()
                .ClickRolesInThreePoints()
                .SelectRole(dictionary["role1"])
                .ClickRoleSaveButton();
        }
        [When(@"custom parent switch to admin")]
        public void WhenCustomParentSwitchToAdmin(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .ClickUpdateAcceptButton()
                .AssertRoleIs(Constants.Roles.Parent.ToString())
                .ClickUserName()
                .ClickRoleModal()
                .EnterPassword(dictionary["password"])
                .ClickChangeButton()
                .AssertRoleIs(Constants.Roles.Admin.ToString());
        }
        [Then(@"admin deletes added parent")]
        public void ThenAdminDeletesAddedParent(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenParentPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedParent(dictionary["email"])
                .Click3Points()
                .ClickDeleteButton()
                .ClickAreUSure()
                .Assert();
        }
        [Then(@"Admin adds poll")]
        public void ThenAdminAddsPoll(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenPollsPage(Constants.Roles.Admin.ToString())
                .ClearSearchBox()
                .ClickAddButton()
                .EnterName(dictionary["Name"])
                .EnterDescription(dictionary["Description"])
                .EnterRepeatNumber(Int32.Parse(dictionary["RepeatNumber"]))
                .SelectIsMandatory()
                .SetDate()
                .ClickNextButton()
                .SearchQuestion(dictionary["question"])
                .SetSetQuestion()
                .ClickSaveButton()
                .Assert();
        }
        [Then(@"Admin deletes Newly added polls")]
        public void ThenAdminDeletesNewlyAddedPolls(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new PollsPage(Driver, Constants.Roles.Admin.ToString())
                .SearchNewlyAddedPollByName(dictionary["Name"])
                .ClickThreePoints()
                .ClickDelete()
                .ClickAreYouSureOk()
                .Assert();
        }
        [Given(@"Admin checks poll is exist")]
        public void GivenAdminChecksPollİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenPollsPage(Constants.Roles.Admin.ToString())
                .CheckPollIsExist(dictionary["Name"]);
        }
        [Given(@"Admin checks poll question is exist")]
        public void GivenAdminChecksPollQuestionIsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenPollQuestionsPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedQuestionByNameAndDeleteIt(dictionary["question"]);
        }
        [Given(@"Admin adds multiple choice poll question with")]
        public void GivenAdminAddsMultipleChoicePollQuestionWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenPollQuestionsPage(Constants.Roles.Admin.ToString())
                .ClickAddButton()
                .EnterText(dictionary["question"])
                .SelectType("Multiple Choice")
                .ClickIsPublic()
                .ClickIsEditable()
                .ClickAddNewAnswerButton()
                .EnterAnswer1(dictionary["answer1"])
                .EnterAnswer2(dictionary["answer2"])
                .EnterAnswer3(dictionary["answer3"])
                .EnterAnswer4(dictionary["answer4"])
                .ClickSaveButton()
                .Assert();
        }
        [Given(@"Admin adds open ended poll question with")]
        public void GivenAdminAddsOpenEndedPollQuestionWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenPollQuestionsPage(Constants.Roles.Admin.ToString())
                .ClickAddButton()
                .EnterText(dictionary["question"])
                .SelectType("Open-Ended")
                .ClickIsPublic()
                .ClickIsEditable()
                .ClickSaveButton()
                .Assert();
        }
        [Given(@"Admin adds true false poll question with")]
        public void GivenAdminAddsTrueFalsePollQuestionWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenPollQuestionsPage(Constants.Roles.Admin.ToString())
                .ClickAddButton()
                .EnterText(dictionary["question"])
                .SelectType("True False")
                .ClickIsPublic()
                .ClickIsEditable()
                .ClickSaveButton()
                .Assert();
        }
        [Then(@"Admin delete poll question with")]
        public void ThenAdminDeleteMultipleChoiceQuestionWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
               .OpenPollQuestionsPage(Constants.Roles.Admin.ToString())
               .SearchNewlyAddedQuestionByName(dictionary["question"])
               .Click3Points()
               .ClickDeleteButton()
               .ClickAreUSure()
               .Assert();
        }
        [Then(@"instructor adds test pool multiple choice with document")]
        public void ThenİnstructorAddsTestPoolMultipleChoiceWithDocument(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                    .OpenTestPoolPage(Constants.Roles.Instructor.ToString())
                    .ClickAddButton()
                    .EnterName(dictionary["name"])
                    //.enterDescription(dictionary["description"])
                    .EnterDuration(Int32.Parse(dictionary["Duration"]))
                    .SelectIsPublic()
                    .SelectIsOpticalMarker()
                    .SelectIsDocument()
                    .SelectFile()
                    .EnterQuestionNumber(Int32.Parse(dictionary["questionNumber"]))
                    .EnterPointsofEach(Int32.Parse(dictionary["points"]))
                    .EnterNumberOfChoices(Int32.Parse(dictionary["choicesNumber"]))
                    .EnterFirstAnswer(dictionary["firstAnswer"])
                    .EnterSecondAnswer(dictionary["secondAnswer"])
                    .EnterThirdAnswer(dictionary["thirdAnswer"])
                    .EnterFourthAnswer(dictionary["fourthAnswer"])
                    .EnterFifthAnswer(dictionary["fifthAnswer"])
                    .EnterSixthAnswer(dictionary["sixthAnswer"])
                    .EnterSeventhAnswer(dictionary["seventhAnswer"])
                    .EnterEighthAnswer(dictionary["eighthAnswer"])
                    .SelectTestCategory(dictionary["TestCategory"])
                    .ClickSaveButton()
                    .Assert();
        }
        [Given(@"instructor adds test pool open ended with")]
        public void GivenİnstructorAddsTestPoolOpenEndedWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                    .OpenTestPoolPage(Constants.Roles.Instructor.ToString())
                    .ClickAddButton()
                    .EnterName(dictionary["name"])
                    .SelectIsPublic()
                    .SelectTestCategory(dictionary["TestCategory"])
                    .ClickNextButton()
                    .EnterQuestionName(dictionary["question"])
                    .ClickSetButton()
                    .ClickSaveButton()
                    .Assert();
        }

        [Then(@"Admin deletes newly added test multiple choice adding question with document")]
        public void ThenAdminDeletesNewlyAddedTestMultipleChoiceAddingQuestionWithDocument(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new TestPoolPage(Driver, Constants.Roles.Instructor.ToString())
                .SearchNewlyAddedPollTestByName(dictionary["Name"])
                .ClickThreePoints()
                .ClickDeleteTest()
                .ClickAreUSure()
                .Assert();
        }
        [Given(@"admin checks catalog is exist")]
        public void GivenAdminChecksCatalogİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenCatalogPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedCatalogAndDeleteIt(dictionary["name"]);
        }
        [Then(@"admin adds new catalog")]
        public void ThenAdminAddsNewCatalog(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenCatalogPage(Constants.Roles.Instructor.ToString())
                .ClickAddNew()
                .EnterName(dictionary["name"])
                .EnterTags(dictionary["tags"])
                .EnterDescription(dictionary["description"])
                .ClickIsShowAtHomePage()
                .Submit()
                .Assert();
        }
        
        [Then(@"admin adds new catalog subscription type to existing catalog")]
        public void ThenAdminAddsNewCatalogSubscriptionTypePermanentToExistingCatalog(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenCatalogPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedCatalog(dictionary["name"])
                .Click3Points()
                .ClickUpdateButton()
                .clickCatalogSubscriptionAdd_button()
                .EnterCatalogSubscriptionTitle(dictionary["title"])
                .EnterCatalogSubscriptionDescription(dictionary["description"])
                .SelectCatalogSubscriptionCurrency(dictionary["currency"])
                .EnterCatalogSubscriptionPackageAmount(Int32.Parse(dictionary["amount"]))
                .EnterCatalogSubscriptionPackageSalePrice(Int32.Parse(dictionary["salePrice"]))
                .SelectCatalogSubscriptionType(dictionary["type"])
                .EnterCatalogSubscriptionPackageDurationTime(dictionary["duration_time"])
                .EnterCatalogSubscriptionPackageDurationType(dictionary["duration_type"])
                .ClickCatalogSubscriptionBranch()
                .ClickCatalogSubscriptionStudent()
                .ClickCatalogSubscriptionSaveButton()
                .Assert();
        }
        [Then(@"admin adds new catalog subscription type temporary to existing catalog")]
        public void ThenAdminAddsNewCatalogSubscriptionTypeTemporaryToExistingCatalog(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenCatalogPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedCatalog(dictionary["name"])
                .Click3Points()
                .ClickUpdateButton()
                .clickCatalogSubscriptionAdd_button()
                .EnterCatalogSubscriptionTitle(dictionary["title"])
                .EnterCatalogSubscriptionDescription(dictionary["description"])
                .SelectCatalogSubscriptionCurrency(dictionary["currency"])
                .EnterCatalogSubscriptionPackageAmount(Int32.Parse(dictionary["amount"]))
                .EnterCatalogSubscriptionPackageSalePrice(Int32.Parse(dictionary["salePrice"]))
                .SelectCatalogSubscriptionType(dictionary["type"])
                .SetTemporaryStartDate()
                .SetTemporaryEndDate()
                .ClickCatalogSubscriptionBranch()
                .ClickCatalogSubscriptionStudent()
                .ClickCatalogSubscriptionSaveButton()
                .Assert();
        }
        [Given(@"admin deletes added catalog")]
        public void GivenAdminDeletesAddedCatalog(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenCatalogPage(Constants.Roles.Instructor.ToString())
                .SearchNewlyAddedCatalog(dictionary["name"])
                .Click3Points()
                .ClickDeleteUserButton()
                .ClickAreUSure()
                .Assert();
        }
        [Given(@"instructor checks exam is exist")]
        public void GivenİnstructorChecksExamİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenExamPage(Constants.Roles.Instructor.ToString())
                .SearchNewlyAddedExamAndDelete(dictionary["name"]);
        }
        [Then(@"instructor adds exam with document")]
        public void ThenİnstructorAddsExamWithDocument(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenExamPage(Constants.Roles.Instructor.ToString())
                .ClickAddNew()
                .EnterName(dictionary["name"])
                .EnterDescription(dictionary["description"])
                .SelectCatalogs(dictionary["catalogs"])
                .ClickNextButton()
                .SetTests(dictionary["tests"])
                .ClickSaveButton();
        }
        [Given(@"instructor delete exam with")]
        public void GivenİnstructorDeleteExamWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenExamPage(Constants.Roles.Instructor.ToString())
                .SearchNewlyAddedExam(dictionary["name"])
                .Click3Points()
                .ClickDeleteExamButton()
                .ClickAreUSure()
                .Assert();
        }
        [Then(@"instructor adds exam with multiple choice")]
        public void ThenİnstructorAddsExamWithMultipleChoice(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenExamPage(Constants.Roles.Instructor.ToString())
                .ClickAddNew()
                .EnterName(dictionary["name"])
                .EnterDescription(dictionary["description"])
                .EnterRepeatNumber(Int32.Parse(dictionary["repeatNumber"]))
                .SelectCatalogs(dictionary["catalogs"])
                .ClickNextButton()
                .SetTests(dictionary["tests"])
                .ClickSaveButton();
        }
        [Then(@"instructor adds exam with open ended")]
        public void ThenİnstructorAddsExamWithOpenEnded(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenExamPage(Constants.Roles.Instructor.ToString())
                .ClickAddNew()
                .EnterName(dictionary["name"])
                .EnterDescription(dictionary["description"])
                .EnterRepeatNumber(Int32.Parse(dictionary["repeatNumber"]))
                .SelectCatalogs(dictionary["catalogs"])
                .ClickNextButton()
                .SetTests(dictionary["tests"])
                .ClickSaveButton();
        }
        [Given(@"admin checks admin is exist")]
        public void GivenAdminChecksAdminİsExist(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenAdminsPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedAdminByNameAndDeleteIt(dictionary["name"]);

        }
        [Then(@"admin adds admin")]
        public void ThenAdminAddsAdmin(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                 .OpenAdminsPage(Constants.Roles.Admin.ToString())
                 .ClickAddButton()
                 .EnterFirstName(dictionary["first_name"])
                 .EnterLastName(dictionary["last_name"])
                 .EnterEmail(dictionary["email"])
                 .EnterUserName(dictionary["username"])
                 .EnterPassword(dictionary["password"])
                 .ClickGenerate()
                 .SelectGpdr()
                 .ClickSaveButton()
                 .Assert();
        }
        [Then(@"admin delete admin")]
        public void ThenAdminDeleteAdmin(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new AdminsPage(Driver, Constants.Roles.Admin.ToString())
                .SearchNewlyAddedAdminByName(dictionary["name"])
                .Click3Points()
                .ClickDeleteButton()
                .ClickAreUSure()
                .Assert();
        }

        [Given(@"admin checks manager is exist")]
        public void GivenAdminChecksManagerİsExist(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenManagersPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedManagerByNameAndDeleteIt(dictionary["name"]);

        }
        [Then(@"admin adds manager")]
        public void ThenAdminAddsManager(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                 .OpenManagersPage(Constants.Roles.Admin.ToString())
                 .ClickAddButton()
                 .EnterFirstName(dictionary["first_name"])
                 .EnterLastName(dictionary["last_name"])
                 .SelectBranchName(dictionary["branchName"])
                 .EnterEmail(dictionary["email"])
                 .EnterUserName(dictionary["username"])
                 .EnterPassword(dictionary["password"])
                 .ClickGenerate()
                 .SelectGpdr()
                 .ClickSaveButton()
                 .Assert();
        }
        [Then(@"admin delete manager")]
        public void ThenAdminDeleteManager(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new ManagersPage(Driver, Constants.Roles.Admin.ToString())
                .SearchNewlyAddedManagerByName(dictionary["name"])
                .Click3Points()
                .ClickDeleteButton()
                .ClickAreUSure()
                .Assert();
        }

        [Given(@"student adds new Q&A")]
        public void GivenStudentAddsNewQa(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenQuestionsAndAnswersPage(Constants.Roles.Student.ToString())
                .ClickNewTicket()
                .SelectCourse(dictionary["courseName"])
                .EnterSubject(dictionary["subject"])
                .EnterMessage(dictionary["message"])
                .ClickNextButton()
                //.selectFile()
                .ClickSendButton()
                .Assert();
        }
        [Given(@"instructor checks Q&A is exist")]
        public void GivenİnstructorChecksQuestionsAndAnswerİsExist(){
            new HomePage(Driver)
                .OpenQuestionsAndAnswersPage(Constants.Roles.Instructor.ToString())
                .CheckQuestionIsExist();
        }
        [Then(@"instructor answers the question")]
        public void GivenInstructorAnswersTheQuestion(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenQuestionsAndAnswersPage(Constants.Roles.Instructor.ToString())
                .OpenViewDetail()
                .EnterAnswer(dictionary["answer"])
                // .selectFile()
                .ClickReplyButton();
        }
        [Then(@"instructor deletes new Q&A")]
        public void GivenİnstructorDeletesNewAddedQuestion(){
            new HomePage(Driver)
                .OpenQuestionsAndAnswersPage(Constants.Roles.Instructor.ToString())
                .DeleteNewAddedQuestions();
        }

        [Given(@"instructor checks poll question is exist")]
        public void GivenInstructorChecksPollQuestionIsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenPollQuestionsPage(Constants.Roles.Instructor.ToString())
                .SearchNewlyAddedQuestionByNameAndDeleteIt(dictionary["question"]);
        }
        [Given(@"instructor adds multiple poll question with")]
        public void GivenİnstructorAddsMultiplePollQuestionWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenPollQuestionsPage(Constants.Roles.Instructor.ToString())
                .ClickAddButton()
                .EnterText(dictionary["question"])
                .SelectType("Multiple Choice")
                .ClickAddNewAnswerButton()
                .EnterAnswer1(dictionary["answer1"])
                .EnterAnswer2(dictionary["answer2"])
                .EnterAnswer3(dictionary["answer3"])
                .EnterAnswer4(dictionary["answer4"])
                .ClickIsPublic()
                .ClickIsEditable()
                .ClickSaveButton()
                .Assert();
        }
        [Given(@"instructor adds open ended poll question with")]
        public void GivenİnstructorAddsOpenEndedPollQuestionWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenPollQuestionsPage(Constants.Roles.Instructor.ToString())
                .ClickAddButton()
                .EnterText(dictionary["question"])
                .SelectType("Open-Ended")
                .ClickIsPublic()
                .ClickIsEditable()
                .ClickSaveButton()
                .Assert();
        }
        [Given(@"instructor adds true false poll question with")]
        public void GivenİnstructorAddsTrueFalsePollQuestionWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenPollQuestionsPage(Constants.Roles.Instructor.ToString())
                .ClickAddButton()
                .EnterText(dictionary["question"])
                .SelectType("True False")
                .ClickIsPublic()
                .ClickIsEditable()
                .ClickSaveButton()
                .Assert();
        }
        [Then(@"instructor delete poll question with")]
        public void ThenInstructorDeleteMultipleChoiceQuestionWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
               .OpenPollQuestionsPage(Constants.Roles.Instructor.ToString())
               .SearchNewlyAddedQuestionByName(dictionary["question"])
               .Click3Points()
               .ClickDeleteButton()
               .ClickAreUSure()
               .Assert();
        }
        [Given(@"admin adds new resource as document")]
        public void GivenAdminAddsNewResourceAsDocument(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenCoursesPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedCourseByName(dictionary["name"])
                .Click3Points()
                .ClickResources()
                .AddSubject()
                .EnterSubjectTitle(dictionary["subject_title"])
                .SaveSubjectTitle()
                .AddResource()
                .ClickResourceTypeDoc()
                .EnterResourceTitle(dictionary["resource_title"])
                .EnterResourceDescription(dictionary["resource_description"])
                .SelectFile()
                .SelectDownloadable()
                .SelectUserReviewEnableForDoc()
                .ClickSaveButton()
                .Assert();
        }
        [Given(@"admin adds new resource as video")]
        public void GivenAdminAddsNewResourceAsVideo(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenCoursesPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedCourseByName(dictionary["name"])
                .Click3Points()
                .ClickResources()
                .AddSubject()
                .EnterSubjectTitle(dictionary["subject_title"])
                .SaveSubjectTitle()
                .AddResource()
                .ClickResourceTypeVideo()
                .ClickVimeo()
                .EnterResourceTitle(dictionary["resource_title"])
                .EnterResourceDescription(dictionary["resource_description"])
                .SelectVideo1()
                .ClickUpload()
                .SelectCourseVideoPrev()
                .SelectCourseVideoDownloadable()
                .SelectCourseVideoSpeedControl()
                .SelectUserReviewEnableForVideo()
                .WaitUntilFileIsUploaded()
                .ClickCourseVideoSubmit()
                .Assert();
        }
        [Given(@"admin adds new resource as video with vimeo id")]
        public void GivenAdminAddsNewResourceAsVideoWithVimeoİd(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenCoursesPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedCourseByName(dictionary["name"])
                .Click3Points()
                .ClickResources()
                .AddSubject()
                .EnterSubjectTitle(dictionary["subject_title"])
                .SaveSubjectTitle()
                .AddResource()
                .ClickResourceTypeVideo()
                .ClickVimeo()
                .EnterResourceTitle(dictionary["resource_title"])
                .EnterResourceDescription(dictionary["resource_description"])
                .SelectVimeoId()
                .EnterVimeoId(dictionary["vimeo_id"])
                .SelectCourseVideoPrev()
                .SelectCourseVideoDownloadable()
                .SelectCourseVideoSpeedControl()
                .SelectUserReviewEnableForVideo()
                .ClickCourseExistingVideoSubmit()
                .Assert();
        }
        [Given(@"admin adds new resource as link")]
        public void GivenAdminAddsNewResourceAsLink(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenCoursesPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedCourseByName(dictionary["name"])
                .Click3Points()
                .ClickResources()
                .AddSubject()
                .EnterSubjectTitle(dictionary["subject_title"])
                .SaveSubjectTitle()
                .AddResource()
                .ClickResourceTypeLink()
                .EnterResourceTitle(dictionary["resource_title"])
                .SetDescription(dictionary["resource_description"])
                .EnterLink(dictionary["link"])
                .SelectVideoUserReview()
                .ClickResourceLinkSave()
                .Assert();
        }
        [Given(@"admin adds new resource as embed")]
        public void GivenAdminAddsNewResourceAsEmbed(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenCoursesPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedCourseByName(dictionary["name"])
                .Click3Points()
                .ClickResources()
                .AddSubject()
                .EnterSubjectTitle(dictionary["subject_title"])
                .SaveSubjectTitle()
                .AddResource()
                .ClickResourceTypeEmbedCode()
                .EnterResourceTitle(dictionary["resource_title"])
                .SetEmbeddedDescription(dictionary["resource_description"])
                .EnterEmbedCode(dictionary["embed_code"])
                .SelectVideoUserReview()
                .ClickResourceLinkSave()
                .Assert();
        }
        
        [Given(@"admin adds new resource as test")]
        public void GivenAdminAddsNewResourceAsTest(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenCoursesPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedCourseByName(dictionary["name"])
                .Click3Points()
                .ClickResources()
                .AddSubject()
                .EnterSubjectTitle(dictionary["subject_title"])
                .SaveSubjectTitle()
                .AddResource()
                .ClickResourceTypeTest()
                .EnterResourceTitle(dictionary["resource_title"])
                .SetTestDescription(dictionary["resource_description"])
                .SetPassPoint(Int32.Parse(dictionary["point"]))
                .SetRepeatNumber(Int32.Parse(dictionary["repeat"]))
                .SetRedirectToResultPageAfterTest()
                .SelectVideoUserReview()
                .SetIsBetweenDates()
                .SetIsExamResultDownload()
                .SetAreStudentAnswersShownInExamResult()
                .SetFirstTestToList()
                .ClickResourceLinkSave()
                .Assert();
        }
        [Given(@"admin adds new resource as text")]
        public void GivenAdminAddsNewResourceAsText(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenCoursesPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedCourseByName(dictionary["name"])
                .Click3Points()
                .ClickResources()
                .AddSubject()
                .EnterSubjectTitle(dictionary["subject_title"])
                .SaveSubjectTitle()
                .AddResource()
                .ClickResourceTypeText()
                .EnterResourceTitle(dictionary["resource_title"])
                .SetDescriptionForText(dictionary["resource_description"])
                .SelectVideoUserReview()
                .ClickResourceLinkSave()
                .Assert();
        }
        [Given(@"admin checks discount code is exist")]
        public void GivenAdminChecksDiscountCodeİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenDiscountCodesPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedDiscountCodeByNameAndDeleteIt(dictionary["name"]);
        }
        [Given(@"admin adds new discount code with")]
        public void GivenAdminAddsNewDiscountCodeWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenDiscountCodesPage(Constants.Roles.Admin.ToString())
                .ClickAddNew()
                .EnterCode(dictionary["code"])
                .EnterDescription(dictionary["description"])
                .EnterPercentage(dictionary["percentage"])
                .SelectIsLimited(Boolean.Parse(dictionary["limit"]))
                .EnterLimit(dictionary.ContainsKey("usage_limit") ? dictionary["usage_limit"] : null)
                .SetStartDate()
                .SetEndDate(Utils.Dates.GetNextYear(NEXT_YEAR), Utils.Dates.GetNextMonth(Months.April), Utils.Dates.GetNextDay(15))
                .ClickSave()
                .Assert();
        }
        [Given(@"admin adds new discount code with not limited")]
        public void GivenAdminAddsNewDiscountCodeWithNotLimited(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenDiscountCodesPage(Constants.Roles.Admin.ToString())
                .ClickAddNew()
                .EnterCode(dictionary["code"])
                .EnterDescription(dictionary["description"])
                .EnterPercentage(dictionary["percentage"])
                .SelectIsLimited(Boolean.Parse(dictionary["limit"]))
                .EnterLimit(dictionary.ContainsKey("usage_limit") ? dictionary["usage_limit"] : null)
                .SetNotLimitedStartDate()
                .SetNotLimitedEndDate(Utils.Dates.GetNextYear(NEXT_YEAR), Utils.Dates.GetNextMonth(Months.April), Utils.Dates.GetNextDay(15))
                .ClickSave()
                .Assert();
        }
        [Then(@"admin deletes added discount code")]
        public void ThenAdminDeletesAddedDiscountCode(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenDiscountCodesPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedDiscountCodeByName(dictionary["name"])
                .Click3Points()
                .ClickDeleteCodeButton()
                .ClickAreUSure()
                .Assert();
        }
        [Given(@"admin adds new batch user with")]
        public void AdminAddsNewBatchUserWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenStudentsPage(Constants.Roles.Admin.ToString())
                .ClickBatchButton()
                .ClickBatchCreateButton()
                .EnterExcelFile()
                .SelectBranchBatchCreate(dictionary["branch"])
                .SetCatalogBatchCreate(dictionary["catalog"])
                .ClickAddCatalogButtonBatchCreate()
                .SetGpdrPolicyBatchCreate()
                .ClickUploadButtonBatchCreate()
                .ClickAcceptButtonBatchCreate()
                .Assert();
        }
        [Given(@"admin checks custom field is exist")]
        public void GivenAdminChecksCustomFieldİsExist(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenCustomFieldPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedCustomFieldByNameAndDeleteIt(dictionary["name"]);
        }
        [Then(@"admin adds custom field text")]
        public void ThenAddCustomFieldText(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenCustomFieldPage(Constants.Roles.Admin.ToString())
                .ClickAddButton()
                .SelectFieldType(dictionary["type"])
                .SelectLanguage(dictionary["language"])
                .EnterName(dictionary["name"])
                .EnterDescription(dictionary["description"])
                .EnterOrderNumber(Int32.Parse(dictionary["orderNumber"]))
                .SelectIsRequired()
                .ClickSaveButton()
                .Assert();
        }
        [Then(@"admin adds custom field dropdown")]
        public void ThenAddCustomFieldDropDown(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenCustomFieldPage(Constants.Roles.Admin.ToString())
                .ClickAddButton()
                .SelectFieldType(dictionary["type"])
                .SelectLanguage(dictionary["language"])
                .EnterName(dictionary["name"])
                .EnterDescription(dictionary["description"])
                .EnterOrderNumber(Int32.Parse(dictionary["orderNumber"]))
                .SelectIsRequired()
                .EnterOptions(dictionary["options"])
                .ClickSaveButton()
                .Assert();
        }
        [Then(@"admin adds custom field checkbox")]
        public void ThenAddCustomFieldCheckbox(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenCustomFieldPage(Constants.Roles.Admin.ToString())
                .ClickAddButton()
                .SelectFieldType(dictionary["type"])
                .SelectLanguage(dictionary["language"])
                .EnterName(dictionary["name"])
                .EnterDescription(dictionary["description"])
                .EnterOrderNumber(Int32.Parse(dictionary["orderNumber"]))
                .ClickSaveButton()
                .Assert();
        }
        [Then(@"admin deletes added custom field")]
        public void GivenAdminDeletesAddedCustomField(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenCustomFieldPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedCustomFieldByName(dictionary["name"])
                .ClickThreePoints()
                .ClickDelete()
                .ClickAreUSure()
                .Assert();
        }
        [Given(@"admin checks catalog is exist in library")]
        public void GivenAdminChecksCatalogİsExistInLibrary(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenLibraryPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedCatalogAndDeleteIt(dictionary["name"]);
        }
        [Then(@"admin adds new catalog in library")]
        public void ThenAdminAddsNewCatalogToLibrary(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenLibraryPage(Constants.Roles.Admin.ToString())
                .ClickAddCategory()
                .EnterCatalogName(dictionary["name"])
                .DeselectIsEditable()
                .ClickAdd()
                .Assert();
        }
        [Then(@"admin adds new content document catalog in library")]
        public void ThenAdminAddsNewContentDocumentCatalogToLibrary(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenLibraryPage(Constants.Roles.Admin.ToString())
                 .ClickCatalog()
                 .ClickAddItem()
                 .ClickDocument()
                 .ClickContentOk()
                 .EnterTitle(dictionary["title"])
                 .EnterDescription(dictionary["description"])
                 .SelectFile()
                 .SelectIsDownloadable()
                 .ClickSaveButton()
                 .Assert();
        }
        [Then(@"admin adds new content link catalog in library")]
        public void ThenAdminAddsNewContentLinkCatalogToLibrary(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenLibraryPage(Constants.Roles.Admin.ToString())
                 .ClickCatalog()
                 .ClickAddItem()
                 .ClickLink()
                 .ClickContentOk()
                 .EnterTitle(dictionary["title"])
                 .EnterDescription(dictionary["description"])
                 .EnterUrl(dictionary["url"])
                 .ClickSaveButton()
                 .Assert();
        }
        [Then(@"admin adds new content embed code catalog in library")]
        public void ThenAdminAddsNewContentEmbedCodeCatalogToLibrary(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenLibraryPage(Constants.Roles.Admin.ToString())
                 .ClickCatalog()
                 .ClickAddItem()
                 .ClickEmbedCode()
                 .ClickContentOk()
                 .EnterTitle(dictionary["title"])
                 .EnterDescription(dictionary["description"])
                 .EnterCode(dictionary["code"])
                 .ClickSaveButton()
                 .Assert();
        }

        [Then(@"admin adds new content sound catalog in library")]
        public void ThenAdminAddsNewContentSoundCatalogToLibrary(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenLibraryPage(Constants.Roles.Admin.ToString())
                 .ClickCatalog()
                 .ClickAddItem()
                 .ClickSound()
                 .ClickContentOk()
                 .EnterTitle(dictionary["title"])
                 .EnterDescription(dictionary["description"])
                 .SelectSound()
                 .SelectIsDownloadable()
                 .ClickAudioSaveButton()
                 .Assert();
        }
        [Given(@"admin deletes added catalog in library")]
        public void GivenAdminDeletesAddedCatalogInLibrary(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenLibraryPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedCatalog(dictionary["name"])
                .ClickCatalog()
                .DeleteCatalog()
                .ClickAreUSure()
                .Assert();
        }
        [Given(@"admin checks test category is exist")]
        public void GivenAdminChecksTestCategoryIsExist(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenTestCategoriesPage(Constants.Roles.Admin.ToString())
                .SearchTestCategoryAndDeleteIt(dictionary["name"]);
        }
        [Then(@"admin adds new test category")]
        public void GivenAdminAddsTestCategory(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenTestCategoriesPage(Constants.Roles.Admin.ToString())
                .ClickAddButton()
                .EnterName(dictionary["name"])
                .SubmitAdd()
                .Assert();
        }
        [Then(@"admin update test category")]
        public void GivenAdminUpdateTestCategory(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenTestCategoriesPage(Constants.Roles.Admin.ToString())
                .ClickName(dictionary["name"])
                .EnterName(dictionary["name"])
                .SubmitAdd()
                .Assert();
            
        }
        [Given(@"admin deletes added test category")]
        public void GivenAdminDeleteTestCategory(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenTestCategoriesPage(Constants.Roles.Admin.ToString())
                .ClickName(dictionary["name"])
                .ClickDeleteButton()
                .ClickAreUSure()
                .Assert();
        }
        [Given(@"admin checks images category is exist")]
        public void GivenAdminChecksImageCategoryIsExist(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenImagePoolPage(Constants.Roles.Admin.ToString())
                .SearchImageCategoryAndDeleteIt(dictionary["name"]);
        }
        [Then(@"admin adds new images category")]
        public void GivenAdminAddsImageCategory(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenImagePoolPage(Constants.Roles.Admin.ToString())
                .ClickAddButton()
                .EnterName(dictionary["name"])
                .SubmitAdd()
                .Assert();
        }
        [Then(@"admin update images category")]
        public void GivenAdminUpdateImageCategory(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenImagePoolPage(Constants.Roles.Admin.ToString())
                .ClickName(dictionary["name"])
                .EnterName(dictionary["name"])
                .EnterImage()
                .EnterImageText(dictionary["name"])
                .SubmitUpdate()
                .Assert();
        }
        [Given(@"admin deletes added images category")]
        public void GivenAdminDeleteImageCategory(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenImagePoolPage(Constants.Roles.Admin.ToString())
                .ClickName(dictionary["name"])
                .ClickDeleteButton()
                .ClickAreUSure()
                .Assert();
            // TODO: Images are not changing when category is selected. Test is failing for that reason
        }
        [Given(@"admin checks blog category is exist")]
        public void GivenAdminChecksBlogCategoryIsExist(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenBlogPage(Constants.Roles.Admin.ToString())
                .SearchBlogCategoryAndDeleteIt(dictionary["name"]);
        }
        [Then(@"admin adds new blog category")]
        public void GivenAdminAddsBlogCategory(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenBlogPage(Constants.Roles.Admin.ToString())
                .EnterName(dictionary["name"])
                .SubmitAdd()
                .Assert();
        }
        [Then(@"admin update blog category")]
        public void GivenAdminUpdateBlogCategory(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenBlogPage(Constants.Roles.Admin.ToString())
                .Click3Points(dictionary["name"])
                .ClickUpdateButtonIn3PointsBy(dictionary["name"])
                .EnterName(dictionary["name"])
                .SubmitUpdate()
                .Assert();
        }
        [Given(@"admin deletes added blog category")]
        public void GivenAdminDeleteBlogCategory(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenBlogPage(Constants.Roles.Admin.ToString())
                .Click3Points(dictionary["name"])
                .ClickDeleteIn3PointsBy(dictionary["name"])
                .ClickAreUSure()
                .Assert();
        }
        [Given(@"admin checks activation codes is exist")]
        public void GivenAdminChecksActivationCodesİsExist(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenActivationCodesPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedActivationCodesByNameAndDeleteIt(dictionary["code"]);
        }
        [Then(@"admin adds activation codes")]
        public void ThenAddActivationCodes(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenActivationCodesPage(Constants.Roles.Admin.ToString())
                .ClickAddButton()
                .EnterCode(dictionary["code"])
                .EnterDesc(dictionary["code"])
                .EnterLimit(Int32.Parse(dictionary["limit"]))
                .SetStartDate(
                    yearParam:Utils.Dates.GetCurrentYear()+1,
                    monthParam:null,
                    dayParam:null
                )
                .SetEndDate(
                    yearParam:Utils.Dates.GetCurrentYear()+1,
                    monthParam:null,
                    dayParam:null
                )
                .ClickSaveButton()
                .Assert();
        }
        [Then(@"admin deletes added activation codes")]
        public void ThenAdminDeletesAddedActivationCodes(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenActivationCodesPage(Constants.Roles.Admin.ToString())
                .SearchNewlyAddedActivationCodesByName(dictionary["code"])
                .ClickThreePoints()
                .ClickDelete()
                .ClickAreUSure()
                .Assert();
        }
        [Given(@"admin checks help exists")]
        public void GivenAdminChecksHelpIsExist(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenHelpPage(Constants.Roles.Admin.ToString())
                .SearchCategoryAndDeleteIt(dictionary["name"]);
        }
        [Then(@"admin adds new help")]
        public void GivenAdminAddsNewHelp(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenHelpPage(Constants.Roles.Admin.ToString())
                .ClickAddButton()
                .EnterName(dictionary["name"])
                .SubmitAdd()
                .Assert();
        }
        [Then(@"admin update document in help")]
        public void GivenAdminUpdateDocumentInHelp(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenHelpPage(Constants.Roles.Admin.ToString())
                .ClickName(dictionary["name"])
                .EnterName(dictionary["name"])
                .ClickAddItemButton()
                .SelectCategoryItem("document")
                .ClickStep2Button()
                .EnterDocumentTitle(dictionary["name"])
                .EnterDocumentDesc(dictionary["name"])
                .SelectFile()
                .ClickSaveButtonInDocumentItem()
                .Assert();
        }
        [Given(@"admin deletes added help")]
        public void GivenAdminDeleteAddedHelp(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenHelpPage(Constants.Roles.Admin.ToString())
                .ClickName(dictionary["name"])
                .ClickDeleteButton()
                .ClickAreUSure()
                .Assert();
        }
        [Then(@"admin update video in help")]
        public void GivenAdminUpdateVideoInHelp(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenHelpPage(Constants.Roles.Admin.ToString())
                .ClickName(dictionary["name"])
                .EnterName(dictionary["name"])
                .ClickAddItemButton()
                .SelectCategoryItem("video")
                .ClickStep2Button()
                .EnterDocumentTitle(dictionary["name"])
                .EnterDocumentDesc(dictionary["name"])
                .SelectVideo()
                .ClickSaveButtonInFileItem()
                .Assert();
            // TODO: After video is uploaded, assert popup not showed
        }
        [Then(@"admin update link in help")]
        public void GivenAdminUpdateLinkInHelp(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenHelpPage(Constants.Roles.Admin.ToString())
                .ClickName(dictionary["name"])
                .EnterName(dictionary["name"])
                .ClickAddItemButton()
                .SelectCategoryItem("link")
                .ClickStep2Button()
                .EnterDocumentTitle(dictionary["name"])
                .EnterDocumentDesc(dictionary["name"])
                .EnterLink(dictionary["name"])
                .ClickSaveButtonInDocumentItem()
                .Assert();
        }
        [Then(@"admin update embed in help")]
        public void GivenAdminUpdateEmbedInHelp(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .OpenHelpPage(Constants.Roles.Admin.ToString())
                .ClickName(dictionary["name"])
                .EnterName(dictionary["name"])
                .ClickAddItemButton()
                .SelectCategoryItem("embed_code")
                .ClickStep2Button()
                .EnterDocumentTitle(dictionary["name"])
                .EnterDocumentDesc(dictionary["name"])
                .EnterEmbedCode(dictionary["name"])
                .ClickSaveButtonInDocumentItem()
                .Assert();
        }
        [Then(@"instructor wait")]
        public void GivenInstructorWait(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            Page.Sleepms(Int32.Parse(dictionary["time"]));
            Console.WriteLine("waited for " + Int32.Parse(dictionary["time"]) + " seconds");
        }
        [Then(@"instructor add document in files")]
        public void GivenInstructorAddDocumentInFile(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new CoursesPage(Driver, Constants.Roles.Instructor.ToString())
                .ClickCourses(dictionary["coursename"])
                .ClickFiles()
                .ClickAddCategory()
                .EnterCategoryName(dictionary["categoryName"])
                .ClickAddCategoryConfirm()
                .Assert()
                .ChooseCategory(dictionary["addedCategoryName"])
                .ClickAddItemToCategoryButton()
                .ChooseItemDocumentToCategory()
                .ClickCategoryFileTypeOk()
                .EnterCategoryTitle(dictionary["categoryTitle"])
                .EnterCategoryDescription(dictionary["categoryDescription"])
                .SelectFileDocument()
                .ClickCategoryDocumentSave()
                .Assert();
        }
        [Then(@"instructor add video in files")]
        public void GivenInstructorAddVideoInFile(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new CoursesPage(Driver, Constants.Roles.Instructor.ToString())
                .ClickCourses(dictionary["coursename"])
                .ClickFiles()
                .ClickAddCategory()
                .EnterCategoryName(dictionary["categoryName"])
                .ClickAddCategoryConfirm()
                .Assert()
                .ChooseCategory(dictionary["addedCategoryName"])
                .ClickAddItemToCategoryButton()
                .ChooseItemVideoToCategory()
                .ClickCategoryFileTypeOk()
                .EnterCategoryTitle(dictionary["categoryTitle"])
                .EnterCategoryDescription(dictionary["categoryDescription"])
                .SelectFileVideo()
                .ClickCategoryDocumentSave();
            }
        [Then(@"instructor add link in files")]
        public void GivenInstructorAddLinkInFile(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new CoursesPage(Driver, Constants.Roles.Instructor.ToString())
                .ClickCourses(dictionary["coursename"])
                .ClickFiles()
                .ClickAddCategory()
                .EnterCategoryName(dictionary["categoryName"])
                .ClickAddCategoryConfirm()
                .Assert()
                .ChooseCategory(dictionary["addedCategoryName"])
                .ClickAddItemToCategoryButton()
                .ChooseItemLinkToCategory()
                .ClickCategoryFileTypeOk()
                .EnterCategoryTitle(dictionary["categoryTitle"])
                .EnterCategoryDescription(dictionary["categoryDescription"])
                .EnterCategoryLink(dictionary["link"])
                .ClickCategoryDocumentSave()
                .Assert();
                }
        [Then(@"instructor add embed in files")]
        public void GivenInstructorAddEmbedInFile(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new CoursesPage(Driver, Constants.Roles.Instructor.ToString())
                .ClickCourses(dictionary["coursename"])
                .ClickFiles()
                .ClickAddCategory()
                .EnterCategoryName(dictionary["categoryName"])
                .ClickAddCategoryConfirm()
                .Assert()
                .ChooseCategory(dictionary["addedCategoryName"])
                .ClickAddItemToCategoryButton()
                .ChooseItemCodeToCategory()
                .ClickCategoryFileTypeOk()
                .EnterCategoryTitle(dictionary["categoryTitle"])
                .EnterCategoryDescription(dictionary["categoryDescription"])
                .EnterCategoryEmbed(dictionary["embed_code"])
                .ClickCategoryDocumentSave()
                .Assert();


        }
        [Then(@"instructor add document in homework")]
        public void GivenInstructorAddDocumentInHomework(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new CoursesPage(Driver, Constants.Roles.Instructor.ToString())
                .ClickCourses(dictionary["coursename"])
                .ClickCategoryUpdate()
                .ClickHomework()
                .ClickAddHomework()
                .EnterHomeworkTitle(dictionary["homework_title"])
                .EnterHomeworkDescription(dictionary["homework_description"])
                .SetHomeworkStartDate()
                .SetHomeworkEndDate()
                .EnterHomeworkPassPoint(Int32.Parse(dictionary["pass_point"]))
                .EnterHomeworkWeightPercentage(Int32.Parse(dictionary["weight_percentage"]))
                .ClickHomeworkSave()
                .Assert()
                .ClickHomeworkAddItem()
                .ChooseItemDocumentToCategory()
                .SelectDocumentType()
                .EnterHomeworkDocTitle(dictionary["homework_doc_title"])
                .EnterHomeworkDocDescription(dictionary["homework_doc_description"])
                .SelectHomeworkFileDocument()
                .ClickHomeworkSave()
                .Assert();
        }
        [Then(@"instructor add video in homework")]
        public void GivenInstructorAddVideoInHomework(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new CoursesPage(Driver, Constants.Roles.Instructor.ToString())
                .ClickCourses(dictionary["coursename"])
                .ClickCategoryUpdate()
                .ClickHomework()
                .ClickAddHomework()
                .EnterHomeworkTitle(dictionary["homework_title"])
                .EnterHomeworkDescription(dictionary["homework_description"])
                .SetHomeworkStartDate()
                .SetHomeworkEndDate()
                .EnterHomeworkPassPoint(Int32.Parse(dictionary["pass_point"]))
                .EnterHomeworkWeightPercentage(Int32.Parse(dictionary["weight_percentage"]))
                .ClickHomeworkSave()
                .Assert()
                .ClickHomeworkAddItem()
                .ChooseItemVideoToCategory()
                .SelectDocumentType()
                .EnterHomeworkDocTitle(dictionary["homework_doc_title"])
                .EnterHomeworkDocDescription(dictionary["homework_doc_description"])
                .SelectHomeworkFileVideo()
                .ClickHomeworkSave();
        }
        [Then(@"instructor add link in homework")]
        public void GivenInstructorAddLinkInHomework(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new CoursesPage(Driver, Constants.Roles.Instructor.ToString())
                .ClickCourses(dictionary["coursename"])
                .ClickCategoryUpdate()
                .ClickHomework()
                .ClickAddHomework()
                .EnterHomeworkTitle(dictionary["homework_title"])
                .EnterHomeworkDescription(dictionary["homework_description"])
                .SetHomeworkStartDate()
                .SetHomeworkEndDate()
                .EnterHomeworkPassPoint(Int32.Parse(dictionary["pass_point"]))
                .EnterHomeworkWeightPercentage(Int32.Parse(dictionary["weight_percentage"]))
                .ClickHomeworkSave()
                .Assert()
                .ClickHomeworkAddItem()
                .ChooseItemLinkToCategory()
                .SelectDocumentType()
                .EnterHomeworkDocTitle(dictionary["homework_doc_title"])
                .EnterHomeworkDocDescription(dictionary["homework_doc_description"])
                .EnterHomeworkLink(dictionary["link"])
                .ClickHomeworkSave()
                .Assert();
        }
        [Then(@"instructor add embed in homework")]
        public void GivenInstructorEmbedInHomework(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new CoursesPage(Driver, Constants.Roles.Instructor.ToString())
                .ClickCourses(dictionary["coursename"])
                .ClickCategoryUpdate()
                .ClickHomework()
                .ClickAddHomework()
                .EnterHomeworkTitle(dictionary["homework_title"])
                .EnterHomeworkDescription(dictionary["homework_description"])
                .SetHomeworkStartDate()
                .SetHomeworkEndDate()
                .EnterHomeworkPassPoint(Int32.Parse(dictionary["pass_point"]))
                .EnterHomeworkWeightPercentage(Int32.Parse(dictionary["weight_percentage"]))
                .ClickHomeworkSave()
                .Assert()
                .ClickHomeworkAddItem()
                .ChooseItemCodeToCategory()
                .SelectDocumentType()
                .EnterHomeworkDocTitle(dictionary["homework_doc_title"])
                .EnterHomeworkDocDescription(dictionary["homework_doc_description"])
                .EnterHomeworkEmbed(dictionary["embed_code"])
                .ClickHomeworkSave()
                .Assert();
        }
        [Then(@"instructor add text in homework")]
        public void GivenInstructorAddTextInHomework(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new CoursesPage(Driver, Constants.Roles.Instructor.ToString())
                .ClickCourses(dictionary["coursename"])
                .ClickCategoryUpdate()
                .ClickHomework()
                .ClickAddHomework()
                .EnterHomeworkTitle(dictionary["homework_title"])
                .EnterHomeworkDescription(dictionary["homework_description"])
                .SetHomeworkStartDate()
                .SetHomeworkEndDate()
                .EnterHomeworkPassPoint(Int32.Parse(dictionary["pass_point"]))
                .EnterHomeworkWeightPercentage(Int32.Parse(dictionary["weight_percentage"]))
                .ClickHomeworkSave()
                .Assert()
                .ClickHomeworkAddItem()
                .ChooseItemTextToCategory()
                .SelectDocumentType()
                .EnterHomeworkDocTitle(dictionary["homework_doc_title"])
                .EnterHomeworkDocDescription(dictionary["homework_doc_description"])
                .ClickHomeworkSave()
                .Assert();
        }
        [Then(@"instructor add test in homework")]
        public void GivenInstructorAddTestInHomework(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new CoursesPage(Driver, Constants.Roles.Instructor.ToString())
                .ClickCourses(dictionary["coursename"])
                .ClickCategoryUpdate()
                .ClickHomework()
                .ClickAddHomework()
                .EnterHomeworkTitle(dictionary["homework_title"])
                .EnterHomeworkDescription(dictionary["homework_description"])
                .SetHomeworkStartDate()
                .SetHomeworkEndDate()
                .EnterHomeworkPassPoint(Int32.Parse(dictionary["pass_point"]))
                .EnterHomeworkWeightPercentage(Int32.Parse(dictionary["weight_percentage"]))
                .ClickHomeworkSave()
                .Assert()
                .ClickHomeworkAddItem()
                .ChooseItemTestToCategory()
                .SelectDocumentType()
                .EnterHomeworkTestTitle(dictionary["homework_test_title"])
                .EnterHomeworkTestDescription(dictionary["homework_test_description"])
                .EnterHomeworkTestPassPoint(Int32.Parse(dictionary["homework_test_pass_point"]))
                .EnterHomeworkTestRepeatNumber(Int32.Parse(dictionary["homework_test_repeat_number"]))
                .SelectHomeworkTestType()
                .ClickHomeworkSave()
                .Assert();
        }

        [Given(@"admin checks forum exists")]
        public void GivenAdminChecksForumExist(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver).SearchForumAndDeleteIt(dictionary["name"]);
        }
        [Then(@"admin adds new forum")]
        public void GivenAdminAddsNewForum(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .EnterDescription(dictionary["name"])
                .ClickPostForum();
            //.Assert();
        }

        [Given(@"admin deletes added forum")]
        public void GivenAdminDeletesAddedForum(Table table) {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(Driver)
                .EnterForumSearch(dictionary["name"])
                .ClickDeleteForumButton()
                .ClickAreUSure()
                .Assert();
        }
    }
}