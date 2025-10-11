[`< Back`](./)

---

# Accessories

Namespace: BurnSoft.Applications.MGC.Firearms

Class Accessories that handles firearm accessories database calls

```csharp
public class Accessories
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Accessories](./burnsoft.applications.mgc.firearms.accessories.md)

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
The application value.

`civ` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [civ].

`ic` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [ic].

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
The application value.

`civ` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [civ].

`ic` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [ic].

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
The application value.

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

Gets the identifier.

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
The application value.

`civ` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [civ].

`ic` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [ic].

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

### **GetFullName(String, Int64, String&)**

Get the Fulle name, Manufacture and model name in one from the accessories table

```csharp
public static string GetFullName(string databasePath, long id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>

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

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>

#### Returns

[List&lt;AccessoriesList&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **List(String, Int64, String&)**

Get all the accessories for a particular firearm

```csharp
public static List<AccessoriesList> List(string databasePath, long gunId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>

#### Returns

[List&lt;AccessoriesList&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **List(String, Int32, String&)**

Return a List of the accessoriy based on it's id

```csharp
public static List<AccessoriesList> List(string databasePath, int id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`id` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>

#### Returns

[List&lt;AccessoriesList&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

---

[`< Back`](./)
