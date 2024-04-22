using Draw.src.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Draw
{
	/// <summary>
	/// Класът, който ще бъде използван при управляване на диалога.
	/// </summary>
	public class DialogProcessor : DisplayProcessor
	{
		#region Constructor

		public DialogProcessor()
		{
		}

		#endregion

		#region Properties

		/// <summary>
		/// Избран елемент.
		/// </summary>
		//private Shape selection;
		/*public Shape Selection
		{
			get { return selection; }
			set { selection = value; }
		}*/
		//за множество от елементи
		private List<Shape> selection = new List<Shape>();
		public List<Shape> Selection
		{
			get { return selection; }
			set { selection = value; }
		}
		/// <summary>
		/// Дали в момента диалога е в състояние на "влачене" на избрания елемент.
		/// </summary>
		private bool isDragging;
		public bool IsDragging
		{
			get { return isDragging; }
			set { isDragging = value; }
		}

		/// <summary>
		/// Последна позиция на мишката при "влачене".
		/// Използва се за определяне на вектора на транслация.
		/// </summary>
		private PointF lastLocation;
		public PointF LastLocation
		{
			get { return lastLocation; }
			set { lastLocation = value; }
		}
		#endregion
		/// <summary>
		/// Добавя примитив - правоъгълник на произволно място върху клиентската област.
		/// </summary>
		public void AddRandomRectangle()
		{
			Random rnd = new Random();
			int x = rnd.Next(100, 1000);
			int y = rnd.Next(100, 600);

			RectangleShape rect = new RectangleShape(new Rectangle(x, y, 100, 200));
			rect.FillColor = Color.White;

			ShapeList.Add(rect);
		}
		public void AddRandomEllipse(Color fill, Color border)
		{
			Random rnd = new Random();
			int x = rnd.Next(100, 1000);
			int y = rnd.Next(100, 600);

			Ellipse ellip = new Ellipse(new Rectangle(x, y, 100, 200));
			ellip.FillColor = Color.White;

			ShapeList.Add(ellip);
		}
        public void upscale()
        {
            foreach (var item in Selection)
            {
                item.Height = item.Height + 1;
                item.Width = item.Width + 1;
            }
        }
        public void downscale()
        {
            foreach (var item in Selection)
            {
                item.Height = item.Height - 1;
                item.Width = item.Width - 1;
            }
        }
        public void Resize(int x, int y)
        {
            foreach (var item in Selection)
            {
                item.Width = x;
                item.Height = y;
            }
        }
        public void AddRandomCircle(Color fill, Color border)
		{
			Random rnd = new Random();
			int x = rnd.Next(100, 1000);
			int y = rnd.Next(100, 600);

			Circle circ = new Circle(new Rectangle(x, y, 100, 100));
			circ.FillColor = Color.White;

			ShapeList.Add(circ);
		}
		public void AddRandomSquare()
		{
			Random rnd = new Random();
			int x = rnd.Next(100, 1000);
			int y = rnd.Next(100, 600);

			Square sq = new Square(new Rectangle(x, y, 100, 100));
			sq.FillColor = Color.White;
			//sq.BorderColor = Color.Black;

			ShapeList.Add(sq);
		}

		/// <summary>
		/// Проверява дали дадена точка е в елемента.
		/// Обхожда в ред обратен на визуализацията с цел намиране на
		/// "най-горния" елемент т.е. този който виждаме под мишката.
		/// </summary>
		/// <param name="point">Указана точка</param>
		/// <returns>Елемента на изображението, на който принадлежи дадената точка.</returns>
		public Shape ContainsPoint(PointF point)
		{
			for (int i = ShapeList.Count - 1; i >= 0; i--)
			{
				if (ShapeList[i].Contains(point))
				{
					return ShapeList[i];
				}
			}
			return null;
		}
		public void AddRandomLine()
		{
			Random rnd = new Random();
			int x = rnd.Next(100, 1000);
			int y = rnd.Next(100, 600);

			Line line = new Line(new Rectangle(x, y, 100, 100));
			line.FillColor = Color.Black;

			ShapeList.Add(line);
		}
		public void AddRandomTriangle()
		{
			Random rnd = new Random();
			int x = rnd.Next(100, 1000);
			int y = rnd.Next(100, 600);

			Triangle triangle = new Triangle(new Rectangle(x, y, 120, 150));
			triangle.FillColor = Color.White;

			ShapeList.Add(triangle);
		}
		public void SetFillColor(Color color)
		{
			// if (Selection != null)
			foreach (var item in Selection)
			{
				item.FillColor = color;
			}
		}
		/// <summary>
		/// Транслация на избраният елемент на вектор определен от <paramref name="p>p</paramref>
		/// </summary>
		/// <param name="p">Вектор на транслация.</param>
		/// //premestvane na elementite ednovremenno
		public void TranslateTo(PointF p)
		{
			//if (selection != null) {
			foreach (var item in Selection)
			{
				item.Location = new PointF(item.Location.X + p.X - lastLocation.X, item.Location.Y + p.Y - lastLocation.Y);

			}
			lastLocation = p;
		}
		internal void SelectAll()
		{
			Selection = new List<Shape>(ShapeList);
		}
		public void SaveAs(string fileName)
		{
			FileStream fs = new FileStream(fileName, FileMode.Create);
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(fs, ShapeList);
			fs.Close();
		}

		public void Delete()
		{
			foreach (var item in Selection)
				ShapeList.Remove(item);
			ShapeList.Clear();
		}



	}
}