using BurnSoft.Applications.MGC.LoadersLog;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BurnSoft.Applications.MGC.UnitTest.LoaderLogs
{
    [TestClass]
    public class FirearmHelpersTests
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
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            // Vs2019.GetSetting("", TestContext);
            _errOut = @"";
        }

        [TestMethod, TestCategory("MyLoadersLog - Gun Collects")]
        public void CountFirearmsTest()
        {
            long value = FirearmHelpers.CountFirearms(out _errOut);
            TestContext.WriteLine($"VALUE RETURNED: {value}");
            General.HasTrueValue(value > 0, _errOut);
        }
     
        [TestMethod, TestCategory("MyLoadersLog - Gun Collects")]
        public void GetManufacturersIdTest()
        {
            long value = FirearmHelpers.GetManufacturersId("Beretta", out _errOut);
            TestContext.WriteLine($"VALUE RETURNED: {value}");
            General.HasTrueValue(value == 3, _errOut);
        }

        [TestMethod, TestCategory("MyLoadersLog - Gun Collects")]
        public void GetManufacturersNameTest()
        {
            string value = FirearmHelpers.GetManufacturersName(3, out _errOut);
            TestContext.WriteLine($"VALUE RETURNED: {value}");
            General.HasTrueValue(value.Equals("Beretta"), _errOut);
        }

        [TestMethod, TestCategory("MyLoadersLog - Gun Collects")]
        public void GetModelIdTest()
        {
            long value = FirearmHelpers.GetModelId("MODEL 92D", 3, out _errOut);
            TestContext.WriteLine($"VALUE RETURNED: {value}");
            General.HasTrueValue(value == 1288, _errOut);
        }

        [TestMethod, TestCategory("MyLoadersLog - Gun Collects")]
        public void GetNationalityIdTest()
        {
            long value = FirearmHelpers.GetNationalityId("UNITED STATES", out _errOut);
            TestContext.WriteLine($"VALUE RETURNED: {value}");
            General.HasTrueValue(value == 231, _errOut);
        }

        [TestMethod, TestCategory("MyLoadersLog - Gun Collects")]
        public void GetGripIdTest()
        {
            long value = FirearmHelpers.GetManufacturersId("Plastic", out _errOut);
            TestContext.WriteLine($"VALUE RETURNED: {value}");
            General.HasTrueValue(value == 2, _errOut);
        }

        [TestMethod, TestCategory("MyLoadersLog - Gun Collects")]
        public void GetGripIdAddTest()
        {
            long value = FirearmHelpers.GetManufacturersId("Plastic & Brass Grip Strap", out _errOut);
            TestContext.WriteLine($"VALUE RETURNED: {value}");
            General.HasTrueValue(value > 0, _errOut);
        }
    }
}
