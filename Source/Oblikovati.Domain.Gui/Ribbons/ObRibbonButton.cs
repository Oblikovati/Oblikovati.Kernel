﻿using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.Ribbons;

public class ObRibbonButton : RibbonButton, IButtonDefinition
{
    public string InternalName { get; set; }
    public string DisplayName { get; set; }
    public IApplication Application { get; set; }
    public bool BuiltIn { get; set; }
    public CommandTypesEnum Classification { get; set; }
    public ICommandManager Parent { get; set; }
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
    public bool Pressed { get; set; }
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

    public void add_OnExecute(ButtonDefinitionSink_OnExecuteEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnExecute(ButtonDefinitionSink_OnExecuteEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void add_OnHelp(ButtonDefinitionSink_OnHelpEventHandler handler)
    {
        throw new NotImplementedException();
    }

    public void remove_OnHelp(ButtonDefinitionSink_OnHelpEventHandler handler)
    {
        throw new NotImplementedException();
    }
}