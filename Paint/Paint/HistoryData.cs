using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// Предоставляет данные, необходимые для истории изменений
    /// </summary>
    public class HistoryData
    {
        public List<Shape> Shapes { get; set; }
        public Stack<System.Drawing.Bitmap> Bitmaps { get; set; }
        public Stack<PanelSize> PanelSizes { get; set; }
        public Stack<MyBitmap> RegionBitmaps { get; set; }
        public Stack<TextSettings> TextSettings { get; set; }

        public HistoryData()
        {
            Shapes = new List<Shape>();
            Bitmaps = new Stack<System.Drawing.Bitmap>();
            PanelSizes = new Stack<PanelSize>();
            RegionBitmaps = new Stack<MyBitmap>();
            TextSettings = new Stack<TextSettings>();
        }
    }
}
