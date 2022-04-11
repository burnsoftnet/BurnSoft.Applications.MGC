using System;
using System.Collections.Generic;
using System.IO;
using BurnSoft.Applications.MGC.UnitTest.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurnSoft.Universal;

namespace BurnSoft.Applications.MGC.UnitTest.Hotfixes
{
    [TestClass]
    public class RunHotFixes
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
            BSOtherObjects obj = new BSOtherObjects();
            _errOut = @"";
            _databasePath = Vs2019.GetSetting("DatabasePath", TestContext);
        }
        [TestMethod]
        public void HotFix10Test()
        {
            bool value = hotixes.HotFix.Run(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databasePath),10, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
    }
}
