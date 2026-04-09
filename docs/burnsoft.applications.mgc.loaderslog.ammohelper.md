[`< Back`](./)

---

# AmmoHelper

Namespace: BurnSoft.Applications.MGC.LoadersLog

Class AmmoHelper mostly helps process the ammunition that is being exported from the My Loaders 
 Log Application to the My Gun Collection Ammo Inventory Table

```csharp
public class AmmoHelper
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [AmmoHelper](./burnsoft.applications.mgc.loaderslog.ammohelper)

## Constructors

### **AmmoHelper()**

```csharp
public AmmoHelper()
```

## Methods

### **ImportAmmoMade(List&lt;Ammunition&gt;, String&)**

Imports the ammo made.

```csharp
public static bool ImportAmmoMade(List<Ammunition> newAmmo, String& errOut)
```

#### Parameters

`newAmmo` [List&lt;Ammunition&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
The new ammo.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **AddedToAmmoList(List&lt;Ammunition&gt;, String, String, String, String, String, Int32, Int32, String&)**

Addeds to ammo list.

```csharp
public static List<Ammunition> AddedToAmmoList(List<Ammunition> ammoList, string manufacturer, string name, string caliber, string grain, string jacket, int qty, int velocity, String& errOut)
```

#### Parameters

`ammoList` [List&lt;Ammunition&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
The ammo list.

`manufacturer` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The manufacturer.

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name.

`caliber` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The caliber.

`grain` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The grain.

`jacket` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The jacket.

`qty` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The qty.

`velocity` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The velocity.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;Ammunition&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;Types.Ammunition&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

---

[`< Back`](./)
