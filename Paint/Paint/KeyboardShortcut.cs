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
        private ToolStripMenuItem itemToSaveAs;

        private Button buttonForUndo;
        private Button buttonForRedo;
        private Button buttonToCut;
        private Button buttonToCopy;
        private Button buttonToPaste;
        private Button buttonToCrop;
        private Button buttonForBold;
        private Button buttonForItalic;
        private Button buttonForUnderline;
        private Button buttonToFinish;

        private ToolStripMenuItem itemToSelectAll;
        private ToolStripMenuItem itemToEraseSelection;
        private ToolStripMenuItem itemToDeselect;

        public KeyboardShortcut(ToolStripMenuItem itemToCreate, ToolStripMenuItem itemToOpen, ToolStripMenuItem itemToSave,
            ToolStripMenuItem itemToSaveAs, Button buttonForUndo, Button buttonForRedo, Button buttonToCrop, Button buttonToCut,
            Button buttonToCopy, Button buttonToPaste, Button buttonForBold, Button buttonForItalic, Button buttonForUnderline,
            Button buttonToFinish, ToolStripMenuItem itemToSelectAll, ToolStripMenuItem itemToEraseSelection, ToolStripMenuItem itemToDeselect)
        {
            this.itemToCreate = itemToCreate;
            this.itemToOpen = itemToOpen;
            this.itemToSave = itemToSave;
            this.itemToSaveAs = itemToSaveAs;
            this.buttonForUndo = buttonForUndo;
            this.buttonForRedo = buttonForRedo;
            this.buttonToCrop = buttonToCrop;
            this.buttonToCut = buttonToCut;
            this.buttonToCopy = buttonToCopy;
            this.buttonToPaste = buttonToPaste;
            this.buttonForBold = buttonForBold;
            this.buttonForItalic = buttonForItalic;
            this.buttonForUnderline = buttonForUnderline;
            this.buttonToFinish = buttonToFinish;
            this.itemToSelectAll = itemToSelectAll;
            this.itemToEraseSelection = itemToEraseSelection;
            this.itemToDeselect = itemToDeselect;
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
            else if (e.Control && e.Shift && e.KeyCode == Keys.S)
            {
                itemToSaveAs.PerformClick();
            }
            else if (e.Control && e.Shift && e.KeyCode == Keys.X)
            {
                buttonToCrop.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.X)
            {
                buttonToCut.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                buttonToCopy.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                buttonToPaste.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.B)
            {
                buttonForBold.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.I)
            {
                buttonForItalic.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.U)
            {
                buttonForUnderline.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                buttonToFinish.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
                itemToSelectAll.PerformClick();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                itemToEraseSelection.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.D)
            {
                itemToDeselect.PerformClick();
            }
        }
    }
}
