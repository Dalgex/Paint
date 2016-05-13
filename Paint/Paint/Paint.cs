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
        private SelectionCommandsManager selectionCommandsManager;
        private PaintingInAction paintingInAction;
        private KeyboardShortcut keyboardShortcut;
        private CropToSelectionFunction cropToSelectionFunction;
        private DefinitionEnabledControl tools;
        private TextTools textTools;

        private int toolWidth = 10;
        private Color mainColor = Color.Black;
        private Color backgroundColor = Color.White;       
        private bool withContour = true;
        private bool withFilling;

        public Paint()
        {
            InitializeComponent();
            panelForPictureBox.Size = new Size(1350, 530);
            var panelsLocation = new PanelsLocation(buttonForText, panelForClipboardTools, panelForImageTools, panelForWorkTools,
                panelForShapeTools, panelForPenWidth, panelForColors, panelForTextTools);
            panelsLocation.SetStartPanelsLocation();

            historyData.PanelSizes.Push(new PanelSize(panelForPictureBox.Size));
            myBitmap = new MyBitmap(new Bitmap(mainPictureBox.Width, mainPictureBox.Height));
            panelResizer = new PanelResizer(panelForPictureBox, history, historyData, myBitmap, labelForPictureBoxSize);
            historyData.Bitmaps.Push(myBitmap.Bitmap);
            historyData.RegionBitmaps.Push(new MyBitmap(new Bitmap(1, 1), new Point(1, 1)));

            ControlsColor.SetPassiveColor(menuStrip, panelForControls, panelForInserting, panelForSelection, panelForTextTools,
                panelForClipboardTools, panelForImageTools, panelForWorkTools, panelForShapeTools, panelForForm);
            tools = new DefinitionEnabledControl(buttonForBrush, buttonForSelection, buttonForText, panelResizer, myBitmap);
            textTools = new TextTools(buttonForText, buttonForBold, buttonForItalic, buttonForUnderline, buttonForStrikeout,
                buttonToFinish, comboBoxForFonts, comboBoxForSizes, myBitmap, history, historyData, mainPictureBox);
            
            fileMenuActions = new FileMenuActions(history, historyData, panelResizer, myBitmap);
            fileMenu = new FileMenu(fileMenuActions, itemToCreate, itemToOpen, itemToSave, itemToSaveAs);           
            clipboardCommandsManager = new ClipboardCommandsManager(history, historyData, panelResizer, myBitmap, 
                buttonToCut, buttonToCopy, buttonToPaste, itemToPaste, itemToPasteFrom, textTools.MyTextBox);
            selectionCommandsManager = new SelectionCommandsManager(myBitmap, buttonForSelection, itemToSelectAll,
                itemToFillSelection, itemToEraseSelection, itemToDeselect);
            cropToSelectionFunction = new CropToSelectionFunction(buttonToCrop, myBitmap, panelResizer);

            paintingInAction = new PaintingInAction(buttonForLine, buttonForBrush, buttonForEraser, buttonForPipette, buttonForColorFilling,
                buttonForEllipse, buttonForRectangle, buttonForSelection, buttonForText, mainPictureBox, history, historyData, myBitmap, tools, textTools);
            keyboardShortcut = new KeyboardShortcut(itemToCreate, itemToOpen, itemToSave, itemToSaveAs, buttonForUndo, buttonForRedo,
                buttonToCrop, buttonToCut, buttonToCopy, buttonToPaste, buttonForBold, buttonForItalic, buttonForUnderline, buttonToFinish,
                itemToSelectAll, itemToEraseSelection, itemToDeselect);
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
            paintingInAction.DefineAction(e, ref mainColor, ref backgroundColor, pictureBoxForMainColor,
                pictureBoxForBackColor, toolWidth, withContour, withFilling);
        }

        private void MainPictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            paintingInAction.Update(history, historyData);
            MouseCursor.ShowCursorLocation(labelForCursorLocation, e);
            paintingInAction.PerformAction(e, mainColor, backgroundColor, Cursor);
        }

        private void MainPictureBoxMouseUp(object sender, MouseEventArgs e)
        {
            paintingInAction.Update(history, historyData);
            paintingInAction.CompleteAction(e, mainColor, backgroundColor, toolWidth, withContour, withFilling);
        }

        private void MainPictureBoxPaint(object sender, PaintEventArgs e)
        {
            paintingInAction.Update(history, historyData);
            paintingInAction.RepaintAll(e);
        }

        private void RotateClick(object sender, EventArgs e)
        {
            textTools.TryAddTextToHistory(mainPictureBox);
            var toolStripMenuItem = (ToolStripMenuItem)sender;
            string temp = toolStripMenuItem.Text;
            BitmapRotation.RotateBitmap(myBitmap, history, historyData, mainPictureBox, panelResizer, temp);
            mainPictureBox.Invalidate();
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            textTools.TryAddTextToHistory(mainPictureBox);
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
            ControlsColor.SetMainColor(pictureBoxForMainColor, ref mainColor);
        }

        private void PanelForBackgroundColorMouseClick(object sender, MouseEventArgs e)
        {
            ControlsColor.SetBackgroundColor(mainPictureBox, pictureBoxForBackColor, ref backgroundColor);
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
            textTools.TryAddTextToHistory();
            history.Undo(historyData);
            mainPictureBox.Invalidate();
        }

        private void OnRedoClick(object sender, EventArgs e)
        {
            history.Redo(historyData);
            mainPictureBox.Invalidate();
        }

        private void MainPictureBoxMouseLeave(object sender, EventArgs e)
        {
            labelForCursorLocation.Text = string.Empty;
        }

        private void OnClipboardCommandClick(object sender, EventArgs e)
        {
            clipboardCommandsManager.DefineClipboardCommandClick(sender, history, historyData, mainPictureBox);
        }

        private void OnSelectionClick(object sender, EventArgs e)
        {
            textTools.TryAddTextToHistory(mainPictureBox);
            selectionCommandsManager.DefineSelectionCommandClick(sender, mainColor);
        }

        private void buttonToCropClick(object sender, EventArgs e)
        {
            cropToSelectionFunction.CropToSelection(history, historyData, mainPictureBox);
        }

        private void OnTextToolClick(object sender, EventArgs e)
        {
            textTools.OnTextToolClick(sender, mainPictureBox);
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
