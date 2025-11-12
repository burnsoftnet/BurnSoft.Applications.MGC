[`< Back`](./)

---

# GeneralAccessoriesList

Namespace: BurnSoft.Applications.MGC.Types

Class AccessoriesList list container that will contain the information from the General_Accessories table.

```csharp
public class GeneralAccessoriesList
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [GeneralAccessoriesList](./burnsoft.applications.mgc.types.generalaccessorieslist.md)<br>
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

### **AttachedToFirearmns**

Gets or sets the attached to firearmns list identirifers.

```csharp
public List<GeneralAccessoriesLinkers> AttachedToFirearmns { get; set; }
```

#### Property Value

[List&lt;GeneralAccessoriesLinkers&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
The attached to firearmns.

### **LastSync**

Gets or sets the last synchronize. Is called sync_lastupdate in the table

```csharp
public string LastSync { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The last synchronize.

## Constructors

### **GeneralAccessoriesList()**

```csharp
public GeneralAccessoriesList()
```

---

[`< Back`](./)
