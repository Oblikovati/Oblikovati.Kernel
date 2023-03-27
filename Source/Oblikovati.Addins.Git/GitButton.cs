using Oblikovati.Domain.Core;
using Oblikovati.GeneralTools;

namespace Oblikovati.Addins.Git;

public class GitButton : Button
{
    public GitButton(
        string DisplayName,
        string InternalName,
        CommandTypesEnum CommandTypesEnum,
        string ClientId,
        string Description = null,
        string ToolTip = null,
        string StandardIconName = null,
        string LargeIconName = null,
        ButtonDisplayEnum ButtonDisplayType = ButtonDisplayEnum.kDisplayTextInLearningMode)
        : base(DisplayName, InternalName, CommandTypesEnum, ClientId, Description, ToolTip, StandardIconName, LargeIconName, ButtonDisplayType)
    {
        Command = new GitBtnCmd();
    }
    protected override void OnButtonExecute(INameValueMap context)
    {
        Command.ButtonDefinitionEvents_OnExecute(context);
    }
}