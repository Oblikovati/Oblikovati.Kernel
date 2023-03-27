using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Core.AssetLibraries;

public class AssetLibrary : IAssetLibrary
{
    public AssetLibrary()
    {
        
    }
    
    public IAssetCategories AppearanceAssetCategories { get; set; }
    public IAssetsEnumerator AppearanceAssets { get; set; }
    public string DisplayName { get; set; }
    public string FullFileName { get; set; }
    public string InternalName { get; set; }
    public bool IsReadOnly { get; set; }
    public IAssetCategories MaterialAssetCategories { get; set; }
    public IAssetsEnumerator MaterialAssets { get; set; }
    public IAssetsEnumerator PhysicalAssets { get; set; }
    public void Remove()
    {
        throw new NotImplementedException();
    }
}