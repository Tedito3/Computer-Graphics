using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    class Figura5 : Shape
    {
        #region Constructor

        public Figura5(RectangleF rect) : base(rect)
        {
        }

        public Figura5(RectangleShape rectangle) : base(rectangle)
        {
        }
        #endregion
        public override bool Contains(PointF point)
        {
            if (base.Contains(point))
                return true;
            else
                return false;
        }
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
            grfx.FillRectangle(new SolidBrush(FillColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            grfx.DrawRectangle(Pens.Black, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            Point[] one = {
                new Point((int)(Rectangle.X + 50), (int)Rectangle.Y),
                new Point((int)(Rectangle.X + Rectangle.Width - 100), (int)(Rectangle.Bottom - 50))};
            grfx.DrawLines(Pens.Black, one);
            Point[] two = {
                new Point((int)(Rectangle.X + 50), (int)Rectangle.Y+100),
                new Point((int)(Rectangle.X + Rectangle.Width -100), (int)(Rectangle.Bottom -50))};
            grfx.DrawLines(Pens.Black, two);
        }
    }
}

