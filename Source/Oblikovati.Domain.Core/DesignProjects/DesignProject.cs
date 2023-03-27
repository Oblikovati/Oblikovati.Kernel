using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.DesignProjects;

public class DesignProject : IDesignProject
{
    public DesignProject()
    {
        
    }
    public string FullFileName { get; set; }
    public IContentCenterConfiguration ContentCenterConfiguration { get; set; }
    public StylesLibraryAccessEnum StylesLibraryAccess { get; set; }
    public IIntentConfiguration IntentConfiguration { get; set; }
    public string ContentCenterPath { get; set; }
    public bool ContentCenterPathOverridden { get; set; }
    public DateTime CreationTime { get; set; }
    public string DesignDataPath { get; set; }
    public bool DesignDataPathOverridden { get; set; }
    public IProjectPaths FrequentlyUsedPaths { get; set; }
    public string ImportedComponentsFolderName { get; set; }
    public string ImportedTopLevelAssembliesFolderName { get; set; }
    public string IncludedProject { get; set; }
    public IProjectPaths LibraryPaths { get; set; }
    public string Name { get; set; }
    public int OldVersionsToKeep { get; set; }
    public string Owner { get; set; }
    public IDesignProjectManager Parent { get; set; }
    public MultiUserModeEnum ProjectType { get; set; }
    public string ReleaseId { get; set; }
    public object Shortcuts { get; set; }
    public string TemplatesPath { get; set; }
    public bool TemplatesPathOverridden { get; set; }
    public bool UsingUniqueFileNames { get; set; }
    public string VaultName { get; set; }
    public string VaultPublishPath { get; set; }
    public string VaultServer { get; set; }
    public string VaultVirtualPath { get; set; }
    public IProjectPaths WorkgroupPaths { get; set; }
    public string WorkspacePath { get; set; }
    public IProjectAssetLibrary ActiveAppearanceLibrary { get; set; }
    public IProjectAssetLibrary ActiveMaterialLibrary { get; set; }
    public IProjectAssetLibraries AppearanceLibraries { get; set; }
    public IProjectAssetLibraries MaterialLibraries { get; set; }
    public string PresetsPath { get; set; }
    public bool PresetsPathOverridden { get; set; }
    public void Save()
    {
        throw new NotImplementedException();
    }

    public string GetCustomSection(string Name)
    {
        throw new NotImplementedException();
    }

    public string GetIncludedCustomSection(string Name)
    {
        throw new NotImplementedException();
    }

    public void Remove()
    {
        throw new NotImplementedException();
    }

    public void SetCustomSection(string Name, string CustomSection)
    {
        throw new NotImplementedException();
    }

    public void Activate(bool SetAsDefaultProject)
    {
       // ((Application as IApplication).DesignProjectManager as DesignProjectManager).ActiveDesignProject = this;
    }
}