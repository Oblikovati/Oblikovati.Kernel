using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Core.AssetLibraries;

public class AssetLibraries : List<IAssetLibrary>, IAssetLibraries
{
    public AssetLibraries()
    {
        
    }
    
    public IAssetLibrary Add(string FullFileName)
    {
        throw new NotImplementedException();
    }

    public IAssetLibrary Open(string FullFileName)
    {
        throw new NotImplementedException();
    }

    public void MigrateOblikovatiStyle(string OblikovatiLibraryPath, bool ImportMaterialStyles, string TargetLibrary)
    {
        throw new NotImplementedException();
    }
}