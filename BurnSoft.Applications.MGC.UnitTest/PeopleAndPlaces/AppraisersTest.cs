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
    public class AppraisersTest
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
        /// The Appraisers name
        /// </summary>
        private string _appraisersName;

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
            _appraisersName = obj.FC(Vs2019.GetSetting("Appraisers_Name", TestContext));

        }
        /// <summary>
        /// Verifies the doesnt exist.
        /// </summary>
        private void VerifyDoesntExist()
        {
            if (Appraisers.Exists(_databasePath, _appraisersName, out _errOut))
            {
                long id = Appraisers.GetId(_databasePath, _appraisersName, out _errOut);
                bool value = Appraisers.Delete(_databasePath, id, out _errOut);
            }
        }
        /// <summary>
        /// Verifies the exists.
        /// </summary>
        private void VerifyExists()
        {
            if (!Appraisers.Exists(_databasePath, _appraisersName, out _errOut))
            {
                bool value = Appraisers.Add(_databasePath, _appraisersName, out _errOut);
            }
        }
        /// <summary>
        /// Defines the test method AddTest.
        /// </summary>
        [TestMethod, TestCategory("Appraisers list")]
        public void AddQuickTest()
        {
            VerifyDoesntExist();
            bool value = Appraisers.Add(_databasePath, _appraisersName, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method EditTest.
        /// </summary>
        [TestMethod, TestCategory("Appraisers list")]
        public void EditTest()
        {
            VerifyExists();
            long id = Appraisers.GetId(_databasePath, _appraisersName, out _errOut);
            bool value = Appraisers.Update(_databasePath, id, _appraisersName, "222 here", "N/A", "myCity", "ky", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", true, out _errOut);
            General.HasTrueValue(value, _errOut);
        }

        /// <summary>
        /// Defines the test method DeleteTest.
        /// </summary>
        [TestMethod, TestCategory("Appraisers Contact list")]
        public void DeleteTest()
        {
            VerifyExists();
            long id = Appraisers.GetId(_databasePath, _appraisersName, out _errOut);
            bool value = Appraisers.Delete(_databasePath, id, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method GetNameTest.
        /// </summary>
        [TestMethod, TestCategory("Appraisers Contact list")]
        public void GetNameTest()
        {
            VerifyExists();
            long id = Appraisers.GetId(_databasePath, _appraisersName, out _errOut);
            string value = Appraisers.GetName(_databasePath, id, out _errOut);
            TestContext.WriteLine($"Name: {value}");
            General.HasValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method GetIdTest.
        /// </summary>
        [TestMethod, TestCategory("Appraisers Contact list")]
        public void GetIdTest()
        {
            VerifyExists();
            long value = Appraisers.GetId(_databasePath, _appraisersName, out _errOut);
            TestContext.WriteLine($"Id: {value}");
            General.HasTrueValue(value > 0, _errOut);
        }

        /// <summary>
        /// Defines the test method GetByIdTest.
        /// </summary>
        [TestMethod, TestCategory("Appraisers")]
        public void GetByIdTest()
        {
            VerifyExists();
            long id = Appraisers.GetId(_databasePath, _appraisersName, out _errOut);
            List<AppraisersContactDetails> value = Appraisers.Get(_databasePath, id, out _errOut);
            TestContext.WriteLine(DebugHelpers.PrintListValues.AppraisersContactInfo(value));
            General.HasTrueValue(value.Count > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method GetTest.
        /// </summary>
        [TestMethod, TestCategory("Appraisers")]
        public void GetTest()
        {
            VerifyExists();
            List<AppraisersContactDetails> value = Appraisers.Get(_databasePath, out _errOut);
            TestContext.WriteLine(DebugHelpers.PrintListValues.AppraisersContactInfo(value));
            General.HasTrueValue(value.Count > 0, _errOut);
        }
    }
}
