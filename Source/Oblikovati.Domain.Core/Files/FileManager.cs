using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.Files;

public class FileManager : IFileManager
{
    public FileManager()
    {
        
        Files = new FilesEnumerator();
        FileManagerEvents = new FileManagerEvents();
    }
    public IFileManagerEvents FileManagerEvents { get; }
    public IFilesEnumerator Files { get; protected set; }
    public object FileSystemObject { get; }
    public void DeleteFile(string FullFileName, FileManagementEnum FileManagementOption)
    {
        throw new NotImplementedException();
    }

    public void CopyFile(string SourceFullFileName, string DestinationFullFileName, FileManagementEnum FileManagementOption)
    {
        throw new NotImplementedException();
    }

    public void MoveFile(string SourceFullFileName, string DestinationFullFileName, FileManagementEnum FileManagementOption)
    {
        throw new NotImplementedException();
    }

    public string GetTemplateFile(DocumentTypeEnum DocumentType, SystemOfMeasureEnum SystemOfMeasure,
        DraftingStandardEnum DraftingStandard, object DocumentSubType)
    {
        throw new NotImplementedException();
    }

    public void GetIdentifierFromFileName(string FullFileName, ref List<byte> Identifier, string AbsolutePath)
    {
        throw new NotImplementedException();
    }

    public void GetFileNameFromIdentifier(ref List<byte> Identifier, out string FullFileName, string AbsolutePath)
    {
        throw new NotImplementedException();
    }

    public string GetFullDocumentName(string FullFileName, string ModelStateName)
    {
        throw new NotImplementedException();
    }

    public string GetLevelOfDetailName(string FullDocumentName)
    {
        throw new NotImplementedException();
    }

    public string GetFullFileName(string FullDocumentName)
    {
        throw new NotImplementedException();
    }

    public List<string> GetDesignViewRepresentations(string FullFileName)
    {
        throw new NotImplementedException();
    }

    public List<string> GetPositionalRepresentations(string FullFileName)
    {
        throw new NotImplementedException();
    }

    public List<string> GetLevelOfDetailRepresentations(string FullFileName)
    {
        throw new NotImplementedException();
    }

    public string GetLastActiveLevelOfDetailRepresentation(string FullFileName)
    {
        throw new NotImplementedException();
    }

    public bool IsFileNameValid(string FileName, out string ValidFileName)
    {
        throw new NotImplementedException();
    }

    public List<string> GetDWGDocumentReferences(object DocumentOrFileName)
    {
        throw new NotImplementedException();
    }

    public bool IsOblikovatiDWG(string FullFileName)
    {
        throw new NotImplementedException();
    }

    public void RefreshAllDocuments()
    {
        throw new NotImplementedException();
    }

    public string GetLastActiveDesignViewRepresentation(string FullFileName)
    {
        throw new NotImplementedException();
    }

    public ISoftwareVersion SoftwareVersionSaved(string FullFileName)
    {
        throw new NotImplementedException();
    }

    public List<string> GetAutoCADBlockDefinitions(string FullFileName)
    {
        throw new NotImplementedException();
    }

    public CachedGraphicsStatusEnum GetExpressGraphicsStatus(string AssemblyFullFilename)
    {
        throw new NotImplementedException();
    }

    public int ReferencedDocumentCount(string FullFileName)
    {
        throw new NotImplementedException();
    }

    public bool WillOpenExpressDefault(string FullFileName)
    {
        throw new NotImplementedException();
    }

    public bool CanCADFileBeAssociativelyImported(string FullFileName)
    {
        throw new NotImplementedException();
    }

    public bool IsOblikovatiComponent(string FullFileName)
    {
        throw new NotImplementedException();
    }

    public bool IsFutureCADFile(string FullFileName)
    {
        throw new NotImplementedException();
    }

    public void GetCADFileStructure(string FullFileName, string ResultXML)
    {
        throw new NotImplementedException();
    }

    public bool IsEmbeddedDocumentPath(string FullFileName)
    {
        throw new NotImplementedException();
    }

    public string GetEmbeddedDocumentShortName(string FullFileName)
    {
        throw new NotImplementedException();
    }

    public List<string> GetSHXFontList(object BigFont)
    {
        throw new NotImplementedException();
    }

    public List<string> GetModelStates(string FullFileName)
    {
        throw new NotImplementedException();
    }

    public string GetModelStateName(string FullDocumentName)
    {
        throw new NotImplementedException();
    }

    public string GetLastActiveModelState(string FullFileName)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}