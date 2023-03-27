namespace Oblikovati.Addin.Tutorials;

internal class GallerySettingsFile
{
    private const string filename = "TutorialGallerySettings.json";

    public static GallerySettings Default()
    {
        GallerySettingsData gallerySettingsData = new GallerySettingsData();
        gallerySettingsData.Type = new List<int>();
        gallerySettingsData.SkillLevel = new List<int>();
        gallerySettingsData.Topics = new List<string>();
        gallerySettingsData.Language = new List<GalleryLanguageData>();
        gallerySettingsData.ResultsPerPage = 12U;
        gallerySettingsData.SortBy = "Most Recent";
        gallerySettingsData.ViewType = "block";
        GallerySettings gallerySettings = new GallerySettings();
        gallerySettings.LwsEvent = "GallerySettings";
        gallerySettings.Data = gallerySettingsData;
        return gallerySettings;
    }

    private static string FilePath() => Path.Combine(FrameworkUtils.InventorRoamingFolder(InteractiveTutorialServer.Instance.InventorApplication), "TutorialGallerySettings.json");

    public static void Save(string text) => File.WriteAllText(GallerySettingsFile.FilePath(), text);

    public static GallerySettings Read()
    {
        try
        {
            if (File.Exists(GallerySettingsFile.FilePath()))
                return JsonParser.Parse<GallerySettings>(File.ReadAllLines(GallerySettingsFile.FilePath())[0]);
        }
        catch (Exception ex)
        {
            int num = (int) MessageBox.Show(ex.ToString());
        }
        return GallerySettingsFile.Default();
    }
}