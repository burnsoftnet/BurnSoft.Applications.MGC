using BurnSoft.Applications.MGC.Firearms;
using BurnSoft.Applications.MGC.Types;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BurnSoft.Applications.MGC.LoadersLog
{
    /// <summary>
    /// Class FirearmHelpers Gun Collection Data Helper for the My Loaders Log Application
    /// </summary>
    public class FirearmHelpers
    {
        public static int CountFirearms(out string errOut)
        {
            string databasePath = RegistryHelpers.GetMGCPath(out errOut);
            string sql = "SELECT * from Gun_Collection where ItemSold=0";
            List<GunCollectionList> value = MyCollection.GetList(databasePath, sql, out errOut);
            return value.Count;
        }

        public static long GetManufacturersId(string name, out string errOut) => 
            Manufacturers.GetId(RegistryHelpers.GetMGCPath(out _), name, out errOut);

        public static string GetManufacturersName(int id, out string errOut) => 
            Manufacturers.GetName(RegistryHelpers.GetMGCPath(out _), id, out errOut);

        public static long GetModelId(string name, long manufacturerId, 
            out string errOut) => Models.GetId(RegistryHelpers.GetMGCPath(out _), 
                name, manufacturerId, out errOut, true);

        public static long GetNationalityId(string name, out string errOut) => 
            Nationality.GetId(RegistryHelpers.GetMGCPath(out _), name, out errOut, true);

        public static long GetGripId(string name, out string errOut) => 
            Grips.GetId(RegistryHelpers.GetMGCPath(out _), name, out errOut, true);

        public static long GetGunShopId(string name, out string errOut) => 
            Nationality.GetId(RegistryHelpers.GetMGCPath(out _), name, out errOut, true);

        public static long GetLastFirearmId(out string errOut) => 
            MyCollection.GetLastId(RegistryHelpers.GetMGCPath(out _), out errOut);
        
    }
}
