using Microsoft.Extensions.DependencyInjection;
using Oblikovati.Domain.Contracts.DependencyInjection;
using System.Reflection;
using Serilog;
using Oblikovati.Domain.Contracts.Application;

namespace Oblikovati.Infra.IoC;

public class Injector : IDependencyResolver
{
    IServiceCollection _services;
    ServiceProvider _serviceProvider;
	public Injector(IEnumerable<string> libraries)
	{
        _services = new ServiceCollection();
        _services.AddSingleton<IDependencyResolver>(this);
        _services.AddSingleton<IApplicationLog, OblikovatiLog>();

        foreach(var library in libraries)
        {
            Log.Debug("DependencyResolver: Loading Library: "+ library);
            InjectTypes(FilterInjectableTypes(GetOblikovatiTypesFromFile(library)));
        }
            
        _serviceProvider= _services.BuildServiceProvider();
	}

    private void InjectTypes(IEnumerable<Type> types)
    {
        foreach (var type in types)
            InjectType(type);
    }

    private void InjectType(Type type)
    {
        var interfaces = GetInjectableInterfaces(type);
        if (IsSingletonEntity(type))
        {
            foreach (var i in interfaces)
            {
                Log.Debug($"Registering Singleton for: {i.Name} using: {type.Name}");
                _services.AddSingleton(i, type);
            }
        }
        else
        {
            foreach (var i in interfaces)
            {
                Log.Debug($"Registering Transient for: {i.Name} using: {type.Name}");
                _services.AddTransient(i, type);
            }
        }
    }
    private void InjectType<TIface, TImplementation>(TImplementation cls) where TImplementation : class , TIface, new() where TIface: class
    {
        if (IsSingletonEntity(cls.GetType()))
        {
            Log.Debug($"Registering Singleton for: {nameof(TIface)} using: {cls.GetType().Name}");
            _services.AddSingleton<TIface, TImplementation>((sp) => cls);
        }
        else
        {
            Log.Debug($"Registering Transient for: {nameof(TIface)} using: {cls.GetType().Name}");
            _services.AddTransient<TIface, TImplementation>((sp) => cls);
        }
    }
    private IEnumerable<Type> GetOblikovatiTypesFromFile(string fileName) 
    {
        var assembly = Assembly.LoadFrom(fileName);
        return assembly
                .DefinedTypes
                .Where(t => t.FullName.StartsWith("Oblikovati"));
    }

    private IEnumerable<Type> FilterInjectableTypes(IEnumerable<Type> types)
    {
        return types.Where(t => t.GetInterfaces()
            .Any(i => i.IsGenericType is false && i.FullName.Equals(
                "Oblikovati.Domain.Contracts.DependencyInjection.IInjectableEntity")));
    }
    private IEnumerable<Type> GetInjectableInterfaces(Type type)
    {
        return type.GetInterfaces()
            .Where(t => t.IsGenericType is false &&
                    t.FullName.StartsWith("Oblikovati.Domain.Contracts") &&
                    !t.Name.Equals("IInjectableEntity") &&
                    !t.Name.Equals("IInjectableSingletonEntity") &&
                    !t.Name.Equals("IInjectableTransientEntity"));
    }
    private bool IsSingletonEntity(Type entityType)
    {
        return entityType.GetInterfaces().Any(i => i.Name.Equals("IInjectableSingletonEntity"));
    }

    public T ResolveDepency<T>() where T : IInjectableEntity
    {
        try
        {
            return _serviceProvider.GetRequiredService<T>();
        }
        catch 
        {
            Log.Error($"DependencyResolver: Unable to Retrieve object for: {typeof(T).Name}");
            return default;
        }
        
    }

    public void RegisterDependency<TIface, TImplementation>(TImplementation cls) where TImplementation : class, TIface, new() where TIface : class
    {
        InjectType<TIface, TImplementation>(cls);
    }
}