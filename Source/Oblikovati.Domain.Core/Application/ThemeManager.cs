using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Core.Application;

public class ThemeManager : IThemeManager
{
    public ITheme ActiveTheme { get; set; }
    public IThemesEnumerator Themes { get; set; }
    public IColor GetComponentThemeColor(string ComponentName)
    {
        throw new NotImplementedException();
    }
}