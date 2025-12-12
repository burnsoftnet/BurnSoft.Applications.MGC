[`< Back`](./)

---

# XmlExport

Namespace: BurnSoft.Applications.MGC.Firearms

Class XmlExport. Export the firearm information in the view collection details form to an xml file.

```csharp
public class XmlExport
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [XmlExport](./burnsoft.applications.mgc.firearms.xmlexport)

## Constructors

### **XmlExport()**

```csharp
public XmlExport()
```

## Methods

### **Generate(String, Int64, String, String, String&)**

Generates the specified database path.

```csharp
public static bool Generate(string databasePath, long gunId, string appVersion, string file, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The gun identifier.

`appVersion` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The application version.

`file` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
the file name and path to save to

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

---

[`< Back`](./)
