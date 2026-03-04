using BurnSoft.Applications.MGC.Global;
using BurnSoft.Applications.MGC.LoadersLog;
using BurnSoft.Applications.MGC.UnitTest.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace BurnSoft.Applications.MGC.UnitTest.LoaderLogs
{
    [TestClass]
    public class RegistryHelpersTests
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

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            // Vs2019.GetSetting("", TestContext);
            //BSOtherObjects obj = new BSOtherObjects();
            _errOut = @"";
            _databasePath = Vs2019.GetSetting("DatabasePath", TestContext);
        }

        [TestMethod, TestCategory("MyLoadersLog - Registry Tests")]
        public void GetMgcExePathTest()
        {
            string value = RegistryHelpers.GetMgcExePath(out _errOut);
            TestContext.WriteLine($"VALUE RETURNED: {value}");
            General.HasTrueValue(value.Length > 0, _errOut);
        }

        [TestMethod, TestCategory("MyLoadersLog - Registry Tests")]
        public void GetMGCPathTest()
        {
            string value = RegistryHelpers.GetMGCPath(out _errOut);
            TestContext.WriteLine($"VALUE RETURNED: {value}");
            General.HasTrueValue(value.Length > 0, _errOut);
        }
    }
}
