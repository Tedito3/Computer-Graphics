using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{ 
[Serializable]
public class Figura1 : Shape
{

    #region Constructor

    public Figura1(RectangleF circ) : base(circ)
    {

    }
    #endregion
    public override bool Contains(PointF point)
    {

        if (base.Contains(point))
            // Проверка дали е в обекта само, ако точката е в обхващащия правоъгълник.
            // В случая на правоъгълник - директно връщаме true

            return true;
        else
            // Ако не е в обхващащия правоъгълник, то неможе да е в обекта и => false
            return false;
    }

    public override void DrawSelf(Graphics grfx)
    {
        base.DrawSelf(grfx);
        grfx.DrawEllipse(Pens.Black, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
        grfx.FillEllipse(new SolidBrush(FillColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
        Point[] one = {
                new Point((int)(Rectangle.X + 15), (int)Rectangle.Y+15),
                new Point((int)(Rectangle.X + Rectangle.Width - 50), (int)(Rectangle.Bottom - 50))};
        grfx.DrawLines(Pens.Black, one);

        Point[] two = {
                 new Point((int)(Rectangle.X + 15), (int)Rectangle.Y + 85),
                new Point((int)(Rectangle.X + Rectangle.Width - 50), (int)(Rectangle.Bottom - 50))};
        grfx.DrawLines(Pens.Black, two);

        Point[] three = {
                new Point((int)(Rectangle.X + Rectangle.Width -50), (int)Rectangle.Bottom - 50),
                new Point((int)(Rectangle.X + Rectangle.Width - 15), (int)(Rectangle.Y + 85))};
        grfx.DrawLines(Pens.Black, three);
    }
}
}
