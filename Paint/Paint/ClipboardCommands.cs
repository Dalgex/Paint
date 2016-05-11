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
    /// Предоставляет методы для помещения данных в системный буфер обмена и извлечения данных из системного буфера обмена
    /// </summary>
    public class ClipboardCommands
    {
        private History history;
        private HistoryData historyData;
        private PanelResizer panelResizer;
        private MyBitmap myBitmap;
        private MyTextBox myTextBox;
        private int distance = DistanceBetweenBordersPictureBoxAndPanel.Value;

        public ClipboardCommands(History history, HistoryData historyData, PanelResizer panelResizer, MyBitmap myBitmap, MyTextBox myTextBox)
        {
            this.history = history;
            this.historyData = historyData;
            this.panelResizer = panelResizer;
            this.myBitmap = myBitmap;
            this.myTextBox = myTextBox;
        }

        /// <summary>
        /// Обновляет ссылки, чтобы два поля класса ClipboardCommands продолжали ссылаться на соответствующие поля класса Paint
        /// </summary>
        public void Update(History history, HistoryData historyData)
        {
            this.history = history;
            this.historyData = historyData;
        }

        /// <summary>
        /// Вставляет содержимое из буфера обмена
        /// </summary>
        public void Paste(PictureBox pictureBox)
        {
            if (myTextBox.TextBox.Visible)
            {
                TryPasteText();
            }
            else
            {
                TryPasteImage(pictureBox);
            }
        }

        private void TryPasteText()
        {
            if (Clipboard.ContainsText())
            {
                PasteText();
            }
            else
            {
                MessageBox.Show("Буфер обмена не содержит текст", "Paint", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PasteText()
        {
            //myTextBox.TextBox.Paste();
            myTextBox.TextBox.Text = myTextBox.TextBox.Text.Insert(myTextBox.TextBox.SelectionStart, 
                (string)Clipboard.GetDataObject().GetData(DataFormats.Text));
        }

        private void TryPasteImage(PictureBox pictureBox)
        {
            if (Clipboard.ContainsImage())
            {
                PasteImage(pictureBox, new Bitmap(Clipboard.GetImage()));
            }
            else
            {
                MessageBox.Show("Буфер обмена не содержит изображение", "Paint", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Вставляет содержимое из файла
        /// </summary>
        public void PasteImageFromFile(PictureBox pictureBox)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Вставить из";
            openFileDialog.Filter = "Все файлы изображений(*.BMP;*.PNG;*.JPEG;*.GIF)|*.BMP;*.PNG;*.JPG;*.GIF|PNG|*.png|JPEG|*.jpg;*.jpeg;*.jpe;*.jfif|GIF|*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var bitmap = new Bitmap(openFileDialog.FileName);
                PasteImage(pictureBox, bitmap);
            }
        }

        private void PasteImage(PictureBox pictureBox, Bitmap bitmap)
        {
            Selection.Deselect(myBitmap);
            var size = new Size(bitmap.Width + distance, bitmap.Height + distance);
            SetClientSize(ref size);
            var bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.DrawToBitmap(bmp, pictureBox.ClientRectangle);
            myBitmap.Bitmap = bmp;
            ImageCapture.RegionBitmap = new MyBitmap(bitmap);
            historyData.RegionBitmaps.Push(ImageCapture.RegionBitmap);
            history.AddHistory(new CommandRegionBitmap(ImageCapture.RegionBitmap), false);
            Selection.InitializeRegion(historyData.RegionBitmaps.Peek().Location, ImageCapture.RegionBitmap.Bitmap.Size);
            ActionsWithShapes.ClearShapes(history, historyData);
            historyData.Bitmaps.Push(myBitmap.Bitmap);
            history.AddHistory(new CommandBitmap(myBitmap), true);
            pictureBox.Refresh();
            var g = pictureBox.CreateGraphics();
            g.DrawImage(ImageCapture.RegionBitmap.Bitmap, 0, 0);
            g.DrawRectangle(Selection.Pen, Selection.TopX, Selection.TopY, Selection.Width, Selection.Height);
            Selection.DrawFrameForRegion();
        }

        private void SetClientSize(ref Size size)
        {
            if (size.Width > historyData.PanelSizes.Peek().Size.Width || size.Height > historyData.PanelSizes.Peek().Size.Height)
            {
                if (size.Width > historyData.PanelSizes.Peek().Size.Width)
                {
                    if (size.Height > historyData.PanelSizes.Peek().Size.Height)
                    {
                        size = new Size(size.Width, size.Height);
                    }
                    else
                    {
                        size = new Size(size.Width, historyData.PanelSizes.Peek().Size.Height);
                    }
                }
                else
                {
                    size = new Size(historyData.PanelSizes.Peek().Size.Width, size.Height);
                }

                panelResizer.SetPanelSize(size);
                historyData.PanelSizes.Push(new PanelSize(size));
                history.AddHistory(new CommandPanelSize(size, panelResizer), false);
            }
        }

        /// <summary>
        /// Помещает копию выделенных данных в буфер обмена. Исходные данные при этом не изменяются
        /// </summary>
        public void Copy()
        {
            if (ImageCapture.DoesRegionBitmapExist)
            {
                CopyImage();
            }
            else
            {
                CopyText();
            }
        }

        private void CopyImage()
        {
            Clipboard.SetImage(ImageCapture.RegionBitmap.Bitmap);
        }

        private void CopyText()
        {
            myTextBox.TextBox.Copy();
        }

        /// <summary>
        /// Помещает копию выделенных данных в буфер обмена. Выделенные данные затем удаляются из приложения
        /// </summary>
        public void Cut()
        {
            if (ImageCapture.DoesRegionBitmapExist)
            {
                CutImage();
            }
            else
            {
                CutText();
            }
        }

        private void CutImage()
        {
            CopyImage();
            Selection.EraseSelection(myBitmap);
        }

        private void CutText()
        {
            myTextBox.TextBox.Cut();
        }
    }
}
