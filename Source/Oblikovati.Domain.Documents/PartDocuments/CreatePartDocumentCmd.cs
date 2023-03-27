//using Oblikovati.Domain.Core;

//namespace Oblikovati.Domain.Documents.PartDocuments;

//public class CreatePartDocumentCmd : Command
//{
//    public CreatePartDocumentCmd() 
//        : base(application)
//    {
//    }
//    public override void ExecuteCommand() => StopCommand();

//    public void CreateButton() => CreateButton("New Part", "NewPartCmd", 
//        CommandTypesEnum.kFileOperationsCmdType, (object) "", "",
//        "",  null, null);

//    protected override void ButtonDefinition_OnExecute(INameValueMap context)
//    {
//        if (_commandIsRunning)
//            StopCommand();
//        StartCommand();
//    }
//    public override void OnHelp(
//        EventTimingEnum beforeOrAfter,
//        INameValueMap context,
//        out HandlingCodeEnum handlingCode)
//    {
//        _application.HelpManager.DisplayHelpTopic("OblikovatiHelp.chm", "CreatePart");
//        handlingCode = HandlingCodeEnum.kEventHandled;
//    }

//    public override void StartCommand()
//    {

//        //TODO: Some action here.
//        base.StartCommand();
//    }
//    public override void StopCommand()
//    {
//        DisableInteraction();
//        base.StopCommand();
//    }
//    public override void EnableInteraction()
//    {
//        base.EnableInteraction();
//        _selectEvents.ClearSelectionFilter();
//        _selectEvents.ResetSelections();
//        _selectEvents.AddSelectionFilter(SelectionFilterEnum.kAllEntitiesFilter);
//        _selectEvents.SingleSelectEnabled = true;
//        _interactionEvents.StatusBarText = "";
//    }

//    public override void OnPreSelect(
//        ref object preSelectEntity,
//        out bool doHighlight,
//        ref IObjectCollection morePreSelectEntities,
//        SelectionDeviceEnum selectionDevice,
//        IPoint modelPosition,
//        IPoint2d viewPosition,
//        IView view)
//    {
//        doHighlight = false;
//    }
//    public override void OnSelect(
//        IObjectsEnumerator justSelectedEntities,
//        SelectionDeviceEnum selectionDevice,
//        IPoint modelPosition,
//        IPoint2d viewPosition,
//        IView view)
//    {
//        if (justSelectedEntities.Count <= 0)
//            return;
//        var justSelectedEntity = justSelectedEntities[1];
//        if ((IComponentOccurrence) justSelectedEntity is null)
//            return;
//        _selectEvents.AddToSelectedEntities(justSelectedEntity);
//    }
//}