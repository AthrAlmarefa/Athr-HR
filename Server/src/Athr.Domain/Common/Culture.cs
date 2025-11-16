namespace Athr.Domain.Common;

public sealed record Culture
{
    internal static readonly Culture None = new("");
    public static readonly Culture ArEg = new("ar-EG");
    public static readonly Culture EnUs = new("en-US");
    //public static readonly Culture DeDe = new("de-DE");

    public static readonly IReadOnlyCollection<Culture> All = new[] { ArEg, EnUs };

    private Culture(string code)
    {
        Code = code;
    }

    public string Code { get; init; }

    public static Culture FromCode(string code)
    {
        return All.FirstOrDefault(c => c.Code == code) ?? throw new ApplicationException("The culture code is invalid");
    }
}
