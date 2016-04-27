using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// Предоставляет Bitmap, который отображается на pictureBox
    /// </summary>
    public class MyBitmap
    {
        public System.Drawing.Bitmap Bitmap { get; set; }
        public System.Drawing.Point Location { get; set; }

        public MyBitmap(System.Drawing.Bitmap bitmap)
        {
            Bitmap = bitmap;
        }

        public MyBitmap(System.Drawing.Bitmap bitmap, System.Drawing.Point location)
        {
            Bitmap = bitmap;
            Location = location;
        }

        public void ChangeBitmap(History history, HistoryData historyData, System.Windows.Forms.PictureBox pictureBox)
        {
            var bitmap = new System.Drawing.Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.DrawToBitmap(bitmap, pictureBox.ClientRectangle);
            Bitmap = bitmap;
            ActionsWithShapes.ClearShapes(history, historyData);
            historyData.Bitmaps.Push(Bitmap);
            history.AddHistory(new CommandBitmap(this), true);
        }

        public void ChangeBitmap(System.Windows.Forms.PictureBox pictureBox)
        {
            var bitmap = new System.Drawing.Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.DrawToBitmap(bitmap, pictureBox.ClientRectangle);
            Bitmap = bitmap;
        }
    }
}
