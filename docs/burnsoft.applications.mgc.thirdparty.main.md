[`< Back`](./)

---

# Main

Namespace: BurnSoft.Applications.MGC.ThirdParty

Class Third Party Class for some simply functions that another application can use to interact with the Gun Collection Application. This is mostly based off the My Loader Load Functions

```csharp
public class Main
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Main](./burnsoft.applications.mgc.thirdparty.main)

## Constructors

### **Main()**

```csharp
public Main()
```

## Methods

### **GetDatabaseLocation(String&)**

Gets the database location.

```csharp
public static string GetDatabaseLocation(String& errOut)
```

#### Parameters

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
System.String.

### **GetMgcExePath(String&)**

Gets the MGC executable path.

```csharp
public static string GetMgcExePath(String& errOut)
```

#### Parameters

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
System.String.

### **MyGunCollectionIsInstalled(String&)**

Mies the gun collection is installed.

```csharp
public static bool MyGunCollectionIsInstalled(String& errOut)
```

#### Parameters

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

---

[`< Back`](./)
