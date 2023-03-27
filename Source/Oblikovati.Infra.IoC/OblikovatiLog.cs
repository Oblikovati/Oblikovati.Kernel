using Serilog;

using Oblikovati.Domain.Contracts.Application;

namespace Oblikovati.Infra.IoC;

public class OblikovatiLog : IApplicationLog
{
    public void Debug(string message)
    {
        Log.Debug(message);
    }

    public void Error(string message)
    {
        Log.Error(message);
    }

    public void Fatal(string message)
    {
        Log.Fatal(message);
    }

    public void Information(string message)
    {
        Log.Information(message);
    }

    public void Verbose(string message)
    {
        Log.Verbose(message);
    }
}
