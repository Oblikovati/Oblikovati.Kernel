using Oblikovati.Addin.Tutorials.Properties;
using Oblikovati.Domain.Core;

namespace Oblikovati.Addin.Tutorials;

internal class TutorialsGalleryCmd : Command
  {
    private static Bitmap _smallSelectPicture;
    private static Bitmap _largeSelectPicture;
    public static string TutorialGalleryCmdName = "TutorialGalleryCmd";
    public static string TutorialGalleryWebViewName = "InventorTutorialGallery";
    private IWebView _webView;

    public static bool IsLightTheme { get; private set; }

    public string GalleryURL { get; set; }

    public TutorialsGalleryCmd(
      InteractiveTutorialServer interactiveTutorialServer)
      : base(interactiveTutorialServer)
    {
      this.GalleryURL = this.InteractiveTutorialServerObj.TEEventsHandler.TutorialsApiHelper.GetTutorialGalleryURL();
    }

    public IWebView GetWebView() => this._webView;

    public void CreateButton()
    {
        this.InteractiveTutorialServerObj.InventorApplication.ApplicationEvents.add_OnApplicationOptionChange(OnApplicationOptionChange);
      TutorialsGalleryCmd.IsLightTheme = this.InteractiveTutorialServerObj.InventorTheme == "LightTheme";
      if (TutorialsGalleryCmd.IsLightTheme)
      {
       // TutorialsGalleryCmd._smallSelectPicture = PictureDispConverter.ToIPictureDisp(TutorialAddinResources.INV_CreateTutorial_16x16);
        //TutorialsGalleryCmd._largeSelectPicture = PictureDispConverter.ToIPictureDisp(TutorialAddinResources.INV_CreateTutorial_32x32);
      }
      else
      {
       // TutorialsGalleryCmd._smallSelectPicture = PictureDispConverter.ToIPictureDisp(TutorialAddinResources.INV_CreateTutorial_16x16_DARK);
       // TutorialsGalleryCmd._largeSelectPicture = PictureDispConverter.ToIPictureDisp(TutorialAddinResources.INV_CreateTutorial_32x32_DARK);
      }


      this.ButtonDefinition.ToolTipText = Resources.TutorialGalleryCmdTooltip;
    }

    private void ApplicationEvents_OnCloseWebView(
      IWebView ViewObject,
      EventTimingEnum BeforeOrAfter,
      INameValueMap Context,
      out HandlingCodeEnum HandlingCode)
    {
      if (string.Compare(ViewObject.InternalName, TutorialsGalleryCmd.TutorialGalleryWebViewName, StringComparison.OrdinalIgnoreCase) == 0)
      {
        this._webView = null;
        this.InteractiveTutorialServerObj.MApplicationEvents.remove_OnCloseWebView(ApplicationEvents_OnCloseWebView);
        HandlingCode = HandlingCodeEnum.kEventHandled;
      }
      else
        HandlingCode = HandlingCodeEnum.kEventNotHandled;
    }

    private bool isLwsServerRunningWell() => LocalWebService.PingServer() && this.InteractiveTutorialServerObj.TEEventsHandler.Init() && !this.InteractiveTutorialServerObj.TEEventsHandler.isHttpPortOccupied();

    protected override void ButtonDefinition_OnExecute(INameValueMap context)
    {
      try
      {
        this.InteractiveTutorialServerObj.InventorApplication.Login();
        if (this._webView == null)
        {
          this._webView = this._application.WebViews.Add((object) TutorialsGalleryCmd.TutorialGalleryWebViewName);
          this._webView.Caption = Resources.TutorialGalleryTabName;
          this.InteractiveTutorialServerObj.MApplicationEvents.remove_OnCloseWebView(ApplicationEvents_OnCloseWebView);
          this.InteractiveTutorialServerObj.MApplicationEvents.add_OnCloseWebView(ApplicationEvents_OnCloseWebView);
        }
        if (this._webView == null)
          return;
        if (this.isLwsServerRunningWell())
          this._webView.Navigate(this.GalleryURL);
        else if (LocalWebService.Instance().AutoStart())
        {
          if (!LocalWebService.IsRunning())
          {
            int num = (int) MessageBox.Show(Resources.ServiceDown);
          }
          else
            this._webView.Navigate(this.GalleryURL);
        }
        else
          this.InteractiveTutorialServerObj.TEEventsHandler.ShowConnectionFailed();
      }
      catch (Exception ex)
      {
        WindowsAPIs.ShowErrorMessage(ex);
      }
    }

    public override void OnHelp(
      EventTimingEnum beforeOrAfter,
      INameValueMap context,
      out HandlingCodeEnum handlingCode)
    {
      this.InteractiveTutorialServerObj.InventorApplication.HelpManager.DisplayHelpTopic("TutorialGalleryHelp.chm", "");
      handlingCode = HandlingCodeEnum.kEventHandled;
    }

    public override void ExecuteCommand()
    {
      this.StopCommand();
      this.ButtonDefinition_OnExecute((INameValueMap) null);
    }

    private void OnApplicationOptionChange(
      EventTimingEnum BeforeOrAfter,
      INameValueMap Context,
      out HandlingCodeEnum HandlingCode)
    {
      HandlingCode = HandlingCodeEnum.kEventNotHandled;
      if (BeforeOrAfter != EventTimingEnum.kAfter)
        return;
      ITheme activeTheme = this.InteractiveTutorialServerObj.InventorApplication.ThemeManager.ActiveTheme;
      if (TutorialsGalleryCmd.IsLightTheme == activeTheme.Name.Equals("LightTheme"))
        return;
      TutorialsGalleryCmd.IsLightTheme = activeTheme.Name.Equals("LightTheme");
      if (TutorialsGalleryCmd.IsLightTheme)
      {
        //TutorialsGalleryCmd._smallSelectPicture = PictureDispConverter.ToIPictureDisp(TutorialAddinResources.INV_CreateTutorial_16x16);
        //TutorialsGalleryCmd._largeSelectPicture = PictureDispConverter.ToIPictureDisp(TutorialAddinResources.INV_CreateTutorial_32x32);
      }
      else
      {
        //TutorialsGalleryCmd._smallSelectPicture = PictureDispConverter.ToIPictureDisp(TutorialAddinResources.INV_CreateTutorial_16x16_DARK);
        //TutorialsGalleryCmd._largeSelectPicture = PictureDispConverter.ToIPictureDisp(TutorialAddinResources.INV_CreateTutorial_32x32_DARK);
      }
      //this.ButtonDefinition.LargeIcon = TutorialsGalleryCmd._largeSelectPicture;
      //this.ButtonDefinition.StandardIcon = TutorialsGalleryCmd._smallSelectPicture;
    }
  }