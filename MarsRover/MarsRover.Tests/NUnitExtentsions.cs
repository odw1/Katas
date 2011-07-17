using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Rhino.Mocks;
using Rhino.Mocks.Exceptions;
using Rhino.Mocks.Interfaces;

namespace MarsRover.Tests
{
    public static class NUnitExtentsions
    {
        public static string AssertThat(this string value, object actual, IResolveConstraint expression)
        {
            Assert.That(actual, expression, value);

            return value;
        }

        public static string AssertWasCalled<T>(this string value, T objectUnderTest, Action<T> action)
        {
            objectUnderTest.AssertWasCalled(action);

            return value;
        }

        public static string AssertWasCalled<T>(this string value, T objectUnderTest, Action<T> action, Action<IMethodOptions<object>> setupConstraints)
        {
            objectUnderTest.AssertWasCalled(action, setupConstraints);

            return value;
        }

        public static string AssertWasCalled<T>(this string value, T objectUnderTest, Func<T, object> action)
        {
            objectUnderTest.AssertWasCalled(action);

            return value;
        }

        public static string AssertWasCalled<T>(this string value, T objectUnderTest, Func<T, object> action, Action<IMethodOptions<object>> setupConstraints)
        {
            objectUnderTest.AssertWasCalled(action, setupConstraints);

            return value;
        }

        public static string AssertThrows<T>(this string value, TestDelegate code) where T: Exception
        {
            Assert.Throws<T>(code);

            return value;
        }

    }
}
