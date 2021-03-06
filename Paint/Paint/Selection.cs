﻿using System;
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
        private static System.Windows.Forms.PictureBox mainPictureBox;
        private static FrameRectangle frame = new FrameRectangle();

        /// <summary>
        /// Возвращает объект, используемый для рисования границы выделения
        /// </summary>
        public static Pen Pen { get; private set; }

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
        public static Rectangle Region { get; private set; }

        /// <summary>
        /// Существует ли область
        /// </summary>
        public static bool DoesRegionExist
        {
            get { return Region.Width > 0 && Region.Height > 0; }
        }

        /// <summary>
        /// Показывает, изменяется ли сейчас выделенный фрагмент (растягивается/сжимается)
        /// </summary>
        public static bool IsRegionChanged
        {
            get { return frame.IsFrameChanged; }
        }

        /// <summary>
        /// Показывает, было ли завершено изменение размеров области
        /// </summary>
        public static bool WasChangeFinished
        {
            get { return frame.WasChangeFinished; }
        }

        /// <summary>
        /// Возвращает начальное положение области выделения
        /// </summary>
        public static Point StartingRegionPosition
        {
            get { return frame.StartingRegionPosition; }
        }

        /// <summary>
        /// Представляет метод, который будет обрабатывать событие, не имеющее данных
        /// </summary>
        public delegate void EventHandler();

        /// <summary>
        /// Происходит после создания выделенной области
        /// </summary>
        public static event EventHandler RegionCreated;

        /// <summary>
        /// Происходит после удаления выделенного фрагмента
        /// </summary>
        public static event EventHandler RegionDeleted;

        static Selection()
        {
            float[] dashValues = { 4, 4 };
            Pen = new Pen(Color.Black, 1);
            Pen.DashPattern = dashValues;
            Region = new Rectangle(Pen, new Point(0, 0), new Size(0, 0));
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
            Region = new Rectangle(Pen, TopX, TopY, Width, Height);
            Region.Draw(e);
            RegionCreated();
        }

        /// <summary>
        /// Задает параметры прямоугольной области
        /// </summary>
        public static void InitializeRegion(Point location, Size size)
        {
            Region = new Rectangle(Pen, location.X, location.Y, size.Width, size.Height);
            TopX = Region.TopX;
            TopY = Region.TopY;
            Width = size.Width;
            Height = size.Height;
            RegionCreated();
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
            Region = new Rectangle(Pen, 0, 0, 0, 0);
            frame.DeleteFrame();
            RegionDeleted();
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
            frame = new FrameRectangle(Region, mainPictureBox);
        }

        /// <summary>
        /// Выбирает в качестве выделенной области сразу все изображение
        /// </summary>
        public static void SelectAll(MyBitmap myBitmap)
        {
            Deselect(myBitmap);
            mainPictureBox.Refresh();
            InitializeRegion(new Point(0, 0), mainPictureBox.ClientSize);
            ImageCapture.GetImageFromSelectedRegion(myBitmap, Region, mainPictureBox);
            ImageCapture.CleanRegion(myBitmap, Region, mainPictureBox.BackColor);
            var g = mainPictureBox.CreateGraphics();
            g.DrawRectangle(Selection.Pen, Selection.TopX, Selection.TopY, Selection.Width, Selection.Height);
            DrawFrameForRegion();
        }

        /// <summary>
        /// Заполняет выделенную область цветом, который установлен как основной
        /// </summary>
        public static void FillSelection(MyBitmap myBitmap, Color color)
        {
            ImageCapture.FillRegionBitmap(myBitmap, Region, color);
            DeleteRegion();
            mainPictureBox.Invalidate();
        }

        /// <summary>
        /// Удаляет изображение внутри выделенного фрагмента
        /// </summary>
        public static void EraseSelection(MyBitmap myBitmap)
        {
            ImageCapture.FillRegionBitmap(myBitmap, Region, mainPictureBox.BackColor);
            DeleteRegion();
            mainPictureBox.Invalidate();
        }

        /// <summary>
        /// Делает частью основного изображения выделенный фрагмент и снимает выделение
        /// </summary>
        public static void Deselect(MyBitmap myBitmap)
        {
            ImageCapture.AddBitmapForRegionToMainBitmap(myBitmap, Region);
            DeleteRegion();
            mainPictureBox.Invalidate();
        }
    }
}
