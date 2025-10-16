using BurnSoft.Applications.MGC.DebugHelpers;
using BurnSoft.Applications.MGC.UnitTest.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BurnSoft.Applications.MGC.UnitTest.DebugHelpersTests
{
    [TestClass]
    public class VerifyDataTests
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
            _errOut = @"";
            _databasePath = Vs2019.GetSetting("DatabasePath", TestContext);
        }

        [TestMethod, TestCategory("Verify Data")]
        public void FirearmDetailsByIdTest()
        {
            bool passed = VerifyData.FirearmDetailsById(_databasePath, 2, out _errOut);
            if (_errOut.Length > 0) TestContext.WriteLine(_errOut);
            Assert.IsTrue(passed);
        }

        [TestMethod, TestCategory("Verify Data")]
        public void FirearmDetailsAllTest()
        {
            bool passed = VerifyData.FirearmDetailsAll(_databasePath, out _errOut);
            if (_errOut.Length > 0) TestContext.WriteLine(_errOut);
         
            Assert.IsTrue(passed);
        }

        [TestMethod, TestCategory("Verify Data")]
        public void CheckBarrelTableTest()
        {
            bool passed = VerifyData.CheckBarrelTable(_databasePath, out _errOut);
            if (_errOut.Length > 0) TestContext.WriteLine(_errOut);
            Assert.IsTrue(passed);
        }
    }
}
