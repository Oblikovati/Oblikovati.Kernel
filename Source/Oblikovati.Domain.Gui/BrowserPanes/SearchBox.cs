using Oblikovati.Domain.Core;


namespace Oblikovati.Domain.Gui.BrowserPanes;

public class SearchBox : SearchBoxControl, ISearchBox
{
    public SearchBox()
    {
        
    }
    public SearchBox(IApplicationBase application, IBrowserPane parent)
    {
        Application = application;
        Parent = parent;
        SearchBoxEvents = new SearchBoxEvents(application, this);
    }
    public IApplicationBase Application { get; set; }
    public IBrowserPane Parent { get; set; }
    public ISearchBoxEvents SearchBoxEvents { get; set; }
    public bool Enabled { get; set; }
    public SearchBoxFilterEnum SearchFilter { get; set; }
    public string SearchText { get; set; }
    public bool Visible { get; set; }
    public void Search(string SearchText, object SearchOptions)
    {
        throw new NotImplementedException();
    }
}