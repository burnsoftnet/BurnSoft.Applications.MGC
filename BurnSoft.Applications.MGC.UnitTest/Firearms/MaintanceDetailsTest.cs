using System.Collections.Generic;
using BurnSoft.Applications.MGC.AutoFill;
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

        private long MaintenanceDetails_PlanId;

        private string MaintenanceDetails_Name;

        private string MaintenanceDetails_OperationDate;
 
        private string MaintenanceDetails_OperationDueDate;

        private long MaintenanceDetails_RoundsFired;
        private string MaintenanceDetails_Notes;
        private long MaintenanceDetails_BarrelSystemId;
        private bool MaintenanceDetails_DoesCount;
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
            MaintenanceDetails_PlanId = Vs2019.IGetSetting("MaintenanceDetails_PlanId", TestContext);
            MaintenanceDetails_Name = Vs2019.GetSetting("MaintenanceDetails_Name", TestContext);
            MaintenanceDetails_OperationDate = Vs2019.GetSetting("MaintenanceDetails_OperationDate", TestContext);
            MaintenanceDetails_OperationDueDate = Vs2019.GetSetting("MaintenanceDetails_OperationDueDate", TestContext);
            MaintenanceDetails_RoundsFired = Vs2019.IGetSetting("MaintenanceDetails_RoundsFired", TestContext);
            MaintenanceDetails_Notes = Vs2019.GetSetting("MaintenanceDetails_Notes", TestContext);
            MaintenanceDetails_BarrelSystemId = Vs2019.IGetSetting("MaintenanceDetails_BarrelSystemId", TestContext);
            MaintenanceDetails_DoesCount = Vs2019.BGetSetting("MaintenanceDetails_DoesCount", TestContext);
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

            if (!MaintanceDetails.Exists(_databasePath, MaintenanceDetails_Name, _gunId, MaintenanceDetails_PlanId, MaintenanceDetails_OperationDate, MaintenanceDetails_OperationDueDate, out _errOut))
            {
                MaintanceDetails.Add(_databasePath, MaintenanceDetails_Name, _gunId, MaintenanceDetails_PlanId, MaintenanceDetails_OperationDate, MaintenanceDetails_OperationDueDate, MaintenanceDetails_RoundsFired, MaintenanceDetails_Notes, "N/A", MaintenanceDetails_BarrelSystemId, MaintenanceDetails_DoesCount, out _errOut);
            }
        }
        /// <summary>
        /// Verifies the doesnt exist.
        /// </summary>
        private void VerifyDoesntExist()
        {
            if (MaintanceDetails.Exists(_databasePath, MaintenanceDetails_Name, _gunId, MaintenanceDetails_PlanId, MaintenanceDetails_OperationDate, MaintenanceDetails_OperationDueDate, out _errOut))
            {
                long value = MaintanceDetails.GetId(_databasePath, MaintenanceDetails_Name, _gunId, MaintenanceDetails_PlanId, MaintenanceDetails_OperationDate, MaintenanceDetails_OperationDueDate, out _errOut);
                MaintanceDetails.Delete(_databasePath, value, out _errOut);
            }
        }
        [TestMethod]
        public void AddTest()
        {
            VerifyDoesntExist();
            bool value = MaintanceDetails.Add(_databasePath, MaintenanceDetails_Name, _gunId, MaintenanceDetails_PlanId, MaintenanceDetails_OperationDate, MaintenanceDetails_OperationDueDate, MaintenanceDetails_RoundsFired, MaintenanceDetails_Notes, "N/A", MaintenanceDetails_BarrelSystemId, MaintenanceDetails_DoesCount, out _errOut);
            General.HasTrueValue(value, _errOut);

        }

        [TestMethod]
        public void ExistsTest()
        {
            VerifyExists();
            bool value = MaintanceDetails.Exists(_databasePath, MaintenanceDetails_Name, _gunId,
                MaintenanceDetails_PlanId, MaintenanceDetails_OperationDate, MaintenanceDetails_OperationDueDate,
                out _errOut);
            General.HasTrueValue(value, _errOut);

        }

        [TestMethod]
        public void DeleteTest()
        {
            VerifyExists();
            long id = MaintanceDetails.GetId(_databasePath, MaintenanceDetails_Name, _gunId, MaintenanceDetails_PlanId, MaintenanceDetails_OperationDate, MaintenanceDetails_OperationDueDate, out _errOut);
            bool value = MaintanceDetails.Delete(_databasePath, id, out _errOut);
            General.HasTrueValue(value, _errOut);

        }


    }
}
