using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Paint
{
    /// <summary>
    /// Выполняет действия с изображениями, описанные в меню
    /// </summary>
    public class FileMenuActions
    {
        private History history;
        private HistoryData historyData;
        private PanelResizer panelResizer;
        private MyBitmap myBitmap;
        private string existFileName = string.Empty;
        private string fullExistFileName;
        private int historyDataBitmapsCount;
        private int historyDataPanelSizesCount;
        private int historyDataShapesCount;

        public FileMenuActions(History history, HistoryData historyData, PanelResizer panelResizer, MyBitmap myBitmap)
        {
            this.history = history;
            this.historyData = historyData;
            this.panelResizer = panelResizer;
            this.myBitmap = myBitmap;
        }

        /// <summary>
        /// Создает новое изображение
        /// </summary>
        public void CreateNewImage(ref History history, ref HistoryData historyData, PictureBox pictureBox)
        {
            var wasCancel = false;
            OfferToSaveImage(pictureBox, ref wasCancel);
            
            if (!wasCancel)
            {
                myBitmap.Bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
                history = new History();
                this.history = history;
                historyData = new HistoryData();
                this.historyData = historyData;
                panelResizer.Update(historyData, history);
                historyData.Bitmaps.Push(myBitmap.Bitmap);
                historyData.RegionBitmaps.Push(new MyBitmap(new Bitmap(1, 1), new Point(1, 1)));
                historyData.PanelSizes.Push(new PanelSize(pictureBox.Size));
                existFileName = string.Empty;
            }
        }

        /// <summary>
        /// Открывает существующее изображение и возвращает имя и расширение файла
        /// </summary>
        public string OpenImage(ref History history, ref HistoryData historyData, PictureBox pictureBox)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Все файлы изображений(*.BMP;*.PNG;*.JPEG;*.GIF)|*.BMP;*.PNG;*.JPG;*.GIF|PNG|*.png|JPEG|*.jpg;*.jpeg;*.jpe;*.jfif|GIF|*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var wasCancel = false;
                OfferToSaveImage(pictureBox, ref wasCancel);

                if (!wasCancel)
                {
                    myBitmap.Bitmap = new Bitmap(openFileDialog.FileName);
                    var distance = DistanceBetweenBordersPictureBoxAndPanel.Value;
                    var size = new Size(myBitmap.Bitmap.Width + distance, myBitmap.Bitmap.Height + distance);
                    panelResizer.SetPanelSize(size);
                    history = new History();
                    this.history = history;
                    historyData = new HistoryData();
                    this.historyData = historyData;
                    panelResizer.Update(historyData, history);
                    historyData.Bitmaps.Push(myBitmap.Bitmap);
                    historyData.RegionBitmaps.Push(new MyBitmap(new Bitmap(1, 1), new Point(1, 1)));
                    historyData.PanelSizes.Push(new PanelSize(size));
                    SetFileNames(openFileDialog);
                }

                return existFileName;
            }

            return string.Empty;
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
        /// Сохраняет текущее изображение и возвращает имя и расширение файла. 
        /// Если текущий файл не был ранее сохранен, команда будет работать как SaveAs
        /// </summary>
        public string SaveImage(PictureBox pictureBox)
        {
            if (existFileName != string.Empty)
            {
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PNG|*.png|JPEG|*.jpg;*.jpeg;*.jpe;*.jfif|BMP|*.bmp|GIF|*.gif";
                saveFileDialog.FileName = fullExistFileName;
                SaveBitmapImage(pictureBox, saveFileDialog);
                WriteHistoryElementsCount();
                return existFileName;
            }
            else
            {
                return SaveAs(pictureBox);
            }
        }

        /// <summary>
        /// Позволяет сохранить текущее изображение под другим именем и/или в другом формате. 
        /// Возвращает имя и расширение файла
        /// </summary>
        public string SaveAs(PictureBox pictureBox)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG|*.png|JPEG|*.jpg;*.jpeg;*.jpe;*.jfif|BMP|*.bmp|GIF|*.gif";
            saveFileDialog.FileName = "Безымянный";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveBitmapImage(pictureBox, saveFileDialog);
                var openFileDialog = new OpenFileDialog();
                openFileDialog.FileName = saveFileDialog.FileName;
                SetFileNames(openFileDialog);
                WriteHistoryElementsCount();
                return existFileName;
            }

            return string.Empty;
        }

        /// <summary>
        /// Сохраняет изображение, дав возможность пользователю переименовать файл, 
        /// изменить его расширение (формат) или создать новую версию файла. 
        /// Возвращает имя и расширение файла
        /// </summary>
        public string SaveAs(object sender, PictureBox pictureBox)
        {
            var toolStripMenuItem = (ToolStripMenuItem)sender;
            var temp = toolStripMenuItem.Text.Split(' ');
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG|*.png|JPEG|*.jpg;*.jpeg;*.jpe;*.jfif|BMP|*.bmp|GIF|*.gif";
            saveFileDialog.FileName = "Безымянный";

            switch (temp[3])
            {
                case "PNG":
                {
                    saveFileDialog.FilterIndex = 1;
                    break;
                }

                case "JPEG":
                {
                    saveFileDialog.FilterIndex = 2;
                    break;
                }

                case "BMP":
                {
                    saveFileDialog.FilterIndex = 3;
                    break;
                }

                case "GIF":
                {
                    saveFileDialog.FilterIndex = 4;
                    break;
                }
            }
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveBitmapImage(pictureBox, saveFileDialog);
                var openFileDialog = new OpenFileDialog();
                openFileDialog.FileName = saveFileDialog.FileName;
                SetFileNames(openFileDialog);
                WriteHistoryElementsCount();
                return existFileName;
            }

            return string.Empty;
        }

        private void WriteHistoryElementsCount()
        {
            historyDataBitmapsCount = historyData.Bitmaps.Count;
            historyDataPanelSizesCount = historyData.PanelSizes.Count;
            historyDataShapesCount = historyData.Shapes.Count;
        }

        /// <summary>
        /// Предлагает сохранить изображение
        /// </summary>
        public void OfferToSaveImage(PictureBox pictureBox, FormClosingEventArgs e)
        {
            var wasCancel = false;
            OfferToSaveImage(pictureBox, ref wasCancel);

            if (wasCancel)
            {
                e.Cancel = true;
            }
        }

        private void OfferToSaveImage(PictureBox pictureBox, ref bool wasCancel)
        {
            if ((historyData.Bitmaps.Count > 1 || historyData.PanelSizes.Count > 1 || historyData.Shapes.Count > 0) && 
                (historyData.Bitmaps.Count != historyDataBitmapsCount || historyData.PanelSizes.Count != historyDataPanelSizesCount 
                || historyData.Shapes.Count != historyDataShapesCount))
            {
                switch (MessageBox.Show("Сохранить изменения в файл?", "Paint", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                    {
                        SaveBitmapImage(pictureBox, ref wasCancel);
                        break;
                    }
                    case DialogResult.Cancel:
                    {
                        wasCancel = true;
                        break;
                    }
                }
            }
        }

        private void SaveBitmapImage(PictureBox pictureBox, ref bool wasCancel)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG|*.png|JPEG|*.jpg;*.jpeg;*.jpe;*.jfif|BMP|*.bmp|GIF|*.gif";

            if (existFileName != string.Empty)
            {
                saveFileDialog.FileName = fullExistFileName;
                SaveBitmapImage(pictureBox, saveFileDialog);
            }
            else
            {
                saveFileDialog.FileName = "Безымянный";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveBitmapImage(pictureBox, saveFileDialog);
                }
                else
                {
                    wasCancel = true;
                }
            }
        }

        private void SaveBitmapImage(PictureBox pictureBox, SaveFileDialog saveFileDialog)
        {
            var bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.DrawToBitmap(bitmap, pictureBox.ClientRectangle);

            try
            {
                bitmap.Save(saveFileDialog.FileName);
            }
            catch (System.Runtime.InteropServices.ExternalException)
            {
                myBitmap.Bitmap.Dispose();
                bitmap.Save(saveFileDialog.FileName);
                myBitmap.Bitmap = bitmap;
            }
        }

        private void SetFileNames(OpenFileDialog openFileDialog)
        {
            fullExistFileName = openFileDialog.FileName;
            existFileName = openFileDialog.SafeFileName;
        }
    }
}
