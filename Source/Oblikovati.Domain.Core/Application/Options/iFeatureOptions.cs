using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Core.Application.Options;

public class iFeatureOptions : IiFeatureOptions
{
    public iFeatureOptions()
    {

    }

    public string RootPath { get; set; }
    public string UserRootPath { get; set; }
    public string SheetMetalPunchesRootPath { get; set; }
    public string Viewer { get; set; }
    public string ViewerArguments { get; set; }
    public bool UseKey1AsBrowserNameColumn { get; set; }
}