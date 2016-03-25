using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public static class MovingRectangle
    {
        private static bool isPressed;
        private static int deltaX;
        private static int deltaY;
        private static System.Drawing.Rectangle rectangle;

        public static void MouseDown(MouseEventArgs e)
        {
            if ((e.X < rectangle.X + rectangle.Width) && (e.X > rectangle.X))
            {
                if ((e.Y < rectangle.Y + rectangle.Height) && (e.Y > rectangle.Y))
                {
                    isPressed = true;
                    deltaX = e.X - rectangle.X;
                    deltaY = e.Y - rectangle.Y;
                }
            }
        }

        public static void MouseMove(MouseEventArgs e)
        {
            if (isPressed)
            {
                rectangle.X = e.X - deltaX;
                rectangle.Y = e.Y - deltaY;
            }
        }

        public static void MouseUp()
        {
            isPressed = false;
        }
    }
}
