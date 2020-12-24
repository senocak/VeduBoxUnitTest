using OpenQA.Selenium;
using System;
using System.IO;
using System.Text;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class CoursesPage : Page{
        private static By ADD_NEW_ADMIN = By.CssSelector("button[ui-sref='veduBox.admin.courses.new']");
        private static By ADD_NEW_INSTRUCTOR = By.CssSelector("button[ng-show='$root.app.isTeacherAddCourseAndPackageEnabled']");
        private static By NAME_ADMIN = By.CssSelector("input[ng-model='course.name']");
        private static By NAME_INSTRUCTOR = By.CssSelector("input[ng-model='courseAndPackage.courseName']");
        private static By TAGS = By.XPath("//*[@id='courseForm']/div[1]/div[2]/div/div/input");
        private static By DESCRIPTION = By.XPath("/html/body/div[6]/div/div/div/div[3]/div/div/div/div/form/div[1]/div[2]/div/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private static By CREATE_COURSE_DESCRIPTION = By.XPath("/html/body/div[3]/div/section/div/div[1]/div[3]/div/div/div[2]/form/div[1]/div[3]/div/text-angular/div[2]/div[3]");
        private static By EMBEDDED_DESCRIPTION = By.XPath(" /html/body/div[6]/div/div/div/div[3]/div/div/div/div/form/div[1]/div[1]/div[2]/div/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private static By CATEGORY_ADMIN = By.CssSelector("select[ng-model='course.categoryId']");
        private static By CATEGORY_INSTRUCTOR = By.CssSelector("select[ng-model='courseAndPackage.categoryId']");
        private static By TEACHER = By.CssSelector("select[ng-model='course.teacherUserId']");
        private static By CATALOG= By.CssSelector("select[ng-model='course.teacherUserId']");
        private static By SUBMIT_ADMIN = By.CssSelector("button[type='submit']:nth-child(1)");
        private static By SUBMIT_INSTRUCTOR = By.CssSelector("button[ng-disabled='courseAndPackageForm.$invalid']");
        private static By SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private static By SEARCH_BOX = By.CssSelector("input.form-control.vedu-search");
        private static By THREE_POINTS = By.CssSelector("button.btn.btn-link.dropdown-toggle");
        private static By DELETE_COURSE = By.CssSelector("button[ng-click='delete(course)']");
        private static By ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private static By LINK_PROJET_MANAGEMENT = By.XPath("//*[contains(text(),'project management')]");
        private static By COURSE_UPDATE_BUTTON = By.CssSelector("button[ui-sref='veduBox.teacher.me.courses.edit({id: course.courseId})']");
        private static By DELETE_COURSE_INSTRUCTOR = By.CssSelector("button[ng-click='deleteCourse(course.courseId)']");
        private static By ADD_SUBJECT_BUTTON = By.CssSelector("a[ng-click='saveSubject(0)']");
        private static By SUBJECT_INPUT = By.CssSelector("input[ng-model='title']");
        private static By FINISH_EDITING_BUTTON = By.CssSelector("button[ui-sref='veduBox.teacher.me.courses.view({id: course.courseId})']");
        private static By SAVE_SUBJECT_BUTTON = By.XPath("/html/body/div[6]/div/div/div/div[3]/button[1]");
        private static By ADD_RESOURCE = By.Id("teacherCourseEditAddResource");
        private static By SELECT_RESOURCE_DOC = By.Id("rescourceTypeDoc");
        private static By RESOURCE_OK = By.Id("rescourceTypeOkBtn");
        private static By RESOURCE_TITLE = By.Id("txtName");
        private static By RESOURCE_DESC = By.XPath("/html/body/div[6]/div/div/div/div[3]/div/div/div/div/form/div[1]/div[1]/div[2]/div/vedu-box-text-angular/text-angular/div[2]/div[3]");
        private static By RESOURCE_DOWNLOADABLE_CHECK = By.Id("resourceTypeDocDownload");
        private static By RESOURCE_REVIEW_CHECK = By.Id("resourceTypeDocReview");
        private static By RESOURCE_SAVE_BUTTON = By.Id("resourceTypeDocFileSave");
        private static By SELECT_RESOURCE_VIDEO = By.Id("rescourceTypeVideo");
        private static By SELECT_RESOURCE_LINK = By.Id("rescourceTypeLink");
        private static By INPUT_RESOURCE_LINK = By.CssSelector("input[ng-model='resource.url']");
        private static By BUTTON_RESOURCE_LINK_SAVE = By.XPath("//*[@id='resourceForm']/div[2]/div/div/button[1]");
        private static By SELECT_RESOURCE_EMBED_CODE = By.Id("rescourceTypeEmbedCode");
        private static By INPUT_RESOURCE_EMBED_CODE = By.CssSelector("textarea[ng-model='resource.code']");

        private static By RESOURCE_TYPE_DOC_FILE= By.Id("resourceTypeDocFile");
        private static By RESOURCE_TYPE_DOC_VIDEO1 = By.Id("fileVideo");
        private static By RESOURCE_TYPE_DOC_VIDEO2 = By.Id("fileTwo");
        private static By RESOURCE_VIDEO_PREVIEW = By.CssSelector("input[ng-model='resource.preview']");
        private static By RESOURCE_VIDEO_DOWNLOADABLE_CHECK = By.CssSelector("input[ng-model='resource.downloadable']");
        private static By RESOURCE_VIDEO_FORWARD = By.CssSelector("input[ng-model='resource.forwardRewindEnabled']");
        private static By RESOURCE_VIDEO_USER_REVIEW = By.CssSelector("input[ng-model='resource.userReviewEnabled']");
        private static By RESOURCE_VIDEO_SUBMIT = By.Id("resourceTypeVideoFileSave");
        private static By RESOURCE_VIDEO_EXISTING_SUBMIT = By.Id("resourceTypeVideoFileSaveExisting");
        private static By RESOURCE_VIDEO_VIMEO_CHECKBOX = By.CssSelector("input[ng-model='resource.vimeoIdEnabled']");
        private static By RESOURCE_VIDEO_VIMEO_TEXT = By.CssSelector("input[ng-model='resource.vimeoId']");

        private static string _user;
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
        public CoursesPage setEmbeddedDescription(string description)
        {
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
                click(THREE_POINTS);
                click(DELETE_COURSE);
            }else if (_user == "instructor"){
                click(DELETE_COURSE_INSTRUCTOR);
            }
            click(ARE_U_SURE_OK);
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
            click(ADD_RESOURCE);
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
        public CoursesPage selectUserReviewEnable(){
            click(RESOURCE_REVIEW_CHECK);
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
            click(RESOURCE_SAVE_BUTTON);
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
    }
}
