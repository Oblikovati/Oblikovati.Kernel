using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.Ribbons;

public class Ribbons : List<IRibbon>, IRibbons
{
    public Ribbons(IApplication application)
    {
        Application = application;
    }
    public IApplication Application { get; set; }
}