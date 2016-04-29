using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    /// <summary>
    /// Предоставляет элементы управления и методы для определения выбранного контрола
    /// </summary>
    public class DefinitionEnabledControl
    {
        private Button activeButton;
        private Button buttonForSelection;
        private PanelResizer panelResizer;
        private MyBitmap myBitmap;

        public DefinitionEnabledControl(Button activeButton, Button buttonForSelection, PanelResizer panelResizer, MyBitmap myBitmap)
        {
            this.activeButton = activeButton;
            this.buttonForSelection = buttonForSelection;
            this.panelResizer = panelResizer;
            this.myBitmap = myBitmap;
            Selection.DrawFrameEvent += SimulateButtonForSelectionClick;
        }

        /// <summary>
        /// Позволяет выбранному элементу управления отвечать на действия пользователя
        /// и добавляет/удаляет рамку для графического окна, если была отключена/выбрана кнопка для выделения области
        /// </summary>
        public void EnableControl(object sender)
        {
            var control = (Button)sender;
            control.Enabled = false;
            activeButton.Enabled = true;

            if (control == buttonForSelection)
            {
                panelResizer.FrameWidget.RemoveFrameWidget();
            }
            else if (activeButton == buttonForSelection)
            {
                Selection.AddRegionBitmapToMainBitmap(myBitmap);
                panelResizer.FrameWidget.AddFrameWidget();
            }

            activeButton = control;
        }

        /// <summary>
        /// Делает неспособным выбранный элемент управления отвечать на действия пользователя
        /// </summary>
        public void DisableControl()
        {
            activeButton.Enabled = false;
        }

        /// <summary>
        /// Имитирует нажатие кнопки для выделения области
        /// </summary>
        public void SimulateButtonForSelectionClick()
        {
            buttonForSelection.PerformClick();
        }
    }
}
