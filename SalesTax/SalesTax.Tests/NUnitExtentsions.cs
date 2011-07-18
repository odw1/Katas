using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Rhino.Mocks;

namespace SalesTax.Tests
{
    public static class NUnitExtentsions
    {
        public static void AssertThat(this string value, object actual, IResolveConstraint expression)
        {
            Assert.That(actual, expression, value);
        }

        public static void AssertWasCalled<T>(this string value, T objectUnderTest, Func<T, object> action)
        {
            objectUnderTest.AssertWasCalled(action);
        }

        public static void AssertThrows<T>(this string value, TestDelegate code) where T : Exception
        {
            Assert.Throws<T>(code);
        }

    }
}
