[`< Back`](./)

---

# HfDatabase

Namespace: BurnSoft.Applications.MGC.hotixes

This HfDatabase class uses ADODB for database connection, unlike the HfDatabase class in the root
 which uses odbc for it's connection methods. This code was converted from the hotfix application.

```csharp
public class HfDatabase
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [HfDatabase](./burnsoft.applications.mgc.hotixes.hfdatabase.md)

## Constructors

### **HfDatabase()**

```csharp
public HfDatabase()
```

## Methods

### **TableExists(String, String, String&, Boolean)**

check to see if theTables the exists in the database.

```csharp
public static bool TableExists(string databasePath, string tableName, String& errOut, bool usePassword)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`tableName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name of the table.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

`usePassword` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [use password].

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **GrantAdminSysObjects(String, String&, Boolean)**

Grants the admin system objects.

```csharp
public static bool GrantAdminSysObjects(string databasePath, String& errOut, bool usePassword)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

`usePassword` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [use password].

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **ValueDoesExist(String, String, String, String, String&, Boolean)**

Values the does exist.

```csharp
public static bool ValueDoesExist(string databasePath, string table, string column, string value, String& errOut, bool usePassword)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`table` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The table.

`column` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The column.

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The value.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

`usePassword` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [use password].

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **AddNewData(String, String, String, String, String&, Boolean)**

Adds the new data by simplifying the see if value exists, and if it doesn't an there are no errors
 then it will do the RunSQL command on the value, and column agstin the table

```csharp
public static bool AddNewData(string databasePath, string table, string column, string value, String& errOut, bool usePassword)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`table` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The table.

`column` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The column.

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The value.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

`usePassword` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [use password].

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **ValueDoesExist(String, String, String, Int32, String&, Boolean)**

Values the does exist.

```csharp
public static bool ValueDoesExist(string databasePath, string table, string column, int value, String& errOut, bool usePassword)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`table` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The table.

`column` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The column.

`value` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The value.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

`usePassword` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [use password].

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **ValueDoesExist(String, String, String, Double, String&, Boolean)**

Values the does exist.

```csharp
public static bool ValueDoesExist(string databasePath, string table, string column, double value, String& errOut, bool usePassword)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`table` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The table.

`column` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The column.

`value` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The value.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

`usePassword` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [use password].

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

---

[`< Back`](./)
