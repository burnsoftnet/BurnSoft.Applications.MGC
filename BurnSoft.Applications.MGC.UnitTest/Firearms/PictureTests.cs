using System;
using System.Collections.Generic;
using BurnSoft.Applications.MGC.Firearms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurnSoft.Applications.MGC.Types;
using BurnSoft.Applications.MGC.UnitTest.Settings;
using BurnSoft.Universal;

// ReSharper disable UnusedMember.Local

namespace BurnSoft.Applications.MGC.UnitTest.Firearms
{
    [TestClass]
    public class PictureTests
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
        /// The gun identifier
        /// </summary>
        private long _gunId;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            // Vs2019.GetSetting("", TestContext);
            _errOut = @"";
            BSOtherObjects obj = new BSOtherObjects();
            _databasePath = Vs2019.GetSetting("DatabasePath", TestContext);
            _gunId = Convert.ToInt32(Vs2019.GetSetting("MyGunCollectionID", TestContext));
        }
        [TestMethod]
        public void HasDefaultPictureTestNoAdd()
        {
            bool value = Pictures.HasDefaultPicture(_databasePath, _gunId, "", out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        [TestMethod]
        public void IsFirstPicTest()
        {
            bool value = Pictures.IsFirstPic(_databasePath, _gunId, out _errOut);
            General.HasTrueValue(value, _errOut);
        }

        [TestMethod]
        public void CountPicsTest()
        {
            long value = Pictures.CountPics(_databasePath, _gunId, out _errOut);
            TestContext.WriteLine($"Number of pics in collection: {value}");
            General.HasTrueValue(value > 0, _errOut);
        }
    }
}
