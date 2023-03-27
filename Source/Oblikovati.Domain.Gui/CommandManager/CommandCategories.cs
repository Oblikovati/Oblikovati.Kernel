using Oblikovati.Domain.Core;

namespace Oblikovati.Domain.Gui.CommandManager;

public class CommandCategories : List<ICommandCategory>, ICommandCategories
{
    public CommandCategories(IApplication application, ICommandManager parent)
    {
        Application = application;
        Parent = parent;
    }
    public IApplication Application { get; set; }

    public ICommandCategory this[string Index] => this.First(p => p.InternalName.Equals(Index));

    public ICommandManager Parent { get; }
    public ICommandCategory Add(string DisplayName, string InternalName, string ClientId)
    {
        var cc = new CommandCategory(Application, Parent)
        {
            DisplayName = DisplayName,
            InternalName = InternalName,
            ClientId = ClientId
        };
        this.Add(cc);
        return cc;
    }
}