using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// Рисует эллипс
    /// </summary>
    public class Ellipse : Shape
    {
        public override Pen Pen { get; set; }

        /// /// <summary>
        /// Возвращает или задает свойство Brush, которое определяет, как окрашена внутренняя область эллипса
        /// </summary>
        public Brush Fill { get; set; }

        /// <summary>
        /// Возвращает или задает координату по оси X левого верхнего угла эллипса
        /// </summary>
        public int TopX { get; set; }

        /// <summary>
        /// Возвращает или задает координату по оси Y левого верхнего угла эллипса
        /// </summary>
        public int TopY { get; set; }

        /// <summary>
        /// Возвращает или задает ширину элемента
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Возвращает или задаёт высоту элемента
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Возвращает или задает логический параметр, который показывает, имеет ли эллипс контур
        /// </summary>
        public bool WithContour { get; set; }

        /// <summary>
        /// Возвращает или задает логический параметр, который показывает, закрашена ли у эллипса внутренняя область
        /// </summary>
        public bool WithFilling { get; set; }

        public Ellipse(Pen pen, SolidBrush brush, int topX, int topY, int width, int height, bool withContour, bool withFill)
            : base(pen)
        {
            Fill = brush;
            TopX = topX;
            TopY = topY;
            Width = width;
            Height = height;
            WithContour = withContour;
            WithFilling = withFill;
        }

        public override void Draw(System.Windows.Forms.PaintEventArgs e)
        {
            if (WithContour || WithFilling)
            {
                if (!WithFilling)
                {
                    e.Graphics.DrawEllipse(Pen, TopX, TopY, Width, Height);
                }
                else if (!WithContour)
                {
                    e.Graphics.FillEllipse(Fill, TopX, TopY, Width, Height);
                }
                else
                {
                    e.Graphics.DrawEllipse(Pen, TopX, TopY, Width, Height);
                    e.Graphics.FillEllipse(Fill, TopX, TopY, Width, Height);
                }
            }
        }
    }
}
