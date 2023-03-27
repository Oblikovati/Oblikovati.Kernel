using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.Views;
/// <summary>
/// The Views collection object provides access to all of the graphic objects associated with a particular document.
/// It also provides functionality to create new views.
/// </summary>
public class Views : List<IView>, IViews
{
    public Views(IApplicationBase application)
    {
        Application = application;
    }
    public IApplicationBase Application { get; }

    public IView Add()
    {
        var v = new View(Application);
        Add(v);
        return v;
    }
}