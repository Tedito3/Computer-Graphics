using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    public class Figura4 : Shape
    {
        #region Constructor
        public Figura4(RectangleF rect) : base(rect)
        {
        }
        public Figura4(RectangleShape rectangle) : base(rectangle)
        {
        }
        #endregion
        /// <summary>
        /// Проверка за принадлежност на точка point към правоъгълника.
        /// В случая на правоъгълник този метод може да не бъде пренаписван, защото
        /// Реализацията съвпада с тази на абстрактния клас Shape, който проверява
        /// дали точката е в обхващащия правоъгълник на елемента (а той съвпада с
        /// елемента в този случай).
        /// </summary>
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
            Point[] oe = {
                new Point((int)(Rectangle.X + 100), (int)Rectangle.Y+100),
                new Point((int)(Rectangle.X + Rectangle.Width - 100), (int)(Rectangle.Bottom - 100))};
            grfx.DrawLines(Pens.Black, oe);
            Point[] one = {
                new Point((int)(Rectangle.X + 100), (int)Rectangle.Y+50),
                new Point((int)(Rectangle.X + Rectangle.Width - 200), (int)(Rectangle.Bottom + 50))};
            grfx.DrawLines(Pens.Black, one);
        }
    }
}
