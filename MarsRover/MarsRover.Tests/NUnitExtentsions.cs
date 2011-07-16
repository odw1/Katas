using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace MarsRover.Tests
{
    public static class NUnitExtentsions
    {
        public static string AssertThat(this string value, object actual, IResolveConstraint expression)
        {
            Assert.That(actual, expression, value);

            return value;
        }
    }
}
