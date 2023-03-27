using System.Globalization;
using System.Net;

namespace Oblikovati.Addin.Tutorials;

public static class TEUtil
{
    public static void DownloadFile(string url, string sFileName)
    {
        try
        {
            new WebClient().DownloadFile(new Uri(url), sFileName);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public static void UpdateCulture()
    {
        if (CultureInfo.CurrentCulture.LCID == InteractiveTutorialServer.Instance.InventorApplication.Locale)
            return;
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(InteractiveTutorialServer.Instance.InventorApplication.Locale);
    }
}