using System;
using System.IO;
using BurnSoft.Applications.MGC.UnitTest.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        [TestMethod]
        public void HotFix1Test()
        {
            bool value = hotixes.HotFix.Run(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databasePath), 1, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        [TestMethod]
        public void HotFix2Test()
        {
            bool value = hotixes.HotFix.Run(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databasePath), 2, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        [TestMethod]
        public void HotFix3Test()
        {
            bool value = hotixes.HotFix.Run(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databasePath), 3, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        [TestMethod]
        public void HotFix4Test()
        {
            bool value = hotixes.HotFix.Run(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databasePath), 4, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        [TestMethod]
        public void HotFix5Test()
        {
            bool value = hotixes.HotFix.Run(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databasePath), 5, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        [TestMethod]
        public void HotFix6Test()
        {
            bool value = hotixes.HotFix.Run(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databasePath), 6, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        [TestMethod]
        public void HotFix7Test()
        {
            bool value = hotixes.HotFix.Run(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databasePath), 7, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        [TestMethod]
        public void HotFix8Test()
        {
            bool value = hotixes.HotFix.Run(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databasePath), 8, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        [TestMethod]
        public void HotFix9Test()
        {
            bool value = hotixes.HotFix.Run(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databasePath), 9, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        [TestMethod]
        public void HotFix10Test()
        {
            bool value = hotixes.HotFix.Run(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databasePath),10, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
    }
}
