using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{

	public class Circle : Shape
	{
		public Circle(RectangleF rect) : base(rect)
		{
		}
		public Circle(Circle circ) : base(circ)
		{
		}
		/// <summary>
		/// Проверка за принадлежност на точка point към правоъгълника.
		/// В случая на правоъгълник този метод може да не бъде пренаписван, защото
		/// реализацията съвпада с тази на абстрактния клас Shape, който проверява
		/// дали точката е в обхващащия правоъгълник на елемента (а той съвпада с
		/// елемента в този случай).
		/// </summary>
		public override bool Contains(PointF point)
		{

			// double h = Rectangle.Width / 2;
			// double k= Rectangle.Height / 2;

			//if ((((point.X-h) * (point.X-h)) / ( (Rectangle.Width/2)* (Rectangle.Width / 2)) + (((point.Y-k) * (point.Y-k)) / ((Rectangle.Height / 2) * (Rectangle.Height / 2)))) <= 1)
			if (base.Contains(point))
				// Проверка дали е в обекта само, ако точката е в обхващащия правоъгълник.
				// В случая на правоъгълник - директно връщаме true

				return true; // реализиране на формулата за принадлежност на точка
			else
				// Ако не е в обхващащия правоъгълник, то неможе да е в обекта и => false
				return false;
		}
		public override void DrawSelf(Graphics grfx)
		{
			base.DrawSelf(grfx);

			grfx.FillEllipse(new SolidBrush(FillColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
			grfx.DrawEllipse(Pens.Black, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);

        }
	}
}
