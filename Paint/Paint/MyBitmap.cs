using System;
using System.Collections.Generic;
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
        public System.Drawing.Bitmap Bitmap;

        public MyBitmap(System.Drawing.Bitmap bitmap)
        {
            Bitmap = bitmap;
        }

        public void ChangeBitmap(History history, HistoryData historyData, System.Windows.Forms.PictureBox pictureBox)
        {
            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.DrawToBitmap(bitmap, pictureBox.ClientRectangle);
            Bitmap = bitmap;
            ActionsWithShapes.ClearShapes(history, historyData);
            historyData.Bitmaps.Push(Bitmap);
            history.AddHistory(new CommandBitmap(this), true);
        }
    }
}
