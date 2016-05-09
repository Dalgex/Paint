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
    /// Предоставляет элемент управления TextBox, расширяя пару методов класса TextBox
    /// </summary>
    public class ExtTextBox : TextBox
    {
        public ExtTextBox()
            : base()
        {
            Multiline = true;
            WordWrap = true;
            base.TextChanged += new EventHandler(TextChanged);
        }

        /// <summary>
        /// Возвращает координаты левого верхнего угла textBox, смещенные на толщину границы textBox
        /// </summary>
        public Point OffsetLocation
        {
            get
            {
                var offsetLocation = Point.Add(Location, SystemInformation.Border3DSize);
                return new Point(offsetLocation.X + 1, offsetLocation.Y + 1);
            }
        }

        private new void TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;

            if (Text == "")
            {
                var size = TextRenderer.MeasureText("a", Font);
                Height = size.Height * 2;
                Width = size.Width * 2;
            }
            else
            {
                var textSize = TextRenderer.MeasureText(textBox.Text, textBox.Font);
                var wordSize = TextRenderer.MeasureText("a", textBox.Font);
                textBox.Height = textSize.Height + wordSize.Height / 2;
                textBox.Width = textSize.Width + wordSize.Width / 2;
            }
        }
    }
}
