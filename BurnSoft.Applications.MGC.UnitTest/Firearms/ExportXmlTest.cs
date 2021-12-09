using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using BurnSoft.Applications.MGC.Firearms;
using BurnSoft.Applications.MGC.UnitTest.Settings;

// ReSharper disable ConvertIfStatementToConditionalTernaryExpression


namespace BurnSoft.Applications.MGC.UnitTest.Firearms
{
    [TestClass]
    public class ExportXmlTest
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
        /// The save to file
        /// </summary>
        private string _saveToFile;
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            // Vs2019.GetSetting("", TestContext);
            _errOut = @"";
            _databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Vs2019.GetSetting("DatabasePath", TestContext));
            _gunId = Vs2019.IGetSetting("MyGunCollectionID", TestContext);
            _saveToFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "unittest_fiream.xml");
        }
        [TestMethod]
        public void GenerateXmlTest()
        {
            if (File.Exists(_saveToFile)) File.Delete(_saveToFile);
            bool value = XmlExport.Generate(_databasePath, _gunId, "7.x", _saveToFile, out _errOut);

            if (value && File.Exists(_saveToFile))
            {
                TestContext.WriteLine($"File was saved to {_saveToFile}");
            }
            else
            {
                TestContext.WriteLine("Unable to save file!");
            }
            General.HasTrueValue(value && File.Exists(_saveToFile), _errOut);
        }
    }
}
