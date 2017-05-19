using System;
using System.Collections.Generic;
using FluentAssertions;
using NovaPoshta.Json;
using NUnit.Framework;

namespace NovaPoshta.UnitTests
{
    public class NovaPoshtaConfigTests
    {
        [Test]
        [TestCaseSource(nameof(CtorParameters))]
        public void Test_When_Any_Of_Ctor_Params_Is_Null_Then_Throw_Exception(string apiKey, Uri apiUrl)
        {
            ((Action)(() => new NovaPoshtaConfig(apiKey, apiUrl))).ShouldThrowExactly<ArgumentNullException>();
        }

        public static IEnumerable<TestCaseData> CtorParameters
        {
            get
            {
                yield return new TestCaseData("", null);
                yield return new TestCaseData(null, new Uri("http://google.com"));
            }
        }
    }
}
