//using Oblikovati.Domain.Core;

//namespace Oblikovati.Addin.Tutorials;

//internal abstract class Command
//  {
//    protected IApplication _application;
//    protected IButtonDefinition m_buttonDefinition;
//    private ButtonDefinitionSink_OnExecuteEventHandler m_buttonDefinition_OnExecute_Delegate;
//    protected Interaction MInteraction;
//    protected IInteractionEvents m_interactionEvents;
//    protected ISelectEvents m_selectEvents;
//    protected bool m_commandIsRunning;

//    protected InteractiveTutorialServer InteractiveTutorialServerObj { get; set; }

//    public IButtonDefinition ButtonDefinition => this.m_buttonDefinition;

//    public Command(
//      InteractiveTutorialServer interactiveTutorialServer = null)
//    {
//      this.InteractiveTutorialServerObj = interactiveTutorialServer;
//      this._application = null;
//      this.m_buttonDefinition = null;
//      this.MInteraction = null;
//      this.m_interactionEvents = null;
//      this.m_selectEvents = null;
//      this.m_commandIsRunning = false;
//    }

//    public void CreateButton(
//      string displayName,
//      string internalName,
//      CommandTypesEnum commandType,
//      string clientId,
//      string description,
//      string toolTip,
//      object standardIcon,
//      object largeIcon)
//    {
//      //TODO: this
//      this.m_buttonDefinition = this._application.CommandManager.ControlDefinitions.AddButtonDefinition(displayName, internalName, commandType, clientId, description, toolTip,(object) standardIcon,(object) largeIcon, ButtonDisplayEnum.kAlwaysDisplayText);
//      Command command = this;
//      // ISSUE: virtual method pointer
//     // this.m_buttonDefinition_OnExecute_Delegate = new ButtonDefinitionSink_OnExecuteEventHandler((object) command, (UIntPtr) __vmethodptr(command, ButtonDefinition_OnExecute));
//      this.m_buttonDefinition.add_OnExecute(this.m_buttonDefinition_OnExecute_Delegate);
//    }

//    protected virtual void ButtonDefinition_OnExecute(INameValueMap context)
//    {
//      if (this.m_commandIsRunning)
//        this.StopCommand();
//      this.StartCommand();
//    }

//    public virtual void RemoveButton()
//    {
//      if (this.m_buttonDefinition == null)
//        return;
//      this.m_buttonDefinition.remove_OnExecute(this.m_buttonDefinition_OnExecute_Delegate);
//      this.m_buttonDefinition = null;
//    }

//    public virtual void StartCommand()
//    {
//      this.m_buttonDefinition.Pressed = true;
//      this.m_commandIsRunning = true;
//    }

//    public abstract void ExecuteCommand();

//    public virtual void StopCommand()
//    {
//      try
//      {
//        this.m_buttonDefinition.Pressed = false;
//        this.m_commandIsRunning = false;
//      }
//      catch (Exception ex)
//      {
//        int num = (int) MessageBox.Show(ex.ToString());
//      }
//    }

//    public void StartInteraction()
//    {
//      try
//      {
//        this.MInteraction = new Interaction();
//        this.MInteraction.SetParentCmd(this);
//        this.MInteraction.StartInteraction(this._application, this.m_buttonDefinition.InternalName, out this.m_interactionEvents);
//      }
//      catch (Exception ex)
//      {
//        int num = (int) MessageBox.Show(ex.ToString());
//      }
//    }

//    public void StopInteraction()
//    {
//      if (this.MInteraction != null)
//      {
//        this.MInteraction.StopInteraction();
//        this.MInteraction = (Interaction) null;
//      }
//      this.m_interactionEvents = null;
//    }

//    public void SubscribeToEvent(Interaction.InteractionTypeEnum interactionType)
//    {
//      object eventType = (object) null;
//      this.MInteraction.SubscribeToEvent(interactionType, ref eventType);
//      if (eventType == null || !(eventType is ISelectEvents))
//        return;
//      this.m_selectEvents = (ISelectEvents) eventType;
//    }

//    public void UnsubscribeFromEvents()
//    {
//      if (this.MInteraction != null)
//        this.MInteraction.UnsubscribeFromEvents();
//      this.m_selectEvents = (ISelectEvents) null;
//    }

//    public virtual void EnableInteraction() => this.MInteraction.EnableInteraction();

//    public virtual void DisableInteraction()
//    {
//      if (this.MInteraction == null)
//        return;
//      this.MInteraction.DisableInteraction();
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
//  }