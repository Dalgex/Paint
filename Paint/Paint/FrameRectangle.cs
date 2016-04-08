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
    /// Предоставляет рамку для прямоугольной области выделения
    /// </summary>
    public class FrameRectangle
    {
        private Rectangle rect;
        private Rectangle offsetRect;
        private int length = 5;
        private Size size;
        private bool doesFrameExist;

        private PictureBox mainPictureBox;
        private PictureBox[] pictureBox = new PictureBox[8];
        
        public FrameRectangle(Rectangle rectangle, PictureBox pictureBox)
        {
            rect = rectangle;
            size = rect.Size;
            mainPictureBox = pictureBox;
            offsetRect = new Rectangle(rect.Pen, rect.Location, rect.Size);
            offsetRect.Offset(-length / 2, -length / 2);
            InitializeComponent();
            AddControls();
            doesFrameExist = true;
        }

        public void InitializeComponent()
        {
            for (int i = 0; i < 8; i++)
            {
                pictureBox[i] = new PictureBox();
                pictureBox[i].BackColor = System.Drawing.Color.White;
                pictureBox[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                pictureBox[i].Size = new System.Drawing.Size(length, length);
                pictureBox[i].TabStop = false;
                pictureBox[i].MouseMove += new System.Windows.Forms.MouseEventHandler(this.ChangeRegionSize);
                pictureBox[i].MouseUp += new System.Windows.Forms.MouseEventHandler(this.CallEventFrameMouseUp);

                if (i == 0)
                {
                    pictureBox[i].Cursor = System.Windows.Forms.Cursors.SizeNESW;
                    pictureBox[i].Location = new System.Drawing.Point(offsetRect.TopX + offsetRect.Width, offsetRect.TopY);
                    pictureBox[i].Name = "pictureBoxInTopRightCorner";
                }
                else if (i == 1)
                {
                    pictureBox[i].Cursor = System.Windows.Forms.Cursors.SizeWE;
                    pictureBox[i].Location = new System.Drawing.Point(offsetRect.TopX + offsetRect.Width, offsetRect.TopY + offsetRect.Height / 2);
                    pictureBox[i].Name = "pictureBoxOnRightBorder";
                }
                else if (i == 2)
                {
                    pictureBox[i].Cursor = System.Windows.Forms.Cursors.SizeNWSE;
                    pictureBox[i].Location = new System.Drawing.Point(offsetRect.TopX + offsetRect.Width, offsetRect.TopY + offsetRect.Height);
                    pictureBox[i].Name = "pictureBoxInBottomRightCorner";
                }
                else if (i == 3)
                {
                    pictureBox[i].Cursor = System.Windows.Forms.Cursors.SizeNS;
                    pictureBox[i].Location = new System.Drawing.Point(offsetRect.TopX + offsetRect.Width / 2, offsetRect.TopY + offsetRect.Height);
                    pictureBox[i].Name = "pictureBoxOnBottomBorder";
                }
                else if (i == 4)
                {
                    pictureBox[i].Cursor = System.Windows.Forms.Cursors.SizeNESW;
                    pictureBox[i].Location = new System.Drawing.Point(offsetRect.TopX, offsetRect.TopY + offsetRect.Height);
                    pictureBox[i].Name = "pictureBoxInBottomLeftCorner";
                }
                else if (i == 5)
                {
                    pictureBox[i].Cursor = System.Windows.Forms.Cursors.SizeWE;
                    pictureBox[i].Location = new System.Drawing.Point(offsetRect.TopX, offsetRect.TopY + offsetRect.Height / 2);
                    pictureBox[i].Name = "pictureBoxOnLeftBorder";
                }
                else if (i == 6)
                {
                    pictureBox[i].Cursor = System.Windows.Forms.Cursors.SizeNWSE;
                    pictureBox[i].Location = new System.Drawing.Point(offsetRect.TopX, offsetRect.TopY);
                    pictureBox[i].Name = "pictureBoxInTopLeftCorner";
                }
                else
                {
                    pictureBox[i].Cursor = System.Windows.Forms.Cursors.SizeNS;
                    pictureBox[i].Location = new System.Drawing.Point(offsetRect.TopX + offsetRect.Width / 2, offsetRect.TopY);
                    pictureBox[i].Name = "pictureBoxOnTopBorder";
                }
            }
        }

        private void AddControls()
        {
            for (int i = 0 ; i < 8; i++)
            {
                mainPictureBox.Controls.Add(pictureBox[i]);
            }
        }

        private void CallEventFrameMouseUp(object sender, MouseEventArgs e)
        {
            if (size != rect.Size)
            {
                //if (FrameMouseUp != null)
                {
                    //FrameMouseUp();
                }
            }
        }

        private void ChangeRegionSize(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                var pictureBox = (PictureBox)sender;

                if ((pictureBox.Name == "pictureBoxOnRightBorder") || (pictureBox.Name == "pictureBoxOnLeftBorder"))
                {
                    if (pictureBox.Name == "pictureBoxOnLeftBorder")
                    {
                        rect.TopX += e.X;
                        rect.Width -= e.X;
                    }
                    else
                    {
                        rect.Width += e.X;
                    }
                }
                else if ((pictureBox.Name == "pictureBoxOnBottomBorder") || (pictureBox.Name == "pictureBoxOnTopBorder"))
                {
                    if (pictureBox.Name == "pictureBoxOnTopBorder")
                    {
                        rect.TopY += e.Y;
                        rect.Height -= e.Y;
                    }
                    else
                    {
                        rect.Height += e.Y;
                    }
                }
                else
                {
                    if (pictureBox.Name == "pictureBoxInTopLeftCorner")
                    {
                        rect.TopX += e.X;
                        rect.TopY += e.Y;
                        rect.Width -= e.X;
                        rect.Height -= e.Y;
                    }
                    else if (pictureBox.Name == "pictureBoxInTopRightCorner")
                    {
                        rect.TopY += e.Y;
                        rect.Width += e.X;
                        rect.Height -= e.Y;
                    }
                    else if (pictureBox.Name == "pictureBoxInBottomLeftCorner")
                    {
                        rect.TopX += e.X;
                        rect.Width -= e.X;
                        rect.Height += e.Y;
                    }
                    else
                    {
                        rect.Width += e.X;
                        rect.Height += e.Y;
                    }
                }

                ChangeFrameLocation();

                //if (FrameMouseMove != null)
                {
                    //FrameMouseMove();
                }
            }
        }

        /// <summary>
        /// Изменяет местоположение рамки вокруг виджета
        /// </summary>
        public void ChangeFrameLocation()
        {
            offsetRect = new Rectangle(rect.Pen, rect.Location, rect.Size);
            offsetRect.Offset(-length / 2, -length / 2);
            pictureBox[0].Location = new Point(offsetRect.TopX + offsetRect.Width, offsetRect.TopY);
            pictureBox[1].Location = new Point(offsetRect.TopX + offsetRect.Width, offsetRect.TopY + offsetRect.Height / 2);
            pictureBox[2].Location = new Point(offsetRect.TopX + offsetRect.Width, offsetRect.TopY + offsetRect.Height);
            pictureBox[3].Location = new Point(offsetRect.TopX + offsetRect.Width / 2, offsetRect.TopY + offsetRect.Height);
            pictureBox[4].Location = new Point(offsetRect.TopX, offsetRect.TopY + offsetRect.Height);
            pictureBox[5].Location = new Point(offsetRect.TopX, offsetRect.TopY + offsetRect.Height / 2);
            pictureBox[6].Location = new Point(offsetRect.TopX, offsetRect.TopY);
            pictureBox[7].Location = new Point(offsetRect.TopX + offsetRect.Width / 2, offsetRect.TopY);
        }

        /// <summary>
        /// Удаляет рамку
        /// </summary>
        public void DeleteFrame()
        {
            if (doesFrameExist)
            {
                for (int i = 0; i < 8; i++)
                {
                    pictureBox[i].Dispose();
                }

                doesFrameExist = false;
            }
        }
    }
}
