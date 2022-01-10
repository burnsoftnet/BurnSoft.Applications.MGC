using System;
using System.Globalization;
using Microsoft.Win32;

// ReSharper disable UnusedMember.Local
// ReSharper disable ConvertToAutoProperty

namespace BurnSoft.Applications.MGC.Global
{
    /// <summary>
    /// Class Registry.  General Registry class for the My gun Collection Application to read, setups, and write
    /// </summary>
    public class MyRegistry
    {

        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string _classLocation = "BurnSoft.Applications.MGC.Global.MyRegistry";
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

        private string _regPath;
        private string _regSuccessful;
        private string _regSetHistListtb;
        private string _regSetHistListdt;
        private bool _regAlertOnBackUp = true;
        private int _regTrackHistoryDays;
        private string _regLastPath;
        private string _regLastFile;
        private bool _regBackupOnExit;
        private bool _regUseOrgImage;
        private bool _regViewPetLoads = true;
        private bool _regIndvReports = true;
        private bool _regTrackHistory = true;
        private string _regNumberFormat;
        private bool _regAutoUpdate;
        private bool _regUseProxy;
        private bool _regUseNumberCatOnly;
        private bool _regAuditammo;
        private bool _regUseautoassign;
        private bool _regUniquecustcatid;
        private bool _regUseselectiveboundbook;
        /// <summary>
        /// Gets or sets the default reg path.
        /// </summary>
        /// <value>The default reg path.</value>
        public string DefaultRegPath
        {
            get
            {
                if (_regPath.Length == 0)
                    _regPath = @"Software\\BurnSoft\\BSMGC";
                return _regPath;
            }
            set => _regPath = value;
        }
        private string RegSuccessful
        {
            get
            {
                if (_regSuccessful.Length == 0)
                    _regSuccessful = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                return _regSuccessful;
            }
            set => _regSuccessful = value;
        }
        private string RegSetHistListtb
        {
            get => _regSetHistListtb;
            set => _regSetHistListtb = value;
        }
        private string RegSetHistListdt
        {
            get => _regSetHistListdt;
            set => _regSetHistListdt = value;
        }
        private bool RegAlertOnBackUp
        {
            get => _regAlertOnBackUp;
            set => _regAlertOnBackUp = value;
        }
        private int RegTrackHistoryDays
        {
            get
            {
                if (_regTrackHistoryDays == 0)
                    _regTrackHistoryDays = 15;
                return _regTrackHistoryDays;
            }
            set => _regTrackHistoryDays = value;
        }
        private string RegLastPath
        {
            get
            {
                if (_regLastPath.Length == 0)
                    _regLastPath = @"C:\";
                return _regLastPath;
            }
            set => _regLastPath = value;
        }
        private string RegLastFile
        {
            get
            {
                if (_regLastFile.Length == 0)
                    _regLastFile = "MGC.MDB";
                return _regLastFile;
            }
            set => _regLastFile = value;
        }
        private bool RegBackupOnExit
        {
            get => _regBackupOnExit;
            set => _regBackupOnExit = value;
        }
        private bool RegUseOrgImage
        {
            get => _regUseOrgImage;
            set => _regUseOrgImage = value;
        }
        private bool RegViewPetLoads
        {
            get => _regViewPetLoads;
            set => _regViewPetLoads = value;
        }
        private bool RegIndvReports
        {
            get => _regIndvReports;
            set => _regIndvReports = value;
        }
        private bool RegTrackHistory
        {
            get => _regTrackHistory;
            set => _regTrackHistory = value;
        }
        private string RegNumberFormat
        {
            get
            {
                if (_regNumberFormat.Length == 0)
                    _regNumberFormat = "0000";
                return _regNumberFormat;
            }
            set => _regNumberFormat = value;
        }
        private bool RegAutoUpdate
        {
            get => _regAutoUpdate;
            set => _regAutoUpdate = value;
        }
        private bool RegUseProxy
        {
            get => _regUseProxy;
            set => _regUseProxy = value;
        }
        private bool RegAuditammo
        {
            get => _regAuditammo;
            set => _regAuditammo = value;
        }
        private bool RegUseNumberCatOnly
        {
            get => _regUseNumberCatOnly;
            set => _regUseNumberCatOnly = value;
        }
        private bool RegUseautoassign
        {
            get => _regUseautoassign;
            set => _regUseautoassign = value;
        }
        private bool RegUniquecustcatid
        {
            get => _regUniquecustcatid;
            set => _regUniquecustcatid = value;
        }
        private bool RegUseselectiveboundbook
        {
            get => _regUseselectiveboundbook;
            set => _regUseselectiveboundbook = value;
        }
        public void CreateSubKey(string strValue)
        {
            Registry.CurrentUser.CreateSubKey(strValue);
        }

