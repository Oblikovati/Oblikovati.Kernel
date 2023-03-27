using System.Runtime.InteropServices;

namespace Oblikovati.Addin.Tutorials;
public class DPI
  {
    private static double _nLogicalPixelsX;
    private static double _nLogicalPixelsY;
    private const int DPI_ONE_LOGICALPIXELS = 96;
    private const int LOGPIXELSX = 88;
    private const int LOGPIXELSY = 90;
    private const int VK_ESCAPE = 27;
    private static bool _bDPIInitialized;

    [DllImport("Gdi32.dll")]
    public static extern int GetDeviceCaps(IntPtr hDc, int idx);

    [DllImport("user32.dll")]
    public static extern IntPtr GetDesktopWindow();

    [DllImport("user32.dll")]
    public static extern IntPtr GetDC(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDc);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern bool GetCursorPos(out DPI.CurPOINT pt);

    [DllImport("user32.dll")]
    public static extern uint GetAsyncKeyState(int vKey);

    public static bool EscapePressed() => (DPI.GetAsyncKeyState(27) & 32768U) > 0U;

    public static void GetCurrentDPI()
    {
      IntPtr desktopWindow = DPI.GetDesktopWindow();
      IntPtr dc = DPI.GetDC(desktopWindow);
      DPI._nLogicalPixelsX = (double) DPI.GetDeviceCaps(dc, 88);
      DPI._nLogicalPixelsY = (double) DPI.GetDeviceCaps(dc, 90);
      DPI.ReleaseDC(desktopWindow, dc);
      DPI._bDPIInitialized = true;
    }

    public static void Scale(ref double x, ref double y)
    {
      if (!DPI._bDPIInitialized)
        DPI.GetCurrentDPI();
      x = x * DPI._nLogicalPixelsX / 96.0;
      y = y * DPI._nLogicalPixelsY / 96.0;
    }

    public static void Scale(ref int x, ref int y)
    {
      double x1 = (double) x;
      double y1 = (double) y;
      DPI.Scale(ref x1, ref y1);
      x = Convert.ToInt32(x1);
      y = Convert.ToInt32(y1);
    }

    public static void Unscale(ref double x, ref double y)
    {
      if (!DPI._bDPIInitialized)
        DPI.GetCurrentDPI();
      x = x * 96.0 / DPI._nLogicalPixelsX;
      y = y * 96.0 / DPI._nLogicalPixelsY;
    }

    public static void Unscale(ref int x, ref int y)
    {
      double x1 = (double) x;
      double y1 = (double) y;
      DPI.Unscale(ref x1, ref y1);
      x = Convert.ToInt32(x1);
      y = Convert.ToInt32(y1);
    }

    public struct CurPOINT
    {
      public int X;
      public int Y;

      public CurPOINT(int x, int y)
      {
        this.X = x;
        this.Y = y;
      }
    }
  }