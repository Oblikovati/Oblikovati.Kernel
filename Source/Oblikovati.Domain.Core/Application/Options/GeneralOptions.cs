using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.Application.Options;

public class GeneralOptions : IGeneralOptions
{
    public GeneralOptions()
    {

    }

    public string TextAppearance { get; set; }
    public int TextSize { get; set; }
    public bool ShowStartupDialog { get; set; }
    public bool Show3DIndicator { get; set; }
    public string UserName { get; set; }
    public int UndoFileSize { get; set; }
    public int ToleranceValue { get; set; }
    public double SelectOtherDelay { get; set; }
    public double AnnotationScale { get; set; }
    public IThreadTableQuery ThreadTableQuery { get; set; }
    public bool UseNegativeIntegralForInertialProperties { get; set; }
    public bool iMateVisibility { get; set; }
    public bool ShowAutocompleteForCommandAlias { get; set; }
    public bool _ShowHelpDialogOnStartup { get; set; }
    public bool ShowCommandPromptTooltips { get; set; }
    public StartupActionTypeEnum StartupActionType { get; set; }
    public StartupHelpFocusTopicEnum StartupHelpFocusTopic { get; set; }
    public string StartupNewFileTemplateName { get; set; }
    public string StartupProjectFileName { get; set; }
    public bool EnableOptimizedSelection { get; set; }
    public bool EnablePrehighlight { get; set; }
    public UpdatePropertiesOnSaveForFileTypeEnum UpdatePropertiesOnSaveForFileType { get; set; }
    public bool EnableLegacyProjectCreation { get; set; }
    public bool ShowCommandAliasInputDialog { get; set; }
    public bool EnableEnhancedHighlighting { get; set; }
    public IGripSnapOptions GripSnapOptions { get; set; }
    public double SecondLevelTooltipDelay { get; set; }
    public bool ShowDocumentTabTooltips { get; set; }
    public bool ShowSecondLevelTooltips { get; set; }
    public bool ShowTooltips { get; set; }
    public bool ShowXYZAxisLabels { get; set; }
    public double TooltipDelay { get; set; }
    public bool ShowVideoToolClips { get; set; }
    public bool UseOblikovatiOnlineHelp { get; set; }
    public bool EnableSpellCheck { get; set; }
    public ISpellCheckOptions SpellCheckOptions { get; set; }
    public bool ShowHomeBaseOnStartup { get; set; }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}