        public void UpDateAppDetails(string productVersion, string productName, string executablePath,string appPath, string logFile, string databasePath, string appDataPath)
        {
            string strValue = DefaultRegPath;
            if (!RegSubKeyExists(strValue))
                CreateSubKey(strValue);
            RegistryKey myReg;
            myReg = Registry.CurrentUser.OpenSubKey(strValue, true);
            myReg.SetValue("Version", productVersion);
            myReg.SetValue("AppName", productName);
            myReg.SetValue("AppEXE", executablePath);
            myReg.SetValue("Path", appPath);
            myReg.SetValue("LogPath", logFile);
            myReg.SetValue("DataBase", databasePath);
            myReg.SetValue("AppDataPath", appDataPath);
            myReg.Close();
        }

        public bool RegSubKeyExists(string strValue)
        {
            bool bAns = false;
            try
            {
                RegistryKey myReg = Registry.CurrentUser.OpenSubKey(strValue, true);
                if (myReg == null)
                    bAns = false;
                else
                    bAns = true;
            }
            catch (Exception ex)
            {
                bAns = false;
            }
            return bAns;
        }

        public string GetRegSubKeyValue(string strKey, string strValue, string strDefault)
        {
            string sAns = "";
            string strMsg = "";
            RegistryKey myReg;
            try
            {
                if (RegSubKeyExists(strKey))
                {
                    myReg = Registry.CurrentUser.OpenSubKey(strKey, true);
                    if (myReg.GetValue(strValue).ToString().Length > 0)
                        sAns = myReg.GetValue(strValue).ToString();
                    else
                    {
                        myReg.SetValue(strValue, strDefault);
                        sAns = strDefault;
                    }
                }
                else
                {
                    CreateSubKey(strKey);
                    myReg = Registry.CurrentUser.OpenSubKey(strKey, true);
                    myReg.SetValue(strValue, strDefault);
                    sAns = strDefault;
                }
            }
            catch (Exception ex)
            {
                sAns = strDefault;
            }
            return sAns;
        }

        public void SetSettingDetails()
        {
            if (!SettingsExists())
            {
                RegistryKey myReg;
                string strValue = DefaultRegPath + @"\Settings";
                myReg = Registry.CurrentUser.OpenSubKey(strValue, true);

                myReg = Registry.CurrentUser.CreateSubKey(strValue);
                myReg.SetValue("Successful", RegSuccessful);
                myReg.SetValue("SetHistListtb", RegSetHistListtb);
                myReg.SetValue("SetHistListdt", RegSetHistListdt);
                myReg.SetValue("AlertOnBackUp", RegAlertOnBackUp);
                myReg.SetValue("TrackHistoryDays", RegTrackHistoryDays);
                myReg.SetValue("TrackHistory", RegTrackHistory);
                myReg.SetValue("LastPath", RegLastPath);
                myReg.SetValue("LastFile", RegLastFile);
                myReg.SetValue("BackupOnExit", RegBackupOnExit);
                myReg.SetValue("UseOrgImage", RegUseOrgImage);
                myReg.SetValue("ViewPetLoads", RegViewPetLoads);
                myReg.SetValue("IndvReports", RegIndvReports);
                myReg.SetValue("UseNumberCatOnly", RegUseNumberCatOnly);
                myReg.SetValue("AUDITAMMO", RegAuditammo);
                myReg.Close();
            }
        }



