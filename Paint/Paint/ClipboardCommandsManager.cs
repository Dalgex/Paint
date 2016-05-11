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
        private Button buttonToCut;
        private Button buttonToCopy;
        private Button buttonToPaste;
        private ToolStripMenuItem itemToPaste;
        private ToolStripMenuItem itemToPasteFrom;
        private MyTextBox myTextBox;

        public ClipboardCommandsManager(History history, HistoryData historyData, PanelResizer panelResizer, MyBitmap myBitmap, 
            Button buttonToCut, Button buttonToCopy, Button buttonToPaste, ToolStripMenuItem itemToPaste, ToolStripMenuItem itemToPasteFrom, MyTextBox myTextBox)
        {
            clipboardCommands = new ClipboardCommands(history, historyData, panelResizer, myBitmap, myTextBox);
            this.buttonToCut = buttonToCut;
            this.buttonToCopy = buttonToCopy;
            this.buttonToPaste = buttonToPaste;
            this.itemToPaste = itemToPaste;
            this.itemToPasteFrom = itemToPasteFrom;
            this.myTextBox = myTextBox;
            myTextBox.TextBox.SelectionChanged += new EventHandler(CheckSelectedText);
            Selection.RegionCreated += EnableButtons;
            Selection.RegionDeleted += DisableButtons;
            DisableButtons();
        }

        private void CheckSelectedText(object sender, EventArgs e)
        {
            if (myTextBox.TextBox.SelectedText != "")
            {
                EnableButtons();
            }
            else
            {
                DisableButtons();
            }
        }
        
        private void EnableButtons()
        {
            buttonToCut.Enabled = true;
            buttonToCopy.Enabled = true;
        }

        private void DisableButtons()
        {
            buttonToCut.Enabled = false;
            buttonToCopy.Enabled = false;
        }

        /// <summary>
        /// Определяет, на какую кнопку нажали и затем выполняет соответствующее действие
        /// </summary>
        public void DefineClipboardCommandClick(object sender, History history, HistoryData historyData, PictureBox pictureBox)
        {
            clipboardCommands.Update(history, historyData);

            if (sender is Button)
            {
                var button = (Button)sender;

                if (button == buttonToCut)
                {
                    clipboardCommands.Cut();
                }
                else if (button == buttonToCopy)
                {
                    clipboardCommands.Copy();
                }
                else if (button == buttonToPaste)
                {
                    clipboardCommands.Paste(pictureBox);
                }
            }
            else
            {
                var toolStripMenuItem = (ToolStripMenuItem)sender;

                if (toolStripMenuItem == itemToPaste)
                {
                    clipboardCommands.Paste(pictureBox);
                }
                else if (toolStripMenuItem == itemToPasteFrom)
                {
                    clipboardCommands.PasteImageFromFile(pictureBox);
                }
            }
        }
    }
}
