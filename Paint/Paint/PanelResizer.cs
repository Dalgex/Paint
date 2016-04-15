using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// Отвечает за изменение размеров панели
    /// </summary>
    public class PanelResizer
    {
        private System.Windows.Forms.Control panel;
        private History history;
        private HistoryData historyData;
        private FrameWidget frameWidget;
        private MyBitmap myBitmap;
        private System.Windows.Forms.Label label;
        private int distance = DistanceBetweenBordersPictureBoxAndPanel.Value;

        public PanelResizer(System.Windows.Forms.Control panel, History history, HistoryData historyData, 
            MyBitmap myBitmap, System.Windows.Forms.Label label)
        {
            this.panel = panel;
            frameWidget = new FrameWidget(panel);
            frameWidget.FrameMouseUp += AddInHistoryNewPanelSize;
            frameWidget.FrameMouseMove += ShowPictureBoxSize;
            this.historyData = historyData;
            this.history = history;
            this.label = label;
            this.myBitmap = myBitmap;
            ShowPictureBoxSize();
        }

        /// <summary>
        /// Обновляет ссылки, чтобы два поля класса PanelResizer продолжали ссылаться на соответствующие поля класса Paint
        /// </summary>
        public void Update(HistoryData historyData, History history)
        {
            this.historyData = historyData;
            this.history = history;
        }

        /// <summary>
        /// Меняет местами высоту и ширину панели
        /// </summary>
        public void ReversePanel()
        {
            int temp = panel.Width;
            panel.Width = panel.Height;
            panel.Height = temp;
            frameWidget.ChangeFrameLocation();
            historyData.PanelSizes.Push(new PanelSize(panel.Size));
            history.AddHistory(new CommandPanelSize(historyData.PanelSizes.Peek().Size, this), false);
            ShowPictureBoxSize();
        }

        private void AddInHistoryNewPanelSize()
        {
            Size size = historyData.PanelSizes.Peek().Size;
            historyData.PanelSizes.Push(new PanelSize(panel.Size));
            history.AddHistory(new CommandPanelSize(historyData.PanelSizes.Peek().Size, this), false);
            System.Windows.Forms.PictureBox pictureBox = (System.Windows.Forms.PictureBox)panel.Controls[0];
            myBitmap.ChangeBitmap(history, historyData, pictureBox);
        }

        private void ShowPictureBoxSize()
        {
            label.Text = "        " + (panel.Size.Width - distance) + ", " + (panel.Size.Height - distance) + " пкс";
        }

        /// <summary>
        /// Устанавливает размер панели
        /// </summary>
        public void SetPanelSize(System.Drawing.Size size)
        {
            panel.Size = size;
            frameWidget.ChangeFrameLocation();
            ShowPictureBoxSize();
        }
    }
}
