using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BurnSoft.Applications.MGC.Firearms;
using BurnSoft.Applications.MGC.Types;
using BurnSoft.Applications.MGC.UnitTest.Settings;
using BurnSoft.Universal;
// ReSharper disable ConvertIfStatementToConditionalTernaryExpression

namespace BurnSoft.Applications.MGC.UnitTest.Firearms
{
    [TestClass]
    public class MyGunCollectionTest
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
        /// The shop old name
        /// </summary>
        private string _shopOldName;
        /// <summary>
        /// The shop new name
        /// </summary>
        private string _shopNewName;

        private string fullName;
        private long manufacturesId;
        private long modelId;
        private long nationalityId;
        private long gripId;
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
            _shopOldName =obj.FC(Vs2019.GetSetting("MyGunCollection_ShopOldName", TestContext));
            _shopNewName = obj.FC(Vs2019.GetSetting("MyGunCollection_ShopNewName", TestContext));
            fullName = "Glock Super Carry";
            manufacturesId = Manufacturers.GetId(_databasePath, "Glock", out _errOut);
            modelId = Models.GetId(_databasePath, "G26", manufacturesId, out _errOut);
            nationalityId = Nationality.GetId(_databasePath, "USA", out _errOut);
            gripId = Grips.GetId(_databasePath, "Plastic", out _errOut);
        }

        [TestMethod, TestCategory("Gun Collection - Get Firearm ID")]
        public void GetFirearmIdByFullName()
        {
            long gunId = MyCollection.GetId(_databasePath, fullName, out _errOut);
            TestContext.WriteLine($"FireArm Id from full name {fullName} is {gunId}");
            General.HasTrueValue(gunId > 0, _errOut);
        }

        [TestMethod, TestCategory("Gun Collection - Delete Firearm")]
        public void RemoveFirearm()
        {
            long gunId = MyCollection.GetId(_databasePath, fullName, out _errOut);
            TestContext.WriteLine($"FireArm Id from full name {fullName} is {gunId}");
            bool value = MyCollection.Delete(_databasePath, gunId, out _errOut);
            General.HasTrueValue(value, _errOut);
        }

        [TestMethod, TestCategory("Gun Collection - Add Firearm")]
        public void AddFirearm()
        {
            //TODO: #13 Finish Unit Test
            bool value = false;
            try
            {
                if (MyCollection.Exists(_databasePath, fullName, out _errOut))
                {
                    long gunId = MyCollection.GetId(_databasePath, fullName, out _errOut);
                    MyCollection.Delete(_databasePath, gunId, out _errOut);
                }

                value = MyCollection.Add(_databasePath, false, 0, manufacturesId,
                    fullName, "G26", modelId, "RIA2323423", "Pistol: Semi-Auto - SA/DA", "9mm Luger", "black",
                    "New", " ", nationalityId, gripId, "16oz", "4", "plastic", "5 in", " ", " ", "single", "10 round mag",
                    "iron", "400.00", "billy bob", "500.00", " ", "MSRP", "500.00", "Safe", " ", " ", "1990", " ",
                    DateTime.Now.ToString(), false, " ", " ", " ", " ", true, "1-8", "2 lbs", " ", "Modern", " ", false," ", out _errOut);
                if (_errOut.Length > 0) throw new Exception(_errOut);
                bool exists = MyCollection.Exists(_databasePath, fullName, out _errOut);
                if (_errOut.Length > 0) throw new Exception(_errOut);
                value = exists;
            }
            catch (Exception e)
            {
                _errOut = e.Message;
            }
            
            General.HasTrueValue(value, _errOut);
        }

        [TestMethod, TestCategory("Gun Collection - Update Firearm")]
        public void UpdateFirearm()
        {
            //TODO: #19 Finish Unit Test
            //bool value = true;
            long manufacturesId = Manufacturers.GetId(_databasePath, "Glock", out _errOut);
            long modelId = Models.GetId(_databasePath, "", manufacturesId, out _errOut);
            long nationalityId = Nationality.GetId(_databasePath, "USA", out _errOut);
            long gripId = Grips.GetId(_databasePath, "Plastice", out _errOut);
            bool value = MyCollection.Add(_databasePath, false, 0, manufacturesId,
                "Glock Super Carry", "G26", modelId, "RIA2323423", "pistol:single action", "9mm luger", "black",
                "new in box", "", nationalityId, gripId, "16oz", "4", "plastice", "5 in", "", "", "single", "10 round mag",
                "iron", "400.00", "billy bob", "500.00", "10/31/2021", "MSRP", "500.00", "Safe", "", "", "1990", "",
                DateTime.Now.ToString(), false, "", "", "", "", true, "1-8", "2 lbs", "", "Modern", "", false, "", out _errOut);

            General.HasTrueValue(value, _errOut);
        }

        /// <summary>
        /// Prints the list.
        /// </summary>
        /// <param name="value">The value.</param>
        private void PrintList(List<GunCollectionList> value)
        {
            if (value.Count > 0)
            {
                foreach (GunCollectionList g in value)
                {
                    TestContext.WriteLine($"id : {g.Id}");
                    TestContext.WriteLine($"Full Name: {g.FullName}");
                    TestContext.WriteLine($"Owner id: {g.Oid}");
                    TestContext.WriteLine($"Manufacture Id: {g.Mid}");
                    TestContext.WriteLine($"ModelName: {g.ModelName}");
                    TestContext.WriteLine($"Model Id: {g.ModelId}");
                    TestContext.WriteLine($"SerialNumber: {g.SerialNumber}");
                    TestContext.WriteLine($"Type: {g.Type}");
                    TestContext.WriteLine($"Caliber: {g.Caliber}");
                    TestContext.WriteLine($"Caliber 2: {g.PetLoads}");
                    TestContext.WriteLine($"Caliber 3: {g.Caliber3}");
                    TestContext.WriteLine($"Feed System: {g.FeedSystem}");
                    TestContext.WriteLine($"Finish: {g.Finish}");
                    TestContext.WriteLine($"Condition: {g.Condition}");
                    TestContext.WriteLine($"CustomId: {g.CustomId}");
                    TestContext.WriteLine($"NationalityId: {g.NationalityId}");
                    TestContext.WriteLine($"BarrelLength: {g.BarrelLength}");
                    TestContext.WriteLine($"GripId: {g.GripId}");
                    TestContext.WriteLine($"Qty: {g.Qty}");
                    TestContext.WriteLine($"Weight: {g.Weight}");
                    TestContext.WriteLine($"Height: {g.Height}");
                    TestContext.WriteLine($"StockType: {g.StockType}");
                    TestContext.WriteLine($"BarrelHeight: {g.BarrelHeight}");
                    TestContext.WriteLine($"BarrelWidth: {g.BarrelWidth}");
                    TestContext.WriteLine($"Action: {g.Action}");
                    TestContext.WriteLine($"Sights: {g.Sights}");
                    TestContext.WriteLine($"PurchasePrice: {g.PurchasePrice}");
                    TestContext.WriteLine($"PurchaseFrom: {g.PurchaseFrom}");
                    TestContext.WriteLine($"AppriasedBy: {g.AppriasedBy}");
                    TestContext.WriteLine($"AppriasedValue: {g.AppriasedValue}");
                    TestContext.WriteLine($"AppriaserId: {g.AppriaserId}");
                    TestContext.WriteLine($"AppraisalDate: {g.AppraisalDate}");
                    TestContext.WriteLine($"InsuredValue: {g.InsuredValue}");
                    TestContext.WriteLine($"StorageLocation: {g.StorageLocation}");
                    TestContext.WriteLine($"ConditionComments: {g.ConditionComments}");
                    TestContext.WriteLine($"AdditionalNotes: {g.AdditionalNotes}");
                    TestContext.WriteLine($"HasAccessory: {g.HasAccessory}");
                    TestContext.WriteLine($"DateProduced: {g.DateProduced}");
                    TestContext.WriteLine($"DateTimeAddedInDb: {g.DateTimeAddedInDb}");
                    TestContext.WriteLine($"ItemSold: {g.ItemSold}");
                    TestContext.WriteLine($"Selled Id: {g.Sid}");
                    TestContext.WriteLine($"Buyer Id: {g.Bid}");
                    TestContext.WriteLine($"Date Sold: {g.DateSold}");
                    TestContext.WriteLine($"Is C&R Items: {g.IsCAndR}");
                    TestContext.WriteLine($"DateTimeAdded: {g.DateTimeAddedInDb}");
                    TestContext.WriteLine($"Importer: {g.Importer}");
                    TestContext.WriteLine($"RemanufactureDate: {g.RemanufactureDate}");
                    TestContext.WriteLine($"Poi: {g.Poi}");
                    TestContext.WriteLine($"HasMb : {g.HasMb}");
                    TestContext.WriteLine($"DbId: {g.DbId}");
                    TestContext.WriteLine($"ShotGunChoke: {g.ShotGunChoke}");
                    TestContext.WriteLine($"IsInBoundBook: {g.IsInBoundBook}");
                    TestContext.WriteLine($"TwistRate: {g.TwistRate}");
                    TestContext.WriteLine($"TriggerPullInPounds: {g.TriggerPullInPounds}");
                    TestContext.WriteLine($"Classification: {g.Classification}");
                    TestContext.WriteLine($"DateOfCAndR: {g.DateOfCAndR}");
                    TestContext.WriteLine($"LastSyncDate: {g.LastSyncDate}");
                    TestContext.WriteLine($"IsClass3Item: {g.IsClass3Item}");
                    TestContext.WriteLine($"Class3Owner: {g.Class3Owner}");
                    TestContext.WriteLine("--------------------------------------");
                    TestContext.WriteLine("");
                }
            }
        }
        /// <summary>
        /// Defines the test method GetList.
        /// </summary>
        [TestMethod, TestCategory("Gun Collection - Get From Table")]
        public void GetList()
        {
            List<GunCollectionList> value = MyCollection.GetList(_databasePath, _gunId, out _errOut);
            PrintList(value);
            General.HasTrueValue(value.Count > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method GetListAll.
        /// </summary>
        [TestMethod, TestCategory("Gun Collection - Get From Table")]
        public void GetListAll()
        {
            List<GunCollectionList> value = MyCollection.GetList(_databasePath, out _errOut);
            PrintList(value);
            General.HasTrueValue(value.Count > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method UpdateShopNames.
        /// </summary>
        [TestMethod, TestCategory("Gun Collection - Update")]
        public void UpdateShopNames()
        {
            bool value = MyCollection.UpdateShopName(_databasePath, _shopNewName, _shopOldName, out _errOut);
            if (value)
            {
                TestContext.WriteLine($"Was able to update database and change name from {_shopOldName} to {_shopNewName}");
            }
            else
            {
                TestContext.WriteLine($"Was not able to update database and change name from {_shopOldName} to {_shopNewName}");
            }
            General.HasTrueValue(value, _errOut);
        }
    }
}
