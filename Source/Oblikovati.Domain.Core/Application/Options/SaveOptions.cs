using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.Application.Options;

public class SaveOptions : ISaveOptions
{
    public SaveOptions()
    {

    }

    public bool PromptSaveForRecomputableChanges { get; set; }
    public bool PromptSaveForMigration { get; set; }
    public bool DefaultToSaveForMigration { get; set; }
    public bool PromptSaveForUserEdits { get; set; }
    public bool DefaultToSaveForUserEdits { get; set; }
    public bool PromptSaveForAPIChanges { get; set; }
    public bool DefaultToSaveForAPIChanges { get; set; }
    public bool PromptSaveForManualUpdates { get; set; }
    public bool DefaultToSaveForManualUpdates { get; set; }
    public bool PromptSaveForFileResolutionChange { get; set; }
    public bool DefaultToSaveForFileResolutionChange { get; set; }
    public bool PromptSaveForMassPropertyUpdate { get; set; }
    public bool DefaultToSaveForMassPropertyUpdate { get; set; }
    public bool PromptSaveForImplicitUpdate { get; set; }
    public bool DefaultToSaveForImplicitUpdate { get; set; }
    public bool SaveFilesInLibraryFolders { get; set; }
    public bool ListReferencedFilesInSaveDialog { get; set; }
    public double SaveReminderTimer { get; set; }
    public bool ShowSaveReminder { get; set; }
    public ReportLocationEnum TranslatorReportLocation { get; set; }
    public bool PromptSaveForModelStateUpdates { get; set; }
    public bool DefaultToSaveForModelStateUpdates { get; set; }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}