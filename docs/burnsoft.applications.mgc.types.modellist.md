[`< Back`](./)

---

# ModelList

Namespace: BurnSoft.Applications.MGC.Types

Class ModelList which will contain all the information gathered form the Gun_Model table

```csharp
public class ModelList
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ModelList](./burnsoft.applications.mgc.types.modellist.md)<br>
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

### **ManufacturerId**

Gets or sets the manufacturer identifier. This is GMID in the tabl

```csharp
public long ManufacturerId { get; set; }
```

#### Property Value

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The manufacturer identifier.

### **Name**

Gets or sets the name. Is field is Model in the table.

```csharp
public string Name { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

### **LastSync**

Gets or sets the last synchronize. This is sync_lastupdate in the table.

```csharp
public string LastSync { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The last synchronize.

## Constructors

### **ModelList()**

```csharp
public ModelList()
```

---

[`< Back`](./)
