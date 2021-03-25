using OpenQA.Selenium;
using System;
using System.IO;
using System.Text;
using VeduBoxUnitTest.Assertion;
using VeduBoxUnitTest.Utils;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class CoursesPage : Page{
        private readonly By BUTTON_ADD_NEW_ADMIN = By.CssSelector("button[ui-sref='veduBox.admin.courses.new']");
        private readonly By BUTTON_ADD_NEW_INSTRUCTOR = By.CssSelector("button[ng-show='$root.app.isTeacherAddCourseAndPackageEnabled']");
        private readonly By INPUT_NAME_ADMIN = By.CssSelector("input[ng-model='course.name']");
        private readonly By INPUT_NAME_INSTRUCTOR = By.CssSelector("input[ng-model='courseAndPackage.courseName']");
        private readonly By INPUT_TAGS = By.XPath("//*[@id='courseForm']/div[1]/div[2]/div/div/input");
        private readonly By DIV_DESCRIPTION = By.XPath("/html/body/div[6]/div/div/div/div[5]/div/div/div/div/form/div[1]/div[2]/div/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private readonly By DIV_CREATE_COURSE_DESCRIPTION = By.XPath("/html/body/div[3]/div/section/div/div[1]/div[3]/div/div/div[2]/form/div[1]/div[3]/div/text-angular/div[2]/div[3]");
        private readonly By DIV_EMBEDDED_DESCRIPTION = By.CssSelector("div[placeholder='Description']");
        private readonly By SELECT_CATEGORY_ADMIN = By.CssSelector("select[ng-model='course.categoryId']");
        private readonly By SELECT_CATEGORY_INSTRUCTOR = By.CssSelector("select[ng-model='courseAndPackage.categoryId']");
        private readonly By SELECT_TEACHER = By.CssSelector("select[ng-model='course.teacherUserId']");
        private readonly By SELECT_CATALOG = By.CssSelector("select[ng-model='course.teacherUserId']");
        private readonly By BUTTON_SUBMIT_ADMIN = By.CssSelector("button[type='submit']:nth-child(1)");
        private readonly By BUTTON_SUBMIT_INSTRUCTOR = By.CssSelector("button[ng-disabled='courseAndPackageForm.$invalid']");
        private readonly By ALERT_SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private readonly By INPUT_SEARCH_BOX = By.CssSelector("input.form-control.vedu-search");
        private readonly By BUTTON_THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private readonly By BUTTON_DELETE_COURSE = By.CssSelector("button[ng-click='delete(course)']");
        private readonly By ALERT_ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private readonly By LINK_PROJECT_MANAGEMENT = By.XPath("//*[contains(text(),'project management')]");
        private readonly By BUTTON_COURSE_UPDATE = By.CssSelector("button[ui-sref='veduBox.teacher.me.courses.edit({id: course.courseId})']");
        private readonly By BUTTON_COURSE_RESOURCES = By.CssSelector("button[ui-sref='veduBox.admin.courses.courseEdit({id: course.courseId})']");
        private readonly By BUTTON_DELETE_COURSE_INSTRUCTOR = By.CssSelector("button[ng-click='deleteCourse(course.courseId)']");
        private readonly By A_ADD_SUBJECT_BUTTON = By.CssSelector("a[ng-click='saveSubject(0)']");
        private readonly By INPUT_SUBJECT_INPUT = By.CssSelector("input[ng-model='title']");
        private readonly By BUTTON_FINISH_EDITING_BUTTON = By.CssSelector("button[ui-sref='veduBox.teacher.me.courses.view({id: course.courseId})']");
        private readonly By BUTTON_SAVE_SUBJECT_BUTTON = By.XPath("/html/body/div[6]/div/div/div/div[3]/button[1]");
        private readonly By BUTTON_ADD_RESOURCE_TEACHER = By.Id("teacherCourseEditAddResource");
        private readonly By BUTTON_ADD_RESOURCE_ADMIN = By.CssSelector("button[ng-click='addResource(subject.id)']");
        private readonly By DIV_SELECT_RESOURCE_DOC = By.Id("rescourceTypeDoc");
        private readonly By BUTTON_RESOURCE_OK = By.Id("rescourceTypeOkBtn");
        private readonly By INPUT_RESOURCE_TITLE = By.Id("txtName");
        private readonly By DIV_RESOURCE_DESC = By.CssSelector("div[placeholder='Description']");
        private readonly By CHECKBOX_RESOURCE_DOWNLOADABLE_CHECK = By.Id("resourceTypeDocDownload");
        private readonly By CHECKBOX_RESOURCE_VIDEO_SPEED_CONTROL= By.CssSelector("input[ng-model='resource.videoSpeedControl']");
        private readonly By CHECKBOX_RESOURCE_DOC_REVIEW_CHECK = By.Id("resourceTypeDocReview");
        private readonly By CHECKBOX_RESOURCE_VIDEO_REVIEW_CHECK = By.Id("resourceTypeVideoReview");
        private readonly By BUTTON_RESOURCE_DOC_SAVE = By.Id("resourceTypeDocFileSave");
        private readonly By DIV_SELECT_RESOURCE_VIDEO = By.Id("rescourceTypeVideo");
        private readonly By DIV_SELECT_RESOURCE_LINK = By.Id("rescourceTypeLink");
        private readonly By INPUT_RESOURCE_LINK = By.CssSelector("input[ng-model='resource.url']");
        private readonly By BUTTON_RESOURCE_LINK_SAVE = By.XPath("//*[@id='resourceForm']/div[2]/div/div/button[1]");
        private readonly By SELECT_RESOURCE_EMBED_CODE = By.Id("rescourceTypeEmbedCode");
        private readonly By INPUT_RESOURCE_EMBED_CODE = By.CssSelector("textarea[ng-model='resource.code']");
        private readonly By INPUT_RESOURCE_TYPE_DOC_FILE = By.Id("resourceTypeDocFile");
        private readonly By INPUT_RESOURCE_TYPE_DOC_VIDEO1 = By.Id("fileVideo");
        private readonly By BUTTON_RESOURCE_VIDEO_UPLOAD_BUTTON = By.CssSelector("button[translate='common.upload']");
        private readonly By INPUT_RESOURCE_TYPE_DOC_VIDEO2 = By.Id("fileTwo");
        private readonly By CHECKBOX_RESOURCE_VIDEO_PREVIEW = By.CssSelector("input[ng-model='resource.preview']");
        private readonly By CHECKBOX_RESOURCE_VIDEO_DOWNLOADABLE = By.CssSelector("input[ng-model='resource.downloadable']");
        private readonly By CHECKBOX_RESOURCE_VIDEO_FORWARD = By.CssSelector("input[ng-model='resource.forwardRewindEnabled']");
        private readonly By CHECKBOX_RESOURCE_VIDEO_USER_REVIEW = By.CssSelector("input[ng-model='resource.userReviewEnabled']");
        private readonly By BUTTON_RESOURCE_VIDEO_SUBMIT = By.Id("resourceTypeVideoFileSave");
        private readonly By BUTTON_RESOURCE_VIDEO_EXISTING_SUBMIT = By.Id("resourceTypeVideoFileSaveExisting");
        private readonly By CHECKBOX_RESOURCE_VIDEO_VIMEO = By.CssSelector("input[ng-model='resource.vimeoIdEnabled']");
        private readonly By INPUT_RESOURCE_VIDEO_VIMEO_TEXT = By.Id("resourceTypeVideoIfVimeoIdValue");
        private readonly By LABEL_UPLOADED_FILE = By.CssSelector("label[ng-bind='resource.fileName']");
        private readonly By SELECT_RESOURCE_TEST = By.Id("rescourceTypeTest");
        private readonly By DIV_EMBEDDED_DESCRIPTION_FOR_TEST = By.CssSelector("div[placeholder='Description']");
        private readonly By INPUT_PASS_POINT = By.CssSelector("input[ng-model='resource.passPoint']");
        private readonly By INPUT_REPEAT_NUMBER = By.CssSelector("input[ng-model='resource.repeatNumber']");
        private readonly By CHECK_REDIRECT_TO_RESULT_PAGE_AFTER_TEST = By.CssSelector("input[ng-model='resource.redirectToResultPageAfterFinished']");
        private readonly By CHECK_IS_BETWEEN_DATES = By.CssSelector("input[ng-model='resource.isBetweenDates']");
        private readonly By CHECK_IS_EXAM_RESULT_DOWNLOAD = By.CssSelector("input[ng-model='resource.isExamResultDownloadEnable']");
        private readonly By CHECK_ARE_STUDENT_ANSWERS_SHOWN_IN_EXAM_RESULT = By.CssSelector("input[ng-model='resource.areStudentAnswersShownInExamResult']");
        private readonly By RADIO_FIRST_TEST = By.XPath("//*[@id='resourceForm']/div[1]/div[18]/div/div[2]/table/tbody/tr[1]/td[2]/input");
        private readonly By SELECT_RESOURCE_TEXT = By.Id("rescourceTypeText");
        private readonly By SELECT_RESOURCE_INTERACTIVE_VIDEO = By.Id("rescourceTypeInteractiveVideo");
        private readonly By DIV_RESOURCE_TEXT_DESCRIPTION= By.XPath("/html/body/div[6]/div/div/div/div[5]/div/div/div/div/form/div[1]/div[2]/div/text-angular/div[2]/div[3]");
        private readonly By BUTTON_RESOURCE_TEXT_SAVE = By.XPath("/html/body/div[6]/div/div/div/div[4]/div/div/div/div/form/div[2]/div/div/button[1]");
        private readonly string UPLOADED_FILE_TEXT = "video.mp4";
        private readonly By BUTTON_COURSES_FILES = By.CssSelector("a[ng-bind*='common.files']");
        private readonly By BUTTON_COURSE_ADD_CATEGORY = By.CssSelector("span[translate*='routeStates.teacher.courseFile.lblAddRootCourseFile']");
        private readonly By INPUT_CATEGORY_NAME = By.CssSelector("input[ng-model*='courseFile.name']");
        private readonly By BUTTON_COURSE_ADD_CATEGORY_OK = By.CssSelector("span[ng-bind*='common.add']");
        private readonly By BUTTON_COURSE_ADD_ITEM = By.CssSelector("span[translate='routeStates.teacher.courseFile.lblAddCourseFileItem']");
        private readonly By BUTTON_CATEGORY_CHOOSE_DOCUMENT = By.CssSelector("span.fa-file");
        private readonly By BUTTON_CATEGORY_CHOOSE_VIDEO = By.CssSelector("span.fa-vimeo");
        private readonly By BUTTON_CATEGORY_CHOOSE_LINK = By.CssSelector("span.fa-link");
        private readonly By BUTTON_CATEGORY_CHOOSE_CODE = By.CssSelector("span.fa-code");
        private readonly By BUTTON_CATEGORY_CHOOSE_TEXT = By.CssSelector("span.fa-font");
        private readonly By BUTTON_CATEGORY_CHOOSE_TEST = By.CssSelector("span.fa-pencil");
        private readonly By BUTTON_CATEGORY_CHOOSE_OK = By.CssSelector("span[translate='common.ok']");
        private readonly By INPUT_CATEGORY_DOCUMENT_TITLE = By.XPath("(//input[@id='txtName'])[1]");
        private readonly By TEXTAREA_CATEGORY_DOCUMENT_DESC = By.XPath("(//textarea[@id='txtDescription'])[1]");
        private readonly By BUTTON_ADD_DOCUMENT_TYPE_SAVE = By.XPath("(//i[@class='fa fa-save'])[2]");
        private readonly By INPUT_SELECT_FILE_TO_CATEGORY = By.XPath("(//input[@ng-model='courseFileItem.file'])[1]");
        private readonly By INPUT_CATEGORY_LINK = By.XPath("(//input[@ng-model='courseFileItem.url'])[1]");
        private readonly By TEXTAREA_CATEGORY_CODE = By.XPath("(//textarea[@ng-model='courseFileItem.code'])[1]");
        private readonly By BUTTON_CATEGORY_UPDATE = By.CssSelector("span[translate='common.update']");
        private readonly By BUTTON_CATEGORY_HOMEWORK = By.CssSelector("span[ng-bind*='homework']");
        private readonly By BUTTON_CATEGORY_PROFILE = By.CssSelector("span[ng-bind*='Profile']");
        private readonly By BUTTON_CATEGORY_CONTENTS = By.CssSelector("span[ng-bind*='btnSubjects']");
        private readonly By BUTTON_CATEGORY_ANNOUNCEMENTS = By.CssSelector("span[ng-bind*='announcements']");
        private readonly By BUTTON_CATEGORY_POLLS = By.CssSelector("span[ng-bind*='polls']");
        private readonly By BUTTON_CATEGORY_ADD_POLLS = By.CssSelector("button[ng-click='addEditPoll(0)']");
        private readonly By INPUT_POLLS_TITLE = By.CssSelector("input[ng-model='poll.name']");
        private readonly By INPUT_POLLS_DESCRIPTION = By.CssSelector("textarea[ng-model='poll.description']");
        private readonly By INPUT_POLLS_TEST_REPEAT_NUMBER = By.CssSelector("input[ng-model='poll.repeatNumber']");
        private readonly By TEST_PASS_POINT = By.CssSelector("input[ng-model='resource.passPoint']");
        private readonly By TEST_REPEAT_NUMBER = By.CssSelector("input[ng-model='resource.repeatNumber']");
        private readonly By SELECT_TEST = By.XPath("(//td[contains(@ng-click,'toggleSelection')])[1]");
        private readonly By TEST_SAVE_BUTTON = By.XPath("(//button[@type='submit'])[3]");

        
        private readonly By INPUT_POLLS_START_DATE_NEW_MODEL_SELECT_DATA = By.CssSelector("input[ng-model='poll.startDate']");
        private readonly By BUTTON_POLLS_START_DATE_OPEN_DATEPICKER = By.XPath("(//button[contains(@ng-click,'open')])[3]");
        private readonly By BUTTON_POLLS_START_DATE_CHOOSE_YEAR = By.XPath("(//button[@ng-click='toggleMode()'])[1]");
        private readonly By BUTTON_POLLS_START_DATE_GO_PREVIOUS_YEAR = By.XPath("(//button[@ng-click='move(-1)'])[1]");
        private readonly By BUTTON_POLLS_START_DATE_GO_NEXT_YEAR = By.XPath("(//button[@ng-click='move(1)'])[1]");
        private readonly By INPUT_POLLS_END_DATE_NEW_MODEL_SELECT_DATA = By.CssSelector("input[ng-model='poll.endDate']");
        private readonly By BUTTON_POLLS_END_DATE_OPEN_DATEPICKER = By.XPath("(//button[contains(@ng-click,'open')])[4]");
        private readonly By BUTTON_POLLS_END_DATE_CHOOSE_YEAR = By.XPath("(//button[@ng-click='toggleMode()'])[2]");
        private readonly By BUTTON_POLLS_END_DATE_GO_PREVIOUS_YEAR = By.XPath("(//button[@ng-click='move(-1)'])[2]");
        private readonly By BUTTON_POLLS_END_DATE_GO_NEXT_YEAR = By.XPath("(//button[@ng-click='move(1)'])[2]");
        private readonly By BUTTON_POLLS_NEXT = By.XPath("(//button[@ng-click='goToStep(2)'])[1]");
        private readonly By POLL_1 = By.XPath("(//span[@translate='common.set'])[2]");
        private readonly By POLL_2 = By.XPath("(//span[@translate='common.set'])[3]");
        private readonly By BUTTON_POLLS_SAVE = By.CssSelector("button[ng-click='goToStep(3)']");
        
        private readonly By BUTTON_CATEGORY_ADD_HOMEWORK = By.CssSelector("a[ng-click='addEditHomeworks(0)']");
        private readonly By INPUT_HOMEWORK_TITLE = By.CssSelector("input[ng-model='homework.title']");
        private readonly By INPUT_HOMEWORK_DESC = By.XPath("/html/body/div[6]/div/div/div/div[2]/form/div[1]/div[2]/div/text-angular/div[2]/div[3]");
        private readonly By INPUT_HOMEWORK_PASS_POINT = By.CssSelector("input[ng-model='homework.passPoint']");
        private readonly By INPUT_HOMEWORK_WEIGHT_PERCENTAGE = By.CssSelector("input[ng-model='homework.weightPercent']");
        private readonly By BUTTON_HOMEWORK_SAVE = By.XPath("(//span[@translate='common.save'])[3]");
        private readonly By BUTTON_HOMEWORK_ADD_ITEM = By.XPath("//span[@translate='routeStates.teacher.library.lblAddLibraryItem']");
        private readonly By BUTTON_HOMEWORK_SELECT = By.CssSelector("span[translate='common.select']");
        private readonly By INPUT_HOMEWORK_DOC_TITLE = By.Id("txtName");
        private readonly By INPUT_HOMEWORK_DOC_DESC = By.CssSelector("textarea[ng-model='homeworkItem.description']");
        private readonly By INPUT_HOMEWORK_DOC_SELECT = By.CssSelector("input[ng-model='homeworkItem.file']");
        private readonly By INPUT_HOMEWORK_LINK = By.CssSelector("input[ng-model='homeworkItem.url']");
        private readonly By INPUT_HOMEWORK_EMBED = By.CssSelector("textarea[ng-model='homeworkItem.code']");
        private readonly By INPUT_HOMEWORK_TEST_TITLE = By.CssSelector("input[ng-model='homeworkItem.title']");
        private readonly By INPUT_HOMEWORK_TEST_DESC = By.CssSelector("#txtDescription");
        private readonly By INPUT_HOMEWORK_TEST_PASS_POINT = By.CssSelector("input[ng-model='homeworkItem.passPoint']");
        private readonly By INPUT_HOMEWORK_TEST_REPEAT_NUMBER = By.CssSelector("input[ng-model='homeworkItem.repeatNumber']");
        private readonly By SELECT_HOMEWORK_TEST = By.XPath("(//td[@ng-click='toggleSelection(test.testId); testSelected(test)'])[1]");
        private readonly By INPUT_HOMEWORK_START_DATE_NEW_MODEL_SELECT_DATA = By.CssSelector("input[ng-model='homework.startDate']");
        private readonly By BUTTON_START_DATE_OPEN_DATEPICKER = By.XPath("/html/body/div[6]/div/div/div/div[2]/form/div[1]/div[3]/div/p/span/button");
        private readonly By BUTTON_START_DATE_CHOOSE_YEAR = By.XPath("(//button[@ng-click='toggleMode()'])[1]");
        private readonly By BUTTON_START_DATE_GO_PREVIOUS_YEAR = By.XPath("(//button[@ng-click='move(-1)'])[1]");
        private readonly By BUTTON_START_DATE_GO_NEXT_YEAR = By.XPath("(//button[@ng-click='move(1)'])[1]");
        private readonly By INPUT_HOMEWORK_END_DATE_NEW_MODEL_SELECT_DATA = By.CssSelector("input[ng-model='homework.endDate']");
        private readonly By BUTTON_END_DATE_OPEN_DATEPICKER = By.XPath("/html/body/div[6]/div/div/div/div[2]/form/div[1]/div[4]/div/p/span/button");
        private readonly By BUTTON_END_DATE_CHOOSE_YEAR = By.XPath("(//button[@ng-click='toggleMode()'])[2]");
        private readonly By BUTTON_END_DATE_GO_PREVIOUS_YEAR = By.XPath("(//button[@ng-click='move(-1)'])[2]");
        private readonly By BUTTON_END_DATE_GO_NEXT_YEAR = By.XPath("(//button[@ng-click='move(1)'])[2]");
        private readonly By START_DATE_DONE = By.XPath("(//button[@ng-click='close()'])[1]");
        private readonly By END_DATE_DONE = By.XPath("(//button[@ng-click='close()'])[2]");
        private readonly By VIMEO = By.Id("videoSaveOptionVimeo");


        private string USER;
        public CoursesPage(IWebDriver wd, string user) : base(wd){
            USER = user;
        }
        public CoursesPage AddNew(){
            if(USER == Constants.Roles.Admin.ToString())
                Click(BUTTON_ADD_NEW_ADMIN);
            else if(USER == Constants.Roles.Instructor.ToString())
                Click(BUTTON_ADD_NEW_INSTRUCTOR);
            return this;
        }
        public CoursesPage SetName(string name){
            if(USER == Constants.Roles.Admin.ToString())
                Type(INPUT_NAME_ADMIN, name);
            else if(USER == Constants.Roles.Instructor.ToString())
                Type(INPUT_NAME_INSTRUCTOR, name);
            return this;
        }
        public CoursesPage SetTags(string tags){
            string[] names = tags.Split(',');
            foreach (var name in names){
                Type(INPUT_TAGS, name + ",");
            }
            return this;
        }
        public CoursesPage SetDescription(string description){
            Type(DIV_DESCRIPTION, description);
            return this;
        }
        public CoursesPage SetCreateCourseDescription(string description)
        {
            Type(DIV_CREATE_COURSE_DESCRIPTION, description);
            return this;
        }
        public CoursesPage SetEmbeddedDescription(string description){
            Type(DIV_EMBEDDED_DESCRIPTION, description);
            return this;
        }
        public CoursesPage SelectCategory(string categoryName){
            categoryName = Encoding.UTF8.GetString(Encoding.Default.GetBytes(categoryName));
            if (USER == Constants.Roles.Admin.ToString())
                SelectDropDown(SELECT_CATEGORY_ADMIN, categoryName);
            else if (USER == Constants.Roles.Instructor.ToString())
                SelectDropDown(SELECT_CATEGORY_INSTRUCTOR, categoryName);
            return this;
        }
        public CoursesPage SelectTeacher(string teacherName){
            SelectDropDown(SELECT_TEACHER, teacherName);
            return this;
        }
        public CoursesPage SetCatalog(string catalogNames){
            string[] names = catalogNames.Split(',');
            foreach (var name in names){
                Click(By.XPath("//a[contains(text(), '" + name + "')]"));
            }
            return this;
        }
        public CoursesPage Submit(){
            if (USER == Constants.Roles.Admin.ToString())
                Click(BUTTON_SUBMIT_ADMIN);
            else if (USER == Constants.Roles.Instructor.ToString())
                Click(BUTTON_SUBMIT_INSTRUCTOR);
            return this;
        }
        public CoursesPage Assert(){
            AssertionCustom.AssertElementVisible("Element Not Found", Driver, ALERT_SUCCESS);
            return this;
        }
        public CoursesPage SearchNewlyAddedCourseByName(string tag){
            Type(INPUT_SEARCH_BOX, tag);
            Sleepms(1000);
            return this;
        }
        public CoursesPage DeleteAndAssertNewlyAddedCourseIfIsExist(){
            try{
                DeleteNewlyAddedCourse();
                Assert();
            }catch(Exception e){
                Console.WriteLine("Error while deleting course. Error is : " + e.Message);
            }
            return this;
        }
        public CoursesPage DeleteNewlyAddedCourse(){
            if (USER == Constants.Roles.Admin.ToString()){
                Click3Points();
                Click(BUTTON_DELETE_COURSE);
            }else if (USER == Constants.Roles.Instructor.ToString()){
                Click(BUTTON_DELETE_COURSE_INSTRUCTOR);
            }
            Click(ALERT_ARE_U_SURE_OK);
            return this;
        }
        public CoursesPage ClickResources(){
            Click(BUTTON_COURSE_RESOURCES);
            return this;
        }
        public CoursesPage Click3Points(){
            Click(BUTTON_THREE_POINTS);
            return this;
        }
        public CoursesPage OpenCourseDetail(string name){
            try {
                Click(By.XPath("//div[contains(text(), '" + name + "')]"));
                Console.WriteLine("Clicked "+ name + " course in Courses Page");
            }catch (Exception e) {
                Console.WriteLine("Error occured during opening Course Detail. Error is : " + e);
            }
            return this;
        }
        public CoursesPage OpenCourseUpdate(){
            try{
                Click(BUTTON_COURSE_UPDATE);
                Console.WriteLine("Clicked Update button in Courses Page");
            }
            catch (Exception e){
                Console.WriteLine("Error occured during opening Course Update. Error is : " + e);
            }
            return this;
        }
        public CoursesPage AddSubject(){
            try{
                Click(A_ADD_SUBJECT_BUTTON);
                Console.WriteLine("Clicked Add Subject button in Courses Detail Page");
            }catch (Exception e){
                Console.WriteLine("Error occured during clicking Add Subject. Error is : " + e);
            }
            return this;
        }
        public CoursesPage EnterSubjectTitle(string title){
            try{
                Type(INPUT_SUBJECT_INPUT, title);
                Console.WriteLine("Subject title is typed");
            }catch (Exception e){
                Console.WriteLine("Error occured during entering Subject Title. Error is : " + e);
            }
            return this;
        }
        public CoursesPage AssertSubjectIsVisible(string title){
            AssertionCustom.AssertElementVisible(title + " text was not found", Driver, By.XPath("(//*[contains(text(), '"+ title + "')])[1]"));
            return this;
        }
        public CoursesPage FinishEditing(){
            try{
                Click(BUTTON_FINISH_EDITING_BUTTON);
                Console.WriteLine("Clicked Finish Editing button in Courses Detail Page");
            }catch (Exception e){
                Console.WriteLine("Error occured during clicking Finish Editing button. Error is : " + e);
            }
            return this;
        }
        public CoursesPage SaveSubjectTitle(){
            try{
                Click(BUTTON_SAVE_SUBJECT_BUTTON);
                Console.WriteLine("Subject title is saved");
            }catch (Exception e){
                Console.WriteLine("Error occured during saving Subject Title. Error is : " + e);
            }
            return this;
        }
        public CoursesPage AddResource(){
            if (USER == Constants.Roles.Instructor.ToString()){
                Click(BUTTON_ADD_RESOURCE_TEACHER);
            }else if (USER == Constants.Roles.Admin.ToString()){
                Click(BUTTON_ADD_RESOURCE_ADMIN);
            }
            return this;
        }
        public CoursesPage ClickResourceTypeDoc(){
            Click(DIV_SELECT_RESOURCE_DOC);
            return this;
        }
        public CoursesPage ClickOkAfterType(){
            Click(BUTTON_RESOURCE_OK);
            return this;
        }
        public CoursesPage EnterResourceTitle(string title){
            Type(INPUT_RESOURCE_TITLE, title);
            return this;
        }
        public CoursesPage EnterResourceDescription(string desc){
            Type(DIV_RESOURCE_DESC, desc);
            return this;
        }
        public CoursesPage EnterTestPassPoint(int test_pass_point)
        {
            Type(TEST_PASS_POINT, test_pass_point);
            return this;
        }
        public CoursesPage EnterTestrEPEATnUMBER(int test_repeat_number)
        {
            Type(TEST_REPEAT_NUMBER, test_repeat_number);
            return this;
        }
        public CoursesPage SelectTest()
        {
            Click(SELECT_TEST);
            return this;
        }
        public CoursesPage ClickTestSaveButton()
        {
            Click(TEST_SAVE_BUTTON);
            return this;
        }
        public CoursesPage EnterEmbedCode(string code){
            Type(INPUT_RESOURCE_EMBED_CODE, code);
            return this;
        }
        public CoursesPage SelectDownloadable(){
            Click(CHECKBOX_RESOURCE_DOWNLOADABLE_CHECK);
            return this;
        }
        public CoursesPage SelectUserReviewEnableForDoc(){
            Click(CHECKBOX_RESOURCE_DOC_REVIEW_CHECK);
            return this;
        }
        public CoursesPage SelectUserReviewEnableForVideo(){
            Click(CHECKBOX_RESOURCE_VIDEO_REVIEW_CHECK);
            return this;
        }
        public CoursesPage SelectFile(){
            Type(
                INPUT_RESOURCE_TYPE_DOC_FILE,
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Docs\\file.png"))
            );
            return this;
        }
        public CoursesPage ClickSaveButton(){
            Click(BUTTON_RESOURCE_DOC_SAVE);
            return this;
        }
        public CoursesPage ClickResourceTypeVideo(){
            Click(DIV_SELECT_RESOURCE_VIDEO);
            return this;
        }
        public CoursesPage ClickResourceTypeLink(){
            Click(DIV_SELECT_RESOURCE_LINK);
            return this;
        }
        public CoursesPage EnterLink(string link){
            Type(INPUT_RESOURCE_LINK, link);
            return this;
        }
        public CoursesPage ClickResourceLinkSave(){
            Click(BUTTON_RESOURCE_LINK_SAVE);
            return this;
        }
        public CoursesPage ClickInteractiveVideoSave(){
            Click(By.CssSelector("button[ng-click='submitInteractiveVideo()']"));
            return this;
        }
        public CoursesPage ClickResourceTypeEmbedCode(){
            Click(SELECT_RESOURCE_EMBED_CODE);
            return this;
        }
        public CoursesPage ClickVimeo()
        {
            Click(VIMEO);
            return this;
        }
        public CoursesPage SelectVideo1(){
            Type(
                INPUT_RESOURCE_TYPE_DOC_VIDEO1,
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Docs\\video.mp4"))
            );
            return this;
        }
        public CoursesPage ClickUpload(){
            Click(BUTTON_RESOURCE_VIDEO_UPLOAD_BUTTON);
            return this;
        }
        public CoursesPage SelectVideo2(){
            Type(
                INPUT_RESOURCE_TYPE_DOC_VIDEO2,
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Docs\\video.mp4"))
            );
            return this;
        }
        public CoursesPage SelectCourseVideoPrev(){
            if (IsSelected(CHECKBOX_RESOURCE_VIDEO_PREVIEW) == false)
                Click(CHECKBOX_RESOURCE_VIDEO_PREVIEW);
            return this;
        }
        public CoursesPage SelectCourseVideoDownloadable(){
            if (IsSelected(CHECKBOX_RESOURCE_VIDEO_DOWNLOADABLE) == false)
                Click(CHECKBOX_RESOURCE_VIDEO_DOWNLOADABLE);
            return this;
        }
        public CoursesPage SelectCourseVideoSpeedControl(){
            if (IsSelected(CHECKBOX_RESOURCE_VIDEO_SPEED_CONTROL) == false)
                Click(CHECKBOX_RESOURCE_VIDEO_SPEED_CONTROL);
            return this;
        }
        public CoursesPage SelectVideoForward(){
            if (IsSelected(CHECKBOX_RESOURCE_VIDEO_FORWARD) == false)
                Click(CHECKBOX_RESOURCE_VIDEO_FORWARD);
            return this;
        }
        public CoursesPage SelectVideoUserReview(){
            if (IsSelected(CHECKBOX_RESOURCE_VIDEO_USER_REVIEW) == false)
                Click(CHECKBOX_RESOURCE_VIDEO_USER_REVIEW);
            return this;
        }
        public CoursesPage WaitUntilFileIsUploaded(){
            AssertionCustom.AssertTextToBePresentInElementLocated(Driver, LABEL_UPLOADED_FILE, UPLOADED_FILE_TEXT, "Element Not Found");
            return this;
        }
        public CoursesPage ClickCourseVideoSubmit(){
            Click(BUTTON_RESOURCE_VIDEO_SUBMIT);
            return this;
        }
        public CoursesPage ClickCourseExistingVideoSubmit(){
            Click(BUTTON_RESOURCE_VIDEO_EXISTING_SUBMIT);
            return this;
        }
        public CoursesPage SelectVimeoId(){
            if (IsSelected(CHECKBOX_RESOURCE_VIDEO_VIMEO) == false)
                Click(CHECKBOX_RESOURCE_VIDEO_VIMEO);
            return this;
        }
        public CoursesPage EnterVimeoId(string id){
            Type(INPUT_RESOURCE_VIDEO_VIMEO_TEXT, id);
            return this;
        }
        public CoursesPage EnterInteractiveVimeoId(string id){
            Type(By.CssSelector("input[ng-model='vimeoId']"), id);
            return this;
        }
        public CoursesPage ClickNext(){
            Click(By.XPath("//*[@id='pageBody']/div/div/div/div[2]/div[1]/button[1]"));
            return this;
        }
        public CoursesPage ClickNext2(){
            Click(By.XPath("//*[@id='pageBody']/div/div/div/div[2]/div[2]/button[2]"));
            return this;
        }
        public CoursesPage ClickResourceTypeTest(){
            Click(SELECT_RESOURCE_TEST);
            return this;
        }
        public CoursesPage SetTestDescription(string text) {
            Type(DIV_EMBEDDED_DESCRIPTION_FOR_TEST, text);
            return this;
        }
        public CoursesPage SetPassPoint(int point) {
            Type(INPUT_PASS_POINT, point);
            return this;
        }
        public CoursesPage SetRepeatNumber(int number) {
            Type(INPUT_REPEAT_NUMBER, number);
            return this;
        }
        public CoursesPage SetRedirectToResultPageAfterTest() {
            if (IsSelected(CHECK_REDIRECT_TO_RESULT_PAGE_AFTER_TEST) == false) {
                Click(CHECK_REDIRECT_TO_RESULT_PAGE_AFTER_TEST);
            }
            return this;
        }
        public CoursesPage SetIsBetweenDates() {
            if (IsSelected(CHECK_IS_BETWEEN_DATES) == false) {
                Click(CHECK_IS_BETWEEN_DATES);
            }
            return this;
        }
        public CoursesPage SetIsExamResultDownload() {
            if (IsSelected(CHECK_IS_EXAM_RESULT_DOWNLOAD) == false) {
                Click(CHECK_IS_EXAM_RESULT_DOWNLOAD);
            }
            return this;
        }
        public CoursesPage SetFirstTestToList() {
            if (IsSelected(RADIO_FIRST_TEST) == false) {
                Click(RADIO_FIRST_TEST);
            }
            return this;
        }
        public CoursesPage SetAreStudentAnswersShownInExamResult() {
            if (IsSelected(CHECK_ARE_STUDENT_ANSWERS_SHOWN_IN_EXAM_RESULT) == false) {
                Click(CHECK_ARE_STUDENT_ANSWERS_SHOWN_IN_EXAM_RESULT);
            }
            return this;
        }
        public CoursesPage ClickResourceTypeText(){
            Click(SELECT_RESOURCE_TEXT);
            return this;
        }
        public CoursesPage ClickResourceTypeInteractiveVideo(){
            Click(SELECT_RESOURCE_INTERACTIVE_VIDEO);
            return this;
        }
        public CoursesPage SetDescriptionForText(string description){
            Type(DIV_RESOURCE_TEXT_DESCRIPTION, description);
            return this;
        }
        public CoursesPage SetDescriptionForInteractiveVimeo(string description){
            Type(By.XPath("/html/body/div[6]/div/div/div/div[5]/div/div/div/div/div/div/div[1]/div/div[1]/form/div/div[1]/div[2]/div/vedu-box-text-angular/text-angular/div[2]/div[3]"), description);
            return this;
        }
        public CoursesPage ClickSaveButtonForText(){
            Click(BUTTON_RESOURCE_TEXT_SAVE);
            return this;
        }
        public CoursesPage ClickCourses(string coursename)
        {
            Click(By.XPath("//div[@ng-bind='course.name'][contains(text(), '" + coursename + "')]"));
            return this;
        }
        public CoursesPage ClickFiles()
        {
            Click(BUTTON_COURSES_FILES);
            return this;
        }
        public CoursesPage ClickAddCategory()
        {
            Click(BUTTON_COURSE_ADD_CATEGORY);
            return this;
        }
        public CoursesPage EnterCategoryName(string categoryName)
        {
            Type(INPUT_CATEGORY_NAME, categoryName);
                return this;
        }
        public CoursesPage ClickAddCategoryConfirm()
        {
            Click(BUTTON_COURSE_ADD_CATEGORY_OK);
            return this;
        }
        public CoursesPage ChooseCategory(string addedCategoryName)
        {
            Click(By.XPath("//a[contains(text(), '" + addedCategoryName + "')]"));
            return this;
        }
        public CoursesPage ClickAddItemToCategoryButton()
        {
            Click(BUTTON_COURSE_ADD_ITEM);
            return this;
        }
        public CoursesPage ChooseItemDocumentToCategory()
        {
            Click(BUTTON_CATEGORY_CHOOSE_DOCUMENT);
            return this;
        }
        public CoursesPage ChooseItemVideoToCategory()
        {
            Click(BUTTON_CATEGORY_CHOOSE_VIDEO);
            return this;
        }
        public CoursesPage ChooseItemLinkToCategory()
        {
            Click(BUTTON_CATEGORY_CHOOSE_LINK);
            return this;
        }
        public CoursesPage ChooseItemTextToCategory()
        {
            Click(BUTTON_CATEGORY_CHOOSE_TEXT);
            return this;
        }
        public CoursesPage ChooseItemTestToCategory()
        {
            Click(BUTTON_CATEGORY_CHOOSE_TEST);
            return this;
        }
        public CoursesPage ChooseItemCodeToCategory()
        {
            Click(BUTTON_CATEGORY_CHOOSE_CODE);
            return this;
        }
        public CoursesPage ClickCategoryFileTypeOk()
        {
            Click(BUTTON_CATEGORY_CHOOSE_OK);
            return this;
        }
        public CoursesPage EnterCategoryTitle(string categoryTitle)
        {
            Type(INPUT_CATEGORY_DOCUMENT_TITLE, categoryTitle);
            return this;
        }
        public CoursesPage EnterCategoryDescription(string categoryDescription)
        {
            Type(TEXTAREA_CATEGORY_DOCUMENT_DESC, categoryDescription);
            return this;
        }
        public CoursesPage ClickCategoryDocumentSave()
        {
            Click(BUTTON_ADD_DOCUMENT_TYPE_SAVE);
            return this;
        }
        public CoursesPage SelectFileDocument()
        {
            Type(
                INPUT_SELECT_FILE_TO_CATEGORY,
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Docs\\file.png"))
            );
            return this;
        }
        public CoursesPage SelectFileVideo()
        {
            Type(
                INPUT_SELECT_FILE_TO_CATEGORY,
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Docs\\video.mp4"))
            );
            return this;
        }
        public CoursesPage EnterCategoryLink(string link)
        {
            Type(INPUT_CATEGORY_LINK, link);
            return this;
        }
        public CoursesPage EnterCategoryEmbed(string embed_code)
        {
            Type(TEXTAREA_CATEGORY_CODE, embed_code);
            return this;
        }
        public CoursesPage ClickCategoryUpdate()
        {
            Click(BUTTON_CATEGORY_UPDATE);
            return this;
        }
        public CoursesPage ClickHomework()
        {
            Click(BUTTON_CATEGORY_HOMEWORK);
            return this;
        }
        public CoursesPage ClickProfile()
        {
            Click(BUTTON_CATEGORY_PROFILE);
            return this;
        }
        public CoursesPage ClickContents()
        {
            Click(BUTTON_CATEGORY_CONTENTS);
            return this;
        }
        public CoursesPage ClickAnnouncements()
        {
            Click(BUTTON_CATEGORY_ANNOUNCEMENTS);
            return this;
        }
        public CoursesPage ClickPolls()
        {
            Click(BUTTON_CATEGORY_POLLS);
            return this;
        }
        public CoursesPage ClickAddPolls()
        {
            Click(BUTTON_CATEGORY_ADD_POLLS);
            return this;
        }
        public CoursesPage EnterPollsTitle(string polls_title)
        {
            Type(INPUT_POLLS_TITLE, polls_title);
            return this;
        }
        public CoursesPage EnterPollsDescription(string polls_description)
        {
            Type(INPUT_POLLS_DESCRIPTION, polls_description);
            return this;
        }
        public CoursesPage EnterPollsTestRepeatNumber(int polls_test_repeat_number)
        {
            Type(INPUT_POLLS_TEST_REPEAT_NUMBER, polls_test_repeat_number);
            return this;
        }
        public CoursesPage SetPollsStartDate(int yearParam = 0, string monthParam = null, string dayParam = null)
        {
            int year = yearParam == 0 ? Utils.Dates.GetCurrentYear() : yearParam;
            string month = monthParam == null ? Utils.Dates.GetCurrentMonth() : monthParam;
            string day = dayParam == null ? Utils.Dates.GetCurrentDay() : dayParam;

            string getCurrentValueOfInput = GetAttribute(INPUT_POLLS_START_DATE_NEW_MODEL_SELECT_DATA, "value");
            string[] words = getCurrentValueOfInput.Split('/');
            int getCurrentValueOfInputYear = Int32.Parse(words[2]);
            int getCurrentValueOfInputMonth = Int32.Parse(words[1]);
            string getCurrentValueOfInputDay = words[0];

            try
            {
                Click(BUTTON_POLLS_START_DATE_OPEN_DATEPICKER);
                Console.WriteLine("clicked start date picker");
                Click(BUTTON_POLLS_START_DATE_CHOOSE_YEAR);
                Console.WriteLine("clicked start date choose year");
                if (year != getCurrentValueOfInputYear)
                {
                    if (year < getCurrentValueOfInputYear)
                    {
                        for (int i = getCurrentValueOfInputYear; i > year; i--)
                        {
                            Click(BUTTON_POLLS_START_DATE_GO_PREVIOUS_YEAR);
                        }
                    }
                    else
                    {
                        for (int i = getCurrentValueOfInputYear; i < year; i++)
                        {
                            Click(BUTTON_POLLS_START_DATE_GO_NEXT_YEAR);
                        }
                    }
                }
                Click(By.XPath("//span[contains(text(),'" + month + "')]"));
                Click(By.XPath("(//span[@class='ng-binding' and contains(text(),'" + day + "')])[2]"));
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Element not found:" + e);
            }
            Sleepms(500);
            return this;
        }
        public CoursesPage SetPollsEndDate(int yearParam = 0, string monthParam = null, string dayParam = null)
        {
            int year = yearParam == 0 ? Utils.Dates.GetCurrentYear() : yearParam;
            string month = monthParam == null ? Utils.Dates.GetCurrentMonth() : monthParam;
            string day = dayParam == null ? Utils.Dates.GetCurrentDay() : dayParam;

            string getCurrentValueOfInput = GetAttribute(INPUT_POLLS_END_DATE_NEW_MODEL_SELECT_DATA, "value");
            string[] words = getCurrentValueOfInput.Split('/');
            int getCurrentValueOfInputYear = Int32.Parse(words[2]);
            int getCurrentValueOfInputMonth = Int32.Parse(words[1]);
            string getCurrentValueOfInputDay = words[0];

            try
            {
                Click(BUTTON_POLLS_END_DATE_OPEN_DATEPICKER);
                Console.WriteLine("clicked end date picker");
                Click(BUTTON_POLLS_END_DATE_CHOOSE_YEAR);
                Console.WriteLine("clicked start date choose year");
                if (year != getCurrentValueOfInputYear)
                {
                    if (year < getCurrentValueOfInputYear)
                    {
                        for (int i = getCurrentValueOfInputYear; i > year; i--)
                        {
                            Click(BUTTON_POLLS_END_DATE_GO_PREVIOUS_YEAR);
                        }
                    }
                    else
                    {
                        for (int i = getCurrentValueOfInputYear; i < year; i++)
                        {
                            Click(BUTTON_POLLS_END_DATE_GO_NEXT_YEAR);
                            Console.WriteLine("clicked end date go to next year " + i + " times");
                        }
                    }
                }
                Click(By.XPath("//span[contains(text(),'" + month + "')]"));
              
                Click(By.XPath("(//span[@class='ng-binding' and contains(text(),'" + day + "')])[3]"));  
            }
            catch (Exception e)
            {
                Console.WriteLine("Element not found:" + e);
            }
            Sleepms(500);
            return this;
        }

        public CoursesPage ClickPollsNext()
        {
            Click(BUTTON_POLLS_NEXT);
            return this;
        }
        public CoursesPage AddPolls()
        {
            Click(POLL_1);
            Click(POLL_2);

            return this;
        }
        public CoursesPage ClickPollsSave()
        {
            Click(BUTTON_POLLS_SAVE);
            return this;
        }
        public CoursesPage ClickAddHomework()
        {
            Click(BUTTON_CATEGORY_ADD_HOMEWORK);
            return this;
        }
        public CoursesPage EnterHomeworkTitle(string homework_title)
        {
            Type(INPUT_HOMEWORK_TITLE, homework_title);
            return this;
        }
        public CoursesPage EnterHomeworkDescription(string homework_description)
        {
            Type(INPUT_HOMEWORK_DESC, homework_description);
            return this;
        }
        public CoursesPage EnterHomeworkPassPoint(int pass_point)
        {
            Type(INPUT_HOMEWORK_PASS_POINT, pass_point);
            return this;
        }
        public CoursesPage EnterHomeworkWeightPercentage(int weight_percentage)
        {
            Type(INPUT_HOMEWORK_WEIGHT_PERCENTAGE, weight_percentage);
            return this;
        }
        public CoursesPage ClickHomeworkSave()
        {
            Click(BUTTON_HOMEWORK_SAVE);
            return this;
        }
        public CoursesPage ClickHomeworkAddItem()
        {
            Click(BUTTON_HOMEWORK_ADD_ITEM);
            return this;
        }
        public CoursesPage SelectDocumentType()
        {
            Click(BUTTON_HOMEWORK_SELECT);
            return this;
        }
        public CoursesPage EnterHomeworkDocTitle(string homework_doc_title)
        {
            Type(INPUT_HOMEWORK_DOC_TITLE, homework_doc_title);
            return this;
        }
        public CoursesPage EnterHomeworkDocDescription(string homework_doc_description)
        {
            Type(INPUT_HOMEWORK_DOC_DESC, homework_doc_description);
            return this;
        }
        public CoursesPage SelectHomeworkFileDocument()
        {
            Type(
                INPUT_HOMEWORK_DOC_SELECT,
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Docs\\file.png")));
            return this;
        }
        public CoursesPage SelectHomeworkFileVideo()
        {
            Type(
                INPUT_HOMEWORK_DOC_SELECT,
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Docs\\video.mp4"))
            );
            return this;
        }
        public CoursesPage EnterHomeworkLink(string link)
        {
            Type(INPUT_HOMEWORK_LINK, link);
            return this;
        }
        public CoursesPage EnterHomeworkEmbed(string embed_code)
        {
            Type(INPUT_HOMEWORK_EMBED, embed_code);
            return this;
        }
        public CoursesPage EnterHomeworkTestTitle(string homework_test_title)
        {
            Type(INPUT_HOMEWORK_TEST_TITLE, homework_test_title);
            return this;
        }
        public CoursesPage EnterHomeworkTestDescription(string homework_test_description)
        {
            Type(INPUT_HOMEWORK_TEST_DESC, homework_test_description);
            return this;
        }
        public CoursesPage EnterHomeworkTestPassPoint(int homework_test_pass_point)
        {
            Type(INPUT_HOMEWORK_TEST_PASS_POINT, homework_test_pass_point);
            return this;
        }
        public CoursesPage EnterHomeworkTestRepeatNumber(int homework_test_repeat_number)
        {
            Type(INPUT_HOMEWORK_TEST_REPEAT_NUMBER, homework_test_repeat_number);
            return this;
        }
        public CoursesPage SelectHomeworkTestType()
        {
            Click(SELECT_HOMEWORK_TEST);
            return this;
        }
        public CoursesPage SetHomeworkStartDate(int yearParam = 0, string monthParam = null, string dayParam = null)
        {
            int year = yearParam == 0 ? Utils.Dates.GetCurrentYear() : yearParam;
            string month = monthParam == null ? Utils.Dates.GetCurrentMonth() : monthParam;
            string day = dayParam == null ? Utils.Dates.GetCurrentDay() : dayParam;

            string getCurrentValueOfInput = GetAttribute(INPUT_HOMEWORK_START_DATE_NEW_MODEL_SELECT_DATA, "value");
            string[] words = getCurrentValueOfInput.Split('/');
            int getCurrentValueOfInputYear = Int32.Parse(words[2]);
            int getCurrentValueOfInputMonth = Int32.Parse(words[1]);
            string getCurrentValueOfInputDay = words[0];

            try
            {
                Click(BUTTON_START_DATE_OPEN_DATEPICKER);
                Console.WriteLine("clicked start date picker");
                Click(BUTTON_START_DATE_CHOOSE_YEAR);
                Console.WriteLine("clicked start date choose year");
                if (year != getCurrentValueOfInputYear)
                {
                    if (year < getCurrentValueOfInputYear)
                    {
                        for (int i = getCurrentValueOfInputYear; i > year; i--)
                        {
                            Click(BUTTON_START_DATE_GO_PREVIOUS_YEAR);
                        }
                    }
                    else
                    {
                        for (int i = getCurrentValueOfInputYear; i < year; i++)
                        {
                            Click(BUTTON_START_DATE_GO_NEXT_YEAR);
                        }
                    }
                }
                Click(By.XPath("//span[contains(text(),'" + month + "')]"));
                Click(By.XPath("(//span[@class='ng-binding' and contains(text(),'" + day + "')])[1]"));
                Click(START_DATE_DONE);
            }
            catch (Exception e)
            {
                Console.WriteLine("Element not found:" + e);
            }
            Sleepms(500);
            return this;
        }
        public CoursesPage SetHomeworkEndDate(int yearParam = 0, string monthParam = null, string dayParam = null)
        {
            int year = yearParam == 0 ? Utils.Dates.GetCurrentYear() : yearParam;
            string month = monthParam == null ? Utils.Dates.GetCurrentMonth() : monthParam;
            string day = dayParam == null ? Utils.Dates.GetCurrentDay() : dayParam;

            string getCurrentValueOfInput = GetAttribute(INPUT_HOMEWORK_END_DATE_NEW_MODEL_SELECT_DATA, "value");
            string[] words = getCurrentValueOfInput.Split('/');
            int getCurrentValueOfInputYear = Int32.Parse(words[2]);
            int getCurrentValueOfInputMonth = Int32.Parse(words[1]);
            string getCurrentValueOfInputDay = words[0];

            try
            {
                Click(BUTTON_END_DATE_OPEN_DATEPICKER);
                Console.WriteLine("clicked end date picker");
                Click(BUTTON_END_DATE_CHOOSE_YEAR);
                Console.WriteLine("clicked start date choose year");
                if (year != getCurrentValueOfInputYear)
                {
                    if (year < getCurrentValueOfInputYear)
                    {
                        for (int i = getCurrentValueOfInputYear; i > year; i--)
                        {
                            Click(BUTTON_END_DATE_GO_PREVIOUS_YEAR);
                        }
                    }
                    else
                    {
                        for (int i = getCurrentValueOfInputYear; i < year; i++)
                        {
                            Click(BUTTON_END_DATE_GO_NEXT_YEAR);
                            Console.WriteLine("clicked end date go to next year " + i + " times");
                        }
                    }
                }
                Click(By.XPath("//span[contains(text(),'" + month + "')]"));
                Console.WriteLine("clicked end date month " + month + " successfully");
                Click(By.XPath("(//span[@class='ng-binding' and contains(text(),'" + day + "')])[2]"));

                Console.WriteLine("clicked END date day " + day + " successfully");
                Click(END_DATE_DONE);
            }
            catch (Exception e)
            {
                Console.WriteLine("Element not found:" + e);
            }
            Sleepms(500);
            return this;
        }
        public CoursesPage ClickAddAnnouncement() {
            Click(By.CssSelector("button[ng-click='addEditAnnouncement(0)']"));
            return this;
        }
        public CoursesPage EnterAnnouncementTitle(string text){
            Type(By.CssSelector("input[ng-model='announcement.title']"), text);
            return this;
        }
        public CoursesPage EnterAnnouncementDescription(string text){
            Type(By.XPath("/html/body/div[6]/div/div/div/div[2]/form/div[1]/div[2]/div/text-angular/div[2]/div[3]"), text);
            return this;
        }
        public CoursesPage ClickAnnouncementSave() {
            Click(By.XPath("//*[@id='announcementForm']/div[2]/button[1]"));
            return this;
        }
    }
}