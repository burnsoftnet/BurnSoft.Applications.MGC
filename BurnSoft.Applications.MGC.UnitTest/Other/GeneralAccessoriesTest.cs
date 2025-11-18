using BurnSoft.Applications.MGC.Firearms;
using BurnSoft.Applications.MGC.Other;
using BurnSoft.Applications.MGC.Types;
using BurnSoft.Applications.MGC.UnitTest.Settings;
using BurnSoft.Universal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BurnSoft.Applications.MGC.UnitTest.Other
{
    [TestClass]
    public class GeneralAccessoriesTest
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
        private int _gunId;
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
        /// The main accessory that is already default in the database
        /// </summary>
        private int _mainAccessory;
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            // Vs2019.GetSetting("", TestContext);
            BSOtherObjects obj = new BSOtherObjects();
            _errOut = @"";
            _mainAccessory = 1;
            _databasePath = Vs2019.GetSetting("DatabasePath", TestContext);
            _accessoriesManufacturer = obj.FC(Vs2019.GetSetting("Accessories_Manufacturer", TestContext));
            _accessoriesName = obj.FC(Vs2019.GetSetting("Accessories_Name", TestContext));
            _accessoriesSerialNumber = obj.FC(Vs2019.GetSetting("Accessories_serialNumber", TestContext));
            _accessoriesCondition = obj.FC(Vs2019.GetSetting("Accessories_condition", TestContext));
            _accessoriesNotes = obj.FC(Vs2019.GetSetting("Accessories_notes", TestContext));
            _accessoriesUse = obj.FC(Vs2019.GetSetting("Accessories_use", TestContext));
            _accessoriesPurValue = Vs2019.DGetSetting("Accessories_purValue", TestContext);
            _accessoriesAppValue = Vs2019.DGetSetting("Accessories_appValue", TestContext);
            _accessoriesCiv = Vs2019.BGetSetting("Accessories_civ", TestContext);
            _accessoriesIc = Vs2019.BGetSetting("Accessories_ic", TestContext);
        }
        /// <summary>
        /// Verifies the doesnt exist.
        /// </summary>
        private void VerifyDoesntExist()
        {
            if (GeneralAccessories.Exists(_databasePath, _accessoriesManufacturer, _accessoriesName,
                _accessoriesSerialNumber, out _errOut))
            {
                long id = GeneralAccessories.GetId(_databasePath, _accessoriesManufacturer, _accessoriesName,
                    _accessoriesSerialNumber, _accessoriesCondition, _accessoriesUse,
                    _accessoriesCiv, _accessoriesIc, out _errOut);
                Accessories.Delete(_databasePath, id, out _errOut);
            }
        }
        /// <summary>
        /// Verifies the exists.
        /// </summary>
        private void VerifyExists()
        {
            if (!GeneralAccessories.Exists(_databasePath, _accessoriesManufacturer, _accessoriesName,
                _accessoriesSerialNumber, out _errOut))
            {
                GeneralAccessories.Add(_databasePath, _accessoriesManufacturer, _accessoriesName,
                    _accessoriesSerialNumber, _accessoriesCondition, _accessoriesNotes, _accessoriesUse,
                    _accessoriesPurValue, _accessoriesAppValue, _accessoriesCiv, _accessoriesIc, out _errOut);
            }
        }

        [TestMethod, TestCategory("General Accessories")]
        public void AddTest()
        {
            VerifyDoesntExist();
            bool value = GeneralAccessories.Add(_databasePath, _accessoriesManufacturer, _accessoriesName,
                _accessoriesSerialNumber, _accessoriesCondition, _accessoriesNotes, _accessoriesUse,
                _accessoriesPurValue, _accessoriesAppValue, _accessoriesCiv, _accessoriesIc, out _errOut);
            General.HasTrueValue(value, _errOut);
        }

        [TestMethod, TestCategory("General Accessories")]
        public void UpdateTest()
        {
            VerifyExists();
            long id = GeneralAccessories.GetId(_databasePath, _accessoriesManufacturer, _accessoriesName,
                _accessoriesSerialNumber, _accessoriesCondition, _accessoriesUse,
                _accessoriesCiv, _accessoriesIc, out _errOut);

            bool value = GeneralAccessories.Update(_databasePath, id, _accessoriesManufacturer, _accessoriesName,
                _accessoriesSerialNumber, _accessoriesCondition, $"UPDATE TEST {_accessoriesNotes}", _accessoriesUse,
                _accessoriesPurValue, _accessoriesAppValue, _accessoriesCiv, _accessoriesIc, out _errOut);
            General.HasTrueValue(value, _errOut);
        }

        [TestMethod, TestCategory("General Accessories")]
        public void DuplicateTest()
        {
            VerifyExists();
            long id = GeneralAccessories.GetId(_databasePath, _accessoriesManufacturer, _accessoriesName,
                _accessoriesSerialNumber, _accessoriesCondition, _accessoriesUse,
                _accessoriesCiv, _accessoriesIc, out _errOut);

            bool value = GeneralAccessories.Duplicate(_databasePath, id, out _errOut);
            General.HasTrueValue(value, _errOut);
            List<GeneralAccessoriesList> lst = GeneralAccessories.Lists(_databasePath, id, out _errOut);
            TestContext.WriteLine(DebugHelpers.PrintListValues.GeneralAccessoriesDetails(lst));
            General.HasTrueValue(lst.Count > 0, _errOut);
        }

        [TestMethod, TestCategory("General Accessories")]
        public void ListTest()
        {
            VerifyExists();
            List<GeneralAccessoriesList> value = GeneralAccessories.Lists(_databasePath, out _errOut);
            TestContext.WriteLine(DebugHelpers.PrintListValues.GeneralAccessoriesDetails(value));
            General.HasTrueValue(value.Count > 0, _errOut);
        }

        [TestMethod, TestCategory("General Accessories")]
        public void ListByIdTest()
        {
            VerifyExists();
            List<GeneralAccessoriesList> value = GeneralAccessories.Lists(_databasePath, _mainAccessory, out _errOut);
            TestContext.WriteLine(DebugHelpers.PrintListValues.GeneralAccessoriesDetails(value));
            General.HasTrueValue(value.Count > 0, _errOut);
        }

        [TestMethod, TestCategory("General Accessories")]
        public void ExistsTest()
        {
            VerifyExists();
            bool value = GeneralAccessories.Exists(_databasePath, _accessoriesManufacturer, _accessoriesName,
                _accessoriesSerialNumber, out _errOut);
            General.HasTrueValue(value, _errOut);
        }

        [TestMethod, TestCategory("General Accessories")]
        public void GetId()
        {
            VerifyExists();
            long value = GeneralAccessories.GetId(_databasePath, _accessoriesManufacturer, _accessoriesName,
                _accessoriesSerialNumber, _accessoriesCondition, _accessoriesUse,
                _accessoriesCiv, _accessoriesIc, out _errOut);
            TestContext.WriteLine($"ID = {value}");
            General.HasTrueValue(value > 0, _errOut);
        }

        [TestMethod, TestCategory("General Accessories")]
        public void GetIdShort()
        {
            VerifyExists();
            long value = GeneralAccessories.GetId(_databasePath, _accessoriesManufacturer, _accessoriesName,
                _accessoriesSerialNumber, out _errOut);
            TestContext.WriteLine($"ID = {value}");
            General.HasTrueValue(value > 0, _errOut);
        }

        [TestMethod, TestCategory("General Accessories")]
        public void DeleteTest()
        {
            VerifyExists();
            long id = GeneralAccessories.GetId(_databasePath, _accessoriesManufacturer, _accessoriesName,
                _accessoriesSerialNumber, out _errOut);
            bool value = GeneralAccessories.Delete(_databasePath, Convert.ToInt32(id), out _errOut);
            General.HasTrueValue(value, _errOut);
        }

        [TestMethod, TestCategory("General Accessories")]
        public void DeleteFromFirearmTest()
        {
            VerifyExists();
            long id = GeneralAccessories.GetId(_databasePath, _accessoriesManufacturer, _accessoriesName,
                _accessoriesSerialNumber, out _errOut);
            bool value = GeneralAccessories.Delete(_databasePath, Convert.ToInt32(id), deleteFromFirearms: true, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
    }
}
