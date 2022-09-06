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
    public class NationalityTest
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
        /// The nationality name
        /// </summary>
        private string _nationalityName;

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
            _nationalityName = obj.FC(Vs2019.GetSetting("Nationality_Name", TestContext));
        }
        /// <summary>
        /// Prints the list.
        /// </summary>
        /// <param name="value">The value.</param>
        private void PrintList(List<NationalityList> value)
        {
            if (value.Count > 0)
            {
                foreach (NationalityList g in value)
                {
                    TestContext.WriteLine($"id : {g.Id}");
                    TestContext.WriteLine($"Name: {g.Name}");
                    TestContext.WriteLine($"Last Updated: {g.LastSync}");
                    TestContext.WriteLine("");
                    TestContext.WriteLine("--------------------------------------");
                    TestContext.WriteLine("");
                }
            }
        }
        /// <summary>
        /// Verifies the exists.
        /// </summary>
        private void VerifyExists()
        {

            if (!Nationality.Exists(_databasePath, _nationalityName, out _errOut))
            {
                Nationality.Add(_databasePath, _nationalityName, out _errOut);
            }
        }
        /// <summary>
        /// Verifies the doesnt exist.
        /// </summary>
        private void VerifyDoesntExist()
        {
            if (Nationality.Exists(_databasePath, _nationalityName, out _errOut))
            {
                long value = Nationality.GetId(_databasePath, _nationalityName, out _errOut);
                Nationality.Delete(_databasePath, value, out _errOut);
            }
        }
        /// <summary>
        /// Defines the test method AddTest.
        /// </summary>
        [TestMethod, TestCategory("Nationality")]
        public void AddTest()
        {
            VerifyDoesntExist();
            bool value = Nationality.Add(_databasePath, _nationalityName, out _errOut);
            General.HasTrueValue(value, _errOut);

        }
        /// <summary>
        /// Defines the test method UpdateTest.
        /// </summary>
        [TestMethod, TestCategory("Nationality")]
        public void UpdateTest()
        {
            VerifyExists();
            long id = Nationality.GetId(_databasePath, _nationalityName, out _errOut);
            bool value = Nationality.Update(_databasePath, id, $"{_nationalityName} 2", out _errOut);
            General.HasTrueValue(value, _errOut);

        }

        /// <summary>
        /// Defines the test method ExistsTest.
        /// </summary>
        [TestMethod, TestCategory("Nationality")]
        public void ExistsTest()
        {
            VerifyExists();
            bool value = Nationality.Exists(_databasePath, _nationalityName, out _errOut);
            General.HasTrueValue(value, _errOut);

        }
        /// <summary>
        /// Defines the test method DeleteTest.
        /// </summary>
        [TestMethod, TestCategory("Nationality")]
        public void DeleteTest()
        {
            VerifyExists();
            long id = Nationality.GetId(_databasePath, _nationalityName, out _errOut);
            bool value = Nationality.Delete(_databasePath, id, out _errOut);
            General.HasTrueValue(value, _errOut);

        }
        /// <summary>
        /// Defines the test method GetIdTest.
        /// </summary>
        [TestMethod, TestCategory("Nationality")]
        public void GetIdTest()
        {
            VerifyExists();
            long id = Nationality.GetId(_databasePath, _nationalityName, out _errOut);
            TestContext.WriteLine($"id: {id}");
            General.HasTrueValue(id > 0, _errOut);
        }

        /// <summary>
        /// Defines the test method GetNameTest.
        /// </summary>
        [TestMethod, TestCategory("Nationality")]
        public void GetNameTest()
        {
            VerifyExists();
            long id = Nationality.GetId(_databasePath, _nationalityName, out _errOut);
            string name = Nationality.GetName(_databasePath, id, out _errOut);
            TestContext.WriteLine($"Name: {name}");
            General.HasTrueValue(name.Length > 0, _errOut);

        }
        /// <summary>
        /// Defines the test method ListFromGunAndBarrelTest.
        /// </summary>
        [TestMethod, TestCategory("Nationality")]
        public void ListByIdTest()
        {
            VerifyExists();
            long id = Nationality.GetId(_databasePath, _nationalityName, out _errOut);
            List<NationalityList> value = Nationality.Lists(_databasePath, id, out _errOut);
            PrintList(value);
            General.HasTrueValue(value.Count > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method ListFromGunTest.
        /// </summary>
        [TestMethod, TestCategory("Nationality")]
        public void ListAllTest()
        {
            VerifyExists();
            List<NationalityList> value = Nationality.Lists(_databasePath, out _errOut);
            PrintList(value);
            General.HasTrueValue(value.Count > 0, _errOut);
        }
    }
}
