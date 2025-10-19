using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using BurnSoft.Applications.MGC.Firearms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurnSoft.Applications.MGC.Types;
using BurnSoft.Applications.MGC.UnitTest.Settings;
using BurnSoft.Universal;
using BurnSoft.Applications.MGC.DebugHelpers;

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
        /// The pic path
        /// </summary>
        private string _picPath;

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
            //_gunId = MyCollection.GetTopId(_databasePath,out _errOut);
            _picPath = "C:\\TestData\\p365-380-web-left.jpg";
        }
        /// <summary>
        /// Defines the test method HasDefaultPictureTestNoAdd.
        /// </summary>
        [TestMethod, TestCategory("Pictures")]
        public void HasDefaultPictureTestNoAdd()
        {
            bool value = Pictures.HasDefaultPicture(_databasePath, _gunId, AppDomain.CurrentDomain.BaseDirectory, "", out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method HasDefaultPictureTestAdd.
        /// </summary>
        [TestMethod, TestCategory("Pictures")]
        public void HasDefaultPictureTestAdd()
        {
            VerifyExists();
            _gunId = MyCollection.GetTopId(_databasePath, out _errOut);
            bool value = Pictures.HasDefaultPicture(_databasePath, _gunId, AppDomain.CurrentDomain.BaseDirectory, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mgc_default.jpg"), out _errOut, true);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method IsFirstPicTest.
        /// </summary>
        [TestMethod, TestCategory("Pictures")]
        public void IsFirstPicTest()
        {
            VerifyExists();
            _gunId = MyCollection.GetTopId(_databasePath, out _errOut);
            TestContext.WriteLine($"Using GunID {_gunId}");
            bool value = Pictures.IsFirstPic(_databasePath, _gunId, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method CountPicsTest.
        /// </summary>
        [TestMethod, TestCategory("Pictures")]
        public void CountPicsTest()
        {
            VerifyExists();
            _gunId = MyCollection.GetTopId(_databasePath, out _errOut);
            TestContext.WriteLine($"Using GunID {_gunId}");
            long value = Pictures.CountPics(_databasePath, _gunId, out _errOut);
            TestContext.WriteLine($"Number of pics in collection: {value}");
            General.HasTrueValue(value > 0, _errOut);
        }

        public void VerifyExists()
        {
            _gunId = MyCollection.GetTopId(_databasePath, out _errOut);
            long value = Pictures.CountPics(_databasePath, _gunId, out _errOut);
            if (value == 0)
            {
                Pictures.Save(_databasePath, _picPath, AppDomain.CurrentDomain.BaseDirectory, _gunId, "test", "test", out _errOut);
                Pictures.SetMainPictures(_databasePath, out _errOut);
            }
        }

        /// <summary>
        /// Defines the test method SaveTest.
        /// </summary>
        [TestMethod, TestCategory("Pictures")]
        public void SaveTest()
        {
           
            _gunId = MyCollection.GetTopId(_databasePath, out _errOut);
            TestContext.WriteLine($"Using GunID {_gunId}");
            bool value = Pictures.Save(_databasePath, _picPath, AppDomain.CurrentDomain.BaseDirectory, _gunId, "test",
                "test", out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        
        /// <summary>
        /// Defines the test method GetPicturesForFirearmTest.
        /// </summary>
        [TestMethod, TestCategory("Pictures")]
        public void GetPicturesForFirearmTest()
        {
            VerifyExists();
            _gunId = MyCollection.GetTopId(_databasePath, out _errOut);
            TestContext.WriteLine($"Using GunID {_gunId}");
            List<PictureDetails> value = Pictures.GetList(_databasePath, _gunId, out _errOut);
            TestContext.WriteLine(PrintListValues.PictureDetailsList(value));
            General.HasTrueValue(value.Count > 0, _errOut);
        }

        /// <summary>
        /// Defines the test method GetPicturesForFirearmTest.
        /// </summary>
        [TestMethod, TestCategory("Pictures")]
        public void GetPicturesTest()
        {
            List<PictureDetails> value = Pictures.GetList(_databasePath, out _errOut);
            TestContext.WriteLine(PrintListValues.PictureDetailsList(value));
            General.HasTrueValue(value.Count > 0, _errOut);
        }

        [TestMethod, TestCategory("Pictures")]
        public void SetPictureOrderTest()
        {
            int picOrder = 1;
            _gunId = MyCollection.GetTopId(_databasePath, out _errOut);
            var picId = Pictures.GetFirstPictureInCollection(_databasePath, _gunId, out _errOut);
            bool passed = Pictures.SetPictureOrder(_databasePath, picId, picOrder, out _errOut);
            TestContext.WriteLine($"Set Picture order for Picture id {picId} for firearm {_gunId} to {picOrder}");
            General.HasTrueValue(passed, _errOut);
        }

        [TestMethod, TestCategory("Pictures")]
        public void GetNextOrderNumberTest()
        {
            _gunId = MyCollection.GetTopId(_databasePath, out _errOut);
            int NextOrder = Pictures.GetNextOrderNumber(_databasePath, _gunId, out _errOut);
            TestContext.WriteLine($"Next Order for Pictures for firearm {_gunId} is {NextOrder}");
            General.HasTrueValue(NextOrder != 0, _errOut);
        }

        [TestMethod, TestCategory("Pictures")]
        public void ResetPicturesForFirearmTest()
        {
            _gunId = MyCollection.GetTopId(_databasePath, out _errOut);
            bool pass = Pictures.ResetPictures(_databasePath, _gunId, out _errOut);
            TestContext.WriteLine($"Reset Pic Order for firearm {_gunId} to 0");
            List<PictureDetails> value = Pictures.GetList(_databasePath, out _errOut);
            TestContext.WriteLine(PrintListValues.PictureDetailsList(value));
            General.HasTrueValue(pass, _errOut);
        }

        [TestMethod, TestCategory("Pictures")]
        public void ResetPicturesForAllTest()
        {
            bool pass = Pictures.ResetPictures(_databasePath, out _errOut);
            TestContext.WriteLine($"Reset Pic Order for all firearms to 0");
            List<PictureDetails> value = Pictures.GetList(_databasePath, _gunId, out _errOut);
            TestContext.WriteLine(PrintListValues.PictureDetailsList(value));
            General.HasTrueValue(pass, _errOut);
        }
    }
}
