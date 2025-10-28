using BurnSoft.Applications.MGC.UnitTest.Settings;
using BurnSoft.Universal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BurnSoft.Applications.MGC.UnitTest.Other
{
    [TestClass]
    public class GeneralAccessoriesTest
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
        public void TestMethod1()
        {
        }
    }
}
