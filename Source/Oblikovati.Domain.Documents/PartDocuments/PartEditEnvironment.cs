using Oblikovati.Domain.Core;
using Environment = Oblikovati.Domain.Core.Environments.Environment;

namespace Oblikovati.Domain.Documents.PartDocuments;

public class PartEditEnvironment : Environment
{
    public PartEditEnvironment()
    {
        DisplayName = "Part Edit Environment";
        InternalName = "PartEditEnvironment";
    }
}