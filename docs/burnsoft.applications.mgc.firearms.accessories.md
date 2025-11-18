[`< Back`](./)

---

# Accessories

Namespace: BurnSoft.Applications.MGC.Firearms

Class Accessories that handles firearm accessories database calls

```csharp
public class Accessories
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Accessories](./burnsoft.applications.mgc.firearms.accessories)

## Constructors

### **Accessories()**

```csharp
public Accessories()
```

## Methods

### **Add(String, Int64, String, String, String, String, String, String, Double, Double, Boolean, Boolean, String&)**

Adds the specified accessory to the database.

```csharp
public static bool Add(string databasePath, long gunId, string manufacturer, string model, string serialNumber, string condition, string notes, string use, double purValue, double appValue, bool civ, bool ic, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`manufacturer` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The manufacturer.

`model` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The model.

`serialNumber` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The serial number.

`condition` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The condition.

`notes` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The notes.

`use` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The use.

`purValue` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The pur value.

`appValue` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The appriased value.

`civ` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Count in Value.

`ic` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Is Shotgun Choke.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **Add(String, Int64, String, String, String, String, String, String, Double, Double, Boolean, Boolean, Int32, String&)**

Adds the specified accessory to the database.

```csharp
public static bool Add(string databasePath, long gunId, string manufacturer, string model, string serialNumber, string condition, string notes, string use, double purValue, double appValue, bool civ, bool ic, int galid, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`manufacturer` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The manufacturer.

`model` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The model.

`serialNumber` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The serial number.

`condition` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The condition.

`notes` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The notes.

`use` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The use.

`purValue` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The pur value.

`appValue` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The appriased value.

`civ` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Count in Value.

`ic` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Is Shotgun Choke.

`galid` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The general accessory list id.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **Update(String, Int64, Int64, String, String, String, String, String, String, Double, Double, Boolean, Boolean, String&)**

Updates the specified database path.

```csharp
public static bool Update(string databasePath, long id, long gunId, string manufacturer, string model, string serialNumber, string condition, string notes, string use, double purValue, double appValue, bool civ, bool ic, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`manufacturer` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The manufacturer.

`model` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The model.

`serialNumber` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The serial number.

`condition` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The condition.

`notes` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The notes.

`use` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The use.

`purValue` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The pur value.

`appValue` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The appriased value.

`civ` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [civ].

`ic` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [ic].

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **Update(String, Int64, Int64, String, String, String, String, String, String, Double, Double, Boolean, Boolean, Int32, String&)**

Updates the specified database path.

```csharp
public static bool Update(string databasePath, long id, long gunId, string manufacturer, string model, string serialNumber, string condition, string notes, string use, double purValue, double appValue, bool civ, bool ic, int gaId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`manufacturer` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The manufacturer.

`model` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The model.

`serialNumber` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The serial number.

`condition` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The condition.

`notes` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The notes.

`use` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The use.

`purValue` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The pur value.

`appValue` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The appriased value.

`civ` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [civ].

`ic` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [ic].

`gaId` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The General Accessor Link identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **Exists(String, Int64, String, String, String, String, String, String, Double, Double, Boolean, Boolean, String&)**

checks to see if the accessory already exists in the database for a particular firearm

```csharp
public static bool Exists(string databasePath, long gunId, string manufacturer, string model, string serialNumber, string condition, string notes, string use, double purValue, double appValue, bool civ, bool ic, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`manufacturer` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The manufacturer.

`model` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The model.

`serialNumber` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The serial number.

`condition` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The condition.

`notes` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The notes.

`use` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The use.

`purValue` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The pur value.

`appValue` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The appriased value.

`civ` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [civ].

`ic` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [ic].

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

**Remarks:**

This is mostyl used for Unit Testing, the application allos copy of duplicate values for accessories

### **GetId(String, Int64, String, String, String, String, String, String, Double, Double, Boolean, Boolean, String&)**

Gets the identifier of the selected accessorie details

```csharp
public static long GetId(string databasePath, long gunId, string manufacturer, string model, string serialNumber, string condition, string notes, string use, double purValue, double appValue, bool civ, bool ic, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`manufacturer` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The manufacturer.

`model` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The model.

`serialNumber` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The serial number.

`condition` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The condition.

`notes` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The notes.

`use` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The use.

`purValue` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The pur value.

`appValue` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The appriased value.

`civ` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [civ].

`ic` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [ic].

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64. The id in the table based on the information passed

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetId(String, Int64, String, String, String, String, String, String, Double, Double, Boolean, Boolean, Int32, String&)**

Gets the identifier of the selected accessorie details

```csharp
public static long GetId(string databasePath, long gunId, string manufacturer, string model, string serialNumber, string condition, string notes, string use, double purValue, double appValue, bool civ, bool ic, int galId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`manufacturer` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The manufacturer.

`model` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The model.

`serialNumber` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The serial number.

`condition` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The condition.

`notes` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The notes.

`use` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The use.

`purValue` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The pur value.

`appValue` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The appriased value.

`civ` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [civ].

`ic` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [ic].

`galId` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The general accessories link identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64. The id in the table based on the information passed

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetId(String, Int64, Int32, String&)**

Gets the accessory identifier based on the general accessory id and the gun id.

```csharp
public static long GetId(string databasePath, long gunId, int galId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`galId` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The gal identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **SumUpPurchaseValue(String, Int64, String&)**

Sums up purchase value.

```csharp
public static double SumUpPurchaseValue(string databasePath, long gunId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
System.Double.

### **SumUpAppriaseValue(String, Int64, String&)**

Sums up appriase value.

```csharp
public static double SumUpAppriaseValue(string databasePath, long gunId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
System.Double.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Delete(String, Int64, String&)**

Deletes the specified accessory from the database

```csharp
public static bool Delete(string databasePath, long id, String& errOut)
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
`true` if XXXX, `false` otherwise.

### **Delete(String, Int32, String&)**

Deletes the specified accessories that are linked from a General Accessory
 and the request to delete all related accessory from the database has been requested

```csharp
public static bool Delete(string databasePath, int genAssId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`genAssId` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The General Accessory identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **ResetGeneralAccessoryToZero(String, String&)**

Resets the general accessory to zero.

```csharp
public static bool ResetGeneralAccessoryToZero(string databasePath, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **ResetGeneralAccessoryToZero(String, Int32, String&)**

Resets the general accessory to zero based onthe selected general accessory id..

```csharp
public static bool ResetGeneralAccessoryToZero(string databasePath, int genAssId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`genAssId` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The gen ass identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **GetFullName(String, Int64, String&)**

Get the Fulle name, Manufacture and model name in one from the accessories table

```csharp
public static string GetFullName(string databasePath, long id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Database Path

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The id of the Accessory that you want to work with

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
If an exception occurs the message will be in this string

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Copy(String, Int64, Int64, String&)**

Copies the specified accessory to another firearm..

```csharp
public static bool Copy(string databasePath, long itemId, long gunId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`itemId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The item identifier.

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

### **List(String, String&)**

Get a list of all the accessories

```csharp
public static List<AccessoriesList> List(string databasePath, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Database Path

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
If an exception occurs the message will be in this string

#### Returns

[List&lt;AccessoriesList&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **List(String, Int64, String&)**

Get all the accessories for a particular firearm

```csharp
public static List<AccessoriesList> List(string databasePath, long gunId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Database Path

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
If an exception occurs the message will be in this string

#### Returns

[List&lt;AccessoriesList&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **List(String, Int32, String&)**

Return a List of the accessoriy based on it's id

```csharp
public static List<AccessoriesList> List(string databasePath, int id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Database Path

`id` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The id of the Accessory that you want to work with

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
If an exception occurs the message will be in this string

#### Returns

[List&lt;AccessoriesList&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

---

[`< Back`](./)
