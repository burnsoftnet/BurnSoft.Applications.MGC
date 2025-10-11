[`< Back`](./)

---

# MyCollectionQry

Namespace: BurnSoft.Applications.MGC.Firearms

Class MyCollection, The majority of this class will hand the data from the qryGunCollectionDetails qurery table.

```csharp
public class MyCollectionQry
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [MyCollectionQry](./burnsoft.applications.mgc.firearms.mycollectionqry.md)

## Constructors

### **MyCollectionQry()**

```csharp
public MyCollectionQry()
```

## Methods

### **SearchList(String, String, String, String&)**

Searches the list.

```csharp
public static List<GunCollectionList> SearchList(string databasePath, string column, string lookFor, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`column` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The column.

`lookFor` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The look for.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;GunCollectionList&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;GunCollectionList&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

---

[`< Back`](./)
