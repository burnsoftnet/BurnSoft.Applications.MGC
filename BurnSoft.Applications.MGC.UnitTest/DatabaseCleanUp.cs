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
        /// Defines the test method KillDataTest.
        /// </summary>
        [TestMethod]
        public void KillDataTest()
        {
            bool value = MGC.DatabaseCleanUp.KillData(_databasePath, "Gun_Type", out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method ClearGripTypesTest.
        /// </summary>
        [TestMethod]
        public void ClearGripTypesTest()
        {
            bool value = MGC.DatabaseCleanUp.ClearGripTypes(_databasePath, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method ClearBuyerListTest.
        /// </summary>
        [TestMethod]
        public void ClearBuyerListTest()
        {
            bool value = MGC.DatabaseCleanUp.ClearBuyerList(_databasePath, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method ClearGunShopListTest.
        /// </summary>
        [TestMethod]
        public void ClearGunShopListTest()
        {
            bool value = MGC.DatabaseCleanUp.ClearGunShopList(_databasePath, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method ClearNationalityTest.
        /// </summary>
        [TestMethod]
        public void ClearNationalityTest()
        {
            bool value = MGC.DatabaseCleanUp.ClearNationality(_databasePath, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method ClearManufacturersTest.
        /// </summary>
        [TestMethod]
        public void ClearManufacturersTest()
        {
            bool value = MGC.DatabaseCleanUp.ClearGunShopList(_databasePath, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method ClearModelsTest.
        /// </summary>
        [TestMethod]
        public void ClearModelsTest()
        {
            bool value = MGC.DatabaseCleanUp.ClearNationality(_databasePath, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method ClearCollectionTest.
        /// </summary>
        [TestMethod]
        public void ClearCollectionTest()
        {
            bool value = MGC.DatabaseCleanUp.ClearCollection(_databasePath, out _errOut);
            General.HasTrueValue(value, _errOut);
        }

    }
}
