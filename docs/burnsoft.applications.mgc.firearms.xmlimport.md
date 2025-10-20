[`< Back`](./)

---

# XmlImport

Namespace: BurnSoft.Applications.MGC.Firearms

Class XmlImport. Imports the firearm information from the xml file and insert it into the database

```csharp
public class XmlImport
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [XmlImport](./burnsoft.applications.mgc.firearms.xmlimport)

## Constructors

### **XmlImport()**

```csharp
public XmlImport()
```

## Methods

### **Details(String, String, Int32, Boolean, String&)**

Get the details from the xml file and insert it into the database, this is the main
 information of the firearm and needs to be ran first before the other import function.

```csharp
public static bool Details(string databasePath, string xmlPath, int ownerId, bool useNumberCatOnly, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`xmlPath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string path.

`ownerId` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The owner identifier.

`useNumberCatOnly` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [use number cat only].

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Accessories(String, String, Int64, String&)**

Accessorieses the specified database path.

```csharp
public static bool Accessories(string databasePath, string xmlPath, long gunId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`xmlPath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The XML path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GunSmithDetails(String, String, Int64, String&)**

Guns the smith details.

```csharp
public static bool GunSmithDetails(string databasePath, string xmlPath, long gunId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`xmlPath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The XML path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **BarrelConverstionKitDetails(String, String, Int64, String&)**

Barrels the converstion kit details.

```csharp
public static bool BarrelConverstionKitDetails(string databasePath, string xmlPath, long gunId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`xmlPath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The XML path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **MaintanceDetails(String, String, Int64, String&)**

Maintances the details.

```csharp
public static bool MaintanceDetails(string databasePath, string xmlPath, long gunId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`xmlPath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The XML path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

---

[`< Back`](./)
