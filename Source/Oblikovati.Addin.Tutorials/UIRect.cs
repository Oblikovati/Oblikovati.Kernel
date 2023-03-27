namespace Oblikovati.Addin.Tutorials;

public class UIRect
{
    public int Top;
    public int Left;
    public int Height;
    public int Width;

    public UIRect()
        : this(0, 0, 0, 0)
    {
    }

    public UIRect(int t, int l, int h, int w)
    {
        this.Top = t;
        this.Left = l;
        this.Height = h;
        this.Width = w;
    }

    public override string ToString() => "" + this.Top.ToString() + " " + this.Left.ToString() + " " + this.Height.ToString() + " " + this.Width.ToString();

    public bool Parse(string str)
    {
        string[] strArray = str.Split(' ');
        if (strArray == null || strArray.Length != 4)
            return false;
        this.Top = Convert.ToInt32(strArray[0]);
        this.Left = Convert.ToInt32(strArray[1]);
        this.Height = Convert.ToInt32(strArray[2]);
        this.Width = Convert.ToInt32(strArray[3]);
        return true;
    }

    public bool IsValid() => this.Width > 0 && this.Height > 0;
}