using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.CommandManager;

public class ControlDefinitions : List<IControlDefinition>, IControlDefinitions
{
    public ControlDefinitions(IApplication application)
    {
        Application = application;
    }

    public IControlDefinition this[string Index] => this.First(p => p.InternalName.Equals(Index));
    public IApplication Application { get; set; }
    public bool UseDefaultMultiCharAliases { get; set; }

    public IButtonDefinition AddButtonDefinition(string DisplayName, string InternalName, CommandTypesEnum Classification,
        string ClientId, string DescriptionText, string ToolTipText, object StandardIcon, object LargeIcon,
        ButtonDisplayEnum ButtonDisplay)
    {
        var bd = new ButtonDefinition(Application, Application.CommandManager, DisplayName,InternalName)
        {
            Classification = Classification,
            ClientId = ClientId,
            DescriptionText = DescriptionText,
            ToolTipText = ToolTipText,
            Image = StandardIcon as Image,
        };
        this.Add(bd);
        return bd;
    }

    public IComboBoxDefinition AddComboBoxDefinition(string DisplayName, string InternalName, CommandTypesEnum Classification,
        int DropDownWidth, string ClientId, string DescriptionText, string ToolTipText, object StandardIcon,
        object LargeIcon, ButtonDisplayEnum ButtonDisplay)
    {
        return new ComboBoxDefinition(Application,Application.CommandManager);
    }

    public IMacroControlDefinition AddMacroControlDefinition(string MacroOrProgram)
    {
        throw new NotImplementedException();
    }
}