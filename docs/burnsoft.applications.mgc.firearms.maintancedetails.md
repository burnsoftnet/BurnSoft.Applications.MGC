[`< Back`](./)

---

# MaintanceDetails

Namespace: BurnSoft.Applications.MGC.Firearms

Class MaintanceDetails that will help manage the details of teh Maintance_Details table.

```csharp
public class MaintanceDetails
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [MaintanceDetails](./burnsoft.applications.mgc.firearms.maintancedetails)

## Constructors

### **MaintanceDetails()**

```csharp
public MaintanceDetails()
```

## Methods

### **Add(String, String, Int64, Int64, String, String, Int64, String, String, Int64, Boolean, String&)**

Adds the specified database path.

```csharp
public static bool Add(string databasePath, string name, long gunId, long maintenancePlanId, string operationDate, string operationDueDate, long roundsFired, string notes, string ammoUsed, long barrelSystemId, bool doesCount, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`maintenancePlanId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The maintenance plan identifier.

`operationDate` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The operation date.

`operationDueDate` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The operation due date.

`roundsFired` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The rounds fired.

`notes` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The notes.

`ammoUsed` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The ammo used.

`barrelSystemId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The barrel system identifier.

`doesCount` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [does count].

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **TotalRoundsFiredBs(String, Int32, String&)**

Totals the rounds fired bs.

```csharp
public static long TotalRoundsFiredBs(string databasePath, int barrelSystemId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`barrelSystemId` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The barrel system identifier.

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

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **AverageRoundsFired(String, Int32, String&)**

Averages the rounds fired.

```csharp
public static long AverageRoundsFired(string databasePath, int gunId, String& errOut)
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

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **AverageRoundsFiredBs(String, Int32, String&)**

Averages the rounds fired bs.

```csharp
public static long AverageRoundsFiredBs(string databasePath, int barrelSystemId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`barrelSystemId` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
barrel system id

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Update(String, Int64, String, Int64, Int64, String, String, Int64, String, String, Int64, Boolean, String&)**

Updates the specified database path.

```csharp
public static bool Update(string databasePath, long id, string name, long gunId, long maintenancePlanId, string operationDate, string operationDueDate, long roundsFired, string notes, string ammoUsed, long barrelSystemId, bool doesCount, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`maintenancePlanId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The maintenance plan identifier.

`operationDate` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The operation date.

`operationDueDate` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The operation due date.

`roundsFired` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The rounds fired.

`notes` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The notes.

`ammoUsed` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The ammo used.

`barrelSystemId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The barrel system identifier.

`doesCount` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [does count].

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Exists(String, String, Int64, Int64, String, String, String&)**

Exists the specified database path.

```csharp
public static bool Exists(string databasePath, string name, long gunId, long maintenancePlanId, string operationDate, string operationDueDate, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`maintenancePlanId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The maintenance plan identifier.

`operationDate` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The operation date.

`operationDueDate` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The operation due date.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Delete(String, Int64, String&)**

Deletes the specified database path.

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

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetId(String, String, Int64, Int64, String, String, String&)**

Gets the identifier.

```csharp
public static long GetId(string databasePath, string name, long gunId, long maintenancePlanId, string operationDate, string operationDueDate, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`maintenancePlanId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The maintenance plan identifier.

`operationDate` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The operation date.

`operationDueDate` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The operation due date.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetName(String, Int64, String&)**

Gets the name.

```csharp
public static string GetName(string databasePath, long id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
System.String.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Lists(String, String&)**

Get the Full List of Maintance Details in a list for all firearms.

```csharp
public static List<MaintanceDetailsList> Lists(string databasePath, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;MaintanceDetailsList&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;MaintanceDetailsList&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Lists(String, Int64, String&)**

Get the Full List of Maintance Details in a list for a specific firearm.

```csharp
public static List<MaintanceDetailsList> Lists(string databasePath, long gunId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;MaintanceDetailsList&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;MaintanceDetailsList&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Lists(String, Int32, String&)**

Get the Full List of Maintance Details in a list for a specific row in the table..

```csharp
public static List<MaintanceDetailsList> Lists(string databasePath, int id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;MaintanceDetailsList&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;MaintanceDetailsList&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Lists(String, Int64, Int64, String&)**

Get the Full List of Maintance Details in a list for a specific firearm and barrel sytem.

```csharp
public static List<MaintanceDetailsList> Lists(string databasePath, long gunId, long barrelSystem, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`barrelSystem` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The barrel system.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;MaintanceDetailsList&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;MaintanceDetailsList&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

---

[`< Back`](./)
