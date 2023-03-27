using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.DesignProjects;

/// <summary>The DesignProjects collection object provides access to all the existing projects and provides methods to create additional projects.</summary>
public class DesignProjects : List<IDesignProject>, IDesignProjects
{

    public IDesignProject this[string Index] => this.First(p => p.FullFileName.Equals(Index));

    public IDesignProject ItemByName(string name)
    {
        return this.FirstOrDefault(dp => dp.FullFileName.Equals(name));
    }
    /// <summary>Method that creates a new DesignProject. The newly created DesignProject is returned.</summary>
    /// <param name="ProjectType">
    ///     <summary>Input MultiUserModeEnum that specifies the type of project to create.</summary>
    /// </param>
    /// <param name="Name">
    ///     <summary>Input String that specifies a name for the project.</summary>
    /// </param>
    /// <param name="ProjectPath">
    ///     <summary>Input String that specifies the project (workspace or workgroup) folder for the project.</summary>
    /// </param>
    /// <returns />
    public IDesignProject Add(MultiUserModeEnum ProjectType, string Name, string ProjectPath)
    {
        var dp = new DesignProject();
        dp.ProjectType = ProjectType;
        dp.Name = Name;
        dp.FullFileName = Path.Combine(ProjectPath,Name);
        dp.Save();
        Add(dp);
        return dp;
    }
    /// <summary>Method that adds an existing project file to the list of project files. This is equivalent of browsing to a specific ipj file on disk and choosing it in the Projects editor dialog. If the design project is already in the collection, the corresponding DesignProject object is returned.</summary>
    /// <param name="FullFileName">
    ///     <summary>Input String that specifies the full file name of an Oblikovati project file with an .ipj extension.</summary>
    /// </param>
    /// <returns />
    public IDesignProject AddExisting(string FullFileName)
    {
        throw new NotImplementedException();
    }
}