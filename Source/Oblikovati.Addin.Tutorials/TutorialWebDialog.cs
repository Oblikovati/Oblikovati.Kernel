using Oblikovati.Domain.Core;

namespace Oblikovati.Addin.Tutorials;

internal class TutorialWebDialog : WebDialog
{
    private readonly InteractiveTutorialServer _addInServer;

    public TutorialWebDialog(InteractiveTutorialServer addInServer)
        : base("TutorialDialog", addInServer.InventorApplication, new UIRect(0, 0, 600, 800))
    {
        this._addInServer = addInServer;
    }

    protected override void GetDialogRect(ref UIRect rect)
    {
    }

    protected override void SetDialogPosition(ref UIRect rect)
    {
        TutorialsGalleryCmd galleryCmdObject = this._addInServer.TutorialsGalleryCmdObject;
        if (galleryCmdObject == null)
            return;
        IWebView webView = galleryCmdObject.GetWebView();
        if (webView == null)
            return;
        rect.Left = Math.Max(webView.Left, 0) + webView.Width / 2 - rect.Width / 2;
        rect.Left = Math.Max(rect.Left, 50);
        rect.Top = webView.Top + webView.Height / 2 - rect.Height / 2;
        rect.Top = Math.Max(rect.Top, 50);
    }

    protected override void FormatUrlValue(ref string value)
    {
    }

    protected override string GetNavigateUrl() => this.Url;

    protected override bool CheckDialogClose(string closingDocFileName) => true;

    protected override void HandleOnClose(EventTimingEnum beforeOrAfter)
    {
        if (beforeOrAfter != EventTimingEnum.kAfter)
            return;
        this.CloseWebDialog();
    }

    protected override void HandleOnHelp()
    {
    }
}