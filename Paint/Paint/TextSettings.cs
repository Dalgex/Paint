using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// Предоставляет текст, его формат, цвет, расположение
    /// </summary>
    public class TextSettings
    {
        /// <summary>
        /// Возвращает текст
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Возвращает формат текста
        /// </summary>
        public Font Font { get; private set; }

        /// <summary>
        /// Возвращает цвет текста
        /// </summary>
        public Color Color { get; private set; }

        /// <summary>
        /// Возвращает координаты левого верхнего угла текста
        /// </summary>
        public Point Location { get; private set; }

        public TextSettings() { }

        public TextSettings(string text, Font font, Color color, Point location)
        {
            SetParameters(text, font, color, location);
        }

        private void SetParameters(string text, Font font, Color color, Point location)
        {
            Text = text;
            Font = font;
            Color = color;
            Location = location;
        }
    }
}
