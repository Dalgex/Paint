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
    /// Отвечает за рисование на графическом окне в процессе
    /// </summary>
    public class PaintingInAction
    {
        private List<Point> points = new List<Point>();
        private Point startPoint; // точка в момент нажатия
        private Point currentPoint; // текущая позиция
        private Point previousPoint; // предыдущая позиция
        
        private Button buttonForLine;
        private Button buttonForBrush;
        private Button buttonForEraser;
        private Button buttonForPipette;
        private Button buttonForColorFilling;
        private Button buttonForEllipse;
        private Button buttonForRectangle;
        private Button activeButton;
        
        private History history;
        private HistoryData historyData;
        private MyBitmap myBitmap;
        private ShapeBuilder shapeBuilder;

        private bool isLineDrawn;
        private bool isShapeDrawn;
        private bool isPressed;
        private bool wasMouseMove;

        public PaintingInAction(Button buttonForLine, Button buttonForBrush, Button buttonForEraser, Button buttonForPipette,
            Button buttonForColorFilling, Button buttonForEllipse, Button buttonForRectangle, Button activeButton, 
            History history, HistoryData historyData, MyBitmap myBitmap)
        {
            this.buttonForLine = buttonForLine;
            this.buttonForBrush = buttonForBrush;
            this.buttonForEraser = buttonForEraser;
            this.buttonForPipette = buttonForPipette;
            this.buttonForColorFilling = buttonForColorFilling;
            this.buttonForEllipse = buttonForEllipse;
            this.buttonForRectangle = buttonForRectangle;
            this.activeButton = activeButton;
            this.history = history;
            this.historyData = historyData;
            this.myBitmap = myBitmap;
        }

        /// <summary>
        /// Обновляет ссылку на activeButton, чтобы не потерять связь между полями activeButton 
        /// класса PaintingInAction и activeButton класса Paint
        /// </summary>
        public void Update(Button activeButton)
        {
            this.activeButton = activeButton;
        }

        /// <summary>
        /// Обновляет ссылки, чтобы два поля класса PaintingInAction продолжали ссылаться на соответствующие поля класса Paint
        /// </summary>
        public void Update(History history, HistoryData historyData)
        {
            this.history = history;
            this.historyData = historyData;
        }

        /// <summary>
        /// Определяет, какая кнопка была нажата и подготавливает фигуру, соответствующую данной кнопке, к построению
        /// </summary>
        public void PrepareSelectedShapeForBuilding(MouseEventArgs e, ref Color mainColor, ref Color backgroundColor,
            PictureBox mainPictureBox, PictureBox pictureBoxForMainColor, PictureBox pictureBoxForBackgroundColor,
            int toolWidth, bool withContour, bool withFilling)
        {
            if (!buttonForPipette.Enabled)
            {
                Pipette.SetColor(e, ref mainColor, ref backgroundColor, mainPictureBox, pictureBoxForMainColor, pictureBoxForBackgroundColor);
                buttonForPipette.Enabled = true;

                if (activeButton != null)
                {
                    activeButton.Enabled = false;
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                isPressed = true;
                startPoint = e.Location;
                currentPoint = e.Location;
                wasMouseMove = false;

                if (!buttonForColorFilling.Enabled)
                {
                    FloodFill.FillRegion(myBitmap, history, historyData, mainPictureBox, e.Location, mainColor);
                }
                else if (!buttonForBrush.Enabled || !buttonForEraser.Enabled)
                {
                    points.Add(new Point(e.Location.X, e.Location.Y));
                    shapeBuilder = new ShapeBuilder(toolWidth);
                }
                else if (!buttonForLine.Enabled)
                {
                    shapeBuilder = new ShapeBuilder(mainColor, toolWidth);
                }
                else if (!buttonForEllipse.Enabled || !buttonForRectangle.Enabled)
                {
                    shapeBuilder = new ShapeBuilder(mainColor, backgroundColor, toolWidth, withContour, withFilling);
                }
            }
        }

        /// <summary>
        /// Определяет, какая фигура строится и вызывает соответствующие методы построения
        /// </summary>
        public void CallSelectedShapeBuilding(MouseEventArgs e, Color mainColor, Color backgroundColor, PictureBox mainPictureBox)
        {
            if (isPressed)
            {
                previousPoint = currentPoint;
                currentPoint = e.Location;

                if (!buttonForBrush.Enabled || !buttonForEraser.Enabled)
                {
                    points.Add(new Point(e.Location.X, e.Location.Y));

                    if (!buttonForEraser.Enabled)
                    {
                        shapeBuilder.BuildCurve(previousPoint, currentPoint, backgroundColor, mainPictureBox);
                    }
                    else
                    {
                        shapeBuilder.BuildCurve(previousPoint, currentPoint, mainColor, mainPictureBox);
                    }
                }
                else if (!buttonForLine.Enabled)
                {
                    isLineDrawn = true;
                    mainPictureBox.Invalidate();
                }
                else if (!buttonForEllipse.Enabled || !buttonForRectangle.Enabled)
                {
                    isShapeDrawn = true;
                    mainPictureBox.Invalidate();
                }
            }

            wasMouseMove = true;
        }

        /// <summary>
        /// Добавляет фигуру, которая до опускания кнопки мыши рисовалась, в историю
        /// </summary>
        public void AddSelectedShapeInHistory(MouseEventArgs e, Color mainColor, Color backgroundColor, int toolWidth,
            bool withContour, bool withFilling, PictureBox mainPictureBox)
        {
            if (isPressed)
            {
                isPressed = false;

                if (wasMouseMove && (!buttonForBrush.Enabled || !buttonForEraser.Enabled))
                {
                    if (!buttonForBrush.Enabled)
                    {
                        var curve = new Curve(points, new Pen(mainColor, toolWidth));
                        historyData.Shapes.Add(curve);
                    }
                    else
                    {
                        var curve = new Curve(points, new Pen(backgroundColor, toolWidth));
                        historyData.Shapes.Add(curve);
                    }

                    points = new List<Point>();
                    history.AddHistory(new CommandShape(historyData.Shapes[historyData.Shapes.Count - 1], "Добавление"), true);
                }
                else if (!buttonForLine.Enabled)
                {
                    var line = new Line(startPoint, currentPoint, new Pen(mainColor, toolWidth));
                    historyData.Shapes.Add(line);
                    history.AddHistory(new CommandShape(historyData.Shapes[historyData.Shapes.Count - 1], "Добавление"), true);
                }
                else if (!buttonForEllipse.Enabled || !buttonForRectangle.Enabled)
                {
                    if (!buttonForEllipse.Enabled)
                    {
                        var ellipse = new Ellipse(shapeBuilder.Pen, new SolidBrush(backgroundColor), shapeBuilder.TopX,
                            shapeBuilder.TopY, shapeBuilder.Width, shapeBuilder.Height, withContour, withFilling);
                        historyData.Shapes.Add(ellipse);
                    }
                    else
                    {
                        var rectangle = new Rectangle(new Pen(mainColor, toolWidth), new SolidBrush(backgroundColor),
                            shapeBuilder.TopX, shapeBuilder.TopY, shapeBuilder.Width, shapeBuilder.Height, withContour, withFilling);
                        historyData.Shapes.Add(rectangle);
                    }

                    history.AddHistory(new CommandShape(historyData.Shapes[historyData.Shapes.Count - 1], "Добавление"), true);
                }
                else if (!wasMouseMove && buttonForColorFilling.Enabled)
                {
                    points.Add(currentPoint);

                    if (!buttonForEraser.Enabled)
                    {
                        var curve = new Curve(points, new Pen(backgroundColor, toolWidth));
                        historyData.Shapes.Add(curve);
                    }
                    else
                    {
                        var curve = new Curve(points, new Pen(mainColor, toolWidth));
                        historyData.Shapes.Add(curve);
                    }

                    points = new List<Point>();
                    history.AddHistory(new CommandShape(historyData.Shapes[historyData.Shapes.Count - 1], "Добавление"), true);
                }

                mainPictureBox.Invalidate();
            }
        }

        /// <summary>
        /// Перерисовывает элемент управления
        /// </summary>
        public void RepaintAll(PaintEventArgs e)
        {
            e.Graphics.DrawImage(myBitmap.Bitmap, 0, 0);

            foreach (var shape in historyData.Shapes)
            {
                shape.Draw(e);
            }

            if (isLineDrawn)
            {
                isLineDrawn = false;
                shapeBuilder.BuildLine(startPoint, currentPoint, e);
            }
            else if (isShapeDrawn)
            {
                isShapeDrawn = false;

                if (!buttonForEllipse.Enabled)
                {
                    shapeBuilder.BuildEllipse(startPoint, currentPoint, e);
                }
                else if (!buttonForRectangle.Enabled)
                {
                    shapeBuilder.BuildRectangle(startPoint, currentPoint, e);
                }
            }
        }
    }
}
