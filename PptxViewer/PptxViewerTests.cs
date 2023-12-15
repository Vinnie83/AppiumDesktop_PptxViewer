using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Windows;

namespace PptxViewer
{
    public class PptxViewerTests
    {
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";
        private const string appIdentifier = "22450.PPTXViewer_0aqw1zw0x2snt!App";
        private WindowsDriver<WindowsElement> driver;
        private AppiumOptions options;
        
        [SetUp]
        public void Setup()
        {
            this.options = new AppiumOptions();
            options.AddAdditionalCapability("app", appIdentifier);
            this.driver = new WindowsDriver<WindowsElement>(new Uri(appiumServer),options);

        }

        [TearDown]
        public void TearDown() 
        
        {
           driver.Quit();
        }

        [Test]
        public void Test_OpenPptxFile()
        {
            Assert.Pass();
        }
    }
}