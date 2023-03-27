using System.Reflection;
using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;
using Oblikovati.Domain.Core.AddIns;
using Oblikovati.Domain.Core.Application;
using Oblikovati.Domain.Core.Files;
using Oblikovati.Domain.Core.Transient;
using Oblikovati.Domain.Documents.PartDocuments;
using Oblikovati.Domain.Contracts.Application;
using Oblikovati.Domain.Contracts.DependencyInjection;
using Oblikovati.Domain.Contracts.Rendering;
using Oblikovati.Domain.Renderer;
using Silk.NET.Windowing;

namespace Oblikovati.Application;

public class ApplicationService : IApplication
{
    private readonly IDependencyResolver _dependencyResolver;
    private Domain.Windowing.Window _mainWindow;
    private IRenderer _renderer;
    public ApplicationService(IDependencyResolver dependencyResolver)
    {
        _dependencyResolver = dependencyResolver;
        Log = _dependencyResolver.ResolveDepency<IApplicationLog>();
        FileManager = _dependencyResolver.ResolveDepency<IFileManager>();
        FileOptions = _dependencyResolver.ResolveDepency<IFileOptions>();
        DisplayOptions = _dependencyResolver.ResolveDepency<IDisplayOptions>();
        HardwareOptions = _dependencyResolver.ResolveDepency<IHardwareOptions>();
        InstallPath = Directory.GetCurrentDirectory();
        DesignProjectManager = _dependencyResolver.ResolveDepency<IDesignProjectManager>();
        CurrentUserAppDataPath = Path.GetFullPath("%appdata%");
        AllUsersAppDataPath = Path.GetFullPath("%programdata%");
        FileAccessEvents = _dependencyResolver.ResolveDepency<IFileAccessEvents>();
        ReferenceKeyEvents = _dependencyResolver.ResolveDepency<IReferenceKeyEvents>();
        HelpManager = _dependencyResolver.ResolveDepency<IHelpManager>();
        Documents = _dependencyResolver.ResolveDepency<IDocuments>();
        ApplicationEvents = _dependencyResolver.ResolveDepency<IApplicationEvents>();
        ModelingEvents = _dependencyResolver.ResolveDepency<IModelingEvents>();
        SketchEvents = _dependencyResolver.ResolveDepency<ISketchEvents>();
        StyleEvents = _dependencyResolver.ResolveDepency<IStyleEvents>();
        RepresentationEvents = _dependencyResolver.ResolveDepency<IRepresentationEvents>();
        AssemblyEvents = _dependencyResolver.ResolveDepency<IAssemblyEvents>();
        ModelStateEvents = _dependencyResolver.ResolveDepency<IModelStateEvents>();
        TransactionManager = _dependencyResolver.ResolveDepency<ITransactionManager>();
        ChangeManager = _dependencyResolver.ResolveDepency<IChangeManager>();
        AssemblyOptions = _dependencyResolver.ResolveDepency<IAssemblyOptions>();
        GeneralOptions = _dependencyResolver.ResolveDepency<IGeneralOptions>();
        SketchOptions = _dependencyResolver.ResolveDepency<ISketchOptions>();
        PartOptions = _dependencyResolver.ResolveDepency<IPartOptions>();
        Sketch3DOptions = _dependencyResolver.ResolveDepency<ISketch3DOptions>();
        DrawingOptions = _dependencyResolver.ResolveDepency<IDrawingOptions>();
        SaveOptions = _dependencyResolver.ResolveDepency<ISaveOptions>();
        ContentCenter = _dependencyResolver.ResolveDepency<IContentCenter>();
        Views = _dependencyResolver.ResolveDepency<IViewsEnumerator>();
        ViewFrames = _dependencyResolver.ResolveDepency<IViewFramesEnumerator>();
        Environments = _dependencyResolver.ResolveDepency<IEnvironments>();
        UserInterfaceManager = _dependencyResolver.ResolveDepency<IUserInterfaceManager>();
        CommandManager = _dependencyResolver.ResolveDepency<ICommandManager>();
    }

