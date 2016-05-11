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
    public class ExtRichTextBox : RichTextBox
    {
        public ExtRichTextBox()
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

        public new void Paste()
        {
            base.Paste();
        }

        private new void TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as RichTextBox;

            if (Text == "")
            {
                var size = TextRenderer.MeasureText("a", Font);
                Height = size.Height * 2;
                Width = size.Width * 2;
            }
            else
            {
                var textSize = TextRenderer.MeasureText(Text, Font);
                var wordSize = TextRenderer.MeasureText("a", Font);
                Height = textSize.Height + wordSize.Height;
                Width = textSize.Width + wordSize.Width;
            }

            if (Clipboard.ContainsText() && Text.Length > Clipboard.GetText().Length)
            {
                if (Text.Substring(0, Clipboard.GetText().Length) == Clipboard.GetText())
                {
                    Text = Text.Remove(0, Clipboard.GetText().Length);
                    SelectionStart = Text.Length;
                }
            }
        }
    }
}
