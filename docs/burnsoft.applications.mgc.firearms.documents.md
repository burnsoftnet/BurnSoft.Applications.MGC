[`< Back`](./)

---

# Documents

Namespace: BurnSoft.Applications.MGC.Firearms

Class Documents to manage the doucments section, upload, edit assisgn, and delete

```csharp
public class Documents
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Documents](./burnsoft.applications.mgc.firearms.documents)

## Fields

### **FileFilterList**

The file filter list

```csharp
public static string FileFilterList;
```

## Constructors

### **Documents()**

```csharp
public Documents()
```

## Methods

### **GetDocType(Int32)**

Gets the type of the document.

```csharp
public static string GetDocType(int selectedIndex)
```

#### Parameters

`selectedIndex` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Index of the selected.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
System.String.

### **GetDocFromHdd(String, String&)**

Gets the document from HDD.

```csharp
public static Byte[] GetDocFromHdd(string filePath, String& errOut)
```

#### Parameters

`filePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The file path.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
System.Byte[].

### **Update(String, Int32, Boolean, String, String, String, String, Int32, String&)**

Updates the specified database path.

```csharp
public static bool Update(string databasePath, int documentId, bool fileWasSelected, string title, string description, string category, string filePathAndName, int selectedFileType, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`documentId` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The document identifier.

`fileWasSelected` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [file was selected].

`title` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The title.

`description` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The description.

`category` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The category.

`filePathAndName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name of the file path and.

`selectedFileType` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Type of the selected file.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **Exists(String, String, String&)**

Existses the specified database path.

```csharp
public static bool Exists(string databasePath, string title, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`title` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The title.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

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

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **Add(String, String, String, String, String, Int32, String&)**

Adds the specified database path.

```csharp
public static bool Add(string databasePath, string title, string description, string category, string filePathAndName, int selectedFileType, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`title` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The title.

`description` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The description.

`category` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The category.

`filePathAndName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name of the file path and.

`selectedFileType` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Type of the selected file.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **GetId(String, String, String&)**

Gets the identifier.

```csharp
public static long GetId(string databasePath, string title, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`title` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The title.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetLastId(String, String&)**

Gets the last identifier.

```csharp
public static long GetLastId(string databasePath, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
System.Int64.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **PerformDocLink(String, Int64, Int64, String&)**

Performs the document link.

```csharp
public static bool PerformDocLink(string databasePath, long firearmId, long documentId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`firearmId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The firearm identifier.

`documentId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The document identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **DocLinkExists(String, Int64, Int64, String&)**

Check to seeif a doc link already exists between the firearm and the document

```csharp
public static bool DocLinkExists(string databasePath, long firearmId, long documentId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Database Path

`firearmId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

`documentId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
If an exception occurs the message will be in this string

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **GetDocLinkId(String, Int64, Int64, String&)**

Get the Doc link Id

```csharp
public static long GetDocLinkId(string databasePath, long docId, long gunId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Database Path

`docId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
If an exception occurs the message will be in this string

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

### **DeleteDocLink(String, Int64, String&)**



```csharp
public static bool DeleteDocLink(string databasePath, long id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Database Path

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
If an exception occurs the message will be in this string

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **DeleteFirearmFromLinkList(String, Int64, String&)**

Remove firearm from link lists

```csharp
public static bool DeleteFirearmFromLinkList(string databasePath, long gunId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Database Path

`gunId` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
If an exception occurs the message will be in this string

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **GetList(String, String&)**

Gets the list.

```csharp
public static List<DocumentList> GetList(string databasePath, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;DocumentList&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;DocumentList&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **GetLinkList(String, String&)**

Get all the Doc Link Lists

```csharp
public static List<DocumentLinkList> GetLinkList(string databasePath, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Database Path

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
If an exception occurs the message will be in this string

#### Returns

[List&lt;DocumentLinkList&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **GetList(String, Int64, String&)**

Gets the list.

```csharp
public static List<DocumentList> GetList(string databasePath, long id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[List&lt;DocumentList&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
List&lt;DocumentList&gt;.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **HasDocumentsAttached(String, Int32, String&)**

Determines whether [has documents attached] [the specified database path].

```csharp
public static bool HasDocumentsAttached(string databasePath, int gunId, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`gunId` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The gun identifier.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if [has documents attached] [the specified database path]; otherwise, `false`.

### **CountLinkedDocs(String, Int64, String&)**

Count the number of firearms this document is attached to.

```csharp
public static long CountLinkedDocs(string databasePath, long id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
database path and name

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
document id

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
exception message if any

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

### **GetDocumentFromDb(String, String, Int64, String&)**

Get the Data of the document from the database and save it to the hard drive to view or export

```csharp
public static bool GetDocumentFromDb(string databasePath, string applicationPathData, long id, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Database Path

`applicationPathData` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`id` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
If an exception occurs the message will be in this string

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

---

[`< Back`](./)
