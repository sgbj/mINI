using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Mini
{
    public static class Ini
    {

        public static IEnumerable<string> Get(string path, string section = null, string key = null)
        {
            var c = new char[1024];
            GetPrivateProfileString(section, key, null, c, c.Length, new FileInfo(path).FullName);
            return new string(c).Split('\0').TakeWhile(s => !string.IsNullOrWhiteSpace(s));
        }

        public static void Put(string path, string section, string key = null, string value = null)
        {
            WritePrivateProfileString(section, key, value, new FileInfo(path).FullName);
        }

        [DllImport("Kernel32")]
        public static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, [In, Out] char[] lpReturnedString, int nSize, string lpFileName);

        [DllImport("Kernel32")]
        public static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);
    }
}
