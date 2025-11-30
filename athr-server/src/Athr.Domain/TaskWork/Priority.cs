namespace Athr.Domain.TaskWork
{
    public sealed record Priority
    {
        public static readonly Priority Low = new("Low", 100);
        public static readonly Priority Medium = new("Medium", 200);
        public static readonly Priority High = new("High", 300);
        public static readonly Priority Critical = new("Critical", 400);
        public string Value { get; private set; }
        public int Key { get; private set; }
        private Priority() { }
        public Priority(string value, int key)
        {
            Value = value;
            Key = key;
        }
    }
}
