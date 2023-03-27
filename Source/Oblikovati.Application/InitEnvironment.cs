using Environment = Oblikovati.Domain.Core.Environments.Environment;

namespace Oblikovati.Application;

internal class InitEnvironment : Environment
{
    public InitEnvironment()
    {
        DisplayName = "Init";
        InternalName = "EnvInit";
        DefaultRibbonTab = "EnvInit_GetStartedTab";
        AdditionalVisibleRibbonTabs.Add("Tools");
        InheritAllRibbonTabs = false;
        CreateRibbon();
    }

    private void CreateRibbon()
    {

    }
}