using FluentAssertions;
using Oblikovati.Domain.Contracts.Enums;
using Oblikovati.Domain.Core.Tests.Application;
using Xunit;

namespace Oblikovati.Domain.Core.Tests.DesignProjects;

public class CreateProjectTest
{
    [Fact]
    [Trait("Design Project","Design Project")]
    public void ShouldCreateProject()
    {
        var app = ApplicationTestSetup.ThisApplication();
        
        app.Documents.Count.Should().Be(0,"All documents must be closed before changing the project");
        
        app.DesignProjectManager.Should().NotBeNull();

        var proj = app.DesignProjectManager.DesignProjects
            .Add(MultiUserModeEnum.kSingleUserMode, "TestProject.opj", @"C:\Temp");

        app.DesignProjectManager.DesignProjects.Should().ContainSingle(p => p.FullFileName.Equals(proj.FullFileName));
    }
}