using System.Collections.Generic;
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
        private string Buyer_Name;
        /// <summary>
        /// The buyer address1
        /// </summary>
        private string Buyer_Address1;
        /// <summary>
        /// The buyer address2
        /// </summary>
        private string Buyer_Address2;
        /// <summary>
        /// The buyer city
        /// </summary>
        private string Buyer_City;
        /// <summary>
        /// The buyer state
        /// </summary>
        private string Buyer_State;
        /// <summary>
        /// The buyer zip code
        /// </summary>
        private string Buyer_ZipCode;
        /// <summary>
        /// The buyer phone
        /// </summary>
        private string Buyer_Phone;
        /// <summary>
        /// The buyer country
        /// </summary>
        private string Buyer_Country;
        /// <summary>
        /// The buyer e mail
        /// </summary>
        private string Buyer_eMail;
        /// <summary>
        /// The buyer lic
        /// </summary>
        private string Buyer_Lic;
        /// <summary>
        /// The buyer d lic
        /// </summary>
        private string Buyer_dLic;
        /// <summary>
        /// The buyer dob
        /// </summary>
        private string Buyer_DOB;
        /// <summary>
        /// The buyer resident
        /// </summary>
        private string Buyer_Resident;
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
            Buyer_Name = obj.FC(Vs2019.GetSetting("Buyer_Name", TestContext));
            Buyer_Address1 = obj.FC(Vs2019.GetSetting("Buyer_Address1", TestContext));
            Buyer_Address2 = obj.FC(Vs2019.GetSetting("Buyer_Address2", TestContext));
            Buyer_City = obj.FC(Vs2019.GetSetting("Buyer_City", TestContext));
            Buyer_State = obj.FC(Vs2019.GetSetting("Buyer_State", TestContext));
            Buyer_ZipCode = obj.FC(Vs2019.GetSetting("Buyer_ZipCode", TestContext));
            Buyer_Phone = obj.FC(Vs2019.GetSetting("Buyer_Phone", TestContext));
            Buyer_Country = obj.FC(Vs2019.GetSetting("Buyer_Country", TestContext));
            Buyer_eMail = obj.FC(Vs2019.GetSetting("Buyer_eMail", TestContext));
            Buyer_Lic = obj.FC(Vs2019.GetSetting("Buyer_Lic", TestContext));
            Buyer_dLic = obj.FC(Vs2019.GetSetting("Buyer_dLic", TestContext));
            Buyer_DOB = obj.FC(Vs2019.GetSetting("Buyer_DOB", TestContext));
            Buyer_Resident = obj.FC(Vs2019.GetSetting("Buyer_Resident", TestContext));
        }
        /// <summary>
        /// Verifies the doesnt exist.
        /// </summary>
        private void VerifyDoesntExist()
        {
            if (Buyers.Exists(_databasePath, Buyer_Name, Buyer_Address1, Buyer_Address2, Buyer_City, Buyer_State, Buyer_ZipCode, Buyer_DOB, Buyer_dLic, out _errOut))
            {
                long id = Buyers.GetId(_databasePath, Buyer_Name, out _errOut);
                bool value = Buyers.Delete(_databasePath, id, out _errOut);
            }
        }
        /// <summary>
        /// Verifies the exists.
        /// </summary>
        private void VerifyExists()
        {
            if (Buyers.Exists(_databasePath, Buyer_Name, Buyer_Address1, Buyer_Address2, Buyer_City, Buyer_State, Buyer_ZipCode, Buyer_DOB, Buyer_dLic, out _errOut))
            {
                bool value = Buyers.Add(_databasePath, Buyer_Name, Buyer_Address1, Buyer_Address2, Buyer_City, Buyer_State, Buyer_ZipCode, Buyer_Phone, Buyer_Country, Buyer_eMail, Buyer_Lic , "", "", Buyer_DOB, Buyer_dLic, Buyer_Resident, out _errOut);
            }
        }
        /// <summary>
        /// Print the list of buyers information
        /// </summary>
        /// <param name="value"></param>
        private void PrintList(List<BuyersList> value)
        {
            foreach (BuyersList v in value)
            {
                TestContext.WriteLine($"id: {v.Id}");
                TestContext.WriteLine($"Name: {v.Name}");
                TestContext.WriteLine($"Address1: {v.Address1}");
                TestContext.WriteLine($"Address2: {v.Address2}");
                TestContext.WriteLine($"City: {v.City}");
                TestContext.WriteLine($"State: {v.State}");
                TestContext.WriteLine($"ZipCode: {v.ZipCode}");
                TestContext.WriteLine($"Phone: {v.Phone}");
                TestContext.WriteLine($"Fax: {v.Fax}");
                TestContext.WriteLine($"email: {v.Email}");
                TestContext.WriteLine($"Driver Lic: {v.Dlic}");
                TestContext.WriteLine($"Date of Birth: {v.Dob}");
                TestContext.WriteLine($"Country: {v.Country}");
                TestContext.WriteLine($"Resident: {v.Resident}");
                TestContext.WriteLine($"License: {v.Lic}");
                TestContext.WriteLine($"");
                TestContext.WriteLine($"----------------------------------");
            }
        }

        /// <summary>
        /// Defines the test method AddTest.
        /// </summary>
        [TestMethod, TestCategory("Buyers")]
        public void AddTest()
        {
            VerifyDoesntExist();
            bool value = Buyers.Add(_databasePath, Buyer_Name, Buyer_Address1, Buyer_Address2, Buyer_City, Buyer_State, Buyer_ZipCode, Buyer_Phone, Buyer_Country, Buyer_eMail, Buyer_Lic, "", "", Buyer_DOB, Buyer_dLic, Buyer_Resident, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method ExistsTest.
        /// </summary>
        [TestMethod, TestCategory("Buyers")]
        public void ExistsTest()
        {
            VerifyExists();
            bool value = Buyers.Exists(_databasePath, Buyer_Name, Buyer_Address1, Buyer_Address2, Buyer_City,
                Buyer_State, Buyer_ZipCode, Buyer_DOB, Buyer_dLic, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method StolenBuyerExistsTest.
        /// </summary>
        [TestMethod, TestCategory("Buyers")]
        public void StolenBuyerExistsTest()
        {
            VerifyExists();
            bool value = Buyers.StolenBuyerExists(_databasePath, Buyer_Name,  out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method GetIdTest.
        /// </summary>
        [TestMethod, TestCategory("Buyers")]
        public void GetIdTest()
        {
            VerifyExists();
            long value = Buyers.GetId(_databasePath, Buyer_Name, out _errOut);
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
            long id = Buyers.GetId(_databasePath, Buyer_Name, out _errOut);
            List<BuyersList> value = Buyers.Get(_databasePath, id, out _errOut);
            PrintList(value);
            General.HasTrueValue(value.Count > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method GetListByNameTest.
        /// </summary>
        [TestMethod, TestCategory("Buyers")]
        public void GetListByNameTest()
        {
            VerifyExists();
            List<BuyersList> value = Buyers.Get(_databasePath, Buyer_Name, out _errOut);
            PrintList(value);
            General.HasTrueValue(value.Count > 0, _errOut);
        }

        [TestMethod, TestCategory("Buyers")]
        public void GetListAllTest()
        {
            VerifyExists();
            List<BuyersList> value = Buyers.Get(_databasePath, out _errOut);
            PrintList(value);
            General.HasTrueValue(value.Count > 0, _errOut);
        }

    }
}
