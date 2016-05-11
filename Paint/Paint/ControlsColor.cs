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
    /// Предоставляет изменение фонового цвета элементов управления
    /// </summary>
    public static class ControlsColor
    {
        private static Color passiveColor = Color.FromArgb(255, 227, 237, 247);
        private static Color activeColor = Color.FromArgb(255, 178, 211, 248);

        /// <summary>
        /// Представляет метод, который будет обрабатывать событие, не имеющее данных
        /// </summary>
        public delegate void EventHandler();

        /// <summary>
        /// Происходит после изменение основного цвета
        /// </summary>
        public static event EventHandler MainColorChanged;

        /// <summary>
        /// Возвращает основной цвет
        /// </summary>
        public static Color MainColor { get; private set; }

        /// <summary>
        /// Устанавливает соответствующие пассивные цвета для всех элементов управления
        /// </summary>
        public static void SetPassiveColor(MenuStrip menuStrip, Panel panelForTools, Panel panelForInserting,
            Panel panelForSelection, Panel panelForTextTools, Panel panelForForm)
        {
            menuStrip.BackColor = Color.FromArgb(255, 212, 222, 235);
            panelForTools.BackColor = passiveColor;

            foreach (Control control in panelForTools.Controls)
            {
                control.BackColor = passiveColor;
            }

            foreach (Control control in panelForInserting.Controls)
            {
                control.BackColor = passiveColor;
            }

            foreach (Control control in panelForSelection.Controls)
            {
                control.BackColor = passiveColor;
            }

            foreach (Control control in panelForTextTools.Controls)
            {
                if (control is Button)
                {
                    control.BackColor = passiveColor;
                }
            }

            panelForForm.BackColor = Color.FromArgb(255, 205, 215, 230);
        }

        /// <summary>
        /// Устанавливает фоновый цвет. Каждый раз при нажатии активный цвет чередуется с пассивным
        /// </summary>
        public static void ChangeButtonBackColor(object sender)
        {
            if (sender is Button)
            {
                var button = (Button)sender;

                if (button.BackColor == activeColor)
                {
                    button.BackColor = passiveColor;
                }
                else
                {
                    button.BackColor = activeColor;
                }
            }
        }

        /// <summary>
        /// Устанавливает основной цвет, выбранный пользователем в диалоговом окне
        /// </summary>
        public static void SetMainColor(PictureBox pictureBoxForMainColor, ref Color mainColor)
        {
            var colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                mainColor = colorDialog.Color;
                pictureBoxForMainColor.BackColor = mainColor;
                MainColor = mainColor;
                MainColorChanged();
            }
        }

        /// <summary>
        /// Устанавливает дополнительный цвет, выбранный пользователем в диалоговом окне
        /// </summary>
        public static void SetBackgroundColor(PictureBox mainPictureBox, PictureBox pictureBoxForBackColor, ref Color backColor)
        {
            var colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                backColor = colorDialog.Color;
                pictureBoxForBackColor.BackColor = backColor;
                mainPictureBox.BackColor = backColor;
            }
        }
    }
}
