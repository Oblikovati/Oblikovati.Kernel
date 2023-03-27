using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Utility;

public class FileMetadata : IFileMetadata
{
    public string FullFileName { get; set; }
    public string FileName { get; set; }
    public bool FileNameOverridden { get; set; }
    public string DisplayName { get; set; }
    public bool DisplayNameOverridden { get; set; }
    public string FileProperties { get; set; }
    public IDocument Document { get; set; }
    public string TemplateFileName { get; set; }
    public BOMStructureEnum BOMStructure { get; set; }
}