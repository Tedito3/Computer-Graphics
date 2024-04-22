using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{

	public class Ellipse : Shape
	{ 
		public Ellipse(RectangleF rect) : base(rect)
		{
		}

		public override bool Contains(PointF point)
		{
			float minorAxis = Width / 2;
			float majorAxis = Height / 2;
			float centerX = this.Location.X + minorAxis;
			float centerY = this.Location.Y + majorAxis;
			double p = (Math.Pow((point.X - centerX), 2) / Math.Pow(minorAxis, 2)) +
					 (Math.Pow((point.Y - centerY), 2) / Math.Pow(majorAxis, 2));

			if (p <= 1)
				return true;
			else
				return false;
		}

		/// Частта, визуализираща конкретния примитив.
		public override void DrawSelf(Graphics grfx)
		{
			base.DrawSelf(grfx);

			grfx.FillEllipse(new SolidBrush(FillColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
			grfx.DrawEllipse(Pens.Black, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);

		}
	}
}