using Oblikovati.Domain.Contracts.Application.Headless;
using Oblikovati.Infra.IoC;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using System.Diagnostics;

namespace Oblikovati.Headless;

public static class Program
{
    private static Injector? _injector;
    [STAThread]
    public static void Main()
    {
        if (Debugger.IsAttached)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console(theme: SystemConsoleTheme.Colored)
            .CreateLogger();
        }
        else
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Error()
            .WriteTo.Console(theme: SystemConsoleTheme.Colored)
            .CreateLogger();
        }

        Log.Information("Starting Oblikovati Headless");
        
        Log.Verbose("Initializing Dependency Injection");

        _injector = new Injector(new List<string>(){
            "Oblikovati.Domain.Core.dll",
            "Oblikovati.Domain.Documents.dll",
            "Oblikovati.Domain.Geometry.dll",
            "Oblikovati.Domain.Math.dll",
            "Oblikovati.Domain.Utility.dll",
            "Oblikovati.Application.dll" });

        Log.Verbose("Dependency Injection Initialized");

        var app = _injector.ResolveDepency<IHeadlessApplication>();
        Log.Verbose("Application->Run()");
        app.Run();
    }
}