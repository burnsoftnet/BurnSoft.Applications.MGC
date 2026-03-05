[`< Back`](./)

---

# FirearmHelpers

Namespace: BurnSoft.Applications.MGC.LoadersLog

Class FirearmHelpers Gun Collection Data Helper for the My Loaders Log Application

```csharp
public class FirearmHelpers
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [FirearmHelpers](./burnsoft.applications.mgc.loaderslog.firearmhelpers)

## Constructors

### **FirearmHelpers()**

```csharp
public FirearmHelpers()
```

## Methods

### **CountFirearms(String&)**

Counts the firearms.

```csharp
public static int CountFirearms(String& errOut)
```

#### Parameters

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
System.Int32.

### **GetManufacturersId(String, String&)**

Gets the manufacturers identifier.

```csharp
public static long GetManufacturersId(string name, String& errOut)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

### **GetManufacturersName(Int32, String&)**

Gets the name of the manufacturers.

```csharp
public static string GetManufacturersName(int id, String& errOut)
```

#### Parameters

`id` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
System.String.

### **GetModelId(String, Int64, String&)**

Gets the model identifier.

```csharp
public static long GetModelId(string name, long manufacturerId, String& errOut)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`manufacturerId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The manufacturer identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

### **GetNationalityId(String, String&)**

Gets the nationality identifier.

```csharp
public static long GetNationalityId(string name, String& errOut)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

### **GetGripId(String, String&)**

Gets the grip identifier.

```csharp
public static long GetGripId(string name, String& errOut)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

### **GetGunShopId(String, String&)**

Gets the gun shop identifier.

```csharp
public static long GetGunShopId(string name, String& errOut)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

### **GetLastFirearmId(String&)**

Gets the last firearm identifier.

```csharp
public static long GetLastFirearmId(String& errOut)
```

#### Parameters

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

### **UpdateGunType(String, String&)**

Updates the type of the gun.

```csharp
public static bool UpdateGunType(string name, String& errOut)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **CaliberExists(String, String&)**

Calibers the exists.

```csharp
public static bool CaliberExists(string name, String& errOut)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **AddFirearmToMGC(String, String, String, String, String, String, String, String&, Int64)**

Adds the firearm to MGC.

```csharp
public static bool AddFirearmToMGC(string fullName, string manufacturer, string model, string caliber, string barrel, string serialNumber, string gunType, String& errOut, long MgcId)
```

#### Parameters

`fullName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The full name.

`manufacturer` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The manufacturer.

`model` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The model.

`caliber` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The caliber.

`barrel` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The barrel.

`serialNumber` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The serial number.

`gunType` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Type of the gun.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

`MgcId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The MGC identifier.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **AmmoIsAlreadyListed(String, String, String, String, String, Int64&, Int64&, String&)**

Ammoes the is already listed.

```csharp
public static bool AmmoIsAlreadyListed(string manufacturer, string name, string cal, string grain, string jacket, Int64& qty, Int64& mid, String& errOut)
```

#### Parameters

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

---

[`< Back`](./)
