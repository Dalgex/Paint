using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    /// <summary>
    /// Отслеживает действия пользователя, связанные с областью выделения
    /// </summary>
    public class SelectionCommandsManager
    {
        private Button buttonToSelect;
        private ToolStripMenuItem itemToSelectAll;
        private ToolStripMenuItem itemToFillSelection;
        private ToolStripMenuItem itemToEraseSelection;
        private ToolStripMenuItem itemToDeselect;
        private MyBitmap myBitmap;

        public SelectionCommandsManager(MyBitmap myBitmap, Button buttonToSelect, ToolStripMenuItem itemToSelectAll,
            ToolStripMenuItem itemToFillSelection, ToolStripMenuItem itemToEraseSelection, ToolStripMenuItem itemToDeselect)
        {
            this.buttonToSelect = buttonToSelect;
            this.itemToSelectAll = itemToSelectAll;
            this.itemToFillSelection = itemToFillSelection;
            this.itemToEraseSelection = itemToEraseSelection;
            this.itemToDeselect = itemToDeselect;
            this.myBitmap = myBitmap;
            DisableItems();
            Selection.RegionCreated += EnableItems;
            Selection.RegionDeleted += DisableItems;
        }

        private void DisableItems()
        {
            itemToFillSelection.Enabled = false;
            itemToEraseSelection.Enabled = false;
            itemToDeselect.Enabled = false;
        }

        private void EnableItems()
        {
            itemToFillSelection.Enabled = true;
            itemToEraseSelection.Enabled = true;
            itemToDeselect.Enabled = true;
        }

        /// <summary>
        /// Определяет, на какую кнопку нажали и затем выполняет соответствующее действие
        /// </summary>
        public void DefineSelectionCommandClick(object sender, System.Drawing.Color color)
        {
            buttonToSelect.PerformClick();

            if (!(sender is Button))
            {
                var toolStripMenuItem = (System.Windows.Forms.ToolStripMenuItem)sender;

                if (toolStripMenuItem == itemToSelectAll)
                {
                    Selection.SelectAll(myBitmap);
                }
                else if (toolStripMenuItem == itemToFillSelection)
                {
                    Selection.FillSelection(myBitmap, color);
                }
                else if (toolStripMenuItem == itemToEraseSelection)
                {
                    Selection.EraseSelection(myBitmap);
                }
                else if (toolStripMenuItem == itemToDeselect)
                {
                    Selection.Deselect(myBitmap);
                }
            }
        }
    }
}
