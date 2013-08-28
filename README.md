mINI
====

mINI is a lightweight INI file library written in C#.

Examples
--------

Load an existing INI file:

```CSharp
var ini = IniFile.Load("Test.ini");
```

Create a new property or set an existing property's value:

```CSharp
ini["Test"]["Key"].Value = "Value";
```

Save the INI file:

```CSharp
ini.Save("Test.ini");
```

Loop through the files sections and properties:

```CSharp
foreach (var section in ini.Sections)
{
    Console.WriteLine("[{0}]", section.Name);
    foreach (var property in section.Properties)
    {
        Console.WriteLine("{0}={1}", property.Key, property.Value);
    }
}
```

Result:

```
[Test]
Username=User
Password=Pass
Key=Value
Press any key to continue . . .
```

Programmatically create a new INI file:

```CSharp
var ini2 = new IniFile(
    new IniSection("Application", 
        new IniProperty("Host", "127.0.0.1"), 
        new IniProperty("Port", "1337")), 
    new IniSection("User", 
        new IniProperty("Username", "User"), 
        new IniProperty("Password", "Pass")));
ini2.Save("Test2.ini");
```


