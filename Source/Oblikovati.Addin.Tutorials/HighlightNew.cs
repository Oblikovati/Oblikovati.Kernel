using Oblikovati.Domain.Core;

namespace Oblikovati.Addin.Tutorials;

internal static class HighlightNew
{
    private static IEnumerable<InteractiveTutorialCmdUpdateInfo> _InteractiveTutorialCmdUpdateInfos;

    private static IEnumerable<InteractiveTutorialCmdUpdateInfo> InteractiveTutorialCmdUpdateInfos()
    {
        if (HighlightNew._InteractiveTutorialCmdUpdateInfos == null)
        {
            try
            {
                //TODO: this
                //if (System.Windows.Application.LoadComponent(new Uri("/InteractiveTutorial;component/Resources/HighlightNew/InteractiveTutorialCmdUpdateInfos.xaml", UriKind.RelativeOrAbsolute)) is ResourceDictionary resourceDictionary)
                //    HighlightNew._InteractiveTutorialCmdUpdateInfos = resourceDictionary[(object) nameof (InteractiveTutorialCmdUpdateInfos)] as IEnumerable<InteractiveTutorialCmdUpdateInfo>;
            }
            catch (Exception ex)
            {
            }
        }
        return HighlightNew._InteractiveTutorialCmdUpdateInfos;
    }

    public static void SetupControl(ICommandControl control)
    {
        if (HighlightNew.InteractiveTutorialCmdUpdateInfos() == null)
            return;
        InteractiveTutorialCmdUpdateInfo tutorialCmdUpdateInfo = HighlightNew.InteractiveTutorialCmdUpdateInfos().Where<InteractiveTutorialCmdUpdateInfo>((Func<InteractiveTutorialCmdUpdateInfo, bool>) (x => x.InternalName == control.InternalName)).SingleOrDefault<InteractiveTutorialCmdUpdateInfo>();
        if (tutorialCmdUpdateInfo == null)
            return;
        if (!string.IsNullOrEmpty(tutorialCmdUpdateInfo.CreatedVersion))
            control.ControlDefinition.IntroducedInVersion = tutorialCmdUpdateInfo.CreatedVersion;
        if (string.IsNullOrEmpty(tutorialCmdUpdateInfo.UpdatedVersion))
            return;
        control.ControlDefinition.LastUpdatedVersion = tutorialCmdUpdateInfo.UpdatedVersion;
    }

    public static void Refresh(IApplication app) => app.RefreshRibbonForComparison();
}