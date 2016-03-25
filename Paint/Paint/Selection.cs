using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// Предоставляет выделение фрагмента изображения
    /// </summary>
    public static class Selection
    {
        private static Pen Pen;

        /// <summary>
        /// Возвращает координату по оси X левого верхнего угла области
        /// </summary>
        public static int TopX { get; private set; }
        
        /// <summary>
        /// Возвращает координату по оси Y левого верхнего угла области
        /// </summary>
        public static int TopY { get; private set; }
        
        /// <summary>
        /// Возвращает ширину области
        /// </summary>
        public static int Width { get; private set; }
        
        /// <summary>
        /// Возвращает высоту области
        /// </summary>
        public static int Height { get; private set; }

        /// <summary>
        /// Возвращает прямоугольную область выделения
        /// </summary>
        public static System.Drawing.Rectangle Region { get; private set; }

        static Selection()
        {
            float[] dashValues = { 4, 4 };
            Pen = new Pen(Color.Black, 1);
            Pen.DashPattern = dashValues;
        }

        private static void DetermineRegionSize(System.Drawing.Point startPoint, System.Drawing.Point currentPoint)
        {
            TopX = (startPoint.X > currentPoint.X) ? currentPoint.X : startPoint.X;
            TopY = (startPoint.Y > currentPoint.Y) ? currentPoint.Y : startPoint.Y;
            Width = (startPoint.X > currentPoint.X) ? startPoint.X - currentPoint.X : currentPoint.X - startPoint.X;
            Height = (startPoint.Y > currentPoint.Y) ? startPoint.Y - currentPoint.Y : currentPoint.Y - startPoint.Y;
        }

        /// <summary>
        /// Рисует выделение области
        /// </summary>
        public static void DrawRegion(System.Drawing.Point startPoint, System.Drawing.Point currentPoint,
            System.Windows.Forms.PaintEventArgs e)
        {
            DetermineRegionSize(startPoint, currentPoint);
            Region = new System.Drawing.Rectangle(TopX, TopY, Width, Height);
            e.Graphics.DrawRectangle(Pen, Region);
        }
    }
}
