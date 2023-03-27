using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Utility;

public class TransientObjects : ITransientObjects
{
    public ITranslationContext CreateTranslationContext()
    {
        return new TranslationContext();
    }

    public IDataMedium CreateDataMedium()
    {
        return new DataMedium();
    }

    public INameValueMap CreateNameValueMap()
    {
        return new NameValueMap();
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
        return new Color()
        {
            Blue = Blue,
            Red = Red,
            Green = Green,
            Opacity = Opacity
        };
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
        return new Camera(this);
    }
}