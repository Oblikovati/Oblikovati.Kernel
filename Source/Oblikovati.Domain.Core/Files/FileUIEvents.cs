using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Delegates;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.Files;

public class FileUIEvents : IFileUIEvents
{
    public void PopulateFileMetadata(
        IObjectCollection FileMetadataObjects, 
        string Formulae, 
        INameValueMap Context,
        out HandlingCodeEnum HandlingCode)
    {
        throw new NotImplementedException();
    }

    public void add_OnFileNewDialog(FileUIEventsSink_OnFileNewDialogEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnFileNewDialog(FileUIEventsSink_OnFileNewDialogEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnFileOpenDialog(FileUIEventsSink_OnFileOpenDialogEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnFileOpenDialog(FileUIEventsSink_OnFileOpenDialogEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnFileSaveAsDialog(FileUIEventsSink_OnFileSaveAsDialogEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnFileSaveAsDialog(FileUIEventsSink_OnFileSaveAsDialogEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnFileInsertNewDialog(FileUIEventsSink_OnFileInsertNewDialogEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnFileInsertNewDialog(FileUIEventsSink_OnFileInsertNewDialogEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnFileInsertDialog(FileUIEventsSink_OnFileInsertDialogEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnFileInsertDialog(FileUIEventsSink_OnFileInsertDialogEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnFileOpenFromMRU(FileUIEventsSink_OnFileOpenFromMRUEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnFileOpenFromMRU(FileUIEventsSink_OnFileOpenFromMRUEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnFileNew(FileUIEventsSink_OnFileNewEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnFileNew(FileUIEventsSink_OnFileNewEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnPopulateFileMetadata(FileUIEventsSink_OnPopulateFileMetadataEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnPopulateFileMetadata(FileUIEventsSink_OnPopulateFileMetadataEventHandler handler)
    {
        throw new NotImplementedException();
    }
}