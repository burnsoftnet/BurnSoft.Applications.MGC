[`< Back`](./)

---

# CustomReports

Namespace: BurnSoft.Applications.MGC.Reports

Class CustomReports handles custom reports for the CR_SavedReports table

```csharp
public class CustomReports
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [CustomReports](./burnsoft.applications.mgc.reports.customreports.md)

## Fields

### **FileTypes**

The file types for the save report export as options

```csharp
public static string FileTypes;
```

## Constructors

### **CustomReports()**

```csharp
public CustomReports()
```

## Methods

### **GetReportSql(String, Int64, String&)**

Gets the report SQL.

```csharp
public static string GetReportSql(string databasePath, long id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
System.String.

### **Add(String, String, String, String&)**

Adds the specified database path.

```csharp
public static bool Add(string databasePath, string reportName, string mySql, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`reportName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name of the report.

`mySql` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
My SQL.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **Update(String, Int64, String, String, String&)**

Updates the specified database path.

```csharp
public static bool Update(string databasePath, long reportId, string reportName, string mySql, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`reportId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The report identifier.

`reportName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name of the report.

`mySql` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
My SQL.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **Exists(String, String, String&)**

Existses the specified database path.

```csharp
public static bool Exists(string databasePath, string name, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetId(String, String, String&)**

Gets the identifier.

```csharp
public static long GetId(string databasePath, string name, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Delete(String, Int64, String&)**

Deletes the specified database path.

```csharp
public static bool Delete(string databasePath, long reportId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`reportId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The report identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **List(String, Int64, String&)**

Lists the specified database path.

```csharp
public static List<CustomReportsLists> List(string databasePath, long id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;CustomReportsLists&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;CustomReportsLists&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **HasSavedReports(String, String&)**

Determines whether the saved reports reports table has anything listed or not..

```csharp
public static bool HasSavedReports(string databasePath, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if [has saved reports] [the specified database path]; otherwise, `false`.

### **List(String, String&)**

Lists the specified database path.

```csharp
public static List<CustomReportsLists> List(string databasePath, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;CustomReportsLists&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;CustomReportsLists&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

---

[`< Back`](./)
