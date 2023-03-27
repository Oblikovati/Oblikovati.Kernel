using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.CommandManager;

public class ComboBoxDefinition : ComboBox, IComboBoxDefinition
{
    public ComboBoxDefinition(IApplication application, ICommandManager commandManager)
    {
        Application = application;
        CommandManager = commandManager;
    }
    public string InternalName { get; set; }
    public string DisplayName { get; set; }
    public IApplication Application { get; set; }
    public bool BuiltIn { get; set; }
    public CommandTypesEnum Classification { get; set; }
    public ICommandManager CommandManager { get; set; }
    public ControlDefinitionTypeEnum DefinitionType { get; set; }
    public string DescriptionText { get; set; }
    public int Id { get; set; }
    public string ToolTipText { get; set; }
    public IControlDefinitionEvents ControlDefinitionEvents { get; set; }
    public string ClientId { get; set; }
    public string DefaultShortcut { get; set; }
    public ShortcutTypeEnum DefaultShortcutType { get; set; }
    public bool IsShortcutOverridden { get; set; }
    public string OverrideShortcut { get; set; }
    public ShortcutTypeEnum OverrideShortcutType { get; set; }
    public IProgressiveToolTip ProgressiveToolTip { get; set; }
    public string IntroducedInVersion { get; set; }
    public string LastUpdatedVersion { get; set; }
    public int ListCount { get; set; }
    public int ListIndex { get; set; }
    public string ListItem { get; set; }
    public string _ClassName { get; set; }

    ICommandManager IControlDefinition.Parent => throw new NotImplementedException();

    public void Delete()
    {
        throw new NotImplementedException();
    }

    public void AutoAddToGUI()
    {
        throw new NotImplementedException();
    }

    public void Execute()
    {
        throw new NotImplementedException();
    }

    public void Execute2(bool Synchronous)
    {
        throw new NotImplementedException();
    }

    public void AddItem(string Item, int Index)
    {
        throw new NotImplementedException();
    }

    public void RemoveItem(int Index)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    private List<ComboBoxDefinitionSink_OnSelectEventHandler> BoxDefinitionSinkOnSelectEventHandlers = new();
    public void add_OnSelect(ComboBoxDefinitionSink_OnSelectEventHandler handler)
    {
        BoxDefinitionSinkOnSelectEventHandlers.Add(handler);
    }

    public void remove_OnSelect(ComboBoxDefinitionSink_OnSelectEventHandler handler)
    {
        BoxDefinitionSinkOnSelectEventHandlers.Remove(handler);
    }
    private readonly List<ComboBoxDefinitionSink_OnHelpEventHandler> BoxDefinitionSinkOnHelpEventHandlers = new();
    public void add_OnHelp(ComboBoxDefinitionSink_OnHelpEventHandler handler)
    {
        BoxDefinitionSinkOnHelpEventHandlers.Add(handler);
    }

    public void remove_OnHelp(ComboBoxDefinitionSink_OnHelpEventHandler handler)
    {
        BoxDefinitionSinkOnHelpEventHandlers.Remove(handler);
    }
}