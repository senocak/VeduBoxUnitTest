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
        private readonly By DIV_DESCRIPTION = By.XPath("/html/body/div[6]/div/div/div/div[4]/div/div/div/div/form/div[1]/div[2]/div/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private readonly By DIV_CREATE_COURSE_DESCRIPTION = By.XPath("/html/body/div[3]/div/section/div/div[1]/div[3]/div/div/div[2]/form/div[1]/div[3]/div/text-angular/div[2]/div[3]");
        private readonly By DIV_EMBEDDED_DESCRIPTION = By.XPath("/html/body/div[6]/div/div/div/div[4]/div/div/div/div/form/div[1]/div[1]/div[2]/div/vedu-box-text-angular/text-angular/div[2]/div[3]");
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
        private readonly By DIV_RESOURCE_DESC = By.XPath("/html/body/div[6]/div/div/div/div[4]/div/div/div/div/form/div[1]/div[1]/div[2]/div/vedu-box-text-angular/text-angular/div[2]/div[3]");
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
        private readonly By BUTTON_RESOURCE_VIDEO_UPLOAD_BUTTON = By.XPath("//*[@id='resourceForm']/div[1]/div[5]/div/button");
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
        private readonly By SELECT_RESOURCE_TEXT = By.Id("rescourceTypeText");
        private readonly By DIV_RESOURCE_TEXT_DESCRIPTION= By.XPath("/html/body/div[6]/div/div/div/div[4]/div/div/div/div/form/div[1]/div[2]/div/text-angular/div[2]/div[3]");
        private readonly By BUTTON_RESOURCE_TEXT_SAVE = By.XPath("/html/body/div[6]/div/div/div/div[4]/div/div/div/div/form/div[2]/div/div/button[1]");
        private readonly string UPLOADED_FILE_TEXT = "video.mp4";

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
        public CoursesPage ClickResourceTypeEmbedCode(){
            Click(SELECT_RESOURCE_EMBED_CODE);
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
        public CoursesPage ClickResourceTypeTest(){
            Click(SELECT_RESOURCE_TEST);
            return this;
        }
        public CoursesPage ClickResourceTypeText(){
            Click(SELECT_RESOURCE_TEXT);
            return this;
        }
        public CoursesPage SetDescriptionForText(string description){
            Type(DIV_RESOURCE_TEXT_DESCRIPTION, description);
            return this;
        }
        public CoursesPage ClickSaveButtonForText(){
            Click(BUTTON_RESOURCE_TEXT_SAVE);
            return this;
        }
    }
}