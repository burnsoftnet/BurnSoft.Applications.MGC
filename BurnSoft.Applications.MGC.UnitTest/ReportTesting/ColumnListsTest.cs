using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurnSoft.Applications.MGC.Reports;
using BurnSoft.Applications.MGC.Types;
using BurnSoft.Applications.MGC.UnitTest.Settings;
using BurnSoft.Universal;

namespace BurnSoft.Applications.MGC.UnitTest.ReportTesting
{
    [TestClass]
    public class ColumnListsTest
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
        /// The cr column table identifier
        /// </summary>
        private long _crColumnTableId;
        /// <summary>
        /// The cr column display name
        /// </summary>
        private string _crColumnDisplayName;

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
            _crColumnTableId = Vs2019.IGetSetting("CR_Column_TableId", TestContext);
            _crColumnDisplayName = obj.FC(Vs2019.GetSetting("CR_Column_DisplayName", TestContext));
        }

        /// <summary>
        /// Prints the list.
        /// </summary>
        /// <param name="value">The value.</param>
        private void PrintList(List<ColumnLists> value)
        {
            if (value.Count > 0)
            {
                foreach (ColumnLists v in value)
                {
                    TestContext.WriteLine($"id :{v.Id}");
                    TestContext.WriteLine($"TableId: {v.TableId}");
                    TestContext.WriteLine($"Column: {v.Column}");
                    TestContext.WriteLine($"DisplayName: {v.DisplayName}");
                    TestContext.WriteLine("");
                    TestContext.WriteLine("--------------------------");
                    TestContext.WriteLine("");
                }
            }
        }
        /// <summary>
        /// Defines the test method GetListTest.
        /// </summary>
        [TestMethod, TestCategory("Column Lists")]
        public void GetListTest()
        {
            List<ColumnLists> value = ColumnList.GetList(_databasePath, _crColumnTableId, out _errOut);
            PrintList(value);
            General.HasTrueValue(value.Count > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method GetFullNameTest.
        /// </summary>
        [TestMethod, TestCategory("Column Lists")]
        public void GetFullNameTest()
        {
            string value = ColumnList.GetColumnName(_databasePath, _crColumnTableId, _crColumnDisplayName, out _errOut);
            TestContext.WriteLine($"Returned value: {value}");
            General.HasTrueValue(value.Length > 0, _errOut);
        }
    }
}
