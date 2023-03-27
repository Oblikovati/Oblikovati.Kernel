using System.Runtime.Serialization.Json;
using System.Text;

namespace Oblikovati.Addin.Tutorials;

public static class JsonParser
{
    public static T Parse<T>(string jsonString)
    {
        using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            return (T) new DataContractJsonSerializer(typeof (T), new DataContractJsonSerializerSettings()
            {
                UseSimpleDictionaryFormat = true
            }).ReadObject((Stream) memoryStream);
    }

    public static string Stringify(object jsonObject)
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            new DataContractJsonSerializer(jsonObject.GetType()).WriteObject((Stream) memoryStream, jsonObject);
            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }
    }
}