using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurnSoft.Applications.MGC.PeopleAndPlaces;
using BurnSoft.Applications.MGC.Types;
using BurnSoft.Applications.MGC.UnitTest.Settings;
using BurnSoft.Universal;
// ReSharper disable UnusedVariable
// ReSharper disable UnusedMember.Local
// ReSharper disable NotAccessedField.Local

namespace BurnSoft.Applications.MGC.UnitTest.PeopleAndPlaces
{
    [TestClass]
    public class BuyersTest
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
        /// The buyer name
        /// </summary>
        private string _buyerName;
        /// <summary>
        /// The buyer address1
        /// </summary>
        private string _buyerAddress1;
        /// <summary>
        /// The buyer address2
        /// </summary>
        private string _buyerAddress2;
        /// <summary>
        /// The buyer city
        /// </summary>
        private string _buyerCity;
        /// <summary>
        /// The buyer state
        /// </summary>
        private string _buyerState;
        /// <summary>
        /// The buyer zip code
        /// </summary>
        private string _buyerZipCode;
        /// <summary>
        /// The buyer phone
        /// </summary>
        private string _buyerPhone;
        /// <summary>
        /// The buyer country
        /// </summary>
        private string _buyerCountry;
        /// <summary>
        /// The buyer e mail
        /// </summary>
        private string _buyerEMail;
        /// <summary>
        /// The buyer lic
        /// </summary>
        private string _buyerLic;
        /// <summary>
        /// The buyer d lic
        /// </summary>
        private string _buyerDLic;
        /// <summary>
        /// The buyer dob
        /// </summary>
        private string _buyerDob;
        /// <summary>
        /// The buyer resident
        /// </summary>
        private string _buyerResident;
        /// <summary>
        /// The buyer fax
        /// </summary>
        private string _buyerFax;
        /// <summary>
        /// The buyer web site
        /// </summary>
        private string _buyerWebSite;
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            // Vs2019.GetSetting("", TestContext);
            // obj.FC(Vs2019.GetSetting("", TestContext));
            BSOtherObjects obj = new BSOtherObjects();
            _errOut = @"";
            _databasePath = Vs2019.GetSetting("DatabasePath", TestContext);
            _gunId = Vs2019.IGetSetting("MyGunCollectionID", TestContext);
            _buyerName = obj.FC(Vs2019.GetSetting("Buyer_Name", TestContext));
            _buyerAddress1 = obj.FC(Vs2019.GetSetting("Buyer_Address1", TestContext));
            _buyerAddress2 = obj.FC(Vs2019.GetSetting("Buyer_Address2", TestContext));
            _buyerCity = obj.FC(Vs2019.GetSetting("Buyer_City", TestContext));
            _buyerState = obj.FC(Vs2019.GetSetting("Buyer_State", TestContext));
            _buyerZipCode = obj.FC(Vs2019.GetSetting("Buyer_ZipCode", TestContext));
            _buyerPhone = obj.FC(Vs2019.GetSetting("Buyer_Phone", TestContext));
            _buyerCountry = obj.FC(Vs2019.GetSetting("Buyer_Country", TestContext));
            _buyerEMail = obj.FC(Vs2019.GetSetting("Buyer_eMail", TestContext));
            _buyerLic = obj.FC(Vs2019.GetSetting("Buyer_Lic", TestContext));
            _buyerDLic = obj.FC(Vs2019.GetSetting("Buyer_dLic", TestContext));
            _buyerDob = obj.FC(Vs2019.GetSetting("Buyer_DOB", TestContext));
            _buyerResident = obj.FC(Vs2019.GetSetting("Buyer_Resident", TestContext));
            _buyerFax = obj.FC(Vs2019.GetSetting("Buyer_Fax", TestContext));
            _buyerWebSite = obj.FC(Vs2019.GetSetting("Buyer_WebSite", TestContext));
        }
        /// <summary>
        /// Verifies the doesnt exist.
        /// </summary>
        private void VerifyDoesntExist()
        {
            if (Buyers.Exists(_databasePath, _buyerName, _buyerAddress1, _buyerAddress2, _buyerCity, _buyerState, _buyerZipCode, _buyerDob, _buyerDLic, out _errOut))
            {
                long id = Buyers.GetId(_databasePath, _buyerName, out _errOut);
                bool value = Buyers.Delete(_databasePath, id, out _errOut);
            }
        }
        /// <summary>
        /// Verifies the exists.
        /// </summary>
        private void VerifyExists()
        {
            if (!Buyers.Exists(_databasePath, _buyerName, _buyerAddress1, _buyerAddress2, _buyerCity, _buyerState, _buyerZipCode, _buyerDob, _buyerDLic, out _errOut))
            {
                bool value = Buyers.Add(_databasePath, _buyerName, _buyerAddress1, _buyerAddress2, _buyerCity, _buyerState, _buyerZipCode, _buyerPhone, _buyerCountry, _buyerEMail, _buyerLic , _buyerWebSite, _buyerFax, _buyerDob, _buyerDLic, _buyerResident, out _errOut);
            }
        }

        /// <summary>
        /// Defines the test method AddTest.
        /// </summary>
        [TestMethod, TestCategory("Buyers")]
        public void AddTest()
        {
            VerifyDoesntExist();
            bool value = Buyers.Add(_databasePath, _buyerName, _buyerAddress1, _buyerAddress2, _buyerCity, _buyerState, _buyerZipCode, _buyerPhone, _buyerCountry, _buyerEMail, _buyerLic, _buyerWebSite, _buyerFax, _buyerDob, _buyerDLic, _buyerResident, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method ExistsTest.
        /// </summary>
        [TestMethod, TestCategory("Buyers")]
        public void ExistsTest()
        {
            VerifyExists();
            bool value = Buyers.Exists(_databasePath, _buyerName, _buyerAddress1, _buyerAddress2, _buyerCity,
                _buyerState, _buyerZipCode, _buyerDob, _buyerDLic, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method StolenBuyerExistsTest.
        /// </summary>
        [TestMethod, TestCategory("Buyers")]
        public void StolenBuyerExistsTest()
        {
            VerifyExists();
            bool value = Buyers.StolenBuyerExists(_databasePath, _buyerName,  out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method GetIdTest.
        /// </summary>
        [TestMethod, TestCategory("Buyers")]
        public void GetIdTest()
        {
            VerifyExists();
            long value = Buyers.GetId(_databasePath, _buyerName, out _errOut);
            TestContext.WriteLine($"ids: {value}");
            General.HasTrueValue(value > 0, _errOut);
        }

        /// <summary>
        /// Defines the test method GetListByIdTest.
        /// </summary>
        [TestMethod, TestCategory("Buyers")]
        public void GetListByIdTest()
        {
            VerifyExists();
            long id = Buyers.GetId(_databasePath, _buyerName, out _errOut);
            List<BuyersList> value = Buyers.Get(_databasePath, id, out _errOut);
            TestContext.WriteLine(DebugHelpers.PrintListValues.BuyersListInfo(value));
            General.HasTrueValue(value.Count > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method GetListByNameTest.
        /// </summary>
        [TestMethod, TestCategory("Buyers")]
        public void GetListByNameTest()
        {
            VerifyExists();
            List<BuyersList> value = Buyers.Get(_databasePath, _buyerName, out _errOut);
            TestContext.WriteLine(DebugHelpers.PrintListValues.BuyersListInfo(value));
            General.HasTrueValue(value.Count > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method GetListAllTest.
        /// </summary>
        [TestMethod, TestCategory("Buyers")]
        public void GetListAllTest()
        {
            VerifyExists();
            List<BuyersList> value = Buyers.Get(_databasePath, out _errOut);
            TestContext.WriteLine(DebugHelpers.PrintListValues.BuyersListInfo(value));
            General.HasTrueValue(value.Count > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method DeleteTest.
        /// </summary>
        [TestMethod, TestCategory("Buyers")]
        public void DeleteTest()
        {
            VerifyExists();
            long id = Buyers.GetId(_databasePath, _buyerName, out _errOut);
            TestContext.WriteLine($"Deleting Buyr with the id of {id} ");
            bool value = Buyers.Delete(_databasePath, id, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method SoldFirearmTest.
        /// </summary>
        [TestMethod, TestCategory("Buyers")]
        public void SoldFirearmTest()
        {
            VerifyExists();
            long id = Buyers.GetId(_databasePath, _buyerName, out _errOut);
            bool value = Buyers.FirearmBought(_databasePath, _gunId, id, DateTime.Now.ToString(CultureInfo.InvariantCulture), "400.00", out _errOut);
            General.HasTrueValue(value, _errOut);
        }

    }
}
