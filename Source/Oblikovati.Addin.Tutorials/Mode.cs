namespace Oblikovati.Addin.Tutorials;

internal class Mode
{
    private static string _val;

    public static string Value
    {
        get
        {
            if (Mode._val == null)
                Mode._val = !OfflineMode.Value ? "enabled" : "offline";
            return Mode._val;
        }
    }
}