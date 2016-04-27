using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// Отвечает за поворот или отражение изображения
    /// </summary>
    public class BitmapRotation
    {
        private static void Rotate(Bitmap bitmap, string temp, PanelResizer panelResizer)
        {
            if (temp == "Повернуть на 90 градусов вправо" || temp == "Повернуть на 90 градусов влево")
            {
                if (temp == "Повернуть на 90 градусов вправо")
                {
                    bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                else
                {
                    bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
                }

                panelResizer.ReversePanel();
            }
            else if (temp == "Отразить по вертикали")
            {
                bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
            }
            else if (temp == "Отразить по горизонтали")
            {
                bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            else
            {
                bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }
        }

        /// <summary>
        /// Поворачивает, зеркально отражает, либо поворачивает и зеркально отражает объект Bitmap
        /// </summary>
        public static void RotateBitmap(MyBitmap myBitmap, History history, HistoryData historyData, 
            System.Windows.Forms.PictureBox pictureBox, PanelResizer panelResizer, string temp)
        {
            var bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.DrawToBitmap(bitmap, pictureBox.ClientRectangle);
            Rotate(bitmap, temp, panelResizer);
            ActionsWithShapes.ClearShapes(history, historyData);
            myBitmap.Bitmap = bitmap;
            historyData.Bitmaps.Push(myBitmap.Bitmap);
            history.AddHistory(new CommandBitmap(myBitmap), true);
        }
    }
}
