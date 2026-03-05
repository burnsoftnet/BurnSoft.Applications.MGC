using BurnSoft.Applications.MGC.LoadersLog;
using BurnSoft.Universal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BurnSoft.Applications.MGC.UnitTest.LoaderLogs
{
    [TestClass]
    public class FirearmHelpersTests
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
        /// The o
        /// </summary>
        private BSOtherObjects o;
        private string _gunType;
        private string _manufacturer;
        private int _manufacturerId;
        private string _expectedModel;
        private long _expectedModelId;
        private string _expectedNationality;
        private long _expectedNationalityId;
        private string _grip;
        private int _gripId;
        private string _gripNameAdd;
        private string _shop;
        private int _shopId;
        private string _caliberExists;
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            // Vs2019.GetSetting("", TestContext);
            o = new BSOtherObjects();
            _errOut = @"";
            _gunType = "Pistol: Race Gun";
            _manufacturer = "Beretta";
            _manufacturerId = 3;
            _expectedModel = "MODEL 92D";
            _expectedModelId = 1288;
            _expectedNationality = "UNITED STATES";
            _expectedNationalityId = 231;
            _grip = "Plastic";
            _gripId = 2;
            _gripNameAdd = "Plastic & Brass Grip Strap";
            _shop = "Mike's Guns";
            _shopId = 1;
            _caliberExists = ".22 Long Rifle";
        }

        [TestMethod, TestCategory("MyLoadersLog - Gun Collects")]
        public void CountFirearmsTest()
        {
            long value = FirearmHelpers.CountFirearms(out _errOut);
            TestContext.WriteLine($"VALUE RETURNED: {value}");
            General.HasTrueValue(value > 0, _errOut);
        }
     
        [TestMethod, TestCategory("MyLoadersLog - Gun Collects")]
        public void GetManufacturersIdTest()
        {
            long value = FirearmHelpers.GetManufacturersId(_manufacturer, out _errOut);
            TestContext.WriteLine($"VALUE RETURNED: {value}");
            General.HasTrueValue(value == _manufacturerId, _errOut);
        }

        [TestMethod, TestCategory("MyLoadersLog - Gun Collects")]
        public void GetManufacturersNameTest()
        {
            string value = FirearmHelpers.GetManufacturersName(_manufacturerId, out _errOut);
            TestContext.WriteLine($"VALUE RETURNED: {value}");
            General.HasTrueValue(value.Equals(_manufacturer), _errOut);
        }

        [TestMethod, TestCategory("MyLoadersLog - Gun Collects")]
        public void GetModelIdTest()
        {
            long value = FirearmHelpers.GetModelId(_expectedModel, _manufacturerId, out _errOut);
            TestContext.WriteLine($"VALUE RETURNED: {value}");
            General.HasTrueValue(value == _expectedModelId, _errOut);
        }

        [TestMethod, TestCategory("MyLoadersLog - Gun Collects")]
        public void GetNationalityIdTest()
        {
            long value = FirearmHelpers.GetNationalityId(_expectedNationality, out _errOut);
            TestContext.WriteLine($"VALUE RETURNED: {value}");
            General.HasTrueValue(value == _expectedNationalityId, _errOut);
        }

        [TestMethod, TestCategory("MyLoadersLog - Gun Collects")]
        public void GetGripIdTest()
        {
            long value = FirearmHelpers.GetGripId(_grip, out _errOut);
            TestContext.WriteLine($"VALUE RETURNED: {value}");
            General.HasTrueValue(value == _gripId, _errOut);
        }

        [TestMethod, TestCategory("MyLoadersLog - Gun Collects")]
        public void GetGripIdAddTest()
        {
            long value = FirearmHelpers.GetGripId(_gripNameAdd, out _errOut);
            TestContext.WriteLine($"VALUE RETURNED: {value}");
            General.HasTrueValue(value > 0, _errOut);
        }

        [TestMethod, TestCategory("MyLoadersLog - Gun Collects")]
        public void GetGunShopIdTest()
        {
            string name = o.FC(_shop);
            long value = FirearmHelpers.GetGunShopId(name, out _errOut);
            TestContext.WriteLine($"VALUE RETURNED: {value}");
            General.HasTrueValue(value == _shopId, _errOut);
        }

        [TestMethod, TestCategory("MyLoadersLog - Gun Collects")]
        public void GetLastFirearmIdTest()
        {
            long value = FirearmHelpers.GetLastFirearmId(out _errOut);
            TestContext.WriteLine($"VALUE RETURNED: {value}");
            General.HasTrueValue(value > 0, _errOut);
        }

        [TestMethod, TestCategory("MyLoadersLog - Gun Collects")]
        public void UpdateGunTypeTest()
        {
            bool value = FirearmHelpers.UpdateGunType(_gunType, out _errOut);
            TestContext.WriteLine($"VALUE RETURNED: {value}");
            General.HasTrueValue(value, _errOut);
        }

        [TestMethod, TestCategory("MyLoadersLog - Gun Collects")]
        public void CaliberExistsTest()
        {
            bool value = FirearmHelpers.CaliberExists(_caliberExists, out _errOut);
            TestContext.WriteLine($"VALUE RETURNED: {value}");
            General.HasTrueValue(value, _errOut);
        }

        [TestMethod, TestCategory("MyLoadersLog - Gun Collects")]
        public void AddFirearmToMGCTest()
        {
            bool value = FirearmHelpers.AddFirearmToMGC("Canik Open Gun", "Canik","Canik TTI", 
                "9mm Luger", "5\"", "FAKE12345", _gunType, out _errOut);
            TestContext.WriteLine($"VALUE RETURNED: {value}");
            General.HasTrueValue(value, _errOut);
        }

        [TestMethod, TestCategory("MyLoadersLog - Gun Collects")]
        public void AmmoIsAlreadyListedTest()
        {
            long qty = 0;
            long id = 0;
            bool value = FirearmHelpers.AmmoIsAlreadyListed("Remington", 
                "Golden Saber", "9mm Luger", "147 Grains", "Brass Jacketed Hollow Point", 
                out qty, out id, out _errOut);
            TestContext.WriteLine($"VALUE RETURNED: {value}");
            TestContext.WriteLine($"qty: {qty}");
            TestContext.WriteLine($"id: {id}");
            General.HasTrueValue(value, _errOut);
        }
    }
}
