namespace Oblikovati.Addin.Tutorials;

public class TutorialsData
{
    public const string EventId = "{4d9c80fe-e70f-4c29-b6c7-8a5ac3f40eb2}";
    public const string ClientId = "{4d9c80fe-e70f-4c29-b6c7-8a5ac3f40eb2}";
    public const string InternalPlaybackName = "tutorialplaybackdockablewindow";
    public const string CommandMarkerKey = "CmdID";
    public const string GraphicsSceneMarkerKey = "IndicatorAttrName";
    public const string ModelBrowserMarkerKey = "ModelBrowserNodeName";

    public static string TutorialFolder() => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\TutorialData";

    public static string StandardAssemblyFile() => TutorialsData.TutorialFolder() + "\\Standard.iam";
}