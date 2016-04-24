using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Paint
{
    /// <summary>
    /// Расширяет некоторые методы контрола
    /// </summary>
    public static class ControlExtension
    {
        public static int GetClientWidth(this Control control)
        {
            return control.Width - FrameWidget.Distance;
        }

        public static int GetClientHeight(this Control control)
        {
            return control.Height - FrameWidget.Distance;
        }

        public static Size GetClientSize(this Control control)
        {
            return new Size(control.GetClientWidth(), control.GetClientHeight());
        }

        public static void SetClientWidth(this Control control, int width)
        {
            control.Width = width + FrameWidget.Distance;
        }

        public static void SetClientHeight(this Control control, int height)
        {
            control.Height = height + FrameWidget.Distance;
        }

        public static void SetClientSize(this Control control, Size size)
        {
            control.SetClientWidth(size.Width);
            control.SetClientHeight(size.Height);
        }
    }

    /// <summary>
    /// Предоставляет рамку для виджета
    /// </summary>
    public class FrameWidget
    {
        private Control control;
        public delegate void EventHandler();
        public event EventHandler FrameMouseUp;
        public event EventHandler FrameMouseMove;
        private Size size;
        private static int distance = DistanceBetweenBordersPictureBoxAndPanel.Value / 2;
        
        public static int Distance
        {
            get { return distance; }
        }

        public FrameWidget(Control control)
        {
            this.control = control;
            size = control.Size;
            InitializeComponent();
            control.Controls.Add(pictureBoxOnRightBorder);
            control.Controls.Add(pictureBoxOnBottomBorder);
            control.Controls.Add(pictureBoxInCorner);
        }

        private System.Windows.Forms.PictureBox pictureBoxOnRightBorder = new PictureBox();
        private System.Windows.Forms.PictureBox pictureBoxOnBottomBorder = new PictureBox();
        private System.Windows.Forms.PictureBox pictureBoxInCorner = new PictureBox();

        private void InitializeComponent()
        {
            // 
            // pictureBoxOnRightBorder
            // 
            this.pictureBoxOnRightBorder.BackColor = System.Drawing.Color.White;
            this.pictureBoxOnRightBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxOnRightBorder.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.pictureBoxOnRightBorder.Location = new System.Drawing.Point(control.GetClientWidth(), control.GetClientHeight() / 2);
            this.pictureBoxOnRightBorder.Name = "pictureBoxOnRightBorder";
            this.pictureBoxOnRightBorder.Size = new System.Drawing.Size(distance, distance);
            this.pictureBoxOnRightBorder.TabStop = false;
            this.pictureBoxOnRightBorder.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ChangeControlSize);
            this.pictureBoxOnRightBorder.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CallEventFrameMouseUp);
            // 
            // pictureBoxOnBottomBorder
            // 
            this.pictureBoxOnBottomBorder.BackColor = System.Drawing.Color.White;
            this.pictureBoxOnBottomBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxOnBottomBorder.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.pictureBoxOnBottomBorder.Location = new System.Drawing.Point(control.GetClientWidth() / 2, control.GetClientHeight());
            this.pictureBoxOnBottomBorder.Name = "pictureBoxOnBottomBorder";
            this.pictureBoxOnBottomBorder.Size = new System.Drawing.Size(distance, distance);
            this.pictureBoxOnBottomBorder.TabStop = false;
            this.pictureBoxOnBottomBorder.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ChangeControlSize);
            this.pictureBoxOnBottomBorder.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CallEventFrameMouseUp);
            // 
            // pictureBoxInCorner
            // 
            this.pictureBoxInCorner.BackColor = System.Drawing.Color.White;
            this.pictureBoxInCorner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxInCorner.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pictureBoxInCorner.Location = new System.Drawing.Point(control.GetClientWidth(), control.GetClientHeight());
            this.pictureBoxInCorner.Name = "pictureBoxInCorner";
            this.pictureBoxInCorner.Size = new System.Drawing.Size(distance, distance);
            this.pictureBoxInCorner.TabStop = false;
            this.pictureBoxInCorner.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ChangeControlSize);
            this.pictureBoxInCorner.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CallEventFrameMouseUp);
        }

        /// <summary>
        /// Добавляет рамку для графического окна
        /// </summary>
        public void AddFrameWidget()
        {
            control.Controls.Add(pictureBoxOnRightBorder);
            control.Controls.Add(pictureBoxOnBottomBorder);
            control.Controls.Add(pictureBoxInCorner);
            ChangeFrameLocation();
        }

        /// <summary>
        /// Удаляет рамку графического окна
        /// </summary>
        public void RemoveFrameWidget()
        {
            control.Controls.Remove(pictureBoxOnRightBorder);
            control.Controls.Remove(pictureBoxOnBottomBorder);
            control.Controls.Remove(pictureBoxInCorner);
        }

        private void CallEventFrameMouseUp(object sender, MouseEventArgs e)
        {
            if (size != control.Size)
            {
                if (FrameMouseUp != null)
                {
                    FrameMouseUp();
                }
            }
        }

        private void ChangeControlSize(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                var pictureBox = (PictureBox)sender;
                
                if (pictureBox == pictureBoxOnRightBorder)
                {
                    control.Width += e.X;
                }
                else if (pictureBox == pictureBoxOnBottomBorder)
                {
                    control.Height += e.Y;
                }
                else
                {
                    control.Width += e.X;
                    control.Height += e.Y;
                }               
                
                ChangeFrameLocation();

                if (FrameMouseMove != null)
                {
                    FrameMouseMove();
                }
            }
        }

        /// <summary>
        /// Изменяет местоположение рамки вокруг виджета
        /// </summary>
        public void ChangeFrameLocation()
        {
            pictureBoxOnRightBorder.Location = new Point(control.GetClientWidth(), control.GetClientHeight() / 2);
            pictureBoxOnBottomBorder.Location = new Point(control.GetClientWidth() / 2, control.GetClientHeight());
            pictureBoxInCorner.Location = new Point(control.GetClientWidth(), control.GetClientHeight());
        }
    }
}
