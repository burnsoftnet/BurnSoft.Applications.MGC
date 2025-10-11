[`< Back`](./)

---

# ExtraBarrelConvoKits

Namespace: BurnSoft.Applications.MGC.Firearms

Class ExtraBarrelConvoKits functions to manage the barrels or conversion kits for a firearm.

```csharp
public class ExtraBarrelConvoKits : System.IDisposable
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ExtraBarrelConvoKits](./burnsoft.applications.mgc.firearms.extrabarrelconvokits.md)<br>
Implements [IDisposable](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable)

## Constructors

### **ExtraBarrelConvoKits()**

```csharp
public ExtraBarrelConvoKits()
```

## Methods

### **FixDefaultBarrelMarkers(String, Int64, String&, Int64)**

Fixes the default barrel markers.

```csharp
public static bool FixDefaultBarrelMarkers(string databasePath, long gunId, String& errOut, long barrelId)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

`barrelId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The barrel identifier.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetDatabaseIdxtLinks(String, Int64, String&)**

Gets the database idxt links.

```csharp
public static long GetDatabaseIdxtLinks(string databasePath, long gunId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

### **GetCurrentBarrelDetailstList(String, Int64, String&)**

Ges the current barrel detailst list.

```csharp
public static List<BarrelSystems> GetCurrentBarrelDetailstList(string databasePath, long id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;BarrelSystems&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;BarrelSystems&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Add(String, Int64, String, String, String, String, String, String, String, String, String, String, String, String, Boolean, String, String&)**

Adds the specified database path.

```csharp
public static bool Add(string databasePath, long gunId, string modelName, string caliber, string finish, string barrelLength, string petLoads, string action, string feedSystem, string sights, string purchasePrice, string purchasedFrom, string height, string type, bool isDefault, string datePurchased, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`modelName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name of the model.

`caliber` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The caliber.

`finish` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The finish.

`barrelLength` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Length of the barrel.

`petLoads` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The pet loads.

`action` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The action.

`feedSystem` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The feed system.

`sights` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The sights.

`purchasePrice` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The purchase price.

`purchasedFrom` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The purchased from.

`height` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The height.

`type` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The type.

`isDefault` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [is default].

`datePurchased` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **AverageRoundsFiredBs(String, Int32, String&)**

Average Round Fired out of barrel System

```csharp
public static long AverageRoundsFiredBs(string databasePath, int barrelSystemId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`barrelSystemId` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Update(String, Int64, Int64, String, String, String, String, String, String, String, String, String, String, String, String, Boolean, String&)**

update the barrel or conversion kit information in the database

```csharp
public static bool Update(string databasePath, long barrelId, long gunId, string modelName, string caliber, string finish, string barrelLength, string petLoads, string action, string feedSystem, string sights, string purchasePrice, string purchasedFrom, string height, string type, bool isDefault, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`barrelId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

`modelName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`caliber` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`finish` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`barrelLength` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`petLoads` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`action` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`feedSystem` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`sights` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`purchasePrice` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`purchasedFrom` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`height` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`type` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`isDefault` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Update(String, Int64, Int64, String, String, String, String, String, String, String, String, String, String, String, String, String&)**

Update with no default setter

```csharp
public static bool Update(string databasePath, long barrelId, long gunId, string modelName, string caliber, string finish, string barrelLength, string petLoads, string action, string feedSystem, string sights, string purchasePrice, string purchasedFrom, string height, string type, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`barrelId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

`modelName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`caliber` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`finish` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`barrelLength` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`petLoads` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`action` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`feedSystem` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`sights` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`purchasePrice` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`purchasedFrom` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`height` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`type` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Move(String, Int64, Int64, String&)**

Moves the specified database path.

```csharp
public static bool Move(string databasePath, long gunId, long barrelId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`barrelId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The barrel identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Exists(String, Int64, String, String, String, String, String, String, String, String, String, String, String, String, Boolean, String&)**

Existses the specified database path.

```csharp
public static bool Exists(string databasePath, long gunId, string modelName, string caliber, string finish, string barrelLength, string petLoads, string action, string feedSystem, string sights, string purchasePrice, string purchasedFrom, string height, string type, bool isDefault, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`modelName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name of the model.

`caliber` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The caliber.

`finish` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The finish.

`barrelLength` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Length of the barrel.

`petLoads` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The pet loads.

`action` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The action.

`feedSystem` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The feed system.

`sights` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The sights.

`purchasePrice` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The purchase price.

`purchasedFrom` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The purchased from.

`height` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The height.

`type` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The type.

`isDefault` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [is default].

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **AddLink(String, Int64, Int64, String&)**

Adds the link.

```csharp
public static bool AddLink(string databasePath, long barrelId, long gunId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`barrelId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The barrel identifier.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **Delete(String, Int64, String&)**

Delete a barrel/conversion system from the database in the main table and the extended links table.

```csharp
public static bool Delete(string databasePath, long id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **DeleteBarrelSystem(String, Int64, String&, String&)**

Deletes the barrel system. and return sa message if it was able to delete it, or
 if it couldn't because it was setup as the default barrel and needs to be corrected before deleting.

```csharp
public static bool DeleteBarrelSystem(string databasePath, long id, String& msg, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`msg` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The MSG.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **IsCurrentlyinUseBarrel(String, Int64, String&)**

Determines whether [is currentlyin use barrel] [the specified database path].

```csharp
public static bool IsCurrentlyinUseBarrel(string databasePath, long id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if [is currentlyin use barrel] [the specified database path]; otherwise, `false`.

### **HasMultiBarrelsListed(String, Int64, String&)**

Determines whether [has multi barrels listed] [the specified database path].

```csharp
public static bool HasMultiBarrelsListed(string databasePath, long id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if [has multi barrels listed] [the specified database path]; otherwise, `false`.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetBarrelId(String, Int64, String&, Boolean, Int64)**

Gets the barrel identifier.

```csharp
public static long GetBarrelId(string databasePath, long gunId, String& errOut, bool useDefault, long barrelId)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

`useDefault` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [use default].

`barrelId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The barrel identifier.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetBarrelId(String, Int64, String, String&)**

Gets the barrel identifier.

```csharp
public static long GetBarrelId(string databasePath, long gunId, string name, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

### **GetDefaultBarrelId(String, Int64, String&)**

Gets the default barrel identifier.

```csharp
public static long GetDefaultBarrelId(string databasePath, long gunId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetList(String, Int64, String&)**

Gets the list.

```csharp
public static List<BarrelSystems> GetList(string databasePath, long barrelId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`barrelId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The barrel identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;BarrelSystems&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;BarrelSystems&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetListForFirearm(String, Int64, String&)**

Gets the list of barrel system by gun id.

```csharp
public static List<BarrelSystems> GetListForFirearm(string databasePath, long gunId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The Firearm identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;BarrelSystems&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;BarrelSystems&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetList(String, String&)**

Gets the list.

```csharp
public static List<BarrelSystems> GetList(string databasePath, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;BarrelSystems&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;BarrelSystems&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **SwapDefaultBarrelSystems(String, Int64, Int64, Int64, String&)**

Swaps the default barrel systems.

```csharp
public static bool SwapDefaultBarrelSystems(string databasePath, long defaultBarrelId, long newBarrelId, long gunId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`defaultBarrelId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The default barrel identifier.

`newBarrelId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The new barrel identifier.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Dispose()**

Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.

```csharp
public void Dispose()
```

---

[`< Back`](./)
