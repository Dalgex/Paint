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
        private int distance = DistanceBetweenBordersPictureBoxAndPanel.Value;

        public ClipboardCommands(History history, HistoryData historyData, PanelResizer panelResizer, MyBitmap myBitmap)
        {
            this.history = history;
            this.historyData = historyData;
            this.panelResizer = panelResizer;
            this.myBitmap = myBitmap;
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
        public void PasteImage(PictureBox pictureBox)
        {
            if (Clipboard.ContainsImage())
            {
                var bitmap = new Bitmap(Clipboard.GetImage());
                PasteImage(pictureBox, bitmap);
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
        /// Помещает выделенный фрагмент изображения в буфер обмена, оставляя графическое окно без изменений
        /// </summary>
        public void CopyImage()
        {
            Clipboard.SetImage(ImageCapture.RegionBitmap.Bitmap);
        }

        /// <summary>
        /// Помещает выделенный фрагмент изображения в буфер обмена и удаляет эту часть изображения из графического окна
        /// </summary>
        public void CutImage(PictureBox pictureBox)
        {
            CopyImage();
            Selection.EraseSelection(myBitmap);
            pictureBox.Invalidate();
        }
    }
}
