using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// Рисует линию
    /// </summary>
    public class Line : Shape
    {
        public override Pen Pen { get; set; }

        /// <summary>
        /// Представляет координаты первой точки
        /// </summary>
        public Point FirstPoint { get; set; }

        /// <summary>
        /// Представляет координаты второй точки
        /// </summary>
        public Point SecondPoint { get; set; }

        public Line(Point firstPoint, Point secondPoint, Pen pen) : base(pen)
        {
            FirstPoint = firstPoint;
            SecondPoint = secondPoint;
        }

        public override void Draw(System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pen, FirstPoint, SecondPoint);
        }
    }
}
