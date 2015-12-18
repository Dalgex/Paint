using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    /// <summary>
    /// Предоставляет возможность определить цвет конкретного пикселя
    /// </summary>
    public class Pipette
    {
        private static Color DeterminePixelColor(PictureBox mainPictureBox, MouseEventArgs e)
        {
            Bitmap bitmap = new Bitmap(mainPictureBox.Width, mainPictureBox.Height);
            mainPictureBox.DrawToBitmap(bitmap, mainPictureBox.ClientRectangle);
            return bitmap.GetPixel(e.Location.X, e.Location.Y);
        }

        /// <summary>
        /// Определяет цвет конкретного пикселя и устанавливает этот цвет в качестве основного или дополнительного
        /// </summary>
        public static void SetColor(MouseEventArgs e, ref Color mainColor, ref Color backgroundColor, 
            PictureBox mainPictureBox, PictureBox pictureBoxForMainColor, PictureBox pictureBoxForBackgroundColor)
        {
            if (e.Button == MouseButtons.Left)
            {
                mainColor = DeterminePixelColor(mainPictureBox, e);
                pictureBoxForMainColor.BackColor = mainColor;
            }
            else
            {
                backgroundColor = DeterminePixelColor(mainPictureBox, e);
                pictureBoxForBackgroundColor.BackColor = backgroundColor;
            }
        }
    }
}
