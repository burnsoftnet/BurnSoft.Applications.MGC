[`< Back`](./)

---

# ColumnList

Namespace: BurnSoft.Applications.MGC.Reports

Class ColumnList to handle all the database functions relating to the cr_ColumnList table.

```csharp
public class ColumnList
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ColumnList](./burnsoft.applications.mgc.reports.columnlist.md)

## Constructors

### **ColumnList()**

```csharp
public ColumnList()
```

## Methods

### **GetColumnName(String, Int64, String, String&)**

Gets the name of the column.

```csharp
public static string GetColumnName(string databasePath, long tableId, string displayName, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`tableId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The table identifier.

`displayName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The display name.

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
public static List<ColumnLists> GetList(string databasePath, long tableId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`tableId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The table identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;ColumnLists&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;ColumnLists&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

---

[`< Back`](./)
