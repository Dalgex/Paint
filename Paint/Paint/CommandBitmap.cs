using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// Выполняет действия, связанные с объеком Bitmap
    /// </summary>
    public class CommandBitmap : Command
    {
        private MyBitmap myBitmap;
        private System.Drawing.Bitmap bitmap;

        public CommandBitmap(MyBitmap myBitmap)
        {
            this.myBitmap = myBitmap;
            bitmap = myBitmap.Bitmap;
        }

        public override void UnExecute(HistoryData historyData)
        {
            historyData.Bitmaps.Pop();
            myBitmap.Bitmap = historyData.Bitmaps.Peek();
        }

        public override void Execute(HistoryData historyData)
        {
            historyData.Bitmaps.Push(bitmap);
            myBitmap.Bitmap = historyData.Bitmaps.Peek();
        }
    }
}
