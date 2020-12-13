using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Reflection;
using TechTalk.SpecFlow;
using VeduBoxUnitTest.Kurumsal.Pages;
using VeduBoxUnitTest.Utils;

namespace VeduBoxUnitTest.StepDefinitions{
    [Binding]
    public class StepDefinitionsCommon{
        private ScenarioContext _scenarioContext;

        public StepDefinitionsCommon(ScenarioContext scenarioContext){
            _scenarioContext = scenarioContext;
        }
        public IWebDriver driver;
        [BeforeScenario]
        public void BeforeWebScenarioStudent(){
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--lang=en");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
        }
        [AfterScenario]
        [Obsolete]
        public void after(){
            if (_scenarioContext.TestError != null){
                //WebBrowser.Driver.CaptureScreenShot(_scenarioContext.ScenarioInfo.Title);
                Console.WriteLine("Title:" + ScenarioContext.Current.ScenarioInfo.Title + " is failed.");
            }
          // driver.Quit();
        }
        [Given(@"Open Kurumsal Login Page")]
        public void GivenOpenKurumsalLoginPage(){
            new OpenURL(driver).openPage();
        }
        [Given(@"Login as ""(.*)""")]
        public void WhenLoginAs(string user){
            if (user == "admin"){
                new LoginPage(driver).enterUsername("defaultadmin").enterPassword("12345").submit();
            }else if (user == "instructor"){
                new LoginPage(driver).enterUsername("defaultinstructor").enterPassword("12345").submit();
            }else if (user == "student"){
                new LoginPage(driver).enterUsername("defaultstudent").enterPassword("12345").submit();
            }else if (user == "veli"){
                new LoginPage(driver).enterUsername("defaultparent").enterPassword("12345").submit();
            }else{
                string[] words = user.Split('@');
                if(words[0] == "custom"){
                    string[] infos = words[1].Split(':');
                    if (infos[0] == null || infos[0] == "" || infos[1] == null || infos[1] == ""){
                        throw new Exception("Kullanıcı Belirtmek Zorundasınız");
                    }
                    new LoginPage(driver).enterUsername(infos[0]).enterPassword(infos[1]).submit();
                }
                else{
                    throw new Exception("Kullanıcı Belirtmek Zorundasınız");
                }
            }
        }
        [Given(@"admin adds new live with")]
        public void ThenAddNewLIVEWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openLIVEpage("admin")
                .AddNew()
                .SelectCourse(dictionary["course_name"])
                .SubmitSelectedCourse()
                .setDate()
                .selectMeetingType(dictionary["meetingType"])
                .enterTitle(dictionary["title"])
                .setHour()
                .setTimezone(dictionary["timezone"])
                .setDuration(Int32.Parse(dictionary["duration"]))
                .setRegistrationLimit(Int32.Parse(dictionary["registrationLimit"]))
                .setDescription(dictionary["description"])
                //.setTrainer("test eğitmen")
                .submit()
                .assertLive();
        }
        [Given(@"admin checks live is exist")]
        public void GivenAdminChecksLiveİsExist(){
            new HomePage(driver)
                .openLIVEpage("admin")
                .goDate()
                .checkLiveIsExist();
        }
        [Then(@"Delete LIVE")]
        public void deleteAddedLive(){
            new HomePage(driver)
                .openLIVEpage("admin")
                //.goDate(YEAR, MONTH, DAY)
                .openLiveRecordDetail()
                .clickDeleteButtonInRecordDetail()
                .clickAreUSure()
                .assertLive();
        }
        [Given(@"admin adds new user with")]
        public void adminAddsNewUserWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                    .openStudentsPage(dictionary["user"])
                    .addNew()
                    .setFirstName(dictionary["firstName"])
                    .setLastName(dictionary["lastName"])
                    .selectBranch(dictionary["branch"])
                    .setEmail(dictionary["email"])
                    .setUserName(dictionary["userName"])
                    .setPassword(dictionary["password"])
                    .setCatalog(dictionary["catalog"])
                    .setDescription(dictionary["description"])
                    .setEmailConfirmed()
                    .setGPDRPolicy()
                    .submit()
                    .assert();
        }
        [Given(@"admin checks user is exist")]
        public void GivenAdminChecksUserİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                    .openStudentsPage("admin")
                    .searchNewlyAddedUserByEmailAndDeleteIt(dictionary["email"]);
        }
        [Then(@"Delete User")]
        public void deleteUser(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openStudentsPage("admin")
                .searchNewlyAddedUserByEmail(dictionary["email"])
                .click3Points()
                .clickDeleteUserButton()
                .clickAreUSure()
                .assert();
        }
        [Given(@"admin adds new course with")]
        public void addNewCourse(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            Console.WriteLine(dictionary["category"]);
            new HomePage(driver)
                .openCOURSESpage("admin")
                .addNew()
                .setName(dictionary["name"])
                .setTags(dictionary["tags"])
                .setDescription(dictionary["description"])
                .selectCategory(dictionary["category"])
                .selectTeacher(dictionary["teacher"])
                .setCatalog(dictionary["catalog"])
                .submit()
                .assert();
        }
        [Given(@"admin checks course is exist")]
        public void GivenAdminChecksCourseİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openCOURSESpage("admin")
                .searchNewlyAddedCouseByName(dictionary["name"])
                .deleteAndAssertNewlyAddedCourseIfIsExist();
        }
        [Then(@"admin deletes added Course")]
        public void ThenAdminDeletesAddedCourse(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openCOURSESpage("admin")
                .searchNewlyAddedCouseByName(dictionary["name"])
                .deleteNewlyAddedCourse()
                .assert();
        }
        [Given(@"instructor checks live is exist")]
        public void GivenİnstructorChecksLiveİsExist(){
            new HomePage(driver)
                .openLIVEpage("admin")
                .goDate()
                .checkLiveIsExist();
        }
        [Given(@"instructor adds new live with")]
        public void GivenİnstructorAddsNewLiveWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openLIVEpage("instructor")
                .AddNew()
                .SelectCourse(dictionary["course_name"])
                .SubmitSelectedCourse()
                .setDate()
                .selectMeetingType(dictionary["meetingType"])
                .enterTitle(dictionary["title"])
                .setHour()
                .setTimezone(dictionary["timezone"])
                .setDuration(Int32.Parse(dictionary["duration"]))
                .setRegistrationLimit(Int32.Parse(dictionary["registrationLimit"]))
                .setDescription(dictionary["description"])
                .submit()
                .assertLive();
        }

       
        [Then(@"verify start live and delete live with")]
        public void ThenVerifyStartLiveAndDeleteLiveWith(){
            new LivePage(driver, "admin")
                //.goDate(YEAR, MONTH, DAY)
                .assertStart()
                .openLiveRecordDetail()
                .clickDeleteButtonInRecordDetail()
                .clickAreUSure();
        }

        [Then(@"student verify start live and delete live with")]
        public void ThenStudentVerifyStartLiveAndDeleteLiveWith(){
            new HomePage(driver)
                .openLIVEpage("student")
                .goDate()
                .assertStart()
                .openLiveRecordDetail()
                .clickDeleteButtonInRecordDetail()
                .clickAreUSure();
        }
        [Given(@"instructor checks student is exist")]
        public void GivenİnstructorChecksStudentİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openStudentsPage("instructor")
                .searchNewlyAddedUserByEmailAndDeleteIt(dictionary["email"]);
        }
        [Given(@"instructor adds new student with")]
        public void GivenİnstructorAddsNewStudentWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openStudentsPage("instructor")
                .addNew()
                .setFirstName(dictionary["firstName"])
                .setLastName(dictionary["lastName"])
                .selectBranch(dictionary["branch"])
                .setEmail(dictionary["email"])
                .setUserName(dictionary["userName"])
                .setPassword(dictionary["password"])
                .setCatalog(dictionary["catalog"])
                .setEmailConfirmed()
                .setGPDRPolicy()
                .submit()
                .assert();
        }
        [Then(@"instructor delete student")]
        public void ThenİnstructorDeleteStudent(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new StudentsPage(driver, "instructor")
                .searchNewlyAddedUserByEmail(dictionary["email"])
                .click3Points()
                .clickDeleteUserButton()
                .clickAreUSure()
                .assert();
        }
        [Given(@"instructor checks course is exist")]
        public void GivenİnstructorChecksCourseİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                    .openCOURSESpage("instructor")
                    .searchNewlyAddedCouseByName(dictionary["name"])
                    .deleteAndAssertNewlyAddedCourseIfIsExist();
        }
        [Given(@"instructor adds new course with")]
        public void GivenİnstructorAddsNewCourseWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                    .openCOURSESpage("instructor")
                    .addNew()
                    .setName(dictionary["name"])
                    .selectCategory(dictionary["category"])
                    .submit()
                    .assert();
        }
        [Then(@"instructor delete course")]
        public void ThenİnstructorDeleteCourse(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new CoursesPage(driver, "instructor")
                    .searchNewlyAddedCouseByName(dictionary["name"])
                    .deleteAndAssertNewlyAddedCourseIfIsExist();
        }
        [Given(@"instructor adds subject with")]
        public void ThenİnstructorAddsSubject(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new CoursesPage(driver, "instructor")
                    .searchNewlyAddedCouseByName(dictionary["course"])
                    .openCourseDetail(dictionary["course"])
                    .openCourseUpdate()
                    .addSubject()
                    .enterSubjectTitle(dictionary["title"])
                    .saveSubjectTitle()
                    .assert()
                    .finishEditing()
                    .assertSubjectIsVisible(dictionary["title"]);
            new HomePage(driver).openCOURSESpage("instructor");
        }
        [Given(@"instructor adds new webinar with")]
        public void GivenİnstructorAddsNewWebinarWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openLIVEpage("instructor")
                .AddNew()
                .SelectCourse(dictionary["course_name"])
                .SubmitSelectedCourse()
                .setDate()
                .selectMeetingType(dictionary["meetingType"])
                .enterTitle(dictionary["title"])
                .setHour()
                .setTimezone(dictionary["timezone"])
                .setDuration(Int32.Parse(dictionary["duration"]))
                .setRegistrationLimit(Int32.Parse(dictionary["registrationLimit"]))
                .setDescription(dictionary["description"])
                .submit()
                .assertLive();
        }
        [Then(@"instructor copies webinar URL with")]
        public void ThenİnstructorCopiesWebinarURLWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                    .openLIVEpage("instructor")
                    //.goDate(YEAR, MONTH, DAY)
                    .goToWebinar()
                    .enterFirstName(dictionary["firstName"])
                    .enterLastName(dictionary["lastName"])
                    .enterPhoneNumber(dictionary["phone"])
                    .enterEmail(dictionary["email"])
                    .setAGREEPolicy()
                    .setGPDRPolicy()
                    .clickCreateAccount()
                    .assertEmailSentText();
        }
        [Then(@"instructor deletes webinar with")]
        public void ThenİnstructorDeletesWebinarWith(){
            new HomePage(driver).openLIVEpage("instructor");
            new LivePage(driver, "instructor")
                    .goDate()
                    .openLiveRecordDetail()
                    .clickDeleteButtonInRecordDetail()
                    .clickAreUSure()
                    .assertLive();
        }
        [Then(@"student registers live")]
        public void ThenStudentRegistersLive(){
            new HomePage(driver)
                .openLIVEpage("instructor")
                .goDate()
                .studentRegister()
                .assertLive();
        }
        [Then(@"student takes exam")]
        public void ThenStudentTakesExam(){
            new HomePage(driver)
                .openExamPage("student")
                .getFirstExam()
                .clickStartExamButton()
                .clickFinishExamButton()
                .clickAreUSure()
                .assert();
        }
        [Then(@"student purchase course")]
        public void ThenStudentPurchaseCourse(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openPortalPage("student")
                .searchEntry(dictionary["entry"])
                .clickView()
                .selectLogin()
                .selectContinue()
                .selectAgree()
                .clickNext()
                .enterName(dictionary["name"])
                .enterSurName(dictionary["surname"])
                .enterCity(dictionary["city"])
                .enterDistrict(dictionary["district"])
                .enterPhone(dictionary["phone"])
                .enterAddress(dictionary["address"])
                .clickNext()
                .enterCardName(dictionary["cardName"])
                .enterCardNumber(dictionary["cardNumber"])
                .enterCardDate(dictionary["cardDate"])
                .enterCardCVC(dictionary["cardCVC"])
                .clickPayButton();
        }
        [Then(@"Student add course package purchase and reflection")]
        public void ThenStudentAddCoursePackagePurchaseAndReflection(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openPortalPage("student")
                .clickCoursesPackages()
                .searchEntry(dictionary["entry"])
                .clickCoursePackagesView()
                .selectCoursesPackageContinue()
                //.closeDismiss()
                .selectIsAgree()
                .clickNext()
                .enterPackageName(dictionary["name"])
                .enterPackageSurname(dictionary["surname"])
                .enterPackageCity(dictionary["city"])
                .enterPackageCountry(dictionary["country"])
                .enterPackagePhone(dictionary["phone"])
                .enterPackageAddress(dictionary["address"])
                .selectSameDelivery()
                .clickNext()
                .enterCardName(dictionary["cardName"])
                .enterCardNumber(dictionary["cardNumber"])
                .enterCardDate(dictionary["cardDate"])
                .enterCardCVC(dictionary["cardCVC"])
                 .clickPayButton()
                 .assertPaymentIsOK();
        }
        [Then(@"Student verifies course package is exist on Courses")]
        public void ThenStudentVerifiesCoursePackageİsExistOnCourses(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openCOURSESpage("student")
                .searchNewlyAddedCouseByName(dictionary["Name"])
                .assertSubjectIsVisible(dictionary["title"]);
        }
        [Then(@"Student make portal shopping both course and course package")]
        public void ThenStudentMakePortalShoppingBothCourseAndCoursePackage(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openPortalPage("student")
                .searchEntry(dictionary["course"])
                .addtoCart()
                .clickCoursesPackages()
                .searchEntry(dictionary["coursePackage"])
                .addtoCart()
                //TO DO //add cart seçeneği courses package için eklenmeli
                .goToCart()
                .selectCoursesPackageContinue()
                .selectIsAgree()
                .clickNext()
                .enterPackageName(dictionary["name"])
                .enterPackageSurname(dictionary["surname"])
                .enterPackageCity(dictionary["city"])
                .enterPackageCountry(dictionary["country"])
                .enterPackagePhone(dictionary["phone"])
                .enterPackageAddress(dictionary["address"])
                .selectSameDelivery()
                .clickNext()
                .enterCardName(dictionary["cardName"])
                .enterCardNumber(dictionary["cardNumber"])
                .enterCardDate(dictionary["cardDate"])
                .enterCardCVC(dictionary["cardCVC"])
                .clickPayButton()
                .assertPaymentIsOK();
        }
        [Given(@"instructor adds file source with")]
        public void GivenİnstructorAddsFileSourceWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new CoursesPage(driver, "instructor")
                    .searchNewlyAddedCouseByName(dictionary["course"])
                    .openCourseDetail(dictionary["course"])
                    .openCourseUpdate()
                    .addResource()
                    .clickResourceTypeDoc()
                    .clickOkAfterType()
                    .enterResourceTitle(dictionary["title"])
                    .enterResourceDescription(dictionary["desc"])
                    .selectDownloadable()
                    .selectUserReviewEnable()
                    .selectFile()
                    .clickSaveButton()
                    .assert();
            new HomePage(driver).openCOURSESpage("instructor");
        }
        [Given(@"instructor adds video source with")]
        public void GivenİnstructorAddsVideoSourceWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new CoursesPage(driver, "instructor")
                    .searchNewlyAddedCouseByName(dictionary["course"])
                    .openCourseDetail(dictionary["course"])
                    .openCourseUpdate()
                    .addResource()
                    .clickResourceTypeVideo()
                    .clickOkAfterType()
                    .enterResourceTitle(dictionary["title"])
                    .enterResourceDescription(dictionary["desc"])
                    .selectCourseVideoPrev()
                    .selectCourseVideoDownloadable()
                    .selectVideoForward()
                    .selectVideoUserReview()
                    .selectVideo1()
                    .clickCourseVideoSubmit()
                    .assert();
            new HomePage(driver).openCOURSESpage("instructor");
        }
        [Then(@"Verify earnings payment")]
        public void ThenVerifyEarningsPayment(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openEarningsPage("admin")
                .searchEntry(dictionary["name"]);
        }
        [Given(@"instructor adds video with vimeo")]
        public void GivenİnstructorAddsVideoWithVimeo(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new CoursesPage(driver, "instructor")
                    .searchNewlyAddedCouseByName(dictionary["course"])
                    .openCourseDetail(dictionary["course"])
                    .openCourseUpdate()
                    .addResource()
                    .clickResourceTypeVideo()
                    .clickOkAfterType()
                    .enterResourceTitle(dictionary["title"])
                    .enterResourceDescription(dictionary["desc"])
                    .selectVimeoID()
                    .enterVimeoID(dictionary["id"])
                    .selectCourseVideoDownloadable()
                    .selectVideoForward()
                    .selectCourseVideoPrev()
                    .selectVideoUserReview()
                    .clickCourseExistingVideoSubmit()
                    .assert();
            new HomePage(driver).openCOURSESpage("instructor");
        }
        [Given(@"instructor adds content as link")]
        public void GivenİnstructorAddsContentAsLink(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new CoursesPage(driver, "instructor")
                    .searchNewlyAddedCouseByName(dictionary["course"])
                    .openCourseDetail(dictionary["course"])
                    .openCourseUpdate()
                    .addResource()
                    .clickResourceTypeLink()
                    .clickOkAfterType()
                    .enterResourceTitle(dictionary["title"])
                    .setDescription(dictionary["desc"])
                    .enterLink(dictionary["link"])
                    .selectVideoUserReview()
                    .clickResourceLinkSave()
                    .assert();
            new HomePage(driver).openCOURSESpage("instructor");
        }
        [Given(@"instructor adds content as embed code")]
        public void GivenİnstructorAddsContentAsEmbedCode(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new CoursesPage(driver, "instructor")
                    .searchNewlyAddedCouseByName(dictionary["course"])
                    .openCourseDetail(dictionary["course"])
                    .openCourseUpdate()
                    .addResource()
                    .clickResourceTypeEmbedCode()
                    .clickOkAfterType()
                    .enterResourceTitle(dictionary["title"])
                    .setDescription(dictionary["desc"])
                    .enterEmbedCode(dictionary["embed_code"])
                    .selectVideoUserReview()
                    .clickResourceLinkSave()
                    .assert();
            new HomePage(driver).openCOURSESpage("instructor");
        }


        [Given(@"instructor checks question is exist")]
        public void GivenInstructorChecksMultipleChoiceQuestionİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openQuestionsPage("instructor")
                .searchNewlyAddedQuestionByNameAndDeleteIt(dictionary["name"]);
        }
        [Given(@"instructor adds multiple choice question with")]
        public void GivenİnstructorAddsMultipleChoiceQuestionWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openQuestionsPage("instructor")
                .clickAddNewButton()
                .typeQuestionInput(dictionary["question"])
                .enterPoint(Int32.Parse(dictionary["point"]))
                .clickDeleteButtonLastElementOfAnswers()
                .enterAnswerA(dictionary["choiceA"])
                .enterAnswerB(dictionary["choiceB"])
                .enterAnswerC(dictionary["choiceC"])
                .enterAnswerD(dictionary["choiceD"])
                .clickRigthAnswerAsC()
                .clickIsPublic()
                .clickIsEDITABLE()
                .selectTestCategory(dictionary["TestCategory"])
                .submit()
                .assert();
        }
        [Then(@"instructor deletes question with")]
        public void ThenInstructorDeletesQuestionWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new QuestionsPage(driver, "instructor")
                    .searchNewlyAddedQuestionByName(dictionary["name"])
                    .clickThreePoints()
                    .clickDeleteSingleQuestionPopup()
                    .assert();
        }
        [Given(@"instructor batch create question with")]
        public void GivenİnstructorBatchCreateQuestionWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new QuestionsPage(driver, "instructor")
                    .clickBatchCreateButton()
                    .enterExcelFile()
                    .selectTestCategory(dictionary["TestCategory"])
                    .clickUploadExcelButton()
                    .clickQuestionListAcceptButton()
                    .refreshPage()
                    ;
            new HomePage(driver).openQuestionsPage("instructor");
        }

        [Given(@"instructor adds true false question with")]
        public void GivenİnstructorAddsTrueFalseQuestionWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openQuestionsPage("instructor")
                .clickAddNewButton()
                .typeQuestionInput(dictionary["question"])
                .selectQuestionType("True False")
                .enterPoint(Int32.Parse(dictionary["point"]))
                .selectTrueFalseAnswer(false)
                .clickIsPublic()
                .clickIsEDITABLE()
                .selectTestCategory(dictionary["TestCategory"])
                .submit()
                .assert();
        }
        [Given(@"instructor adds open_ended question with")]
        public void GivenİnstructorAddsOpen_EndedQuestionWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openQuestionsPage("instructor")
                .clickAddNewButton()
                .typeQuestionInput(dictionary["question"])
                .selectQuestionType("Open-Ended")
                .enterPoint(Int32.Parse(dictionary["point"]))
                .clickIsPublic()
                .clickIsEDITABLE()
                .selectTestCategory(dictionary["TestCategory"])
                .submit()
                .assert();
        }
        [Given(@"instructor checks test poll question is exist")]
        public void GivenİnstructorChecksTestPollQuestionİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openTestPoolPage("instructor")
                .searchNewlyAddedPollTestByNameAndDeleteIt(dictionary["name"]);
        }

        [Given(@"instructor adds test pool multiple choice with")]
        public void GivenİnstructorAddsMultipleChoiceTestPollWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openTestPoolPage("instructor")
                .clickAddButton()
                .enterName(dictionary["name"])
                .enterDuration(Int32.Parse(dictionary["time"]))
                .selectIsPublic()
                .clickIsReturnBetweenQuestions()
                .selectTestCategory(dictionary["TestCategory"])
                .clickNextButton()
                .enterQuestionName(dictionary["question"])
                .clickSetButton()
                .clickSaveButton()
                .assert();
        }
        [Given(@"instructor delete tests with")]
        public void GivenİnstructorDeleteTestsWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new TestPoolPage(driver, "instructor")
                .searchNewlyAddedPollTestByName(dictionary["name"])
                .clickThreePoints()
                .clickDeleteTest()
                .clickAreUSure()
                .assert();
            new HomePage(driver).openQuestionsPage("instructor");
        }
        [Then(@"admin adds new branch")]
        public void ThenAdminAddsNewBranch(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openBranchPage("instructor")
                .clickAddButton()
                .enterName(dictionary["name"])
                .enterLimit(Int32.Parse(dictionary["limit"]))
                .clickSaveButton()
                .assert();
        }
        [Given(@"admin checks branch is exist")]
        public void GivenAdminChecksBranchİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openBranchPage("instructor")
                .searchNewlyAddedBranchByNameAndDeleteItAndAssertIt(dictionary["name"]);
        }
        [Then(@"admin deletes added branch")]
        public void ThenAdminDeletesAddedBranch(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openBranchPage("instructor")
                .searchNewlyAddedBranchByName(dictionary["name"])
                .selectBranch(dictionary["name"])
                .deleteNewlyAddedBranch()
                .clickAreYouSure()
                .assert();
        }
        [Then(@"admin adds instructor")]
        public void ThenAdminAddsİnstructor(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openTeachersPage("admin")
                .clickAddButton()
                .enterFirstName(dictionary["first_name"])
                .enterLastName(dictionary["last_name"])
                .selectBranchName(dictionary["branch"])
                .enterEmailName(dictionary["email"])
                .enterUserNameName(dictionary["username"])
                .enterPasswordName(dictionary["password"])
                .selectIsGuidanceTeacher()
                .selectGPDRPolicy()
                .clickSaveButton()
                .assert();
        }
        [Then(@"admin adds role to instructor")]
        public void ThenAdminAddsRoleToİnstructor(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new TeachersPage(driver, "admin")
                .searchNewlyAddedModeratorByName(dictionary["name"])
                .clickThreePoints()
                .clickRolesInThreePoints()
                .selectRole(dictionary["role1"])
                .selectRole(dictionary["role2"])
                .clickRoleSaveButton();
        }
        [Given(@"admin checks instructor is exist")]
        public void GivenAdminChecksİnstructorİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openTeachersPage("admin")
                .searchNewlyAddedModeratorByNameAndDeleteIt(dictionary["name"]);
        }
        [Then(@"admin delete instructor")]
        public void ThenAdminDeleteİnstructor(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new TeachersPage(driver, "admin")
                .searchNewlyAddedModeratorByName(dictionary["name"])
                .clickThreePoints()
                .clickDeleteInThreePoints()
                .clickAreYouSure()
                .assert();
        }
        [Given(@"admin checks announcement is exist")]
        public void GivenAdminChecksAnnouncementİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openAnnouncementsPage("admin")
                .searchNewlyAddedAnnouncementAndDeleteIt(dictionary["name"]);
        }
        [Given(@"admin adds new announcement with")]
        public void GivenAdminAddsNewAnnouncementWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
               .openAnnouncementsPage("admin")
               .clickAddButton()
               .enterTitle(dictionary["title"])
               .enterDesc(dictionary["description"])
               .selectShowToStudents()
               .selectShowToTeachers()
               .selectShowToParents()
               .enterEndDate()
               .clickSaveButton()
               .assert();
        }
        [Then(@"admin deletes announcement")]
        public void ThenAdminDeletesAnnouncementİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openAnnouncementsPage("admin")
                .searchNewlyAddedAnnouncement(dictionary["name"])
                .click3Points()
                .clickDeleteButton()
                .clickAreUSure()
                .assert();
        }
        [Given(@"admin checks parent is exist")]
        public void GivenAdminChecksParentİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openParentPage("admin")
                .searchNewlyAddedParentAndDeleteIt(dictionary["email"]);
        }
        [Then(@"admin adds parent")]
        public void ThenAdminAddsParent(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openParentPage("admin")
                .clickAddButton()
                .enterFirstName(dictionary["first_name"])
                .enterLastName(dictionary["last_name"])
                .clickAnotherChildButton()
                .selectFirstBranchName(dictionary["firstBranchName"])
                .selectFirstStudents(dictionary["firstStudents"])
                .clickAnotherChildButton()
                .selectSecondBranchName(dictionary["secondBranchName"])
                .selectSecondStudents(dictionary["secondStudents"])
                .enterEmail(dictionary["email"])
                .enterUserName(dictionary["username"])
                .enterPassword(dictionary["password"])
                //.clickGenerate()
                .selectGPDR()
                .clickSaveButton()
                .assert();
        }
        [Then(@"admin adds role to parent")]
        public void ThenAdminAddsRoleToParent(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openParentPage("admin")
                .searchNewlyAddedParent(dictionary["email"])
                .click3Points()
                .clickRolesInThreePoints()
                .selectRole(dictionary["role1"])
                .clickRoleSaveButton();
        }
        [When(@"custom parent switch to admin")]
        public void WhenCustomParentSwitchToAdmin(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .clickUpdateAcceptButton()
                .assertRoleIs("Parent")
                .clickUserName()
                .clickRoleModal()
                .enterPassword(dictionary["password"])
                .clickChangeButton()
                .assertRoleIs("Admin");
        }
        [Then(@"admin deletes added parent")]
        public void ThenAdminDeletesAddedParent(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openParentPage("admin")
                .searchNewlyAddedParent(dictionary["email"])
                .click3Points()
                .clickDeleteButton()
                .clickAreUSure()
                .assert();
        }
        [Then(@"Admin adds poll")]
        public void ThenAdminAddsPoll(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openPollsPage("admin")
                .clearSearchBox()
                .clickAddButton()
                .enterName(dictionary["Name"])
                .enterDescription(dictionary["Description"])
                .enterRepeatNumber(Int32.Parse(dictionary["RepeatNumber"]))
                .selectIsMandatory()
                .setDate()
                .clickNextButton()
                .searchQuestion(dictionary["question"])
                .setSetQuestion()
                .clickSaveButton()
                .assert();
        }
        [Then(@"Admin deletes Newly added polls")]
        public void ThenAdminDeletesNewlyAddedPolls(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new PollsPage(driver, "admin")
                .searchNewlyAddedPollByName(dictionary["Name"])
                .clickThreePoints()
                .clickDelete()
                .clickAreYouSureOK()
                .assert();
        }
        [Given(@"Admin checks poll is exist")]
        public void GivenAdminChecksPollİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openPollsPage("admin")
                .checkPollIsExist(dictionary["Name"]);
        }
        [Given(@"Admin checks poll question is exist")]
        public void GivenAdminChecksPollQuestionIsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openPollQuestionsPage("admin")
                .searchNewlyAddedQuestionByNameAndDeleteIt(dictionary["question"]);
        }
        [Given(@"Admin adds multiple choice question with")]
        public void GivenAdminAddsMultipleChoiceQuestionWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openPollQuestionsPage("admin")
                .clickAddButton()
                .enterText(dictionary["question"])
                .selectType("Multiple Choice")
                .clickIsPublic()
                .clickIsEditable()
                .clickAddNewAnswerButton()
                .enterAnswer1(dictionary["answer1"])
                .enterAnswer2(dictionary["answer2"])
                .enterAnswer3(dictionary["answer3"])
                .enterAnswer4(dictionary["answer4"])
                .clickSaveButton()
                .assert();
        }
        [Given(@"Admin adds open ended question with")]
        public void GivenAdminAddsOpenEndedQuestionWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openPollQuestionsPage("admin")
                .clickAddButton()
                .enterText(dictionary["question"])
                .selectType("Open-Ended")
                .clickIsPublic()
                .clickIsEditable()
                .clickSaveButton()
                .assert();
        }
        [Given(@"Admin adds true false question with")]
        public void GivenAdminAddsTrueFalseQuestionWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openPollQuestionsPage("admin")
                .clickAddButton()
                .enterText(dictionary["question"])
                .selectType("True False")
                .clickIsPublic()
                .clickIsEditable()
                .clickSaveButton()
                .assert();
        }
        [Then(@"Admin delete poll question with")]
        public void ThenAdminDeleteMultipleChoiceQuestionWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
               .openPollQuestionsPage("admin")
               .searchNewlyAddedQuestionByName(dictionary["question"])
               .click3Points()
               .clickDeleteButton()
               .clickAreUSure()
               .assert();
        }
        [Then(@"instructor adds test pool multiple choice with document")]
        public void ThenİnstructorAddsTestPoolMultipleChoiceWithDocument(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                    .openTestPoolPage("instructor")
                    .clickAddButton()
                    .enterName(dictionary["name"])
                    //.enterDescription(dictionary["description"])
                    .enterDuration(Int32.Parse(dictionary["Duration"]))
                    .selectIsPublic()
                    .selectIsOpticalMarker()
                    .selectIsDocument()
                    .selectFile()
                    .enterQuestionNumber(Int32.Parse(dictionary["questionNumber"]))
                    .enterPointsofEach(Int32.Parse(dictionary["points"]))
                    .enterNumberOfChoices(Int32.Parse(dictionary["choicesNumber"]))
                    .enterFirstAnswer(dictionary["firstAnswer"])
                    .enterSecondAnswer(dictionary["secondAnswer"])
                    .enterThirdAnswer(dictionary["thirdAnswer"])
                    .enterFourthAnswer(dictionary["fourthAnswer"])
                    .enterFifthAnswer(dictionary["fifthAnswer"])
                    .enterSixthAnswer(dictionary["sixthAnswer"])
                    .enterSeventhAnswer(dictionary["seventhAnswer"])
                    .enterEighthAnswer(dictionary["eighthAnswer"])
                    .selectTestCategory(dictionary["TestCategory"])
                    .clickSaveButton()
                    .assert();
        }
        [Given(@"instructor adds test pool open ended with")]
        public void GivenİnstructorAddsTestPoolOpenEndedWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                    .openTestPoolPage("instructor")
                    .clickAddButton()
                    .enterName(dictionary["name"])
                    .selectIsPublic()
                    .selectTestCategory(dictionary["TestCategory"])
                    .clickNextButton()
                    .enterQuestionName(dictionary["question"])
                    .clickSetButton()
                    .clickSaveButton()
                    .assert();
        }

        [Then(@"Admin deletes newly added test multiple choice adding question with document")]
        public void ThenAdminDeletesNewlyAddedTestMultipleChoiceAddingQuestionWithDocument(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new TestPoolPage(driver, "instructor")
                .searchNewlyAddedPollTestByName(dictionary["Name"])
                .clickThreePoints()
                .clickDeleteTest()
                .clickAreUSure()
                .assert();
        }
        [Given(@"admin checks catalog is exist")]
        public void GivenAdminChecksCatalogİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openCatalogPage("admin")
                .searchNewlyAddedCatalogAndDeleteIt(dictionary["name"]);
        }
        [Then(@"admin adds new catalog")]
        public void ThenAdminAddsNewCatalog(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openCatalogPage("instructor")
                .clickAddNew()
                .enterName(dictionary["name"])
                .enterTags(dictionary["tags"])
                .enterDescription(dictionary["description"])
                .submit()
                .assert();
        }
        [Then(@"admin adds new catalog subscription to existing catalog")]
        public void ThenAdminAddsNewCatalogSubscriptionToExistingCatalog(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openCatalogPage("instructor")
                .searchNewlyAddedCatalog(dictionary["name"])
                .click3Points()
                .clickUpdateButton()
                .clickCatalogSubscriptionAdd_button()
                .enterCatalogSubscriptionTitle(dictionary["title"])
                .selectCatalogSubscriptionCurrency(dictionary["currency"])
                .selectCatalogSubscriptionType(dictionary["type"])
                .enterCatalogSubscriptionPackageDurationTime(dictionary["duration_time"])
                .enterCatalogSubscriptionPackageDurationType(dictionary["duration_type"])
                .clickCatalogSubscriptionSaveButton()
                .assert();
        }
        [Given(@"admin deletes added catalog")]
        public void GivenAdminDeletesAddedCatalog(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openCatalogPage("instructor")
                .searchNewlyAddedCatalog(dictionary["name"])
                .click3Points()
                .clickDeleteUserButton()
                .clickAreUSure()
                .assert();
        }
        [Given(@"instructor checks exam is exist")]
        public void GivenİnstructorChecksExamİsExist(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openExamPage("instructor")
                .searchNewlyAddedExamAndDelete(dictionary["name"]);
        }
        [Then(@"instructor adds exam with document")]
        public void ThenİnstructorAddsExamWithDocument(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openExamPage("instructor")
                .clickAddNew()
                .enterName(dictionary["name"])
                .enterDescription(dictionary["description"])
                .selectCatalogs(dictionary["catalogs"])
                .clickNextButton()
                .setTests(dictionary["tests"])
                .clickSaveButton();
        }
        [Given(@"instructor delete exam with")]
        public void GivenİnstructorDeleteExamWith(Table table){
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openExamPage("instructor")
                .searchNewlyAddedExam(dictionary["name"])
                .click3Points()
                .clickDeleteExamButton()
                .clickAreUSure()
                .assert();
        }
        [Then(@"instructor adds exam with multiple choice")]
        public void ThenİnstructorAddsExamWithMultipleChoice(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openExamPage("instructor")
                .clickAddNew()
                .enterName(dictionary["name"])
                .enterDescription(dictionary["description"])
                .enterRepeatNumber(Int32.Parse(dictionary["repeatNumber"]))
                .selectCatalogs(dictionary["catalogs"])
                .clickNextButton()
                .setTests(dictionary["tests"])
                .clickSaveButton();
        }
        [Then(@"instructor adds exam with open ended")]
        public void ThenİnstructorAddsExamWithOpenEnded(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openExamPage("instructor")
                .clickAddNew()
                .enterName(dictionary["name"])
                .enterDescription(dictionary["description"])
                .enterRepeatNumber(Int32.Parse(dictionary["repeatNumber"]))
                .selectCatalogs(dictionary["catalogs"])
                .clickNextButton()
                .setTests(dictionary["tests"])
                .clickSaveButton();
        }
        [Given(@"admin checks admin is exist")]
        public void GivenAdminChecksAdminİsExist(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openADMINSpage("admin")
                .searchNewlyAddedAdminByNameAndDeleteIt(dictionary["name"]);

        }
        [Then(@"admin adds admin")]
        public void ThenAdminAddsAdmin(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                 .openADMINSpage("admin")
                 .clickAddButton()
                 .enterFirstName(dictionary["first_name"])
                 .enterLastName(dictionary["last_name"])
                 .enterEmail(dictionary["email"])
                 .enterUserName(dictionary["username"])
                 .enterPassword(dictionary["password"])
                 .clickGenerate()
                 .selectGPDR()
                 .clickSaveButton()
                 .assert();
        }
        [Then(@"admin delete admin")]
        public void ThenAdminDeleteAdmin(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new AdminsPage(driver, "admin")
                .searchNewlyAddedAdminByName(dictionary["name"])
                .click3Points()
                .clickDeleteButton()
                .clickAreUSure()
                .assert();
        }

        [Given(@"admin checks manager is exist")]
        public void GivenAdminChecksManagerİsExist(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openManagersPage("admin")
                .searchNewlyAddedManagerByNameAndDeleteIt(dictionary["name"]);

        }
        [Then(@"admin adds manager")]
        public void ThenAdminAddsManager(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                 .openManagersPage("admin")
                 .clickAddButton()
                 .enterFirstName(dictionary["first_name"])
                 .enterLastName(dictionary["last_name"])
                 .selectBranchName(dictionary["branchName"])
                 .enterEmail(dictionary["email"])
                 .enterUserName(dictionary["username"])
                 .enterPassword(dictionary["password"])
                 .clickGenerate()
                 .selectGPDR()
                 .clickSaveButton()
                 .assert();
        }
        [Then(@"admin delete manager")]
        public void ThenAdminDeleteManager(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new ManagersPage(driver, "admin")
                .searchNewlyAddedManagerByName(dictionary["name"])
                .click3Points()
                .clickDeleteButton()
                .clickAreUSure()
                .assert();
        }

        [Given(@"student adds new Q&A")]
        public void GivenStudentAddsNewQA(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openQuestionsAndAnswersPage("student")
                .clickNewTicket()
                .SelectCourse(dictionary["courseName"])
                .enterSubject(dictionary["subject"])
                .enterMessage(dictionary["message"])
                .clickNextButton()
                //.selectFile()
                .clickSendButton()
                .assert();
        }
        [Given(@"instructor checks Q&A is exist")]
        public void GivenİnstructorChecksQuestionsAndAnswerİsExist()
        {
            new HomePage(driver)
                .openQuestionsAndAnswersPage("instructor")
                .checkQuestionIsExist();
        }
        [Then(@"instructor answers the question")]
        public void GivenInstructorAnswersTheQuestion(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            new HomePage(driver)
                .openQuestionsAndAnswersPage("instructor")
                .openViewDetail()
                .enterAnswer(dictionary["answer"])
                // .selectFile()
                .clickReplyButton();
        }
        [Then(@"instructor deletes new Q&A")]
        public void GivenİnstructorDeletesNewAddedQuestion()
        {
            new HomePage(driver)
                .openQuestionsAndAnswersPage("instructor")
                .deleteNewAddedQuestions();
        }


    }
}
