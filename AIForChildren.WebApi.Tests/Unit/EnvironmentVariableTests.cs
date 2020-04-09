using System;
using FluentAssertions;
using MusteriPaneli.WebApi.Helpers;
using Xunit;

namespace AIForChildren.WebApi.Tests.Unit
{
    public class EnvironmentVariableTests
    {
        [Fact]
        public void ConnectionStringMustBeInEnvironmentVariable()
        {
            var myCustomValue = "ABCDEFGH";
            Environment.SetEnvironmentVariable(Keys.ConnectionString, myCustomValue);
            var value = Environment.GetEnvironmentVariable(Keys.ConnectionString);
            value.Should().NotBeNullOrEmpty();
            value.Should().Be(myCustomValue);
        }
    }
}