using System;
using FluentAssertions;
using MusteriPaneli.WebApi.Helpers;
using Xunit;

namespace AIForChildren.WebApi.Tests.Unit
{
    public class KeysTest
    {
        [Fact]
        public void ConnectionStringKeyMustEqual()
        {
            Keys.ConnectionString.Should().Be("AIFORCHILDREN_CONNECTIONSTRING");
        }
    }
}