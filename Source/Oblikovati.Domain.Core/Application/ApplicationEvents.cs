using Oblikovati.Domain.Contracts.Application;

namespace Oblikovati.Domain.Core.Application;

public class ApplicationEvents : IApplicationEvents
{
    public EventHandler<IApplicationEvents.OnNewDocumentEventArgs>? OnNewDocument { get; protected set; }

    public EventHandler<IApplicationEvents.OnInitializeDocumentEventArgs>? OnInitializeDocument { get; protected set; }

    public EventHandler<IApplicationEvents.OnOpenDocumentEventArgs>? OnOpenDocument { get; protected set; }

    public EventHandler<IApplicationEvents.OnSaveDocumentEventArgs>? OnSaveDocument { get; protected set; }

    public EventHandler<IApplicationEvents.OnCloseDocumentEventArgs>? OnCloseDocument { get; protected set; }

    public EventHandler<IApplicationEvents.OnTerminateDocumentEventArgs>? OnTerminateDocument { get; protected set; }

    public EventHandler<IApplicationEvents.OnActivateDocumentEventArgs>? OnActivateDocument { get; protected set; }

    public EventHandler<IApplicationEvents.OnDeactivateDocumentEventArgs>? OnDeactivateDocument { get; protected set; }

    public EventHandler<IApplicationEvents.OnNewViewEventArgs>? OnNewView { get; protected set; }

    public EventHandler<IApplicationEvents.OnDisplayModeChangeEventArgs>? OnDisplayModeChange { get; protected set; }

    public EventHandler<IApplicationEvents.OnCloseViewEventArgs>? OnCloseView { get; protected set; }

    public EventHandler<IApplicationEvents.OnActivateViewEventArgs>? OnActivateView { get; protected set; }

    public EventHandler<IApplicationEvents.OnDeactivateViewEventAgrs>? OnDeactivateView { get; protected set; }

    public EventHandler<IApplicationEvents.OnQuitEventArgs>? OnQuit { get; protected set; }

    public EventHandler<IApplicationEvents.OnNewEditObjectEventArgs>? OnNewEditObject { get; protected set; }

    public EventHandler<IApplicationEvents.OnTranslateDocumentEventArgs>? OnTranslateDocument { get; protected set; }

    public EventHandler<IApplicationEvents.OnActiveProjectChangedEventArgs>? OnActiveProjectChanged { get; protected set; }

    public EventHandler<IApplicationEvents.OnDocumentChangeEventArgs>? OnDocumentChange { get; protected set; }

    public EventHandler<IApplicationEvents.OnReadyEventArgs>? OnReady { get; protected set; }

    public EventHandler<IApplicationEvents.OnApplicationOptionChangeEventArgs>? OnApplicationOptionChange { get; protected set; }

    public EventHandler<IApplicationEvents.OnMoveApplicationWindowEventArgs>? OnMoveApplicationWindow { get; protected set; }

    public EventHandler<IApplicationEvents.OnResizeApplicationWindowEventArgs>? OnResizeApplicationWindow { get; protected set; }

    public EventHandler<IApplicationEvents.OnMoveViewEventArgs>? OnMoveView { get; protected set; }

    public EventHandler<IApplicationEvents.OnResizeViewEventArgs>? OnResizeView { get; protected set; }

    public EventHandler<IApplicationEvents.OnMigrateDocumentEventArgs>? OnMigrateDocument { get; protected set; }

    public void Dispose() {  }

}
