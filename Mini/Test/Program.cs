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
        }
    }
}
