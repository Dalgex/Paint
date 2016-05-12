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
        private static bool isPressed;
        private static Rectangle rectangle;

        /// <summary>
        /// Представляет метод, который будет обрабатывать событие, не имеющее данных
        /// </summary>
        public delegate void EventHandler();

        /// <summary>
        /// Происходит после перемещения выделенной области
        /// </summary>
        public static event EventHandler MouseUp;

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
            isPressed = true;
            deltaX = e.X - rectangle.TopX;
            deltaY = e.Y - rectangle.TopY;
        }

        /// <summary>
        /// Определяет, перемещается ли прямоугольник
        /// </summary>
        public static void DetermineIsRectangleMoving(Rectangle rect, MouseEventArgs e)
        {
            rectangle = rect;
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

        /// <summary>
        /// Вызывает событие при отпускании конпки мыши
        /// </summary>
        public static void CallEventMouseUp()
        {
            if (isPressed)
            {
                MouseUp();
                isPressed = false;
            }
        }
    }
}
