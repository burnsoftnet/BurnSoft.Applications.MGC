using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurnSoft.Applications.MGC.Types;
// ReSharper disable RedundantAssignment
// ReSharper disable NotAccessedVariable

// ReSharper disable UnusedMember.Local

namespace BurnSoft.Applications.MGC.Firearms
{
    /// <summary>
    /// Class XmlExport.  Export the firearm information in the view collection details form to an xml file.
    /// </summary>
    public class XmlExport
    {

        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string _classLocation = "BurnSoft.Applications.MGC.Firearms.XmlExport";
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
        //End Snippet        
        /// <summary>
        /// Generates the specified database path.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="appVersion">The application version.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.Exception"></exception>
        public static bool Generate(string databasePath, long gunId,string appVersion, out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                string xmlData = $"<?xml version=\"1.0\" encoding=\"utf-8\" ?>{Environment.NewLine}";
                xmlData += $"<Firearm>{Environment.NewLine}";
                xmlData += $"    <MGC>{Environment.NewLine}";
                xmlData += $"        <version>{appVersion}</version>{Environment.NewLine}";
                xmlData += $"    <MGC>{Environment.NewLine}";
                xmlData += GenerateDetails(databasePath, gunId, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                xmlData += GenerateAccessories(databasePath, gunId, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                xmlData += GenerateGunSmitheDetails(databasePath, gunId, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                xmlData += GenerateMaintanceDetails(databasePath, gunId, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                xmlData += GenerateBarrelConversKit(databasePath, gunId, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                xmlData += $"</Firearm>{Environment.NewLine}";
                xmlData = xmlData.Replace("&", "&amp;");
                //BSFileSystem objFs = new BSFileSystem();
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Generate", e);
            }
            return bAns;
        }
        /// <summary>
        /// Generates the details.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception"></exception>
        private static string GenerateDetails(string databasePath, long gunId, out string errOut)
        {
            string sAns = $"   <Details>{Environment.NewLine}";
            errOut = "";
            try
            {
                List<GunCollectionList> lst = MyCollection.GetList(databasePath, gunId, out errOut);
                if (errOut.Length > 0) throw  new Exception(errOut);
                foreach (GunCollectionList l in lst)
                {
                    sAns = $"       <FullName>{l.FullName}</FullName>{Environment.NewLine}";
                    sAns = $"       <Manufacturer>{l.Manufacturer}</Manufacturer>{Environment.NewLine}";
                    sAns = $"       <ModelName>{l.ModelName}</ModelName>{Environment.NewLine}";
                    sAns = $"       <SerialNumber>{l.SerialNumber}</SerialNumber>{Environment.NewLine}";
                    sAns = $"       <Type>{l.Type}</Type>{Environment.NewLine}";
                    sAns = $"       <Caliber>{l.Caliber}</Caliber>{Environment.NewLine}";
                    sAns = $"       <Finish>{l.Finish}</Finish>{Environment.NewLine}";
                    sAns = $"       <Condition>{l.Condition}</Condition>{Environment.NewLine}";
                    sAns = $"       <CustomID>{l.CustomId}</CustomID>{Environment.NewLine}";
                    sAns = $"       <NatID>{l.Nationality}</NatID>{Environment.NewLine}";
                    sAns = $"       <GripID>{l.GripType}</GripID>{Environment.NewLine}";
                    sAns = $"       <Weight>{l.Weight}</Weight>{Environment.NewLine}";
                    sAns = $"       <Height>{l.Height}</Height>{Environment.NewLine}";
                    sAns = $"       <BarrelLength>{l.BarrelLength}</BarrelLength>{Environment.NewLine}";
                    sAns = $"       <BarWid>{l.BarrelWidth}</BarWid>{Environment.NewLine}";
                    sAns = $"       <BarHei>{l.BarrelHeight}</BarHei>{Environment.NewLine}";
                    sAns = $"       <Action>{l.Action}</Action>{Environment.NewLine}";
                    sAns = $"       <Feedsystem>{l.FeedSystem}</Feedsystem>{Environment.NewLine}";
                    sAns = $"       <Sights>{l.Sights}</Sights>{Environment.NewLine}";
                    sAns = $"       <PurchasedPrice>{l.PurchasePrice}</PurchasedPrice>{Environment.NewLine}";
                    sAns = $"       <PurchasedFrom>{l.PurchaseFrom}</PurchasedFrom>{Environment.NewLine}";
                    sAns = $"       <AppraisedValue>{l.AppriasedValue}</AppraisedValue>{Environment.NewLine}";
                    sAns = $"       <AppraisalDate>{l.AppraisalDate}</AppraisalDate>{Environment.NewLine}";
                    sAns = $"       <AppraisedBy>{l.AppriasedBy}</AppraisedBy>{Environment.NewLine}";
                    sAns = $"       <InsuredValue>{l.InsuredValue}</InsuredValue>{Environment.NewLine}";
                    sAns = $"       <StorageLocation>{l.StorageLocation}</StorageLocation>{Environment.NewLine}";
                    sAns = $"       <ConditionComments>{l.ConditionComments}</ConditionComments>{Environment.NewLine}";
                    sAns = $"       <AdditionalNotes>{l.AdditionalNotes}</AdditionalNotes>{Environment.NewLine}";
                    sAns = $"       <Produced>{l.DateProduced}</Produced>{Environment.NewLine}";
                    sAns = $"       <IsCandR>{l.IsCAndR}</IsCandR>{Environment.NewLine}";
                    sAns = $"       <PetLoads>{l.PetLoads}</PetLoads>{Environment.NewLine}";
                    sAns = $"       <dtp>{l.DateTimeAdded}</dtp>{Environment.NewLine}";
                    sAns = $"       <Importer>{l.Importer}</Importer>{Environment.NewLine}";
                    sAns = $"       <ReManDT>{l.RemanufactureDate}</ReManDT>{Environment.NewLine}";
                    sAns = $"       <POI>{l.Poi}</POI>{Environment.NewLine}";
                    sAns = $"       <SGChoke>{l.ShotGunChoke}</SGChoke>{Environment.NewLine}";
                    sAns = $"       <Caliber3>{l.Caliber3}</Caliber3>{Environment.NewLine}";
                    sAns = $"       <TwistOfRate>{l.TwistRate}</TwistOfRate>{Environment.NewLine}";
                    sAns = $"       <TriggerPull>{l.TriggerPullInPounds}</TriggerPull>{Environment.NewLine}";
                    sAns = $"       <BoundBook>{l.IsInBoundBook}</BoundBook>{Environment.NewLine}";
                    sAns = $"       <Classification>{l.Classification}</Classification>{Environment.NewLine}";
                    sAns = $"       <DateofCR>{l.DateOfCAndR}</DateofCR>{Environment.NewLine}";
                    sAns = $"       <IsClassIII>{l.IsClass3Item}</IsClassIII>{Environment.NewLine}";
                    sAns = $"       <ClassIiiOwner>{l.Class3Owner}</ClassIiiOwner>{Environment.NewLine}";
                    //sAns = $"       {Environment.NewLine}";
                    //sAns = $"       {Environment.NewLine}";
                    //sAns = $"       {Environment.NewLine}";
                }
                //sAns = $"{Environment.NewLine}";
                //sAns = $"{Environment.NewLine}";
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GenerateDetails", e);
            }
            sAns = $"   </Details>{Environment.NewLine}";
            return sAns;
        }
        /// <summary>
        /// Generates the accessories.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception"></exception>
        private static string GenerateAccessories(string databasePath, long gunId, out string errOut)
        {
            string sAns = $"   <Accessories>{Environment.NewLine}";
            errOut = "";
            try
            {
                List<AccessoriesList> lst = Accessories.List(databasePath, gunId, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                foreach (AccessoriesList l in lst)
                {
                    sAns = $"       <Manufacturer>{l.Manufacturer}</Manufacturer>{Environment.NewLine}";
                    sAns = $"       <Model>{l.Model}</Model>{Environment.NewLine}";
                    sAns = $"       <SerialNumber>{l.SerialNumber}</SerialNumber>{Environment.NewLine}";
                    sAns = $"       <Condition>{l.Condition}</Condition>{Environment.NewLine}";
                    sAns = $"       <Notes>{l.Notes}</Notes>{Environment.NewLine}";
                    sAns = $"       <Use>{l.Use}</Use>{Environment.NewLine}";
                    sAns = $"       <PurValue>{l.PurchaseValue}</PurValue>{Environment.NewLine}";
                    sAns = $"       <appValue>{l.AppriasedValue}</appValue>{Environment.NewLine}";
                    sAns = $"       <civ>{l.CountInValue}</civ>{Environment.NewLine}";
                    sAns = $"       <ic>{l.IsChoke}</ic>{Environment.NewLine}";
                }
                //sAns = $"{Environment.NewLine}";
                //sAns = $"{Environment.NewLine}";
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GenerateAccessories", e);
            }
            sAns = $"   </Accessories>{Environment.NewLine}";
            return sAns;
        }
        /// <summary>
        /// Generates the maintance details.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception"></exception>
        private static string GenerateMaintanceDetails(string databasePath, long gunId, out string errOut)
        {
            string sAns = $"   <Maintance_Details>{Environment.NewLine}";
            errOut = "";
            try
            {
                List<MaintanceDetailsList> lst = MaintanceDetails.Lists(databasePath, gunId, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                foreach (MaintanceDetailsList l in lst)
                {
                    sAns = $"       <Name>{l.Name}</Name>{Environment.NewLine}";
                    sAns = $"       <OpDate>{l.OperationStartDate}</OpDate>{Environment.NewLine}";
                    sAns = $"       <OpDueDate>{l.OperationDueDate}</OpDueDate>{Environment.NewLine}";
                    sAns = $"       <RndFired>{l.RoundsFired}</RndFired>{Environment.NewLine}";
                    sAns = $"       <Notes>{l.Notes}</Notes>{Environment.NewLine}";
                    sAns = $"       <ammoUsed>{l.AmmoUsed}</ammoUsed>{Environment.NewLine}";
                }
                //sAns = $"{Environment.NewLine}";
                //sAns = $"{Environment.NewLine}";
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GenerateMaintanceDetails", e);
            }
            sAns = $"   </Maintance_Details>{Environment.NewLine}";
            return sAns;
        }
        /// <summary>
        /// Generates the gun smithe details.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception"></exception>
        private static string GenerateGunSmitheDetails(string databasePath, long gunId, out string errOut)
        {
            string sAns = $"   <GunSmith_Details>{Environment.NewLine}";
            errOut = "";
            try
            {
                List<GunSmithWorkDone> lst = GunSmithDetails.Lists(databasePath, gunId, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                foreach (GunSmithWorkDone l in lst)
                {
                    sAns = $"       <gsmith>{l.GunSmithName}</gsmith>{Environment.NewLine}";
                    sAns = $"       <sdate>{l.StartDate}</sdate>{Environment.NewLine}";
                    sAns = $"       <rdate>{l.ReturnDate}</rdate>{Environment.NewLine}";
                    sAns = $"       <od>{l.OrderDetails}</od>{Environment.NewLine}";
                    sAns = $"       <Notes>{l.Notes}</Notes>{Environment.NewLine}";
                }
                //sAns = $"{Environment.NewLine}";
                //sAns = $"{Environment.NewLine}";
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GenerateGunSmitheDetails", e);
            }
            sAns = $"   </GunSmith_Details>{Environment.NewLine}";
            return sAns;
        }
        /// <summary>
        /// Generates the barrel convers kit.
        /// </summary>
        /// <param name="databasePath">The database path.</param>
        /// <param name="gunId">The gun identifier.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception"></exception>
        private static string GenerateBarrelConversKit(string databasePath, long gunId, out string errOut)
        {
            string sAns = $"   <BarrelConverstionKit_Details>{Environment.NewLine}";
            errOut = "";
            try
            {
                string sql = $"SELECT * from Gun_Collection_Ext where GID={gunId}";
                List<BarrelSystems> lst = ExtraBarrelConvoKits.GetList(databasePath, sql, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                foreach (BarrelSystems l in lst)
                {
                    sAns = $"       <ModelName>{l.ModelName}</ModelName>{Environment.NewLine}";
                    sAns = $"       <Caliber>{l.Caliber}</Caliber>{Environment.NewLine}";
                    sAns = $"       <Finish>{l.Finish}</Finish>{Environment.NewLine}";
                    sAns = $"       <BarrelLength>{l.BarrelLength}</BarrelLength>{Environment.NewLine}";
                    sAns = $"       <PetLoads>{l.PetLoads}</PetLoads>{Environment.NewLine}";
                    sAns = $"       <Action>{l.Action}</Action>{Environment.NewLine}";
                    sAns = $"       <Feedsystem>{l.FeedSystem}</Feedsystem>{Environment.NewLine}";
                    sAns = $"       <Sights>{l.Sights}</Sights>{Environment.NewLine}";
                    sAns = $"       <PurchasedPrice>{l.PurchasedPrice}</PurchasedPrice>{Environment.NewLine}";
                    sAns = $"       <PurchasedFrom>{l.PurchasedFrom}</PurchasedFrom>{Environment.NewLine}";
                    sAns = $"       <dtp>{l.PurchaseDate}</dtp>{Environment.NewLine}";
                    sAns = $"       <Height>{l.Height}</Height>{Environment.NewLine}";
                    sAns = $"       <IsDefault>{l.IsDefault}</IsDefault>{Environment.NewLine}";
                    sAns = $"       <BarrelLength>{l.BarrelLength}</BarrelLength>{Environment.NewLine}";
                }
                //sAns = $"{Environment.NewLine}";
                //sAns = $"{Environment.NewLine}";
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GenerateBarrelConversKit", e);
            }
            sAns = $"   </BarrelConverstionKit_Details>{Environment.NewLine}";
            return sAns;
        }
    }
}
