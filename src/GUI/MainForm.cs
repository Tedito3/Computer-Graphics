using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Draw
{
	/// <summary>
	/// Върху главната форма е поставен потребителски контрол,
	/// в който се осъществява визуализацията
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// Агрегирания диалогов процесор във формата улеснява манипулацията на модела.
		/// </summary>
		private DialogProcessor dialogProcessor = new DialogProcessor();
		
		public MainForm()
		{
			// The InitializeComponent() call is required for Windows Forms designer support.
			InitializeComponent();
			// TODO: Add constructor code after the InitializeComponent() call.
		}

		/// <summary>
		/// Изход от програмата. Затваря главната форма, а с това и програмата.
		/// </summary>
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}
		
		/// <summary>
		/// Събитието, което се прихваща, за да се превизуализира при изменение на модела.
		/// </summary>
		void ViewPortPaint(object sender, PaintEventArgs e)
		{
			dialogProcessor.ReDraw(sender, e);
		}
		
		/// <summary>
		/// Бутон, който поставя на произволно място правоъгълник със зададените размери.
		/// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
		/// </summary>
		void DrawRectangleSpeedButtonClick(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomRectangle();
			
			statusBar.Items[0].Text = "Последно действие: Рисуване на правоъгълник";
			
			viewPort.Invalidate();
		}
		/// <summary>
		/// Прихващане на координатите при натискането на бутон на мишката и проверка (в обратен ред) дали не е
		/// щракнато върху елемент. Ако е така то той се отбелязва като селектиран и започва процес на "влачене".
		/// Промяна на статуса и инвалидиране на контрола, в който визуализираме.
		/// Реализацията се диалогът с потребителя, при който се избира "най-горния" елемент от екрана.
		/// </summary>
		/// множествена селекция
		void ViewPortMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (pickUpSpeedButton.Checked)
			{
				var sel = dialogProcessor.ContainsPoint(e.Location);
				if (sel == null) return;

				if (dialogProcessor.Selection.Contains(sel))
					dialogProcessor.Selection.Remove(sel);
				else dialogProcessor.Selection.Add(sel);
				statusBar.Items[0].Text = "Последно действие: Селекция на примитив";
				dialogProcessor.IsDragging = true;
				dialogProcessor.LastLocation = e.Location;
				viewPort.Invalidate();
			}
		}

		/// <summary>
		/// Прихващане на преместването на мишката.
		/// Ако сме в режим на "влачене", то избрания елемент се транслира.
		/// </summary>
		void ViewPortMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (dialogProcessor.IsDragging) {
				if (dialogProcessor.Selection != null) statusBar.Items[0].Text = "Последно действие: Влачене";
				dialogProcessor.TranslateTo(e.Location);
				viewPort.Invalidate();
			}
		}

		/// <summary>
		/// Прихващане на отпускането на бутона на мишката.
		/// Излизаме от режим "влачене".
		/// </summary>
		void ViewPortMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			dialogProcessor.IsDragging = false;
		}

		//изтриване от падащо меню
		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dialogProcessor.Delete();
			viewPort.Invalidate();
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomEllipse(Color.White, Color.Black);
			statusBar.Items[0].Text = "Последно действие: рисуване на елипса";
			viewPort.Invalidate();
        }
		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomCircle(Color.White, Color.Black);
			statusBar.Items[0].Text = "Последно действие: рисуване на кръг";
			viewPort.Invalidate();
		}
		private void toolStripButton3_Click(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomSquare();
			statusBar.Items[0].Text = "Последно действие: рисуване на квадрат";
			viewPort.Invalidate();
		}
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomLine();
			statusBar.Items[0].Text = "Последно действие: рисуване на линия";
			viewPort.Invalidate();
		}

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomTriangle();
			statusBar.Items[0].Text = "Последно действие: рисуване на триъгълник";
			viewPort.Invalidate();
		}

		private void toolStripButton6_Click(object sender, EventArgs e)
        {
			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				dialogProcessor.SetFillColor(colorDialog1.Color);
				statusBar.Items[0].Text = "Последно действие: задаване на цвят";
				viewPort.Invalidate();
			}

		}
		private void toolStripButton8_Click(object sender, EventArgs e)
		{
			SaveFileDialog f = new SaveFileDialog();
			f.Filter = "JPG(*.JPG)|*.jpg";

			viewPort.Size = new System.Drawing.Size(10000, 10000);
			Bitmap bitmap = DrawControltoBitmap(viewPort);

			if (f.ShowDialog() == DialogResult.OK)
			{
				bitmap.Save(f.FileName);
				statusBar.Items[0].Text = "Последно действие: запазване на изображение";

			}
		}
		//запазване на изображение
		public Bitmap DrawControltoBitmap(DoubleBufferedPanel viewPort)
		{
			Bitmap bitmap = new Bitmap(viewPort.Width, viewPort.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			Rectangle rect = viewPort.RectangleToScreen(viewPort.ClientRectangle);
			graphics.CopyFromScreen(rect.Location, Point.Empty, viewPort.Size);
			return bitmap;
		}
		//запазване на изображение от падащо меню
		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog f = new SaveFileDialog();
			f.Filter = "JPG(*.JPG)|*.jpg";

			viewPort.Size = new System.Drawing.Size(10000, 10000);
			Bitmap bitmap = DrawControltoBitmap(viewPort);

			if (f.ShowDialog() == DialogResult.OK)
			{
				bitmap.Save(f.FileName);
				statusBar.Items[0].Text = "Последно действие: запазване на изображение";

			}
		}
		//избиране на всички елементи от падащо меню 
		private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dialogProcessor.SelectAll();
		}
        private void Figura1_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddFigura1();

            statusBar.Items[0].Text = "Рисуване на фигура 1";

            viewPort.Invalidate();

        }
        private void Figura2_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddFigura2();

            statusBar.Items[0].Text = "Рисуване на елипса";

            viewPort.Invalidate();
        }
        private void Figura3_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddFigura3();

            statusBar.Items[0].Text = "Рисуване на фигура 3";

            viewPort.Invalidate();
        }
        private void Figura4_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddFigura4();

            statusBar.Items[0].Text = "Рисуване на фигура 4";

            viewPort.Invalidate();
        }
        private void Figura5_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddFigura5();

            statusBar.Items[0].Text = "Рисуване на фигура 3";

            viewPort.Invalidate();
        }
        private void Figura6_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddFigura6();

            statusBar.Items[0].Text = "Рисуване на елипса";

            viewPort.Invalidate();
        }
        private void Figura7_Click(object sender, EventArgs e)
        {

        }
        private void viewPort_Load(object sender, EventArgs e)
        {

        }
        private void UpScale_Click(object sender, EventArgs e)
        {
            dialogProcessor.upscale();
            statusBar.Items[0].Text = "Последно действие: Уголемяване на размера на примитива пропорционално";
            viewPort.Invalidate();
        }

        private void Downscale_Click(object sender, EventArgs e)
        {
            dialogProcessor.downscale();
            statusBar.Items[0].Text = "Последно действие: Смаляване на размера на примитива пропорционално";
            viewPort.Invalidate();
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    dialogProcessor.Copy();
            //    statusBar.Items[0].Text = "Последно действие: Копиране на примитив/и";
            //    viewPort.Invalidate();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    dialogProcessor.Paste();
            //    statusBar.Items[0].Text = "Последно действие: Поставяне на примитив/и";
            //    viewPort.Invalidate();
        }
        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomLine();
            statusBar.Items[0].Text = "Последно действие: Рисуване на линия";
            viewPort.Invalidate();
        }
        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogProcessor.SelectAll();
            statusBar.Items[0].Text = "Последно действие: Селектиране на всички примитиви";
            viewPort.Invalidate();
        }
        private void saveAsToolStripMenuItem_Click()
        {

        }
    }
}
