using BurnSoft.Applications.MGC.LoadersLog;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BurnSoft.Applications.MGC.UnitTest.LoaderLogs
{
    [TestClass]
    public class FirearmHelpersTests
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
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            // Vs2019.GetSetting("", TestContext);
            _errOut = @"";
        }

        [TestMethod, TestCategory("MyLoadersLog - Gun Collects")]
        public void CountFirearmsTest()
        {
            long value = FirearmHelpers.CountFirearms(out _errOut);
            TestContext.WriteLine($"VALUE RETURNED: {value}");
            General.HasTrueValue(value > 0, _errOut);
        }
    }
}
