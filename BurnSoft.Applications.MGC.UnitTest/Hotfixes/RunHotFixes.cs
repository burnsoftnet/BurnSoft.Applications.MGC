﻿using System;
using System.IO;
using BurnSoft.Applications.MGC.UnitTest.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ConvertIfStatementToConditionalTernaryExpression

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
            _errOut = @"";
            _databasePath = Vs2019.GetSetting("DatabasePath", TestContext);
        }
        /// <summary>
        /// Defines the test method HotFix1Test.
        /// </summary>
        [TestMethod, TestCategory("Run Hotfixes")]
        public void HotFix1Test()
        {
            bool value = hotixes.HotFix.Run(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databasePath), 1, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method HotFix2Test.
        /// </summary>
        [TestMethod, TestCategory("Run Hotfixes")]
        public void HotFix2Test()
        {
            bool value = hotixes.HotFix.Run(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databasePath), 2, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method HotFix3Test.
        /// </summary>
        [TestMethod, TestCategory("Run Hotfixes")]
        public void HotFix3Test()
        {
            bool value = hotixes.HotFix.Run(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databasePath), 3, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method HotFix4Test.
        /// </summary>
        [TestMethod, TestCategory("Run Hotfixes")]
        public void HotFix4Test()
        {
            bool value = hotixes.HotFix.Run(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databasePath), 4, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method HotFix5Test.
        /// </summary>
        [TestMethod, TestCategory("Run Hotfixes")]
        public void HotFix5Test()
        {
            bool value = hotixes.HotFix.Run(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databasePath), 5, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method HotFix6Test.
        /// </summary>
        [TestMethod, TestCategory("Run Hotfixes")]
        public void HotFix6Test()
        {
            bool value = hotixes.HotFix.Run(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databasePath), 6, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method HotFix7Test.
        /// </summary>
        [TestMethod, TestCategory("Run Hotfixes")]
        public void HotFix7Test()
        {
            bool value = hotixes.HotFix.Run(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databasePath), 7, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method HotFix8Test.
        /// </summary>
        [TestMethod, TestCategory("Run Hotfixes")]
        public void HotFix8Test()
        {
            bool value = hotixes.HotFix.Run(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databasePath), 8, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method HotFix9Test.
        /// </summary>
        [TestMethod, TestCategory("Run Hotfixes")]
        public void HotFix9Test()
        {
            bool value = hotixes.HotFix.Run(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databasePath), 9, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method HotFix10Test.
        /// </summary>
        [TestMethod, TestCategory("Run Hotfixes")]
        public void HotFix10Test()
        {
            bool value = hotixes.HotFix.Run(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databasePath),10, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method NeedsUpdateTest.
        /// </summary>
        [TestMethod, TestCategory("Run Hotfixes")]
        public void NeedsUpdateTest()
        {
            bool value = hotixes.HotFix.NeedsUpdate(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databasePath), out _errOut);
            if (value)
            {
                TestContext.WriteLine("Needs Updates.");
            }
            else
            {
                TestContext.WriteLine("Does not need Updates.");
            }
            General.HasTrueValue(_errOut.Length == 0, _errOut);
        }
        /// <summary>
        /// Defines the test method ApplyMissingUpdateTests.
        /// </summary>
        [TestMethod, TestCategory("Run Hotfixes")]
        public void ApplyMissingUpdateTests()
        {
            string appliedFixes;
            bool value = hotixes.HotFix.ApplyMissingHotFixes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databasePath), out _errOut, out appliedFixes);
            if (value)
            {
                if (appliedFixes.Length > 0)
                {
                    TestContext.WriteLine($"Updates were applied: {appliedFixes}");
                }
                else
                {
                    TestContext.WriteLine($"No Need to Apply Updates");
                }
                
            }
            else
            {
                TestContext.WriteLine("Error while appling updates");
            }
            General.HasTrueValue(_errOut.Length == 0, _errOut);
        }
    }
}
