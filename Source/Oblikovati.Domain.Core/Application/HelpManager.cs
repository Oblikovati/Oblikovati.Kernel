using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Core.Application;

public class HelpManager : IHelpManager
{
    public string HelpPath { get; set; }
    public IHelpEvents HelpEvents { get; set; }
    public void DisplayHelpTopic(string FileName, string TopicName)
    {
        throw new NotImplementedException();
    }

    public void DisplayHelpContext(string FileName, int Context)
    {
        throw new NotImplementedException();
    }

    public void RegisterHelpContext(string FileName, int Context, string ContextString)
    {
        throw new NotImplementedException();
    }

    public string GetOblikovatiHelpURL(string Seed, object Query)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}