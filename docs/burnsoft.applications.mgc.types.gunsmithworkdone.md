[`< Back`](./)

---

# GunSmithWorkDone

Namespace: BurnSoft.Applications.MGC.Types

Class GunSmithWorkDone. Stores the information for the work that was done to a firearm from a gun smith that is stored in the GunSmith_Details table.

```csharp
public class GunSmithWorkDone
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [GunSmithWorkDone](./burnsoft.applications.mgc.types.gunsmithworkdone.md)<br>
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

Gets or sets the gun identifier. Table field name is GID

```csharp
public long GunId { get; set; }
```

#### Property Value

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

### **GunSmithName**

Gets or sets the name of the gun smith, field name is gsmith

```csharp
public string GunSmithName { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the gun smith.

### **GunSmithId**

Gets or sets the gun smith identifier. GSID in the database

```csharp
public long GunSmithId { get; set; }
```

#### Property Value

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun smith identifier.

### **OrderDetails**

Gets or sets the Order details. od in the database

```csharp
public string OrderDetails { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The other work done.

### **Notes**

Gets or sets the notes.

```csharp
public string Notes { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The notes.

### **StartDate**

Gets or sets the start date. sdate in teh database

```csharp
public string StartDate { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The start date.

### **ReturnDate**

Gets or sets the return date. rdate in the database

```csharp
public string ReturnDate { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The return date.

### **LastSync**

Gets or sets the last synchronize. sync_lastupdate in the database

```csharp
public string LastSync { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The last synchronize.

## Constructors

### **GunSmithWorkDone()**

```csharp
public GunSmithWorkDone()
```

---

[`< Back`](./)
