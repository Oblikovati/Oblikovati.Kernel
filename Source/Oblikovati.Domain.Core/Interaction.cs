//namespace Oblikovati.Domain.Core;

//public class Interaction
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
//      m_interactionTypes = new ArrayList();
//      m_interactionEvents = null;
//      m_selectEvents = null;
//      m_parentCmd = null;
//    }

//    public void StartInteraction(
//      string interactionName,
//      out IInteractionEvents interactionEvents)
//    {
//      try
//      {
//        if (application.ActiveDocument is null)
//          return;
//        m_interactionEvents = application.CommandManager.CreateInteractionEvents();
//        m_interactionEvents.SelectionActive = true;
//        m_interactionEvents.Name = interactionName;
//        //this.m_interaction_OnTerminate_Delegate = new InteractionEventsSink_OnTerminateEventHandler(this, (UIntPtr) __methodptr(InteractionEvents_OnTerminate));
//        m_interactionEvents.add_OnTerminate(m_interaction_OnTerminate_Delegate);
//        //this.m_interaction_OnHelp_Delegate += InteractionEvents_OnHelp;
//        m_interactionEvents.add_OnHelp(m_interaction_OnHelp_Delegate);
//        m_selectEvents = m_interactionEvents.SelectEvents;
//        m_interactionEvents.Start();
//      }
//      catch (Exception ex)
//      {
//        //int num = (int) MessageBox.Show(ex.ToString());
//      }
//      finally
//      {
//        interactionEvents = m_interactionEvents;
//      }
//    }

//    public void StopInteraction()
//    {
//      if (m_interactionEvents == null)
//        return;
//      m_interactionEvents.remove_OnTerminate(m_interaction_OnTerminate_Delegate);
//      m_interactionEvents.remove_OnHelp(m_interaction_OnHelp_Delegate);
//      m_interactionEvents.Stop();
//      m_interactionEvents = null;
//    }

//    public void SubscribeToEvent(
//      InteractionTypeEnum interactionType,
//      ref object eventType)
//    {
//      for (var index = 0; index < m_interactionTypes.Count; ++index)
//      {
//        if (interactionType == (InteractionTypeEnum) m_interactionTypes[index])
//          return;
//      }
//      m_interactionTypes.Add((object) interactionType);
//      if (interactionType != InteractionTypeEnum.kSelection)
//        return;
//      m_selectEvents = m_interactionEvents.SelectEvents;
//      if (m_selectEvents == null)
//        return;
//      //this.m_Select_OnPreSelect_Delegate = new SelectEventsSink_OnPreSelectEventHandler((object) this, (UIntPtr) __methodptr(SelectEvents_OnPreSelect));
//      m_selectEvents.add_OnPreSelect(m_Select_OnPreSelect_Delegate);
//      // this.m_Select_OnSelect_Delegate = new SelectEventsSink_OnSelectEventHandler((object) this, (UIntPtr) __methodptr(SelectEvents_OnSelect));
//      m_selectEvents.add_OnSelect(m_Select_OnSelect_Delegate);
//      //this.m_Select_OnUnSelect_Delegate = new SelectEventsSink_OnUnSelectEventHandler((object) this, (UIntPtr) __methodptr(SelectEvents_OnUnSelect));
//      m_selectEvents.add_OnUnSelect(m_Select_OnUnSelect_Delegate);
//      m_selectEvents.PreSelectBurnThrough = true;
//      eventType = m_selectEvents;
//    }

//    public void UnsubscribeFromEvents()
//    {
//      for (int index = 0; index < m_interactionTypes.Count; ++index)
//      {
//        if ((InteractionTypeEnum) m_interactionTypes[index] == InteractionTypeEnum.kSelection && m_selectEvents != null)
//        {
//          m_selectEvents.remove_OnPreSelect(m_Select_OnPreSelect_Delegate);
//          m_selectEvents.remove_OnSelect(m_Select_OnSelect_Delegate);
//          m_selectEvents.remove_OnUnSelect(m_Select_OnUnSelect_Delegate);
//          m_selectEvents = null;
//        }
//      }
//      m_interactionTypes.Clear();
//    }

//    public void EnableInteraction()
//    {
//      for (int index = 0; index < m_interactionTypes.Count; ++index)
//      {
//        if ((InteractionTypeEnum) m_interactionTypes[index] == InteractionTypeEnum.kSelection && m_selectEvents == null)
//        {
//          m_selectEvents = m_interactionEvents.SelectEvents;
//          m_selectEvents.add_OnPreSelect(m_Select_OnPreSelect_Delegate);
//          m_selectEvents.add_OnSelect(m_Select_OnSelect_Delegate);
//          m_selectEvents.add_OnUnSelect(m_Select_OnUnSelect_Delegate);
//          m_selectEvents.PreSelectBurnThrough = true;
//        }
//      }
//    }

//    public void DisableInteraction()
//    {
//      for (int index = 0; index < m_interactionTypes.Count; ++index)
//      {
//        if ((InteractionTypeEnum) m_interactionTypes[index] == InteractionTypeEnum.kSelection && m_selectEvents != null)
//        {
//          m_selectEvents.remove_OnPreSelect(m_Select_OnPreSelect_Delegate);
//          m_selectEvents.remove_OnSelect(m_Select_OnSelect_Delegate);
//          m_selectEvents.remove_OnUnSelect(m_Select_OnUnSelect_Delegate);
//          m_selectEvents = null;
//        }
//      }
//    }

//    public void SetParentCmd(Command parentCmd) => m_parentCmd = parentCmd;

//    public void InteractionEvents_OnTerminate() => m_parentCmd.StopCommand();

//    public void InteractionEvents_OnHelp(
//      EventTimingEnum beforeOrAfter,
//      INameValueMap context,
//      out HandlingCodeEnum handlingCode)
//    {
//      m_parentCmd.OnHelp(beforeOrAfter, context, out handlingCode);
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
//      m_parentCmd.OnPreSelect(ref preSelectEntity, out doHighlight, ref morePreSelectEntities, selectionDevice, modelPosition, viewPosition, view);
//    }

//    public void SelectEvents_OnSelect(
//      IObjectsEnumerator justSelectedEntities,
//      SelectionDeviceEnum selectionDevice,
//      IPoint modelPosition,
//      IPoint2d viewPosition,
//      IView view)
//    {
//      m_parentCmd.OnSelect(justSelectedEntities, selectionDevice, modelPosition, viewPosition, view);
//    }

//    public void SelectEvents_OnUnSelect(
//      IObjectsEnumerator unSelectedEntities,
//      SelectionDeviceEnum selectionDevice,
//      IPoint modelPosition,
//      IPoint2d viewPosition,
//      IView view)
//    {
//      m_parentCmd.OnUnSelect(unSelectedEntities, selectionDevice, modelPosition, viewPosition, view);
//    }

//    public enum InteractionTypeEnum
//    {
//      kSelection,
//      kMouse,
//      kKeyboard,
//      kTriad,
//    }
//  }