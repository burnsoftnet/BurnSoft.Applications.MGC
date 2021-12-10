using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Xml;
using BurnSoft.Applications.MGC.Global;
using BurnSoft.Applications.MGC.Types;
using BurnSoft.Universal;
// ReSharper disable RedundantAssignment
// ReSharper disable NotAccessedVariable

// ReSharper disable UnusedMember.Local
namespace BurnSoft.Applications.MGC.Firearms
{
    /// <summary>
    /// Class XmlImport. Imports the firearm information from the xml file and insert it into the database
    /// </summary>
    public class XmlImport
    {
        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string _classLocation = "BurnSoft.Applications.MGC.Firearms.XmlImport";
        /// <summary>
        /// Errors the message for regular Exceptions
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, Exception e) => $"{_classLocation}.{functionName} - {e.Message}";
        /// <summary>
        /// Errors the message for access violations
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, AccessViolationException e) => $"{_classLocation}.{functionName} - {e.Message}";
        /// <summary>
        /// Errors the message for invalid cast exception
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, InvalidCastException e) => $"{_classLocation}.{functionName} - {e.Message}";
        /// <summary>
        /// Errors the message argument exception
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, ArgumentException e) => $"{_classLocation}.{functionName} - {e.Message}";
        /// <summary>
        /// Errors the message for argument null exception.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, ArgumentNullException e) => $"{_classLocation}.{functionName} - {e.Message}";
        #endregion        
        /// <summary>
        /// Gets the XML node.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns>System.String.</returns>
        internal static string GetXmlNode(XmlNode instance)
        {
            string sAns;
            try
            {
                if (instance==null)
                    sAns = " ";
                else
                    sAns = instance.InnerText;
            }
            catch (Exception ex)
            {
                sAns = " ";
            }

            return sAns;
        }

        /// <summary>
        /// Get the details from the xml file and insert it into the database, this is the main
        /// information of the firearm and needs to be ran first before the other import function.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="strPath">The string path.</param>
        /// <param name="ownerId">The owner identifier.</param>
        /// <param name="useNumberCatOnly">if set to <c>true</c> [use number cat only].</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        public static bool Details(string databasePath,string strPath,int ownerId,bool useNumberCatOnly,  out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                XmlDocument doc = new XmlDocument();
                string serialNumber = "";
                string fullName = "";

                doc.Load(strPath);
                XmlNodeList elemlist = doc.GetElementsByTagName("Details");
                foreach (XmlNode xn in elemlist)
                {
                    fullName = Helpers.FormatFromXml(GetXmlNode(xn["FirstName"]));
                    string manufacturer = Helpers.FormatFromXml(GetXmlNode(xn["Manufacturer"]));
                    string modelName = Helpers.FormatFromXml(GetXmlNode(xn["ModelName"]));
                    serialNumber = Helpers.FormatFromXml(GetXmlNode(xn["SerialNumber"]));
                    string sType = Helpers.FormatFromXml(GetXmlNode(xn["Type"]));
                    string caliber = Helpers.FormatFromXml(GetXmlNode(xn["Caliber"]));
                    string finish = Helpers.FormatFromXml(GetXmlNode(xn["Finish"]));
                    string condition = Helpers.FormatFromXml(GetXmlNode(xn["Condition"]));
                    string customId = Helpers.FormatFromXml(GetXmlNode(xn["CustomID"]));
                    string natId = Helpers.FormatFromXml(GetXmlNode(xn["NatID"]));
                    string gripId = Helpers.FormatFromXml(GetXmlNode(xn["GripID"]));
                    string weight = Helpers.FormatFromXml(GetXmlNode(xn["Weight"]));
                    string height = Helpers.FormatFromXml(GetXmlNode(xn["Height"]));
                    string barrelLength = Helpers.FormatFromXml(GetXmlNode(xn["BarrelLength"]));
                    string action = Helpers.FormatFromXml(GetXmlNode(xn["Action"]));
                    string feedsystem = Helpers.FormatFromXml(GetXmlNode(xn["Feedsystem"]));
                    string sights = Helpers.FormatFromXml(GetXmlNode(xn["Sights"]));
                    string purchasedPrice = Helpers.FormatFromXml(GetXmlNode(xn["PurchasedPrice"]));
                    string purchasedFrom = Helpers.FormatFromXml(GetXmlNode(xn["PurchasedFrom"]));
                    string appraisedValue = Helpers.FormatFromXml(GetXmlNode(xn["AppraisedValue"]));
                    string appraisalDate = Helpers.FormatFromXml(GetXmlNode(xn["AppraisalDate"]));
                    string appraisedBy = Helpers.FormatFromXml(GetXmlNode(xn["AppraisedBy"]));
                    string insuredValue = Helpers.FormatFromXml(GetXmlNode(xn["InsuredValue"]));
                    string sgChoke = Helpers.FormatFromXml(GetXmlNode(xn["SGChoke"]));
                    string storageLocation = Helpers.FormatFromXml(GetXmlNode(xn["StorageLocation"]));
                    string conditionComments = Helpers.FormatFromXml(GetXmlNode(xn["ConditionComments"]));
                    string additionalNotes = Helpers.FormatFromXml(GetXmlNode(xn["AdditionalNotes "]));
                    string produced = Helpers.FormatFromXml(GetXmlNode(xn["Produced"]));
                    string isCandR = Helpers.FormatFromXml(GetXmlNode(xn["IsCandR"]));
                    string petLoads = Helpers.FormatFromXml(GetXmlNode(xn["PetLoads"]));
                    string dtp = Helpers.FormatFromXml(GetXmlNode(xn["dtp"]));
                    string importer = Helpers.FormatFromXml(GetXmlNode(xn["Importer"]));
                    string reManDt = Helpers.FormatFromXml(GetXmlNode(xn["ReManDT"]));
                    bool bBoundBook = Convert.ToBoolean(Helpers.FormatFromXml(GetXmlNode(xn["BoundBook"])));
                    string sCaliber3 = Helpers.FormatFromXml(GetXmlNode(xn["Caliber3"]));
                    string sTwist = Helpers.FormatFromXml(GetXmlNode(xn["TwistOfRate"]));
                    string sTrigger = Helpers.FormatFromXml(GetXmlNode(xn["TriggerPull"]));
                    string sClassification = Helpers.FormatFromXml(GetXmlNode(xn["Classification"]));
                    string sDateOfCr = Helpers.FormatFromXml(GetXmlNode(xn["DateofCR"]));
                    string strBarWid = Helpers.FormatFromXml(GetXmlNode(xn["BarWid"]));
                    string strBarHei = Helpers.FormatFromXml(GetXmlNode(xn["BarHei"]));
                    string sClassIiiOwner = Helpers.FormatFromXml(GetXmlNode(xn["ClassIiiOwner"]));
                    bool isClassIii = Convert.ToBoolean(Helpers.FormatFromXml(GetXmlNode(xn["IsClassIII"])));

                    string poi = Helpers.FormatFromXml(GetXmlNode(xn["POI"]));
                    long manId = Manufacturers.GetId(databasePath, manufacturer, out errOut);
                    if (errOut.Length > 0)
                        throw new Exception(errOut);

                    long modId = Models.GetId(databasePath, modelName, manId, out errOut);
                    if (errOut.Length > 0)
                        throw new Exception(errOut);

                    long lGripId = Grips.GetId(databasePath, gripId, out errOut);
                    if (errOut.Length > 0)
                        throw new Exception(errOut);

                    long lNatId = Nationality.GetId(databasePath, natId, out errOut);
                    if (errOut.Length > 0)
                        throw new Exception(errOut);

                    GunTypes.UpdateGunType(databasePath, sType, out errOut);
                    if (errOut.Length > 0)
                        throw new Exception(errOut);


                    if (!MyCollection.Add(databasePath, useNumberCatOnly, ownerId, manId, fullName, modelName, modId, serialNumber, sType, caliber,
                        finish, condition, customId, lNatId, lGripId, weight, height, gripId, barrelLength, strBarWid, strBarHei, action, feedsystem,
                        sights, purchasedPrice, purchasedFrom, appraisedValue, appraisalDate, appraisedBy, insuredValue, storageLocation, conditionComments,
                        additionalNotes, produced, petLoads, dtp, Convert.ToBoolean(isCandR), importer, reManDt, poi, sgChoke, Convert.ToBoolean(bBoundBook), sTwist, sTrigger, sCaliber3, sClassification, sDateOfCr, isClassIii, sClassIiiOwner, out errOut))
                        throw new Exception(errOut);
                }

                long id = MyCollection.GetLastId(databasePath, out errOut);
                if (errOut.Length > 0)
                    throw new Exception(errOut);
                bAns = MyCollection.Verify(databasePath, id, fullName, serialNumber, out errOut);
                if (errOut.Length > 0)
                    throw new Exception(errOut);
            }
            catch (Exception ex)
            {

                errOut = ErrorMessage("Details", ex);
            }

            return bAns;
        }

        public static bool Accessories(string databasePath, string Path, int gunId, out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {

            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Accessories", e);
            }
            return bAns;
        }

    }
}
