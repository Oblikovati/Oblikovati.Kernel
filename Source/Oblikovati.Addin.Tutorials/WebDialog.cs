using Oblikovati.Domain.Core;

namespace Oblikovati.Addin.Tutorials;

public abstract class WebDialog
  {
    private IApplication _inventorApp;
    private IWebBrowserDialogs _webBrowserDialogs;
    private IWebBrowserDialog _webBrowserDialog;
    private IWebBrowserDialogEvents _webBrowserDialogEvents;
    private string _strUrl;
    private string _internalName;
    private UIRect _defaultRect;

    protected abstract void GetDialogRect(ref UIRect rect);

    protected abstract void SetDialogPosition(ref UIRect rect);

    protected abstract void FormatUrlValue(ref string value);

    protected abstract string GetNavigateUrl();

    protected abstract bool CheckDialogClose(string closingDocFileName);

    protected abstract void HandleOnClose(EventTimingEnum beforeOrAfter);

    protected abstract void HandleOnHelp();

    protected string Url
    {
      get => this._strUrl;
      set
      {
        this.FormatUrlValue(ref value);
        this._strUrl = value;
      }
    }

    protected IWebBrowserDialog WebBrowserDialog => this._webBrowserDialog;

    public WebDialog(string internalName, IApplication inventorApp, UIRect defaultRect)
    {
      this._webBrowserDialogs = null;
      this._webBrowserDialog =  null;
      this._inventorApp = inventorApp;
      this._webBrowserDialogEvents =  null;
      this._internalName = internalName;
      this._defaultRect = defaultRect;
    }

    public void SetUrl(string strUrl)
    {
      if (string.IsNullOrEmpty(strUrl))
        return;
      this.Url = strUrl;
    }

    public void Refresh()
    {
      if (this._webBrowserDialog == null || !this._webBrowserDialog.Visible)
        return;
      this.NavigateToUrl();
    }

    public void ResizeDialog(int width, int height)
    {
      if (width <= 0 || height <= 0 || this._webBrowserDialog == null)
        return;
      DPI.Scale(ref width, ref height);
      this._webBrowserDialog.Width = width;
      this._webBrowserDialog.Height = height;
    }

    private void CreateWebDialog(UIRect defaultRect)
    {
      try
      {
        if (this._inventorApp == null)
          return;
        if (this._webBrowserDialogs == null)
          this._webBrowserDialogs = this._inventorApp.WebBrowserDialogs;
        this._webBrowserDialog = this._webBrowserDialogs[_internalName];
        if (this._webBrowserDialog == null)
          this._webBrowserDialog = this._webBrowserDialogs.Add(_internalName,false);
        this._webBrowserDialog.WindowState = WindowsSizeEnum.kNormalWindow;
        UIRect rect = new UIRect();
        this.GetDialogRect(ref rect);
        if (!rect.IsValid())
        {
          rect = defaultRect == null ? this._defaultRect : defaultRect;
          DPI.Scale(ref rect.Width, ref rect.Height);
          this.SetDialogPosition(ref rect);
        }
        this._webBrowserDialog.Height = rect.Height;
        this._webBrowserDialog.Left = rect.Left;
        this._webBrowserDialog.Top = rect.Top;
        this._webBrowserDialog.Width = rect.Width;
        this._webBrowserDialogEvents = this._webBrowserDialog.WebBrowserDialogEvents;
        // ISSUE: method pointer
        //this._webBrowserDialogEvents.add_OnClose(new WebBrowserDialogEventsSink_OnCloseEventHandler((object) this, (UIntPtr) __methodptr(WebBrowserDialogEvents_OnClose)));
        // ISSUE: method pointer
        //this._webBrowserDialogEvents.add_OnHelp(new WebBrowserDialogEventsSink_OnHelpEventHandler((object) this, (UIntPtr) __methodptr(WebBrowserDialogEvents_OnHelp)));
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    private void NavigateToUrl()
    {
      try
      {
        if (this._webBrowserDialog == null)
          return;
        this._webBrowserDialog.Navigate(this.GetNavigateUrl());
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    public void ShowWebDialog(UIRect rect = null)
    {
      try
      {
        this.CreateWebDialog(rect);
        if (this._webBrowserDialog == null)
          return;
        this.NavigateToUrl();
        this._webBrowserDialog.Visible = true;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    public void CloseWebDialog()
    {
      try
      {
        if (this._webBrowserDialogEvents != null)
        {
          // ISSUE: method pointer
          //this._webBrowserDialogEvents.remove_OnHelp(new WebBrowserDialogEventsSink_OnHelpEventHandler((object) this, (UIntPtr) __methodptr(WebBrowserDialogEvents_OnHelp)));
          // ISSUE: method pointer
          //this._webBrowserDialogEvents.remove_OnClose(new WebBrowserDialogEventsSink_OnCloseEventHandler((object) this, (UIntPtr) __methodptr(WebBrowserDialogEvents_OnClose)));
          this._webBrowserDialogEvents = (IWebBrowserDialogEvents) null;
        }
        if (this._webBrowserDialog == null)
          return;
        this._webBrowserDialog.Visible = false;
        this._webBrowserDialog.Delete();
        this._webBrowserDialog = (IWebBrowserDialog) null;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    public bool ShouldDialogBeClosed(string closingDocFileName)
    {
      try
      {
        return this._webBrowserDialog != null && this.CheckDialogClose(closingDocFileName);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
        return false;
      }
    }

    private void WebBrowserDialogEvents_OnClose(
      EventTimingEnum beforeOrAfter,
      INameValueMap context,
      out HandlingCodeEnum handlingCode)
    {
      handlingCode = HandlingCodeEnum.kEventNotHandled;
      this.HandleOnClose(beforeOrAfter);
    }

    private void WebBrowserDialogEvents_OnHelp(
      INameValueMap context,
      out HandlingCodeEnum handlingCode)
    {
      handlingCode = HandlingCodeEnum.kEventHandled;
      this.HandleOnHelp();
    }
  }