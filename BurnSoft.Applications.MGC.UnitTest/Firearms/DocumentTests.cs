using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BurnSoft.Applications.MGC.Firearms;
using BurnSoft.Applications.MGC.UnitTest.Settings;
using BurnSoft.Universal;

namespace BurnSoft.Applications.MGC.UnitTest.Firearms
{
    [TestClass]
    public class DocumentTests
    {
        /// <summary>
        /// Gets or sets the test context.
        /// </summary>
        /// <value>The test context.</value>
        public TestContext TestContext { get; set; }
        /// <summary>
        /// The error out
        /// </summary>
        private string _errOut;

        /// <summary>
        /// The database path
        /// </summary>
        private string _databasePath;
        private string Doc_Title;
        private string Doc_Description;
        private string Doc_Category;
        private string Doc_Ext;
        private string Doc_Path;
        private int Doc_Ext_Number;
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            // Vs2019.GetSetting("", TestContext);
            BSOtherObjects obj = new BSOtherObjects();
            _errOut = @"";
            _databasePath = Vs2019.GetSetting("DatabasePath", TestContext);
            Doc_Title = obj.FC(Vs2019.GetSetting("Doc_Title", TestContext));
            Doc_Description = obj.FC(Vs2019.GetSetting("Doc_Description", TestContext));
            Doc_Category = obj.FC(Vs2019.GetSetting("Doc_Category", TestContext));
            Doc_Ext = obj.FC(Vs2019.GetSetting("Doc_Ext", TestContext));
            Doc_Path = Vs2019.GetSetting("Doc_Path", TestContext);
            Doc_Ext_Number = Convert.ToInt32(Vs2019.GetSetting("Doc_Ext_Number", TestContext));
        }
        [TestMethod]
        public void AddTest()
        {
            bool value = Documents.Add(_databasePath, Doc_Title, Doc_Description, Doc_Category, Doc_Path, Doc_Ext_Number,
                out _errOut);

            General.HasTrueValue(value, _errOut);
        }
    }
}
