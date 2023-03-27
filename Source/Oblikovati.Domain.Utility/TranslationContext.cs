using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Utility;

public class TranslationContext : ITranslationContext
{
    public IOMechanismEnum Type { get; set; }
    public object OpenIntoExisting { get; set; }
}