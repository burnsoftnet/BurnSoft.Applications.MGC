[`< Back`](./)

---

# TableList

Namespace: BurnSoft.Applications.MGC.Reports

Class TableList. Class to manage the CR_TableList table in the database

```csharp
public class TableList
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [TableList](./burnsoft.applications.mgc.reports.tablelist.md)

## Constructors

### **TableList()**

```csharp
public TableList()
```

## Methods

### **GetTableName(String, Int64, String&)**

Gets the name of the table.

```csharp
public static string GetTableName(string databasePath, long tableId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`tableId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The table identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
System.String.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetList(String, Int64, String&)**

Gets the list.

```csharp
public static List<TableLists> GetList(string databasePath, long tableId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`tableId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The table identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;TableLists&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;TableLists&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

---

[`< Back`](./)
