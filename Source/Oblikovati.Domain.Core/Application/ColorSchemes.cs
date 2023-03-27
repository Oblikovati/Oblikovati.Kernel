using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.Application;

public class ColorSchemes : List<IColorScheme>, IColorSchemes
{
    public ColorSchemes()
    {
        
    }
    
    public BackgroundTypeEnum BackgroundType { get; set; }
    public ApplicationFrameColorTypeEnum ApplicationFrameColor { get; set; }
    public IconsColorTypeEnum IconsColor { get; set; }
    public InterfaceStyleEnum InterfaceStyle { get; set; }
    public bool EnableEnhancedHighlighting { get; set; }
    public bool EnablePrehighlight { get; set; }
}