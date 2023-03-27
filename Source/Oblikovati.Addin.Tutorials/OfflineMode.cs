using Microsoft.Win32;

namespace Oblikovati.Addin.Tutorials;

internal class OfflineMode
{
    private const string INVREG_KEYBASE = @"SOFTWARE\\Oblikovati";
    private const string INVREG_KEY = @"SOFTWARE\\Oblikovati\\Current Version";
    private const string INVREG_REGVER = @"RegistryVersion";
    private const string ENABLE_COLLABORATION_KEY = "EnableCollaboration";
    private static bool _offlineInstallation;

    public static bool Value => OfflineMode._offlineInstallation;

    public static void Init()
    {
        var name = @"SOFTWARE\\Autodesk\\Inventor\\" + (string) Registry.CurrentUser.OpenSubKey(@"SOFTWARE\\Oblikovati\\Current Version").GetValue("RegistryVersion");
        var registryKey = Registry.LocalMachine.OpenSubKey(name);
        if (registryKey == null)
            return;
        var obj = registryKey.GetValue("EnableCollaboration");
        _offlineInstallation = obj != null && (int) obj == 0;
    }
}