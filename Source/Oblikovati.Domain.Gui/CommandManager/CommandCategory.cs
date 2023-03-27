using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.CommandManager;

public class CommandCategory : List<object>, ICommandCategory
{
    public CommandCategory(IApplication application, ICommandManager parent)
    {
        Application = application;
        Parent = parent;
    }
    public ICommandManager Parent { get; set; }
    public IApplication Application { get; set; }
    public bool BuiltIn { get; set; }
    public string DisplayName { get; set; }
    public string InternalName { get; set; }
    public string ClientId { get; set; }
    public void Delete()
    {
        throw new NotImplementedException();
    }

    public void Remove(int Index)
    {
        throw new NotImplementedException();
    }
}