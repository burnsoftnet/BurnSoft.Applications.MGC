
using System.Collections.Generic;
using BurnSoft.Applications.MGC.PeopleAndPlaces;
using BurnSoft.Applications.MGC.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurnSoft.Applications.MGC.UnitTest.Settings;
using BurnSoft.Universal;
// ReSharper disable UnusedVariable
// ReSharper disable UnusedMember.Local
// ReSharper disable NotAccessedField.Local
#pragma warning disable 414

namespace BurnSoft.Applications.MGC.UnitTest.PeopleAndPlaces
{
    [TestClass]
    public class OwnerInfoTest
    {
        //TODO: Finish this unit test
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
        /// The gun smith name
        /// </summary>
        private string _gunSmithName;

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
            _gunSmithName = obj.FC(Vs2019.GetSetting("GunSmith_Name", TestContext));

        }
        /// <summary>
        /// Logins the enabled test.
        /// </summary>
        [TestMethod]
        public void LoginEnabledTest()
        {
            bool value = OwnerInformation.LoginEnabled(_databasePath, out var uid, out var pwd, out var forgotWord,
                out var forgotPhrase, out _errOut);
            if (value)
            {
                TestContext.WriteLine($"uid: {uid}");
                TestContext.WriteLine($"pwd: {pwd}");
                TestContext.WriteLine($"forgot word: {forgotWord}");
                TestContext.WriteLine($"forgot phrase: {forgotPhrase}");
            }
            General.HasTrueValue(!value, _errOut);
        }
        /// <summary>
        /// Defines the test method GetOwnerInfoTest.
        /// </summary>
        [TestMethod]
        public void GetOwnerInfoTest()
        {
            List<OwnerInfo> lst = OwnerInformation.GetOwnerInfo(_databasePath, out _errOut);
            bool value = lst.Count > 0;

            if (value)
            {
                foreach (OwnerInfo l in lst)
                {
                    TestContext.WriteLine($"uid: {l.UserName}");
                    TestContext.WriteLine($"pwd: {l.Password}");
                    TestContext.WriteLine($"forgot word: {l.ForgotWord}");
                    TestContext.WriteLine($"forgot phrase: {l.ForgotPhrase}");
                    TestContext.WriteLine($"name: {l.Name}");
                    TestContext.WriteLine($"License: {l.Ccdwl}");
                    TestContext.WriteLine($"Address: {l.Address}");
                    TestContext.WriteLine($"City: {l.City}");
                    TestContext.WriteLine($"ZipCode: {l.ZipCode}");
                    TestContext.WriteLine($"State: {l.State}");
                    TestContext.WriteLine($"id: {l.Id}");
                }
            }
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method GetOwnerIdTest.
        /// </summary>
        [TestMethod]
        public void GetOwnerIdTest()
        {
            long id = OwnerInformation.GetOwnerId(_databasePath, out var ownerName, out var ownerLic, out _errOut);
            bool value = id > 0;
            if (value)
            {
                TestContext.WriteLine($"id: {id}");
                TestContext.WriteLine($"owner name: {ownerName}");
                TestContext.WriteLine($"License: {ownerLic}");
            }
            General.HasTrueValue(value, _errOut);
        }
    }
}
