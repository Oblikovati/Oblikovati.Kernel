using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Application;
using Oblikovati.Domain.Contracts.Application.Headless;
using Oblikovati.Domain.Contracts.DependencyInjection;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Application;

public class HeadlessApplicationService : IHeadlessApplication
{
    private readonly IDependencyResolver _dependencyResolver;
    public HeadlessApplicationService(IDependencyResolver dependencyResolver)
    {
        _dependencyResolver= dependencyResolver;
    }
    public IApplicationLog Log { get; private set; }
    public IFileLocations FileLocations { get; set; }
    public IApplicationAddIns ApplicationAddIns { get; set; }
    public ISoftwareVersion SoftwareVersion { get; set; }
    public string UserName { get; set; }
    public ITransientGeometry TransientGeometry { get; set; }
    public IFileManager FileManager { get; set; }
    public IFileOptions FileOptions { get; set; }
    public int Locale { get; set; }
    public IDisplayOptions DisplayOptions { get; set; }
    public IHardwareOptions HardwareOptions { get; set; }
    public string InstallPath { get; set; }
    public IDesignProjectManager DesignProjectManager { get; set; }
    public string CurrentUserAppDataPath { get; set; }
    public string AllUsersAppDataPath { get; set; }
    public ITransientObjects TransientObjects { get; set; }
    public IFileAccessEvents FileAccessEvents { get; set; }
    public IReferenceKeyEvents ReferenceKeyEvents { get; set; }
    public bool _IsRegistryEntry { get; set; }
    public object _RegistryEntry { get; set; }
    public IDebugInstrumentation _DebugInstrumentation { get; set; }
    public I_AppPerformanceMonitor _AppPerformanceMonitor { get; set; }
    public ITestManager TestManager { get; set; }
    public IHelpManager HelpManager { get; set; }

    public void _SetRegistryEntry(string SubKey, string ValueName, object Value, _RegistryHiveTypeEnum RegistryHive,
        bool RefreshWithEntry)
    {
        throw new NotImplementedException();
    }

    public void _DeleteRegistryEntry(string SubKey, string ValueName, _RegistryHiveTypeEnum RegistryHive)
    {
        throw new NotImplementedException();
    }

    public TService GetRequiredService<TService>() where TService : IInjectableEntity
    {
        //var service = ReadonlyDependencyResolver.GetService<TService>();
        //if (service is null)
        //{
        //    throw new InvalidOperationException($"Failed to resolve object of type {typeof(TService)}");
        //}

        return default;
    }

    public IHeadlessDocument Document { get; set; }
    public IFileSaveAs FileSaveAs { get; set; }
    public bool MultiUsersEnabled { get; set; }
    public MultiUserModeEnum MultiUserMode { get; set; }
    public bool MultiUserExternallyManaged { get; set; }
    public bool DisplayAffinity { get; set; }
    public bool IndirectReferences { get; set; }
    public IHeadlessDocument Open(string FullDocumentName)
    {
        throw new NotImplementedException();
    }

    public IHeadlessDocument OpenWithOptions(string FullDocumentName, INameValueMap Options)
    {
        throw new NotImplementedException();
    }

    public void _DisplayHelpTopic(string FileName, string TopicName)
    {
        throw new NotImplementedException();
    }

    public void _DisplayHelpContext(string FileName, int Context)
    {
        throw new NotImplementedException();
    }

    public bool _GetStylesLibraryLockStatus(string StylesLibraryLocation)
    {
        throw new NotImplementedException();
    }

    public void _SetStylesLibraryLockStatus(string FileName, bool bLock)
    {
        throw new NotImplementedException();
    }
    public IDependencyResolver GetDependencyResolver()
    {
        return _dependencyResolver;
    }

    public void Dispose()
    {
        
    }

    public void Run()
    {
        throw new NotImplementedException();
    }

    public void Shutdown()
    {
        throw new NotImplementedException();
    }
}