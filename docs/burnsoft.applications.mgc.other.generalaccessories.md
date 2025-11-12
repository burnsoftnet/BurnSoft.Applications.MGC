[`< Back`](./)

---

# GeneralAccessories

Namespace: BurnSoft.Applications.MGC.Other

Main Class to handle the General_Accessories table.

```csharp
public class GeneralAccessories
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [GeneralAccessories](./burnsoft.applications.mgc.other.generalaccessories.md)

## Constructors

### **GeneralAccessories()**

```csharp
public GeneralAccessories()
```

## Methods

### **Add(String, String, String, String, String, String, String, Double, Double, Boolean, Boolean, String&)**

Adds the specified accessory to the database.

```csharp
public static bool Add(string databasePath, string manufacturer, string model, string serialNumber, string condition, string notes, string use, double purValue, double appValue, bool civ, bool ic, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

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

### **Update(String, Int64, String, String, String, String, String, String, Double, Double, Boolean, Boolean, String&)**

Updates the specified accessory in the database.

```csharp
public static bool Update(string databasePath, long id, string manufacturer, string model, string serialNumber, string condition, string notes, string use, double purValue, double appValue, bool civ, bool ic, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

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

### **Lists(String, Int32, String&)**

Return a List of the general accessories based on it's id

```csharp
public static List<GeneralAccessoriesList> Lists(string databasePath, int id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Database Path

`id` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The id of the Accessory that you want to work with

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
If an exception occurs the message will be in this string

#### Returns

[List&lt;GeneralAccessoriesList&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **Lists(String, String&)**

Return a List of all the general accessories

```csharp
public static List<GeneralAccessoriesList> Lists(string databasePath, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Database Path

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
If an exception occurs the message will be in this string

#### Returns

[List&lt;GeneralAccessoriesList&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **Exists(String, String, String, String, String&)**

Check to see an in accessory exists based on the Manufacture, Model and serial number.
 Might not even be needed since This section is designed to hold misc accessories which 
 can contain multiple of the same product. But not listed in qty since they can be different
 in some way and not all equal, or you might have or create a serial number for it.

```csharp
public static bool Exists(string databasePath, string manufacturer, string model, string serialNumber, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`manufacturer` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`model` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`serialNumber` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **GetId(String, String, String, String, String, String, Boolean, Boolean, String&)**

Gets the identifier of the selected accessorie details

```csharp
public static long GetId(string databasePath, string manufacturer, string model, string serialNumber, string condition, string use, bool civ, bool ic, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`manufacturer` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The manufacturer.

`model` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The model.

`serialNumber` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The serial number.

`condition` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The condition.

`use` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The use.

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

### **GetId(String, String, String, String, String&)**

Gets the identifier of the selected accessorie details

```csharp
public static long GetId(string databasePath, string manufacturer, string model, string serialNumber, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`manufacturer` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The manufacturer.

`model` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The model.

`serialNumber` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The serial number.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64. The id in the table based on the information passed

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Delete(String, Int32, String&)**

Delete an Accessory from the General Accessory list and removes all the links.

```csharp
public static bool Delete(string databasePath, int id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Database path

`id` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The Accessory ID

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
Exception error message

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Truw if delete was ok, false if there was an error

### **Delete(String, Int32, Boolean, String&)**

Deletes the specified Accessory from the links and general tables, as well as the option to delete it
 from all the firearms that it is attacted to so a complete clelan up.

```csharp
public static bool Delete(string databasePath, int id, bool deleteFromFirearms, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The identifier.

`deleteFromFirearms` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [delete from firearms].

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

---

[`< Back`](./)
