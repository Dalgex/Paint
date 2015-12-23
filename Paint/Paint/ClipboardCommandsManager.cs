using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    /// <summary>
    /// Отслеживает действия пользователя, связанные с буфером обмена
    /// </summary>
    public class ClipboardCommandsManager
    {
        private ClipboardCommands clipboardCommands;
        private Button buttonToPaste;
        private ToolStripMenuItem itemToPaste;
        private ToolStripMenuItem itemToPasteFrom;

        public ClipboardCommandsManager(History history, HistoryData historyData, PanelResizer panelResizer, MyBitmap myBitmap, 
            Button buttonToPaste, ToolStripMenuItem itemToPaste, ToolStripMenuItem itemToPasteFrom)
        {
            clipboardCommands = new ClipboardCommands(history, historyData, panelResizer, myBitmap);
            this.buttonToPaste = buttonToPaste;
            this.itemToPaste = itemToPaste;
            this.itemToPasteFrom = itemToPasteFrom;
        }

        /// <summary>
        /// Определяет, на какую кнопку нажали и затем выполняет соответствующее действие
        /// </summary>
        public void DefineClipboardCommandClick(object sender, History history, HistoryData historyData, PictureBox pictureBox)
        {
            clipboardCommands.Update(history, historyData);

            if (sender is Button)
            {
                clipboardCommands.PasteImage(pictureBox);
            }
            else
            {
                var toolStripMenuItem = (System.Windows.Forms.ToolStripMenuItem)sender;

                if (toolStripMenuItem == itemToPaste)
                {
                    clipboardCommands.PasteImage(pictureBox);
                }
                else if (toolStripMenuItem == itemToPasteFrom)
                {
                    clipboardCommands.PasteImageFromFile(pictureBox);
                }
            }
        }
    }
}
