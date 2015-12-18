using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// Представляет указатель мыши
    /// </summary>
    public class MouseCursor
    {
        /// <summary>
        /// Показывает текущие координаты курсора
        /// </summary>
        public static void ShowCursorLocation(System.Windows.Forms.Label label, System.Windows.Forms.MouseEventArgs e)
        {
            label.Text = "      " + e.Location.X + ", " + e.Location.Y + " пкс";
        }
    }
}
