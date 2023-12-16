using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;

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
            var openFile = driver.FindElementByName("Open File..");
            openFile.Click();

            Thread.Sleep(3000); 

            var inputFileName = driver.FindElementByClassName("Edit");
            inputFileName.SendKeys("08.Security-Testing");

            Thread.Sleep(1000);

            var openButton = driver.FindElementByClassName("Button");
            openButton.Click();

            Thread.Sleep(10000);

            var allSlides = driver.FindElementsByAccessibilityId("ImagesGridView");

            foreach (var slide in allSlides)
            {
                string slideText = slide.Text;
                if (slideText.Contains("Security Testing", StringComparison.OrdinalIgnoreCase))
                {
                    Assert.That(slideText.Contains("Security Testing", StringComparison.OrdinalIgnoreCase));
                    break;
                }
            }   


        }
    }
}