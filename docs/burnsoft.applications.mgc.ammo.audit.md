[`< Back`](./)

---

# Audit

Namespace: BurnSoft.Applications.MGC.Ammo

Class Audit that contains the functions for the ammo audit section

```csharp
public class Audit : System.IDisposable
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Audit](./burnsoft.applications.mgc.ammo.audit.md)<br>
Implements [IDisposable](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable)

## Constructors

### **Audit()**

```csharp
public Audit()
```

## Methods

### **Add(String, Int64, String, Int64, Int32, Double, String, String&, Boolean)**

Adds the specified ammo to the audit table

```csharp
public static bool Add(string databasePath, long ammoId, string datePurchased, long currentQty, int qty, double price, string store, String& errOut, bool updateInventory)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`ammoId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The ammo identifier.

`datePurchased` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The date purchased.

`currentQty` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

`qty` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The qty.

`price` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The price.

`store` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The store.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

`updateInventory` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
update inventory

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **Add(String, Int64, String, Int32, Double, String, Int32, Int64, String&)**

Adds the specified ammo to the audit table, over ride if you bought more than one box

```csharp
public static bool Add(string databasePath, long ammoId, string datePurchased, int qty, double price, string store, int numberOfBoxes, long currentQty, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`ammoId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The ammo identifier.

`datePurchased` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The date purchased.

`qty` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The qty.

`price` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The price.

`store` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The store.

`numberOfBoxes` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The number of boxes.

`currentQty` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Delete(String, Int64, String&)**

Deletes the specified ammo audit informatmion.

```csharp
public static bool Delete(string databasePath, long ammoId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`ammoId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The ammo identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **UpdatePricePerBullet(String, Int64, Double, String&)**

Updates the price per bullet.

```csharp
public static bool UpdatePricePerBullet(string databasePath, long ammoId, double pricePerBullet, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`ammoId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The ammo identifier.

`pricePerBullet` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The price per bullet.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **Dispose()**

Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.

```csharp
public void Dispose()
```

---

[`< Back`](./)
