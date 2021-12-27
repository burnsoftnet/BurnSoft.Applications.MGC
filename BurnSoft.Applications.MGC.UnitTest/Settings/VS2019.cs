using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable InconsistentNaming

namespace BurnSoft.Applications.MGC.UnitTest.Settings
{
    /// <summary>
    /// Class VS2019. Seetings class that will allow me to put setting in this section or a unit test settings file if that is working.
    /// This was created because my unit test file from VS2017 would not work in VS2019, so this function was created to allow either or
    /// when the settings file is available.
    /// </summary>
    public class Vs2019
    {
        /// <summary>
        /// Gets or sets the test context.
        /// </summary>
        /// <value>The test context.</value>
        public TestContext TestContext { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Vs2019"/> class.
        /// </summary>
        /// <param name="con">The con.</param>
        public Vs2019(TestContext con)
        {
            TestContext = con;
        }
        /// <summary>
        /// Generals the settings.
        /// </summary>
        /// <returns>List&lt;Tuple&lt;System.String, System.String&gt;&gt;.</returns>
        private static List<Tuple<string, string>> GeneralSettings()
        {
            string testCaliber = @"10mm gunny";
            List<Tuple<string, string>> ls = new List<Tuple<string, string>>();
            ls.Add(new Tuple<string, string>("DatabasePath", "data\\mgc.mdb"));
            ls.Add(new Tuple<string, string>("XMLImport", "data\\unittest_fiream.xml"));
            ls.Add(new Tuple<string, string>("XMLImport2", "data\\ExportFirearm_Glock_G17_Open_Class.xml"));
            ls.Add(new Tuple<string, string>("OwnerId", "1"));
            ls.Add(new Tuple<string, string>("MyGunCollectionID", "3"));
            ls.Add(new Tuple<string, string>("MyGunCollection_ShopOldName", "Mike's Guns"));
            ls.Add(new Tuple<string, string>("MyGunCollection_ShopNewName", "Mikes Guns"));
            ls.Add(new Tuple<string, string>("ManufacturersTestName", "OpenGlock"));
            ls.Add(new Tuple<string, string>("Accessories_Manufacturer", "Glock"));
            ls.Add(new Tuple<string, string>("Accessories_Name", "21 Round Mag"));
            ls.Add(new Tuple<string, string>("Accessories_serialNumber", "N/A"));
            ls.Add(new Tuple<string, string>("Accessories_condition", "New"));
            ls.Add(new Tuple<string, string>("Accessories_notes", "extra mag's for the gun"));
            ls.Add(new Tuple<string, string>("Accessories_use", "Extra Mag"));
            ls.Add(new Tuple<string, string>("Accessories_purValue", "19.95"));
            ls.Add(new Tuple<string, string>("Accessories_appValue", "10.00"));
            ls.Add(new Tuple<string, string>("Accessories_civ", "true"));
            ls.Add(new Tuple<string, string>("Accessories_ic", "false"));
            ls.Add(new Tuple<string, string>("Model_LookUp", "Glock"));
            ls.Add(new Tuple<string, string>("Caliber_Test", testCaliber));
            ls.Add(new Tuple<string, string>("Ammo_Id", "12"));
            ls.Add(new Tuple<string, string>("Ammo_Manufacturer", "WildCats"));
            ls.Add(new Tuple<string, string>("Ammo_Name", "WildCats 10mm gunny"));
            ls.Add(new Tuple<string, string>("Ammo_Caliber", testCaliber));
            ls.Add(new Tuple<string, string>("Ammo_Grain", "500"));
            ls.Add(new Tuple<string, string>("Ammo_Jacket", "FMJ Gold"));
            ls.Add(new Tuple<string, string>("Ammo_Qty", "100"));
            ls.Add(new Tuple<string, string>("Ammo_DCal", "500"));
            ls.Add(new Tuple<string, string>("Ammo_VelocityNumber", "2000"));
            ls.Add(new Tuple<string, string>("Shops_Name", "Gunny's Big Ass Guns"));
            ls.Add(new Tuple<string, string>("Shops_Name_Existing", "Mike's Guns"));
            ls.Add(new Tuple<string, string>("BarrelConvoKit_DefaultId", "1"));
            ls.Add(new Tuple<string, string>("BarrelConvoKit_Add_ModelName", "Advantage Arms"));
            ls.Add(new Tuple<string, string>("BarrelConvoKit_Add_Caliber", ".22 LR"));
            ls.Add(new Tuple<string, string>("BarrelConvoKit_Add_Finish", "Black"));
            ls.Add(new Tuple<string, string>("BarrelConvoKit_Add_BarrelLength", "4.49 in."));
            ls.Add(new Tuple<string, string>("BarrelConvoKit_Add_PetLoads", ".22 Short"));
            ls.Add(new Tuple<string, string>("BarrelConvoKit_Add_Action", "Safe action"));
            ls.Add(new Tuple<string, string>("BarrelConvoKit_Add_Feedsystem", "10 round magazine"));
            ls.Add(new Tuple<string, string>("BarrelConvoKit_Add_Sights", "Fixed front and rear"));
            ls.Add(new Tuple<string, string>("BarrelConvoKit_Add_PurchasedPrice", "299.99"));
            ls.Add(new Tuple<string, string>("BarrelConvoKit_Add_PurchasedFrom", "Bud's Police Supply"));
            ls.Add(new Tuple<string, string>("BarrelConvoKit_Add_Height", "7.32 in."));
            ls.Add(new Tuple<string, string>("BarrelConvoKit_Add_Type", "22LR Conversion Kit G17/22"));
            ls.Add(new Tuple<string, string>("BarrelConvoKit_Add_IsDefault", "false"));
            ls.Add(new Tuple<string, string>("Classification_Name", "R&D"));
            ls.Add(new Tuple<string, string>("GunSmith_Name", "Gunny's Hack Shop"));
            ls.Add(new Tuple<string, string>("GunDetails_OrderDetails", "Make it fast"));
            ls.Add(new Tuple<string, string>("GunDetails_Notes", "Did some stuff to it, it didn't blow up so it's good"));
            ls.Add(new Tuple<string, string>("GunDetails_StartDate", "1/1/2021"));
            ls.Add(new Tuple<string, string>("GunDetails_ReturnDate", "2/1/2021"));
            ls.Add(new Tuple<string, string>("MaintenanceDetails_PlanId", "1"));
            ls.Add(new Tuple<string, string>("MaintenanceDetails_Name", "Complete Cleaning"));
            ls.Add(new Tuple<string, string>("MaintenanceDetails_OperationDate", "4/16/2021 8:58:54 AM"));
            ls.Add(new Tuple<string, string>("MaintenanceDetails_OperationDueDate", "4/16/2021 8:58:54 AM"));
            ls.Add(new Tuple<string, string>("MaintenanceDetails_RoundsFired", "300"));
            ls.Add(new Tuple<string, string>("MaintenanceDetails_Notes", "Test"));
            ls.Add(new Tuple<string, string>("MaintenanceDetails_BarrelSystemId", "1"));
            ls.Add(new Tuple<string, string>("MaintenanceDetails_DoesCount", "true"));
            ls.Add(new Tuple<string, string>("MaintenancePlans_Name", "Unit Test Cleaning"));
            ls.Add(new Tuple<string, string>("MaintenancePlans_OperationDetails", "Doesn't have anything"));
            ls.Add(new Tuple<string, string>("MaintenancePlans_IntervalsInDays", "0"));
            ls.Add(new Tuple<string, string>("MaintenancePlans_IntervalInRoundsFired", "500"));
            ls.Add(new Tuple<string, string>("MaintenancePlans_Notes", "It's a miricle if it works"));
            ls.Add(new Tuple<string, string>("Models_ManufacturerId", "15"));
            ls.Add(new Tuple<string, string>("Models_Name", "Glock gXXX"));
            ls.Add(new Tuple<string, string>("Nationality_Name", "RugerCountry"));
            ls.Add(new Tuple<string, string>("WishList_Manufacturer", "unicorn"));
            ls.Add(new Tuple<string, string>("WishList_Model", "unicorn poop luancher"));
            ls.Add(new Tuple<string, string>("WishList_PlaceToBuy", "the lepracon guild"));
            ls.Add(new Tuple<string, string>("WishList_Qty", "2"));
            ls.Add(new Tuple<string, string>("WishList_Price", "99.99"));
            ls.Add(new Tuple<string, string>("WishList_Notes", "one for each hand"));
            ls.Add(new Tuple<string, string>("CR_ReportName", "Test Report"));
            ls.Add(new Tuple<string, string>("CR_SQL", "select * from somtable"));
            ls.Add(new Tuple<string, string>("CR_Column_TableId", "4"));
            ls.Add(new Tuple<string, string>("CR_Column_DisplayName", "Full Name"));
            ls.Add(new Tuple<string, string>("Buyer_Name", "test user"));
            ls.Add(new Tuple<string, string>("Buyer_Address1", "test address"));
            ls.Add(new Tuple<string, string>("Buyer_Address2", "32323"));
            ls.Add(new Tuple<string, string>("Buyer_City", "testton"));
            ls.Add(new Tuple<string, string>("Buyer_State", "test"));
            ls.Add(new Tuple<string, string>("Buyer_ZipCode", "24332"));
            ls.Add(new Tuple<string, string>("Buyer_Phone", "555-555-5555"));
            ls.Add(new Tuple<string, string>("Buyer_Country", "usa"));
            ls.Add(new Tuple<string, string>("Buyer_eMail", "tets@test.com"));
            ls.Add(new Tuple<string, string>("Buyer_Lic", "222-333-4455-555-"));
            ls.Add(new Tuple<string, string>("Buyer_dLic", "3333333333"));
            ls.Add(new Tuple<string, string>("Buyer_DOB", "33/33/3333"));
            ls.Add(new Tuple<string, string>("Buyer_Resident", "franlkin county"));
            ls.Add(new Tuple<string, string>("Buyer_Fax", "N/A"));
            ls.Add(new Tuple<string, string>("Buyer_WebSite", "N/A"));
            ls.Add(new Tuple<string, string>("Appraisers_Name", "Joe Gun Grabers"));
            ls.Add(new Tuple<string, string>("Doc_Title", "ATI 9mm PCC Super POP"));
            ls.Add(new Tuple<string, string>("Doc_Description", "ATI 9mm Proof of purchase"));
            ls.Add(new Tuple<string, string>("Doc_Category", "Proof of Purchase"));
            ls.Add(new Tuple<string, string>("Doc_Ext", "pdf"));
            ls.Add(new Tuple<string, string>("Doc_Ext_Number", "1"));
            ls.Add(new Tuple<string, string>("Doc_Path", "data\\mgc_doc.pdf"));
            //ls.Add(new Tuple<string, string>("", ""));
            return ls;
        }
        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        private static string GetSettings(string value)
        {
            string sAns = @"";
            List<Tuple<string, string>> ls = GeneralSettings();
            foreach (Tuple<string, string> l in ls)
            {
                if (l.Item1.Equals(value))
                {
                    sAns = l.Item2;
                    break;
                }
            }
            return sAns;
        }
        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="con">The con.</param>
        /// <returns>System.String.</returns>
        private static string GetSettings(string value, TestContext con)
        {
            string sAns;

            Vs2019 obj = new Vs2019(con);
            if (obj.TestSettingsLoaded(value))
            {
                sAns = con.Properties[value].ToString();
            }
            else
            {
                sAns = GetSetting(value);
            }

            return sAns;
        }
        /// <summary>
        /// Tests the settings loaded.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool TestSettingsLoaded(string property)
        {
            bool bAns = false;
            try
            {
                if (TestContext != null)
                {
                    if (TestContext.Properties[property] != null)
                    {
                        string value = TestContext.Properties[property].ToString();
                        bAns = value.Length > 0;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return bAns;
        }
        /// <summary>
        /// Gets the setting.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string GetSetting(string value) => GetSettings(value);
        /// <summary>
        /// is the get setting.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Int32.</returns>
        public static int IGetSetting(string value) => Convert.ToInt32(GetSettings(value));
        /// <summary>
        /// ds the get setting.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Double.</returns>
        public static double DGetSetting(string value) => Convert.ToDouble(GetSettings(value));
        /// <summary>
        /// bs the get setting.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool BGetSetting(string value) => Convert.ToBoolean(GetSettings(value));
        /// <summary>
        /// Gets the setting.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="con">The con.</param>
        /// <returns>System.String.</returns>
        public static string GetSetting(string value, TestContext con) => GetSettings(value, con);
        /// <summary>
        /// is the get setting.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="con">The con.</param>
        /// <returns>System.Int32.</returns>
        public static int IGetSetting(string value, TestContext con) => Convert.ToInt32(GetSettings(value, con));
        /// <summary>
        /// ds the get setting.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="con">The con.</param>
        /// <returns>System.Double.</returns>
        public static double DGetSetting(string value, TestContext con) => Convert.ToDouble(GetSettings(value, con));
        /// <summary>
        /// bs the get setting.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="con">The con.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool BGetSetting(string value, TestContext con) => Convert.ToBoolean(GetSettings(value, con));
    }
}
