using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    /// <summary>
    /// Предоставляет перемещение прямоугольника
    /// </summary>
    public static class MovingRectangle
    {
        private static int deltaX;
        private static int deltaY;
        private static Rectangle rectangle;

        /// <summary>
        /// Определяет, перемещается ли прямоугольник
        /// </summary>
        public static bool IsRectangleMoving { get; private set; }

        /// <summary>
        /// Если указатель мыши находится внутри прямоугольника, то задает разницу 
        /// между координатами верхнего левого угла прямоугольника и текущим положением курсора
        /// </summary>
        public static void SetDifferenceBetweenCoordinates(MouseEventArgs e)
        {
            rectangle = Selection.Region;

            if (rectangle.Contains(e.Location))
            {
                IsRectangleMoving = true;
                deltaX = e.X - rectangle.TopX;
                deltaY = e.Y - rectangle.TopY;
            }
            else
            {
                IsRectangleMoving = false;
            }
        }

        /// <summary>
        /// Если прямоугольник сейчас двигается, то изменяет координаты его левого верхнего угла 
        /// в соответствии с перемещением курсора
        /// </summary>
        public static void ChangeRectangleCoordinates(MouseEventArgs e)
        {
            if (IsRectangleMoving)
            {
                rectangle.TopX = e.X - deltaX;
                rectangle.TopY = e.Y - deltaY;
            }
        }
    }
}
