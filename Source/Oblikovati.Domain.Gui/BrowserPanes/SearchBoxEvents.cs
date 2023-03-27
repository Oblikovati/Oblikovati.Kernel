using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.BrowserPanes;

public class SearchBoxEvents : ISearchBoxEvents
{
    public SearchBoxEvents(IApplicationBase application, ISearchBox parent)
    {
        Application = application;
        Parent = parent;
    }
    public ISearchBox Parent { get; set; }
    public IApplicationBase Application { get; set; }
    public void add_OnStartSearch(SearchBoxEventsSink_OnStartSearchEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnStartSearch(SearchBoxEventsSink_OnStartSearchEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnEndSearch(SearchBoxEventsSink_OnEndSearchEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnEndSearch(SearchBoxEventsSink_OnEndSearchEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnStopSearch(SearchBoxEventsSink_OnStopSearchEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnStopSearch(SearchBoxEventsSink_OnStopSearchEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnClearSearch(SearchBoxEventsSink_OnClearSearchEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnClearSearch(SearchBoxEventsSink_OnClearSearchEventHandler handler)
    {
        throw new NotImplementedException();
    }
}