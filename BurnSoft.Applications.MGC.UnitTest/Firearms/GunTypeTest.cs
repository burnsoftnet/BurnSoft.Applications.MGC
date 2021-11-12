using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using BurnSoft.Applications.MGC.Firearms;
using BurnSoft.Applications.MGC.UnitTest.Settings;

namespace BurnSoft.Applications.MGC.UnitTest.Firearms
{
    [TestClass]
    public class GunTypeTest
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
        /// The gun type name
        /// </summary>
        private string GunTypeName;
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            // Vs2019.GetSetting("", TestContext);
            _errOut = @"";
            _databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Vs2019.GetSetting("DatabasePath", TestContext));
            _gunId = Vs2019.IGetSetting("MyGunCollectionID", TestContext);
            GunTypeName = "Pistol: Triple Action";
        }

        [TestMethod]
        public void AddTest()
        {
            bool value = BurnSoft.Applications.MGC.Firearms.GunTypes.Add(_databasePath, GunTypeName, out _errOut);
            string result = value ? "Was" : "Was not";
            result += $" able to add gun type {GunTypeName} to database";
            TestContext.WriteLine(result);
            General.HasTrueValue(value, _errOut);
        }

        [TestMethod]
        public void ExistsTest()
        {
            bool value = BurnSoft.Applications.MGC.Firearms.GunTypes.Exists(_databasePath, GunTypeName, out _errOut);
            TestContext.WriteLine(value ? $"{GunTypeName} exists!" : $"{GunTypeName} does not exist");
            General.HasTrueValue(value, _errOut);
        }
    }
}
