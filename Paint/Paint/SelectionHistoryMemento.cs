using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// Добавляет в историю действия, связанные с областью выделения
    /// </summary>
    public class SelectionHistoryMemento
    {
        private History history;
        private HistoryData historyData;
        private MyBitmap myBitmap;

        public SelectionHistoryMemento(History history, HistoryData historyData, MyBitmap myBitmap)
        {
            ImageCapture.RegionBitmapCreated += AddBitmapsAfterSelectionOrDeselection;
            ImageCapture.RegionDeselected += AddBitmapsAfterSelectionOrDeselection;
            ImageCapture.RegionScaled += AddRegionBitmapAfterScaling;
            MovingRectangle.MouseUp += AddRegionBitmapAfterMoving;
            this.history = history;
            this.historyData = historyData;
            this.myBitmap = myBitmap;
        }

        /// <summary>
        /// Обновляет ссылки, чтобы два поля класса HistoryMemento продолжали ссылаться на соответствующие поля класса Paint
        /// </summary>
        public void Update(History history, HistoryData historyData)
        {
            this.history = history;
            this.historyData = historyData;
        }

        private void AddBitmapsAfterSelectionOrDeselection()
        {
            historyData.RegionBitmaps.Push(ImageCapture.RegionBitmap);
            history.AddHistory(new CommandRegionBitmap(ImageCapture.RegionBitmap), false);
            ActionsWithShapes.ClearShapes(history, historyData);
            historyData.Bitmaps.Push(myBitmap.Bitmap);
            history.AddHistory(new CommandBitmap(myBitmap), true);
        }

        private void AddRegionBitmapAfterScaling()
        {
            historyData.RegionBitmaps.Push(ImageCapture.RegionBitmap);
            history.AddHistory(new CommandRegionBitmap(ImageCapture.RegionBitmap), true);
        }

        private void AddRegionBitmapAfterMoving()
        {
            ImageCapture.RegionBitmap = new MyBitmap(ImageCapture.RegionBitmap.Bitmap, Selection.Region.Location);
            historyData.RegionBitmaps.Push(ImageCapture.RegionBitmap);
            history.AddHistory(new CommandRegionBitmap(ImageCapture.RegionBitmap), true);
        }
    }
}
