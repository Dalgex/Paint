using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    /// <summary>
    /// Представляет горячие клавиши
    /// </summary>
    public class KeyboardShortcut
    {
        private ToolStripMenuItem itemToCreate;
        private ToolStripMenuItem itemToOpen;
        private ToolStripMenuItem itemToSave;

        private Button buttonForUndo;
        private Button buttonForRedo;
        private Button buttonToPaste;

        public KeyboardShortcut(ToolStripMenuItem itemToCreate, ToolStripMenuItem itemToOpen, ToolStripMenuItem itemToSave,
            Button buttonForUndo, Button buttonForRedo, Button buttonToPaste)
        {
            this.itemToCreate = itemToCreate;
            this.itemToOpen = itemToOpen;
            this.itemToSave = itemToSave;
            this.buttonForUndo = buttonForUndo;
            this.buttonForRedo = buttonForRedo;
            this.buttonToPaste = buttonToPaste;
        }

        /// <summary>
        /// Имитирует нажатие клавиш
        /// </summary>
        public void SimulateKeypress(KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                buttonForUndo.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.Y)
            {
                buttonForRedo.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.N)
            {
                itemToCreate.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.O)
            {
                itemToOpen.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                itemToSave.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                buttonToPaste.PerformClick();
            }
        }
    }
}
