using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Application;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Documents;

public abstract class Document : IDocument
{
    protected Document(IApplicationBase parent)
    {
        
    }
    public IApplicationBase Parent { get; set; }
    public DocumentTypeEnum DocumentType { get; set; }
    public string DisplayName { get; set; }
    public bool DisplayNameOverridden { get; set; }
    public IFile File { get; set; }
    public string FullDocumentName { get; set; }
    public bool Open { get; set; }
    public IDocumentDescriptorsEnumerator ReferencedDocumentDescriptors { get; set; }
    public IDocumentsEnumerator ReferencedDocuments { get; set; }
    public IDocumentsEnumerator ReferencingDocuments { get; set; }
    public IDocumentsEnumerator AllReferencedDocuments { get; set; }
    public string FullFileName { get; set; }
    public IViews Views { get; set; }
    public IClientViews ClientViews { get; set; }
    public bool Dirty { get; set; }
    public bool Compacted { get; set; }
    public IDocumentEvents DocumentEvents { get; set; }
    public string DefaultCommand { get; set; }
    public IReferencedOpaqueFileDescriptors ReferencedOpaqueFileDescriptors { get; set; }
    public int FileSaveCounter { get; set; }
    public ISoftwareVersion SoftwareVersionCreated { get; set; }
    public ISoftwareVersion SoftwareVersionSaved { get; set; }
    public bool ReservedForWrite { get; set; }
    public bool ReservedForWriteByMe { get; set; }
    public string ReservedForWriteName { get; set; }
    public string ReservedForWriteLogin { get; set; }
    public int ReservedForWriteVersion { get; set; }
    public DateTime ReservedForWriteTime { get; set; }
    public bool IsModifiable { get; set; }
    public IPropertySets PropertySets { get; set; }
    public IAttributeManager AttributeManager { get; set; }
    public string InternalName { get; set; }
    public string RevisionId { get; set; }
    public string DatabaseRevisionId { get; set; }
    public string SubType { get; set; }
    public IUnitsOfMeasure UnitsOfMeasure { get; set; }
    public bool RequiresUpdate { get; set; }
    public object ActivatedObject { get; set; }
    public IPrintManager PrintManager { get; set; }
    public IGraphicsDataSetsCollection GraphicsDataSetsCollection { get; set; }
    public IRenderStyles RenderStyles { get; set; }
    public IBrowserPanes BrowserPanes { get; set; }
    public IReferenceKeyManager ReferenceKeyManager { get; set; }
    public ISelectSet SelectSet { get; set; }
    public ISelectionPreferences SelectionPreferences { get; set; }
    public CommandTypesEnum DisabledCommandTypes { get; set; }
    public IDocumentSubType DocumentSubType { get; set; }
    public CommandTypesEnum RecentChanges { get; set; }
    public SelectionPriorityEnum SelectionPriority { get; set; }
    public IDocumentInterests DocumentInterests { get; set; }
    public bool NeedsMigrating { get; set; }
    public ThumbnailSaveOptionEnum ThumbnailSaveOption { get; set; }
    public IAttributeSets AttributeSets { get; set; }
    public FileOwnershipEnum OwnershipType { get; set; }
    public IDocument OblikovatiDocument { get; set; }
    public IDocumentsEnumerator ReferencedFiles { get; set; }
    public IReferencedFileDescriptors ReferencedFileDescriptors { get; set; }
    public IHighlightSets HighlightSets { get; set; }
    public IGraphicsDataSetsCollection NonTransactingGraphicsDataSetsCollection { get; set; }
    public IClientGraphicsCollection NonTransactingClientGraphicsCollection { get; set; }
    public string ModelStateName { get; set; }
    public IPropertySets FilePropertySets { get; set; }
    public void GetLocationFoundIn(out string LocationName, out LocationTypeEnum LocationType)
    {
        throw new NotImplementedException();
    }

    public void Activate()
    {
        throw new NotImplementedException();
    }

    public void Close(bool SkipSave)
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        throw new NotImplementedException();
    }

    public void Save2(bool SaveDependents, object DocumentsToSave)
    {
        throw new NotImplementedException();
    }

    public void SaveAs(string FileName, bool SaveCopyAs)
    {
        throw new NotImplementedException();
    }

    public void SaveAsWithOptions(string FileName, INameValueMap Options)
    {
        throw new NotImplementedException();
    }

    public bool HasPrivateStorage(string StorageName)
    {
        throw new NotImplementedException();
    }

    public bool HasPrivateStream(string StreamName)
    {
        throw new NotImplementedException();
    }

    public object GetPrivateStorage(string StorageName, bool CreateIfNecessary)
    {
        throw new NotImplementedException();
    }

    public object GetPrivateStream(string StreamName, bool CreateIfNecessary)
    {
        throw new NotImplementedException();
    }

    public IDocumentsEnumerator FindWhereUsed(string FullFileName)
    {
        throw new NotImplementedException();
    }

    public void RevertReservedForWriteByMe()
    {
        throw new NotImplementedException();
    }

    public void PutInternalNameAndRevisionId(string InternalNameToken, string RevisionIdToken, out string InternalName,
        out string RevisionId)
    {
        throw new NotImplementedException();
    }

    public void Update()
    {
        throw new NotImplementedException();
    }

    public bool Update2(bool AcceptErrorsAndContinue)
    {
        throw new NotImplementedException();
    }

    public void Rebuild()
    {
        throw new NotImplementedException();
    }

    public bool Rebuild2(bool AcceptErrorsAndContinue)
    {
        throw new NotImplementedException();
    }

    public void SetMissingAddInBehavior(string ClientId, CommandTypesEnum DisabledCommandTypesEnum, object DisabledCommands)
    {
        throw new NotImplementedException();
    }

    public void GetMissingAddInBehavior(out string ClientId, out CommandTypesEnum DisabledCommandTypesEnum,
        out IObjectCollection DisabledCommands)
    {
        throw new NotImplementedException();
    }

    public IHighlightSet CreateHighlightSet()
    {
        throw new NotImplementedException();
    }

    public void Migrate()
    {
        throw new NotImplementedException();
    }

    public void ReleaseReference()
    {
        throw new NotImplementedException();
    }

    public void SetThumbnailSaveOption(ThumbnailSaveOptionEnum SaveOption, string ImageFullFileName)
    {
        throw new NotImplementedException();
    }

    public void _XmlOutToFile(string schemaXmlString, string outXmlFile)
    {
        throw new NotImplementedException();
    }

    public void LockSaveSet()
    {
        throw new NotImplementedException();
    }

    public void PutInternalName(string Name, string Number, string Custom, out string InternalName)
    {
        throw new NotImplementedException();
    }

    public void _PutInternalNameAndFileVersion(string Name, string Number, string Custom, string Revision, out string InternalName,
        out string FileVersion)
    {
        throw new NotImplementedException();
    }

    public void _DeleteUnusedEmbeddings(bool Preview, out int NumEmbeddings, ref List<string> Embeddings)
    {
        throw new NotImplementedException();
    }

    public bool isAssemblyDocument()
    {
        return this is IAssemblyDocument;
    }
}