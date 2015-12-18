using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// Определяет область, которую заполняет определенным цветом
    /// </summary>
    public class FloodFill
    {
        /// <summary>
        /// Закрашивает область поверхности указанным цветом
        /// </summary>
        public static void FillRegion(MyBitmap myBitmap, History history, HistoryData historyData,
            System.Windows.Forms.PictureBox pictureBox, Point point, Color mainColor)
        {
            var bitmap = new Bitmap(myBitmap.Bitmap, pictureBox.Size);
            pictureBox.DrawToBitmap(bitmap, pictureBox.ClientRectangle);
            myBitmap.Bitmap = bitmap;
            var graphics = Graphics.FromImage(bitmap);
            Fill(graphics, point, ref myBitmap.Bitmap, mainColor);
            ActionsWithShapes.ClearShapes(history, historyData);
            historyData.Bitmaps.Push(myBitmap.Bitmap);
            history.AddHistory(new CommandBitmap(myBitmap), true);
        }

        private static void Fill(Graphics graphics, Point point, ref Bitmap bitmap, Color mainColor)
        {
            var gdi = new GDI();
            var beginColor = bitmap.GetPixel(point.X, point.Y); // цвет в точке, с которой начинается заливка
            IntPtr panelDC = graphics.GetHdc(); // дескриптор панели
            IntPtr memDC = gdi.ProxyCreateCompatibleDC(panelDC); // дескриптор в памяти, совместимый с панелью
            IntPtr hBrush = gdi.ProxyCreateSolidBrush((uint)ColorTranslator.ToWin32(mainColor)); // создаем и подсовываем свою кисть
            IntPtr hOldBr = gdi.ProxySelectObject(memDC, hBrush);
            IntPtr hBitmap = bitmap.GetHbitmap(); // подсовываем свой битмап
            IntPtr hOldBmp = gdi.ProxySelectObject(memDC, hBitmap);

            // Заливаем (заливается благодаря совместимости с панелью) 
            gdi.ProxyExtFloodFill(memDC, point.X, point.Y, (uint)ColorTranslator.ToWin32(beginColor), 1);
            bitmap.Dispose();
            bitmap = Bitmap.FromHbitmap(hBitmap); // записываем полученный залитый битмап в наш битмап

            // Возвращаем на место предыдущие кисть и битмап
            gdi.ProxySelectObject(memDC, hOldBr);
            gdi.ProxySelectObject(memDC, hOldBmp);

            // Освобождаем использованные ресурсы
            gdi.ProxyDeleteObject(hBitmap);
            gdi.ProxyDeleteObject(hBrush);
            gdi.ProxyDeleteObject(memDC);
        }
    }
}
