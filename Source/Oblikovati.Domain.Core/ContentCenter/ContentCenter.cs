using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.ContentCenter;

public class ContentCenter : IContentCenter
{
    public IContentQuery Query { get; set; }
    public string Language { get; set; }
    public ICategoryManager CategoryManager { get; set; }
    public IFamilyManager FamilyManager { get; set; }
    public IMemberManager MemberManager { get; set; }
    public IQueryManager QueryManager { get; set; }
    public ILibraryManager LibraryManager { get; set; }
    public IContentCenterEvents ContentCenterEvents { get; set; }
    public IContentTreeViewNode TreeViewTopNode { get; set; }
    public void Refresh(bool Full)
    {
        throw new NotImplementedException();
    }

    public bool ContentCenterControlled(object Document)
    {
        throw new NotImplementedException();
    }

    public string GetMoniker(object Document)
    {
        throw new NotImplementedException();
    }

    public IContentCenterDialog CreateContentCenterDialog()
    {
        throw new NotImplementedException();
    }

    public object GetTableOfContents(GeneralDataTypeEnum ReturnAs, string LibraryId)
    {
        throw new NotImplementedException();
    }

    public void ForceRefreshCache()
    {
        throw new NotImplementedException();
    }

    public object GetOutOfDateParts(I_AssemblyDocument Document,bool Recursive)
    {
        throw new NotImplementedException();
    }

    public bool RefreshStandardComponents(I_AssemblyDocument Document,bool Recursive, object Settings,
        object AssemblyRefreshInfo)
    {
        throw new NotImplementedException();
    }

    public object GetContentObject(string ContentIdentifier, string LibraryId)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}