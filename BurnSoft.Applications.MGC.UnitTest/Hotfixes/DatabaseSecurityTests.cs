﻿using System;
using System.IO;
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
        /// <summary>
        /// Defines the test method RemovePasswordTest.
        /// </summary>
        [TestMethod, TestCategory("Database Security")]
        public void RemovePasswordTest()
        {
            bool value = hotixes.HfDatabase.Security.RemovePassword(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databasePath), out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method AddPasswordTest.
        /// </summary>
        [TestMethod, TestCategory("Database Security")]
        public void AddPasswordTest()
        {
            hotixes.HfDatabase.Security.RemovePassword(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databasePath), out _errOut);
            bool value = hotixes.HfDatabase.Security.AddPassword(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databasePath), out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method ChangePasswordTest.
        /// </summary>
        [TestMethod, TestCategory("Database Security")]
        public void ChangePasswordTest()
        {
            bool value = hotixes.HfDatabase.Security.ChangePassword(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databasePath), out _errOut);
            General.HasTrueValue(value, _errOut);
        }
    }
}
