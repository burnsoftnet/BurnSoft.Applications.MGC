[`< Back`](./)

---

# GunTypes

Namespace: BurnSoft.Applications.MGC.Firearms

Class GunTypes. This class is to help manage the Gun_Type table.

```csharp
public class GunTypes
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [GunTypes](./burnsoft.applications.mgc.firearms.guntypes.md)

## Constructors

### **GunTypes()**

```csharp
public GunTypes()
```

## Methods

### **Add(String, String, String&)**

Add the Gun Type to the datbaase table

```csharp
public static bool Add(string databasePath, string value, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Exists(String, String, String&)**

Check to see if the value already exists in the database

```csharp
public static bool Exists(string databasePath, string value, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **GetId(String, String, String&)**

Get the ID tied to the name fo the gun type based ont he name from the database

```csharp
public static int GetId(string databasePath, string value, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **Delete(String, Int32, String&)**

Delete the gun type from the database based on the id

```csharp
public static bool Delete(string databasePath, int id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`id` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Delete(String, String, String&)**

Delete the gun type from the database based on tie name

```csharp
public static bool Delete(string databasePath, string value, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Update(String, Int32, String, String&)**

Update the gun type in the database

```csharp
public static bool Update(string databasePath, int id, string value, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`id` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **UpdateGunType(String, String, String&)**

Check to see if the gun type exists int he database, if it does not then add it.

```csharp
public static bool UpdateGunType(string databasePath, string value, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **GetList(String, String&)**

Get a list of all the Gun Types in the database

```csharp
public static List<GunTypes> GetList(string databasePath, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>

#### Returns

[List&lt;GunTypes&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **GetList(String, Int64, String&)**

Get a lit os the Gun Types by the ID,

```csharp
public static List<GunTypes> GetList(string databasePath, long id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>

#### Returns

[List&lt;GunTypes&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

---

[`< Back`](./)
