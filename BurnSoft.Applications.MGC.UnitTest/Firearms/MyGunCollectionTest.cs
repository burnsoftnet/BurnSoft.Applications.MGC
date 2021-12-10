﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
        /// <summary>
        /// The full name
        /// </summary>
        private string _fullName;
        /// <summary>
        /// The manufactures identifier
        /// </summary>
        private long _manufacturesId;
        /// <summary>
        /// The model identifier
        /// </summary>
        private long _modelId;
        /// <summary>
        /// The nationality identifier
        /// </summary>
        private long _nationalityId;
        /// <summary>
        /// The grip identifier
        /// </summary>
        private long _gripId;
        /// <summary>
        /// The serial number
        /// </summary>
        private string _serialNumber;
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            // Vs2019.GetSetting("", TestContext);
            BSOtherObjects obj = new BSOtherObjects();
            _errOut = @"";
            _databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Vs2019.GetSetting("DatabasePath", TestContext));
            _gunId = Vs2019.IGetSetting("MyGunCollectionID", TestContext);
            _shopOldName =obj.FC(Vs2019.GetSetting("MyGunCollection_ShopOldName", TestContext));
            _shopNewName = obj.FC(Vs2019.GetSetting("MyGunCollection_ShopNewName", TestContext));
            _fullName = "Glock Super Carry";
            _serialNumber = "RIA2323423";
            _manufacturesId = Manufacturers.GetId(_databasePath, "Glock", out _errOut);
            _modelId = Models.GetId(_databasePath, "G26", _manufacturesId, out _errOut);
            _nationalityId = Nationality.GetId(_databasePath, "USA", out _errOut);
            _gripId = Grips.GetId(_databasePath, "Plastic", out _errOut);
        }
        /// <summary>
        /// Defines the test method GetFirearmIdByFullName.
        /// </summary>
        [TestMethod, TestCategory("Gun Collection - Get Firearm ID")]
        public void GetFirearmIdByFullName()
        {
            long gunId = MyCollection.GetId(_databasePath, _fullName, out _errOut);
            TestContext.WriteLine($"FireArm Id from full name {_fullName} is {gunId}");
            General.HasTrueValue(gunId > 0, _errOut);
        }

        [TestMethod, TestCategory("Gun Collection - Verify Firearm by Name")]
        public void VerifyByFullName()
        {
            bool value = false;
            long gunId = 0;
            try
            {
                VerifyExists();
                gunId = MyCollection.GetId(_databasePath, _fullName, out _errOut);
                if (_errOut.Length > 0) throw new Exception(_errOut);
                value = MyCollection.Verify(_databasePath, gunId, _fullName, out _errOut);
                if (_errOut.Length > 0) throw new Exception(_errOut);
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
            }

            string msg = value ? "does exists" : "does not exist";
            TestContext.WriteLine($"FireArm Id from full name {_fullName} is {gunId} and {msg}");
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method VerifyByFullNameAndSerial.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        [TestMethod, TestCategory("Gun Collection - Verify Firearm by Name and serial")]
        public void VerifyByFullNameAndSerial()
        {
            bool value = false;
            long gunId = 0;
            try
            {
                VerifyExists();
                gunId = MyCollection.GetId(_databasePath, _fullName, out _errOut);
                if (_errOut.Length > 0) throw new Exception(_errOut);
                value = MyCollection.Verify(_databasePath, gunId, _fullName,_serialNumber, out _errOut);
                if (_errOut.Length > 0) throw new Exception(_errOut);
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
            }

            string msg = value ? "does exists" : "does not exist";
            TestContext.WriteLine($"FireArm Id from full name {_fullName} is {gunId} and {msg}");
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method RemoveFirearm.
        /// </summary>
        [TestMethod, TestCategory("Gun Collection - Delete Firearm")]
        public void RemoveFirearm()
        {
            long gunId = MyCollection.GetId(_databasePath, _fullName, out _errOut);
            TestContext.WriteLine($"FireArm Id from full name {_fullName} is {gunId}");
            bool value = MyCollection.Delete(_databasePath, gunId, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Verifies the does not exists.
        /// </summary>
        private void VerifyDoesNotExists()
        {
            if (MyCollection.Exists(_databasePath, _fullName, out _errOut))
            {
                long gunId = MyCollection.GetId(_databasePath, _fullName, out _errOut);
                MyCollection.Delete(_databasePath, gunId, out _errOut);
            }
        }
        /// <summary>
        /// Verifies the exists.
        /// </summary>
        private void VerifyExists()
        {
            if (!MyCollection.Exists(_databasePath, _fullName, out _errOut))
            {
                MyCollection.Add(_databasePath, false, 2, _manufacturesId,
                    _fullName, "G26", _modelId, _serialNumber, "Pistol: Semi-Auto - SA/DA", "9mm Luger", "black",
                    "New", " ", _nationalityId, _gripId, "16oz", "4", "plastic", "5 in", " ", " ", "single", "10 round mag",
                    "iron", "400.00", "billy bob", "500.00", " ", "MSRP", "500.00", "Safe", " ", " ", "1990", " ",
                    DateTime.Now.ToString(CultureInfo.InvariantCulture), false, " ", "11/09/2021 14:20:45", " ", " ",
                    true, "1-8", "2 lbs", " ", "Modern", "11/09/2021 14:20:45", false, " ", out _errOut);
            }
        }
        /// <summary>
        /// Defines the test method AddFirearm.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        [TestMethod, TestCategory("Gun Collection - Add Firearm")]
        public void AddFirearm()
        {
            bool value = false;
            try
            {
                VerifyDoesNotExists();

                value = MyCollection.Add(_databasePath, false, 2, _manufacturesId,
                    _fullName, "G26", _modelId, "RIA2323423", "Pistol: Semi-Auto - SA/DA", "9mm Luger", "black",
                    "New", " ", _nationalityId, _gripId, "16oz", "4", "plastic", "5 in", " ", " ", "single", "10 round mag",
                    "iron", "400.00", "billy bob", "500.00", " ", "MSRP", "500.00", "Safe", " ", " ", "1990", " ",
                    DateTime.Now.ToString(CultureInfo.InvariantCulture), false, " ", "11/09/2021 14:20:45", " ", " ", true, "1-8", "2 lbs", " ", "Modern", "11/09/2021 14:20:45", false," ", out _errOut);
                if (_errOut.Length > 0) throw new Exception(_errOut);
                bool exists = MyCollection.Exists(_databasePath, _fullName, out _errOut);
                if (_errOut.Length > 0) throw new Exception(_errOut);
                value = exists;
            }
            catch (Exception e)
            {
                _errOut = e.Message;
            }
            
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method UpdateFirearm.
        /// </summary>
        [TestMethod, TestCategory("Gun Collection - Update Firearm")]
        public void UpdateFirearm()
        {
            VerifyExists();

            long gunId = MyCollection.GetId(_databasePath, _fullName, out _errOut);

            bool value = MyCollection.Update(_databasePath, (int)gunId, false, 2, _manufacturesId, "G26", _modelId, "RIA2323423", "Pistol: Semi-Auto - SA/DA", "9mm Luger", "black",
                "New", " ", _nationalityId, _gripId, "18oz", "4", "plastic", "5 in", " ", " ", "single", "10 round mag",
                "iron", "400.00", "billy bob", "500.00", " ", "MSRP", "500.00", "Safe", " ", " ", "1990", " ",
                DateTime.Now.ToString(CultureInfo.InvariantCulture), false, " ", "11/09/2021 14:20:45", " ", " ",
                true, "1-8", "1 lbs", " ", "Modern", "2021/11/02",false,false,"","", out _errOut);

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
                    TestContext.WriteLine($"WaS Stolen: {g.WasStolen}");
                    TestContext.WriteLine($"Was Sold: {g.WasSold}");
                    TestContext.WriteLine($"Is Stogun: {g.IsShotGun}");
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
