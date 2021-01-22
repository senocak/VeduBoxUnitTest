using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using VeduBoxUnitTest.Assertion;

namespace VeduBoxUnitTest.Kurumsal.Pages
{
    class LibraryPage : Page
    {
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

        private static string _user;
        public LibraryPage(IWebDriver wd, string user) : base(wd)
        {
            _user = user;
        }

        public LibraryPage ClickAddCategory()
        {
            click(ADD_CATEGORY);
            return this;
        }
        public LibraryPage EnterCatalogName(String catalogName)
        {
            type(CATALOG_NAME, catalogName);
            return this;
        }
        public LibraryPage DeselectIsEditable()
        {
            if (isSelected(IS_EDITABLE) == true)
                click(IS_EDITABLE);
            return this;
        }
        public LibraryPage ClickAdd()
        {
            click(ADD);
            return this;
        }
        public LibraryPage Assert()
        {
            AssertionCustom.assertElementVisible("Element Not Found", driver, SUCCESS);
            return this;
        }
      
        public LibraryPage SearchNewlyAddedCatalog(string name)
        {
            type(SEARCH_BOX, name);
            sleepms(1000);
            return this;
        }
        public LibraryPage ClickCatalog()
        {
            click(CHOOSE_CATALOG);
            return this;
        }
      
        public LibraryPage DeleteCatalog()
        {
            click(DELETE);
            return this;
        }
        public LibraryPage ClickMyFolders()
        {
            click(MY_FOLDERS);
            return this;
        }
        public LibraryPage ClickAddItem()
        {
            click(ADD_ITEM);
            return this;
        }
        public LibraryPage ClickDocument()
        {
            click(DOCUMENT);
            return this;
        }
        public LibraryPage ClickLink()
        {
            click(LINK);
            return this;
        }
        public LibraryPage ClickEmbedCode()
        {
            click(EMBED_CODE);
            return this;
        }
        public LibraryPage ClickSound()
        {
            click(SOUND);
            return this;
        }
        public LibraryPage ClickContentOK()
        {
            click(CONTENT_OK);
            return this;
        }
        public LibraryPage EnterTitle(String title)
        {
            type(TITLE, title);
            return this;
        }
        public LibraryPage EnterDescription(String description)
        {
            type(DESCRIPTION, description);
            return this;
        }
        public LibraryPage EnterURL(String url)
        {
            type(URL, url);
            return this;
        }
        public LibraryPage EnterCode(String code)
        {
            type(CODE, code);
            return this;
        }
        public LibraryPage SelectIsDownloadable()
        {
            if (isSelected(IS_DOWNLOADABLE) == false)
                click(IS_DOWNLOADABLE);
            return this;
        }
        public LibraryPage ClickSaveButton()
        {
            click(SAVE_BUTTON);
            return this;
        }
        public LibraryPage ClickAudioSaveButton()
        {
            click(AUDIO_SAVE_BUTTON);
            return this;
        }
        public LibraryPage ClickAreUSure()
        {
            click(ARE_U_SURE_OK);
            return this;
        }
        public LibraryPage SearchNewlyAddedCatalogAndDeleteIt(string name)
        {
            SearchNewlyAddedCatalog(name);
            try
            {
                ClickCatalog();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e.Message);
                return null;
            }
            DeleteCatalog();
            ClickAreUSure();
            Assert();
            return this;
        }
        public LibraryPage SelectFile()
        {
            
            type(
                RESOURCE_TYPE_DOC_FILE,
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Docs\\file.png"))
            );
            return this;
        }
        public LibraryPage SelectSound()
        {

            type(
                RESOURCE_TYPE_DOC_FILE,
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Docs\\audio.mp3"))
            );
            return this;
        }
    }
}
