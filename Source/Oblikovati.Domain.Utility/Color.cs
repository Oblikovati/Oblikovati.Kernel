using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Utility;

public class Color : IColor
{
    public byte Blue { get; set; }
    public byte Green { get; set; }
    public double Opacity { get; set; }
    public byte Red { get; set; }
    public ColorSourceTypeEnum ColorSourceType { get; set; }
    public void GetColor(out byte Red, out byte Green, out byte Blue)
    {
        Red = this.Red;
        Green = this.Green;
        Blue = this.Blue;
    }

    public void SetColor(byte Red, byte Green, byte Blue)
    {
        this.Red = Red;
        this.Green = Green;
        this.Blue = Blue;
    }

}