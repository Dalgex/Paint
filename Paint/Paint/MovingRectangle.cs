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
        /// Показывает, перемещается ли прямоугольник
        /// </summary>
        public static bool IsRectangleMoving { get; private set; }

        /// <summary>
        /// Задает разницу между координатами верхнего левого угла прямоугольника и текущим положением курсора
        /// </summary>
        public static void SetDifferenceBetweenCoordinates(MouseEventArgs e)
        {
            IsRectangleMoving = true;
            deltaX = e.X - rectangle.TopX;
            deltaY = e.Y - rectangle.TopY;
        }

        /// <summary>
        /// Определяет, перемещается ли прямоугольник
        /// </summary>
        public static void DetermineIsRectangleMoving(MouseEventArgs e)
        {
            rectangle = Selection.Region;
            IsRectangleMoving = rectangle.Contains(e.Location);
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
