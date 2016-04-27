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
        /// Показывает, было ли выделение раньше
        /// </summary>
        public static bool WasSelectionBefore { get; private set; }
        
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
        public static Rectangle Region { get; set; }

        /// <summary>
        /// Показывает, изменяется ли сейчас рамка (растягивается/сжимается)
        /// </summary>
        public static bool IsFrameChanged
        {
            get { return frame.IsFrameChanged; }
        }

        /// <summary>
        /// Показывает, было ли завершено изменение размеров области
        /// </summary>
        public static bool WasFinishedChange
        {
            get { return frame.WasFinishedChange; }
        }

        /// <summary>
        /// Возвращает начальное положение области выделения
        /// </summary>
        public static Point StartingPositionRegion
        {
            get { return frame.StartingPositionRegion; }
        }

        private static Pen pen;
        private static System.Windows.Forms.PictureBox mainPictureBox;
        private static FrameRectangle frame = new FrameRectangle();

        static Selection()
        {
            float[] dashValues = { 4, 4 };
            pen = new Pen(Color.Black, 1);
            pen.DashPattern = dashValues;
            Region = new Rectangle(pen, new Point(0, 0), new Size(0, 0));
        }

        /// <summary>
        /// Инициализирует поле pictureBox
        /// </summary>
        public static void InitializeField(System.Windows.Forms.PictureBox pictureBox)
        {
            mainPictureBox = pictureBox;
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
        /// Задает параметры прямоугольной области
        /// </summary>
        public static void InitializeRegion(Point location, Size size)
        {
            Region = new Rectangle(pen, location.X, location.Y, size.Width, size.Height);
            TopX = Region.TopX;
            TopY = Region.TopY;
            Width = size.Width;
            Height = size.Height;
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
            WasSelectionBefore = false;
            frame.DeleteFrame();
        }

        /// <summary>
        /// Удаляет рамку
        /// </summary>
        public static void DeleteFrame()
        {
            frame.DeleteFrame();
        }

        /// <summary>
        /// Рисует рамку для выделенного фрагмента
        /// </summary>
        public static void DrawFrameForRegion()
        {
            WasSelectionBefore = true;
            frame = new FrameRectangle(Region, mainPictureBox);
        }
    }
}
