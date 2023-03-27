using Oblikovati.Domain.Core;
using Environment = Oblikovati.Domain.Core.Environments.Environment;

namespace Oblikovati.Domain.Documents.PartDocuments;

public class PartEnvironment : Environment
{
    public PartEnvironment() 
    {
        DisplayName = "Part Environment";
        InternalName = "PartEnvironment";
    }
}