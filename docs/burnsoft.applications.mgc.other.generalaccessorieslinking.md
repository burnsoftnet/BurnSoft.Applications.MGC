[`< Back`](./)

---

# GeneralAccessoriesLinking

Namespace: BurnSoft.Applications.MGC.Other

General Class to handline the linking between the firearm and the General Accessories. 
 We are keeping the Firearm accessories the way it is because there are some things that will
 never be put into general, while others can be.

```csharp
public class GeneralAccessoriesLinking
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [GeneralAccessoriesLinking](./burnsoft.applications.mgc.other.generalaccessorieslinking.md)

## Constructors

### **GeneralAccessoriesLinking()**

```csharp
public GeneralAccessoriesLinking()
```

## Methods

### **AttachToFirearm(String, Int32, Int64, String&)**

Attaches The general accessory to the select firearm accessories and adds it to the link list.

```csharp
public static bool AttachToFirearm(string databasePath, int id, long gunId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The identifier.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **IsAttached(String, Int32, String&)**

Determines whether the accessory by id is attached to other firearm accessories

```csharp
public static bool IsAttached(string databasePath, int id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The accessory identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if the specified database path is attached; otherwise, `false`.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Add(String, Int32, Int64, String&)**

Adds the specified linker id's to the linker table

```csharp
public static bool Add(string databasePath, int id, long gunId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The general accessory identifier.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **Delete(String, Int32, String&)**

Deletes the specified Link by id from the tabl

```csharp
public static bool Delete(string databasePath, int linkId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`linkId` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The link identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Delete(String, Int32, Int64, String&)**

Deletes the specified link(s) from the table based on the accessory id and gun id.

```csharp
public static bool Delete(string databasePath, int accessory_id, long gunId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`accessory_id` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The accessory identifier.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Delete(String, List&lt;GeneralAccessoriesLinkers&gt;, String&)**

Deletes the specified links from the table based on the provided list.

```csharp
public static bool Delete(string databasePath, List<GeneralAccessoriesLinkers> deleteList, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`deleteList` [List&lt;GeneralAccessoriesLinkers&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
The delete list.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **UpdateFirearm(String, Int32, Int64, String&)**

Updates the firearm accessory with the details that was updated in the general accessories table..

```csharp
public static bool UpdateFirearm(string databasePath, int id, long gunId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The identifier.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Lists(String, String&)**

Return a List of all the general accessories linkers based

```csharp
public static List<GeneralAccessoriesLinkers> Lists(string databasePath, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Database Path

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
If an exception occurs the message will be in this string

#### Returns

[List&lt;GeneralAccessoriesLinkers&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **Lists(String, Int32, String&)**

Return a List of the general accessories linkers based accessory id

```csharp
public static List<GeneralAccessoriesLinkers> Lists(string databasePath, int accessoryId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Database Path

`accessoryId` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The id of the Accessory that you want to work with

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
If an exception occurs the message will be in this string

#### Returns

[List&lt;GeneralAccessoriesLinkers&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **Lists(String, Int64, Int32, String&)**

Return a List of the general accessories linkers based accessory and firearm id

```csharp
public static List<GeneralAccessoriesLinkers> Lists(string databasePath, long gunId, int accessoryId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Database Path

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
the firearm ID

`accessoryId` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The id of the Accessory that you want to work with

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
If an exception occurs the message will be in this string

#### Returns

[List&lt;GeneralAccessoriesLinkers&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **GetId(String, Int64, Int32, String&)**

Gets the identifier for the general accessory attached to the firearm in the linker table

```csharp
public static long GetId(string databasePath, long gunId, int galId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`galId` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The general accessory identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64. Linker table ID

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Exists(String, Int64, Int32, String&)**

Check to see if an accessory and gun id already exist in the linkers table.

```csharp
public static bool Exists(string databasePath, long gunId, int galid, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

`galid` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

---

[`< Back`](./)
