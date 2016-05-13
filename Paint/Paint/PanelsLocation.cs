using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    /// <summary>
    /// Предоставляет расположение набора инструментов на ленте
    /// </summary>
    public class PanelsLocation
    {
        private Button buttonForText;
        private Panel panelForClipboardTools;
        private Panel panelForImageTools;
        private Panel panelForWorkTools;
        private Panel panelForShapeTools;
        private Panel panelForPenWidth;
        private Panel panelForColors;
        private Panel panelForTextTools;

        private Point panelForWorkToolsLocation;
        private Point panelForColorsLocation;
        private int distanceBetweenPanels = 3;

        public PanelsLocation(Button buttonForText, Panel panelForClipboardTools, Panel panelForImageTools, Panel panelForWorkTools,
            Panel panelForShapeTools, Panel panelForPenWidth, Panel panelForColors, Panel panelForTextTools)
        {
            this.buttonForText = buttonForText;
            this.panelForClipboardTools = panelForClipboardTools;
            this.panelForImageTools = panelForImageTools;
            this.panelForWorkTools = panelForWorkTools;
            this.panelForShapeTools = panelForShapeTools;
            this.panelForPenWidth = panelForPenWidth;
            this.panelForColors = panelForColors;
            this.panelForTextTools = panelForTextTools;
            buttonForText.EnabledChanged += new EventHandler(ChangePanelsLocation);
        }

        /// <summary>
        /// Устанавливает расположение панелей перед началом работы
        /// </summary>
        public void SetStartPanelsLocation()
        {
            panelForClipboardTools.Location = new Point(1, 1);
            panelForImageTools.Location = DefinePanelLocation(panelForClipboardTools);
            panelForWorkTools.Location = DefinePanelLocation(panelForImageTools);
            panelForShapeTools.Location = DefinePanelLocation(panelForWorkTools);
            panelForPenWidth.Location = DefinePanelLocation(panelForShapeTools);
            panelForColors.Location = DefinePanelLocation(panelForPenWidth);
            panelForTextTools.Location = DefinePanelLocation(panelForColors);
            InitializeFields();
        }

        private Point DefinePanelLocation(Panel panel)
        {
            var location = panel.Location;
            var x = location.X + panel.Width + distanceBetweenPanels;
            return new Point(x, panel.Top);
        }

        private void InitializeFields()
        {
            panelForWorkToolsLocation = panelForWorkTools.Location;
            panelForColorsLocation = panelForColors.Location;
        }

        private void SetOldPanelsLocation()
        {
            panelForWorkTools.Location = panelForWorkToolsLocation;
            panelForColors.Location = panelForColorsLocation;
        }

        private void SetNewPanelsLocation()
        {
            panelForWorkTools.Location = panelForImageTools.Location;
            panelForTextTools.Location = DefinePanelLocation(panelForWorkTools);
            panelForColors.Location = DefinePanelLocation(panelForTextTools);
        }

        private void ChangePanelsLocation(object sender, EventArgs e)
        {
            if (!buttonForText.Enabled)
            {
                panelForImageTools.Visible = false;
                panelForShapeTools.Visible = false;
                panelForPenWidth.Visible = false;
                panelForTextTools.Visible = true;
                SetNewPanelsLocation();
            }
            else
            {
                panelForImageTools.Visible = true;
                panelForShapeTools.Visible = true;
                panelForPenWidth.Visible = true;
                panelForTextTools.Visible = false;
                SetOldPanelsLocation();
            }
        }
    }
}
