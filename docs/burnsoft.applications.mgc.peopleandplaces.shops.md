[`< Back`](./)

---

# Shops

Namespace: BurnSoft.Applications.MGC.PeopleAndPlaces

Class Contacts handling class

```csharp
public class Shops
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Shops](./burnsoft.applications.mgc.peopleandplaces.shops.md)

## Constructors

### **Shops()**

```csharp
public Shops()
```

## Methods

### **Exists(String, String, String&)**

Existses the specified database path.

```csharp
public static bool Exists(string databasePath, string name, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Count(String, String, String&)**

Counts the specified database path.

```csharp
public static int Count(string databasePath, string name, String& errOut)
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

### **Add(String, String, String&)**

Adds the specified database path.

```csharp
public static bool Add(string databasePath, string name, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **Add(String, String, String, String, String, String, String&)**

Adds the specified database path.

```csharp
public static bool Add(string databasePath, string name, string address, string city, string state, string zipCode, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`address` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The address.

`city` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The city.

`state` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The state.

`zipCode` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The zip code.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **Update(String, Int32, String, String, String, String, String, String, String, String, String, String, String, String, Boolean, String&)**

Updates the specified database path.

```csharp
public static bool Update(string databasePath, int id, string name, string address, string address2, string city, string state, string zipCode, string country, string phone, string fax, string website, string email, string license, bool isStillInBusiness, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The identifier.

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`address` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The address.

`address2` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`city` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The city.

`state` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The state.

`zipCode` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The zip code.

`country` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Country

`phone` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Phone number

`fax` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Fax, yes people still use them

`website` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Website

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
email

`license` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
FFLor drivers license or CR license

`isStillInBusiness` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Still in business

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **HasCollectionAttached(String, Int64, String&)**

Determines whether [has collection attached] [the specified database path].

```csharp
public static int HasCollectionAttached(string databasePath, long id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
`true` if [has collection attached] [the specified database path]; otherwise, `false`.

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

### **GetName(String, Int64, String&)**

Gets the name of the shop by the id.

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

### **GetId(String, String, String&)**

Gets the identifier by the shop name.

```csharp
public static long GetId(string databasePath, string name, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Get(String, Int64, String&)**

Gets the specified shop by id from the database

```csharp
public static List<GunShopDetails> Get(string databasePath, long id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;GunShopDetails&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;GunShopDetails&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Get(String, String&)**

Gets all the shop details in the database

```csharp
public static List<GunShopDetails> Get(string databasePath, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;GunShopDetails&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;GunShopDetails&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

---

[`< Back`](./)
