using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurnSoft.Applications.MGC.Other;
using BurnSoft.Applications.MGC.Types;
using BurnSoft.Applications.MGC.UnitTest.Settings;
using BurnSoft.Universal;

namespace BurnSoft.Applications.MGC.UnitTest.Other
{
    [TestClass]
    public class WishlistTest
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
        /// The wish list manufacturer
        /// </summary>
        private string _wishListManufacturer;
        /// <summary>
        /// The wish list model
        /// </summary>
        private string _wishListModel;
        /// <summary>
        /// The wish list place to buy
        /// </summary>
        private string _wishListPlaceToBuy;
        /// <summary>
        /// The wish list qty
        /// </summary>
        private string _wishListQty;
        /// <summary>
        /// The wish list price
        /// </summary>
        private string _wishListPrice;
        /// <summary>
        /// The wish list notes
        /// </summary>
        private string _wishListNotes;

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
            _wishListManufacturer = obj.FC(Vs2019.GetSetting("WishList_Manufacturer", TestContext));
            _wishListModel = obj.FC(Vs2019.GetSetting("WishList_Model", TestContext));
            _wishListPlaceToBuy = obj.FC(Vs2019.GetSetting("WishList_PlaceToBuy", TestContext));
            _wishListQty = obj.FC(Vs2019.GetSetting("WishList_Qty", TestContext));
            _wishListPrice = obj.FC(Vs2019.GetSetting("WishList_Price", TestContext));
            _wishListNotes = obj.FC(Vs2019.GetSetting("WishList_Notes", TestContext));

        }
        /// <summary>
        /// Verifies the doesnt exist.
        /// </summary>
        private void VerifyDoesntExist()
        {
            if (WishList.Exists(_databasePath, _wishListManufacturer, _wishListModel, out _errOut))
            {
                long id = WishList.GetId(_databasePath, _wishListManufacturer, _wishListModel, out _errOut);
                WishList.Delete(_databasePath, id, out _errOut);
            }
        }
        /// <summary>
        /// Verifies the exists.
        /// </summary>
        private void VerifyExists()
        {
            if (!WishList.Exists(_databasePath, _wishListManufacturer, _wishListModel, out _errOut))
            {
                WishList.Add(_databasePath, _wishListManufacturer, _wishListModel, _wishListPlaceToBuy, _wishListQty, _wishListPrice, _wishListNotes,out _errOut);
            }
        }
        
        /// <summary>
        /// Defines the test method AddTest.
        /// </summary>
        [TestMethod, TestCategory("Wishlist")]
        public void AddTest()
        {
            VerifyDoesntExist();
            bool value = WishList.Add(_databasePath, _wishListManufacturer, _wishListModel, _wishListPlaceToBuy, _wishListQty, _wishListPrice, _wishListNotes, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method ExistsTest.
        /// </summary>
        [TestMethod, TestCategory("Wishlist")]
        public void ExistsTest()
        {
            VerifyExists();
            bool value = WishList.Exists(_databasePath, _wishListManufacturer, _wishListModel, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method GetId.
        /// </summary>
        [TestMethod, TestCategory("Wishlist")]
        public void GetId()
        {
            VerifyExists();
            long value = WishList.GetId(_databasePath, _wishListManufacturer, _wishListModel, out _errOut);
            TestContext.WriteLine($"ID = {value}");
            General.HasTrueValue(value > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method UpdateTest.
        /// </summary>
        [TestMethod, TestCategory("Wishlist")]
        public void UpdateTest()
        {
            VerifyExists();
            long id = WishList.GetId(_databasePath, _wishListManufacturer, _wishListModel, out _errOut);

            bool value = WishList.Update(_databasePath, id, _wishListManufacturer, _wishListModel, _wishListPlaceToBuy,
                _wishListQty, _wishListPrice, $"UPDATE TEST {_wishListNotes}", out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        

        /// <summary>
        /// Defines the test method DeleteTest.
        /// </summary>
        [TestMethod, TestCategory("Wishlist")]
        public void DeleteTest()
        {
            VerifyExists();
            long id = WishList.GetId(_databasePath, _wishListManufacturer, _wishListModel, out _errOut);
            bool value = WishList.Delete(_databasePath, id, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method ListByIDTest.
        /// </summary>
        [TestMethod, TestCategory("Wishlist")]
        public void ListByIdTest()
        {
            VerifyExists();
            long id = WishList.GetId(_databasePath, _wishListManufacturer, _wishListModel, out _errOut);
            List<WishlistList> value = WishList.List(_databasePath, (int)id, out _errOut);
            TestContext.WriteLine(DebugHelpers.PrintListValues.WishListList(value));
            General.HasTrueValue(value.Count > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method ListTest.
        /// </summary>
        [TestMethod, TestCategory("Wishlist")]
        public void ListTest()
        {
            VerifyExists();
            List<WishlistList> value = WishList.List(_databasePath, out _errOut);
            TestContext.WriteLine(DebugHelpers.PrintListValues.WishListList(value));
            General.HasTrueValue(value.Count > 0, _errOut);
        }
    }
}
