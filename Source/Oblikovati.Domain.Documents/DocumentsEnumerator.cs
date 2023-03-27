

using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Documents;

public class DocumentsEnumerator : List<IDocument>, IDocumentsEnumerator
{
    public IDocument this[string Index] => this.First(p => p.InternalName.Equals(Index));
}

