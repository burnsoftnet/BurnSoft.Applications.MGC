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





    }
}
