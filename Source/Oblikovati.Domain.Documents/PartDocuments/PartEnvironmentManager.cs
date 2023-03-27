using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Core.Environments;

namespace Oblikovati.Domain.Documents.PartDocuments;

public class PartEnvironmentManager : EnvironmentManager
{
    public PartEnvironmentManager(IDocument document)
    {
        
        Parent = document;
      
    }
}