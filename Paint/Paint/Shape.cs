using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// Предоставляет базовый класс для элементов фигур
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Определяет цвет, ширину и стиль фигуры
        /// </summary>
        public abstract Pen Pen { get; set; }

        public Shape(Pen pen)
        {
            Pen = pen;
        }

        /// <summary>
        /// Рисует фигуру
        /// </summary>
        public abstract void Draw(System.Windows.Forms.PaintEventArgs e);
    }
}
