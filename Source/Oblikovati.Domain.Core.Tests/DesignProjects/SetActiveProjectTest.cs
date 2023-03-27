using FluentAssertions;
using Oblikovati.Domain.Core.Tests.Application;
using Xunit;

namespace Oblikovati.Domain.Core.Tests.DesignProjects;

public class SetActiveProjectTest
{
    [Fact]
    [Trait("Design Project","Design Project")]
    public void ShouldSetActiveProject()
    {
        var app = ApplicationTestSetup.ThisApplication();
        
        app.Documents.Count.Should().Be(0,"All documents must be closed before changing the project");
        
        app.DesignProjectManager.Should().NotBeNull();

        var proj = app.DesignProjectManager.DesignProjects[@"C:\Temp\TestProject.opj"];

        proj.Should().NotBeNull("The project should be selected");

        proj.Activate(true);

        app.DesignProjectManager.ActiveDesignProject.Should().Be(proj);
    }

}