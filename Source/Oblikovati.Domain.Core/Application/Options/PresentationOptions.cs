using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Core.Application.Options;

public class PresentationOptions : IPresentationOptions
{
    public PresentationOptions()
    {

    }

    public bool SkipAllUnresolvedFiles { get; set; }
}