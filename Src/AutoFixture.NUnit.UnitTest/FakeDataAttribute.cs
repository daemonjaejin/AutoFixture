﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Ploeh.AutoFixture.NUnit.UnitTest
{
    public class FakeDataAttribute : DataAttribute
    {
        private readonly MethodInfo expectedMethod;
        private readonly Type[] expectedTypes;
        private readonly IEnumerable<object[]> output;

        public FakeDataAttribute(MethodInfo expectedMethod, 
            Type[] expectedTypes, IEnumerable<object[]> output)
        {
            this.expectedMethod = expectedMethod;
            this.expectedTypes = expectedTypes;
            this.output = output;
        }

        public override IEnumerable<object[]> GetData(MethodInfo method, Type[] parameterTypes)
        {
            Assert.Equal(this.expectedMethod, method);
            Assert.True(this.expectedTypes.SequenceEqual(parameterTypes));

            return this.output;
        }
    }
}