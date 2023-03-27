

using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Documents;

public class Documents : DocumentsEnumerator, IDocuments
{
    public Documents()
    {
        VisibleDocuments = new DocumentsEnumerator();
    }
    public IDocumentsEnumerator VisibleDocuments { get; protected set; }

    public int LoadedCount => Count;

    public IDocument Add(DocumentTypeEnum DocumentType, string TemplateFileName, bool CreateVisible)
    {
        throw new NotImplementedException();
    }

    public void CloseAll(bool UnreferencedOnly)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public IDocument Open(string FullDocumentName, bool OpenVisible)
    {
        throw new NotImplementedException();
    }

    public IDocument OpenWithOptions(string FullDocumentName, INameValueMap Options, bool OpenVisible)
    {
        throw new NotImplementedException();
    }
}

