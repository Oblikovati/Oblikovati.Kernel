using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Core.Styles;

public class StylesManager : IStylesManager
{
    public StylesManager()
    {
        
        
    }

    public IMaterialsEnumerator Materials { get; set; }
    public void GetStyleNameFromKey(ref List<byte> ReferenceKey, out string InternalName, out string DisplayName)
    {
        throw new NotImplementedException();
    }
}