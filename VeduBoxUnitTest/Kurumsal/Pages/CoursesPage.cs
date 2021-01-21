using OpenQA.Selenium;
using System;
using System.IO;
using System.Text;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class CoursesPage : Page{
        private readonly By ADD_NEW_ADMIN = By.CssSelector("button[ui-sref='veduBox.admin.courses.new']");
        private readonly By ADD_NEW_INSTRUCTOR = By.CssSelector("button[ng-show='$root.app.isTeacherAddCourseAndPackageEnabled']");
        private readonly By NAME_ADMIN = By.CssSelector("input[ng-model='course.name']");
        private readonly By NAME_INSTRUCTOR = By.CssSelector("input[ng-model='courseAndPackage.courseName']");
        private readonly By TAGS = By.XPath("//*[@id='courseForm']/div[1]/div[2]/div/div/input");
        private readonly By DESCRIPTION = By.XPath("/html/body/div[6]/div/div/div/div[4]/div/div/div/div/form/div[1]/div[2]/div/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private readonly By CREATE_COURSE_DESCRIPTION = By.XPath("/html/body/div[3]/div/section/div/div[1]/div[3]/div/div/div[2]/form/div[1]/div[3]/div/text-angular/div[2]/div[3]");
        private readonly By EMBEDDED_DESCRIPTION = By.XPath("/html/body/div[6]/div/div/div/div[4]/div/div/div/div/form/div[1]/div[1]/div[2]/div/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private readonly By CATEGORY_ADMIN = By.CssSelector("select[ng-model='course.categoryId']");
        private readonly By CATEGORY_INSTRUCTOR = By.CssSelector("select[ng-model='courseAndPackage.categoryId']");
        private readonly By TEACHER = By.CssSelector("select[ng-model='course.teacherUserId']");
        private readonly By CATALOG = By.CssSelector("select[ng-model='course.teacherUserId']");
        private readonly By SUBMIT_ADMIN = By.CssSelector("button[type='submit']:nth-child(1)");
        private readonly By SUBMIT_INSTRUCTOR = By.CssSelector("button[ng-disabled='courseAndPackageForm.$invalid']");
        private readonly By SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private readonly By SEARCH_BOX = By.CssSelector("input.form-control.vedu-search");
        private readonly By THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private readonly By DELETE_COURSE = By.CssSelector("button[ng-click='delete(course)']");
        private readonly By ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private readonly By LINK_PROJET_MANAGEMENT = By.XPath("//*[contains(text(),'project management')]");
        private readonly By COURSE_UPDATE_BUTTON = By.CssSelector("button[ui-sref='veduBox.teacher.me.courses.edit({id: course.courseId})']");
        private readonly By COURSE_RESOURCES_BUTTON = By.CssSelector("button[ui-sref='veduBox.admin.courses.courseEdit({id: course.courseId})']");



        


        private readonly By DELETE_COURSE_INSTRUCTOR = By.CssSelector("button[ng-click='deleteCourse(course.courseId)']");
        private readonly By ADD_SUBJECT_BUTTON = By.CssSelector("a[ng-click='saveSubject(0)']");
        private readonly By SUBJECT_INPUT = By.CssSelector("input[ng-model='title']");
        private readonly By FINISH_EDITING_BUTTON = By.CssSelector("button[ui-sref='veduBox.teacher.me.courses.view({id: course.courseId})']");
        private readonly By SAVE_SUBJECT_BUTTON = By.XPath("/html/body/div[6]/div/div/div/div[3]/button[1]");
        private readonly By ADD_RESOURCE_TEACHER = By.Id("teacherCourseEditAddResource");
        private readonly By ADD_RESOURCE_ADMIN = By.CssSelector("button[ng-click='addResource(subject.id)']");
       


        


        
        private readonly By SELECT_RESOURCE_DOC = By.Id("rescourceTypeDoc");
        private readonly By RESOURCE_OK = By.Id("rescourceTypeOkBtn");
        private readonly By RESOURCE_TITLE = By.Id("txtName");
        private readonly By RESOURCE_DESC = By.XPath("/html/body/div[6]/div/div/div/div[4]/div/div/div/div/form/div[1]/div[1]/div[2]/div/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private readonly By RESOURCE_DOWNLOADABLE_CHECK = By.Id("resourceTypeDocDownload");
        private readonly By RESOURCE_VIDEO_SPEED_CONTROL= By.CssSelector("input[ng-model='resource.videoSpeedControl']");


        private readonly By RESOURCE_DOC_REVIEW_CHECK = By.Id("resourceTypeDocReview");
        private readonly By RESOURCE_VIDEO_REVIEW_CHECK = By.Id("resourceTypeVideoReview");
        private readonly By RESOURCE_DOC_SAVE_BUTTON = By.Id("resourceTypeDocFileSave");
        private readonly By SELECT_RESOURCE_VIDEO = By.Id("rescourceTypeVideo");
        private readonly By SELECT_RESOURCE_LINK = By.Id("rescourceTypeLink");
        private readonly By INPUT_RESOURCE_LINK = By.CssSelector("input[ng-model='resource.url']");
        private readonly By BUTTON_RESOURCE_LINK_SAVE = By.XPath("//*[@id='resourceForm']/div[2]/div/div/button[1]");
        private readonly By SELECT_RESOURCE_EMBED_CODE = By.Id("rescourceTypeEmbedCode");
        private readonly By INPUT_RESOURCE_EMBED_CODE = By.CssSelector("textarea[ng-model='resource.code']");
        private readonly By RESOURCE_TYPE_DOC_FILE = By.Id("resourceTypeDocFile");
        private readonly By RESOURCE_TYPE_DOC_VIDEO1 = By.Id("fileVideo");
        private readonly By RESOURCE_VIDEO_UPLOAD_BUTTON = By.XPath("//*[@id='resourceForm']/div[1]/div[5]/div/button");
        private readonly By RESOURCE_TYPE_DOC_VIDEO2 = By.Id("fileTwo");
        private readonly By RESOURCE_VIDEO_PREVIEW = By.CssSelector("input[ng-model='resource.preview']");
        private readonly By RESOURCE_VIDEO_DOWNLOADABLE_CHECK = By.CssSelector("input[ng-model='resource.downloadable']");
        private readonly By RESOURCE_VIDEO_FORWARD = By.CssSelector("input[ng-model='resource.forwardRewindEnabled']");
        private readonly By RESOURCE_VIDEO_USER_REVIEW = By.CssSelector("input[ng-model='resource.userReviewEnabled']");
        private readonly By RESOURCE_VIDEO_SUBMIT = By.Id("resourceTypeVideoFileSave");
        private readonly By RESOURCE_VIDEO_EXISTING_SUBMIT = By.Id("resourceTypeVideoFileSaveExisting");
        private readonly By RESOURCE_VIDEO_VIMEO_CHECKBOX = By.CssSelector("input[ng-model='resource.vimeoIdEnabled']");
        private readonly By RESOURCE_VIDEO_VIMEO_TEXT = By.Id("resourceTypeVideoIfVimeoIdValue");
        private readonly By UPLOADED_FILE_LABEL = By.CssSelector("label[ng-bind='resource.fileName']");
        private readonly By SELECT_RESOURCE_TEST = By.Id("rescourceTypeTest");
        private readonly By SELECT_RESOURCE_TEXT = By.Id("rescourceTypeText");
        private readonly By RESOURCE_TEXT_DESCRIPTION= By.XPath("/html/body/div[6]/div/div/div/div[4]/div/div/div/div/form/div[1]/div[2]/div/text-angular/div[2]/div[3]");
        private readonly By RESOURCE_TEXT_SAVE_BUTTON = By.XPath("/html/body/div[6]/div/div/div/div[4]/div/div/div/div/form/div[2]/div/div/button[1]");
        

        private readonly string UPLOADED_FILE_TEXT = "video.mp4";

        private string _user;
        public CoursesPage(IWebDriver wd, string user) : base(wd){
            _user = user;
        }
        public CoursesPage addNew(){
            if(_user == "admin")
                click(ADD_NEW_ADMIN);
            else if(_user == "instructor")
                click(ADD_NEW_INSTRUCTOR);
            return this;
        }
        public CoursesPage setName(string name){
            if(_user == "admin")
                type(NAME_ADMIN, name);
            else if(_user == "instructor")
                type(NAME_INSTRUCTOR, name);
            return this;
        }
        public CoursesPage setTags(string tags){
            string[] names = tags.Split(',');
            foreach (var name in names){
                type(TAGS, name + ",");
            }
            return this;
        }
        public CoursesPage setDescription(string description){
            type(DESCRIPTION, description);
            return this;
        }
        public CoursesPage setCreateCourseDescription(string description)
        {
            type(CREATE_COURSE_DESCRIPTION, description);
            return this;
        }
        public CoursesPage setEmbeddedDescription(string description){
            type(EMBEDDED_DESCRIPTION, description);
            return this;
        }
       
        public CoursesPage selectCategory(string catetoryName){
            catetoryName = Encoding.UTF8.GetString(Encoding.Default.GetBytes(catetoryName));
            if (_user == "admin")
                selectDropDown(CATEGORY_ADMIN, catetoryName);
            else if (_user == "instructor")
                selectDropDown(CATEGORY_INSTRUCTOR, catetoryName);
            return this;
        }
        public CoursesPage selectTeacher(string teacherName){
            selectDropDown(TEACHER, teacherName);
            return this;
        }
        public CoursesPage setCatalog(string catalogNames){
            string[] names = catalogNames.Split(',');
            foreach (var name in names){
                click(By.XPath("//a[contains(text(), '" + name + "')]"));
            }
            return this;
        }
        public CoursesPage submit(){
            if (_user == "admin")
                click(SUBMIT_ADMIN);
            else if (_user == "instructor")
                click(SUBMIT_INSTRUCTOR);
            return this;
        }
        public CoursesPage assert(){
            AssertionCustom.assertElementVisible("Element Not Found", driver, SUCCESS);
            return this;
        }
        public CoursesPage searchNewlyAddedCouseByName(string tag){
            type(SEARCH_BOX, tag);
            sleepms(1000);
            return this;
        }
        public CoursesPage deleteAndAssertNewlyAddedCourseIfIsExist(){
            try{
                deleteNewlyAddedCourse();
                assert();
            }catch(Exception e){
                Console.WriteLine("Error while deleting course. Error is : " + e.Message);
            }
            return this;
        }
        public CoursesPage deleteNewlyAddedCourse(){
            if (_user == "admin"){
                click3Points();
                click(DELETE_COURSE);
            }else if (_user == "instructor"){
                click(DELETE_COURSE_INSTRUCTOR);
            }
            click(ARE_U_SURE_OK);
            return this;
        }
        public CoursesPage clickResources(){
            click(COURSE_RESOURCES_BUTTON);
            return this;
        }
        public CoursesPage click3Points(){
            click(THREE_POINTS);
            return this;
        }
        public CoursesPage openCourseDetail(string name){
            try {
                click(By.XPath("//div[contains(text(), '" + name + "')]"));
                Console.WriteLine("Clicked "+ name + " course in Courses Page");
            }catch (Exception e) {
                Console.WriteLine("Error occured during opening Course Detail. Error is : " + e);
            }
            return this;
        }
        public CoursesPage openCourseUpdate(){
            try{
                click(COURSE_UPDATE_BUTTON);
                Console.WriteLine("Clicked Update button in Courses Page");
            }
            catch (Exception e){
                Console.WriteLine("Error occured during opening Course Update. Error is : " + e);
            }
            return this;
        }
        public CoursesPage addSubject(){
            try{
                click(ADD_SUBJECT_BUTTON);
                Console.WriteLine("Clicked Add Subject button in Courses Detail Page");
            }catch (Exception e){
                Console.WriteLine("Error occured during clicking Add Subject. Error is : " + e);
            }
            return this;
        }
        public CoursesPage enterSubjectTitle(string title){
            try{
                type(SUBJECT_INPUT, title);
                Console.WriteLine("Subject title is typed");
            }catch (Exception e){
                Console.WriteLine("Error occured during entering Subject Title. Error is : " + e);
            }
            return this;
        }
        public CoursesPage assertSubjectIsVisible(string title){
            AssertionCustom.assertElementVisible(title + " text was not found", driver, By.XPath("(//*[contains(text(), '"+ title + "')])[1]"));
            return this;
        }
      
        public CoursesPage finishEditing(){
            try{
                click(FINISH_EDITING_BUTTON);
                Console.WriteLine("Clicked Finish Editing button in Courses Detail Page");
            }catch (Exception e){
                Console.WriteLine("Error occured during clicking Finish Editing button. Error is : " + e);
            }
            return this;
        }
        public CoursesPage saveSubjectTitle(){
            try{
                click(SAVE_SUBJECT_BUTTON);
                Console.WriteLine("Subject title is saved");
            }catch (Exception e){
                Console.WriteLine("Error occured during saving Subject Title. Error is : " + e);
            }
            return this;
        }
        public CoursesPage addResource(){
            if (_user == "instructor"){
                click(ADD_RESOURCE_TEACHER);
            }else if (_user == "admin"){
                click(ADD_RESOURCE_ADMIN);
            }
            return this;
        }
        public CoursesPage clickResourceTypeDoc(){
            click(SELECT_RESOURCE_DOC);
            return this;
        }
        public CoursesPage clickOkAfterType(){
            click(RESOURCE_OK);
            return this;
        }
        public CoursesPage enterResourceTitle(string title){
            type(RESOURCE_TITLE, title);
            return this;
        }
        public CoursesPage enterResourceDescription(string desc){
            type(RESOURCE_DESC, desc);
            return this;
        }
        public CoursesPage enterEmbedCode(string code){
            type(INPUT_RESOURCE_EMBED_CODE, code);
            return this;
        }
        public CoursesPage selectDownloadable(){
            click(RESOURCE_DOWNLOADABLE_CHECK);
            return this;
        }
        public CoursesPage selectUserReviewEnableForDOC(){
            click(RESOURCE_DOC_REVIEW_CHECK);
            return this;
        }
        public CoursesPage selectUserReviewEnableForVideo(){
            click(RESOURCE_VIDEO_REVIEW_CHECK);
            return this;
        }
        public CoursesPage selectFile(){
            /*
            IWebElement element = driver.FindElement(By.Id("resourceTypeDocFile"));
            element.SendKeys(
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Docs\\file.png"))
            );
            */
            type(
                RESOURCE_TYPE_DOC_FILE,
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Docs\\file.png"))
            );
            return this;
        }
        public CoursesPage clickSaveButton(){
            click(RESOURCE_DOC_SAVE_BUTTON);
            return this;
        }
        public CoursesPage clickResourceTypeVideo(){
            click(SELECT_RESOURCE_VIDEO);
            return this;
        }
        public CoursesPage clickResourceTypeLink(){
            click(SELECT_RESOURCE_LINK);
            return this;
        }
        public CoursesPage enterLink(string link){
            type(INPUT_RESOURCE_LINK, link);
            return this;
        }
        public CoursesPage clickResourceLinkSave(){
            click(BUTTON_RESOURCE_LINK_SAVE);
            return this;
        }
        public CoursesPage clickResourceTypeEmbedCode(){
            click(SELECT_RESOURCE_EMBED_CODE);
            return this;
        }
        public CoursesPage selectVideo1(){
            type(
                RESOURCE_TYPE_DOC_VIDEO1,
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Docs\\video.mp4"))
            );
            return this;
        }
        public CoursesPage clickUpload(){
            click(RESOURCE_VIDEO_UPLOAD_BUTTON);
            return this;
        }
        public CoursesPage selectVideo2(){
            type(
                RESOURCE_TYPE_DOC_VIDEO2,
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Docs\\video.mp4"))
            );
            return this;
        }
        public CoursesPage selectCourseVideoPrev(){
            if (isSelected(RESOURCE_VIDEO_PREVIEW) == false)
                click(RESOURCE_VIDEO_PREVIEW);
            return this;
        }
        public CoursesPage selectCourseVideoDownloadable(){
            if (isSelected(RESOURCE_VIDEO_DOWNLOADABLE_CHECK) == false)
                click(RESOURCE_VIDEO_DOWNLOADABLE_CHECK);
            return this;
        }
        public CoursesPage selectCourseVideoSpeedControl(){
            if (isSelected(RESOURCE_VIDEO_SPEED_CONTROL) == false)
                click(RESOURCE_VIDEO_SPEED_CONTROL);
            return this;
        }
        public CoursesPage selectVideoForward(){
            if (isSelected(RESOURCE_VIDEO_FORWARD) == false)
                click(RESOURCE_VIDEO_FORWARD);
            return this;
        }
        public CoursesPage selectVideoUserReview(){
            if (isSelected(RESOURCE_VIDEO_USER_REVIEW) == false)
                click(RESOURCE_VIDEO_USER_REVIEW);
            return this;
        }
        public CoursesPage waitUntillFileIsUploaded(){
            AssertionCustom.assertTextToBePresentInElementLocated(driver, UPLOADED_FILE_LABEL, UPLOADED_FILE_TEXT, "Element Not Found");
            return this;
        }
        public CoursesPage clickCourseVideoSubmit(){
            click(RESOURCE_VIDEO_SUBMIT);
            return this;
        }
        public CoursesPage clickCourseExistingVideoSubmit(){
            click(RESOURCE_VIDEO_EXISTING_SUBMIT);
            return this;
        }
        public CoursesPage selectVimeoID(){
            if (isSelected(RESOURCE_VIDEO_VIMEO_CHECKBOX) == false)
                click(RESOURCE_VIDEO_VIMEO_CHECKBOX);
            return this;
        }
        public CoursesPage enterVimeoID(string id){
            type(RESOURCE_VIDEO_VIMEO_TEXT, id);
            return this;
        }
        public CoursesPage clickResourceTypeTest(){
            click(SELECT_RESOURCE_TEST);
            return this;
        }
        public CoursesPage clickResourceTypeText(){
            click(SELECT_RESOURCE_TEXT);
            return this;
        }
        public CoursesPage setDescriptionForText(string description){
            type(RESOURCE_TEXT_DESCRIPTION, description);
            return this;
        }
        public CoursesPage clickSaveButtonForText(){
            click(RESOURCE_TEXT_SAVE_BUTTON);
            return this;
        }

    }
}
