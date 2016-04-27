using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// Выполняет действия, связанные с объектом Bitmap, который находится внутри области выделения
    /// </summary>
    public class CommandRegionBitmap : Command
    {
        private MyBitmap bitmap;
        private System.Drawing.Point location;

        public CommandRegionBitmap(MyBitmap bitmap)
        {
            this.bitmap = bitmap;
            this.location = bitmap.Location;
        }

        public override void UnExecute(HistoryData historyData)
        {
            historyData.RegionBitmaps.Pop();
            ImageCapture.RegionBitmap = historyData.RegionBitmaps.Peek();
            DrawOrDeleteRegion(historyData);
        }

        public override void Execute(HistoryData historyData)
        {
            historyData.RegionBitmaps.Push(bitmap);
            ImageCapture.RegionBitmap = historyData.RegionBitmaps.Peek();
            DrawOrDeleteRegion(historyData);
        }

        private void DrawOrDeleteRegion(HistoryData historyData)
        {
            Selection.DeleteRegion();

            if (ImageCapture.RegionBitmap.Bitmap.Width != 1 || ImageCapture.RegionBitmap.Bitmap.Height != 1)
            {
                Selection.InitializeRegion(historyData.RegionBitmaps.Peek().Location, ImageCapture.RegionBitmap.Bitmap.Size);
                Selection.DrawFrameForRegion();
            }
        }
    }
}
