namespace Mini
{
    public class IniProperty
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public IniProperty(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
