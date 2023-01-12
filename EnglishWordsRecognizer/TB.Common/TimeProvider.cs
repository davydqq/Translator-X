namespace TB.Common;

public static class TimeProvider
{
    public static DateTimeOffset Get() => DateTimeOffset.UtcNow;
}
