using System.Collections.Generic;
using System.Linq;

namespace Mini
{
    public class IniFile
    {
        public IEnumerable<IniSection> Sections { get; set; }

        public IniFile(params IniSection[] sections)
        {
            Sections = sections;
        }

        public void Save(string path)
        {
            Sections.ToList().ForEach(s => s.Properties.ToList().ForEach(p => Ini.Put(path, s.Name, p.Key, p.Value)));
        }

        public static IniFile Load(string path)
        {
            return new IniFile(Ini.Get(path).Select(s =>
                        new IniSection(s, Ini.Get(path, s).Select(k =>
                            new IniProperty(k, Ini.Get(path, s, k).FirstOrDefault())).ToArray())).ToArray());
        }

        public IniSection this[string name]
        {
            get
            {
                var section = Sections.FirstOrDefault(s => s.Name == name);
                if (section == null)
                    Sections = Sections.Concat(new[] { section = new IniSection(name) });
                return section;
            }
        }
    }
}
