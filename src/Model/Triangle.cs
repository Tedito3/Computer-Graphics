using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    class Triangle : Shape
    {
        #region Constructor

        public Triangle(RectangleF tri) : base(tri)
        {
        }

        public Triangle(Triangle triangle) : base(triangle)
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
            Point[] p = { new Point((int)Rectangle.X + ((int)Rectangle.Width / 2), (int)Rectangle.Y), new Point((int)Rectangle.X, (int)(Rectangle.Y + Rectangle.Height)), new Point((int)(Rectangle.X + Rectangle.Width), (int)(Rectangle.Y + Rectangle.Height)) };
            Pen blackPen = new Pen(Color.Black, 3);
            base.DrawSelf(grfx);
            grfx.FillPolygon(new SolidBrush(FillColor), p);
            grfx.DrawPolygon(new Pen(Color.Black), p);
        }
    }
}
