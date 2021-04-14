using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurnSoft.Applications.MGC.Firearms;
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
        /// The gun identifier
        /// </summary>
        private int _gunId;
        /// <summary>
        /// The database path
        /// </summary>
        private string _databasePath;
       
        private string WishList_Manufacturer;
        
        private string WishList_Model;
        
        private string WishList_PlaceToBuy;
        
        private string WishList_Qty;
        
        private string WishList_Price;
        
        private string WishList_Notes;

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
            WishList_Manufacturer = obj.FC(Vs2019.GetSetting("WishList_Manufacturer", TestContext));
            WishList_Model = obj.FC(Vs2019.GetSetting("WishList_Model", TestContext));
            WishList_PlaceToBuy = obj.FC(Vs2019.GetSetting("WishList_PlaceToBuy", TestContext));
            WishList_Qty = obj.FC(Vs2019.GetSetting("WishList_Qty", TestContext));
            WishList_Price = obj.FC(Vs2019.GetSetting("WishList_Price", TestContext));
            WishList_Notes = obj.FC(Vs2019.GetSetting("WishList_Notes", TestContext));

        }
        /// <summary>
        /// Verifies the doesnt exist.
        /// </summary>
        private void VerifyDoesntExist()
        {
            if (WishList.Exists(_databasePath, WishList_Manufacturer, WishList_Model, out _errOut))
            {
                long id = WishList.GetId(_databasePath, WishList_Manufacturer, WishList_Model, out _errOut);
                WishList.Delete(_databasePath, id, out _errOut);
            }
        }
        /// <summary>
        /// Verifies the exists.
        /// </summary>
        private void VerifyExists()
        {
            if (!WishList.Exists(_databasePath, WishList_Manufacturer, WishList_Model, out _errOut))
            {
                WishList.Add(_databasePath, WishList_Manufacturer, WishList_Model, WishList_PlaceToBuy, WishList_Qty, WishList_Price, WishList_Notes,out _errOut);
            }
        }
        /// <summary>
        /// Prints the list.
        /// </summary>
        /// <param name="value">The value.</param>
        private void PrintList(List<WishlistList> value)
        {
            if (value.Count > 0)
            {
                foreach (WishlistList v in value)
                {
                    TestContext.WriteLine($"id :{v.Id}");
                    TestContext.WriteLine($"manufacturer: {v.Manufacturer}");
                    TestContext.WriteLine($"Model: {v.Model}");
                    TestContext.WriteLine($"Qty: {v.Qty}");
                    TestContext.WriteLine($"Value: {v.Value}");
                    TestContext.WriteLine($"LastSync: {v.LastSync}");
                    TestContext.WriteLine($"Notes: {v.Notes}");
                    TestContext.WriteLine($"");
                    TestContext.WriteLine($"--------------------------");
                    TestContext.WriteLine($"");
                }
            }
        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