        public bool SettingsExists()
        {
            bool bAns = false;
            RegistryKey myReg;
            string strValue = DefaultRegPath + @"\Settings";
            myReg = Registry.CurrentUser.OpenSubKey(strValue, true);
            if (myReg == null)
                bAns = false;
            else
                bAns = true;
            return bAns;
        }


        public void GetSettings(ref string lastSucBackup, ref bool alertOnBackUp, ref int trackHistoryDays, ref bool trackHistory, ref bool autoBackup, ref bool uoimg, ref bool usePl, ref bool useIPer, ref bool useCcid, ref bool useaa, ref bool useAacid, ref bool useUniqueCustId, ref bool bUseselectiveboundbook)
        {
            RegistryKey myReg;
            string numberFormat;
            bool useProxy;
            bool autoUpdate;
            string strValue = DefaultRegPath + @"\Settings";
            try
            {
                myReg = Registry.CurrentUser.OpenSubKey(strValue, true);
                if (myReg == null)
                    SetSettingDetails();
                if ((myReg != null))
                {
                    trackHistoryDays = Convert.ToInt32(GetRegSubKeyValue(strValue, "TrackHistoryDays", RegTrackHistoryDays.ToString())); // CInt(MyReg.GetValue("TrackHistoryDays", ""))
                    trackHistory = Convert.ToBoolean(GetRegSubKeyValue(strValue, "TrackHistory", RegTrackHistory.ToString()));
                    numberFormat = Convert.ToString(GetRegSubKeyValue(strValue, "NumberFormat", RegNumberFormat));
                    autoUpdate = Convert.ToBoolean(GetRegSubKeyValue(strValue, "AutoUpdate", RegAutoUpdate.ToString()));
                    useProxy = Convert.ToBoolean(GetRegSubKeyValue(strValue, "UseProxy", RegUseProxy.ToString()));
                    lastSucBackup = GetRegSubKeyValue(strValue, "Successful", RegSuccessful);
                    alertOnBackUp = Convert.ToBoolean(GetRegSubKeyValue(strValue, "AlertOnBackUp", RegAlertOnBackUp.ToString()));
                    autoBackup = Convert.ToBoolean(GetRegSubKeyValue(strValue, "BackupOnExit", RegBackupOnExit.ToString()));
                    uoimg = Convert.ToBoolean(GetRegSubKeyValue(strValue, "UseOrgImage", RegUseOrgImage.ToString()));
                    usePl = Convert.ToBoolean(GetRegSubKeyValue(strValue, "ViewPetLoads", RegViewPetLoads.ToString()));
                    useIPer = Convert.ToBoolean(GetRegSubKeyValue(strValue, "IndvReports", RegIndvReports.ToString()));
                    useCcid = Convert.ToBoolean(GetRegSubKeyValue(strValue, "UseNumberCatOnly", RegUseNumberCatOnly.ToString()));
                    useaa = Convert.ToBoolean(GetRegSubKeyValue(strValue, "AUDITAMMO", RegAuditammo.ToString()));
                    useAacid = Convert.ToBoolean(GetRegSubKeyValue(strValue, "USEAUTOASSIGN", RegUseautoassign.ToString()));
                    useUniqueCustId = Convert.ToBoolean(GetRegSubKeyValue(strValue, "DISABLEUNIQUECUSTCATID", RegUniquecustcatid.ToString()));
                    bUseselectiveboundbook = Convert.ToBoolean(GetRegSubKeyValue(strValue, "USESELECTIVEBOUNDBOOK", RegUseselectiveboundbook.ToString()));
                }
                else
                {
                    trackHistoryDays = RegTrackHistoryDays;
                    trackHistory = RegTrackHistory;
                    numberFormat = RegNumberFormat;
                    autoUpdate = RegAutoUpdate;
                    useProxy = RegUseProxy;
                    lastSucBackup = RegSuccessful;
                    alertOnBackUp = RegAlertOnBackUp;
                    autoBackup = RegBackupOnExit;
                    uoimg = RegUseOrgImage;
                    usePl = RegViewPetLoads;
                    useIPer = RegIndvReports;
                    useCcid = RegUseNumberCatOnly;
                    useaa = RegAuditammo;
                    useAacid = RegUseautoassign;
                    useUniqueCustId = RegUniquecustcatid;
                    bUseselectiveboundbook = RegUseselectiveboundbook;
                }
            }
            catch (Exception ex)
            {
                //long myErr = ex.Number;
                //if (myErr == 13)
                //    SetSettingDetails();
            }
        }
        public void SaveSettings(string numberFormat, bool trackHistory, int trackHistoryDays, bool autoUpdate, bool useProxy, bool alertOnBackUp, bool autoBackup, bool uoimg, bool usePl, bool useIPer, bool usenccid, bool useaa, bool useAacid, bool useUniqueCustId, bool bUseselectiveboundbook)
        {
            RegistryKey myReg;
            string strValue = DefaultRegPath + @"\Settings";
            myReg = Registry.CurrentUser.OpenSubKey(strValue, true);
            if (myReg == null)
                myReg = Registry.CurrentUser.CreateSubKey(strValue);
            myReg.SetValue("TrackHistoryDays", trackHistoryDays);
            myReg.SetValue("TrackHistory", trackHistory);
            myReg.SetValue("NumberFormat", numberFormat);
            myReg.SetValue("AutoUpdate", autoUpdate);
            myReg.SetValue("UseProxy", useProxy);
            myReg.SetValue("AlertOnBackUp", alertOnBackUp);
            myReg.SetValue("BackupOnExit", autoBackup);
            myReg.SetValue("UseOrgImage", uoimg);
            myReg.SetValue("ViewPetLoads", usePl);
            myReg.SetValue("IndvReports", useIPer);
            myReg.SetValue("UseNumberCatOnly", usenccid);
            myReg.SetValue("AUDITAMMO", useaa);
            myReg.SetValue("USEAUTOASSIGN", useAacid);
            myReg.SetValue("DISABLEUNIQUECUSTCATID", useUniqueCustId);
            myReg.SetValue("USESELECTIVEBOUNDBOOK", bUseselectiveboundbook);
            myReg.Close();
        }

