[`< Back`](./)

---

# RegistryHelpers

Namespace: BurnSoft.Applications.MGC.LoadersLog

Class RegistryHelpers Pointer to halp the My Loaders Log use the MyRegistry Class Functions that it uses

```csharp
public class RegistryHelpers
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [RegistryHelpers](./burnsoft.applications.mgc.loaderslog.registryhelpers)

## Constructors

### **RegistryHelpers()**

```csharp
public RegistryHelpers()
```

## Methods

### **GetMgcExePath(String&, String)**

Gets the MGC executable path.

```csharp
public static string GetMgcExePath(String& errOut, string sDefault)
```

#### Parameters

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

`sDefault` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The s default.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
System.String.

### **GetMGCPath(String&, String)**

Gets the MGC database path.

```csharp
public static string GetMGCPath(String& errOut, string sDefault)
```

#### Parameters

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

`sDefault` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The s default.

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
