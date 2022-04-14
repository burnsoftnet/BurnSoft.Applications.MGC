using System;
using System.Collections.Generic;
using System.Globalization;
using BurnSoft.Applications.MGC.hotixes;
using BurnSoft.Applications.MGC.hotixes.types;
using Microsoft.Win32;
// ReSharper disable PossibleNullReferenceException
// ReSharper disable RedundantAssignment
// ReSharper disable TooWideLocalVariableScope
// ReSharper disable UnusedMember.Global
// ReSharper disable ConvertIfStatementToNullCoalescingExpression

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
        /// <summary>
        /// The reg path
        /// </summary>
        private static string _regPath;
        /// <summary>
        /// The reg successful
        /// </summary>
        private static string _regSuccessful;
        /// <summary>
        /// The reg set hist listtb
        /// </summary>
        private static string _regSetHistListtb;
        /// <summary>
        /// The reg set hist listdt
        /// </summary>
        private static string _regSetHistListdt;
        /// <summary>
        /// The reg alert on back up
        /// </summary>
        private static bool _regAlertOnBackUp = true;
        /// <summary>
        /// The reg track history days
        /// </summary>
        private static int _regTrackHistoryDays;
        /// <summary>
        /// The reg last path
        /// </summary>
        private static string _regLastPath;
        /// <summary>
        /// The reg last file
        /// </summary>
        private static string _regLastFile;
        /// <summary>
        /// The reg backup on exit
        /// </summary>
        private static bool _regBackupOnExit;
        /// <summary>
        /// The reg use org image
        /// </summary>
        private static bool _regUseOrgImage;
        /// <summary>
        /// The reg view pet loads
        /// </summary>
        private static bool _regViewPetLoads = true;
        /// <summary>
        /// The reg indv reports
        /// </summary>
        private static bool _regIndvReports = true;
        /// <summary>
        /// The reg track history
        /// </summary>
        private static bool _regTrackHistory = true;
        /// <summary>
        /// The reg number format
        /// </summary>
        private static string _regNumberFormat;
        /// <summary>
        /// The reg automatic update
        /// </summary>
        private static bool _regAutoUpdate;
        /// <summary>
        /// The reg use proxy
        /// </summary>
        private static bool _regUseProxy;
        /// <summary>
        /// The reg use number cat only
        /// </summary>
        private static bool _regUseNumberCatOnly;
        /// <summary>
        /// The reg auditammo
        /// </summary>
        private static bool _regAuditammo;
        /// <summary>
        /// The reg useautoassign
        /// </summary>
        private static bool _regUseautoassign;
        /// <summary>
        /// The reg uniquecustcatid/
        /// </summary>
        private static bool _regUniquecustcatid;
        /// <summary>
        /// The reg useselectiveboundbook
        /// </summary>
        private static bool _regUseselectiveboundbook;
        /// <summary>
        /// Gets or sets the default reg path.
        /// </summary>
        /// <value>The default reg path.</value>
        public static string DefaultRegPath
        {
            get
            {
                if (_regPath == null)
                {
                    _regPath = @"Software\\BurnSoft\\BSMGC";
                    return _regPath;
                }
                if (_regPath.Length == 0)
                    _regPath = @"Software\\BurnSoft\\BSMGC";
                return _regPath;
            }
            set => _regPath = value;
        }
        /// <summary>
        /// Gets or sets the reg successful.
        /// </summary>
        /// <value>The reg successful.</value>
        private static string RegSuccessful
        {
            get
            {
                if (_regSuccessful == null)
                {
                    _regSuccessful = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                    return _regSuccessful;
                }
                if (_regSuccessful.Length == 0)
                    _regSuccessful = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                return _regSuccessful;
            }
            set => _regSuccessful = value;
        }
        /// <summary>
        /// Gets or sets the reg set hist listtb.
        /// </summary>
        /// <value>The reg set hist listtb.</value>
        private static string RegSetHistListtb
        {
            get => _regSetHistListtb;
            set => _regSetHistListtb = value;
        }
        /// <summary>
        /// Gets or sets the reg set hist listdt.
        /// </summary>
        /// <value>The reg set hist listdt.</value>
        private static string RegSetHistListdt
        {
            get => _regSetHistListdt;
            set => _regSetHistListdt = value;
        }
        /// <summary>
        /// Gets or sets a value indicating whether [reg alert on back up].
        /// </summary>
        /// <value><c>true</c> if [reg alert on back up]; otherwise, <c>false</c>.</value>
        private static bool RegAlertOnBackUp
        {
            get => _regAlertOnBackUp;
            set => _regAlertOnBackUp = value;
        }
        /// <summary>
        /// Gets or sets the reg track history days.
        /// </summary>
        /// <value>The reg track history days.</value>
        private static int RegTrackHistoryDays
        {
            get
            {
                if (_regTrackHistoryDays == 0)
                    _regTrackHistoryDays = 15;
                return _regTrackHistoryDays;
            }
            set => _regTrackHistoryDays = value;
        }
        /// <summary>
        /// Gets or sets the reg last path.
        /// </summary>
        /// <value>The reg last path.</value>
        private static string RegLastPath
        {
            get
            {
                if (_regLastPath == null)
                {
                    _regLastPath = @"C:\";
                    return _regLastPath;
                }
                if (_regLastPath.Length == 0)
                    _regLastPath = @"C:\";
                return _regLastPath;
            }
            set => _regLastPath = value;
        }
        /// <summary>
        /// Gets or sets the reg last file.
        /// </summary>
        /// <value>The reg last file.</value>
        private static string RegLastFile
        {
            get
            {
                if (_regLastFile == null)
                {
                    _regLastFile = "MGC.MDB";
                    return _regLastFile;
                }
                if (_regLastFile.Length == 0)
                    _regLastFile = "MGC.MDB";
                return _regLastFile;
            }
            set => _regLastFile = value;
        }
        /// <summary>
        /// Gets or sets a value indicating whether [reg backup on exit].
        /// </summary>
        /// <value><c>true</c> if [reg backup on exit]; otherwise, <c>false</c>.</value>
        private static bool RegBackupOnExit
        {
            get => _regBackupOnExit;
            set => _regBackupOnExit = value;
        }
        /// <summary>
        /// Gets or sets a value indicating whether [reg use org image].
        /// </summary>
        /// <value><c>true</c> if [reg use org image]; otherwise, <c>false</c>.</value>
        private static bool RegUseOrgImage
        {
            get => _regUseOrgImage;
            set => _regUseOrgImage = value;
        }
        /// <summary>
        /// Gets or sets a value indicating whether [reg view pet loads].
        /// </summary>
        /// <value><c>true</c> if [reg view pet loads]; otherwise, <c>false</c>.</value>
        private static bool RegViewPetLoads
        {
            get => _regViewPetLoads;
            set => _regViewPetLoads = value;
        }
        /// <summary>
        /// Gets or sets a value indicating whether [reg indv reports].
        /// </summary>
        /// <value><c>true</c> if [reg indv reports]; otherwise, <c>false</c>.</value>
        private static bool RegIndvReports
        {
            get => _regIndvReports;
            set => _regIndvReports = value;
        }
        /// <summary>
        /// Gets or sets a value indicating whether [reg track history].
        /// </summary>
        /// <value><c>true</c> if [reg track history]; otherwise, <c>false</c>.</value>
        private static bool RegTrackHistory
        {
            get => _regTrackHistory;
            set => _regTrackHistory = value;
        }
        /// <summary>
        /// Gets or sets the reg number format.
        /// </summary>
        /// <value>The reg number format.</value>
        private static string RegNumberFormat
        {
            get
            {
                if (_regNumberFormat == null)
                {
                    _regNumberFormat = "0000";
                    return _regNumberFormat;
                }
                if (_regNumberFormat.Length == 0)
                    _regNumberFormat = "0000";
                return _regNumberFormat;
            }
            set => _regNumberFormat = value;
        }
        /// <summary>
        /// Gets or sets a value indicating whether [reg automatic update].
        /// </summary>
        /// <value><c>true</c> if [reg automatic update]; otherwise, <c>false</c>.</value>
        private static bool RegAutoUpdate
        {
            get => _regAutoUpdate;
            set => _regAutoUpdate = value;
        }
        /// <summary>
        /// Gets or sets a value indicating whether [reg use proxy].
        /// </summary>
        /// <value><c>true</c> if [reg use proxy]; otherwise, <c>false</c>.</value>
        private static bool RegUseProxy
        {
            get => _regUseProxy;
            set => _regUseProxy = value;
        }
        /// <summary>
        /// Gets or sets a value indicating whether [reg auditammo].
        /// </summary>
        /// <value><c>true</c> if [reg auditammo]; otherwise, <c>false</c>.</value>
        private static bool RegAuditammo
        {
            get => _regAuditammo;
            set => _regAuditammo = value;
        }
        /// <summary>
        /// Gets or sets a value indicating whether [reg use number cat only].
        /// </summary>
        /// <value><c>true</c> if [reg use number cat only]; otherwise, <c>false</c>.</value>
        private static bool RegUseNumberCatOnly
        {
            get => _regUseNumberCatOnly;
            set => _regUseNumberCatOnly = value;
        }
        /// <summary>
        /// Gets or sets a value indicating whether [reg useautoassign].
        /// </summary>
        /// <value><c>true</c> if [reg useautoassign]; otherwise, <c>false</c>.</value>
        private static bool RegUseautoassign
        {
            get => _regUseautoassign;
            set => _regUseautoassign = value;
        }
        /// <summary>
        /// Gets or sets a value indicating whether [reg uniquecustcatid].
        /// </summary>
        /// <value><c>true</c> if [reg uniquecustcatid]; otherwise, <c>false</c>.</value>
        private static bool RegUniquecustcatid
        {
            get => _regUniquecustcatid;
            set => _regUniquecustcatid = value;
        }
        /// <summary>
        /// Gets or sets a value indicating whether [reg useselectiveboundbook].
        /// </summary>
        /// <value><c>true</c> if [reg useselectiveboundbook]; otherwise, <c>false</c>.</value>
        private static bool RegUseselectiveboundbook
        {
            get => _regUseselectiveboundbook;
            set => _regUseselectiveboundbook = value;
        }
        /// <summary>
        /// Creates the sub key.
        /// </summary>
        /// <param name="strValue">The string value.</param>
        /// <param name="errOut">The error out.</param>
        public static void CreateSubKey(string strValue, out string errOut)
        {
            errOut = "";
            try
            {
                Registry.CurrentUser.CreateSubKey(strValue);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("CreateSubKey", e);
            }
        }
        /// <summary>
        /// Ups the date application details.
        /// </summary>
        /// <param name="productVersion">The product version.</param>
        /// <param name="productName">Name of the product.</param>
        /// <param name="executablePath">The executable path.</param>
        /// <param name="appPath">The application path.</param>
        /// <param name="logFile">The log file.</param>
        /// <param name="databasePath">The database path.</param>
        /// <param name="appDataPath">The application data path.</param>
        /// <param name="errOut">The error out.</param>
        public static bool UpDateAppDetails(string productVersion, string productName, string executablePath,string appPath, string logFile, string databasePath, string appDataPath, out string errOut)
        {
            errOut = "";
            bool bAns = false;
            try
            {
                string strValue = DefaultRegPath;
                if (!RegSubKeyExists(strValue, out errOut))
                    CreateSubKey(strValue, out errOut);

                RegistryKey myReg = Registry.CurrentUser.OpenSubKey(strValue, true);
                myReg.SetValue("Version", productVersion);
                myReg.SetValue("AppName", productName);
                myReg.SetValue("AppEXE", executablePath);
                myReg.SetValue("Path", appPath);
                myReg.SetValue("LogPath", logFile);
                myReg.SetValue("DataBase", databasePath);
                myReg.SetValue("AppDataPath", appDataPath);
                myReg.Close();
                bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("UpDateAppDetails", e);
            }

            return bAns;
        }
        /// <summary>
        /// Regs the sub key exists.
        /// </summary>
        /// <param name="strValue">The string value.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool RegSubKeyExists(string strValue, out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                RegistryKey myReg = Registry.CurrentUser.OpenSubKey(strValue, true);
                if (myReg != null) bAns = true;
            }
            catch (Exception ex)
            {
                errOut = ErrorMessage("RegSubKeyExists", ex);
            }
            return bAns;
        }
        /// <summary>
        /// Gets the reg sub key value.
        /// </summary>
        /// <param name="strKey">The string key.</param>
        /// <param name="strValue">The string value.</param>
        /// <param name="strDefault">The string default.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        public static string GetRegSubKeyValue(string strKey, string strValue, string strDefault, out string errOut)
        {
            string sAns;
#pragma warning disable 219
            string strMsg = "";
#pragma warning restore 219
            errOut = "";
            RegistryKey myReg;
            try
            {
                if (RegSubKeyExists(strKey, out errOut))
                {
                    myReg = Registry.CurrentUser.OpenSubKey(strKey, true);

                    var checkValueExists = myReg.GetValue(strValue);
                    if (checkValueExists == null)
                    {
                        myReg.SetValue(strValue, strDefault);
                        sAns = strDefault;
                    }
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
                    CreateSubKey(strKey, out errOut);
                    myReg = Registry.CurrentUser.OpenSubKey(strKey, true);
                    myReg.SetValue(strValue, strDefault);
                    sAns = strDefault;
                }
            }
            catch (Exception ex)
            {
                sAns = strDefault;
                errOut = ErrorMessage("GetRegSubKeyValue", ex);
            }
            return sAns;
        }
        /// <summary>
        /// Sets the setting details.
        /// </summary>
        public static bool SetSettingDetails(out string errOut)
        {
            errOut = "";
            bool bAns = false;
            try
            {
                if (!SettingsExists(out errOut))
                {
                    string strValue = DefaultRegPath + @"\Settings";
                    RegistryKey myReg = Registry.CurrentUser.OpenSubKey(strValue, true);

                    myReg = Registry.CurrentUser.CreateSubKey(strValue);

                    myReg.SetValue("Successful", RegSuccessful);
                    myReg.SetValue("SetHistListtb", RegSetHistListtb ?? "");
                    myReg.SetValue("SetHistListdt", RegSetHistListdt ?? "");
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

                    for (int i = 1; i < HotFix.NumberOfFixes + 1; i++)
                    {
                        if (!SetHotFix(i, out errOut)) throw new Exception(errOut);
                    }
                }
                if (errOut.Length > 0) throw new Exception(errOut);
                bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("SetSettingDetails", e);
            }

            return bAns;
        }
        /// <summary>
        /// Gets the hotxes and puts them in a list to process
        /// </summary>
        /// <param name="errOut">The error out.</param>
        /// <returns>List&lt;HotFixList&gt;.</returns>
        public static List<HotFixList> GetHotxes(out string errOut)
        {
            List<HotFixList> lst = new List<HotFixList>();
            errOut = "";
            try
            {
                string strValue = DefaultRegPath + @"\HotFix";
                RegistryKey key = Registry.CurrentUser.OpenSubKey(strValue);
                foreach (var v in key.GetValueNames())
                {
                    //Console.WriteLine(v);
                    string hotfixId = v;
                    string dateinstalled = key.GetValue(v).ToString();
                    lst.Add(new HotFixList(){ Id = hotfixId, DateInstalled = dateinstalled, WasFromInstall = dateinstalled.Equals("OnInstall") });
                }
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetHotfixes", e);
            }

            return lst;
        }
        /// <summary>
        /// Settingses the exists.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool SettingsExists(out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                string strValue = DefaultRegPath + @"\Settings";
                RegistryKey myReg = Registry.CurrentUser.OpenSubKey(strValue, true);
                if (myReg != null) bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("SettingsExists", e);
            }
            return bAns;
        }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <param name="lastSucBackup">The last suc backup.</param>
        /// <param name="alertOnBackUp">if set to <c>true</c> [alert on back up].</param>
        /// <param name="trackHistoryDays">The track history days.</param>
        /// <param name="trackHistory">if set to <c>true</c> [track history].</param>
        /// <param name="autoBackup">if set to <c>true</c> [automatic backup].</param>
        /// <param name="uoimg">if set to <c>true</c> [uoimg].</param>
        /// <param name="usePl">if set to <c>true</c> [use pl].</param>
        /// <param name="useIPer">if set to <c>true</c> [use i per].</param>
        /// <param name="useCcid">if set to <c>true</c> [use ccid].</param>
        /// <param name="useaa">if set to <c>true</c> [useaa].</param>
        /// <param name="useAacid">if set to <c>true</c> [use aacid].</param>
        /// <param name="useUniqueCustId">if set to <c>true</c> [use unique customer identifier].</param>
        /// <param name="bUseselectiveboundbook">if set to <c>true</c> [b useselectiveboundbook].</param>
        /// <param name="errOut">The error out.</param>
        public static void GetSettings(out string lastSucBackup, out bool alertOnBackUp, out int trackHistoryDays, out bool trackHistory, out bool autoBackup, out bool uoimg, out bool usePl, out bool useIPer, out bool useCcid, out bool useaa, out bool useAacid, out bool useUniqueCustId, out bool bUseselectiveboundbook, out string errOut)
        {
            errOut = "";
            lastSucBackup = "";
            alertOnBackUp = false;
            trackHistoryDays = 30;
            trackHistory = false;
            autoBackup = false;
            uoimg = false;
            usePl = false;
            useIPer = false;
            useCcid = false;
            useaa = false;
            useAacid = false;
            useUniqueCustId = false;
            bUseselectiveboundbook = false;

            RegistryKey myReg;

            string strValue = DefaultRegPath + @"\Settings";
            try
            {
                myReg = Registry.CurrentUser.OpenSubKey(strValue, true);
                if (myReg == null)
                    SetSettingDetails(out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                if ((myReg != null))
                {
                    trackHistoryDays = Convert.ToInt32(GetRegSubKeyValue(strValue, "TrackHistoryDays", RegTrackHistoryDays.ToString(), out errOut)); 
                    trackHistory = Convert.ToBoolean(GetRegSubKeyValue(strValue, "TrackHistory", RegTrackHistory.ToString(), out errOut));
                    lastSucBackup = GetRegSubKeyValue(strValue, "Successful", RegSuccessful, out errOut);
                    alertOnBackUp = Convert.ToBoolean(GetRegSubKeyValue(strValue, "AlertOnBackUp", RegAlertOnBackUp.ToString(), out errOut));
                    autoBackup = Convert.ToBoolean(GetRegSubKeyValue(strValue, "BackupOnExit", RegBackupOnExit.ToString(), out errOut));
                    uoimg = Convert.ToBoolean(GetRegSubKeyValue(strValue, "UseOrgImage", RegUseOrgImage.ToString(), out errOut));
                    usePl = Convert.ToBoolean(GetRegSubKeyValue(strValue, "ViewPetLoads", RegViewPetLoads.ToString(), out errOut));
                    useIPer = Convert.ToBoolean(GetRegSubKeyValue(strValue, "IndvReports", RegIndvReports.ToString(), out errOut));
                    useCcid = Convert.ToBoolean(GetRegSubKeyValue(strValue, "UseNumberCatOnly", RegUseNumberCatOnly.ToString(), out errOut));
                    useaa = Convert.ToBoolean(GetRegSubKeyValue(strValue, "AUDITAMMO", RegAuditammo.ToString(), out errOut));
                    useAacid = Convert.ToBoolean(GetRegSubKeyValue(strValue, "USEAUTOASSIGN", RegUseautoassign.ToString(), out errOut));
                    useUniqueCustId = Convert.ToBoolean(GetRegSubKeyValue(strValue, "DISABLEUNIQUECUSTCATID", RegUniquecustcatid.ToString(), out errOut));
                    bUseselectiveboundbook = Convert.ToBoolean(GetRegSubKeyValue(strValue, "USESELECTIVEBOUNDBOOK", RegUseselectiveboundbook.ToString(), out errOut));
                }
                else
                {
                    trackHistoryDays = RegTrackHistoryDays;
                    trackHistory = RegTrackHistory;
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
                errOut = ErrorMessage("GetSettings", ex);
                //long myErr = ex.Number;
                //if (myErr == 13)
                //    SetSettingDetails();
            }
        }

        /// <summary>
        /// Saves the settings.
        /// </summary>
        /// <param name="numberFormat">The number format.</param>
        /// <param name="trackHistory">if set to <c>true</c> [track history].</param>
        /// <param name="trackHistoryDays">The track history days.</param>
        /// <param name="autoUpdate">if set to <c>true</c> [automatic update].</param>
        /// <param name="alertOnBackUp">if set to <c>true</c> [alert on back up].</param>
        /// <param name="autoBackup">if set to <c>true</c> [automatic backup].</param>
        /// <param name="uoimg">if set to <c>true</c> [uoimg].</param>
        /// <param name="usePl">if set to <c>true</c> [use pl].</param>
        /// <param name="useIPer">if set to <c>true</c> [use i per].</param>
        /// <param name="usenccid">if set to <c>true</c> [usenccid].</param>
        /// <param name="useaa">if set to <c>true</c> [useaa].</param>
        /// <param name="useAacid">if set to <c>true</c> [use aacid].</param>
        /// <param name="useUniqueCustId">if set to <c>true</c> [use unique customer identifier].</param>
        /// <param name="bUseselectiveboundbook">if set to <c>true</c> [b useselectiveboundbook].</param>
        /// <param name="errOut"></param>
        public static bool SaveSettings(string numberFormat, bool trackHistory, int trackHistoryDays, bool autoUpdate, bool alertOnBackUp, bool autoBackup, 
            bool uoimg, bool usePl, bool useIPer, bool usenccid, bool useaa, bool useAacid, bool useUniqueCustId, bool bUseselectiveboundbook, out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                string strValue = DefaultRegPath + @"\Settings";
                RegistryKey myReg = Registry.CurrentUser.OpenSubKey(strValue, true);
                if (myReg == null)
                    myReg = Registry.CurrentUser.CreateSubKey(strValue);
                myReg.SetValue("TrackHistoryDays", trackHistoryDays);
                myReg.SetValue("TrackHistory", trackHistory);
                myReg.SetValue("NumberFormat", numberFormat);
                myReg.SetValue("AutoUpdate", autoUpdate);
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
                bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("SaveSettings", e);
            }

            return bAns;
        }
        /// <summary>
        /// Saves the last working dir.
        /// </summary>
        /// <param name="strPath">The string path.</param>
        /// <param name="errOut">The error out.</param>
        public static bool SaveLastWorkingDir(string strPath, out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                string strValue = DefaultRegPath + @"\Settings";
                RegistryKey myReg = Registry.CurrentUser.CreateSubKey(strValue, RegistryKeyPermissionCheck.Default);
                if (myReg == null)
                    myReg = Registry.CurrentUser.CreateSubKey(strValue);
                myReg.SetValue("LastWorkingPath", strPath);
                myReg.Close();
                bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("SaveLastWorkingDir", e);
            }

            return bAns;
        }

        /// <summary>
        /// Sets the hot fix.
        /// </summary>
        /// <param name="hotfixNumber">The hotfix number.</param>
        /// <param name="errOut">The error out.</param>
        /// <param name="installNotice">The Date and Time it was installed, OnInstall will skip the reinstall since that is by current version.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool SetHotFix(int hotfixNumber, out string errOut, string installNotice = "OnInstall")
        {
            bool bAns = false;
            errOut = "";
            try
            {
                string strValue = DefaultRegPath + @"\HotFix";
                RegistryKey myReg = Registry.CurrentUser.CreateSubKey(strValue, RegistryKeyPermissionCheck.Default);
                if (myReg == null)
                    myReg = Registry.CurrentUser.CreateSubKey(strValue);
                myReg.SetValue($"{hotfixNumber}", installNotice);
                myReg.Close();
                bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("SetHotFix", e);
            }

            return bAns;
        }

        /// <summary>
        /// Sets the setting value.
        /// </summary>
        /// <param name="subKey">Name of the sub key with the default to the Main Application Path, if left blank it will insert in root </param>
        /// <param name="name">name to store the value in the key</param>
        /// <param name="value">The value.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool SetValue(string subKey, string name, string value, out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                string strValue = DefaultRegPath;
                if (subKey.Length > 0) strValue = DefaultRegPath + $"\\{subKey}";
                RegistryKey myReg = Registry.CurrentUser.CreateSubKey(strValue, RegistryKeyPermissionCheck.Default);
                if (myReg == null)
                    myReg = Registry.CurrentUser.CreateSubKey(strValue);
                myReg.SetValue(name, value);
                myReg.Close();
                bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("SetValue", e);
            }

            return bAns;
        }
        /// <summary>
        /// Sets the last update.
        /// </summary>
        /// <param name="hotfixNumber">The hotfix number.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool SetLastUpdate(int hotfixNumber, out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                string strValue = DefaultRegPath + @"\HotFix";
                RegistryKey myReg = Registry.CurrentUser.CreateSubKey(strValue, RegistryKeyPermissionCheck.Default);
                if (myReg == null)
                    myReg = Registry.CurrentUser.CreateSubKey(strValue);
                myReg.SetValue("LastUpdate",$"{hotfixNumber}");
                myReg.Close();
                bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("SetLastUpdate", e);
            }

            return bAns;
        }
        /// <summary>
        /// Gets the last working dir.
        /// </summary>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        public static string GetLastWorkingDir(out string errOut)
        {
            string sAns = "";
            errOut = "";
            try
            {
                string strValue = DefaultRegPath + @"\Settings";
                RegistryKey myReg = Registry.CurrentUser.CreateSubKey(strValue, RegistryKeyPermissionCheck.Default);
                if (myReg == null)
                {
                    myReg = Registry.CurrentUser.CreateSubKey(strValue);
                    myReg.SetValue("LastWorkingPath", "");
                }
                sAns = myReg.GetValue("LastWorkingPath", "").ToString();
                myReg.Close();
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetLastWorkingDir", e);
            }
            return sAns;
        }
        /// <summary>
        /// Saves the firearm list sort.
        /// </summary>
        /// <param name="configSort">The configuration sort.</param>
        /// <param name="errOut">The error out.</param>
        /// <exception cref="System.Exception"></exception>
        public static bool SaveFirearmListSort(string configSort, out string errOut)
        {
            errOut = "";
            bool bAns = false;
            try
            {
                string strValue = DefaultRegPath + @"\Settings";
                if (!RegSubKeyExists(strValue, out errOut))
                    CreateSubKey(strValue, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
                RegistryKey myReg = Registry.CurrentUser.OpenSubKey(strValue, true);
                myReg.SetValue("VIEW_FirearmList", configSort);
                myReg.Close();
                bAns = true;
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("SaveFirearmListSort", e);
            }

            return bAns;
        }
        /// <summary>
        /// Gets the view settings.
        /// </summary>
        /// <param name="sKey">The s key.</param>
        /// <param name="errOut">The error out.</param>
        /// <param name="sDefault">The s default.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception"></exception>
        public static string GetViewSettings(string sKey,out string errOut, string sDefault = "")
        {
            string sAns = "";
            errOut = "";
            try
            {
                string strValue = DefaultRegPath + @"\Settings";
                sAns = GetRegSubKeyValue(strValue, sKey, sDefault, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetViewSettings", e);
            }
            return sAns;
        }
        /// <summary>
        /// Gets the database location.
        /// </summary>
        /// <param name="errOut">The error out.</param>
        /// <param name="sDefault">The s default.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception"></exception>
        public static string GetDatabaseLocation(out string errOut, string sDefault = "")
        {
            string sAns = "";
            errOut = "";
            try
            {
                sAns = GetRegSubKeyValue(DefaultRegPath, "DataBase", sDefault, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetDatabaseLocation", e);
            }
            return sAns;
        }

        /// <summary>
        /// Gets the MGC executable path.
        /// </summary>
        /// <param name="errOut">The error out.</param>
        /// <param name="sDefault">The s default.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception"></exception>
        public static string GetMgcExePath(out string errOut, string sDefault = "")
        {
            string sAns = "";
            errOut = "";
            try
            {
                sAns = GetRegSubKeyValue(DefaultRegPath, "AppEXE", sDefault, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("GetMgcExePath", e);
            }
            return sAns;
        }
        /// <summary>
        /// Mies the gun collection is installed.
        /// </summary>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.Exception"></exception>
        public static bool MyGunCollectionIsInstalled(out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                bAns = RegSubKeyExists(DefaultRegPath, out errOut);
                if (errOut.Length > 0) throw new Exception(errOut);
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("MyGunCollectionIsInstalled", e);
            }
            return bAns;
        }

    }
}
