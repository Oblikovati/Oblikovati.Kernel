using System.Runtime.Serialization;

namespace Oblikovati.Addin.Tutorials;

[DataContract]
public class GallerySettingsData
{
    [DataMember(Name = "type")]
    public List<int> Type { get; set; }

    [DataMember(Name = "skillLevel")]
    public List<int> SkillLevel { get; set; }

    [DataMember(Name = "topics")]
    public List<string> Topics { get; set; }

    [DataMember(Name = "language")]
    public List<GalleryLanguageData> Language { get; set; }

    [DataMember(Name = "resultsPerPage")]
    public uint ResultsPerPage { get; set; }

    [DataMember(Name = "sortBy")]
    public string SortBy { get; set; }

    [DataMember(Name = "viewType")]
    public string ViewType { get; set; }
}