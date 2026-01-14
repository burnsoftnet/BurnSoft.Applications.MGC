[`< Back`](./)

---

# DocumentLinkList

Namespace: BurnSoft.Applications.MGC.Types

Class DocumentLinkList. Container for the doc link table.

```csharp
public class DocumentLinkList
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DocumentLinkList](./burnsoft.applications.mgc.types.documentlinklist)<br>
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

Gets or sets the gun identifier. GID in the Table

```csharp
public long GunId { get; set; }
```

#### Property Value

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

### **DocId**

Gets or sets the document identifier. DID in the table

```csharp
public long DocId { get; set; }
```

#### Property Value

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The document identifier.

### **Dta**

Gets or sets the dta.

```csharp
public string Dta { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The dta.

### **LastSync**

Gets or sets the last synchronize. sync_lastupdate in the table

```csharp
public string LastSync { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The last synchronize.

## Constructors

### **DocumentLinkList()**

```csharp
public DocumentLinkList()
```

---

[`< Back`](./)
