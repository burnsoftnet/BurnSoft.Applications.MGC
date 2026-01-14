using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurnSoft.Applications.MGC.UnitTest.Settings;

namespace BurnSoft.Applications.MGC.UnitTest
{
    [TestClass]
    public class DatabaseCleanUp
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
        /// The skip test Skip the clean up tests for sake of other tests.
        /// </summary>
        private bool _skipTest;
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            // Vs2019.GetSetting("", TestContext);
            _errOut = @"";
            _databasePath = Vs2019.GetSetting("DatabasePath", TestContext);
            _skipTest = Vs2019.BGetSetting("SkipCleanupTests", TestContext);
        }
        /// <summary>
        /// Defines the test method KillDataTest.
        /// </summary>
        [TestMethod, TestCategory("Database Cleanup")]
        public void KillDataTest()
        {
            if (!_skipTest)
            {
                bool value = MGC.DatabaseCleanUp.KillData(_databasePath, "Gun_Type", out _errOut);
                General.HasTrueValue(value, _errOut);
            }
            else
            {
                General.HasTrueValue(true);
            }                            
        }
        /// <summary>
        /// Defines the test method ClearGripTypesTest.
        /// </summary>
        [TestMethod, TestCategory("Database Cleanup")]
        public void ClearGripTypesTest()
        {
            if (!_skipTest)
            {
                bool value = MGC.DatabaseCleanUp.ClearGripTypes(_databasePath, out _errOut);
                General.HasTrueValue(value, _errOut);
            }
            else
            {
                General.HasTrueValue(true);
            }
        }
        /// <summary>
        /// Defines the test method ClearBuyerListTest.
        /// </summary>
        [TestMethod, TestCategory("Database Cleanup")]
        public void ClearBuyerListTest()
        {
            if (!_skipTest)
            {
                bool value = MGC.DatabaseCleanUp.ClearBuyerList(_databasePath, out _errOut);
                General.HasTrueValue(value, _errOut);
            }
            else
            {
                General.HasTrueValue(true);
            }
        }
        /// <summary>
        /// Defines the test method ClearGunShopListTest.
        /// </summary>
        [TestMethod, TestCategory("Database Cleanup")]
        public void ClearGunShopListTest()
        {
            if (!_skipTest)
            {
                bool value = MGC.DatabaseCleanUp.ClearGunShopList(_databasePath, out _errOut);
                General.HasTrueValue(value, _errOut);
            }
            else
            {
                General.HasTrueValue(true);
            }
        }
        /// <summary>
        /// Defines the test method ClearNationalityTest.
        /// </summary>
        [TestMethod, TestCategory("Database Cleanup")]
        public void ClearNationalityTest()
        {
            if (!_skipTest)
            {
                bool value = MGC.DatabaseCleanUp.ClearNationality(_databasePath, out _errOut);
                General.HasTrueValue(value, _errOut);
            }
            else
            {
                General.HasTrueValue(true);
            }
        }
        /// <summary>
        /// Defines the test method ClearManufacturersTest.
        /// </summary>
        [TestMethod, TestCategory("Database Cleanup")]
        public void ClearManufacturersTest()
        {
            if (!_skipTest)
            {
                bool value = MGC.DatabaseCleanUp.ClearGunShopList(_databasePath, out _errOut);
                General.HasTrueValue(value, _errOut);
            }
            else
            {
                General.HasTrueValue(true);
            }
        }
        /// <summary>
        /// Defines the test method ClearModelsTest.
        /// </summary>
        [TestMethod, TestCategory("Database Cleanup")]
        public void ClearModelsTest()
        {
            if (!_skipTest)
            {
                bool value = MGC.DatabaseCleanUp.ClearNationality(_databasePath, out _errOut);
                General.HasTrueValue(value, _errOut);
            }
            else
            {
                General.HasTrueValue(true);
            }
        }
        /// <summary>
        /// Defines the test method ClearCollectionTest.
        /// </summary>
        [TestMethod, TestCategory("Database Cleanup")]
        public void ClearCollectionTest()
        {
            if (!_skipTest)
            {
                bool value = MGC.DatabaseCleanUp.ClearCollection(_databasePath, out _errOut);
                General.HasTrueValue(value, _errOut);
            }
            else
            {
                General.HasTrueValue(true);
            }
        }

    }
}
