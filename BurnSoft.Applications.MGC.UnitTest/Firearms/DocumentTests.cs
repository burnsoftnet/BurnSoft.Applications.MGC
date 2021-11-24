using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using BurnSoft.Applications.MGC.Firearms;
using BurnSoft.Applications.MGC.Types;
using BurnSoft.Applications.MGC.UnitTest.Settings;
using BurnSoft.Universal;

namespace BurnSoft.Applications.MGC.UnitTest.Firearms
{
    [TestClass]
    public class DocumentTests
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
        private string Doc_Title;
        private string Doc_Description;
        private string Doc_Category;
        private string Doc_Ext;
        private string Doc_Path;
        private int Doc_Ext_Number;
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
            Doc_Title = obj.FC(Vs2019.GetSetting("Doc_Title", TestContext));
            Doc_Description = obj.FC(Vs2019.GetSetting("Doc_Description", TestContext));
            Doc_Category = obj.FC(Vs2019.GetSetting("Doc_Category", TestContext));
            Doc_Ext = obj.FC(Vs2019.GetSetting("Doc_Ext", TestContext));
            Doc_Path = Vs2019.GetSetting("Doc_Path", TestContext);
            Doc_Ext_Number = Convert.ToInt32(Vs2019.GetSetting("Doc_Ext_Number", TestContext));
        }
        /// <summary>
        /// Verifies the doesnt exists.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        public void VerifyDoesntExists()
        {
            try
            {
                if (Documents.Exists(_databasePath, Doc_Title, out _errOut))
                {
                    long id = Documents.GetId(_databasePath, Doc_Title, out _errOut);
                    if (_errOut.Length > 0) throw new Exception(_errOut);
                    if (!Documents.Delete(_databasePath, id, out _errOut)) throw new Exception(_errOut);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e}");
            }
        }
        /// <summary>
        /// Verifies the exists.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        public void VerifyExists()
        {
            try
            {
                if (!Documents.Exists(_databasePath, Doc_Title, out _errOut))
                {
                    if (!Documents.Add(_databasePath, Doc_Title, Doc_Description, Doc_Category, Doc_Path, Doc_Ext_Number,
                        out _errOut)) throw new Exception(_errOut);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e}");
            }
        }
        /// <summary>
        /// Defines the test method AddTest.
        /// </summary>
        [TestMethod]
        public void AddTest()
        {
            VerifyDoesntExists();
            bool value = Documents.Add(_databasePath, Doc_Title, Doc_Description, Doc_Category, Doc_Path, Doc_Ext_Number,
                out _errOut);

            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method ExistsTest.
        /// </summary>
        [TestMethod]
        public void ExistsTest()
        {
            VerifyExists();
            bool value = Documents.Exists(_databasePath, Doc_Title, out _errOut);

            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method DeleteTest.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        [TestMethod]
        public void DeleteTest()
        {
            VerifyExists();
            bool value = false;
            try
            {
                long id = Documents.GetId(_databasePath, Doc_Title, out _errOut);
                if (_errOut.Length > 0) throw new Exception(_errOut);
                if (!Documents.Delete(_databasePath, id, out _errOut)) throw new Exception(_errOut);
                value = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method GetIdTest.
        /// </summary>
        [TestMethod]
        public void GetIdTest()
        {
            VerifyExists();
            long id = Documents.GetId(_databasePath, Doc_Title, out _errOut);
            TestContext.WriteLine($"ID for {Doc_Title} is {id}");
            General.HasTrueValue(id > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method GetLastIdTest.
        /// </summary>
        [TestMethod]
        public void GetLastIdTest()
        {
            VerifyExists();
            long id = Documents.GetLastId(_databasePath, out _errOut);
            TestContext.WriteLine($"ID for {Doc_Title} is {id}");
            General.HasTrueValue(id > 0, _errOut);
        }
        /// <summary>
        /// Prints the list.
        /// </summary>
        /// <param name="value">The value.</param>
        public void PrintList(List<DocumentList> value)
        {
            if (value.Count > 0)
            {
                foreach (DocumentList d in value)
                {
                    TestContext.WriteLine($"");
                    TestContext.WriteLine($"id: {d.Id}");
                    TestContext.WriteLine($"DocName: {d.DocName}");
                    TestContext.WriteLine($"DocDescription: {d.DocDescription}");
                    TestContext.WriteLine($"Length: {d.Length}");
                    TestContext.WriteLine($"Category: {d.Category}");
                    TestContext.WriteLine($"DocExt: {d.DocExt}");
                    TestContext.WriteLine($"DocFilename: {d.DocFilename}");
                    TestContext.WriteLine($"Dta: {d.Dta}");
                    TestContext.WriteLine($"DataFile: {d.DataFile}");
                    TestContext.WriteLine($"");
                    TestContext.WriteLine($"-------------------------------------------------------");
                }
            }
        }
        /// <summary>
        /// Defines the test method GetListAllTest.
        /// </summary>
        [TestMethod]
        public void GetListAllTest()
        {
            VerifyExists();
            long id = Documents.GetLastId(_databasePath, out _errOut);
            List<DocumentList> value = Documents.GetList(_databasePath, out _errOut);
            PrintList(value);
            General.HasTrueValue(value.Count > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method GetListByIdTest.
        /// </summary>
        [TestMethod]
        public void GetListByIdTest()
        {
            VerifyExists();
            long id = Documents.GetLastId(_databasePath, out _errOut);
            List<DocumentList> value = Documents.GetList(_databasePath,id, out _errOut);
            PrintList(value);
            General.HasTrueValue(value.Count > 0, _errOut);
        }
    }
}
