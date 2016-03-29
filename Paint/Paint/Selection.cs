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
        /// <summary>
        /// Возвращает координату по оси X левого верхнего угла области
        /// </summary>
        public static int TopX { get; private set; }

        /// <summary>
        /// Существует ли область
        /// </summary>
        public static bool DoesRegionExist { get; private set; }
        
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
        public static Rectangle Region { get; private set; }

        private static Pen pen;

        static Selection()
        {
            float[] dashValues = { 4, 4 };
            pen = new Pen(Color.Black, 1);
            pen.DashPattern = dashValues;
        }

        private static void DetermineRegionSize(Point startPoint, Point currentPoint)
        {
            TopX = (startPoint.X > currentPoint.X) ? currentPoint.X : startPoint.X;
            TopY = (startPoint.Y > currentPoint.Y) ? currentPoint.Y : startPoint.Y;
            Width = (startPoint.X > currentPoint.X) ? startPoint.X - currentPoint.X : currentPoint.X - startPoint.X;
            Height = (startPoint.Y > currentPoint.Y) ? startPoint.Y - currentPoint.Y : currentPoint.Y - startPoint.Y;
        }

        /// <summary>
        /// Рисует выделение области
        /// </summary>
        public static void DrawRegion(Point startPoint, Point currentPoint, System.Windows.Forms.PaintEventArgs e)
        {
            DetermineRegionSize(startPoint, currentPoint);
            Region = new Rectangle(pen, TopX, TopY, Width, Height);
            Region.Draw(e);
            DoesRegionExist = true;
        }

        /// <summary>
        /// Рисует область при перемещении
        /// </summary>
        public static void DrawMovingRegion(System.Windows.Forms.PaintEventArgs e)
        {
            TopX = Region.TopX;
            TopY = Region.TopY;
            Region.Draw(e);
        }

        /// <summary>
        /// Удаляет область выделения
        /// </summary>
        public static void DeleteRegion()
        {
            Region = new Rectangle(pen, 0, 0, 0, 0);
            DoesRegionExist = false;
        }

        public static void DrawFrameForRegion()
        {

        }
    }
}
