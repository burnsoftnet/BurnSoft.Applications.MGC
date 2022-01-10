using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BurnSoft.Applications.MGC.UnitTest.Settings;
using BurnSoft.Universal;

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
        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}
