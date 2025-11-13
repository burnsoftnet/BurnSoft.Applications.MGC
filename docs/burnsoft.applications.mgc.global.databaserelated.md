[`< Back`](./)

---

# DatabaseRelated

Namespace: BurnSoft.Applications.MGC.Global

Class DatabaseRelated.

```csharp
public class DatabaseRelated
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DatabaseRelated](./burnsoft.applications.mgc.global.databaserelated.md)

## Constructors

### **DatabaseRelated()**

```csharp
public DatabaseRelated()
```

## Methods

### **GetId(String, String, String&)**

Gets the identifier.

```csharp
public static long GetId(string databasePath, string sql, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`sql` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The SQL.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **ObjectExistsInDb(String, String, String&)**

Objects the exists in database.

```csharp
public static bool ObjectExistsInDb(string databasePath, string table, String& errOut)
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

### **GetDatabaseVersion(String, String&)**

Gets the database version.

```csharp
public static string GetDatabaseVersion(string databasePath, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
System.String.

### **GetName(String, String, String, String&)**

Gets the name.

```csharp
public static string GetName(string databasePath, string sql, string column, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`sql` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The SQL.

`column` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The column.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
System.String.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetTotal(String, String, String, String&)**

Gets the total from a sql queretm have your sum or total defined as T

```csharp
public static long GetTotal(string databasePath, string sql, string fromFunction, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`sql` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The SQL.

`fromFunction` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
From function.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

---

[`< Back`](./)
