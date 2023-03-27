using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.CommandManager;

public class CommandManager : ICommandManager
{
    public CommandManager(IApplication parent)
    {
        Parent = parent;
        CommandCategories = new CommandCategories(parent,this);
        ControlDefinitions = new ControlDefinitions(Parent);
    }
    public IApplication Parent { get; set; }
    public bool CommandEnabled { get; set; }
    public CommandIDEnum _ActiveCommand { get; set; }
    public string ActiveCommand { get; set; }
    public bool SelectionActive { get; set; }
    public IUserInputEvents UserInputEvents { get; set; }
    public ICommandCategories CommandCategories { get; set; }
    public IControlDefinitions ControlDefinitions { get; set; }
    public void StartCommand(CommandIDEnum BuiltInCommandId)
    {
        throw new NotImplementedException();
    }

    public void StopActiveCommand()
    {
        throw new NotImplementedException();
    }

    public void StopAllActiveCommands()
    {
        throw new NotImplementedException();
    }

    public void StartExecutable(string ExecutableName, string Parameters)
    {
        throw new NotImplementedException();
    }

    public void PeekPrivateEvent(out PrivateEventTypeEnum DataType, out object Data)
    {
        throw new NotImplementedException();
    }

    public void PostPrivateEvent(PrivateEventTypeEnum DataType, object Data)
    {
        throw new NotImplementedException();
    }

    public void ClearPrivateEvents()
    {
        throw new NotImplementedException();
    }

    public void _PostPrivateEvent(string Tag, object Data)
    {
        throw new NotImplementedException();
    }

    public IInteractionEvents CreateInteractionEvents()
    {
        throw new NotImplementedException();
    }

    public void DoPreSelect(object Entity)
    {
        throw new NotImplementedException();
    }

    public void DoStopPreSelect(object Entity)
    {
        throw new NotImplementedException();
    }

    public void DoSelect(object Entity)
    {
        throw new NotImplementedException();
    }

    public void DoUnSelect(object Entity)
    {
        throw new NotImplementedException();
    }

    public int PromptMessage(string Prompt, int Buttons, object Title, object DefaultAnswer, object Restrictions,
        object PromptStrings)
    {
        throw new NotImplementedException();
    }

    public object Pick(SelectionFilterEnum Filter, string PromptText)
    {
        throw new NotImplementedException();
    }

    public IDragContext CreateDragContext()
    {
        throw new NotImplementedException();
    }

    public IMiniToolbar CreateMiniToolbar()
    {
        throw new NotImplementedException();
    }

    public int _PromptMessage(int MessageID)
    {
        throw new NotImplementedException();
    }
}