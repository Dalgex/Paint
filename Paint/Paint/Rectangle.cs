using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// Рисует прямоугольник
    /// </summary>
    public class Rectangle : Shape
    {
        public override Pen Pen { get; set; }

        /// <summary>
        /// Возвращает или задаёт высоту элемента
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Возвращает или задает координаты левого верхнего угла прямоугольника
        /// </summary>
        public Point Location
        {
            get
            {
                return new Point(TopX, TopY);
            }

            set
            {
                TopX = value.X;
                TopY = value.Y;
            }
        }

        /// <summary>
        /// Возвращает или задает размер элемента
        /// </summary>
        public Size Size
        {
            get
            {
                return new Size(Width, Height);
            }

            set
            {
                Width = value.Width;
                Height = value.Height;
            }
        }
        
        /// <summary>
        /// Возвращает или задает координату по оси X левого верхнего угла прямоугольника
        /// </summary>
        public int TopX { get; set; }
        
        /// <summary>
        /// Возвращает или задает координату по оси Y левого верхнего угла прямоугольника
        /// </summary>
        public int TopY { get; set; }

        /// <summary>
        /// Возвращает или задает ширину элемента
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Возвращает или задает свойство Brush, которое определяет, как окрашена внутренняя область прямоугольника
        /// </summary>
        public Brush Fill { get; set; }

        /// <summary>
        /// Возвращает или задает логический параметр, который показывает, имеет ли прямоугольник контур
        /// </summary>
        public bool WithContour { get; set; }
        
        /// <summary>
        /// Возвращает или задает логический параметр, который показывает, закрашена ли у прямоугольника внутренняя область
        /// </summary>
        public bool WithFilling { get; set; }

        public Rectangle(Pen pen, SolidBrush brush, int topX, int topY, int width, int height, bool withContour, bool withFill)
            : base(pen)
        {
            Fill = brush;
            InitializeProperties(topX, topY, width, height);
            WithContour = withContour;
            WithFilling = withFill;
        }

        public Rectangle(Pen pen, int topX, int topY, int width, int height)
            : base(pen)
        {
            InitializeProperties(topX, topY, width, height);
            WithContour = true;
        }

        public Rectangle(Pen pen, Point location, Size size)
            : base(pen)
        {
            InitializeProperties(location.X, location.Y, size.Width, size.Height);
            WithContour = true;
        }

        private void InitializeProperties(int topX, int topY, int width, int height)
        {
            TopX = topX;
            TopY = topY;
            Width = width;
            Height = height;
        }

        public override void Draw(System.Windows.Forms.PaintEventArgs e)
        {
            if (WithContour || WithFilling)
            {
                if (!WithFilling)
                {
                    e.Graphics.DrawRectangle(Pen, TopX, TopY, Width, Height);
                }
                else if (!WithContour)
                {
                    e.Graphics.FillRectangle(Fill, TopX, TopY, Width, Height);
                }
                else
                {
                    e.Graphics.DrawRectangle(Pen, TopX, TopY, Width, Height);
                    e.Graphics.FillRectangle(Fill, TopX, TopY, Width, Height);
                }
            }
        }

        /// <summary>
        /// Определяет, включает ли прямоугольник указанную точку
        /// </summary>
        public bool Contains(Point point)
        {
            return (TopX <= point.X) && (point.X < TopX + Width) && (TopY <= point.Y) && (point.Y < (TopY + Height));
        }

        /// <summary>
        /// Изменяет положение прямоугольника на указанную величину
        /// </summary>
        public void Offset(int offsetX, int offsetY)
        {
            TopX += offsetX;
            TopY += offsetY;
        }
    }
}
