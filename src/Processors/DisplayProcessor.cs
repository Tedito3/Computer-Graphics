using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Draw.src.Model;

namespace Draw
{
	/// <summary>
	/// Класът, който ще бъде използван при управляване на дисплейната система.
	/// </summary>
	public class DisplayProcessor
	{
		#region Constructor

		public DisplayProcessor()
		{
		}

		#endregion

		#region Properties

		/// <summary>
		/// Списък с всички елементи формиращи изображението.
		/// </summary>
		private List<Shape> shapeList = new List<Shape>();
		public List<Shape> ShapeList
		{
			get { return shapeList; }
			set { shapeList = value; }
		}

		#endregion

		#region Drawing

		/// <summary>
		/// Прерисува всички елементи в shapeList върху e.Graphics
		/// </summary>
		public void ReDraw(object sender, PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			Draw(e.Graphics);
		}

		/// <summary>
		/// Визуализация.
		/// Обхождане на всички елементи в списъка и извикване на визуализиращия им метод.
		/// </summary>
		/// <param name="grfx">Къде да се извърши визуализацията.</param>
		public virtual void Draw(Graphics grfx)
		{
			foreach (Shape item in ShapeList)
			{
				DrawShape(grfx, item);
			}
		}

		/// <summary>
		/// Визуализира даден елемент от изображението.
		/// </summary>
		/// <param name="grfx">Къде да се извърши визуализацията.</param>
		/// <param name="item">Елемент за визуализиране.</param>
		public virtual void DrawShape(Graphics grfx, Shape item)
		{
			item.DrawSelf(grfx);
		}

        public void AddFigura1()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            Figura1 figura1 = new Figura1(new Rectangle(x, y, 100, 100));
            figura1.FillColor = Color.White;
            ShapeList.Add(figura1);
        }
        public void AddFigura2()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);
            Figura2 figura2 = new Figura2(new Rectangle(x, y, 100, 100));
            figura2.FillColor = Color.White;
			ShapeList.Add(figura2);
		}

        public void AddFigura3()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);
            Figura3 figura3 = new Figura3(new Rectangle(x, y, 100, 100));
            figura3.FillColor = Color.White;
            ShapeList.Add(figura3);
        }
        public void AddFigura4()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);
            Figura4 figura4 = new Figura4(new Rectangle(x, y, 200, 100));
            figura4.FillColor = Color.White;
            ShapeList.Add(figura4);
        }
        public void AddFigura5()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);
            Figura5 figura5 = new Figura5(new Rectangle(x, y, 200, 100));
            figura5.FillColor = Color.White;
            ShapeList.Add(figura5);
        }
        public void AddFigura6()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);
            Figura6 figura6 = new Figura6(new Rectangle(x, y, 100, 100));
            figura6.FillColor = Color.White;
            ShapeList.Add(figura6);
        }
        #endregion
    }
}