using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurnSoft.Applications.MGC.Global;
using BurnSoft.Applications.MGC.hotixes.types;
using BurnSoft.Applications.MGC.UnitTest.Settings;
// ReSharper disable InlineOutVariableDeclaration
// ReSharper disable RedundantAssignment
// ReSharper disable NotAccessedField.Local
// ReSharper disable UnusedVariable

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
        /// <summary>
        /// Defines the test method GetSettingsTest.
        /// </summary>
        [TestMethod, TestCategory("Registry Tests")]
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
        /// <summary>
        /// Defines the test method SaveSettingsTest.
        /// </summary>
        [TestMethod, TestCategory("Registry Tests")]
        public void SaveSettingsTest()
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

            bool value = MyRegistry.SaveSettings("00000", trackHistory, trackHistoryDays, autoBackup, alertOnBackUp,
                autoBackup, uoimg, usePl, useIPer, false, useaa, useAacid, useUniqueCustId, bUseselectiveboundbook,
                out _errOut);

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

            General.HasTrueValue(value, _errOut);

        }
        /// <summary>
        /// Defines the test method SaveLastWorkingDirTest.
        /// </summary>
        [TestMethod, TestCategory("Registry Tests")]
        public void SaveLastWorkingDirTest()
        {
            bool value = MyRegistry.SaveLastWorkingDir(Path.GetFullPath(_databasePath), out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method GetLastWorkingDirTest.
        /// </summary>
        [TestMethod, TestCategory("Registry Tests")]
        public void GetLastWorkingDirTest()
        {
            string value = MyRegistry.GetLastWorkingDir(out _errOut);
            TestContext.WriteLine(value);
            General.HasValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method SaveFirearmListSortTest.
        /// </summary>
        [TestMethod, TestCategory("Registry Tests")]
        public void SaveFirearmListSortTest()
        {
            bool value = MyRegistry.SaveFirearmListSort("In Stock", out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method GetViewSettingsTest.
        /// </summary>
        [TestMethod, TestCategory("Registry Tests")]
        public void GetViewSettingsTest()
        {
            string value = MyRegistry.GetViewSettings("VIEW_FirearmList", out _errOut, "In Stocks");
            TestContext.WriteLine(value);
            General.HasValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method SetSettingDetailsTest.
        /// </summary>
        [TestMethod, TestCategory("Registry Tests")]
        public void SetSettingDetailsTest()
        {
            bool value = MyRegistry.SetSettingDetails(out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method UpDateAppDetailsTest.
        /// </summary>
        [TestMethod, TestCategory("Registry Tests")]
        public void UpDateAppDetailsTest()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            bool value = MyRegistry.UpDateAppDetails("1.0", "My Gun Collection Unit Test", path, $"{path}", Path.Combine(path,"log.err"), _databasePath, Path.GetFullPath(_databasePath), out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method GetHotxesTest.
        /// </summary>
        [TestMethod, TestCategory("Registry Tests")]
        public void GetHotxesTest()
        {
            List<HotFixList> value = MyRegistry.GetHotxes(out _errOut);
            foreach (HotFixList h in value)
            {
                TestContext.WriteLine($"id: {h.Id}");
                TestContext.WriteLine($"DateInstalled: {h.DateInstalled}");
                TestContext.WriteLine($"Was from Install: {h.WasFromInstall}");
            }
            General.HasTrueValue(value.Count > 0, _errOut);
        }
    }
}
