using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Core.Transient;

public class TransientObjects : ITransientObjects
{
    public ITranslationContext CreateTranslationContext()
    {
        throw new NotImplementedException();
    }

    public IDataMedium CreateDataMedium()
    {
        throw new NotImplementedException();
    }

    public INameValueMap CreateNameValueMap()
    {
        throw new NotImplementedException();
    }

    public IObjectCollection CreateObjectCollection(object ObjectsEnumerator)
    {
        throw new NotImplementedException();
    }

    public IObjectCollectionByVariant CreateObjectCollectionByVariant(object ObjectsEnumeratorByVariant)
    {
        throw new NotImplementedException();
    }

    public IEdgeCollection CreateEdgeCollection(object ObjectsEnumerator)
    {
        throw new NotImplementedException();
    }

    public IFaceCollection CreateFaceCollection(object ObjectsEnumerator)
    {
        throw new NotImplementedException();
    }

    public IColor CreateColor(byte Red, byte Green, byte Blue, double Opacity)
    {
        throw new NotImplementedException();
    }

    public string CreateSignatureString(string StringToSign)
    {
        throw new NotImplementedException();
    }

    public IFileMetadata CreateFileMetadata(object FullFileName)
    {
        throw new NotImplementedException();
    }

    public ICamera CreateCamera()
    {
        throw new NotImplementedException();
    }
}