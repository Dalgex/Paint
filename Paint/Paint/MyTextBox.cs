using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// Предоставляет доступ к элементу управления TextBox и содержит некоторые методы для его определения
    /// </summary>
    public class MyTextBox
    {
        /// <summary>
        /// Возвращает элемент управления TextBox
        /// </summary>
        public ExtRichTextBox TextBox { get; private set; }

        /// <summary>
        /// Возвращает текст, который отображается в самом начале на TextBox
        /// </summary>
        public string StartText { get; private set; }

        public MyTextBox(System.Windows.Forms.PictureBox pictureBox)
        {
            TextBox = new ExtRichTextBox();
            pictureBox.Controls.Add(TextBox);
            TextBox.Visible = false;
            TextBox.VisibleChanged += new EventHandler(InitializeStartText);
            InitializeTextBox(new TextSettings());
        }

        /// <summary>
        /// Создает TextBox в заданном месте и задает основной цвет элемента управления
        /// </summary>
        public void CreateTextBox(TextSettings textSettings)
        {
            TextBox.Visible = true;
            InitializeTextBox(textSettings);
        }

        /// <summary>
        /// Инициализирует TextBox, задавая текст, шрифт, цвет и расположение
        /// </summary>
        public void InitializeTextBox(TextSettings textSettings)
        {
            TextBox.Font = textSettings.Font;
            TextBox.Text = textSettings.Text;
            TextBox.ForeColor = textSettings.Color;
            TextBox.Location = textSettings.Location;
            StartText = textSettings.Text;

            if (TextBox.Text == "")
            {
                var size = System.Windows.Forms.TextRenderer.MeasureText("a", TextBox.Font);
                TextBox.Height = size.Height * 2;
                TextBox.Width = size.Width * 2;
            }
        }

        private void InitializeStartText(object sender, EventArgs e)
        {
            StartText = TextBox.Text;
        }

        /// <summary>
        /// Удаляет TextBox (делает его невидимым)
        /// </summary>
        public void DeleteTextBox()
        {
            TextBox.Visible = false;
        }

        /// <summary>
        /// Проверяет, содержит ли указанную точку TextBox
        /// </summary>
        public bool Contains(Point point)
        {
            var rect = new System.Drawing.Rectangle(TextBox.Location, TextBox.Size);
            return rect.Contains(point);
        }
    }
}
