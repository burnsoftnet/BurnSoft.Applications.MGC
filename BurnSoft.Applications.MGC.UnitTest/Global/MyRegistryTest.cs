using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurnSoft.Applications.MGC.Global;
using BurnSoft.Applications.MGC.UnitTest.Settings;
// ReSharper disable InlineOutVariableDeclaration
// ReSharper disable RedundantAssignment

namespace BurnSoft.Applications.MGC.UnitTest.Global
{
    [TestClass]
    public class MyRegistryTest
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
            //BSOtherObjects obj = new BSOtherObjects();
            _errOut = @"";
            _databasePath = Vs2019.GetSetting("DatabasePath", TestContext);
        }
        [TestMethod]
        public void GetSettingsTest()
        {
            string lastSucBackup = "";
            bool alertOnBackUp = false;
            int trackHistoryDays = 30;
            bool trackHistory = false;
            bool autoBackup = false;
            bool uoimg = false;
            bool usePl = false;
            bool useIPer = false;
            bool useCcid = false;
            bool useaa = false;
            bool useAacid = false;
            bool useUniqueCustId = false;
            bool bUseselectiveboundbook = false;


            MyRegistry.GetSettings(out lastSucBackup, out alertOnBackUp, out trackHistoryDays, out trackHistory, out autoBackup, out uoimg, out usePl, out useIPer, out useCcid, out useaa, out useAacid, out useUniqueCustId, out bUseselectiveboundbook, out _errOut);

            TestContext.WriteLine($"lastSucBackup: {lastSucBackup}");
            TestContext.WriteLine($"alertOnBackUp: {alertOnBackUp}");
            TestContext.WriteLine($"trackHistoryDays: {trackHistoryDays}");
            TestContext.WriteLine($"trackHistory: {trackHistory}");
            TestContext.WriteLine($"autoBackup: {autoBackup}");
            TestContext.WriteLine($"uoimg: {uoimg}");
            TestContext.WriteLine($"usePl: {usePl}");
            TestContext.WriteLine($"useIPer: {useIPer}");
            TestContext.WriteLine($"useCcid: {useCcid}");
            TestContext.WriteLine($"useaa: {useaa}");
            TestContext.WriteLine($"useAacid: {useAacid}");
            TestContext.WriteLine($"useUniqueCustId: {useUniqueCustId}");
            TestContext.WriteLine($"bUseselectiveboundbook: {bUseselectiveboundbook}");

            General.HasValue(trackHistory.ToString(), _errOut);
        }
    }
}
