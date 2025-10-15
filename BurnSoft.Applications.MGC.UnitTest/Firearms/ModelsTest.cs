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
    public class ModelsTest
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
        /// The models manufacturer identifier
        /// </summary>
        private long _modelsManufacturerId;
        /// <summary>
        /// The models name
        /// </summary>
        private string _modelsName;

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
            _modelsName = obj.FC(Vs2019.GetSetting("Models_Name", TestContext));
            _modelsManufacturerId = Vs2019.IGetSetting("Models_ManufacturerId", TestContext);
        }
        /// <summary>
        /// Prints the list.
        /// </summary>
        /// <param name="value">The value.</param>
        private void PrintList(List<ModelList> value)
        {
            // TODO: #63 Add to PrintListValues Function
            if (value.Count > 0)
            {
                foreach (ModelList g in value)
                {
                    TestContext.WriteLine($"id : {g.Id}");
                    TestContext.WriteLine($"Name: {g.Name}");
                    TestContext.WriteLine($"ManufacturerId: {g.ManufacturerId}");
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

            if (!Models.Exists(_databasePath, _modelsName, _modelsManufacturerId, out _errOut))
            {
                Models.Add(_databasePath, _modelsName, _modelsManufacturerId, out _errOut);
            }
        }
        /// <summary>
        /// Verifies the doesnt exist.
        /// </summary>
        private void VerifyDoesntExist()
        {
            if (Models.Exists(_databasePath, _modelsName, _modelsManufacturerId, out _errOut))
            {
                long value = Models.GetId(_databasePath, _modelsName, _modelsManufacturerId, out _errOut);
                Models.Delete(_databasePath, value, out _errOut);
            }
        }
        /// <summary>
        /// Defines the test method AddTest.
        /// </summary>
        [TestMethod, TestCategory("Models Information")]
        public void AddTest()
        {
            VerifyDoesntExist();
            bool value = Models.Add(_databasePath, _modelsName, _modelsManufacturerId, out _errOut);
            General.HasTrueValue(value, _errOut);

        }
        /// <summary>
        /// Defines the test method UpdateTest.
        /// </summary>
        [TestMethod, TestCategory("Models Information")]
        public void UpdateTest()
        {
            VerifyExists();
            long id = Models.GetId(_databasePath, _modelsName, _modelsManufacturerId, out _errOut);
            bool value = Models.Update(_databasePath, id, $"{_modelsName}1", _modelsManufacturerId, out _errOut);
            General.HasTrueValue(value, _errOut);

        }

        /// <summary>
        /// Defines the test method UpdateTest.
        /// </summary>
        [TestMethod, TestCategory("Models Information")]
        public void Update2Test()
        {
            VerifyExists();
            long id = Models.GetId(_databasePath, _modelsName, _modelsManufacturerId, out _errOut);
            bool value = Models.Update(_databasePath, id, $"{_modelsName}2", out _errOut);
            General.HasTrueValue(value, _errOut);

        }

        /// <summary>
        /// Defines the test method ExistsTest.
        /// </summary>
        [TestMethod, TestCategory("Models Information")]
        public void ExistsTest()
        {
            VerifyExists();
            bool value = Models.Exists(_databasePath, _modelsName, _modelsManufacturerId, out _errOut);
            General.HasTrueValue(value, _errOut);

        }

        /// <summary>
        /// Defines the test method DeleteTest.
        /// </summary>
        [TestMethod, TestCategory("Models Information")]
        public void DeleteTest()
        {
            VerifyExists();
            long id = Models.GetId(_databasePath, _modelsName, _modelsManufacturerId, out _errOut);
            bool value = Models.Delete(_databasePath, id, out _errOut);
            General.HasTrueValue(value, _errOut);

        }
        /// <summary>
        /// Defines the test method GetIdTest.
        /// </summary>
        [TestMethod, TestCategory("Models Information")]
        public void GetIdTest()
        {
            VerifyExists();
            long id = Models.GetId(_databasePath, _modelsName, _modelsManufacturerId, out _errOut);
            TestContext.WriteLine($"id: {id}");
            General.HasTrueValue(id > 0, _errOut);
        }

        [TestMethod, TestCategory("Models Information")]
        public void GetIdTestExpectFail()
        {
            long id = Models.GetId(_databasePath, _modelsName, _modelsManufacturerId, out _errOut);
            TestContext.WriteLine($"id: {id}");
            General.HasFalseValue(id > 0, _errOut);
        }

        [TestMethod, TestCategory("Models Information")]
        public void GetIdAddIfTest()
        {
            long id = Models.GetId(_databasePath, $"{_modelsName}-Test", _modelsManufacturerId, out _errOut, true);
            TestContext.WriteLine($"id: {id} for {_modelsName}-Test");
            General.HasTrueValue(id > 0, _errOut);
        }

        [TestMethod, TestCategory("Models Information")]
        public void GetIdAddIfTestFail()
        {
            long id = Models.GetId(_databasePath, $"{_modelsName}-TestFail", _modelsManufacturerId, out _errOut);
            TestContext.WriteLine($"id: {id} for {_modelsName}-TestFail");
            General.HasFalseValue(id > 0, _errOut);
        }

        /// <summary>
        /// Defines the test method GetNameTest.
        /// </summary>
        [TestMethod, TestCategory("Models Information")]
        public void GetNameTest()
        {
            VerifyExists();
            long id = Models.GetId(_databasePath, _modelsName, _modelsManufacturerId, out _errOut);
            string name = Models.GetName(_databasePath, id, out _errOut);
            TestContext.WriteLine($"Name: {name}");
            General.HasTrueValue(name.Length > 0, _errOut);

        }
        /// <summary>
        /// Defines the test method ListFromGunAndBarrelTest.
        /// </summary>
        [TestMethod, TestCategory("Models Information")]
        public void ListByIdTest()
        {
            VerifyExists();
            List<ModelList> value = Models.Lists(_databasePath, _modelsManufacturerId, out _errOut);
            PrintList(value);
            General.HasTrueValue(value.Count > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method ListFromGunTest.
        /// </summary>
        [TestMethod, TestCategory("Models Information")]
        public void ListAllTest()
        {
            VerifyExists();
            List<ModelList> value = Models.Lists(_databasePath, out _errOut);
            PrintList(value);
            General.HasTrueValue(value.Count > 0, _errOut);
        }
    }
}
