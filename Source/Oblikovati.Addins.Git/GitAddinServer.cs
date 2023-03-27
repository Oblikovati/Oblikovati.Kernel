
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Oblikovati.Domain.Core;
using Oblikovati.GeneralTools;

namespace Oblikovati.Addins.Git;

public class GitAddinServer : IApplicationAddInServer
{
    private IUserInterfaceEvents userInterfaceEvents;
    private GitButton _gitButton;
    public void Activate(IApplicationAddInSite AddInSiteObject, bool FirstTime)
    {
        Globals.InventorApplication = AddInSiteObject.Application;
        userInterfaceEvents = Globals.InventorApplication.UserInterfaceManager.UserInterfaceEvents;
        userInterfaceEvents.add_OnResetCommandBars(OnResetCommandBarsHandler);
        userInterfaceEvents.add_OnResetRibbonInterface(OnResetRibbonInterfaceHandler);

        var commandCategory = Globals.InventorApplication.CommandManager.CommandCategories
            .Add("General Tools", "Oblikovati:SourceControl:GitCmdCat", "");

        _gitButton = new GitButton("Git Source Control", 
                                    "Oblikovati:SourceControl:GitBtn",
                                    CommandTypesEnum.kNonShapeEditCmdType,
                                    "",
                                    "Open Git Source Control", 
                                    "Open Git Source Control");
        _gitButton.CreateButton();
        commandCategory.Add(_gitButton.Definition);
        MessageBox.Show("Git Active!");
        if(!FirstTime)
            return;
        this._gitButton.AddButtonToCommandBar("PartToolsMenu");
    }

    private void OnResetRibbonInterfaceHandler(INameValueMap context)
    {
        
    }

    private void OnResetCommandBarsHandler(IObjectsEnumerator commandbars, INameValueMap context)
    {
        try
        {
            foreach (ICommandBar commandBar in commandbars)
            {
                if (Operators.CompareString(commandBar.InternalName, "PartToolsMenu", false) == 0)
                    this._gitButton.AddButtonToCommandBar(commandBar);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    public void Deactivate()
    {
        Globals.InventorApplication.CommandManager.CommandCategories["Oblikovati:SourceControl:GitCmdCat"].Delete();

    }

    public void ExecuteCommand(int CommandID)
    {
        
    }

}