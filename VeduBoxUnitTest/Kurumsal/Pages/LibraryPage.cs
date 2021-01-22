using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages{
    class LibraryPage : Page{
        private readonly By ADD_CATEGORY = By.CssSelector("span[translate='routeStates.teacher.library.lblAddRootLibrary']");
        private readonly By CATALOG_NAME = By.CssSelector("input[ng-model='library.name']");
        private readonly By IS_EDITABLE = By.CssSelector("[ng-model='library.isEditable']");
        private readonly By ADD = By.CssSelector("span[ng-bind*='common.add']");
        private readonly By SUCCESS = By.CssSelector("[class='toast ng-scope toast-success']");
        private readonly By SEARCH_BOX = By.CssSelector("input[ng-change='queryForLibraries()']");
        private readonly By CHOOSE_CATALOG = By.CssSelector("a.jstree-anchor");
        private readonly By DELETE = By.CssSelector("span[translate='common.delete']");
        private readonly By ARE_U_SURE_OK = By.CssSelector("button.msc-ok");
        private readonly By MY_FOLDERS = By.XPath("//*[@id='mainSection']/div/div/div[2]/div/div[1]/div[1]/label[1]");
        private readonly By ADD_ITEM = By.CssSelector("button[ng-click='addItem(subject.id)']");
        private readonly By DOCUMENT = By.CssSelector("span[ng-click='resourceTypeId = 1']");
        private readonly By LINK = By.CssSelector("span[ng-click='resourceTypeId = 3']");
        private readonly By EMBED_CODE = By.CssSelector("span[ng-click='resourceTypeId = 4']");
        private readonly By SOUND = By.CssSelector("span[ng-click='resourceTypeId = 10']");
        private readonly By CONTENT_OK = By.CssSelector("span[translate='common.ok']");
        private readonly By TITLE = By.CssSelector("input[ng-model='libraryItem.title']");
        private readonly By URL = By.CssSelector("input[ng-model='libraryItem.url']");
        private readonly By CODE = By.CssSelector("textarea[ng-model='libraryItem.code']");
        private readonly By DESCRIPTION = By.Id("txtDescription");
        private readonly By RESOURCE_TYPE_DOC_FILE = By.CssSelector("input[ng-model='libraryItem.file']");
        private readonly By IS_DOWNLOADABLE = By.CssSelector("input[ng-model='libraryItem.downloadable']");
        private readonly By SAVE_BUTTON = By.XPath("(//button[@ng-click='save()'])[1]");
        private readonly By AUDIO_SAVE_BUTTON = By.XPath("(//button[@ng-click='save(libraryItem)'])[1]");
        private string USER;
        
        public LibraryPage(IWebDriver wd, string user) : base(wd){
            USER = user;
        }
        public LibraryPage ClickAddCategory(){
            Click(ADD_CATEGORY);
            return this;
        }
        public LibraryPage EnterCatalogName(String catalogName){
            Type(CATALOG_NAME, catalogName);
            return this;
        }
        public LibraryPage DeselectIsEditable(){
            if (IsSelected(IS_EDITABLE) == true)
                Click(IS_EDITABLE);
            return this;
        }
        public LibraryPage ClickAdd(){
            Click(ADD);
            return this;
        }
        public LibraryPage Assert(){
            AssertionCustom.AssertElementVisible("Element Not Found", Driver, SUCCESS);
            return this;
        }
        public LibraryPage SearchNewlyAddedCatalog(string name){
            Type(SEARCH_BOX, name);
            Sleepms(1000);
            return this;
        }
        public LibraryPage ClickCatalog(){
            Click(CHOOSE_CATALOG);
            return this;
        }
        public LibraryPage DeleteCatalog(){
            Click(DELETE);
            return this;
        }
        public LibraryPage ClickMyFolders(){
            Click(MY_FOLDERS);
            return this;
        }
        public LibraryPage ClickAddItem(){
            Click(ADD_ITEM);
            return this;
        }
        public LibraryPage ClickDocument(){
            Click(DOCUMENT);
            return this;
        }
        public LibraryPage ClickLink(){
            Click(LINK);
            return this;
        }
        public LibraryPage ClickEmbedCode(){
            Click(EMBED_CODE);
            return this;
        }
        public LibraryPage ClickSound(){
            Click(SOUND);
            return this;
        }
        public LibraryPage ClickContentOk(){
            Click(CONTENT_OK);
            return this;
        }
        public LibraryPage EnterTitle(String title){
            Type(TITLE, title);
            return this;
        }
        public LibraryPage EnterDescription(String description){
            Type(DESCRIPTION, description);
            return this;
        }
        public LibraryPage EnterUrl(String url){
            Type(URL, url);
            return this;
        }
        public LibraryPage EnterCode(String code){
            Type(CODE, code);
            return this;
        }
        public LibraryPage SelectIsDownloadable(){
            if (IsSelected(IS_DOWNLOADABLE) == false)
                Click(IS_DOWNLOADABLE);
            return this;
        }
        public LibraryPage ClickSaveButton(){
            Click(SAVE_BUTTON);
            return this;
        }
        public LibraryPage ClickAudioSaveButton(){
            Click(AUDIO_SAVE_BUTTON);
            return this;
        }
        public LibraryPage ClickAreUSure(){
            Click(ARE_U_SURE_OK);
            return this;
        }
        public LibraryPage SearchNewlyAddedCatalogAndDeleteIt(string name){
            SearchNewlyAddedCatalog(name);
            try{
                ClickCatalog();
            }catch (Exception e){
                Console.WriteLine("Error:" + e.Message);
                return null;
            }
            DeleteCatalog();
            ClickAreUSure();
            Assert();
            return this;
        }
        public LibraryPage SelectFile(){
            Type(
                RESOURCE_TYPE_DOC_FILE,
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Docs\\file.png"))
            );
            return this;
        }
        public LibraryPage SelectSound(){
            Type(
                RESOURCE_TYPE_DOC_FILE,
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Docs\\audio.mp3"))
            );
            return this;
        }
    }
}