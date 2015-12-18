using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// Класс, в котором импортированы некоторые методы GDI для заливки
    /// </summary>
    public class GDI
    {
        public IntPtr ProxyCreateSolidBrush(uint color)
        {
            return CreateSolidBrush(color);
        }

        public bool ProxyExtFloodFill(IntPtr hdcSourse, int x, int y, uint сolorRefColor, uint nFillType)
        {
            return ExtFloodFill(hdcSourse, x, y, сolorRefColor, nFillType);
        }

        public IntPtr ProxySelectObject(IntPtr hdcSourse, IntPtr hBitmap)
        {
            return SelectObject(hdcSourse, hBitmap);
        }

        public IntPtr ProxyCreateCompatibleDC(IntPtr hdcSourse)
        {
            return CreateCompatibleDC(hdcSourse);
        }

        public bool ProxyDeleteObject(IntPtr hObject)
        {
            return DeleteObject(hObject);
        }

        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern IntPtr CreateSolidBrush(uint crColor);

        [System.Runtime.InteropServices.DllImport("gdi32", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern bool ExtFloodFill(IntPtr hdc, int x, int y, uint сolorRefColor, uint nFillType);

        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);
    }
}
