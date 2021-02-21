namespace SmartSolutions.Guards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public static class GuardClauseExtensions
    {
        public static void Null(this IGuardClause guardClause, object input, string parameterName)
        {
            if (input is null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        public static void NullOrEmpty(this IGuardClause guardClause, string input, string parameterName)
        {
            Guard.Against.Null(input, parameterName);
            if (input.Length == 0)
            {
                throw new ArgumentException($"Required input `{parameterName}` is empty.", parameterName);
            }
        }

        public static void NullOrEmpty<T>(this IGuardClause guardClause, IEnumerable<T> input, string parameterName)
        {
            Guard.Against.Null(input, parameterName);
            if (!input.Any())
            {
                throw new ArgumentException($"Required input `{parameterName}` is empty.", parameterName);
            }
        }

        public static void NullOrWhiteSpace(this IGuardClause guardClause, string input, string parameterName)
        {
            Guard.Against.NullOrEmpty(input, parameterName);
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException($"Required input `{parameterName}` consists only of white-space characters.", parameterName);
            }
        }

        public static void NullOrAnySpace(this IGuardClause guardClause, string input, string parameterName)
        {
            Guard.Against.NullOrEmpty(input, parameterName);
            if (input.Contains(" "))
            {
                throw new ArgumentException($"Required input `{parameterName}` contains spaces.", parameterName);
            }
        }

        public static void IsEnumType(this IGuardClause guardClause, Type input, string parameterName)
        {
            Guard.Against.Null(input, parameterName);
            if (!input.IsEnum)
                throw new ArgumentException($"Type '{input.FullName}' must be a valid Enum type", parameterName);
        }

        public static void IsTrue(this IGuardClause guardClause, bool input, string parameterName)
        {
            if (!input)
                throw new ArgumentException($"True expected for '{parameterName}' but the condition is False.", parameterName);
        }

        public static void Zero<T>(this IGuardClause guardClause, T input, string parameterName) where T : struct, IComparable<T>
        {
            if (input.CompareTo(default(T)) == 0)
                throw new ArgumentException($"Required input {parameterName} cannot be zero.", parameterName);
        }

        public static void Negative<T>(this IGuardClause guardClause, T input, string parameterName) where T : struct, IComparable<T>
        {
            if (input.CompareTo(default(T)) < 0)
                throw new ArgumentException($"Required input {parameterName} cannot be negative.", parameterName);
        }

    }

}
