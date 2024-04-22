using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    class Figura3 : Shape
    {
        #region Constructor

        public Figura3(RectangleF circ) : base(circ)
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
            grfx.DrawEllipse(Pens.Black, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            grfx.FillEllipse(new SolidBrush(FillColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            Point[] one = {
                new Point((int)(Rectangle.X + 50), (int)Rectangle.Y),
                new Point((int)(Rectangle.X + Rectangle.Width - 100), (int)(Rectangle.Bottom - 50))};
            grfx.DrawLines(Pens.Black, one);
            Point[] two = {
                new Point((int)(Rectangle.X + 15), (int)Rectangle.Y+15),
                new Point((int)(Rectangle.X + Rectangle.Width - 50), (int)(Rectangle.Bottom - 50))};
            grfx.DrawLines(Pens.Black, two);
            Point[] four = {
                 new Point((int)(Rectangle.X + 15), (int)Rectangle.Y + 85),
                new Point((int)(Rectangle.X + Rectangle.Width - 50), (int)(Rectangle.Bottom - 50))};
            grfx.DrawLines(Pens.Black, four);
            Point[] three = {
                new Point((int)(Rectangle.X + Rectangle.Width -50), (int)Rectangle.Bottom - 50),
                new Point((int)(Rectangle.X + Rectangle.Width - 15), (int)(Rectangle.Y + 85))};
            grfx.DrawLines(Pens.Black, three);
            
        }
    }
}
