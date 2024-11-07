namespace Core.Extensions
{
    public static class EnumExtensions
    {
        public static string ToFullString(this Enum value)
        {
            return $"{value.GetType().Name}.{value}";
        }
    }
}
