using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// Выполняет действия, связанные с размерами панели
    /// </summary>
    public class CommandPanelSize : Command
    {
        private System.Drawing.Size size;
        private PanelResizer panelResizer;

        public CommandPanelSize(System.Drawing.Size size, PanelResizer panelResizer)
        {
            this.size = size;
            this.panelResizer = panelResizer;
        }

        public override void Execute(HistoryData historyData)
        {
            historyData.PanelSizes.Push(new PanelSize(size));
            panelResizer.SetPanelSize(historyData.PanelSizes.Peek().Size);
        }

        public override void UnExecute(HistoryData historyData)
        {
            historyData.PanelSizes.Pop();
            panelResizer.SetPanelSize(historyData.PanelSizes.Peek().Size);
        }
    }
}
