using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    [Serializable]
    class Figura6 : Shape
    {
        #region Constructor
        public Figura6(RectangleF elp) : base(elp)
        {
        }
        public Figura6(RectangleShape ellipse) : base(ellipse)
        {
        }
        #endregion
        public override bool Contains(PointF point)
        {
            if (base.Contains(point))
            {
                float a = Width / 2;
                float b = Height / 2;
                float x0 = Location.X + a;
                float y0 = Location.Y + b;

                return Math.Pow((point.X - x0) / a, 2) + Math.Pow((point.Y - y0) / b, 2) - 1 <= 0;
            }
            else
                return false;
        }

        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
            grfx.FillEllipse(new SolidBrush(FillColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            grfx.DrawEllipse(new Pen(Color.Black), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            grfx.ResetTransform();
            Point[] one = {
                new Point((int)(Rectangle.X+15), (int)Rectangle.Y+15),
                new Point((int)(Rectangle.X +100), (int)(Rectangle.Bottom -50))};
            grfx.DrawLines(Pens.Black, one);
            Point[] two = {
                new Point((int)(Rectangle.X + 85), (int)Rectangle.Y+85),
                new Point((int)(Rectangle.X ), (int)(Rectangle.Bottom -50))};
            grfx.DrawLines(Pens.Black, two);
        }

    }
}
