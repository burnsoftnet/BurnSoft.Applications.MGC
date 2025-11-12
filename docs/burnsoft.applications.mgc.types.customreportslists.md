[`< Back`](./)

---

# CustomReportsLists

Namespace: BurnSoft.Applications.MGC.Types

Class CustomReportsLists. List container for the CR_SavedReports table.

```csharp
public class CustomReportsLists
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [CustomReportsLists](./burnsoft.applications.mgc.types.customreportslists.md)

## Properties

### **Id**

Gets or sets the identifier.

```csharp
public long Id { get; set; }
```

#### Property Value

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

### **ReportName**

Gets or sets the name of the report.

```csharp
public string ReportName { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the report.

### **Sql**

Gets or sets the SQL. Is Called MySQL in the table

```csharp
public string Sql { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The SQL.

### **DateAdded**

Gets or sets the date added. Is called dt in the table

```csharp
public string DateAdded { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The date added.

### **LastSync**

Gets or sets the last synchronize. sync_lastupdate in the table

```csharp
public string LastSync { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The last synchronize.

## Constructors

### **CustomReportsLists()**

```csharp
public CustomReportsLists()
```

---

[`< Back`](./)
