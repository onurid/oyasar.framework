using System.Text.RegularExpressions;

namespace OYASAR.Framework.EFProvider.NetCore.PostgreSQL.Extensions
{
    public static class SnakeCaseExtensions
    {
        public static string ToSnakeCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            var prefixingUnderscores = Regex.Match(input, "^_+");
            return prefixingUnderscores + Regex.Replace(input, "([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }
    }
}
