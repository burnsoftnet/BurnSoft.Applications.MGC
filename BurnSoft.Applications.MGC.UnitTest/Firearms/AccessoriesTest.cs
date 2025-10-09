using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurnSoft.Applications.MGC.Firearms;
using BurnSoft.Applications.MGC.Types;
using BurnSoft.Applications.MGC.UnitTest.Settings;
using BurnSoft.Universal;
using System;

namespace BurnSoft.Applications.MGC.UnitTest.Firearms
{
    [TestClass]
    public class AccessoriesTest
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
        /// The accessories manufacturer
        /// </summary>
        private string _accessoriesManufacturer;
        /// <summary>
        /// The accessories name
        /// </summary>
        private string _accessoriesName;
        /// <summary>
        /// The accessories serial number
        /// </summary>
        private string _accessoriesSerialNumber;
        /// <summary>
        /// The accessories condition
        /// </summary>
        private string _accessoriesCondition;
        /// <summary>
        /// The accessories notes
        /// </summary>
        private string _accessoriesNotes;
        /// <summary>
        /// The accessories use
        /// </summary>
        private string _accessoriesUse;
        /// <summary>
        /// The accessories pur value
        /// </summary>
        private double _accessoriesPurValue;
        /// <summary>
        /// The accessories application value
        /// </summary>
        private double _accessoriesAppValue;
        /// <summary>
        /// The accessories civ
        /// </summary>
        private bool _accessoriesCiv;
        /// <summary>
        /// The accessories ic
        /// </summary>
        private bool _accessoriesIc;
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
            _accessoriesManufacturer = obj.FC(Vs2019.GetSetting("Accessories_Manufacturer", TestContext));
            _accessoriesName = obj.FC(Vs2019.GetSetting("Accessories_Name", TestContext));
            _accessoriesSerialNumber = obj.FC(Vs2019.GetSetting("Accessories_serialNumber", TestContext));
            _accessoriesCondition = obj.FC(Vs2019.GetSetting("Accessories_condition", TestContext));
            _accessoriesNotes = obj.FC(Vs2019.GetSetting("Accessories_notes", TestContext));
            _accessoriesUse = obj.FC(Vs2019.GetSetting("Accessories_use", TestContext));
            _accessoriesPurValue =Vs2019.DGetSetting("Accessories_purValue", TestContext);
            _accessoriesAppValue = Vs2019.DGetSetting("Accessories_appValue", TestContext);
            _accessoriesCiv = Vs2019.BGetSetting("Accessories_civ", TestContext);
            _accessoriesIc = Vs2019.BGetSetting("Accessories_ic", TestContext);
        }
        /// <summary>
        /// Verifies the doesnt exist.
        /// </summary>
        private void VerifyDoesntExist()
        {
            if (Accessories.Exists(_databasePath, _gunId, _accessoriesManufacturer, _accessoriesName,
                _accessoriesSerialNumber, _accessoriesCondition, _accessoriesNotes, _accessoriesUse,
                _accessoriesPurValue, _accessoriesAppValue, _accessoriesCiv, _accessoriesIc, out _errOut))
            {
                long id = Accessories.GetId(_databasePath, _gunId, _accessoriesManufacturer, _accessoriesName,
                    _accessoriesSerialNumber, _accessoriesCondition, _accessoriesNotes, _accessoriesUse,
                    _accessoriesPurValue, _accessoriesAppValue, _accessoriesCiv, _accessoriesIc, out _errOut);
                Accessories.Delete(_databasePath, id, out _errOut);
            }
        }
        /// <summary>
        /// Verifies the exists.
        /// </summary>
        private void VerifyExists()
        {
            if (!Accessories.Exists(_databasePath, _gunId, _accessoriesManufacturer, _accessoriesName,
                _accessoriesSerialNumber, _accessoriesCondition, _accessoriesNotes, _accessoriesUse,
                _accessoriesPurValue, _accessoriesAppValue, _accessoriesCiv, _accessoriesIc, out _errOut))
            {
                Accessories.Add(_databasePath, _gunId, _accessoriesManufacturer, _accessoriesName,
                    _accessoriesSerialNumber, _accessoriesCondition, _accessoriesNotes, _accessoriesUse,
                    _accessoriesPurValue, _accessoriesAppValue, _accessoriesCiv, _accessoriesIc, out _errOut);
            }
        }
        /// <summary>
        /// Prints the list.
        /// </summary>
        /// <param name="value">The value.</param>
        private void PrintList(List<AccessoriesList> value)
        {
            if (value.Count > 0)
            {
                foreach (AccessoriesList v in value)
                {
                    TestContext.WriteLine($"id :{v.Id}");
                    TestContext.WriteLine($"gun id: {v.GunId}");
                    TestContext.WriteLine($"manufacturer: {v.Manufacturer}");
                    TestContext.WriteLine($"Model: {v.Model}");
                    TestContext.WriteLine($"Condition: {v.Condition}");
                    TestContext.WriteLine($"AppriasedValue: {v.AppriasedValue}");
                    TestContext.WriteLine($"CountInValue: {v.CountInValue}");
                    TestContext.WriteLine($"IsChoke: {v.IsChoke}");
                    TestContext.WriteLine($"LastSync: {v.LastSync}");
                    TestContext.WriteLine($"Notes: {v.Notes}");
                    TestContext.WriteLine($"PurchaseValue: {v.PurchaseValue}");
                    TestContext.WriteLine($"SerialNumber: {v.SerialNumber}");
                    TestContext.WriteLine($"Use: {v.Use}");
                    TestContext.WriteLine($"");
                    TestContext.WriteLine($"--------------------------");
                    TestContext.WriteLine($"");
                }
            }
        }

        /// <summary>
        /// Defines the test method AddTest.
        /// </summary>
        [TestMethod, TestCategory("Accessories")]
        public void AddTest()
        {
            VerifyDoesntExist();
            bool value = Accessories.Add(_databasePath, _gunId, _accessoriesManufacturer, _accessoriesName,
                _accessoriesSerialNumber, _accessoriesCondition, _accessoriesNotes, _accessoriesUse,
                _accessoriesPurValue, _accessoriesAppValue, _accessoriesCiv, _accessoriesIc, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method ExistsTest.
        /// </summary>
        [TestMethod, TestCategory("Accessories")]
        public void ExistsTest()
        {
            VerifyExists();
            bool value = Accessories.Exists(_databasePath, _gunId, _accessoriesManufacturer, _accessoriesName,
                _accessoriesSerialNumber, _accessoriesCondition, _accessoriesNotes, _accessoriesUse,
                _accessoriesPurValue, _accessoriesAppValue, _accessoriesCiv, _accessoriesIc, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method GetId.
        /// </summary>
        [TestMethod, TestCategory("Accessories")]
        public void GetId()
        {
            VerifyExists();
            long value = Accessories.GetId(_databasePath, _gunId, _accessoriesManufacturer, _accessoriesName,
                _accessoriesSerialNumber, _accessoriesCondition, _accessoriesNotes, _accessoriesUse,
                _accessoriesPurValue, _accessoriesAppValue, _accessoriesCiv, _accessoriesIc, out _errOut);
            TestContext.WriteLine($"ID = {value}");
            General.HasTrueValue(value > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method UpdateTest.
        /// </summary>
        [TestMethod, TestCategory("Accessories")]
        public void UpdateTest()
        {
            VerifyExists();
            long id = Accessories.GetId(_databasePath, _gunId, _accessoriesManufacturer, _accessoriesName,
                _accessoriesSerialNumber, _accessoriesCondition, _accessoriesNotes, _accessoriesUse,
                _accessoriesPurValue, _accessoriesAppValue, _accessoriesCiv, _accessoriesIc, out _errOut);

            bool value = Accessories.Update(_databasePath, id, _gunId, _accessoriesManufacturer, _accessoriesName,
                _accessoriesSerialNumber, _accessoriesCondition, $"UPDATE TEST {_accessoriesNotes}", _accessoriesUse,
                _accessoriesPurValue, _accessoriesAppValue, _accessoriesCiv, _accessoriesIc, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method GetFullNameTest.
        /// </summary>
        [TestMethod, TestCategory("Accessories")]
        public void GetFullNameTest()
        {
            VerifyExists();
            long id = Accessories.GetId(_databasePath, _gunId, _accessoriesManufacturer, _accessoriesName,
                _accessoriesSerialNumber, _accessoriesCondition, _accessoriesNotes, _accessoriesUse,
                _accessoriesPurValue, _accessoriesAppValue, _accessoriesCiv, _accessoriesIc, out _errOut);

            string value = Accessories.GetFullName(_databasePath, id, out _errOut);
            TestContext.WriteLine($"Full Name: {value}");
            General.HasTrueValue(value.Length > 0, _errOut);
        }

        /// <summary>
        /// Defines the test method DeleteTest.
        /// </summary>
        [TestMethod, TestCategory("Accessories")]
        public void DeleteTest()
        {
            VerifyExists();
            _gunId = Convert.ToInt32(MyCollection.GetLastId(_databasePath, out _errOut));
            long id = Accessories.GetId(_databasePath, _gunId, _accessoriesManufacturer, _accessoriesName,
                _accessoriesSerialNumber, _accessoriesCondition, _accessoriesNotes, _accessoriesUse,
                _accessoriesPurValue, _accessoriesAppValue, _accessoriesCiv, _accessoriesIc, out _errOut);
            bool value = Accessories.Delete(_databasePath, id, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method ListByIDTest.
        /// </summary>
        [TestMethod, TestCategory("Accessories")]
        public void ListByIdTest()
        {
            VerifyExists();
            long id = Accessories.GetId(_databasePath, _gunId, _accessoriesManufacturer, _accessoriesName,
                _accessoriesSerialNumber, _accessoriesCondition, _accessoriesNotes, _accessoriesUse,
                _accessoriesPurValue, _accessoriesAppValue, _accessoriesCiv, _accessoriesIc, out _errOut);
            List<AccessoriesList> value = Accessories.List(_databasePath, (int)id, out _errOut);
            PrintList(value);
            General.HasTrueValue(value.Count > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method ListByGunIdTest.
        /// </summary>
        [TestMethod, TestCategory("Accessories")]
        public void ListByGunIdTest()
        {
            VerifyExists();
            List<AccessoriesList> value = Accessories.List(_databasePath, _gunId, out _errOut);
            PrintList(value);
            General.HasTrueValue(value.Count > 0, _errOut);
        }

        [TestMethod, TestCategory("Accessories")]
        public void CopyTest()
        {
            VerifyExists();
            long id = Accessories.GetId(_databasePath, _gunId, _accessoriesManufacturer, _accessoriesName,
                _accessoriesSerialNumber, _accessoriesCondition, _accessoriesNotes, _accessoriesUse,
                _accessoriesPurValue, _accessoriesAppValue, _accessoriesCiv, _accessoriesIc, out _errOut);

            bool value = Accessories.Copy(_databasePath, id, _gunId, out _errOut);
            General.HasTrueValue(value, _errOut);
            List<AccessoriesList> lst = Accessories.List(_databasePath, (long)_gunId, out _errOut);
            PrintList(lst);
        }
        /// <summary>
        /// Defines the test method ListTest.
        /// </summary>
        [TestMethod, TestCategory("Accessories")]
        public void ListTest()
        {
            VerifyExists();
            List<AccessoriesList> value = Accessories.List(_databasePath, out _errOut);
            PrintList(value);
            General.HasTrueValue(value.Count > 0, _errOut);
        }
    }
}
