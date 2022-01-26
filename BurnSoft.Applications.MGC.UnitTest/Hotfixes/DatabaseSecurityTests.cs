using System.Collections.Generic;
using BurnSoft.Applications.MGC.UnitTest.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurnSoft.Universal;

namespace BurnSoft.Applications.MGC.UnitTest.Hotfixes
{
    [TestClass]
    public class DatabaseSecurityTests
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
        /// The gun identifier
        /// </summary>
        private int _gunId;
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
            _gunId = Vs2019.IGetSetting("MyGunCollectionID", TestContext);
        }
        [TestMethod]
        public void RemovePasswordTest()
        {
            bool value = hotixes.Database.Security.RemovePassword(_databasePath, out _errOut);
            General.HasTrueValue(value, _errOut);
        }

        [TestMethod]
        public void AddPasswordTest()
        {
            bool value = hotixes.Database.Security.AddPassword(_databasePath, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
    }
}
