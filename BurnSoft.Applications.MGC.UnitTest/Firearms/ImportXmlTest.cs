using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using BurnSoft.Applications.MGC.Firearms;
using BurnSoft.Applications.MGC.Types;
using BurnSoft.Applications.MGC.UnitTest.Settings;

// ReSharper disable ConvertIfStatementToConditionalTernaryExpression


namespace BurnSoft.Applications.MGC.UnitTest.Firearms
{
    [TestClass]
    public class ImportXmlTest
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
        /// The owner identifier
        /// </summary>
        private int _ownerId;
        /// <summary>
        /// The database path
        /// </summary>
        private string _databasePath;
        /// <summary>
        /// The xml file to import
        /// </summary>
        private string _xmlImportFile;
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
            _ownerId = Vs2019.IGetSetting("OwnerId", TestContext);
            _xmlImportFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Vs2019.GetSetting("XMLImport2", TestContext));
        }
        /// <summary>
        /// Defines the test method ImportFileTest. This will use all the import function just like the application would, but with out the update to the progress bar
        /// </summary>
        [TestMethod, TestCategory("Import XML")]
        public void ImportFileTest()
        {
            bool value = false;
            try
            {
                //string expectedFullName = "Glock G17 Imported unit test";
                string expectedFullName = "Glock G17 Open Class";
                if (MyCollection.Exists(_databasePath, expectedFullName, out _errOut))
                {
                    long gId = MyCollection.GetId(_databasePath, expectedFullName, out _errOut);
                    if (_errOut.Length > 0) throw new Exception(_errOut);
                    if (!MyCollection.Delete(_databasePath, gId, out _errOut)) throw new Exception(_errOut);

                }

                if (!XmlImport.Details(_databasePath, _xmlImportFile, _ownerId, false, out _errOut )) throw new Exception(_errOut);
                long gunId = MyCollection.GetLastId(_databasePath, out _errOut);
                if (_errOut.Length > 0) throw new Exception(_errOut);
                if (!XmlImport.Accessories(_databasePath, _xmlImportFile, gunId, out _errOut)) throw new Exception(_errOut);
                if (!XmlImport.BarrelConverstionKitDetails(_databasePath, _xmlImportFile, gunId, out _errOut)) throw new Exception(_errOut);
                if (!XmlImport.GunSmithDetails(_databasePath, _xmlImportFile, gunId, out _errOut)) throw new Exception(_errOut);
                if (!XmlImport.MaintanceDetails(_databasePath, _xmlImportFile, gunId, out _errOut)) throw new Exception(_errOut);
                
                List<GunCollectionList> lst = MyCollection.GetList(_databasePath, gunId, out _errOut);
                if (_errOut.Length > 0) throw new Exception(_errOut);
                MyGunCollectionTest obj = new MyGunCollectionTest();
                obj.PrintList(lst);
                value = true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
            }
            General.HasTrueValue(value, _errOut);
        }
    }
}
