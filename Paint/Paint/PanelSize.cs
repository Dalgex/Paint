using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// Предоставляет размер панели
    /// </summary>
    public class PanelSize
    {
        /// <summary>
        /// Возвращает размер панели
        /// </summary>
        public System.Drawing.Size Size { get; private set; }

        public PanelSize(System.Drawing.Size size)
        {
            Size = size;
        }
    }
}
