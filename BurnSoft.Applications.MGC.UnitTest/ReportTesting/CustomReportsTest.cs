using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurnSoft.Applications.MGC.Firearms;
using BurnSoft.Applications.MGC.Other;
using BurnSoft.Applications.MGC.Reports;
using BurnSoft.Applications.MGC.Types;
using BurnSoft.Applications.MGC.UnitTest.Settings;
using BurnSoft.Universal;

namespace BurnSoft.Applications.MGC.UnitTest.ReportTesting
{
    [TestClass]
    public class CustomReportsTest
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
        /// The cr report name
        /// </summary>
        private string CR_ReportName;
        /// <summary>
        /// The cr SQL
        /// </summary>
        private string CR_SQL;

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
            CR_ReportName = obj.FC(Vs2019.GetSetting("CR_ReportName", TestContext));
            CR_SQL = obj.FC(Vs2019.GetSetting("CR_SQL", TestContext));
        }
        /// <summary>
        /// Verifies the doesnt exist.
        /// </summary>
        private void VerifyDoesntExist()
        {
            if (CustomReports.Exists(_databasePath, CR_ReportName,  out _errOut))
            {
                long id = CustomReports.GetId(_databasePath, CR_ReportName,  out _errOut);
                CustomReports.Delete(_databasePath, id, out _errOut);
            }
        }
        /// <summary>
        /// Verifies the exists.
        /// </summary>
        private void VerifyExists()
        {
            if (!CustomReports.Exists(_databasePath, CR_ReportName,  out _errOut))
            {
                CustomReports.Add(_databasePath, CR_ReportName, CR_SQL, out _errOut);
            }
        }
        /// <summary>
        /// Prints the list.
        /// </summary>
        /// <param name="value">The value.</param>
        private void PrintList(List<CustomReportsLists> value)
        {
            if (value.Count > 0)
            {
                foreach (CustomReportsLists v in value)
                {
                    TestContext.WriteLine($"id :{v.Id}");
                    TestContext.WriteLine($"ReportName: {v.ReportName}");
                    TestContext.WriteLine($"Sql: {v.Sql}");
                    TestContext.WriteLine($"DateAdded: {v.DateAdded}");
                    TestContext.WriteLine($"LastSync: {v.LastSync}");
                    TestContext.WriteLine("");
                    TestContext.WriteLine("--------------------------");
                    TestContext.WriteLine("");
                }
            }
        }
        /// <summary>
        /// Defines the test method AddTest.
        /// </summary>
        [TestMethod, TestCategory("Custom Reports")]
        public void AddTest()
        {
            VerifyDoesntExist();
            bool value = CustomReports.Add(_databasePath, CR_ReportName, CR_SQL, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
    }
}
