[`< Back`](./)

---

# Inventory

Namespace: BurnSoft.Applications.MGC.Ammo

Class Inventory contains all the functions used to manage the ammo in the database

```csharp
public class Inventory : System.IDisposable
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Inventory](./burnsoft.applications.mgc.ammo.inventory.md)<br>
Implements [IDisposable](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable)

## Constructors

### **Inventory()**

```csharp
public Inventory()
```

## Methods

### **UpdateQty(String, Int64, Int64, Int32, String&, Boolean)**

Updates the qty.

```csharp
public static bool UpdateQty(string databasePath, long ammoId, long currentQty, int roundCountUsed, String& errOut, bool doAdd)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`ammoId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The ammo identifier.

`currentQty` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The current qty.

`roundCountUsed` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The Number of rounds that was used to be subtracted by the current inventory number

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

`doAdd` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
by default it will subtract, is this is set to true it will add it instead

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **Delete(String, Int64, String&)**

Deletes the specified ammo from the database as well as the audit information

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

### **Add(String, String, String, String, String, String, Int64, Double, Int64, String&)**

Adds the specified database path.

```csharp
public static bool Add(string databasePath, string manufacturer, string name, string cal, string grain, string jacket, long qty, double dcal, long velocityNumber, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`manufacturer` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The manufacturer.

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`cal` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The cal.

`grain` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The grain.

`jacket` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The jacket.

`qty` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The qty.

`dcal` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The dcal.

`velocityNumber` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The velocity number.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **GetId(String, String, String, String, String, String, Int64, Double, Int64, String&)**

Gets the identifier.

```csharp
public static long GetId(string databasePath, string manufacturer, string name, string cal, string grain, string jacket, long qty, double dcal, long velocityNumber, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`manufacturer` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The manufacturer.

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`cal` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The cal.

`grain` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The grain.

`jacket` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The jacket.

`qty` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The qty.

`dcal` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The dcal.

`velocityNumber` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The velocity number.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

### **GetTotalInventory(String, String&)**

Gets the total inventory.

```csharp
public static long GetTotalInventory(string databasePath, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **TotalRoundsFired(String, Int32, String&)**

Totals the rounds fired.

```csharp
public static long TotalRoundsFired(string databasePath, int gunId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The gun identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

### **TotalAmmoSelected(String, String, String&)**

Totals the ammo selected.

```csharp
public static long TotalAmmoSelected(string databasePath, string caliber, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`caliber` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The caliber.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

### **TotalAmmoSelected(String, String, String, String&)**

Totals the ammo selected.

```csharp
public static long TotalAmmoSelected(string databasePath, string caliber, string caliber2, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`caliber` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The caliber.

`caliber2` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The caliber2.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

### **TotalAmmoSelected(String, String, String, String, String&)**

Totals the ammo selected.

```csharp
public static long TotalAmmoSelected(string databasePath, string caliber, string caliber2, string caliber3, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`caliber` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The caliber.

`caliber2` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The caliber2.

`caliber3` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The caliber3.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

### **GetQty(String, Int64, String&)**

Gets the qty.

```csharp
public static long GetQty(string databasePath, long id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

### **Update(String, Int64, String, String, String, String, String, Int64, Double, Int64, String&)**

Updates the specified database path.

```csharp
public static bool Update(string databasePath, long id, string manufacturer, string name, string cal, string grain, string jacket, long qty, double dcal, long velocityNumber, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`manufacturer` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The manufacturer.

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`cal` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The cal.

`grain` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The grain.

`jacket` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The jacket.

`qty` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The qty.

`dcal` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The dcal.

`velocityNumber` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The velocity number.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **Exists(String, String, String, String, String, String, Double, Int64, String&)**

Existses the specified database path.

```csharp
public static bool Exists(string databasePath, string manufacturer, string name, string cal, string grain, string jacket, double dcal, long velocityNumber, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`manufacturer` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The manufacturer.

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`cal` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The cal.

`grain` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The grain.

`jacket` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The jacket.

`dcal` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The dcal.

`velocityNumber` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The velocity number.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **GetLastAmmoId(String, String&)**

Gets the last ammo identifier.

```csharp
public static long GetLastAmmoId(string databasePath, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

### **GetList(String, String, String, String, String&)**

Gets the list.

```csharp
public static List<Ammunition> GetList(string databasePath, string name, string manufacturer, string cal, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`manufacturer` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The manufacturer.

`cal` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The cal.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;Ammunition&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;Ammunition&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetList(String, Int64, String&)**

Gets the list.

```csharp
public static List<Ammunition> GetList(string databasePath, long id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;Ammunition&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;Ammunition&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **ConvToNum(String)**

Convs to number.

```csharp
public static double ConvToNum(string strValue)
```

#### Parameters

`strValue` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string value.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
System.Double.

### **ConvertAmmoGrainsToNum(String, String&)**

Converts the ammo grains to number.

```csharp
public static bool ConvertAmmoGrainsToNum(string databasePath, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **AmmoIsAlreadyListed(String, String, String, String, String, String, Int64&, Int64&, String&)**

Ammo the is already listed.

```csharp
public static bool AmmoIsAlreadyListed(string databasePath, string manufacturer, string name, string cal, string grain, string jacket, Int64& qty, Int64& mid, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`manufacturer` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The manufacturer.

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`cal` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The cal.

`grain` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The grain.

`jacket` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The jacket.

`qty` [Int64&](https://docs.microsoft.com/en-us/dotnet/api/system.int64&)<br>
The qty.

`mid` [Int64&](https://docs.microsoft.com/en-us/dotnet/api/system.int64&)<br>
The mid.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetList(String, String&)**

Gets the list.

```csharp
public static List<Ammunition> GetList(string databasePath, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;Ammunition&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;Ammunition&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Dispose()**

Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.

```csharp
public void Dispose()
```

---

[`< Back`](./)
