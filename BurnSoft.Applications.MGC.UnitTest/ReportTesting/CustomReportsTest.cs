using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        private string _crReportName;
        /// <summary>
        /// The cr SQL
        /// </summary>
        private string _crSql;

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
            _crReportName = obj.FC(Vs2019.GetSetting("CR_ReportName", TestContext));
            _crSql = obj.FC(Vs2019.GetSetting("CR_SQL", TestContext));
        }
        /// <summary>
        /// Verifies the doesnt exist.
        /// </summary>
        private void VerifyDoesntExist()
        {
            if (CustomReports.Exists(_databasePath, _crReportName,  out _errOut))
            {
                long id = CustomReports.GetId(_databasePath, _crReportName,  out _errOut);
                CustomReports.Delete(_databasePath, id, out _errOut);
            }
        }
        /// <summary>
        /// Verifies the exists.
        /// </summary>
        private void VerifyExists()
        {
            if (!CustomReports.Exists(_databasePath, _crReportName,  out _errOut))
            {
                CustomReports.Add(_databasePath, _crReportName, _crSql, out _errOut);
            }
        }
        /// <summary>
        /// Prints the list.
        /// </summary>
        /// <param name="value">The value.</param>
        private void PrintList(List<CustomReportsLists> value)
        {
            // TODO: #63 Add to PrintListValues Function
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
            bool value = CustomReports.Add(_databasePath, _crReportName, _crSql, out _errOut);
            General.HasTrueValue(value, _errOut);
        }

        [TestMethod, TestCategory("Custom Reports")]
        public void ExistsTest()
        {
            VerifyExists();
            bool value = CustomReports.Exists(_databasePath, _crReportName,  out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method GetId.
        /// </summary>
        [TestMethod, TestCategory("Custom Reports")]
        public void GetId()
        {
            VerifyExists();
            long value = CustomReports.GetId(_databasePath, _crReportName, out _errOut);
            TestContext.WriteLine($"ID = {value}");
            General.HasTrueValue(value > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method UpdateTest.
        /// </summary>
        [TestMethod, TestCategory("Custom Reports")]
        public void UpdateTest()
        {
            VerifyExists();
            long id = CustomReports.GetId(_databasePath, _crReportName, out _errOut);

            bool value = CustomReports.Update(_databasePath, id, _crReportName, $"{_crSql} where id={id}", out _errOut);
            General.HasTrueValue(value, _errOut);
        }


        /// <summary>
        /// Defines the test method DeleteTest.
        /// </summary>
        [TestMethod, TestCategory("Custom Reports")]
        public void DeleteTest()
        {
            VerifyExists();
            long id = CustomReports.GetId(_databasePath, _crReportName, out _errOut);
            bool value = CustomReports.Delete(_databasePath, id, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method ListByIDTest.
        /// </summary>
        [TestMethod, TestCategory("Custom Reports")]
        public void ListByIdTest()
        {
            VerifyExists();
            long id = CustomReports.GetId(_databasePath, _crReportName, out _errOut);
            List<CustomReportsLists> value = CustomReports.List(_databasePath, (int)id, out _errOut);
            PrintList(value);
            General.HasTrueValue(value.Count > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method ListTest.
        /// </summary>
        [TestMethod, TestCategory("Custom Reports")]
        public void ListTest()
        {
            VerifyExists();
            List<CustomReportsLists> value = CustomReports.List(_databasePath, out _errOut);
            PrintList(value);
            General.HasTrueValue(value.Count > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method HasSavedReportsTest.
        /// </summary>
        [TestMethod, TestCategory("Custom Reports")]
        public void HasSavedReportsTest()
        {
            VerifyExists();
            bool value = CustomReports.HasSavedReports(_databasePath, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
    }
}
