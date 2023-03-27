//using System.Collections;
//using Oblikovati.Domain.Core;

//namespace Oblikovati.Addin.Tutorials;

//internal class Interaction
//  {
//    private ArrayList m_interactionTypes;
//    private IInteractionEvents m_interactionEvents;
//    private ISelectEvents m_selectEvents;
//    private Command m_parentCmd;
//    private InteractionEventsSink_OnTerminateEventHandler m_interaction_OnTerminate_Delegate;
//    private InteractionEventsSink_OnHelpEventHandler m_interaction_OnHelp_Delegate;
//    private SelectEventsSink_OnPreSelectEventHandler m_Select_OnPreSelect_Delegate;
//    private SelectEventsSink_OnSelectEventHandler m_Select_OnSelect_Delegate;
//    private SelectEventsSink_OnUnSelectEventHandler m_Select_OnUnSelect_Delegate;

//    public Interaction()
//    {
//      this.m_interactionTypes = new ArrayList();
//      this.m_interactionEvents =  null;
//      this.m_selectEvents =  null;
//      this.m_parentCmd = null;
//    }

//    public void StartInteraction(
//      ,
//      string interactionName,
//      out IInteractionEvents interactionEvents)
//    {
//      try
//      {
//        if (application.ActiveDocument == null)
//          return;
//        this.m_interactionEvents = application.CommandManager.CreateInteractionEvents();
//        this.m_interactionEvents.SelectionActive = true;
//        this.m_interactionEvents.Name = interactionName;
//        // ISSUE: method pointer
//       // this.m_interaction_OnTerminate_Delegate = new InteractionEventsSink_OnTerminateEventHandler((object) this, (UIntPtr) __methodptr(InteractionEvents_OnTerminate));
//        this.m_interactionEvents.add_OnTerminate(this.m_interaction_OnTerminate_Delegate);
//        // ISSUE: method pointer
//        //this.m_interaction_OnHelp_Delegate = new InteractionEventsSink_OnHelpEventHandler((object) this, (UIntPtr) __methodptr(InteractionEvents_OnHelp));
//        this.m_interactionEvents.add_OnHelp(this.m_interaction_OnHelp_Delegate);
//        this.m_selectEvents = this.m_interactionEvents.SelectEvents;
//        this.m_interactionEvents.Start();
//      }
//      catch (Exception ex)
//      {
//        int num = (int) MessageBox.Show(ex.ToString());
//      }
//      finally
//      {
//        interactionEvents = this.m_interactionEvents;
//      }
//    }

//    public void StopInteraction()
//    {
//      if (this.m_interactionEvents == null)
//        return;
//      this.m_interactionEvents.remove_OnTerminate(this.m_interaction_OnTerminate_Delegate);
//      this.m_interactionEvents.remove_OnHelp(this.m_interaction_OnHelp_Delegate);
//      this.m_interactionEvents.Stop();
//      this.m_interactionEvents = null;
//    }

//    public void SubscribeToEvent(
//      Interaction.InteractionTypeEnum interactionType,
//      ref object eventType)
//    {
//      for (int index = 0; index < this.m_interactionTypes.Count; ++index)
//      {
//        if (interactionType == (Interaction.InteractionTypeEnum) this.m_interactionTypes[index])
//          return;
//      }
//      this.m_interactionTypes.Add((object) interactionType);
//      if (interactionType != Interaction.InteractionTypeEnum.kSelection)
//        return;
//      this.m_selectEvents = this.m_interactionEvents.SelectEvents;
//      if (this.m_selectEvents == null)
//        return;
//      // ISSUE: method pointer
//      //this.m_Select_OnPreSelect_Delegate = new SelectEventsSink_OnPreSelectEventHandler((object) this, (UIntPtr) __methodptr(SelectEvents_OnPreSelect));
//      this.m_selectEvents.add_OnPreSelect(this.m_Select_OnPreSelect_Delegate);
//      // ISSUE: method pointer
//     // this.m_Select_OnSelect_Delegate = new SelectEventsSink_OnSelectEventHandler((object) this, (UIntPtr) __methodptr(SelectEvents_OnSelect));
//      this.m_selectEvents.add_OnSelect(this.m_Select_OnSelect_Delegate);
//      // ISSUE: method pointer
//      //this.m_Select_OnUnSelect_Delegate = new SelectEventsSink_OnUnSelectEventHandler((object) this, (UIntPtr) __methodptr(SelectEvents_OnUnSelect));
//      this.m_selectEvents.add_OnUnSelect(this.m_Select_OnUnSelect_Delegate);
//      this.m_selectEvents.PreSelectBurnThrough = true;
//      eventType = (object) this.m_selectEvents;
//    }

