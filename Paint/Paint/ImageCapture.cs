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
        /// Представляет метод, который будет обрабатывать событие, не имеющее данных
        /// </summary>
        public delegate void EventHandler();

        /// <summary>
        /// Происходит после выбора прямоугольной области
        /// </summary>
        public static event EventHandler RegionBitmapCreated;
        
        /// <summary>
        /// Происходит при отмене выделения
        /// </summary>
        public static event EventHandler RegionDeselected;

        /// <summary>
        /// Происходит при масштабировании области выделения
        /// </summary>
        public static event EventHandler RegionScaled;

        /// <summary>
        /// Предоставляет точечный рисунок выделенной области
        /// </summary>
        public static MyBitmap RegionBitmap { get; set; }

        /// <summary>
        /// Показывает, существует ли изображение выделенного фрагмента
        /// </summary>
        public static bool DoesRegionBitmapExist
        {
            get { return RegionBitmap.Bitmap.Width > 1 || RegionBitmap.Bitmap.Height > 1; }
        }

        static ImageCapture()
        {
            RegionBitmap = new MyBitmap(new Bitmap(1, 1), new Point(1, 1));
        }

        /// <summary>
        /// Получает изображение из выделенной области
        /// </summary>
        public static Image GetImageFromSelectedRegion(MyBitmap myBitmap, Rectangle region, System.Windows.Forms.PictureBox pictureBox)
        {
            var rect = new System.Drawing.Rectangle(region.Location, region.Size);
            RegionBitmap = new MyBitmap(new Bitmap(rect.Width, rect.Height), rect.Location);
            var g = Graphics.FromImage(RegionBitmap.Bitmap);
            myBitmap.ChangeBitmap(pictureBox);
            g.DrawImage(myBitmap.Bitmap, 0, 0, rect, GraphicsUnit.Pixel);
            return RegionBitmap.Bitmap;
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
            RegionBitmapCreated();
        }

        /// <summary>
        /// Получает изображение из выделенного фрагмента и заполняет это место на графическом окне цветом фона.
        /// Это означает, что на данном месте нет изображения
        /// </summary>
        public static void GetImageFromSelectedRegion(MyBitmap myBitmap, Rectangle region, 
            System.Windows.Forms.PictureBox pictureBox, Color backgroundColor)
        {
            ImageCapture.GetImageFromSelectedRegion(myBitmap, Selection.Region, pictureBox);
            ImageCapture.CleanRegion(myBitmap, Selection.Region, backgroundColor);
        }

        /// <summary>
        /// Делает частью основного изображения выделенную область
        /// </summary>
        public static void AddBitmapForRegionToMainBitmap(MyBitmap myBitmap, Rectangle region)
        {
            if (region.Width > 0 && region.Height > 0)
            {
                var bitmap = new Bitmap(myBitmap.Bitmap);
                var g = Graphics.FromImage(bitmap);
                g.DrawImage(RegionBitmap.Bitmap, region.TopX, region.TopY);
                myBitmap.Bitmap = bitmap;
                DeleteRegionBitmap();
                RegionDeselected();
            }
        }

        /// <summary>
        /// Масштабирует изображение, исходя из начального прямоугольника и передаваемого
        /// </summary>
        public static void ScaleImage(Rectangle region)
        {
            var bitmap = new Bitmap(region.Width, region.Height);
            var g = Graphics.FromImage(bitmap);
            g.DrawImage(RegionBitmap.Bitmap, 0, 0, region.Width, region.Height);
            RegionBitmap = new MyBitmap(bitmap, region.Location);
            RegionScaled();
        }

        /// <summary>
        /// Заполняет выделенный фрагмент изображения указанным цветом
        /// </summary>
        public static void FillRegionBitmap(MyBitmap myBitmap, Rectangle region, Color color)
        {
            var rect = new System.Drawing.Rectangle(region.Location, region.Size);
            var bitmap = new Bitmap(myBitmap.Bitmap);
            var g = Graphics.FromImage(bitmap);
            g.FillRectangle(new SolidBrush(color), rect);
            myBitmap.Bitmap = bitmap;
            DeleteRegionBitmap();
            RegionDeselected();
        }

        /// <summary>
        /// Удаляет изображение выделенной области
        /// </summary>
        public static void DeleteRegionBitmap()
        {
            RegionBitmap = new MyBitmap(new Bitmap(1, 1), new Point(1, 1));
        }
    }
}
