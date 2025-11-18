[`< Back`](./)

---

# GunSmithDetails

Namespace: BurnSoft.Applications.MGC.Firearms

Class GunSmithDetails, Class to handle management of the gunsmith_details table.

```csharp
public class GunSmithDetails
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [GunSmithDetails](./burnsoft.applications.mgc.firearms.gunsmithdetails)

## Constructors

### **GunSmithDetails()**

```csharp
public GunSmithDetails()
```

## Methods

### **Exists(String, Int64, String, String, String&)**

Existses the specified database path.

```csharp
public static bool Exists(string databasePath, long gunId, string smithName, string orderDetails, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`smithName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name of the smith.

`orderDetails` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Add(String, Int64, String, Int64, String, String, String, String, String&)**

Adds the specified database path.

```csharp
public static bool Add(string databasePath, long gunId, string smithName, long gunSmithId, string orderDetails, string notes, string startDate, string returnDate, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`smithName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name of the smith.

`gunSmithId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun smith identifier.

`orderDetails` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The order details.

`notes` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The notes.

`startDate` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The start date.

`returnDate` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The return date.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Add(String, Int64, String, String, String, String, String, String&)**

Adds the specified database path.

```csharp
public static bool Add(string databasePath, long gunId, string smithName, string orderDetails, string notes, string startDate, string returnDate, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`smithName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name of the smith.

`orderDetails` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The order details.

`notes` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The notes.

`startDate` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The start date.

`returnDate` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The return date.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **HasCollectionAttached(String, String, String&)**

Determines whether [has collection attached] [the specified database path].

```csharp
public static int HasCollectionAttached(string databasePath, string name, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
System.Int32.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Update(String, Int64, Int64, String, Int64, String, String, String, String, String&)**

Updates The gun smith details for a firearm

```csharp
public static bool Update(string databasePath, long id, long gunId, string smithName, long gunSmithId, string orderDetails, string notes, string startDate, string returnDate, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`smithName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name of the smith.

`gunSmithId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun smith identifier.

`orderDetails` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The order details.

`notes` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The notes.

`startDate` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The start date.

`returnDate` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The return date.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Update(String, Int64, String, String, String, String, String, String&)**

Updates the specified database path.

```csharp
public static bool Update(string databasePath, long id, string smithName, string orderDetails, string notes, string startDate, string returnDate, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`smithName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name of the smith.

`orderDetails` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The order details.

`notes` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The notes.

`startDate` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The start date.

`returnDate` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The return date.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Update(String, Int64, Int64, String, String, String, String, String, String&)**

Updates the specified database path.

```csharp
public static bool Update(string databasePath, long id, long gunId, string smithName, string orderDetails, string notes, string startDate, string returnDate, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`smithName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name of the smith.

`orderDetails` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The order details.

`notes` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The notes.

`startDate` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The start date.

`returnDate` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The return date.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **Update(String, Int64, String, Int64, String, String, String, String, String&)**

Updates The gun smith details for a firearm

```csharp
public static bool Update(string databasePath, long id, string smithName, long gunSmithId, string orderDetails, string notes, string startDate, string returnDate, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`smithName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name of the smith.

`gunSmithId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun smith identifier.

`orderDetails` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The order details.

`notes` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The notes.

`startDate` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The start date.

`returnDate` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The return date.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetId(String, Int64, Int64, String, String&)**

Gets the identifier.

```csharp
public static long GetId(string databasePath, long gunId, long gunSmithId, string orderDetails, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`gunSmithId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun smith identifier.

`orderDetails` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The order details.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

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

### **Lists(String, Int64, String&)**

Listses the specified database path.

```csharp
public static List<GunSmithWorkDone> Lists(string databasePath, long gunId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;GunSmithWorkDone&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;GunSmithWorkDone&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **ListsById(String, Int64, String&)**

Listses the by identifier.

```csharp
public static List<GunSmithWorkDone> ListsById(string databasePath, long id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;GunSmithWorkDone&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;GunSmithWorkDone&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Lists(String, String, String&)**

Listses the specified database path.

```csharp
public static List<GunSmithWorkDone> Lists(string databasePath, string gunSmithName, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunSmithName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name of the gun smith.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;GunSmithWorkDone&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;GunSmithWorkDone&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Lists(String, String&, Boolean)**

Listses the specified database path.

```csharp
public static List<GunSmithWorkDone> Lists(string databasePath, String& errOut, bool doDistinct)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

`doDistinct` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

#### Returns

[List&lt;GunSmithWorkDone&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;GunSmithWorkDone&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

---

[`< Back`](./)
