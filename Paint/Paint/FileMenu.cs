using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    /// <summary>
    /// Предоставляет файловое меню
    /// </summary>
    public class FileMenu
    {
        private ToolStripMenuItem itemToCreate;
        private ToolStripMenuItem itemToOpen;
        private ToolStripMenuItem itemToSave;
        private ToolStripMenuItem itemToSaveAs;
        private FileMenuActions fileMenuActions;

        public FileMenu(FileMenuActions fileMenuActions, ToolStripMenuItem itemToCreate, ToolStripMenuItem itemToOpen, 
            ToolStripMenuItem itemToSave, ToolStripMenuItem itemToSaveAs)
        {
            this.itemToCreate = itemToCreate;
            this.itemToOpen = itemToOpen;
            this.itemToSave = itemToSave;
            this.itemToSaveAs = itemToSaveAs;
            this.fileMenuActions = fileMenuActions;
        }

        /// <summary>
        /// Определяет, какой пункт выбрали в меню и затем выполняет соответствующее действие
        /// </summary>
        public void DefindMenuItemClick(ref History history, ref HistoryData historyData,
            object sender, ref string text, System.Windows.Forms.PictureBox pictureBox)
        {
            var toolStripMenuItem = (System.Windows.Forms.ToolStripMenuItem)sender;

            if (toolStripMenuItem == itemToCreate)
            {
                fileMenuActions.CreateNewImage(ref history, ref historyData, pictureBox);
                pictureBox.Invalidate();
            }
            else if (toolStripMenuItem == itemToOpen)
            {
                text = fileMenuActions.OpenImage(ref history, ref historyData, pictureBox);
                pictureBox.Invalidate();
            }
            else if (toolStripMenuItem == itemToSave)
            {
                text = fileMenuActions.SaveImage(pictureBox);
            }
            else if (toolStripMenuItem == itemToSaveAs)
            {
                text = fileMenuActions.SaveAs(pictureBox);
            }
            else
            {
                text = fileMenuActions.SaveAs(sender, pictureBox);
            }
        }
    }
}
