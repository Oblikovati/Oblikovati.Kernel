//namespace Oblikovati.Domain.Core;

//public abstract class Command
//{ 
//    protected IButtonDefinition _buttonDefinition;
//    private ButtonDefinitionSink_OnExecuteEventHandler _buttonDefinition_OnExecute_Delegate;
//    protected Interaction _interaction;
//    protected IInteractionEvents _interactionEvents;
//    protected ISelectEvents _selectEvents;
//    protected bool _commandIsRunning;
//    public IButtonDefinition ButtonDefinition => _buttonDefinition;
//    protected Command()
//    {
        
//    }
//    public void CreateButton(string displayName, string internalName, CommandTypesEnum commandType,
//        object clientId, string description, string toolTip, object standardIcon, object largeIcon)
//    {
//        // this._buttonDefinition = this._application.CommandManager.ControlDefinitions.AddButtonDefinition(displayName, internalName, commandType, clientId, description, toolTip, standardIcon, largeIcon);
//        Command command = this;

//        //this._buttonDefinition_OnExecute_Delegate = new ButtonDefinitionSink_OnExecuteEventHandler((object) command, (UIntPtr) __vmethodptr(command, ButtonDefinition_OnExecute));
//        this._buttonDefinition.add_OnExecute(this._buttonDefinition_OnExecute_Delegate);
//    }
//    protected virtual void ButtonDefinition_OnExecute(INameValueMap context)
//    {
//        if (this._commandIsRunning)
//            this.StopCommand();
//        this.StartCommand();
//    }
//    public virtual void RemoveButton()
//    {
//      if (this._buttonDefinition == null)
//        return;
//      this._buttonDefinition.remove_OnExecute(this._buttonDefinition_OnExecute_Delegate);
//      this._buttonDefinition = null;
//    }

//    public virtual void StartCommand()
//    {
//      this._buttonDefinition.Pressed = true;
//      this._commandIsRunning = true;
//    }

//    public abstract void ExecuteCommand();

//    public virtual void StopCommand()
//    {
//      try
//      {
//        this._buttonDefinition.Pressed = false;
//        this._commandIsRunning = false;
//      }
//      catch (Exception ex)
//      {
//        //int num = (int) MessageBox.Show(ex.ToString());
//      }
//    }

//    public void StartInteraction()
//    {
//      try
//      {
//        this._interaction = new Interaction();
//        this._interaction.SetParentCmd(this);
//        this._interaction.StartInteraction(this._application, this._buttonDefinition.InternalName, out this._interactionEvents);
//      }
//      catch (Exception ex)
//      {
//       // int num = (int) MessageBox.Show(ex.ToString());
//      }
//    }

//    public void StopInteraction()
//    {
//      if (this._interaction != null)
//      {
//        this._interaction.StopInteraction();
//        this._interaction = null;
//      }
//      this._interactionEvents = null;
//    }

//    public void SubscribeToEvent(Interaction.InteractionTypeEnum interactionType)
//    {
//      object eventType = null;
//      this._interaction.SubscribeToEvent(interactionType, ref eventType);
//      if (eventType == null || !(eventType is ISelectEvents))
//        return;
//      this._selectEvents = (ISelectEvents) eventType;
//    }

//    public void UnsubscribeFromEvents()
//    {
//      if (this._interaction != null)
//        this._interaction.UnsubscribeFromEvents();
//      this._selectEvents = null;
//    }

//    public virtual void EnableInteraction() => this._interaction.EnableInteraction();

//    public virtual void DisableInteraction()
//    {
//      if (this._interaction == null)
//        return;
//      this._interaction.DisableInteraction();
//      this.StopInteraction();
//    }

//    public virtual void OnHelp(
//      EventTimingEnum beforeOrAfter,
//      INameValueMap context,
//      out HandlingCodeEnum handlingCode)
//    {
//      handlingCode = HandlingCodeEnum.kEventNotHandled;
//    }

//    public virtual void OnPreSelect(
//      ref object preSelectEntity,
//      out bool doHighlight,
//      ref IObjectCollection morePreSelectEntities,
//      SelectionDeviceEnum selectionDevice,
//      IPoint modelPosition,
//      IPoint2d viewPosition,
//      IView view)
//    {
//      doHighlight = true;
//    }

//    public virtual void OnSelect(
//      IObjectsEnumerator justSelectedEntities,
//      SelectionDeviceEnum selectionDevice,
//      IPoint modelPosition,
//      IPoint2d viewPosition,
//      IView view)
//    {
//    }

//    public virtual void OnUnSelect(
//      IObjectsEnumerator unSelectedEntities,
//      SelectionDeviceEnum selectionDevice,
//      IPoint modelPosition,
//      IPoint2d viewPosition,
//      IView view)
//    {
//    }
//}