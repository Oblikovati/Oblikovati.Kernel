using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.Application.Options;

public class FileOptions : IFileOptions
{
    public string ProjectsPath { get; set; }
    public string TeamWebFullFilename { get; set; }
    public string TemplatesPath { get; set; }
    public string UndoPath { get; set; }
    public string DesignDataPath { get; set; }
    public string ContentCenterPath { get; set; }
    public IFileOpenOptions FileOpenOptions { get; set; }
    public bool QuickFileOpenEnabled { get; set; }
    public bool QuickFileOpenCacheLastAssembly { get; set; }
    public string QuickFileOpenCachedAssembly { get; set; }
    public bool DefaultTemplateUnitsAreInches { get; set; }
    public DraftingStandardEnum DefaultTemplateDrawingStandard { get; set; }
    public string SymbolLibraryPath { get; set; }
    public string TexturePath { get; set; }
    public string PresetsPath { get; set; }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}