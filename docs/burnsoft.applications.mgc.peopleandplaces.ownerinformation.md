[`< Back`](./)

---

# OwnerInformation

Namespace: BurnSoft.Applications.MGC.PeopleAndPlaces

Class OwnerInformation. handing the Owner_infotable in the database

```csharp
public class OwnerInformation
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [OwnerInformation](./burnsoft.applications.mgc.peopleandplaces.ownerinformation.md)

## Constructors

### **OwnerInformation()**

```csharp
public OwnerInformation()
```

## Methods

### **Add(String, String, String, String, String, String, String, String, Boolean, String, String, String, String, String&)**

Adds the specified database path.

```csharp
public static bool Add(string databasePath, string name, string address, string city, string state, string zip, string phone, string ccdwl, bool usePwd, string pwd, string uid, string forgotWord, string forgotPhrase, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`address` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The address.

`city` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The city.

`state` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The state.

`zip` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The zip.

`phone` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The phone.

`ccdwl` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The CCDWL.

`usePwd` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [use password].

`pwd` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The password.

`uid` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The uid.

`forgotWord` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The forgot word.

`forgotPhrase` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The forgot phrase.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **Update(String, Int64, String, String, String, String, String, String, String, Boolean, String, String, String, String, String&)**

Updates the specified database path.

```csharp
public static bool Update(string databasePath, long id, string name, string address, string city, string state, string zip, string phone, string ccdwl, bool usePwd, string pwd, string uid, string forgotWord, string forgotPhrase, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`address` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The address.

`city` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The city.

`state` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The state.

`zip` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The zip.

`phone` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The phone.

`ccdwl` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The CCDWL.

`usePwd` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [use password].

`pwd` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The password.

`uid` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The uid.

`forgotWord` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The forgot word.

`forgotPhrase` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The forgot phrase.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **SetLogin(String, Int64, Boolean, String&)**

Sets the login option

```csharp
public static bool SetLogin(string databasePath, long id, bool isEnabled, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`isEnabled` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [is enabled].

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **LoginIsEnabled(String, Int64, String&)**

Checks to see if then Login field the is enabled.

```csharp
public static bool LoginIsEnabled(string databasePath, long id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetOwnerInfo(String, String&)**

Gets the owner information from the database

```csharp
public static List<OwnerInfo> GetOwnerInfo(string databasePath, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;OwnerInfo&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;OwnerInfo&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetOwnerId(String, String&, String&, String&)**

Gets the owner identifier.

```csharp
public static long GetOwnerId(string databasePath, String& ownerName, String& ownerLic, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`ownerName` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
Name of the owner.

`ownerLic` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The owner lic.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetOwnerId(String, String&, String&, String&, String&, String&, String&, String&, String&)**

Gets the owner identifier.

```csharp
public static long GetOwnerId(string databasePath, String& ownerName, String& ownerLic, String& sAddress, String& sCity, String& sState, String& sZip, String& sPhone, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`ownerName` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
Name of the owner.

`ownerLic` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The owner lic.

`sAddress` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The s address.

`sCity` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The s city.

`sState` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
State of the s.

`sZip` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The s zip.

`sPhone` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The s phone.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **LoginEnabled(String, String&, String&, String&, String&, String&)**

Logins the enabled.

```csharp
public static bool LoginEnabled(string databasePath, String& uid, String& pwd, String& forgotWord, String& forgotPhrase, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`uid` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The uid.

`pwd` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The password.

`forgotWord` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The forgot word.

`forgotPhrase` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The forgot phrase.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

---

[`< Back`](./)
