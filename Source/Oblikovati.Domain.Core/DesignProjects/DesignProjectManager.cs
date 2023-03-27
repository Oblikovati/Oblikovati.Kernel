using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.DesignProjects;

public class DesignProjectManager : IDesignProjectManager
{
    public DesignProjectManager()
    {
        
        
        DesignProjects = new DesignProjects();
    }
    
    public IDesignProjects DesignProjects { get; protected set; }
    public IDesignProject ActiveDesignProject { get; set; }
    
    public bool IsFileInActiveProject(string FileName, out LocationTypeEnum ProjectPathType, out string ProjectPathName)
    {
        throw new NotImplementedException();
    }

    public string ResolveFile(string SourcePath, string DestinationFileName, object Options)
    {
        throw new NotImplementedException();
    }

    public IProjectOptionsButton AddOptionsButton(string ClientId, string DisplayName, string ToolTipText, object StandardIcon)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}