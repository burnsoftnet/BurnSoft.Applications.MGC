[`< Back`](./)

---

# MyRegistry

Namespace: BurnSoft.Applications.MGC.Global

Class Registry. General Registry class for the My gun Collection Application to read, setups, and write

```csharp
public class MyRegistry
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [MyRegistry](./burnsoft.applications.mgc.global.myregistry)

## Properties

### **DefaultRegPath**

Gets or sets the default reg path.

```csharp
public static string DefaultRegPath { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The default reg path.

## Constructors

### **MyRegistry()**

```csharp
public MyRegistry()
```

## Methods

### **CreateSubKey(String, String&)**

Creates the sub key.

```csharp
public static void CreateSubKey(string strValue, String& errOut)
```

#### Parameters

`strValue` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string value.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

### **UpDateAppDetails(String, String, String, String, String, String, String, String&)**

Ups the date application details.

```csharp
public static bool UpDateAppDetails(string productVersion, string productName, string executablePath, string appPath, string logFile, string databasePath, string appDataPath, String& errOut)
```

#### Parameters

`productVersion` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The product version.

`productName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name of the product.

`executablePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The executable path.

`appPath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The application path.

`logFile` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The log file.

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`appDataPath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The application data path.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **RegSubKeyExists(String, String&)**

Regs the sub key exists.

```csharp
public static bool RegSubKeyExists(string strValue, String& errOut)
```

#### Parameters

`strValue` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string value.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **GetRegSubKeyValue(String, String, String, String&)**

Gets the reg sub key value.

```csharp
public static string GetRegSubKeyValue(string strKey, string strValue, string strDefault, String& errOut)
```

#### Parameters

`strKey` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string key.

`strValue` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string value.

`strDefault` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string default.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
System.String.

### **SetSettingDetails(String&)**

Sets the setting details.

```csharp
public static bool SetSettingDetails(String& errOut)
```

#### Parameters

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **GetHotxes(String&)**

Gets the hotxes and puts them in a list to process

```csharp
public static List<HotFixList> GetHotxes(String& errOut)
```

#### Parameters

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;HotFixList&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;HotFixList&gt;.

### **SettingsExists(String&)**

Settingses the exists.

```csharp
public static bool SettingsExists(String& errOut)
```

#### Parameters

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **GetSettings(String&, Boolean&, Int32&, Boolean&, Boolean&, Boolean&, Boolean&, Boolean&, Boolean&, Boolean&, Boolean&, Boolean&, Boolean&, String&)**

Gets the settings.

```csharp
public static void GetSettings(String& lastSucBackup, Boolean& alertOnBackUp, Int32& trackHistoryDays, Boolean& trackHistory, Boolean& autoBackup, Boolean& uoimg, Boolean& usePl, Boolean& useIPer, Boolean& useCcid, Boolean& useaa, Boolean& useAacid, Boolean& useUniqueCustId, Boolean& bUseselectiveboundbook, String& errOut)
```

#### Parameters

`lastSucBackup` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The last suc backup.

`alertOnBackUp` [Boolean&](https://docs.microsoft.com/en-us/dotnet/api/system.boolean&)<br>
if set to `true` [alert on back up].

`trackHistoryDays` [Int32&](https://docs.microsoft.com/en-us/dotnet/api/system.int32&)<br>
The track history days.

`trackHistory` [Boolean&](https://docs.microsoft.com/en-us/dotnet/api/system.boolean&)<br>
if set to `true` [track history].

`autoBackup` [Boolean&](https://docs.microsoft.com/en-us/dotnet/api/system.boolean&)<br>
if set to `true` [automatic backup].

`uoimg` [Boolean&](https://docs.microsoft.com/en-us/dotnet/api/system.boolean&)<br>
if set to `true` [uoimg].

`usePl` [Boolean&](https://docs.microsoft.com/en-us/dotnet/api/system.boolean&)<br>
if set to `true` [use pl].

`useIPer` [Boolean&](https://docs.microsoft.com/en-us/dotnet/api/system.boolean&)<br>
if set to `true` [use i per].

`useCcid` [Boolean&](https://docs.microsoft.com/en-us/dotnet/api/system.boolean&)<br>
if set to `true` [use ccid].

`useaa` [Boolean&](https://docs.microsoft.com/en-us/dotnet/api/system.boolean&)<br>
if set to `true` [useaa].

`useAacid` [Boolean&](https://docs.microsoft.com/en-us/dotnet/api/system.boolean&)<br>
if set to `true` [use aacid].

`useUniqueCustId` [Boolean&](https://docs.microsoft.com/en-us/dotnet/api/system.boolean&)<br>
if set to `true` [use unique customer identifier].

`bUseselectiveboundbook` [Boolean&](https://docs.microsoft.com/en-us/dotnet/api/system.boolean&)<br>
if set to `true` [b useselectiveboundbook].

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

### **SaveSettings(String, Boolean, Int32, Boolean, Boolean, Boolean, Boolean, Boolean, Boolean, Boolean, Boolean, Boolean, Boolean, Boolean, String&)**

Saves the settings.

```csharp
public static bool SaveSettings(string numberFormat, bool trackHistory, int trackHistoryDays, bool autoUpdate, bool alertOnBackUp, bool autoBackup, bool uoimg, bool usePl, bool useIPer, bool usenccid, bool useaa, bool useAacid, bool useUniqueCustId, bool bUseselectiveboundbook, String& errOut)
```

#### Parameters

`numberFormat` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The number format.

`trackHistory` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [track history].

`trackHistoryDays` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The track history days.

`autoUpdate` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [automatic update].

`alertOnBackUp` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [alert on back up].

`autoBackup` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [automatic backup].

`uoimg` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [uoimg].

`usePl` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [use pl].

`useIPer` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [use i per].

`usenccid` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [usenccid].

`useaa` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [useaa].

`useAacid` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [use aacid].

`useUniqueCustId` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [use unique customer identifier].

`bUseselectiveboundbook` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [b useselectiveboundbook].

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
If an exception occurs the message will be in this string

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **SaveLastWorkingDir(String, String&)**

Saves the last working dir.

```csharp
public static bool SaveLastWorkingDir(string strPath, String& errOut)
```

#### Parameters

`strPath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string path.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **SetHotFix(Int32, String&, String)**

Sets the hot fix.

```csharp
public static bool SetHotFix(int hotfixNumber, String& errOut, string installNotice)
```

#### Parameters

`hotfixNumber` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The hotfix number.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

`installNotice` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Date and Time it was installed, OnInstall will skip the reinstall since that is by current version.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **SetValue(String, String, String, String&)**

Sets the setting value.

```csharp
public static bool SetValue(string subKey, string name, string value, String& errOut)
```

#### Parameters

`subKey` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name of the sub key with the default to the Main Application Path, if left blank it will insert in root

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
name to store the value in the key

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The value.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **SetLastUpdate(Int32, String&)**

Sets the last update.

```csharp
public static bool SetLastUpdate(int hotfixNumber, String& errOut)
```

#### Parameters

`hotfixNumber` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The hotfix number.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **GetLastWorkingDir(String&)**

Gets the last working dir.

```csharp
public static string GetLastWorkingDir(String& errOut)
```

#### Parameters

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
System.String.

### **SaveFirearmListSort(String, String&)**

Saves the firearm list sort.

```csharp
public static bool SaveFirearmListSort(string configSort, String& errOut)
```

#### Parameters

`configSort` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The configuration sort.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetViewSettings(String, String&, String)**

Gets the view settings.

```csharp
public static string GetViewSettings(string sKey, String& errOut, string sDefault)
```

#### Parameters

`sKey` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The s key.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

`sDefault` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The s default.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
System.String.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetDatabaseLocation(String&, String)**

Gets the database location.

```csharp
public static string GetDatabaseLocation(String& errOut, string sDefault)
```

#### Parameters

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

`sDefault` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The s default.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
System.String.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetMgcExePath(String&, String)**

Gets the MGC executable path.

```csharp
public static string GetMgcExePath(String& errOut, string sDefault)
```

#### Parameters

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

`sDefault` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The s default.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
System.String.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **MyGunCollectionIsInstalled(String&)**

Mies the gun collection is installed.

```csharp
public static bool MyGunCollectionIsInstalled(String& errOut)
```

#### Parameters

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

---

[`< Back`](./)
