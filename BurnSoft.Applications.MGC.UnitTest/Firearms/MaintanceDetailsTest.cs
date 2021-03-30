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
    public class MaintanceDetailsTest
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
        /// The maintenance details plan identifier
        /// </summary>
        private long _maintenanceDetailsPlanId;
        /// <summary>
        /// The maintenance details name
        /// </summary>
        private string _maintenanceDetailsName;
        /// <summary>
        /// The maintenance details operation date
        /// </summary>
        private string _maintenanceDetailsOperationDate;
        /// <summary>
        /// The maintenance details operation due date
        /// </summary>
        private string _maintenanceDetailsOperationDueDate;
        /// <summary>
        /// The maintenance details rounds fired
        /// </summary>
        private long _maintenanceDetailsRoundsFired;
        /// <summary>
        /// The maintenance details notes
        /// </summary>
        private string _maintenanceDetailsNotes;
        /// <summary>
        /// The maintenance details barrel system identifier
        /// </summary>
        private long _maintenanceDetailsBarrelSystemId;
        /// <summary>
        /// The maintenance details does count
        /// </summary>
        private bool _maintenanceDetailsDoesCount;
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
            _maintenanceDetailsPlanId = Vs2019.IGetSetting("MaintenanceDetails_PlanId", TestContext);
            _maintenanceDetailsName = Vs2019.GetSetting("MaintenanceDetails_Name", TestContext);
            _maintenanceDetailsOperationDate = Vs2019.GetSetting("MaintenanceDetails_OperationDate", TestContext);
            _maintenanceDetailsOperationDueDate = Vs2019.GetSetting("MaintenanceDetails_OperationDueDate", TestContext);
            _maintenanceDetailsRoundsFired = Vs2019.IGetSetting("MaintenanceDetails_RoundsFired", TestContext);
            _maintenanceDetailsNotes = Vs2019.GetSetting("MaintenanceDetails_Notes", TestContext);
            _maintenanceDetailsBarrelSystemId = Vs2019.IGetSetting("MaintenanceDetails_BarrelSystemId", TestContext);
            _maintenanceDetailsDoesCount = Vs2019.BGetSetting("MaintenanceDetails_DoesCount", TestContext);
        }
        /// <summary>
        /// Prints the list.
        /// </summary>
        /// <param name="value">The value.</param>
        private void PrintList(List<MaintanceDetailsList> value)
        {
            if (value.Count > 0)
            {
                foreach (MaintanceDetailsList g in value)
                {
                    TestContext.WriteLine($"id : {g.Id}");
                    TestContext.WriteLine($"Plan Id: {g.PlanId}");
                    TestContext.WriteLine($"Name: {g.Name}");
                    TestContext.WriteLine($"Gun Id: {g.GunId}");
                    TestContext.WriteLine($"Operation Date: {g.OperationStartDate}");
                    TestContext.WriteLine($"Operation Due Date: {g.OperationDueDate}");
                    TestContext.WriteLine($"Notes: {g.Notes}");
                    TestContext.WriteLine($"Barrel System Id: {g.BarrelSystemId}");
                    TestContext.WriteLine($"Counts in Total: {g.DoesCount}");
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

            if (!MaintanceDetails.Exists(_databasePath, _maintenanceDetailsName, _gunId, _maintenanceDetailsPlanId, _maintenanceDetailsOperationDate, _maintenanceDetailsOperationDueDate, out _errOut))
            {
                MaintanceDetails.Add(_databasePath, _maintenanceDetailsName, _gunId, _maintenanceDetailsPlanId, _maintenanceDetailsOperationDate, _maintenanceDetailsOperationDueDate, _maintenanceDetailsRoundsFired, _maintenanceDetailsNotes, "N/A", _maintenanceDetailsBarrelSystemId, _maintenanceDetailsDoesCount, out _errOut);
            }
        }
        /// <summary>
        /// Verifies the doesnt exist.
        /// </summary>
        private void VerifyDoesntExist()
        {
            if (MaintanceDetails.Exists(_databasePath, _maintenanceDetailsName, _gunId, _maintenanceDetailsPlanId, _maintenanceDetailsOperationDate, _maintenanceDetailsOperationDueDate, out _errOut))
            {
                long value = MaintanceDetails.GetId(_databasePath, _maintenanceDetailsName, _gunId, _maintenanceDetailsPlanId, _maintenanceDetailsOperationDate, _maintenanceDetailsOperationDueDate, out _errOut);
                MaintanceDetails.Delete(_databasePath, value, out _errOut);
            }
        }
        /// <summary>
        /// Defines the test method AddTest.
        /// </summary>
        [TestMethod]
        public void AddTest()
        {
            VerifyDoesntExist();
            bool value = MaintanceDetails.Add(_databasePath, _maintenanceDetailsName, _gunId, _maintenanceDetailsPlanId, _maintenanceDetailsOperationDate, _maintenanceDetailsOperationDueDate, _maintenanceDetailsRoundsFired, _maintenanceDetailsNotes, "N/A", _maintenanceDetailsBarrelSystemId, _maintenanceDetailsDoesCount, out _errOut);
            General.HasTrueValue(value, _errOut);

        }
        /// <summary>
        /// Defines the test method ExistsTest.
        /// </summary>
        [TestMethod]
        public void ExistsTest()
        {
            VerifyExists();
            bool value = MaintanceDetails.Exists(_databasePath, _maintenanceDetailsName, _gunId,
                _maintenanceDetailsPlanId, _maintenanceDetailsOperationDate, _maintenanceDetailsOperationDueDate,
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
            long id = MaintanceDetails.GetId(_databasePath, _maintenanceDetailsName, _gunId, _maintenanceDetailsPlanId, _maintenanceDetailsOperationDate, _maintenanceDetailsOperationDueDate, out _errOut);
            bool value = MaintanceDetails.Delete(_databasePath, id, out _errOut);
            General.HasTrueValue(value, _errOut);

        }
        /// <summary>
        /// Defines the test method GetIdTest.
        /// </summary>
        [TestMethod]
        public void GetIdTest()
        {
            VerifyExists();
            long id = MaintanceDetails.GetId(_databasePath, _maintenanceDetailsName, _gunId, _maintenanceDetailsPlanId, _maintenanceDetailsOperationDate, _maintenanceDetailsOperationDueDate, out _errOut);
            TestContext.WriteLine($"id: {id}");
            General.HasTrueValue(id > 0, _errOut);

        }
        /// <summary>
        /// Defines the test method GetNameTest.
        /// </summary>
        [TestMethod]
        public void GetNameTest()
        {
            VerifyExists();
            long id = MaintanceDetails.GetId(_databasePath, _maintenanceDetailsName, _gunId, _maintenanceDetailsPlanId, _maintenanceDetailsOperationDate, _maintenanceDetailsOperationDueDate, out _errOut);
            string name = MaintanceDetails.GetName(_databasePath, id, out _errOut);
            TestContext.WriteLine($"Name: {name}");
            General.HasTrueValue(name.Length > 0, _errOut);

        }
        /// <summary>
        /// Defines the test method ListFromGunAndBarrelTest.
        /// </summary>
        [TestMethod]
        public void ListFromGunAndBarrelTest()
        {
            VerifyExists();
            List<MaintanceDetailsList> value = MaintanceDetails.Lists(_databasePath, _gunId, _maintenanceDetailsBarrelSystemId, out _errOut);
            PrintList(value);
            General.HasTrueValue(value.Count > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method ListFromGunTest.
        /// </summary>
        [TestMethod]
        public void ListFromGunTest()
        {
            VerifyExists();
            List<MaintanceDetailsList> value = MaintanceDetails.Lists(_databasePath, _gunId,  out _errOut);
            PrintList(value);
            General.HasTrueValue(value.Count > 0, _errOut);
        }
    }
}
