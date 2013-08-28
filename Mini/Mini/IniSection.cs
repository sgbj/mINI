using System.Collections.Generic;
using System.Linq;

namespace Mini
{
    public class IniSection
    {
        public string Name { get; set; }
        public IEnumerable<IniProperty> Properties { get; set; }

        public IniSection(string name, params IniProperty[] properties)
        {
            Name = name;
            Properties = properties;
        }

        public IniProperty this[string key]
        {
            get
            {
                var property = Properties.FirstOrDefault(p => p.Key == key);
                if (property == null)
                    Properties = Properties.Concat(new[] { property = new IniProperty(key, null) });
                return property;
            }
        }
    }
}
