using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// Строит фигуру в момент ее рисования
    /// </summary>
    public class ShapeBuilder
    {
        /// <summary>
        /// Возвращает координату по оси X левого верхнего угла фигуры
        /// </summary>
        public int TopX { get; private set; }

        /// <summary>
        /// Возвращает координату по оси Y левого верхнего угла фигуры
        /// </summary>
        public int TopY { get; private set; }

        /// <summary>
        /// Возвращает высоту фигуры
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Возвращает ширину фигуры
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Определяет цвет, ширину и стиль фигуры
        /// </summary>
        public System.Drawing.Pen Pen { get; private set; }

        private System.Drawing.Color mainColor;
        private System.Drawing.Color backgroundColor;
        private int toolWidth;
        private bool withContour;
        private bool withFilling;

        public ShapeBuilder(System.Drawing.Color mainColor, System.Drawing.Color backgroundColor, int toolWidth, 
            bool withContour, bool withFilling)
        {
            this.mainColor = mainColor;
            this.backgroundColor = backgroundColor;
            this.toolWidth = toolWidth;
            this.withContour = withContour;
            this.withFilling = withFilling;
        }

        public ShapeBuilder(System.Drawing.Color mainColor, int toolWidth)
        {
            this.mainColor = mainColor;
            this.toolWidth = toolWidth;
        }

        public ShapeBuilder(int toolWidth)
        {
            this.toolWidth = toolWidth;
        }

        private void DetermineShapeSize(System.Drawing.Point startPoint, System.Drawing.Point currentPoint)
        {
            TopX = (startPoint.X > currentPoint.X) ? currentPoint.X : startPoint.X;
            TopY = (startPoint.Y > currentPoint.Y) ? currentPoint.Y : startPoint.Y;
            Width = (startPoint.X > currentPoint.X) ? startPoint.X - currentPoint.X : currentPoint.X - startPoint.X;
            Height = (startPoint.Y > currentPoint.Y) ? startPoint.Y - currentPoint.Y : currentPoint.Y - startPoint.Y;
        }

        public void BuildEllipse(System.Drawing.Point startPoint, System.Drawing.Point currentPoint, 
            System.Windows.Forms.PaintEventArgs e)
        {
            DetermineShapeSize(startPoint, currentPoint);
            Pen = new System.Drawing.Pen(mainColor, toolWidth);
            Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            Pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;

            if (withContour || withFilling)
            {
                if (!withFilling)
                {
                    e.Graphics.DrawEllipse(Pen, TopX, TopY, Width, Height);
                }
                else if (!withContour)
                {
                    e.Graphics.FillEllipse(new System.Drawing.SolidBrush(backgroundColor), TopX, TopY, Width, Height);
                }
                else
                {
                    e.Graphics.DrawEllipse(Pen, TopX, TopY, Width, Height);
                    e.Graphics.FillEllipse(new System.Drawing.SolidBrush(backgroundColor), TopX, TopY, Width, Height);
                }
            }
        }

        public void BuildRectangle(System.Drawing.Point startPoint, System.Drawing.Point currentPoint, 
            System.Windows.Forms.PaintEventArgs e)
        {
            DetermineShapeSize(startPoint, currentPoint);

            if (withContour || withFilling)
            {
                if (!withFilling)
                {
                    e.Graphics.DrawRectangle(new System.Drawing.Pen(mainColor, toolWidth), TopX, TopY, Width, Height);
                }
                else if (!withContour)
                {
                    e.Graphics.FillRectangle(new System.Drawing.SolidBrush(backgroundColor), TopX, TopY, Width, Height);
                }
                else
                {
                    e.Graphics.DrawRectangle(new System.Drawing.Pen(mainColor, toolWidth), TopX, TopY, Width, Height);
                    e.Graphics.FillRectangle(new System.Drawing.SolidBrush(backgroundColor), TopX, TopY, Width, Height);
                }
            }
        }

        public void BuildLine(System.Drawing.Point startPoint, System.Drawing.Point currentPoint, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawLine(new System.Drawing.Pen(mainColor, toolWidth), startPoint, currentPoint);
        }

        public void BuildCurve(System.Drawing.Point previousPoint, System.Drawing.Point currentPoint, 
            System.Drawing.Color color, System.Windows.Forms.PictureBox pictureBox)
        {
            System.Drawing.Graphics graphics = pictureBox.CreateGraphics();
            var brush = new System.Drawing.SolidBrush(color);
            var size = new System.Drawing.Size(toolWidth, toolWidth);
            System.Drawing.RectangleF rectangle = new System.Drawing.RectangleF(new System.Drawing.PointF((float)(previousPoint.X) - (float)(size.Height) / 2, (float)(previousPoint.Y) - (float)(size.Height) / 2), size); // PointF представляет левый верхний угол прямоугольной области, поэтому сдвигаем по координатам X и Y на половину длины прямогугольника
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.FillEllipse(brush, rectangle);
            graphics.DrawLine(new System.Drawing.Pen(color, toolWidth), previousPoint, currentPoint);
        }
    }
}
