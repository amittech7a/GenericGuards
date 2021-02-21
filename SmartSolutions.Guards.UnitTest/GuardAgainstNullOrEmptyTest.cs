namespace SmartSolutions.Guards.UnitTest
{
    using System;
    using Xunit;
    public class GuardAgainstNullOrEmptyTest
    {
        [Fact]
        public void DoesNotThrowGivenNonEmptyString()
        {
            Guard.Against.NullOrEmpty("Amit", "string");
        }

        [Fact]
        public void DoesNotThrowGivenNonEmptyEnumerable()
        {
            Guard.Against.NullOrEmpty(new[] { 1, 2 }, "array");
        }

        [Fact]
        public void ThrowsGivenEmptyString()
        {
            Assert.Throws<ArgumentException>(() => Guard.Against.NullOrEmpty("", "emptyString"));
        }

        [Fact]
        public void ThrowNullValue()
        {
            Assert.Throws<ArgumentException>(() => Guard.Against.NullOrEmpty(null, "null"));
        }
    }

}
