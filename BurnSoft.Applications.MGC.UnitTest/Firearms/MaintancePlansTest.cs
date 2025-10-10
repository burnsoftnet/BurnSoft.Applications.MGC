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
    public class MaintancePlansTest
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
        /// The maintenance plans name
        /// </summary>
        private string _maintenancePlansName;
        /// <summary>
        /// The maintenance plans operation details
        /// </summary>
        private string _maintenancePlansOperationDetails;
        /// <summary>
        /// The maintenance plans intervals in days
        /// </summary>
        private string _maintenancePlansIntervalsInDays;
        /// <summary>
        /// The maintenance plans interval in rounds fired
        /// </summary>
        private string _maintenancePlansIntervalInRoundsFired;
        /// <summary>
        /// The maintenance plans notes
        /// </summary>
        private string _maintenancePlansNotes;
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            // Vs2019.GetSetting("", TestContext);
            _errOut = @"";
            BSOtherObjects obj = new BSOtherObjects();
            _databasePath = Vs2019.GetSetting("DatabasePath", TestContext);
            _maintenancePlansName = obj.FC(Vs2019.GetSetting("MaintenancePlans_Name", TestContext));
            _maintenancePlansOperationDetails = obj.FC(Vs2019.GetSetting("MaintenancePlans_OperationDetails", TestContext));
            _maintenancePlansIntervalsInDays = obj.FC(Vs2019.GetSetting("MaintenancePlans_IntervalsInDays", TestContext));
            _maintenancePlansNotes = obj.FC(Vs2019.GetSetting("MaintenancePlans_Notes", TestContext));
            _maintenancePlansIntervalInRoundsFired = obj.FC(Vs2019.GetSetting("MaintenancePlans_IntervalInRoundsFired", TestContext));
            
        }
        /// <summary>
        /// Prints the list.
        /// </summary>
        /// <param name="value">The value.</param>
        private void PrintList(List<MaintancePlansList> value)
        {
            // TODO: #63 Add to PrintListValues Function
            if (value.Count > 0)
            {
                foreach (MaintancePlansList g in value)
                {
                    TestContext.WriteLine($"id : {g.Id}");
                    TestContext.WriteLine($"Name: {g.Name}");
                    TestContext.WriteLine($"OperationDetails: {g.OperationDetails}");
                    TestContext.WriteLine($"IntervalInRoundsFired: {g.IntervalInRoundsFired}");
                    TestContext.WriteLine($"IntervalsInDays: {g.IntervalsInDays}");
                    TestContext.WriteLine($"Notes: {g.Notes}");
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

            if (!MaintancePlans.Exists(_databasePath, _maintenancePlansName, out _errOut))
            {
                MaintancePlans.Add(_databasePath, _maintenancePlansName, _maintenancePlansOperationDetails, _maintenancePlansIntervalsInDays, _maintenancePlansIntervalInRoundsFired, _maintenancePlansNotes , out _errOut);
            }
        }
        /// <summary>
        /// Verifies the doesnt exist.
        /// </summary>
        private void VerifyDoesntExist()
        {
            if (MaintancePlans.Exists(_databasePath, _maintenancePlansName , out _errOut))
            {
                long value = MaintancePlans.GetId(_databasePath, _maintenancePlansName, out _errOut);
                MaintancePlans.Delete(_databasePath, value, out _errOut);
            }
        }
        /// <summary>
        /// Defines the test method AddTest.
        /// </summary>
        [TestMethod, TestCategory("Maintance Plans")]
        public void AddTest()
        {
            VerifyDoesntExist();
            bool value = MaintancePlans.Add(_databasePath, _maintenancePlansName, _maintenancePlansOperationDetails, _maintenancePlansIntervalsInDays, _maintenancePlansIntervalInRoundsFired, _maintenancePlansNotes, out _errOut);
            General.HasTrueValue(value, _errOut);

        }
        /// <summary>
        /// Defines the test method UpdateTest.
        /// </summary>
        [TestMethod, TestCategory("Maintance Plans")]
        public void UpdateTest()
        {
            VerifyExists();
            long id = MaintancePlans.GetId(_databasePath, _maintenancePlansName, out _errOut);
            bool value = MaintancePlans.Update(_databasePath,id, _maintenancePlansName, $"UPDATED - {_maintenancePlansOperationDetails}", _maintenancePlansIntervalsInDays, _maintenancePlansIntervalInRoundsFired, _maintenancePlansNotes, out _errOut);
            General.HasTrueValue(value, _errOut);

        }

        /// <summary>
        /// Defines the test method ExistsTest.
        /// </summary>
        [TestMethod, TestCategory("Maintance Plans")]
        public void ExistsTest()
        {
            VerifyExists();
            bool value = MaintancePlans.Exists(_databasePath, _maintenancePlansName, out _errOut);
            General.HasTrueValue(value, _errOut);

        }
        /// <summary>
        /// Defines the test method DeleteTest.
        /// </summary>
        [TestMethod, TestCategory("Maintance Plans")]
        public void DeleteTest()
        {
            VerifyExists();
            long id = MaintancePlans.GetId(_databasePath, _maintenancePlansName, out _errOut);
            bool value = MaintancePlans.Delete(_databasePath, id, out _errOut);
            General.HasTrueValue(value, _errOut);

        }
        /// <summary>
        /// Defines the test method GetIdTest.
        /// </summary>
        [TestMethod, TestCategory("Maintance Plans")]
        public void GetIdTest()
        {
            VerifyExists();
            long id = MaintancePlans.GetId(_databasePath, _maintenancePlansName, out _errOut);
            TestContext.WriteLine($"id: {id}");
            General.HasTrueValue(id > 0, _errOut);
        }

        /// <summary>
        /// Defines the test method GetNameTest.
        /// </summary>
        [TestMethod, TestCategory("Maintance Plans")]
        public void GetNameTest()
        {
            VerifyExists();
            long id = MaintancePlans.GetId(_databasePath, _maintenancePlansName, out _errOut);
            string name = MaintancePlans.GetName(_databasePath, id, out _errOut);
            TestContext.WriteLine($"Name: {name}");
            General.HasTrueValue(name.Length > 0, _errOut);

        }
        /// <summary>
        /// Defines the test method ListFromGunAndBarrelTest.
        /// </summary>
        [TestMethod, TestCategory("Maintance Plans")]
        public void ListByIdTest()
        {
            VerifyExists();
            long id = MaintancePlans.GetId(_databasePath, _maintenancePlansName, out _errOut);
            List<MaintancePlansList> value = MaintancePlans.Lists(_databasePath, id, out _errOut);
            PrintList(value);
            General.HasTrueValue(value.Count > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method ListFromGunTest.
        /// </summary>
        [TestMethod, TestCategory("Maintance Plans")]
        public void ListAllTest()
        {
            VerifyExists();
            List<MaintancePlansList> value = MaintancePlans.Lists(_databasePath, out _errOut);
            PrintList(value);
            General.HasTrueValue(value.Count > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method ListByNameTest.
        /// </summary>
        [TestMethod, TestCategory("Maintance Plans")]
        public void ListByNameTest()
        {
            VerifyExists();
            List<MaintancePlansList> value = MaintancePlans.Lists(_databasePath, _maintenancePlansName, out _errOut);
            PrintList(value);
            General.HasTrueValue(value.Count > 0, _errOut);
        }
    }
}
