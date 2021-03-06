﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    /// <summary>
    /// Предоставляет инструменты, связанные с текстом
    /// </summary>
    public class TextTools
    {
        private Button buttonForText;
        private Button buttonForBold;
        private Button buttonForItalic;
        private Button buttonForUnderline;
        private Button buttonForStrikeout;
        private Button buttonToFinish;
        private ComboBox comboBoxForFonts;
        private ComboBox comboBoxForSizes;
        private Panel panelForTextTools;
        private TextSettings textSettings;
        private MyBitmap myBitmap;
        private History history;
        private HistoryData historyData;
        private string startText;
        private bool wasSimulate;

        public MyTextBox MyTextBox { get; private set; }

        /// <summary>
        /// Определяет, нужно ли перерисовать текст Bitmap
        /// </summary>
        public bool DoesTextDraw { get; private set; }

        /// <summary>
        /// Показывает, существует ли TextBox в данный момент
        /// </summary>
        public bool DoesTextBoxExist
        {
            get { return MyTextBox.TextBox.Visible; }
        }

        public TextTools(Button buttonForText, Button buttonForBold, Button buttonForItalic, Button buttonForUnderline,
            Button buttonForStrikeout, Button buttonToFinish, ComboBox comboBoxForFonts, ComboBox comboBoxForSizes, MyBitmap myBitmap, 
            History history, HistoryData historyData, PictureBox pictureBox)
        {
            this.buttonForText = buttonForText;
            this.buttonForBold = buttonForBold;
            this.buttonForItalic = buttonForItalic;
            this.buttonForUnderline = buttonForUnderline;
            this.buttonForStrikeout = buttonForStrikeout;
            this.buttonToFinish = buttonToFinish;
            this.comboBoxForFonts = comboBoxForFonts;
            this.comboBoxForSizes = comboBoxForSizes;
            panelForTextTools = (Panel)comboBoxForFonts.Parent;
            this.myBitmap = myBitmap;
            this.history = history;
            this.historyData = historyData;
            textSettings = new TextSettings();
            MyTextBox = new MyTextBox(pictureBox);
            startText = string.Empty;
            MyTextBox.TextBox.VisibleChanged += new EventHandler(SimulateButtonForTextClick);
            MyTextBox.TextBox.VisibleChanged += new EventHandler(ChangeButtonForFinishEnabled);
            buttonForText.EnabledChanged += new EventHandler(CheckButtonEnabled);
            ControlsColor.MainColorChanged += ChangeTextColor;
            InitializeComboBoxForFonts();
            InitializeComboBoxForSizes();
            DisactivateTextPanel();
        }

        private void InitializeComboBoxForFonts()
        {
            foreach (var item in FontFamily.Families)
            {
                comboBoxForFonts.Items.Add(item.Name);
            }
        }

        private void InitializeComboBoxForSizes()
        {
            for (int i = 8; i < 13; i++)
            {
                comboBoxForSizes.Items.Add(i);
            }

            for (int i = 14; i < 29; i += 2)
            {
                comboBoxForSizes.Items.Add(i);
            }

            comboBoxForSizes.Items.Add(36);
            comboBoxForSizes.Items.Add(48);
            comboBoxForSizes.Items.Add(72);
        }

        private void SetVisible(bool value)
        {
            panelForTextTools.Visible = value;
        }

        private void SimulateButtonForTextClick(object sender, EventArgs e)
        {
            wasSimulate = true;
            buttonForText.PerformClick();
            wasSimulate = false;
        }

        private void CheckButtonEnabled(object sender, EventArgs e)
        {
            if (buttonForText.Enabled)
            {
                DisactivateTextPanel();
            }
            else
            {
                ActivateTextPanel();
            }
        }

        private void ActivateTextPanel()
        {
            SetVisible(true);
        }

        private void DisactivateTextPanel()
        {
            SetVisible(false);
        }

        /// <summary>
        /// Создает TextBox в заданном месте и задает основной цвет элемента управления
        /// </summary>
        public void CreateTextBox(Point location, Color color)
        {
            textSettings = new TextSettings(string.Empty, new Font(comboBoxForFonts.Text, int.Parse(comboBoxForSizes.Text), MyTextBox.TextBox.Font.Style), 
                color, location);
            MyTextBox.CreateTextBox(textSettings);
            startText = textSettings.Text;

            if (historyData.TextSettings.Count == 0)
            {
                historyData.TextSettings.Push(new TextSettings());
            }
        }

        /// <summary>
        /// Инициализирует TextBox, задавая текст, шрифт, цвет и расположение
        /// </summary>
        public void InitializeTextBox(TextSettings textSettings)
        {
            MyTextBox.InitializeTextBox(textSettings);
            startText = textSettings.Text;
            history.AddHistory(new CommandTextBox(MyTextBox, "Добавление"), true);
        }

        /// <summary>
        /// Удаляет TextBox
        /// </summary>
        public void DeleteTextBox(PictureBox pictureBox)
        {
            AddTextToHistory();
            history.AddHistory(new CommandTextBox(MyTextBox, "Удаление"), false);
            DrawText(pictureBox);
            MyTextBox.DeleteTextBox();
            pictureBox.Invalidate();
        }

        /// <summary>
        /// Добавляет текст в историю, если существует TextBox
        /// </summary>
        public void TryAddTextToHistory(PictureBox pictureBox)
        {
            if (DoesTextBoxExist && !wasSimulate)
            {
                DeleteTextBox(pictureBox);
            }
        }

        /// <summary>
        /// Добавляет текст в историю, если существует TextBox и этот текст еще не содержится в истории
        /// </summary>
        public void TryAddTextToHistory()
        {
            if (DoesTextBoxExist && (MyTextBox.TextBox.Text != MyTextBox.StartText || 
                MyTextBox.TextBox.Text == "" && historyData.TextSettings.Peek().Text != ""))
            {
                AddTextToHistory();
            }
        }

        private void AddTextToHistory()
        {
            textSettings = new TextSettings(MyTextBox.TextBox.Text, MyTextBox.TextBox.Font, 
                MyTextBox.TextBox.ForeColor, MyTextBox.TextBox.Location);

            if (historyData.TextSettings.Count == 0)
            {
                historyData.TextSettings.Push(new TextSettings());
            }

            history.AddHistory(new CommandTextBox(MyTextBox, "Добавление"), false);
            historyData.TextSettings.Push(textSettings);
            history.AddHistory(new CommandText(MyTextBox, textSettings), true);
        }

        private void DrawText(PictureBox pictureBox)
        {
            DoesTextDraw = true;
            MyTextBox.TextBox.Visible = false;
            myBitmap.ChangeBitmap(history, historyData, pictureBox);
            MyTextBox.TextBox.Visible = true;
            DoesTextDraw = false;
        }

        /// <summary>
        /// Обновляет ссылки, чтобы два поля класса TextTools продолжали ссылаться на соответствующие поля класса Paint
        /// </summary>
        public void Update(History history, HistoryData historyData)
        {
            this.history = history;
            this.historyData = historyData;
        }

        public void OnTextToolClick(object sender, PictureBox pictureBox)
        {
            if (sender is Button)
            {
                var button = (Button)sender;

                if (button == buttonToFinish)
                {
                    FinishText(pictureBox);
                }
                else
                {
                    ChangeFontStyle(button);
                }
            }
            else if (sender is ComboBox)
            {
                ChangeFont();
            }
        }

        private void FinishText(PictureBox pictureBox)
        {
            TryAddTextToHistory(pictureBox);
        }

        private void ChangeButtonForFinishEnabled(object sender, EventArgs e)
        {
            if (MyTextBox.TextBox.Visible)
            {
                buttonToFinish.Enabled = true;
            }
            else
            {
                buttonToFinish.Enabled = false;
            }
        }

        private void ChangeFontStyle(Button button)
        {
            var font = MyTextBox.TextBox.Font;

            if (button == buttonForBold)
            {
                font = new Font(MyTextBox.TextBox.Font, MyTextBox.TextBox.Font.Style ^ FontStyle.Bold);
            }
            else if (button == buttonForItalic)
            {
                font = new Font(MyTextBox.TextBox.Font, MyTextBox.TextBox.Font.Style ^ FontStyle.Italic);
            }
            else if (button == buttonForUnderline)
            {
                font = new Font(MyTextBox.TextBox.Font, MyTextBox.TextBox.Font.Style ^ FontStyle.Underline);
            }
            else if (button == buttonForStrikeout)
            {
                font = new Font(MyTextBox.TextBox.Font, MyTextBox.TextBox.Font.Style ^ FontStyle.Strikeout);
            }

            MyTextBox.TextBox.Font = font;
            ChangeTextBoxSize();

            ControlsColor.ChangeButtonBackColor(button);
        }

        private void ChangeFont()
        {
            try
            {
                MyTextBox.TextBox.Font = new Font(comboBoxForFonts.Text, int.Parse(comboBoxForSizes.Text), MyTextBox.TextBox.Font.Style);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Невозможно в данный момент применить этот шрифт", "Paint", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxForFonts.Text = "Times New Roman";
                MyTextBox.TextBox.Font = new Font(comboBoxForFonts.Text, int.Parse(comboBoxForSizes.Text), MyTextBox.TextBox.Font.Style);
            }

            ChangeTextBoxSize();
        }
        
        private void ChangeTextBoxSize()
        { 
            if (MyTextBox.TextBox.Text == "")
            {
                var size = TextRenderer.MeasureText("a", MyTextBox.TextBox.Font);
                MyTextBox.TextBox.Height = size.Height * 2;
                MyTextBox.TextBox.Width = size.Width * 2;
            }
            else
            {
                var textSize = TextRenderer.MeasureText(MyTextBox.TextBox.Text, MyTextBox.TextBox.Font);
                var wordSize = TextRenderer.MeasureText("a", MyTextBox.TextBox.Font);
                MyTextBox.TextBox.Height = textSize.Height + wordSize.Height;
                MyTextBox.TextBox.Width = textSize.Width + wordSize.Width;
            }
        }

        private void ChangeTextColor()
        {
            MyTextBox.TextBox.ForeColor = ControlsColor.MainColor;
        }
    }
}