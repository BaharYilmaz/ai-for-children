using System;
using System.Collections.Generic;
using AIForChildren.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AIForChildren.WebApi.Tests.Unit.ControllerTests
{
    public class HomeControllerTest
    {
        [Fact]
        public void GetShouldReturnString()
        {
            var controller = new HomeController();
            var result = controller.Get();
            result.Should().BeOfType<ActionResult<IEnumerable<string>>>();
        }
    }
}