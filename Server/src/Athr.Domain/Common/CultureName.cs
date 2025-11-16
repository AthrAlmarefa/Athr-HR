namespace Athr.Domain.Common
{
    public abstract class CultureName
    {
        protected CultureName(string value, Culture culture, bool isDefault)
        {
            Value = value;
            Culture = culture;
            IsDefault = isDefault;
        }
        public LocalizedNameId Id { get; }
        protected CultureName()
        {
        }
        public string Value { get; private set; }
        public Culture Culture { get; private set; }
        public bool IsDefault { get; private set; }

        public void ChangeBasics(string name, Culture culture, bool isDefault)
        {
            Value = name;
            Culture = culture;
            IsDefault = isDefault;
        }
    }
}
