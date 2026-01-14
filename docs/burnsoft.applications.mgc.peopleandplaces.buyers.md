[`< Back`](./)

---

# Buyers

Namespace: BurnSoft.Applications.MGC.PeopleAndPlaces

Class Buyers, which will handle the information relating to the Gun_Collection_SoldTo table in the database

```csharp
public class Buyers
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Buyers](./burnsoft.applications.mgc.peopleandplaces.buyers)

## Constructors

### **Buyers()**

```csharp
public Buyers()
```

## Methods

### **Exists(String, String, String, String, String, String, String, String, String, String&)**

Existses the specified database path.

```csharp
public static bool Exists(string databasePath, string name, string address, string address2, string city, string state, string zipCode, string dob, string dLic, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

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

`dob` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The dob.

`dLic` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The d lic.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **StolenBuyerExists(String, String, String&)**

Stolens the buyer exists.

```csharp
public static bool StolenBuyerExists(string databasePath, string name, String& errOut)
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

### **GetId(String, String, String&)**

Get the Id of the buyer record

```csharp
public static long GetId(string databasePath, string name, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Database Path

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
If an exception occurs the message will be in this string

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

### **GetName(String, Int32, String&)**

Gets the name.

```csharp
public static string GetName(string databasePath, int id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
System.String.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Get(String, Int64, String&)**

Get information from the database based on the buyers ID

```csharp
public static List<BuyersList> Get(string databasePath, long id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Database Path

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
If an exception occurs the message will be in this string

#### Returns

[List&lt;BuyersList&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **Get(String, String, String&)**

Get the buyer information based on a specific name

```csharp
public static List<BuyersList> Get(string databasePath, string name, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Database Path

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
If an exception occurs the message will be in this string

#### Returns

[List&lt;BuyersList&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **Get(String, String&)**

Get all the Buyers List from the database

```csharp
public static List<BuyersList> Get(string databasePath, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Database Path

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
If an exception occurs the message will be in this string

#### Returns

[List&lt;BuyersList&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **Add(String, String, String, String, String, String, String, String, String, String, String, String, String, String, String, String, String&)**

Add a new buyer and related information into the database

```csharp
public static bool Add(string databasePath, string name, string address1, string address2, string city, string state, string zipCode, string phone, string country, string eMail, string lic, string webSite, string fax, string dob, string dLic, string resident, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Database Path

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`address1` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`address2` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`city` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`state` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`zipCode` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`phone` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`country` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`eMail` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`lic` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`webSite` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`fax` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`dob` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`dLic` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`resident` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
If an exception occurs the message will be in this string

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Delete(String, Int64, String&)**

Delete a buyer from the database

```csharp
public static bool Delete(string databasePath, long id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Database Path

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
If an exception occurs the message will be in this string

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Update(String, Int64, String, String, String, String, String, String, String, String, String, String, String, String, String, String, String, String&)**

Update a buyers information in the database

```csharp
public static bool Update(string databasePath, long id, string name, string address1, string address2, string city, string state, string zipCode, string phone, string country, string eMail, string lic, string webSite, string fax, string dob, string dLic, string resident, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Database Path

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`address1` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`address2` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`city` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`state` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`zipCode` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`phone` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`country` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`eMail` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`lic` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`webSite` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`fax` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`dob` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`dLic` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`resident` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
If an exception occurs the message will be in this string

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **FirearmBought(String, Int64, Int64, String, String, String&)**

Firearms the bought.

```csharp
public static bool FirearmBought(string databasePath, long gunId, long buyerId, string dateSold, string salePrice, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`buyerId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The buyer identifier.

`dateSold` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The date sold.

`salePrice` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The sale price.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

---

[`< Back`](./)
