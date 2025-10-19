[`< Back`](./)

---

# AccessoriesList

Namespace: BurnSoft.Applications.MGC.Types

Class AccessoriesList list container that will contain the information from the Gun_Collection_Accessories table.

```csharp
public class AccessoriesList
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [AccessoriesList](./burnsoft.applications.mgc.types.accessorieslist)<br>
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

Gets or sets the gun identifier. This is gid in the table

```csharp
public long GunId { get; set; }
```

#### Property Value

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

### **Manufacturer**

Gets or sets the manufacturer.

```csharp
public string Manufacturer { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The manufacturer.

### **Model**

Gets or sets the model.

```csharp
public string Model { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The model.

### **SerialNumber**

Gets or sets the serial number.

```csharp
public string SerialNumber { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The serial number.

### **Condition**

Gets or sets the condition.

```csharp
public string Condition { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The condition.

### **Notes**

Gets or sets the notes.

```csharp
public string Notes { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The notes.

### **Use**

Gets or sets the use.

```csharp
public string Use { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The use.

### **PurchaseValue**

Gets or sets the purchase value. Is PurValue in the table

```csharp
public string PurchaseValue { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The purchase value.

### **AppriasedValue**

Gets or sets the appriased value. Is AppValue in the table.

```csharp
public string AppriasedValue { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The appriased value.

### **CountInValue**

Gets or sets a value indicating whether [count in value]. This is an interger value called CIV in the table

```csharp
public bool CountInValue { get; set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if [count in value]; otherwise, `false`.

### **IsChoke**

Gets or sets a value indicating whether this instance is choke. This is an interger value called IC in the table

```csharp
public bool IsChoke { get; set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if this instance is choke; otherwise, `false`.

### **LastSync**

Gets or sets the last synchronize. Is called sync_lastupdate in the table

```csharp
public string LastSync { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The last synchronize.

## Constructors

### **AccessoriesList()**

```csharp
public AccessoriesList()
```

---

[`< Back`](./)
