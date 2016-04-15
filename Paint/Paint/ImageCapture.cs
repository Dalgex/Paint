using System;
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
        /// Предоставляет точечный рисунок выделенной области
        /// </summary>
        public static Bitmap BitmapForRegion { get; private set; }

        static ImageCapture()
        {
            BitmapForRegion = new Bitmap(1, 1);
        }

        /// <summary>
        /// Получает изображения из выделенной области
        /// </summary>
        public static void GetImageFromSelectedRegion(MyBitmap bitmap, Rectangle region)
        {
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(region.Location, region.Size);
            BitmapForRegion = new Bitmap(rect.Width, rect.Height);
            var g = Graphics.FromImage(BitmapForRegion);
            g.DrawImage(bitmap.Bitmap, 0, 0, rect, GraphicsUnit.Pixel);
        }

        /// <summary>
        /// Делает частью основного изображения выделенную область
        /// </summary>
        public static void AddBitmapForRegionToMainBitmap(MyBitmap bitmap, Rectangle region)
        {
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(region.Location, region.Size);
            var g = Graphics.FromImage(bitmap.Bitmap);
            g.DrawImage(BitmapForRegion, rect.X, rect.Y);           
            BitmapForRegion = new Bitmap(1, 1);
        }

        /// <summary>
        /// Масштабирует изображение, исходя из начального прямоугольника и передаваемого
        /// </summary>
        public static void ScaleImage(Rectangle region)
        {
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(region.Location, region.Size);
            var bitmap = new Bitmap(rect.Width, rect.Height);
            var g = Graphics.FromImage(bitmap);
            g.DrawImage(BitmapForRegion, 0, 0, rect.Width, rect.Height);
            BitmapForRegion = bitmap;
        }

        /// <summary>
        /// Очищает выделенный фрагмент изображения (закрашивает его цветом фона)
        /// </summary>
        public static void CleanRegion(MyBitmap bitmap, Rectangle region, Color backgroundColor)
        {
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(region.Location, region.Size);
            var g = Graphics.FromImage(bitmap.Bitmap);
            g.FillRectangle(new SolidBrush(backgroundColor), rect);
        }
    }
}
