using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurnSoft.Applications.MGC.Firearms;
using BurnSoft.Applications.MGC.Types;
using BurnSoft.Applications.MGC.UnitTest.Settings;
using BurnSoft.Universal;

// ReSharper disable UnusedMember.Local


namespace BurnSoft.Applications.MGC.UnitTest.Firearms
{
    [TestClass]
    public class GunSmithDetailsTest
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
        /// The gun smith name
        /// </summary>
        private string _gunSmithName;
        /// <summary>
        /// The gun details order details
        /// </summary>
        private string _gunDetailsOrderDetails;
        /// <summary>
        /// The gun details notes
        /// </summary>
        private string _gunDetailsNotes;
        /// <summary>
        /// The gun details start date
        /// </summary>
        private string _gunDetailsStartDate;
        /// <summary>
        /// The gun details return date
        /// </summary>
        private string _gunDetailsReturnDate;
        /// <summary>
        /// The database path
        /// </summary>
        private string _databasePath;
        
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
            _gunSmithName = obj.FC(Vs2019.GetSetting("GunSmith_Name", TestContext));
            _gunDetailsOrderDetails = obj.FC(Vs2019.GetSetting("GunDetails_OrderDetails", TestContext));
            _gunDetailsNotes = obj.FC(Vs2019.GetSetting("GunDetails_Notes", TestContext));
            _gunDetailsStartDate = Vs2019.GetSetting("GunDetails_StartDate", TestContext);
            _gunDetailsReturnDate = Vs2019.GetSetting("GunDetails_ReturnDate", TestContext);
        }
        /// <summary>
        /// Prints the list.
        /// </summary>
        /// <param name="value">The value.</param>
        private void PrintList(List<GunSmithWorkDone> value)
        {
            if (value.Count > 0)
            {
                foreach (GunSmithWorkDone g in value)
                {
                    TestContext.WriteLine($"id : {g.Id}");
                    TestContext.WriteLine($"Smith Name: {g.GunSmithName}");
                    TestContext.WriteLine($"Smith ID: {g.GunSmithId}");
                    TestContext.WriteLine($"Gun Id: {g.GunId}");
                    TestContext.WriteLine($"OrderDetails: {g.OrderDetails}");
                    TestContext.WriteLine($"Notes: {g.Notes}");
                    TestContext.WriteLine($"Return Date: {g.ReturnDate}");
                    TestContext.WriteLine($"Start Date: {g.StartDate}");
                    TestContext.WriteLine($"Last Updated: {g.LastSync}");
                    TestContext.WriteLine($"");
                    TestContext.WriteLine($"--------------------------------------");
                    TestContext.WriteLine($"");
                }
            }
        }
        /// <summary>
        /// Verifies the exists.
        /// </summary>
        private void VerifyExists()
        {

            if (!GunSmithDetails.Exists(_databasePath, _gunId, _gunSmithName, _gunDetailsOrderDetails, out _errOut))
            {
                VerifyContactExists();
                long gsid = MGC.PeopleAndPlaces.GunSmiths.GetId(_databasePath, _gunSmithName, out _errOut);

                GunSmithDetails.Add(_databasePath, _gunId, _gunSmithName, gsid, _gunDetailsOrderDetails, _gunDetailsNotes, _gunDetailsStartDate, _gunDetailsReturnDate, out _errOut);

            }
        }
        /// <summary>
        /// Verifies the contact exists.
        /// </summary>
        private void VerifyContactExists()
        {
            if (!MGC.PeopleAndPlaces.GunSmiths.Exists(_databasePath, _gunSmithName,
                out _errOut))
            {
                MGC.PeopleAndPlaces.GunSmiths.Add(_databasePath, _gunSmithName, out _errOut);
            }
        }
        /// <summary>
        /// Verifies the doesnt exist.
        /// </summary>
        private void VerifyDoesntExist()
        {
            if (GunSmithDetails.Exists(_databasePath, _gunId, _gunSmithName, _gunDetailsOrderDetails, out _errOut))
            {
                VerifyContactExists();
                long gsid = MGC.PeopleAndPlaces.GunSmiths.GetId(_databasePath, _gunSmithName, out _errOut);
                long value = GunSmithDetails.GetId(_databasePath, _gunId, gsid, _gunDetailsOrderDetails, out _errOut);
                GunSmithDetails.Delete(_databasePath, value, out _errOut);
            }
        }

        /// <summary>
        /// Defines the test method AddTest.
        /// </summary>
        [TestMethod]
        public void AddTest()
        {
            VerifyDoesntExist();
            VerifyContactExists();
            long gsid = MGC.PeopleAndPlaces.GunSmiths.GetId(_databasePath, _gunSmithName, out _errOut);

            bool value = GunSmithDetails.Add(_databasePath, _gunId, _gunSmithName, gsid, _gunDetailsOrderDetails, _gunDetailsNotes, _gunDetailsStartDate, _gunDetailsReturnDate, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method ExistsTest.
        /// </summary>
        [TestMethod]
        public void ExistsTest()
        {
            VerifyExists();
            bool value = GunSmithDetails.Exists(_databasePath, _gunId, _gunSmithName, _gunDetailsOrderDetails,
                out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method DeleteTest.
        /// </summary>
        [TestMethod]
        public void DeleteTest()
        {
            VerifyExists();
            long gsid = MGC.PeopleAndPlaces.GunSmiths.GetId(_databasePath, _gunSmithName, out _errOut);
            long id = GunSmithDetails.GetId(_databasePath, _gunId, gsid, _gunDetailsOrderDetails, out _errOut);
            bool value = GunSmithDetails.Delete(_databasePath, id, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method UpdateTest.
        /// </summary>
        [TestMethod]
        public void UpdateTest()
        {
            VerifyExists();
            long gsid = MGC.PeopleAndPlaces.GunSmiths.GetId(_databasePath, _gunSmithName, out _errOut);
            long id = GunSmithDetails.GetId(_databasePath, _gunId, gsid, _gunDetailsOrderDetails, out _errOut);
            bool value = GunSmithDetails.Update(_databasePath, id, _gunId, _gunSmithName, gsid, _gunDetailsOrderDetails,$"UPDATED {_gunDetailsNotes}", _gunDetailsStartDate, _gunDetailsReturnDate, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method GetIdTest.
        /// </summary>
        [TestMethod]
        public void GetIdTest()
        {
            VerifyExists();
            long gsid = MGC.PeopleAndPlaces.GunSmiths.GetId(_databasePath, _gunSmithName, out _errOut);
            long id = GunSmithDetails.GetId(_databasePath, _gunId, gsid, _gunDetailsOrderDetails, out _errOut);

            General.HasTrueValue(id > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method ListAllTest.
        /// </summary>
        [TestMethod]
        public void ListAllTest()
        {
            VerifyExists();
            List<GunSmithWorkDone> value = GunSmithDetails.Lists(_databasePath, out _errOut);
            PrintList(value);

            General.HasTrueValue(value.Count > 0, _errOut);
        }

        [TestMethod]
        public void ListByGunSmithTest()
        {
            VerifyExists();
            List<GunSmithWorkDone> value = GunSmithDetails.Lists(_databasePath, _gunSmithName, out _errOut);
            PrintList(value);

            General.HasTrueValue(value.Count > 0, _errOut);
        }

        /// <summary>
        /// Defines the test method ListByGunTest.
        /// </summary>
        [TestMethod]
        public void ListByGunTest()
        {
            VerifyExists();
            List<GunSmithWorkDone> value = GunSmithDetails.Lists(_databasePath, _gunId, out _errOut);
            PrintList(value);

            General.HasTrueValue(value.Count > 0, _errOut);
        }
    }
}
