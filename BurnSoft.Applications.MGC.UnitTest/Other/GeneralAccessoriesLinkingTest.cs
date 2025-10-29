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
    public class GeneralAccessoriesLinkingTest
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
            _gunId = Vs2019.IGetSetting("MyGunCollectionID", TestContext);
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
            if (GeneralAccessoriesLinking.Exists(_databasePath, _gunId, _mainAccessory, out _errOut))
            {
                long id = GeneralAccessoriesLinking.GetId(_databasePath, _gunId, _mainAccessory, out _errOut);
                GeneralAccessoriesLinking.Delete(_databasePath, Convert.ToInt32(id), out _errOut);
            }
        }
        /// <summary>
        /// Verifies the exists.
        /// </summary>
        private void VerifyExists()
        {
            if (!GeneralAccessoriesLinking.Exists(_databasePath, _gunId, _mainAccessory, out _errOut))
            {
                GeneralAccessoriesLinking.Add(_databasePath, _mainAccessory, _gunId, out _errOut);
            }
        }

        [TestMethod, TestCategory("General Accessories Links")]
        public void AddTest()
        {
            VerifyDoesntExist();
            bool value = GeneralAccessoriesLinking.Add(_databasePath, _mainAccessory, _gunId, out _errOut);
            General.HasTrueValue(value, _errOut);
        }

        [TestMethod, TestCategory("General Accessories Links")]
        public void ListsAllTest()
        {
            VerifyExists();
            List<GeneralAccessoriesLinkers> value = GeneralAccessoriesLinking.Lists(_databasePath, out _errOut);
            TestContext.WriteLine(DebugHelpers.PrintListValues.GeneralAccessoriesLinkersDetails(value));
            General.HasTrueValue(value.Count > 0, _errOut);
        }

        [TestMethod, TestCategory("General Accessories Links")]
        public void ListsByAccessoryTest()
        {
            VerifyExists();
            List<GeneralAccessoriesLinkers> value = GeneralAccessoriesLinking.Lists(_databasePath, _mainAccessory, out _errOut);
            TestContext.WriteLine(DebugHelpers.PrintListValues.GeneralAccessoriesLinkersDetails(value));
            General.HasTrueValue(value.Count > 0, _errOut);
        }

        [TestMethod, TestCategory("General Accessories Links")]
        public void ListsByGunAndAccessoryTest()
        {
            VerifyExists();
            List<GeneralAccessoriesLinkers> value = GeneralAccessoriesLinking.Lists(_databasePath, _gunId, _mainAccessory, out _errOut);
            TestContext.WriteLine(DebugHelpers.PrintListValues.GeneralAccessoriesLinkersDetails(value));
            General.HasTrueValue(value.Count > 0, _errOut);
        }

        [TestMethod, TestCategory("General Accessories Links")]
        public void GetId()
        {
            VerifyExists();
            long value = GeneralAccessoriesLinking.GetId(_databasePath, _gunId, _mainAccessory, out _errOut);
            TestContext.WriteLine($"ID = {value}");
            General.HasTrueValue(value > 0, _errOut);
        }

        [TestMethod, TestCategory("General Accessories Links")]
        public void ExistsTest()
        {
            VerifyExists();
            bool value = GeneralAccessoriesLinking.Exists(_databasePath, _gunId, _mainAccessory, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
    }
}
