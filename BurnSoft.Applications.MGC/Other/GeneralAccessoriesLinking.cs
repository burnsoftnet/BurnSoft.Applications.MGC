using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSoft.Applications.MGC.Other
{
    /// <summary>
    /// General Class to handline the linking between the firearm and the General Accessories.  
    /// We are keeping the Firearm accessories the way it is because there are some things that will
    /// never be put into general, while others can be. 
    /// </summary>
    public class GeneralAccessoriesLinking
    {
        public static bool AttachToFirearm(string databasePath, long id, long gunId, out string errOut)
        {
            bool bAns = false;
            errOut = @"";
            try
            {
                string sql = $"INSERT INTO General_Accessories_Link(GID, AID) Values({gunId},{id})";
                if (!Database.Execute(databasePath, sql, out errOut)) throw new Exception(errOut);
                sql = ""
                ////string sql = $"Update General_Accessories set Manufacturer='{manufacturer}',Model='{model}'," +
                ////             $"SerialNumber='{serialNumber}',Condition='{condition}',Notes='{notes}',Use='{use}'," +
                ////             $"PurValue={purValue},AppValue={appValue},CIV={iCiv},IC={iIc},sync_lastupdate=Now() where id={id}";
                bAns = Database.Execute(databasePath, sql, out errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("Update", e);
            }

            return bAns;
        }
    }
}
