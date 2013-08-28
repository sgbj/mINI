using Mini;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var ini = IniFile.Load("Test.ini");
            ini["Test"]["Key"].Value = "Value";
            foreach (var section in ini.Sections)
            {
                Console.WriteLine("[{0}]", section.Name);
                foreach (var property in section.Properties)
                {
                    Console.WriteLine("{0}={1}", property.Key, property.Value);
                }
            }
            ini.Save("Test.ini");

            var ini2 = new IniFile(
                new IniSection("Application", 
                    new IniProperty("Host", "127.0.0.1"), 
                    new IniProperty("Port", "1337")), 
                new IniSection("User", 
                    new IniProperty("Username", "User"), 
                    new IniProperty("Password", "Pass")));
            ini2.Save("Test2.ini");
        }
    }
}
