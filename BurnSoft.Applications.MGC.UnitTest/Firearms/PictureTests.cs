using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        /// <summary>
        /// Defines the test method HasDefaultPictureTestNoAdd.
        /// </summary>
        [TestMethod]
        public void HasDefaultPictureTestNoAdd()
        {
            bool value = Pictures.HasDefaultPicture(_databasePath, _gunId, Path.GetFullPath(_databasePath), "", out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method IsFirstPicTest.
        /// </summary>
        [TestMethod]
        public void IsFirstPicTest()
        {
            bool value = Pictures.IsFirstPic(_databasePath, _gunId, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method CountPicsTest.
        /// </summary>
        [TestMethod]
        public void CountPicsTest()
        {
            long value = Pictures.CountPics(_databasePath, _gunId, out _errOut);
            TestContext.WriteLine($"Number of pics in collection: {value}");
            General.HasTrueValue(value > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method SaveTest.
        /// </summary>
        [TestMethod]
        public void SaveTest()
        {
            string picPath = "D:\\ProductPics\\MyEssentialOilRemedies.jpg";
            bool value = Pictures.Save(_databasePath, picPath, AppDomain.CurrentDomain.BaseDirectory, _gunId, "test",
                "test", out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Prints the list.
        /// </summary>
        /// <param name="p">The p.</param>
        public void PrintList(List<PictureDetails> p)
        {
            if (p.Count > 0)
            {
                foreach (PictureDetails d in p)
                {
                    TestContext.WriteLine("");
                    TestContext.WriteLine($"id: {d.Id}");
                    TestContext.WriteLine($"isMain: {d.IsMain}");
                    TestContext.WriteLine($"Last Sync: {d.LastSyncDate}");
                    TestContext.WriteLine($"Picture: {d.Picture}");
                    TestContext.WriteLine($"Thumb: {d.Thumb}");
                    TestContext.WriteLine($"Display Name: {d.PictureDisplayName}");
                    TestContext.WriteLine($"Display Note: {d.PictureNotes}");
                    TestContext.WriteLine($"Pic Stream: {d.PictureMemoryStream}");
                    TestContext.WriteLine($"Thumb Stream: {d.ThumbMemoryStream}");
                    TestContext.WriteLine("");
                    TestContext.WriteLine("----------------------------------------");
                }
            }
            else
            {
                TestContext.WriteLine("NO DATA IN LIST!");
            }
        }
        /// <summary>
        /// Defines the test method GetPicturesForFirearmTest.
        /// </summary>
        [TestMethod]
        public void GetPicturesForFirearmTest()
        {
            List<PictureDetails> value = Pictures.GetList(_databasePath, _gunId, out _errOut);
            PrintList(value);
            General.HasTrueValue(value.Count > 0, _errOut);
        }
    }
}
