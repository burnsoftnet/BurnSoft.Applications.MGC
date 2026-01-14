[`< Back`](./)

---

# MyCollection

Namespace: BurnSoft.Applications.MGC.Firearms

Class MyCollection, The majority of this class will hand the data from the gun_collection table.

```csharp
public class MyCollection
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [MyCollection](./burnsoft.applications.mgc.firearms.mycollection)

## Constructors

### **MyCollection()**

```csharp
public MyCollection()
```

## Methods

### **Add(String, Boolean, Int64, Int64, String, String, Int64, String, String, String, String, String, String, Int64, Int64, String, String, String, String, String, String, String, String, String, String, String, String, String, String, String, String, String, String, String, String, String, Boolean, String, String, String, String, Boolean, String, String, String, String, String, Boolean, String, Boolean, Boolean, String&)**

Adds the specified database path.

```csharp
public static bool Add(string databasePath, bool useNumberOnlyCatalog, long ownerId, long manufactureId, string fullName, string modelName, long modelId, string serialNumber, string firearmType, string caliber, string finish, string condition, string customId, long natId, long gripId, string weight, string height, string stockType, string barrelLength, string barrelWidth, string barrelHeight, string action, string feedsystem, string sights, string purchasedPrice, string purchasedFrom, string appraisedValue, string appraisalDate, string appraisedBy, string insuredValue, string storageLocation, string conditionComments, string additionalNotes, string produced, string petLoads, string dtp, bool isCandR, string importer, string reManDt, string poi, string sgChoke, bool isInBoundBook, string twistRate, string lbsTrigger, string caliber3, string classification, string dateofCr, bool isClassIii, string classIiiOwner, bool isCompetition, bool isNonLethal, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`useNumberOnlyCatalog` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [use number only catalog].

`ownerId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The owner identifier.

`manufactureId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The manufacture identifier.

`fullName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The full name.

`modelName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name of the model.

`modelId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The model identifier.

`serialNumber` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The serial number.

`firearmType` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Type of the firearm.

`caliber` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The serialNumber.

`finish` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The finish.

`condition` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The condition.

`customId` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The custom identifier.

`natId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The nat identifier.

`gripId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The grip identifier.

`weight` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The weight.

`height` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The height.

`stockType` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Type of the stock.

`barrelLength` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Length of the barrel.

`barrelWidth` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Width of the barrel.

`barrelHeight` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Height of the barrel.

`action` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The action.

`feedsystem` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The feedsystem.

`sights` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The sights.

`purchasedPrice` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The purchased price.

`purchasedFrom` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The purchased from.

`appraisedValue` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The appraised value.

`appraisalDate` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The appraisal date.

`appraisedBy` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The appraised by.

`insuredValue` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The insured value.

`storageLocation` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The storage location.

`conditionComments` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The condition comments.

`additionalNotes` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The additional notes.

`produced` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The produced.

`petLoads` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The pet loads.

`dtp` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The DTP.

`isCandR` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [is cand r].

`importer` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The importer.

`reManDt` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The re man dt.

`poi` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The poi.

`sgChoke` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The sg choke.

`isInBoundBook` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [is in bound book].

`twistRate` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The twist rate.

`lbsTrigger` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The LBS trigger.

`caliber3` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The caliber3.

`classification` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The classification.

`dateofCr` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The dateof cr.

`isClassIii` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [is class iii].

`classIiiOwner` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The class iii owner.

`isCompetition` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

`isNonLethal` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

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

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Update(String, Int32, Boolean, Int64, Int64, String, Int64, String, String, String, String, String, String, Int64, Int64, String, String, String, String, String, String, String, String, String, String, String, String, String, String, String, String, String, String, String, String, String, Boolean, String, String, String, String, Boolean, String, String, String, String, String, Boolean, Boolean, String, String, Boolean, Boolean, String&)**

Updates the specified database path.

```csharp
public static bool Update(string databasePath, int firearmId, bool useNumberOnlyCatalog, long ownerId, long manufactureId, string modelName, long modelId, string serialNumber, string firearmType, string caliber, string finish, string condition, string customId, long natId, long gripId, string weight, string height, string stockType, string barrelLength, string barrelWidth, string barrelHeight, string action, string feedsystem, string sights, string purchasedPrice, string purchasedFrom, string appraisedValue, string appraisalDate, string appraisedBy, string insuredValue, string storageLocation, string conditionComments, string additionalNotes, string produced, string petLoads, string dtp, bool isCandR, string importer, string reManDt, string poi, string sgChoke, bool isInBoundBook, string twistRate, string lbsTrigger, string caliber3, string classification, string dateofCr, bool isClassIii, bool isSold, string dateTimeSold, string classIiiOwner, bool isCompetition, bool isNonLethal, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`firearmId` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The firearm identifier.

`useNumberOnlyCatalog` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [use number only catalog].

`ownerId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The owner identifier.

`manufactureId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The manufacture identifier.

`modelName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name of the model.

`modelId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The model identifier.

`serialNumber` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The serial number.

`firearmType` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Type of the firearm.

`caliber` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The serialNumber.

`finish` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The finish.

`condition` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The condition.

`customId` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The custom identifier.

`natId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The nat identifier.

`gripId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The grip identifier.

`weight` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The weight.

`height` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The height.

`stockType` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Type of the stock.

`barrelLength` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Length of the barrel.

`barrelWidth` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Width of the barrel.

`barrelHeight` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Height of the barrel.

`action` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The action.

`feedsystem` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The feedsystem.

`sights` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The sights.

`purchasedPrice` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The purchased price.

`purchasedFrom` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The purchased from.

`appraisedValue` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The appraised value.

`appraisalDate` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The appraisal date.

`appraisedBy` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The appraised by.

`insuredValue` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The insured value.

`storageLocation` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The storage location.

`conditionComments` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The condition comments.

`additionalNotes` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The additional notes.

`produced` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The produced.

`petLoads` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The pet loads.

`dtp` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The DTP.

`isCandR` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [is cand r].

`importer` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The importer.

`reManDt` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The re man dt.

`poi` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The poi.

`sgChoke` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The sg choke.

`isInBoundBook` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [is in bound book].

`twistRate` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The twist rate.

`lbsTrigger` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The LBS trigger.

`caliber3` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The caliber3.

`classification` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The classification.

`dateofCr` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The dateof cr.

`isClassIii` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [is class iii].

`isSold` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [is sold].

`dateTimeSold` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The date time sold.

`classIiiOwner` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The class iii owner.

`isCompetition` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

`isNonLethal` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

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

### **Delete(String, Int64, String&)**

Deletes the the gunid from all the tables.

```csharp
public static bool Delete(string databasePath, long firearmId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`firearmId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The firearm identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Verify(String, Int64, String, String&)**

Verifies the specified firearm is at the expected id based on the full name

```csharp
public static bool Verify(string databasePath, long gunId, string fullName, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`fullName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The full name.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Verify(String, Int64, String, String, String&)**

Verifies the specified firearm is at the expected id based on the full name and serial number

```csharp
public static bool Verify(string databasePath, long gunId, string fullName, string serialNumber, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`fullName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The full name.

`serialNumber` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The serialNumber.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Exists(String, String, String, String&)**

Existses the specified database path.

```csharp
public static bool Exists(string databasePath, string fullName, string caliber, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`fullName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The full name.

`caliber` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The serialNumber.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Exists(String, String, String&)**

Existses the specified database path.

```csharp
public static bool Exists(string databasePath, string fullName, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`fullName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The full name.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetId(String, String, String&)**

Gets the identifier.

```csharp
public static long GetId(string databasePath, string fullName, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`fullName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The full name.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetTopId(String, String&)**

Gets the top identifier from the database

```csharp
public static long GetTopId(string databasePath, String& errOut)
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

### **CatalogIdExists(String, String, String&, Int32)**

Catalogs the identifier exists.

```csharp
public static bool CatalogIdExists(string databasePath, string customId, String& errOut, int gunId)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`customId` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The custom identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

`gunId` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The gun identifier.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **CatalogIdExists(String, Int64, String&, Int32)**

Catalogs the identifier exists.

```csharp
public static bool CatalogIdExists(string databasePath, long customId, String& errOut, int gunId)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`customId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The custom identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

`gunId` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The gun identifier.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **IsNotOldEnouthForDelete(String, Int64, String&, Int32)**

Determines whether [is not old enouth for delete] [the specified database path]. If the firearm was just recently sold and
 you attempt to delete it, you will get a warning message saying that it is to new of a sale to delete, to wait a few years
 before deleting.

```csharp
public static bool IsNotOldEnouthForDelete(string databasePath, long id, String& errOut, int defaultYearsToWait)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

`defaultYearsToWait` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if [is not old enouth for delete] [the specified database path]; otherwise, `false`.

### **CatalogIsNumeric(String, String&)**

Checks the cataeglog field to see if all the values can be converted to numeric, if there isn't anything like
 Colleotr-001, is that is in there then the column cannot be converted to numeric only.

```csharp
public static bool CatalogIsNumeric(string databasePath, String& errOut)
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

### **SetCatalogValuesToNumeric(String, String&)**

Sets the catalog values to numeric. Don't care if there was somethign special in it, it's gone and now some random number

```csharp
public static bool SetCatalogValuesToNumeric(string databasePath, String& errOut)
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

### **SetCatalogType(String, CatalogType, String&)**

Sets the type of the catalog.

```csharp
public static bool SetCatalogType(string databasePath, CatalogType type, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`type` [CatalogType](./burnsoft.applications.mgc.firearms.mycollection.catalogtype)<br>
The type.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **CatalogExistsDetails(String, String, String&, Int32)**

Check to see if the Custom Catalog ID already exists exists.

```csharp
public static string CatalogExistsDetails(string databasePath, string customId, String& errOut, int gunId)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`customId` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The custom identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

`gunId` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The gun identifier.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
System.String.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetCatalogNextIdNumber(String, String&)**

Gets the catalog next identifier number.

```csharp
public static long GetCatalogNextIdNumber(string databasePath, String& errOut)
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

### **UpdateDefaultBarrel(String, Int64, Int64, String&)**

Updates the default barrel in the main database collection table

```csharp
public static bool UpdateDefaultBarrel(string databasePath, long barrelId, long gunId, String& errOut)
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

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **UpdateSellerId(String, Int64, Int64, String&)**

Updates the seller identifier.

```csharp
public static bool UpdateSellerId(string databasePath, long sellerId, long gunId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`sellerId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The seller identifier.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetLastId(String, String&)**

Gets the last identifier.

```csharp
public static long GetLastId(string databasePath, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

### **UpdateShopName(String, String, String, String&)**

Updates the name of the shop for all the guns that was bought from it due to a name change

```csharp
public static bool UpdateShopName(string databasePath, string newName, string oldName, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`newName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The new name.

`oldName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The old name.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **SetAsCompetitionGun(String, Int32, Boolean, String&)**

Sets as competition gun.

```csharp
public static bool SetAsCompetitionGun(string databasePath, int id, bool isCompetition, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The identifier.

`isCompetition` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [is competition].

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **SetAsToBeSold(String, Int32, Boolean, String&)**

Sets as to be sold true or false

```csharp
public static bool SetAsToBeSold(string databasePath, int id, bool value, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The identifier.

`value` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [value].

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **SetAsGunSmithJob(String, Int32, Boolean, String&)**

Sets as gun smith job to true or false

```csharp
public static bool SetAsGunSmithJob(string databasePath, int id, bool value, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The identifier.

`value` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [value].

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **SetAsForCollecting(String, Int32, Boolean, String&)**

Sets as for collecting.

```csharp
public static bool SetAsForCollecting(string databasePath, int id, bool value, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The identifier.

`value` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [value].

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **SetFirearmRating(String, Int32, Int32, String&)**

Sets the firearm rating. This will bet set while you are viewing the firearm and not during add or edit.
 Because if might be a new gun and you don't know how it handles. So something that can be changed more 
 on the fly.

```csharp
public static bool SetFirearmRating(string databasePath, int id, int rating, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The identifier.

`rating` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The rating.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **SetAsNonLethal(String, Int32, Boolean, String&)**

Sets as non lethal.

```csharp
public static bool SetAsNonLethal(string databasePath, int id, bool isNonLethal, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The identifier.

`isNonLethal` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [is non lethal].

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **HasCollectionAttached(String, Int32, String&)**

Determines whether [has collection attached] [the specified database path].

```csharp
public static int HasCollectionAttached(string databasePath, int buyerId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`buyerId` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The buyer identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
System.Int32.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **HasCollectionAttached(String, String, String&)**

Determines whether [has collection attached] [the specified database path].

```csharp
public static int HasCollectionAttached(string databasePath, string shopName, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`shopName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name of the shop.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
System.Int32.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetList(String, String&)**

Gets all the firearms in the database and their details

```csharp
public static List<GunCollectionList> GetList(string databasePath, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;GunCollectionList&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;GunCollectionList&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetList(String, Int64, String&)**

Gets a specfic firearm from the database

```csharp
public static List<GunCollectionList> GetList(string databasePath, long id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;GunCollectionList&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;GunCollectionList&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetFullList(String, Int64, String&)**

Gets the full list of the firearm details, accessories, BarrelSystems, etc.

```csharp
public static List<GunCollectionFullList> GetFullList(string databasePath, long id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;GunCollectionFullList&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;GunCollectionFullList&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **MarkAsSold(String, Int64, Int64, String, String, String&)**

Marks as sold.

```csharp
public static bool MarkAsSold(string databasePath, long gunId, long buyerId, string dateSold, string salePrice, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`buyerId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The buyer identifier.

`dateSold` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The date sold.

`salePrice` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The sale price.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **MarkAsStolen(String, Int64, Int64, String, String, String&)**

Marks as stolen.

```csharp
public static bool MarkAsStolen(string databasePath, long gunId, long buyerId, string dateSold, string salePrice, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`buyerId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The buyer identifier.

`dateSold` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The date sold.

`salePrice` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The sale price.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **UnMarkAsStolenOrSold(String, Int64, String&)**

Uns the mark as stolen or sold.

```csharp
public static bool UnMarkAsStolenOrSold(string databasePath, long gunId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **RenameFullName(String, Int64, String, String&)**

Renames the full name.

```csharp
public static bool RenameFullName(string databasePath, long gunId, string newName, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`newName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The new name.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetRatingList(Boolean)**

Gets the rating list.

```csharp
public static List<Ratings> GetRatingList(bool useTen)
```

#### Parameters

`useTen` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [use ten].

#### Returns

[List&lt;Ratings&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;Ratings&gt;.

### **GetRatingId(String, Boolean)**

Gets the rating identifier.

```csharp
public static int GetRatingId(string name, bool useTen)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`useTen` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [use ten].

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
System.Int32.

---

[`< Back`](./)
