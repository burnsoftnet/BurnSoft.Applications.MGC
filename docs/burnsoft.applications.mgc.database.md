[`< Back`](./)

---

# Database

Namespace: BurnSoft.Applications.MGC

Class Database. General Database functions needed.

```csharp
public class Database
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Database](./burnsoft.applications.mgc.database.md)

## Constructors

### **Database()**

```csharp
public Database()
```

## Methods

### **ConnectionString(String, String, String&, String)**

Connection String Format Used to Connect to MS Access Databases using the Microsoft Access Driver

```csharp
public static string ConnectionString(string databasePath, string databaseName, String& errOut, string password)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Database Path

`databaseName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
If an exception occurs the message will be in this string

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
string

### **ConnectionString(String, String&, String)**

Connections the string.

```csharp
public static string ConnectionString(string fullDatabasePath, String& errOut, string password)
```

#### Parameters

`fullDatabasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The full database path.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The password.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
System.String.

### **ConnectionStringOle(String, String, String&, String)**

Connections to the MS Access Database using the string OLE.

```csharp
public static string ConnectionStringOle(string databasePath, string databaseName, String& errOut, string password)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`databaseName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name of the database.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
If an exception occurs the message will be in this string

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The password.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
System.String.

### **ConnectionStringOle(String, String&, String)**

Connections the string OLE.

```csharp
public static string ConnectionStringOle(string databasePathAndName, String& errOut, string password)
```

#### Parameters

`databasePathAndName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name of the database path and.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The password.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
System.String.

### **ConnectDb(String, String&)**

Connects the database using the connection string.

```csharp
public bool ConnectDb(string connectionString, String& errOut)
```

#### Parameters

`connectionString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The connection string.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **Close(String&)**

Closes the specified error MSG.

```csharp
public bool Close(String& errMsg)
```

#### Parameters

`errMsg` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error MSG.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **ConnExec(String, String, String&)**

Connect to the database and execute the SQL statement that you passed.
 In this function, we set the connection object null instead of using the Close Function
 because you might be using that object for something else, and this will take out the connection
 from right under neath you, so we just set that to null instead of a hard close.

```csharp
public bool ConnExec(string connectionString, string sql, String& errOut)
```

#### Parameters

`connectionString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The connection string.

`sql` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The SQL.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Execute(String, String, String&)**

Executes the specified database path.

```csharp
public static bool Execute(string databasePath, string sql, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`sql` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The SQL.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **RunSql(String, String, String&)**

Runs the SQL.

```csharp
public static bool RunSql(string databasePath, string sql, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`sql` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The SQL.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **GetData(String, String, String&)**

Gets the data.

```csharp
public DataTable GetData(string connectionString, string sql, String& errOut)
```

#### Parameters

`connectionString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The connection string.

`sql` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The SQL.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

DataTable<br>
DataTable.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetIDFromTableBasedOnTSQL(String, String, String, String&)**

Get the Identity seed from the table base on your T SQl statement.

```csharp
public static int GetIDFromTableBasedOnTSQL(string connection, string sql, string identitySeedColumnName, String& errOut)
```

#### Parameters

`connection` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`sql` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`identitySeedColumnName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
If an exception occurs the message will be in this string

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
number

### **GetDataFromTable(String, String, String&)**

Gets the data from table.

```csharp
public static DataTable GetDataFromTable(string databasePath, string sql, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`sql` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The SQL.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

DataTable<br>
DataTable.

### **DataExists(String, String, String&)**

Datas the exists.

```csharp
public static bool DataExists(string databasePath, string sql, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`sql` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The SQL.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **UpdateSyncDataTables(String, String, String&)**

Updates the synchronize data tables.

```csharp
public static bool UpdateSyncDataTables(string databasePath, string table, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`table` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The table.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **SaveDatabaseVersion(String, String, String&)**

Saves the database version.

```csharp
public static bool SaveDatabaseVersion(string databasePath, string version, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`version` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The version.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **InsertNewContact(String, String, String, String, String&)**

Inserts the new contact.

```csharp
public bool InsertNewContact(string databasePath, string sValue, string sTable, string sColumn, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`sValue` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The s value.

`sTable` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The s table.

`sColumn` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The s column.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

---

[`< Back`](./)
