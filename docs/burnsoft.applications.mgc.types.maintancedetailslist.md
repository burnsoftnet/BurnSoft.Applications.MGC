[`< Back`](./)

---

# MaintanceDetailsList

Namespace: BurnSoft.Applications.MGC.Types

Class MaintanceDetailsList to store the information from the Maintance_Details table

```csharp
public class MaintanceDetailsList
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [MaintanceDetailsList](./burnsoft.applications.mgc.types.maintancedetailslist.md)<br>
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

### **GunId**

Gets or sets the gun identifier. in the table it is gid

```csharp
public long GunId { get; set; }
```

#### Property Value

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

### **PlanId**

Gets or sets the plan identifier. is mpid in the table

```csharp
public long PlanId { get; set; }
```

#### Property Value

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The plan identifier.

### **Name**

Gets or sets the name.

```csharp
public string Name { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

### **OperationStartDate**

Gets or sets the operation start date. is OpDate in the table

```csharp
public string OperationStartDate { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The operation start date.

### **OperationDueDate**

Gets or sets the operation due date. is OpDueDate in the table

```csharp
public string OperationDueDate { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The operation due date.

### **RoundsFired**

Gets or sets the rounds fired. is RndFired in the table

```csharp
public long RoundsFired { get; set; }
```

#### Property Value

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The rounds fired.

### **Notes**

Gets or sets the notes.

```csharp
public string Notes { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The notes.

### **AmmoUsed**

Gets or sets the ammo used. is au in the table

```csharp
public string AmmoUsed { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The ammo used.

### **BarrelSystemId**

Gets or sets the barrel system identifier. is bsid in the table

```csharp
public long BarrelSystemId { get; set; }
```

#### Property Value

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The barrel system identifier.

### **DoesCount**

Gets or sets a value indicating whether [does count]. is dc in the table, this is used
 for to overall count of rounds fired

```csharp
public bool DoesCount { get; set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if [does count]; otherwise, `false`.

### **LastSync**

Gets or sets the last synchronize. is sync_lastupdate in the table.

```csharp
public string LastSync { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The last synchronize.

## Constructors

### **MaintanceDetailsList()**

```csharp
public MaintanceDetailsList()
```

---

[`< Back`](./)
