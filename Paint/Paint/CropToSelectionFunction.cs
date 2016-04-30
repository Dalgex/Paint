using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    /// <summary>
    /// Предоставляет метод обрезать изображение по границе выделенной области
    /// </summary>
    public class CropToSelectionFunction
    {
        private Button buttonToCrop;
        private MyBitmap myBitmap;
        private PanelResizer panelResizer;

        public CropToSelectionFunction(Button buttonToCrop, MyBitmap myBitmap, PanelResizer panelResizer)
        {
            this.buttonToCrop = buttonToCrop;
            this.myBitmap = myBitmap;
            this.panelResizer = panelResizer;
            Selection.RegionCreated += EnableButton;
            Selection.RegionDeleted += DisableButton;
            DisableButton();
        }

        private void EnableButton()
        {
            buttonToCrop.Enabled = true;
        }

        private void DisableButton()
        {
            buttonToCrop.Enabled = false;
        }

        /// <summary>
        /// Уменьшает размер изображения так, что остается только выделенная область
        /// </summary>
        public void CropToSelection(History history, HistoryData historyData, PictureBox pictureBox)
        {
            myBitmap.Bitmap = new System.Drawing.Bitmap(ImageCapture.RegionBitmap.Bitmap);
            var distance = DistanceBetweenBordersPictureBoxAndPanel.Value;
            var size = new System.Drawing.Size(myBitmap.Bitmap.Width + distance, myBitmap.Bitmap.Height + distance);
            panelResizer.SetPanelSize(size);
            historyData.PanelSizes.Push(new PanelSize(size));
            history.AddHistory(new CommandPanelSize(size, panelResizer), false);
            ImageCapture.DeleteRegionBitmap();
            historyData.RegionBitmaps.Push(ImageCapture.RegionBitmap);
            history.AddHistory(new CommandRegionBitmap(ImageCapture.RegionBitmap), false);
            ActionsWithShapes.ClearShapes(history, historyData);
            historyData.Bitmaps.Push(myBitmap.Bitmap);
            history.AddHistory(new CommandBitmap(myBitmap), true);
            Selection.DeleteRegion();
            pictureBox.Invalidate();
        }
    }
}
