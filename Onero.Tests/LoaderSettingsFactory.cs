using System.Collections.Generic;
using System.IO;
using Onero.Loader;
using Onero.Loader.Forms;
using Onero.Loader.Results;

namespace Onero.Tests
{
    // TODO: Place as nested class within BaseTest
    internal static class Settings
    {
        const string TEST = "test";

        public static LoaderSettings DEFAULT_EMPTY_SETTINGS => new LoaderSettings();


        internal static class Actions
        {
            public static LoaderSettings Rule_Action_Test => new LoaderSettings
            {
                Profile = new Profile { Timeout = 60 },
                Rules = new List<Rule>
                {
                    new Rule("Rule to test HTML tag", "$('html').length > 0") { Enabled = true }
                }
            };     
                   
            public static LoaderSettings Screenshot_Action_Test => new LoaderSettings
            {
                Profile = new Profile { Timeout = 60, CreateScreenshots = true, OutputDirectory = Directory.GetCurrentDirectory() }
            };

            public static LoaderSettings Form_Sumbission_Action_Test_All_Supported_Types => new LoaderSettings
            {
                Profile = new Profile { Timeout = 60 },
                Forms = new List<WebForm>
                {
                    new WebForm
                    {
                        Name = "login form",
                        Fields = new List<WebFormField>
                        {
                            new WebFormField(SupportedFields.TEXT, FieldType.SendText, TEST),
                            new WebFormField(SupportedFields.PASSWORD,  FieldType.SendText, TEST),
                            new WebFormField(SupportedFields.CHECKBOX,  FieldType.ClickItem, "not_used"),
                            new WebFormField(SupportedFields.RADIO,  FieldType.ClickItem, "not_used"),
                            new WebFormField(SupportedFields.DATALIST,  FieldType.SendText, TEST),
                            new WebFormField(SupportedFields.RANGE,  FieldType.SendKeys, "RIGHT*40"),
                            new WebFormField(SupportedFields.NUMBER,  FieldType.SendKeys, "UP*4"),
                            new WebFormField(SupportedFields.COLOR,  FieldType.JavaScript, $"$('{SupportedFields.COLOR}').val('#ffff00');")
                        },

                        ResultParameters = new FormResultParameters(FormResultType.Message)
                        {
                            Id = SupportedFields.MESSAGE,
                            Message = "OK"
                        },

                        SubmitId = SupportedFields.SUBMIT,
                        Urls = new List<string> { URL.SupportedPages }
                    }
                }
            };

            public static LoaderSettings Form_Sumbission_Login => new LoaderSettings
            {
                Profile = new Profile { Timeout = 60 },
                Forms = new List<WebForm>
                {
                    new WebForm
                    {
                        Name = "login form",
                        Fields = new List<WebFormField>
                        {
                            new WebFormField("#Email", "test@test.com"),
                            new WebFormField("#Password", "Test-123"),
                        },
                        ResultParameters = new FormResultParameters(FormResultType.Redirect)
                        {
                            Url = $"{BaseTest.WEBSITE_TEST_BASE}$"
                        },
                        SubmitId = ".btn-default",
                        Urls = new List<string> { URL.Login }
                    }
                }
            };

            public static LoaderSettings Data_Extract_Action => new LoaderSettings
            {
                DataExtractors = new List<DataExtractItem>
            {
                new DataExtractItem
                {
                    Condition = ".body-content",
                    Enabled = true,
                    Name = "",
                    RemoveWhitespaces = true,
                    Urls = new List<string> { "/Home/DataExtract" }
                }
            }

            };
            public static LoaderSettings Broken_Links_Action => new LoaderSettings
            {
                BrokenLinks = null,
                BrokenImages = null,
                BrokenScripts = null,
                BrokenStyles = null, //new List<Broken> { new BrokenStyle { Enabled = true } },
                Profile = new Profile
                {
                    FindAllBrokenLinks = true,
                    FindAllBrokenImages = true,
                    FindAllBrokenScripts = true,
                    FindAllBrokenStyles = true
                }
            };

        }

        internal static class Loader
        {
            public static LoaderSettings Universal => new LoaderSettings
            {
                Profile = new Profile
                {
                    Timeout = 60,
                    CreateScreenshots = false,
                    OutputDirectory = Directory.GetCurrentDirectory(),
                    FindAllBrokenLinks = true,
                    FindAllBrokenImages = true,
                    FindAllBrokenScripts = true,
                    FindAllBrokenStyles = true
                },
                Rules = new List<Rule>
                {
                    new Rule("Rule to test HTML tag", "$('html').length > 0") {Enabled = true}
                },
                Forms = new List<WebForm>
                {
                    new WebForm
                    {
                        Name = "login form",
                        Fields = new List<WebFormField>
                        {
                            new WebFormField(SupportedFields.TEXT, FieldType.SendText, TEST),
                            new WebFormField(SupportedFields.PASSWORD, FieldType.SendText, TEST),
                            new WebFormField(SupportedFields.CHECKBOX, FieldType.ClickItem, "not_used"),
                            new WebFormField(SupportedFields.RADIO, FieldType.ClickItem, "not_used"),
                            new WebFormField(SupportedFields.DATALIST, FieldType.SendText, TEST),
                            new WebFormField(SupportedFields.RANGE, FieldType.SendKeys, "RIGHT*40"),
                            new WebFormField(SupportedFields.NUMBER, FieldType.SendKeys, "UP*4"),
                            new WebFormField(SupportedFields.COLOR, FieldType.JavaScript, $"$('{SupportedFields.COLOR}').val('#ffff00');")
                        },

                        ResultParameters = new FormResultParameters(FormResultType.Message)
                        {
                            Id = SupportedFields.MESSAGE,
                            Message = "OK"
                        },

                        SubmitId = SupportedFields.SUBMIT,
                        Urls = new List<string> {URL.SupportedPages}
                    }
                },
                DataExtractors = new List<DataExtractItem>
                {
                    new DataExtractItem
                    {
                        Condition = ".body-content",
                        Enabled = true,
                        Name = "",
                        RemoveWhitespaces = true,
                        Urls = new List<string> {"/Home/DataExtract"}
                    },
                }
            };
        }
    }
}
