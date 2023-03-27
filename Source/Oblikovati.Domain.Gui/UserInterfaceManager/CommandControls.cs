using Oblikovati.Domain.Core;
using Oblikovati.Domain.UiControls;

namespace Oblikovati.Domain.Gui.UserInterfaceManager;

public class CommandControls : List<ICommandControl>, ICommandControls
{
    public CommandControls(IApplication application, object parent)
    {
        Application = application;
        Parent = parent;
    }
    public IApplication Application { get; }
    public object Parent { get; }
    public ICommandControl this[string Index] => this.First(p => p.InternalName.Equals(Index));

    public ICommandControl AddButton(IButtonDefinition ButtonDefinition, bool UseLargeIcon, bool ShowText,
        string TargetControlInternalName = "", bool InsertBeforeTargetControl = false)
    {
        var cc = new ObRibbonButton(Application, this, ButtonDefinition.InternalName, ControlTypeEnum.kButtonControl,
            ButtonDefinition, UseLargeIcon);

        if(InsertBeforeTargetControl)
            Insert(IndexOf(this[TargetControlInternalName]),cc);
        else
            Add(cc);
        if (Parent is IRibbonPanel panel)
            panel.RefreshControls();

        return cc;
    }

    public ICommandControl AddButtonPopup(IObjectCollection ButtonDefinitions, bool UseLargeIcon, bool ShowText,
        string TargetControlInternalName = "", bool InsertBeforeTargetControl = false)
    {
        CommandControl cc = null;
        foreach (var item in ButtonDefinitions)
        {
               var ButtonDefinition = item as IButtonDefinition;
               if (cc is null)
               {
                   cc = new CommandControl(Application,ButtonDefinition.DisplayName,ButtonDefinition.InternalName);
                   cc.ControlType = ControlTypeEnum.kButtonControl;
                   cc.UseLargeIcon = UseLargeIcon;
                   cc.Visible = true;
                   cc.ControlDefinition = ButtonDefinition;
                   cc.DisplayedControl = cc.ControlDefinition;
                   cc.ShowText = ShowText;
                   cc.InternalName = ButtonDefinition.InternalName;
               }
               else
               {
                    cc.ChildControls.Add(cc);
               }

        }
        
        if(InsertBeforeTargetControl)
            Insert(IndexOf(this[TargetControlInternalName]),cc);
        else
            Add(cc);
        return cc;
    }

    public ICommandControl AddComboBox(IComboBoxDefinition ComboBoxDefinition, string TargetControlInternalName = "",
        bool InsertBeforeTargetControl = false)
    {
        var cc = new CommandControl(Application,ComboBoxDefinition.DisplayName,ComboBoxDefinition.InternalName);
        cc.ControlType = ControlTypeEnum.kButtonControl;
        cc.Visible = true;
        cc.ControlDefinition = ComboBoxDefinition;
        cc.DisplayedControl = cc.ControlDefinition;
        cc.InternalName = ComboBoxDefinition.InternalName;
        if(InsertBeforeTargetControl)
            Insert(IndexOf(this[TargetControlInternalName]),cc);
        else
            Add(cc);
        return cc;
    }

    public ICommandControl AddMacro(IMacroControlDefinition MacroControlDefinition, bool UseLargeIcon, bool ShowText,
        string TargetControlInternalName = "", bool InsertBeforeTargetControl = false)
    {
        throw new NotImplementedException();
    }

    public ICommandControl AddPopup(IButtonDefinition DisplayedControl, IObjectCollection ButtonDefinitions, bool UseLargeIcon,
        bool ShowText, string TargetControlInternalName = "", bool InsertBeforeTargetControl = false)
    {
        throw new NotImplementedException();
    }

    public ICommandControl AddSeparator(string TargetControlInternalName, bool InsertBeforeTargetControl = false)
    {
        throw new NotImplementedException();
    }

    public ICommandControl AddSplitButton(IButtonDefinition DisplayedControl, IObjectCollection ButtonDefinitions,
        bool UseLargeIcon, bool ShowText, string TargetControlInternalName = "", bool InsertBeforeTargetControl = false)
    {
        var cc = new CommandControl(Application,DisplayedControl.DisplayName,DisplayedControl.InternalName);
        cc.ControlType = ControlTypeEnum.kSplitButtonControl;
        cc.UseLargeIcon = UseLargeIcon;
        cc.Visible = true;
        cc.ControlDefinition = DisplayedControl;
        cc.DisplayedControl = cc.ControlDefinition;
        cc.ShowText = ShowText;
        cc.InternalName = DisplayedControl.InternalName;
        foreach (var item in ButtonDefinitions)
        {
            var bd = item as IButtonDefinition;
            var cci = new CommandControl(Application,bd.DisplayName,bd.InternalName);
            cci.ControlType = ControlTypeEnum.kButtonControl;
            cci.UseLargeIcon = false;
            cci.Visible = true;
            cci.ControlDefinition = bd;
            cci.DisplayedControl = cci.ControlDefinition;
            cci.ShowText = ShowText;
            cci.InternalName = bd.InternalName;
            cc.ChildControls.Add(cci);
        }
        if(InsertBeforeTargetControl)
            Insert(IndexOf(this[TargetControlInternalName]),cc);
        else
            Add(cc);
        return cc;
    }

    public ICommandControl AddSplitButtonMRU(IObjectCollection ButtonDefinitions, bool UseLargeIcon, bool ShowText,
        string TargetControlInternalName = "", bool InsertBeforeTargetControl = false)
    {
        throw new NotImplementedException();
    }

    public ICommandControl AddGallery(IObjectCollection ButtonDefinitions, bool DisplayAsComboBox, int Width,
        string TargetControlInternalName = "", bool InsertBeforeTargetControl = false)
    {
        throw new NotImplementedException();
    }

    public ICommandControl AddTogglePopup(IButtonDefinition DisplayedControl, IObjectCollection ButtonDefinitions,
        bool UseLargeIcon, bool ShowText, string TargetControlInternalName = "", bool InsertBeforeTargetControl = false)
    {
        throw new NotImplementedException();
    }

    public ICommandControl AddCopy(ICommandControl CommandControl, string TargetControlInternalName = "",
        bool InsertBeforeTargetControl = false)
    {
        throw new NotImplementedException();
    }
}