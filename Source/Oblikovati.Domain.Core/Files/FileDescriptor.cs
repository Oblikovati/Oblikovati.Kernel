using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.Files;

public class FileDescriptor : IFileDescriptor
{
    public FileDescriptor(IFile parent)
    {
        
        
    }
    public IFile Parent { get;  }
    public string FullFileName { get; set; }
    public string RelativeFileName { get; set; }
    public LocationTypeEnum LocationType { get; set; }
    public string LibraryName { get; set; }
    public IFile ReferencedFile { get; set; }
    public FileTypeEnum ReferencedFileType { get; set; }
    public int FileSaveCounter { get; set; }
    public bool ReferenceMissing { get; set; }
    public bool ReferenceDisabled { get; set; }
    public bool ReferenceInternalNameDifferent { get; set; }
    public bool ReferenceLocationDifferent { get; set; }
    public string ResolvedFullFileName { get; set; }
    public FileOwnershipEnum OwnershipType { get; set; }
    public string ReferencedFileInternalName { get; set; }
    public bool ReferenceReplaced { get; set; }
    public List<byte> GetCustomLogicalFileName()
    {
        throw new NotImplementedException();
    }

    public void PutCustomLogicalFileName(List<byte> Value)
    {
        throw new NotImplementedException();
    }

    public void ReplaceReference(string FullFileName)
    {
        throw new NotImplementedException();
    }
}