//    public void UnsubscribeFromEvents()
//    {
//      for (int index = 0; index < this.m_interactionTypes.Count; ++index)
//      {
//        if ((Interaction.InteractionTypeEnum) this.m_interactionTypes[index] == Interaction.InteractionTypeEnum.kSelection && this.m_selectEvents != null)
//        {
//          this.m_selectEvents.remove_OnPreSelect(this.m_Select_OnPreSelect_Delegate);
//          this.m_selectEvents.remove_OnSelect(this.m_Select_OnSelect_Delegate);
//          this.m_selectEvents.remove_OnUnSelect(this.m_Select_OnUnSelect_Delegate);
//          this.m_selectEvents = null;
//        }
//      }
//      this.m_interactionTypes.Clear();
//    }

//    public void EnableInteraction()
//    {
//      for (int index = 0; index < this.m_interactionTypes.Count; ++index)
//      {
//        if ((Interaction.InteractionTypeEnum) this.m_interactionTypes[index] == Interaction.InteractionTypeEnum.kSelection && this.m_selectEvents == null)
//        {
//          this.m_selectEvents = this.m_interactionEvents.SelectEvents;
//          this.m_selectEvents.add_OnPreSelect(this.m_Select_OnPreSelect_Delegate);
//          this.m_selectEvents.add_OnSelect(this.m_Select_OnSelect_Delegate);
//          this.m_selectEvents.add_OnUnSelect(this.m_Select_OnUnSelect_Delegate);
//          this.m_selectEvents.PreSelectBurnThrough = true;
//        }
//      }
//    }

//    public void DisableInteraction()
//    {
//      for (int index = 0; index < this.m_interactionTypes.Count; ++index)
//      {
//        if ((Interaction.InteractionTypeEnum) this.m_interactionTypes[index] == Interaction.InteractionTypeEnum.kSelection && this.m_selectEvents != null)
//        {
//          this.m_selectEvents.remove_OnPreSelect(this.m_Select_OnPreSelect_Delegate);
//          this.m_selectEvents.remove_OnSelect(this.m_Select_OnSelect_Delegate);
//          this.m_selectEvents.remove_OnUnSelect(this.m_Select_OnUnSelect_Delegate);
//          this.m_selectEvents = null;
//        }
//      }
//    }

//    public void SetParentCmd(Command parentCmd) => this.m_parentCmd = parentCmd;

//    public void InteractionEvents_OnTerminate() => this.m_parentCmd.StopCommand();

//    public void InteractionEvents_OnHelp(
//      EventTimingEnum beforeOrAfter,
//      INameValueMap context,
//      out HandlingCodeEnum handlingCode)
//    {
//      this.m_parentCmd.OnHelp(beforeOrAfter, context, out handlingCode);
//    }

//    public void SelectEvents_OnPreSelect(
//      ref object preSelectEntity,
//      out bool doHighlight,
//      ref IObjectCollection morePreSelectEntities,
//      SelectionDeviceEnum selectionDevice,
//      IPoint modelPosition,
//      IPoint2d viewPosition,
//      IView view)
//    {
//      this.m_parentCmd.OnPreSelect(ref preSelectEntity, out doHighlight, ref morePreSelectEntities, selectionDevice, modelPosition, viewPosition, view);
//    }

//    public void SelectEvents_OnSelect(
//      IObjectsEnumerator justSelectedEntities,
//      SelectionDeviceEnum selectionDevice,
//      IPoint modelPosition,
//      IPoint2d viewPosition,
//      IView view)
//    {
//      this.m_parentCmd.OnSelect(justSelectedEntities, selectionDevice, modelPosition, viewPosition, view);
//    }

//    public void SelectEvents_OnUnSelect(
//      IObjectsEnumerator unSelectedEntities,
//      SelectionDeviceEnum selectionDevice,
//      IPoint modelPosition,
//      IPoint2d viewPosition,
//      IView view)
//    {
//      this.m_parentCmd.OnUnSelect(unSelectedEntities, selectionDevice, modelPosition, viewPosition, view);
//    }

//    internal enum InteractionTypeEnum
//    {
//      kSelection,
//      kMouse,
//      kKeyboard,
//      kTriad,
//    }
//  }