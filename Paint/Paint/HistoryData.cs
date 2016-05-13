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
        /// <summary>
        /// Предоставляет список фигур, нарисованных на графическом окне
        /// </summary>
        public List<Shape> Shapes { get; set; }

        /// <summary>
        /// Предоставляет коллекцию объектов Bitmap, верхний элемент которой является главным изображением 
        /// на графическом окне в данный момент
        /// </summary>
        public Stack<System.Drawing.Bitmap> Bitmaps { get; set; }

        /// <summary>
        /// Предоставляет коллекцию объектов, содержащую сведения о размерах панели, которые менялись в ходе работы
        /// </summary>
        public Stack<PanelSize> PanelSizes { get; set; }

        /// <summary>
        /// Предоставляет коллецию объектов, изображения которых в ходе работы были внутри области выделения
        /// </summary>
        public Stack<MyBitmap> RegionBitmaps { get; set; }

        /// <summary>
        /// Предоставляет коллекцию объектов, которая в качестве своих элементов содержит параметры текста
        /// </summary>
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
