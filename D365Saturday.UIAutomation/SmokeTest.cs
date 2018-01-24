using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.Dynamics365.UIAutomation.Api;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Configuration;

namespace D365Saturday.UIAutomation
{
    [TestClass]
    public class SmokeTest
    {
        public TestContext TestContext { get; set; }

        private SecureString _username = GetConfigValue("CRMUser").ToSecureString();
        private SecureString _password = GetConfigValue("CRMPassword").ToSecureString();
        private Uri _xrmUri = new Uri(GetConfigValue("CRMUrl"));


        private readonly BrowserOptions _options = new BrowserOptions
        {
            BrowserType = BrowserType.Chrome,
            PrivateMode = true,
            FireEvents = true
        };

        private static string GetConfigValue(string name)
        {
            string value = Environment.GetEnvironmentVariable(name);
            if (string.IsNullOrEmpty(value))
                value = ConfigurationManager.AppSettings[name];
            if (string.IsNullOrEmpty(value))
                throw new NotFoundException(name);
            return value;
        }

        [TestMethod]
        public void RunSmokeTest()
        {
            using (var xrmBrowser = new XrmBrowser(_options))
            {
                try
                {
                    xrmBrowser.LoginPage.Login(_xrmUri, _username, _password);
                    xrmBrowser.GuidedHelp.CloseGuidedHelp();

                    xrmBrowser.ThinkTime(500);
                    xrmBrowser.Navigation.OpenSubArea("Sales", "Contacts");

                    xrmBrowser.ThinkTime(2000);
                    xrmBrowser.Grid.SwitchView("Active Contacts");

                    xrmBrowser.ThinkTime(1000);
                    xrmBrowser.CommandBar.ClickCommand("New");

                    xrmBrowser.ThinkTime(5000);

                    var fields = new List<Field>
                    {
                        new Field() {Id = "firstname", Value = "Wael"},
                        new Field() {Id = "lastname", Value = "Test"}
                    };
                    xrmBrowser.Entity.SetValue(new CompositeControl() { Id = "fullname", Fields = fields });
                    xrmBrowser.Entity.SetValue("emailaddress1", "test@contoso.com");
                    xrmBrowser.Entity.SetValue("mobilephone", "555-555-5555");
                    xrmBrowser.Entity.SetValue("birthdate", DateTime.Parse("11/1/1980"));
                    xrmBrowser.Entity.SetValue(new OptionSet { Name = "preferredcontactmethodcode", Value = "Email" });

                    xrmBrowser.CommandBar.ClickCommand("Save");
                    xrmBrowser.ThinkTime(5000);
                }
                finally
                {
                    string screenShot = string.Format("{0}\\SmokeTest_Final.jpeg", TestContext.TestResultsDirectory);
                    xrmBrowser.TakeWindowScreenShot(screenShot, ScreenshotImageFormat.Jpeg);
                    TestContext.AddResultFile(screenShot);
                }
            }
        }
    }
}
