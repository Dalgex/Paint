using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// Предоставляет расстояние между границами mainPictureBox и panelForPictureBox
    /// </summary>
    public static class DistanceBetweenBordersPictureBoxAndPanel
    {
        private static int value = 10;

        /// <summary>
        /// Возвращает расстояние между границами
        /// </summary>
        public static int Value
        {
            get { return value; }
        }
    }
}
