namespace SmartSolutions.Guards.UnitTest
{
    using System;
    using Xunit;
    public class GuardAgainstNullTest
    {
        [Fact]
        public void ThrowNullValue()
        {
            Assert.Throws<ArgumentException>(() => Guard.Against.Null(null, "null"));
        }

        [Fact]
        public void DoesNotThrowNonNullValue()
        {
            Guard.Against.Null("", "string");            
            Guard.Against.Null(1, "int");
            Guard.Against.Null(Guid.Empty, "guid");
            Guard.Against.Null(DateTime.Now, "datetime");
            Guard.Against.Null(new object(), "object");
        }
    }
}
