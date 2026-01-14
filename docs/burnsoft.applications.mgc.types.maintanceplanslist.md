[`< Back`](./)

---

# MaintancePlansList

Namespace: BurnSoft.Applications.MGC.Types

Class MaintancePlans to hold the information from the Maintance_Plans table

```csharp
public class MaintancePlansList
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [MaintancePlansList](./burnsoft.applications.mgc.types.maintanceplanslist)<br>
Attributes [SerializableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.serializableattribute)

## Properties

### **Id**

Gets or sets the identifier.

```csharp
public long Id { get; set; }
```

#### Property Value

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

### **Name**

Gets or sets the name.

```csharp
public string Name { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

### **OperationDetails**

Gets or sets the operation details. is od in the table

```csharp
public string OperationDetails { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The operation details.

### **IntervalsInDays**

Gets or sets the intervals in days. iid in table

```csharp
public string IntervalsInDays { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The intervals in days.

### **IntervalInRoundsFired**

Gets or sets the interval in rounds fired. is iirf in table

```csharp
public string IntervalInRoundsFired { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The interval in rounds fired.

### **Notes**

Gets or sets the notes.

```csharp
public string Notes { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The notes.

### **LastSync**

Gets or sets the last synchronize. sync_lastupdate in table

```csharp
public string LastSync { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The last synchronize.

## Constructors

### **MaintancePlansList()**

```csharp
public MaintancePlansList()
```

---

[`< Back`](./)
