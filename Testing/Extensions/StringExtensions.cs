using System;

namespace Testing.Extensions
{
    public static class StringExtensions
    {
        public static bool ContainsIgnoreCase(this string source, string toCheck) =>
            source?.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase) >= 0;
    }
}