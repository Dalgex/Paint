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
    /// Рисует кривую
    /// </summary>
    public class Curve : Shape
    {
        public override Pen Pen { get; set; }
        private List<Point> points;

        public Curve(List<Point> points, Pen pen) : base(pen)
        {
            this.points = points;
        }

        public override void Draw(PaintEventArgs e)
        {
            var size = new Size();
            size.Width = (int)Pen.Width;
            size.Height = (int)Pen.Width;
            var fillBrush = new SolidBrush(Pen.Color);

            for (int i = 0; i < points.Count - 1; i++)
            {
                var rectangle = new RectangleF(new PointF((float)(points[i].X) - (float)(size.Width) / 2, (float)(points[i].Y) - (float)(size.Height) / 2), size);
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.FillEllipse(fillBrush, rectangle);
                e.Graphics.DrawLine(Pen, points[i], points[i + 1]);
            }
        }
    }
}
