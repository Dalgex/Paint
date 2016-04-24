using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;

namespace Paint
{
    public partial class Paint : Form
    {
        private History history = new History();
        private HistoryData historyData = new HistoryData();
        private PanelResizer panelResizer;
        private MyBitmap myBitmap;
        private FileMenuActions fileMenuActions;
        private FileMenu fileMenu;
        private ClipboardCommandsManager clipboardCommandsManager;
        private PaintingInAction paintingInAction;
        private KeyboardShortcut keyboardShortcut;
        private DefinitionEnabledControl tools;

        private int toolWidth = 10;
        private Color mainColor = Color.Black;
        private Color backgroundColor = Color.White;       
        private bool withContour = true;
        private bool withFilling;

        public Paint()
        {
            InitializeComponent();

            historyData.PanelSizes.Push(new PanelSize(panelForPictureBox.Size));
            myBitmap = new MyBitmap(new Bitmap(mainPictureBox.Width, mainPictureBox.Height));
            panelResizer = new PanelResizer(panelForPictureBox, history, historyData, myBitmap, labelForPictureBoxSize);
            historyData.Bitmaps.Push(myBitmap.Bitmap);
            tools = new DefinitionEnabledControl(buttonForBrush, buttonForSelection, panelResizer, myBitmap);
            
            fileMenuActions = new FileMenuActions(history, historyData, panelResizer, myBitmap);
            fileMenu = new FileMenu(fileMenuActions, itemToCreate, itemToOpen, itemToSave, itemToSaveAs);           
            clipboardCommandsManager = new ClipboardCommandsManager(history, historyData, panelResizer, myBitmap, 
                buttonToPaste, itemToPaste, itemToPasteFrom);
            

            paintingInAction = new PaintingInAction(buttonForLine, buttonForBrush, buttonForEraser, buttonForPipette, buttonForColorFilling,
                buttonForEllipse, buttonForRectangle, buttonForSelection, history, historyData, myBitmap, tools);
            keyboardShortcut = new KeyboardShortcut(itemToCreate, itemToOpen, itemToSave, buttonForUndo, buttonForRedo, buttonToPaste);
            InitializeColor();
        }

        private void InitializeColor()
        {
            menuStrip1.BackColor = Color.FromArgb(255, 212, 222, 235);
            panelForTools.BackColor = Color.FromArgb(255, 227, 237, 247);

            foreach (Control control in panelForTools.Controls)
            {
                control.BackColor = Color.FromArgb(255, 227, 237, 247);
            }

            foreach (Control control in panelForInserting.Controls)
            {
                control.BackColor = Color.FromArgb(255, 227, 237, 247);
            }

            panelForForm.BackColor = Color.FromArgb(255, 205, 215, 230);
        }

        private void OnFileMenuClick(object sender, EventArgs e)
        {
            string text = string.Empty;
            fileMenu.DefineMenuItemClick(ref history, ref historyData, sender, ref text, mainPictureBox);
            
            if (text != string.Empty)
            {
                Text = text + " - Paint";
            }
            else
            {
                Text = "Paint";
            }
        }

        private void MainPictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            paintingInAction.Update(history, historyData);
            paintingInAction.DefineAction(e, ref mainColor, ref backgroundColor, mainPictureBox, pictureBoxForMainColor,
                pictureBoxForBackgroundColor, toolWidth, withContour, withFilling);
        }

        private void MainPictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            paintingInAction.Update(history, historyData);
            MouseCursor.ShowCursorLocation(labelForCursorLocation, e);
            paintingInAction.PerformAction(e, mainColor, backgroundColor, mainPictureBox, Cursor);
        }

        private void MainPictureBoxMouseUp(object sender, MouseEventArgs e)
        {
            paintingInAction.Update(history, historyData);
            paintingInAction.CompleteAction(e, mainColor, backgroundColor, toolWidth, withContour, withFilling, mainPictureBox);
        }

        private void MainPictureBoxPaint(object sender, PaintEventArgs e)
        {
            paintingInAction.Update(history, historyData);
            paintingInAction.RepaintAll(e);
        }

        private void RotateClick(object sender, EventArgs e)
        {
            var toolStripMenuItem = (ToolStripMenuItem)sender;
            string temp = toolStripMenuItem.Text;
            BitmapRotation.RotateBitmap(myBitmap, history, historyData, mainPictureBox, panelResizer, temp);
            mainPictureBox.Invalidate();
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            tools.EnableControl(sender);
            mainPictureBox.Invalidate();
        }

        private void NumericUpDownValueChanged(object sender, EventArgs e)
        {
            toolWidth = (int)numericUpDown.Value;
        }
      
        private void NumericUpDownKeyUp(object sender, KeyEventArgs e)
        {
            if (numericUpDown.Value < 1 || numericUpDown.Value > 99)
            {
                if (numericUpDown.Value < 1)
                {
                    numericUpDown.Value = 1;
                }
                else
                {
                    numericUpDown.Value = 99;
                }
            }
        } 

        private void PanelForMainColorMouseClick(object sender, MouseEventArgs e)
        {
            DialogResult colorDialog = colorDialog1.ShowDialog();

            if (colorDialog == DialogResult.OK)
            {
                mainColor = colorDialog1.Color;
                pictureBoxForMainColor.BackColor = mainColor;
            }
        }

        private void PanelForBackgroundColorMouseClick(object sender, MouseEventArgs e)
        {
            DialogResult colorDialog = colorDialog2.ShowDialog();

            if (colorDialog == DialogResult.OK)
            {
                backgroundColor = colorDialog2.Color;
                pictureBoxForBackgroundColor.BackColor = backgroundColor;
            }
        }

        private void OnItemForOutLineClick(object sender, EventArgs e)
        {
            var toolStripMenuItem = (ToolStripMenuItem)sender;
            withContour = (toolStripMenuItem.Text == "Без контура") ? false : true;
        }

        private void OnItemForShapeFillingClick(object sender, EventArgs e)
        {
            var toolStripMenuItem = (ToolStripMenuItem)sender;
            withFilling = (toolStripMenuItem.Text == "Без заливки") ? false : true;
        }

        private void OnUndoClick(object sender, EventArgs e)
        {
            history.Undo(historyData);
            mainPictureBox.Invalidate();
        }

        private void OnRedoClick(object sender, EventArgs e)
        {
            history.Redo(historyData);
            mainPictureBox.Invalidate();
        }

        private void PipetteMouseDown(object sender, MouseEventArgs e)
        {
            buttonForPipette.Enabled = false;

            foreach (var control in panelForTools.Controls)
            {
                if (control is Button && control != buttonForPipette)
                {
                    Button button = (Button)control;
                    button.Enabled = true;
                }
            }
        }

        private void MainPictureBoxMouseLeave(object sender, EventArgs e)
        {
            labelForCursorLocation.Text = string.Empty;
        }

        private void OnClipboardCommandClick(object sender, EventArgs e)
        {
            clipboardCommandsManager.DefineClipboardCommandClick(sender, history, historyData, mainPictureBox);
            mainPictureBox.Invalidate();
        }

        private void PaintKeyDown(object sender, KeyEventArgs e)
        {
            keyboardShortcut.SimulateKeypress(e);
        }

        private void PaintFormClosing(object sender, FormClosingEventArgs e)
        {
            //fileMenuActions.OfferToSaveImage(mainPictureBox, e);
        }
    }
}