        public void SaveLastWorkingDir(string strPath)
        {
            RegistryKey myReg;
            string strValue = DefaultRegPath + @"\Settings";
            myReg = Registry.CurrentUser.CreateSubKey(strValue, RegistryKeyPermissionCheck.Default);
            if (myReg == null)
                myReg = Registry.CurrentUser.CreateSubKey(strValue);
            myReg.SetValue("LastWorkingPath", strPath);
            myReg.Close();
        }

        public string GetLastWorkingDir()
        {
            string sAns = "";
            RegistryKey myReg;
            string strValue = DefaultRegPath + @"\Settings";
            myReg = Registry.CurrentUser.CreateSubKey(strValue, RegistryKeyPermissionCheck.Default);
            if (myReg == null)
            {
                myReg = Registry.CurrentUser.CreateSubKey(strValue);
                myReg.SetValue("LastWorkingPath", "");
            }
            sAns = myReg.GetValue("LastWorkingPath", "").ToString();
            myReg.Close();
            return sAns;
        }

        public void SaveFirearmListSort(string configSort)
        {
            string strValue = DefaultRegPath + @"\Settings";
            if (!RegSubKeyExists(strValue))
                CreateSubKey(strValue);
            RegistryKey myReg;
            myReg = Registry.CurrentUser.OpenSubKey(strValue, true);
            myReg.SetValue("VIEW_FirearmList", configSort);
            myReg.Close();
        }

        public string GetViewSettings(string sKey, string sDefault = "")
        {
            string sAns = "";
            string strValue = DefaultRegPath + @"\Settings";
            sAns = GetRegSubKeyValue(strValue, sKey, sDefault);
            return sAns;
        }

    }
}
