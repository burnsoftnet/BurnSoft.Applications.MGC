using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using BurnSoft.Applications.MGC.Firearms;
using BurnSoft.Applications.MGC.Types;
using BurnSoft.Applications.MGC.UnitTest.Settings;
using BurnSoft.Universal;
// ReSharper disable NotAccessedField.Local

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
        /// The gun identifier
        /// </summary>
        private int _gunId;
        /// <summary>
        /// The database path
        /// </summary>
        private string _databasePath;
        /// <summary>
        /// The document title
        /// </summary>
        private string _docTitle;
        /// <summary>
        /// The document description
        /// </summary>
        private string _docDescription;
        /// <summary>
        /// The document category
        /// </summary>
        private string _docCategory;
        /// <summary>
        /// The document ext
        /// </summary>
        private string _docExt;
        /// <summary>
        /// The document path
        /// </summary>
        private string _docPath;
        /// <summary>
        /// The document ext number
        /// </summary>
        private int _docExtNumber;
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
            _docTitle = obj.FC(Vs2019.GetSetting("Doc_Title", TestContext));
            _docDescription = obj.FC(Vs2019.GetSetting("Doc_Description", TestContext));
            _docCategory = obj.FC(Vs2019.GetSetting("Doc_Category", TestContext));
            _docExt = obj.FC(Vs2019.GetSetting("Doc_Ext", TestContext));
            _docPath = Vs2019.GetSetting("Doc_Path", TestContext);
            _docExtNumber = Convert.ToInt32(Vs2019.GetSetting("Doc_Ext_Number", TestContext));
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
                if (Documents.Exists(_databasePath, _docTitle, out _errOut))
                {
                    long id = Documents.GetId(_databasePath, _docTitle, out _errOut);
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
                if (!Documents.Exists(_databasePath, _docTitle, out _errOut))
                {
                    if (!Documents.Add(_databasePath, _docTitle, _docDescription, _docCategory, _docPath, _docExtNumber,
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
        [TestMethod, TestCategory("Documents")]
        public void AddTest()
        {
            VerifyDoesntExists();
            bool value = Documents.Add(_databasePath, _docTitle, _docDescription, _docCategory, _docPath, _docExtNumber,
                out _errOut);

            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method ExistsTest.
        /// </summary>
        [TestMethod, TestCategory("Documents")]
        public void ExistsTest()
        {
            VerifyExists();
            bool value = Documents.Exists(_databasePath, _docTitle, out _errOut);

            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method DeleteTest.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        [TestMethod, TestCategory("Documents")]
        public void DeleteTest()
        {
            VerifyExists();
            bool value = false;
            try
            {
                long id = Documents.GetId(_databasePath, _docTitle, out _errOut);
                if (_errOut.Length > 0) throw new Exception(_errOut);
                if (!Documents.Delete(_databasePath, id, out _errOut)) throw new Exception(_errOut);
                value = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Defines the test method GetIdTest.
        /// </summary>
        [TestMethod, TestCategory("Documents")]
        public void GetIdTest()
        {
            VerifyExists();
            long id = Documents.GetId(_databasePath, _docTitle, out _errOut);
            TestContext.WriteLine($"ID for {_docTitle} is {id}");
            General.HasTrueValue(id > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method GetLastIdTest.
        /// </summary>
        [TestMethod, TestCategory("Documents")]
        public void GetLastIdTest()
        {
            VerifyExists();
            long id = Documents.GetLastId(_databasePath, out _errOut);
            TestContext.WriteLine($"ID for {_docTitle} is {id}");
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
                    TestContext.WriteLine("");
                    TestContext.WriteLine($"id: {d.Id}");
                    TestContext.WriteLine($"DocName: {d.DocName}");
                    TestContext.WriteLine($"DocDescription: {d.DocDescription}");
                    TestContext.WriteLine($"Length: {d.Length}");
                    TestContext.WriteLine($"Category: {d.Category}");
                    TestContext.WriteLine($"DocExt: {d.DocExt}");
                    TestContext.WriteLine($"DocFilename: {d.DocFilename}");
                    TestContext.WriteLine($"Dta: {d.Dta}");
                    TestContext.WriteLine($"DataFile: {d.DataFile}");
                    TestContext.WriteLine("");
                    TestContext.WriteLine("-------------------------------------------------------");
                }
            }
        }
        /// <summary>
        /// Print the Doc link list data
        /// </summary>
        /// <param name="value"></param>
        public void PrintLinkList(List<DocumentLinkList> value)
        {
            if (value.Count > 0)
            {
                foreach (DocumentLinkList d in value)
                {
                    TestContext.WriteLine("");
                    TestContext.WriteLine($"id: {d.Id}");
                    TestContext.WriteLine($"gun id: {d.GunId}");
                    TestContext.WriteLine($"doc id: {d.DocId}");
                    TestContext.WriteLine($"Dta: {d.Dta}");
                    TestContext.WriteLine($"Last Sync: {d.LastSync}");
                    TestContext.WriteLine("");
                    TestContext.WriteLine("-------------------------------------------------------");
                }
            }
        }
        /// <summary>
        /// Defines the test method GetListAllTest.
        /// </summary>
        [TestMethod, TestCategory("Documents")]
        public void GetListAllTest()
        {
            VerifyExists();
            List<DocumentList> value = Documents.GetList(_databasePath, out _errOut);
            PrintList(value);
            General.HasTrueValue(value.Count > 0, _errOut);
        }
        /// <summary>
        /// Defines the test method GetListByIdTest.
        /// </summary>
        [TestMethod, TestCategory("Documents")]
        public void GetListByIdTest()
        {
            VerifyExists();
            long id = Documents.GetLastId(_databasePath, out _errOut);
            List<DocumentList> value = Documents.GetList(_databasePath,id, out _errOut);
            PrintList(value);
            General.HasTrueValue(value.Count > 0, _errOut);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod, TestCategory("Documents")]
        public void GetListLinkAllTest()
        {
            VerifyExists();
            long documentId = Documents.GetLastId(_databasePath, out _errOut);
            bool didPass = Documents.PerformDocLink(_databasePath, _gunId, documentId, out _errOut);
            if (didPass)
            {
                List<DocumentLinkList> value = Documents.GetLinkList(_databasePath, out _errOut);
                PrintLinkList(value);
                General.HasTrueValue(value.Count > 0, _errOut);
            }
            else
            {
                General.HasTrueValue(false,_errOut);
            }
        }
        /// <summary>
        /// verify that the doc link already exists, if it doesn't then add it.
        /// </summary>
        /// <param name="docId"></param>
        /// <param name="gunid"></param>
        public void VerifyDockLinkExists(long docId, long gunid)
        {
            if (!Documents.DocLinkExists(_databasePath, gunid, docId, out _errOut))
            {
                Documents.PerformDocLink(_databasePath, gunid, docId, out _errOut);
            }
        }
        /// <summary>
        /// verify the doc link does no exists, if it does delete it
        /// </summary>
        /// <param name="docId"></param>
        /// <param name="gunid"></param>
        public void VerifyDockLinkDoesNotExists(long docId, long gunid)
        {
            if (Documents.DocLinkExists(_databasePath, gunid, docId, out _errOut))
            {
                
                Documents.DeleteFirearmFromLinkList(_databasePath, gunid, out _errOut);
            }
        }
        /// <summary>
        /// Adds the doc link
        /// </summary>
        [TestMethod, TestCategory("Documents")]
        public void AddDockLinkTest()
        {
            VerifyExists();
            bool value = false;
            try
            {
                long id = Documents.GetId(_databasePath, _docTitle, out _errOut);
                if (_errOut.Length > 0) throw new Exception(_errOut);
                VerifyDockLinkDoesNotExists(id, _gunId);

                if (!Documents.PerformDocLink(_databasePath, _gunId, id, out _errOut)) throw new Exception(_errOut);
                value = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Delete Doc Link test
        /// </summary>
        [TestMethod, TestCategory("Documents")]
        public void DeleteDocLinkTest()
        {
            VerifyExists();
            bool value = false;
            try
            {
                long id = Documents.GetId(_databasePath, _docTitle, out _errOut);
                if (_errOut.Length > 0) throw new Exception(_errOut);
                VerifyDockLinkExists(id, _gunId);
                long linkId = Documents.GetDocLinkId(_databasePath, id, _gunId, out _errOut);
                if (_errOut.Length > 0) throw new Exception(_errOut);

                if (!Documents.DeleteDocLink(_databasePath, linkId, out _errOut)) throw new Exception(_errOut);
                value = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Verify doc link exists
        /// </summary>
        [TestMethod, TestCategory("Documents")]
        public void DocLinkExistsTest()
        {
            VerifyExists();
            bool value = false;
            try
            {
                long id = Documents.GetId(_databasePath, _docTitle, out _errOut);
                if (_errOut.Length > 0) throw new Exception(_errOut);
                VerifyDockLinkExists(id, _gunId);
                long linkId = Documents.GetDocLinkId(_databasePath, id, _gunId, out _errOut);
                if (_errOut.Length > 0) throw new Exception(_errOut);

                if (!Documents.DocLinkExists(_databasePath, linkId,id, out _errOut)) throw new Exception(_errOut);
                value = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Get doc link Id test
        /// </summary>
        [TestMethod, TestCategory("Documents")]
        public void GetDocLinkIdTest()
        {
            VerifyExists();
            bool value = false;
            try
            {
                long id = Documents.GetId(_databasePath, _docTitle, out _errOut);
                if (_errOut.Length > 0) throw new Exception(_errOut);
                VerifyDockLinkExists(id, _gunId);
                long linkId = Documents.GetDocLinkId(_databasePath, id, _gunId, out _errOut);
                if (_errOut.Length > 0) throw new Exception(_errOut);
                TestContext.WriteLine($"Doc Link id is: {linkId}");
                value = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Get documentat from database test
        /// </summary>
        [TestMethod, TestCategory("Documents")]
        public void GetDocumentFromDbTest()
        {
            VerifyExists();
            bool value = false;
            try
            {
                long id = Documents.GetId(_databasePath, _docTitle, out _errOut);
                if (_errOut.Length > 0) throw new Exception(_errOut);
                if (!Documents.GetDocumentFromDb(_databasePath,AppDomain.CurrentDomain.BaseDirectory, id, out _errOut)) throw new Exception(_errOut);
                value = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            General.HasTrueValue(value, _errOut);
        }
        /// <summary>
        /// Test the count lined documents test
        /// </summary>
        [TestMethod, TestCategory("Documents")]
        public void CountLinkedDocsTest()
        {
            long value = 0;
            try
            {
                VerifyExists();
                long id = Documents.GetId(_databasePath, _docTitle, out _errOut);
                if (_errOut.Length > 0) throw new Exception(_errOut);
                VerifyDockLinkExists(id, _gunId);
                value = Documents.CountLinkedDocs(_databasePath, id, out _errOut);
                TestContext.WriteLine($"There are {value} documents that are attached to a firearm");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            General.HasTrueValue(value >0, _errOut);
        }
    }
}
