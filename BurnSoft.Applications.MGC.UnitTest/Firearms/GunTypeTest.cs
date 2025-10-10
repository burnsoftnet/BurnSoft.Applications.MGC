using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using BurnSoft.Applications.MGC.Firearms;
using BurnSoft.Applications.MGC.UnitTest.Settings;

namespace BurnSoft.Applications.MGC.UnitTest.Firearms
{
    [TestClass]
    public class GunTypeTest
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
        /// The gun type name
        /// </summary>
        private string _gunTypeName;
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            // Vs2019.GetSetting("", TestContext);
            _errOut = @"";
            _databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Vs2019.GetSetting("DatabasePath", TestContext));
            _gunTypeName = "Pistol: Triple Action";
        }
        /// <summary>
        /// Doesnes the exist.
        /// </summary>
        private void DoesneExist()
        {
            if (!GunTypes.Exists(_databasePath, _gunTypeName, out _errOut))
            {
                GunTypes.Add(_databasePath, _gunTypeName, out _errOut);
            }
        }
        /// <summary>
        /// Doeses the eixst.
        /// </summary>
        private void DoesEixst()
        {
            if (GunTypes.Exists(_databasePath, _gunTypeName, out _errOut))
            {
                GunTypes.Delete(_databasePath, _gunTypeName, out _errOut);
            }
        }
        /// <summary>
        /// Defines the test method AddTest.
        /// </summary>
        [TestMethod, TestCategory("Gun Types")]
        public void AddTest()
        {
            DoesEixst();
            bool value = GunTypes.Add(_databasePath, _gunTypeName, out _errOut);
            string result = value ? "Was" : "Was not";
            result += $" able to add gun type {_gunTypeName} to database";
            TestContext.WriteLine(result);
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method ExistsTest.
        /// </summary>
        [TestMethod, TestCategory("Gun Types")]
        public void ExistsTest()
        {
            DoesneExist();
            bool value = GunTypes.Exists(_databasePath, _gunTypeName, out _errOut);
            TestContext.WriteLine(value ? $"{_gunTypeName} exists!" : $"{_gunTypeName} does not exist");
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method GetIdTest.
        /// </summary>
        [TestMethod, TestCategory("Gun Types")]
        public void GetIdTest()
        {
            DoesneExist();
            int value = GunTypes.GetId(_databasePath, _gunTypeName, out _errOut);
            TestContext.WriteLine($"{_gunTypeName} id is {value}!");
            General.HasTrueValue(value > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method DeleteByNameTest.
        /// </summary>
        [TestMethod, TestCategory("Gun Types")]
        public void DeleteByNameTest()
        {
            DoesneExist();
            bool value = GunTypes.Delete(_databasePath, _gunTypeName, out _errOut);
            TestContext.WriteLine(value ? $"{_gunTypeName} was delete!" : $"{_gunTypeName} was not deleted");
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method DeleteByIdTest.
        /// </summary>
        [TestMethod, TestCategory("Gun Types")]
        public void DeleteByIdTest()
        {
            DoesneExist();
            int id = GunTypes.GetId(_databasePath, _gunTypeName, out _errOut);
            bool value = GunTypes.Delete(_databasePath, id, out _errOut);
            TestContext.WriteLine(value ? $"{_gunTypeName} was delete!" : $"{_gunTypeName} was not deleted");
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method UpdateTest.
        /// </summary>
        [TestMethod, TestCategory("Gun Types")]
        public void UpdateTest()
        {
            DoesneExist();
            int id = GunTypes.GetId(_databasePath, _gunTypeName, out _errOut);
            bool value = GunTypes.Update(_databasePath,id, $"{_gunTypeName} NEW", out _errOut);
            TestContext.WriteLine(value ? $"{_gunTypeName} was updated to {_gunTypeName} NEW!" : $"{_gunTypeName} was not updated to {_gunTypeName} NEW");
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Prints the list.
        /// </summary>
        /// <param name="value">The value.</param>
        private void PrintList(List<Types.GunTypes> value)
        {
            // TODO: #63 Add to PrintListValues Function
            if (value.Count > 0)
            {
                foreach (Types.GunTypes v in value)
                {
                    TestContext.WriteLine($"id: {v.Id}");
                    TestContext.WriteLine($"Name/Type: {v.Name}");
                    TestContext.WriteLine($"Last Sync: {v.LastSync}");
                }
            }
        }
        /// <summary>
        /// Defines the test method GetListByIdTest.
        /// </summary>
        [TestMethod, TestCategory("Gun Types")]
        public void GetListByIdTest()
        {
            DoesneExist();
            int id = GunTypes.GetId(_databasePath, _gunTypeName, out _errOut);
            List<Types.GunTypes> value = GunTypes.GetList(_databasePath, id, out _errOut);
            PrintList(value);
            General.HasTrueValue(value.Count > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method GetListAllTest.
        /// </summary>
        [TestMethod, TestCategory("Gun Types")]
        public void GetListAllTest()
        {
            DoesneExist();
            
            List<Types.GunTypes> value = GunTypes.GetList(_databasePath,  out _errOut);
            PrintList(value);
            General.HasTrueValue(value.Count > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method UpdateGunTypeTest.
        /// </summary>
        [TestMethod, TestCategory("Gun Types")]
        public void UpdateGunTypeTest()
        {
            DoesEixst();

            bool value = GunTypes.UpdateGunType(_databasePath,_gunTypeName, out _errOut);
            General.HasTrueValue(value, _errOut);
        }
    }
}
