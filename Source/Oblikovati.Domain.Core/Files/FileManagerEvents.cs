using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Delegates;

namespace Oblikovati.Domain.Core.Files;

public class FileManagerEvents : IFileManagerEvents
{
    public FileManagerEvents()
    {
        
        
        _onFileDeleteHandlers  = new List<FileManagerEventsSink_OnFileDeleteEventHandler>();
        OnFileDeleteHandlers = _onFileDeleteHandlers;
        _onFileCopyEventHandlers = new List<FileManagerEventsSink_OnFileCopyEventHandler>();
        OnFileCopyEventHandlers = _onFileCopyEventHandlers;

    }
    
    

    private readonly List<FileManagerEventsSink_OnFileDeleteEventHandler> _onFileDeleteHandlers;
    public IEnumerable<FileManagerEventsSink_OnFileDeleteEventHandler> OnFileDeleteHandlers { get; }
    private readonly List<FileManagerEventsSink_OnFileCopyEventHandler> _onFileCopyEventHandlers;
    public IEnumerable<FileManagerEventsSink_OnFileCopyEventHandler> OnFileCopyEventHandlers { get; }
    public void add_OnFileDelete(FileManagerEventsSink_OnFileDeleteEventHandler handler)
    {
        _onFileDeleteHandlers.Add(handler);
    }

    public void remove_OnFileDelete(FileManagerEventsSink_OnFileDeleteEventHandler handler)
    {
        _onFileDeleteHandlers.Remove(handler);
    }

    public void add_OnFileCopy(FileManagerEventsSink_OnFileCopyEventHandler handler)
    {
        _onFileCopyEventHandlers.Add(handler);
    }

    public void remove_OnFileCopy(FileManagerEventsSink_OnFileCopyEventHandler handler)
    {
        _onFileCopyEventHandlers.Remove(handler);
    }
}