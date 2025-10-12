[`< Back`](./)

---

# Appraisers

Namespace: BurnSoft.Applications.MGC.PeopleAndPlaces

Class Appraisers will handle the general functions needed to manage the Appraisers table

```csharp
public class Appraisers
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Appraisers](./burnsoft.applications.mgc.peopleandplaces.appraisers.md)

## Constructors

### **Appraisers()**

```csharp
public Appraisers()
```

## Methods

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

### **Add(String, String, String, String, String, String, String, String, String, String, String, String, Boolean, String&)**

Adds the specified database path.

```csharp
public static bool Add(string databasePath, string name, string address, string city, string state, string zipCode, string country, string phone, string fax, string eMail, string license, string webSite, bool stillInBusiness, String& errOut)
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

`country` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The country.

`phone` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The phone.

`fax` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The fax.

`eMail` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The e mail.

`license` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The license.

`webSite` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The web site.

`stillInBusiness` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [still in business].

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

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

### **Update(String, Int64, String, String, String, String, String, String, String, String, String, String, String, String, Boolean, String&)**

Updates the specified database path.

```csharp
public static bool Update(string databasePath, long id, string name, string address, string address2, string city, string state, string zipCode, string country, string phone, string fax, string eMail, string license, string webSite, bool stillInBusiness, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`address` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The address.

`address2` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The address2.

`city` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The city.

`state` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The state.

`zipCode` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The zip code.

`country` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The country.

`phone` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The phone.

`fax` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The fax.

`eMail` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The e mail.

`license` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The license.

`webSite` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The web site.

`stillInBusiness` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [still in business].

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **UpdateCollection(String, String, String, String&)**

Updates the collection.

```csharp
public static bool UpdateCollection(string databasePath, string oldName, string newName, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`oldName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The old name.

`newName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The new name.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

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

### **GetId(String, String, String&)**

Gets the identifier.

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

### **Get(String, String&)**

Gets the specified database path.

```csharp
public static List<AppraisersContactDetails> Get(string databasePath, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;AppraisersContactDetails&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;GunSmithContacts&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Get(String, Int64, String&)**

Gets the specified database path.

```csharp
public static List<AppraisersContactDetails> Get(string databasePath, long id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;AppraisersContactDetails&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;GunSmithContacts&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Get(String, String, String&)**

Gets the specified database path.

```csharp
public static List<AppraisersContactDetails> Get(string databasePath, string name, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;AppraisersContactDetails&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;GunSmithContacts&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

---

[`< Back`](./)
