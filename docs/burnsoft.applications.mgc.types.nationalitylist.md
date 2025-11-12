[`< Back`](./)

---

# NationalityList

Namespace: BurnSoft.Applications.MGC.Types

Class NationalityList. Container for the results in the Gun_Nationality table

```csharp
public class NationalityList
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [NationalityList](./burnsoft.applications.mgc.types.nationalitylist.md)<br>
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

Gets or sets the name. Is called Country in the table

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

### **NationalityList()**

```csharp
public NationalityList()
```

---

[`< Back`](./)
