using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurnSoft.Applications.MGC.Types;
// ReSharper disable RedundantAssignment

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

        public static bool Generate(string databasePath, long gunId,string appVersion, out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                string xmlData = $"<?xml version=\"1.0\" encoding=\"utf-8\" ?>{Environment.NewLine}";
                xmlData = $"<Firearm>{Environment.NewLine}";
                xmlData = $"    <MGC>{Environment.NewLine}";
                xmlData = $"        <version>{appVersion}</version>{Environment.NewLine}";
                xmlData = $"    <MGC>{Environment.NewLine}";
                xmlData = $"{Environment.NewLine}";
                xmlData = $"{Environment.NewLine}";
                xmlData = $"{Environment.NewLine}";
                xmlData = $"</Firearm>{Environment.NewLine}";

            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Generate", e);
            }
            return bAns;
        }

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
                    sAns = $"       {Environment.NewLine}";
                    sAns = $"       {Environment.NewLine}";
                    sAns = $"       {Environment.NewLine}";
                    sAns = $"       {Environment.NewLine}";
                    sAns = $"       {Environment.NewLine}";
                    sAns = $"       {Environment.NewLine}";
                    sAns = $"       {Environment.NewLine}";
                    sAns = $"       {Environment.NewLine}";
                    sAns = $"       {Environment.NewLine}";
                    sAns = $"       {Environment.NewLine}";
                    sAns = $"       {Environment.NewLine}";
                }
                sAns = $"{Environment.NewLine}";
                sAns = $"{Environment.NewLine}";
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GenerateDetails", e);
            }
            sAns = $"   </Details>{Environment.NewLine}";
            return sAns;
        }
    }
}