    #region Properties

    public IFileLocations FileLocations { get; set; } = new FileLocations();
    public IApplicationAddIns ApplicationAddIns { get; set; } = new ApplicationAddIns();
    public ISoftwareVersion SoftwareVersion { get; set; } = new SoftwareVersion();
    public string UserName { get; set; } = "";
    public ITransientGeometry TransientGeometry { get; set; } = new TransientGeometry();
    public IFileManager FileManager { get; set; }
    public IFileOptions FileOptions { get; set; }
    public int Locale { get; set; } = 0;
    public IDisplayOptions DisplayOptions { get; set; }
    public IHardwareOptions HardwareOptions { get; set; }
    public string InstallPath { get; set; }
    public IDesignProjectManager DesignProjectManager { get; set; }
    public string CurrentUserAppDataPath { get; set; }
    public string AllUsersAppDataPath { get; set; }
    public ITransientObjects TransientObjects { get; set; } = new TransientObjects();
    public IFileAccessEvents FileAccessEvents { get; set; }
    public IReferenceKeyEvents ReferenceKeyEvents { get; set; }
    public ITestManager TestManager { get; set; }
    public IHelpManager HelpManager { get; set; }
    public IDocuments Documents { get; set; }
    public IApplicationEvents ApplicationEvents { get; set; }
    public IModelingEvents ModelingEvents { get; set; }
    public ISketchEvents SketchEvents { get; set; }
    public IStyleEvents StyleEvents { get; set; }
    public IRepresentationEvents RepresentationEvents { get; set; }
    public IAssemblyEvents AssemblyEvents { get; set; }
    public IModelStateEvents ModelStateEvents { get; set; }
    public IObjectsEnumeratorByVariant Preferences { get; set; }
    public ITransactionManager TransactionManager { get; set; }
    public IChangeManager ChangeManager { get; set; }
    public string LanguageName { get; set; }
    public IAssemblyOptions AssemblyOptions { get; set; }
    public IGeneralOptions GeneralOptions { get; set; }
    public ISketchOptions SketchOptions { get; set; }
    public IPartOptions PartOptions { get; set; }
    public ISketch3DOptions Sketch3DOptions { get; set; }
    public IDrawingOptions DrawingOptions { get; set; }
    public ISaveOptions SaveOptions { get; set; }
    public IContentCenter ContentCenter { get; set; }
    public IiFeatureOptions iFeatureOptions { get; set; }
    public INotebookOptions NotebookOptions { get; set; }
    public IMeasureTools MeasureTools { get; set; }
    public ILanguageTools LanguageTools { get; set; }
    public bool Ready { get; set; }
    public IUnitsOfMeasure UnitsOfMeasure { get; set; }
    public ITransientBRep TransientBRep { get; set; }
    public bool SupportsFileManagement { get; set; }
    public IErrorManager ErrorManager { get; set; }
    public IContentCenterOptions ContentCenterOptions { get; set; }
    public IStylesManager StylesManager { get; set; }
    public IPresentationOptions PresentationOptions { get; set; }
    public IAssetLibrary ActiveAppearanceLibrary { get; set; }
    public IAssetLibrary ActiveMaterialLibrary { get; set; }
    public IAssetLibraries AssetLibraries { get; set; }
    public IAssetsEnumerator FavoriteAssets { get; set; }
    public MaterialDisplayUnitsEnum MaterialDisplayUnits { get; set; }
    public IColorScheme ActiveColorScheme { get; set; }
    public IColorSchemes ColorSchemes { get; set; }
    public IiLogicOptions iLogicOptions { get; set; }
    public ICustomDataEvents _CustomDataEvents { get; set; }
    public bool _LibraryDocumentModifiable { get; set; }
    public IDocument ActiveDocument { get; set; }
    public IDocument ActiveEditDocument { get; set; }
    public DocumentTypeEnum ActiveDocumentType { get; set; }
    public Domain.Contracts.IView ActiveView { get; set; }
    public IViewsEnumerator Views { get; set; }
    public string Caption { get; set; }
    public bool Visible { get; set; }
    public bool IsCIPEnabled { get; set; }
    public string ADPSessionId { get; set; }
    public string ADPDeviceId { get; set; }
    public ICommandManager CommandManager { get; set; }
    public bool MRUEnabled { get; set; }
    public bool MRUDisplay { get; set; }
    public bool SilentOperation { get; set; }
    public object ActiveEditObject { get; set; }
    public string StatusBarText { get; set; }
    public IEnvironments Environments { get; set; }
    public IEnvironmentBaseCollection EnvironmentBaseCollection { get; set; }
    public IEnvironment ActiveEnvironment { get; set; }
    public int Top { get; set; }
    public int Left { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    public WindowsSizeEnum WindowState { get; set; }
    public bool ScreenUpdating { get; set; }
    public IUserInterfaceManager UserInterfaceManager { get; set; }
    public IThemeManager ThemeManager { get; set; }
    public IFileUIEvents FileUIEvents { get; set; }
    public ICameraEvents CameraEvents { get; set; }
    public bool FlythroughMode3Dx { get; set; }
    public bool CameraRollMode3Dx { get; set; }
    public bool OpenDocumentsDisplay { get; set; }
    public string LanguageCode { get; set; }
    public ITutorialsManager TutorialsManager { get; set; }
    public IWebViews WebViews { get; set; }
    public IWebView ActiveWebView { get; set; }
    public IWebBrowserDialogs WebBrowserDialogs { get; set; }
    public bool IsIn3dPrintMode { get; set; }
    public bool AllowDataCollectionForAnalyticsPrograms { get; set; }
    public List<string> AvailableComparisonVersions { get; set; }
    public string ComparisonVersion { get; set; }
    public IViewFrame ActiveViewFrame { get; set; }
    public IViewFramesEnumerator ViewFrames { get; set; }
    public IClientResourceMaps ClientResourceMaps { get; set; }

    public IApplicationLog Log { get; private set; }

#endregion

#region Public Methods
    public void Run()
    {
        Log.Debug("Initializing Window System");
        //TODO: Splash screen?
        _mainWindow = new Domain.Windowing.Window("Oblikovati");
        _mainWindow.Init();
        _renderer = new Renderer(_mainWindow.SilkWindow);
        _renderer.Init();
        
        RegisterDefaultEnvironments();
        LoadAddins();

        _mainWindow.SilkWindow!.Run();
        Log.Debug("Main Window Closed, Starting Shutdown!");
        ApplicationEvents.OnQuit?.Invoke(this, new IApplicationEvents.OnQuitEventArgs()
        {
            BeforeOrAfter = EventTimingEnum.kBefore
        });

        _renderer.Shutdown();
    }

    public void Shutdown()
    {
        throw new NotImplementedException();
    }
    public void WriteCIPWaypoint(string WaypointData)
    {
        throw new NotImplementedException();
    }

    public void Move(int Top, int Left, int Height, int Width)
    {
        throw new NotImplementedException();
    }

    public void CreateFileDialog(out IFileDialog Dialog)
    {
        throw new NotImplementedException();
    }

    public IProgressBar CreateProgressBar(bool DisplayInStatusBar, int NumberOfSteps, string Title, bool AllowCancel, int HWND)
    {
        throw new NotImplementedException();
    }

    public bool Login()
    {
        throw new NotImplementedException();
    }

    public void ShowMyHomeWindow(object ContentTypeOrURL)
    {
        throw new NotImplementedException();
    }

    public StatusEnum GetSubscriptionEnablerStatus(string VersionNumber)
    {
        throw new NotImplementedException();
    }

    public IFactoryTableDialog CreateFactoryTableDialog(string FullFileName)
    {
        throw new NotImplementedException();
    }

    public void RefreshRibbonForComparison()
    {
        throw new NotImplementedException();
    }

    public void ExportApplicationOptions(string FullFileName)
    {
        throw new NotImplementedException();
    }

    public void ImportApplicationOptions(string FullFileName)
    {
        throw new NotImplementedException();
    }

    public void UseAutoCADRelatedSettings()
    {
        throw new NotImplementedException();
    }

    public void UseOblikovatiSettings()
    {
        throw new NotImplementedException();
    }

    public string GetTemplateFile(DocumentTypeEnum DocumentType, SystemOfMeasureEnum SystemOfMeasure,
        DraftingStandardEnum DraftingStandard, object DocumentSubType)
    {
        throw new NotImplementedException();
    }

    public void _ConstructInternalNameAndFileVersion(string Name, string Number, string Custom, string Revision,
        out string InternalName, out string FileVersion)
    {
        throw new NotImplementedException();
    }

    public void CreateInternalName(string Name, string Number, string Custom, out string InternalName)
    {
        throw new NotImplementedException();
    }

    public object GetInterfaceObject(string ProgIDorCLSID)
    {
        throw new NotImplementedException();
    }

    public object GetInterfaceObject32(string ProgIDorCLSID)
    {
        throw new NotImplementedException();
    }

    public void ConstructInternalNameAndRevisionId(string InternalNameToken, string RevisionIdToken, out string InternalName,
        out string RevisionId)
    {
        throw new NotImplementedException();
    }

    public void ReserveLicense(string ClientId)
    {
        throw new NotImplementedException();
    }

    public void UnreserveLicense(string ClientId)
    {
        throw new NotImplementedException();
    }

    public void _ReplayTranscript(string TranscriptFileName)
    {
        throw new NotImplementedException();
    }

    public void _MigrateStylesLibrary(string LibraryPath, out string Result, out int NumLibraries)
    {
        throw new NotImplementedException();
    }

    public void _LogExceptionDump(int Value)
    {
        throw new NotImplementedException();
    }

    public void _GetShapeManagerVersion(out int MajorVersion, out int MinorVersion, out int PointVersion)
    {
        throw new NotImplementedException();
    }

    public string LicenseChallenge()
    {
        throw new NotImplementedException();
    }

    public void LicenseResponse(string Response)
    {
        throw new NotImplementedException();
    }

    public bool _CanMigrateCustomSettings(CustomSettingsTypeEnum CustomSettingsType, string FromBuildIdentifier)
    {
        throw new NotImplementedException();
    }

    public bool _MigrateCustomSettings(CustomSettingsTypeEnum CustomSettingsType, string FromBuildIdentifier)
    {
        throw new NotImplementedException();
    }

    public void Quit()
    {
        throw new NotImplementedException();
    }

    public void GetAppFrameExtents(out int Top, out int Left, out int Height, out int Width)
    {
        throw new NotImplementedException();
    }

    public void GetMDIClientAreaExtents(out int Top, out int Left, out int Height, out int Width)
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


    #endregion

    #region Private Methods


    private void RegisterDefaultEnvironments()
    {
        var initEnv = new InitEnvironment();
        Environments.Add(initEnv);
        Environments.Add(new PartEnvironment());
        Environments.Add(new PartEditEnvironment());

        ActiveEnvironment = initEnv;
    }

    private void LoadAddins()
    {
        try
        {
            var pd = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var addInFolder = Path.Combine(pd, @"Oblikovati\Addins");
            Directory.CreateDirectory(addInFolder);
            var files = Directory.GetFiles(addInFolder);
            foreach (var file in files)
                LoadAddin(file);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void LoadAddin(string fileName)
    {
        try
        {
            var asm = Assembly.LoadFile(fileName);
            var appAddin = new ApplicationAddin(asm);
            ApplicationAddIns.Add(appAddin);
        }
        catch (Exception e)
        {

        }

    }

    #endregion
}