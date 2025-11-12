[`< Back`](./)

---

# Helpers

Namespace: BurnSoft.Applications.MGC.Global

Class Helpers.

```csharp
public class Helpers
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Helpers](./burnsoft.applications.mgc.global.helpers.md)

## Constructors

### **Helpers()**

```csharp
public Helpers()
```

## Methods

### **ObjectToByteArray(Object)**

Convert an Object to a Byte Array

```csharp
public static Byte[] ObjectToByteArray(object obj)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

#### Returns

[Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>

### **FormatFromXml(String)**

Formats from XML.

```csharp
public static string FormatFromXml(string value)
```

#### Parameters

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The value.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
System.String.

### **SetCatalogInsType(Boolean, String, String&)**

Sets the type of the catalog to insert into the database.

```csharp
public static string SetCatalogInsType(bool useNumberOnlyCatalog, string value, String& errOut)
```

#### Parameters

`useNumberOnlyCatalog` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
if set to `true` [use number only catalog].

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The value.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
System.String.

### **FluffContent(String, String&, String)**

Fluffs the content.

```csharp
public static string FluffContent(string value, String& errOut, string defaultValue)
```

#### Parameters

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The value.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

`defaultValue` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The default value.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
System.String.

### **IsNumeric(String)**

Determines whether the specified text is numeric.

```csharp
public static bool IsNumeric(string text)
```

#### Parameters

`text` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The text.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if the specified text is numeric; otherwise, `false`.

### **Mid(String, Int32, Char)**

Mids the specified input.

```csharp
public static string Mid(string input, int index, char newChar)
```

#### Parameters

`input` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The input.

`index` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The index.

`newChar` [Char](https://docs.microsoft.com/en-us/dotnet/api/system.char)<br>
The new character.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
System.String.

#### Exceptions

[ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception)<br>
input

### **Mid(String, Int32, Int32)**

Mids the specified s.

```csharp
public static string Mid(string s, int a, int b)
```

#### Parameters

`s` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The s.

`a` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
a.

`b` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The b.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
System.String.

### **ConvertTextToNumber(String, String&)**

Converts the text to number.

```csharp
public static double ConvertTextToNumber(string strValue, String& errOut)
```

#### Parameters

`strValue` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string value.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
System.Double.

### **IsRequired(String, String, String, String&)**

Determines whether the specified string value is required.

```csharp
public static bool IsRequired(string strValue, string strField, string strTitle, String& errOut)
```

#### Parameters

`strValue` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string value.

`strField` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string field.

`strTitle` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string title.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if the specified string value is required; otherwise, `false`.

### **IsRequired(Int64, Int64, String, String, String&)**

Determines whether the specified l value is required.

```csharp
public static bool IsRequired(long lValue, long lDefault, string strField, string strTitle, String& errOut)
```

#### Parameters

`lValue` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The l value.

`lDefault` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
The l default.

`strField` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string field.

`strTitle` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string title.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if the specified l value is required; otherwise, `false`.

### **IsRequired(Double, Double, String, String, String&)**

Determines whether the specified l value is required.

```csharp
public static bool IsRequired(double lValue, double lDefault, string strField, string strTitle, String& errOut)
```

#### Parameters

`lValue` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The l value.

`lDefault` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The l default.

`strField` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string field.

`strTitle` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string title.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if the specified l value is required; otherwise, `false`.

---

[`< Back`](./)
