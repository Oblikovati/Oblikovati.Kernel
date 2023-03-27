using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.Files;

public class FileLocations : IFileLocations
{
    public string Workspace { get; set; }
    public bool _WorkspaceActive { get; set; }
    public bool _LocalsActive { get; set; }
    public bool _WorkgroupsActive { get; set; }
    public string FileLocationsFilesDir { get; set; }
    public string FileLocationsFile { get; set; }
    public bool _CurrentSettingsDirty { get; }
    public bool _Dirty { get; }
    public string ContentCenterPath { get; set; }
    public string TemplatesPath { get; set; }
    public string DesignDataPath { get; set; }
    public string PresetsPath { get; set; }
    public void _Locals(out int NumLocals, ref List<string> Names, ref List<string> Paths)
    {
        throw new NotImplementedException();
    }

    public void _RemoveLocal(string Name)
    {
        throw new NotImplementedException();
    }

    public void _AddLocal(string Name, string Path, int Index)
    {
        throw new NotImplementedException();
    }

    public void Workgroups(out int NumWorkGroups, ref List<string> Names, ref List<string> Paths)
    {
        throw new NotImplementedException();
    }

    public void RemoveWorkgroup(string Name)
    {
        throw new NotImplementedException();
    }

    public void AddWorkgroup(string Name, string Path, int Index)
    {
        throw new NotImplementedException();
    }

    public void Libraries(out int NumLibraries, ref List<string> Names, ref List<string> Paths)
    {
        throw new NotImplementedException();
    }

    public void RemoveLibrary(string Name)
    {
        throw new NotImplementedException();
    }

    public void AddLibrary(string Name, string Path)
    {
        throw new NotImplementedException();
    }

    public string _GetLibraryVault(string LibraryName)
    {
        throw new NotImplementedException();
    }

    public void _SetLibraryVault(string LibraryName, string VaultPath)
    {
        throw new NotImplementedException();
    }

    public void _ApplyCurrentSettings()
    {
        throw new NotImplementedException();
    }

    public void _Save()
    {
        throw new NotImplementedException();
    }

    public void _SaveAs(string LocationsFile)
    {
        throw new NotImplementedException();
    }

    public void FindInLocations(string FullFileName, out string RepositoryName, out LocationTypeEnum Type)
    {
        throw new NotImplementedException();
    }

    public void FindLogicalInLocations(string RelativeFileName, string LibraryName, out string RepositoryName,
        out LocationTypeEnum Type)
    {
        throw new NotImplementedException();
    }

    public void ProjectFiles(out int NumProjectFiles, ref List<string> ProjectFileNamePaths)
    {
        throw new NotImplementedException();
    }

    public void GetVaultData(out string VaultServer, out string VaultName, out string VaultProject,
        out string StreamlineWatchFolder)
    {
        throw new NotImplementedException();
    }

    public void SetVaultData(string VaultServer, string VaultName, string VaultProject, string StreamlineWatchFolder)
    {
        throw new NotImplementedException();
    }
}