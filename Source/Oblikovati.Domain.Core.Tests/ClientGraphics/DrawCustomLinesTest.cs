using FluentAssertions;
using Oblikovati.Domain.Core.Tests.Application;
using Xunit;

namespace Oblikovati.Domain.Core.Tests.ClientGraphics;

public class DrawCustomLinesTest
{
    [Fact]
    [Trait("ClientGraphics","ClientGraphics")]
    public void ShouldCreateProject()
    {
        var app = ApplicationTestSetup.ThisApplication();

        var actDoc = app.ActiveDocument;

        actDoc.Should().NotBeNull("A document must be active to proceed!");
    }
}