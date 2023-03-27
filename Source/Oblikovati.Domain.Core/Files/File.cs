using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.Files;
/// <summary>The File object represents file on disk.</summary>
public class File : IFile
{
    public File()
    {
        
    }
    
    public object AvailableDocuments { get; set; }
    public string FullFileName { get; set; }
    public IFileDescriptorsEnumerator ReferencedFileDescriptors { get; set; }
    public IFilesEnumerator ReferencedFiles { get; set; }
    public IFilesEnumerator ReferencingFiles { get; set; }
    public IFilesEnumerator AllReferencedFiles { get; set; }
    public string InternalName { get; set; }
    public int FileSaveCounter { get; set; }
    public FileOwnershipEnum OwnershipType { get; set; }
    public string RevisionId { get; set; }
    public string DatabaseRevisionId { get; set; }
    public bool HasLoadedDocuments { get; set; }
    public bool HasReferencingFiles { get; set; }
}