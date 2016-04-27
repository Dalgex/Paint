﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// Предоставляет захват изображения из выделенного фрагмента
    /// </summary>
    public static class ImageCapture
    {
        /// <summary>
        /// Представляет метод, который будет обрабатывать событие, не имеющее данных
        /// </summary>
        public delegate void EventHandler();

        /// <summary>
        /// Происходит после выбора прямоугольной области
        /// </summary>
        public static event EventHandler CreateRegionBitmap;
        
        /// <summary>
        /// Происходит при отмене выделения
        /// </summary>
        public static event EventHandler AddBitmap;

        /// <summary>
        /// Происходит при масштабировании области выделения
        /// </summary>
        public static event EventHandler Scale;

        /// <summary>
        /// Предоставляет точечный рисунок выделенной области
        /// </summary>
        public static MyBitmap RegionBitmap { get; set; }

        static ImageCapture()
        {
            RegionBitmap = new MyBitmap(new Bitmap(1, 1), new Point(1, 1));
        }

        /// <summary>
        /// Получает изображение из выделенной области
        /// </summary>
        public static void GetImageFromSelectedRegion(MyBitmap myBitmap, Rectangle region, System.Windows.Forms.PictureBox pictureBox)
        {
            var rect = new System.Drawing.Rectangle(region.Location, region.Size);
            RegionBitmap = new MyBitmap(new Bitmap(rect.Width, rect.Height), rect.Location);
            var g = Graphics.FromImage(RegionBitmap.Bitmap);
            myBitmap.ChangeBitmap(pictureBox);
            g.DrawImage(myBitmap.Bitmap, 0, 0, rect, GraphicsUnit.Pixel);
            CreateRegionBitmap();
        }

        /// <summary>
        /// Делает частью основного изображения выделенную область
        /// </summary>
        public static void AddBitmapForRegionToMainBitmap(MyBitmap myBitmap, Rectangle region)
        {     
            var bitmap = new Bitmap(myBitmap.Bitmap);
            var g = Graphics.FromImage(bitmap);
            g.DrawImage(RegionBitmap.Bitmap, region.TopX, region.TopY);
            myBitmap.Bitmap = bitmap;
            RegionBitmap = new MyBitmap(new Bitmap(1, 1), new Point(1, 1));
            AddBitmap();
        }

        /// <summary>
        /// Масштабирует изображение, исходя из начального прямоугольника и передаваемого
        /// </summary>
        public static void ScaleImage(Rectangle region)
        {
            var rect = new System.Drawing.Rectangle(region.Location, region.Size);
            var bitmap = new Bitmap(rect.Width, rect.Height);
            var g = Graphics.FromImage(bitmap);
            g.DrawImage(RegionBitmap.Bitmap, 0, 0, rect.Width, rect.Height);
            RegionBitmap = new MyBitmap(bitmap, rect.Location);
            Scale();
        }

        /// <summary>
        /// Очищает выделенный фрагмент изображения (закрашивает его цветом фона)
        /// </summary>
        public static void CleanRegion(MyBitmap myBitmap, Rectangle region, Color backgroundColor)
        {
            var rect = new System.Drawing.Rectangle(region.Location, region.Size);
            var bitmap = new Bitmap(myBitmap.Bitmap);
            var g = Graphics.FromImage(bitmap);
            g.FillRectangle(new SolidBrush(backgroundColor), rect);
            myBitmap.Bitmap = bitmap;
        }
    }
}
