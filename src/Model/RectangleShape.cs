using System;
using System.Drawing;

namespace Draw
{
	
	public class RectangleShape : Shape
	{
		#region Constructor
		
		public RectangleShape(RectangleF rect) : base(rect)
		{
		}
		public RectangleShape(RectangleShape rectangle) : base(rectangle)
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
			
			grfx.FillRectangle(new SolidBrush(FillColor),Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
			grfx.DrawRectangle(Pens.Black,Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
			
		}
	}
}
