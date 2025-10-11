[`< Back`](./)

---

# HotFix

Namespace: BurnSoft.Applications.MGC.hotixes

Class HotFix. Hotfix fix main functions

```csharp
public class HotFix
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [HotFix](./burnsoft.applications.mgc.hotixes.hotfix.md)

## Fields

### **NumberOfFixes**

The number of fixes for this version in the datrabase

```csharp
public static int NumberOfFixes;
```

## Constructors

### **HotFix()**

```csharp
public HotFix()
```

## Methods

### **SendStatus(String)**

Sends the status.

```csharp
protected void SendStatus(string value)
```

#### Parameters

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The value.

### **SendErrors(String)**

Sends the errors.

```csharp
protected void SendErrors(string value)
```

#### Parameters

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The value.

### **Run(String, Int32, String&)**

Runs the specified database path.

```csharp
public static bool Run(string databasePath, int hotFixNumber, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`hotFixNumber` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The hot fix number.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **RunObj(String, Int32, String&)**

Runs the specified database path.

```csharp
public bool RunObj(string databasePath, int hotFixNumber, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`hotFixNumber` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The hot fix number.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **NeedsUpdate(String, String&)**

Needses the update.

```csharp
public static bool NeedsUpdate(string databasePath, String& errOut)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

### **ApplyMissingHotFixes(String, String&, String&)**

Applies the missing hot fixes.

```csharp
public static bool ApplyMissingHotFixes(string databasePath, String& errOut, String& appliedFixes)
```

#### Parameters

`databasePath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The database path.

`errOut` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>
The error out.

`appliedFixes` [String&](https://docs.microsoft.com/en-us/dotnet/api/system.string&)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if XXXX, `false` otherwise.

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

## Events

### **Status**

Occurs when [status].

```csharp
public event EventHandler<string> Status;
```

### **Errors**

Occurs when [errors].

```csharp
public event EventHandler<string> Errors;
```

---

[`< Back`](./)
