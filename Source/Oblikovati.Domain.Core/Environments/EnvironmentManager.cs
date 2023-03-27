using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Core.Environments;

public abstract class EnvironmentManager : IEnvironmentManager
{
    public IDocument Parent { get; protected set; }
    public IEnvironment BaseEnvironment { get; protected set; }
    public IEnvironment OverrideEnvironment { get; set; }
    public IEnvironment EditObjectEnvironment { get; protected set; }
    public void GetCurrentEnvironment(out IEnvironment Environment, out string EditTargetId)
    {
        if (OverrideEnvironment is object)
        {
            Environment = OverrideEnvironment;
            EditTargetId = "";
            return;
        }

        Environment = BaseEnvironment;
        EditTargetId = "";
    }

    public void SetCurrentEnvironment(IEnvironment Environment, string EditObjectId)
    {
        throw new NotImplementedException();
    }
}