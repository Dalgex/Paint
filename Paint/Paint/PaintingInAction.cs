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
        private Button buttonForSelection;
        private Button buttonForText;
        private PictureBox mainPictureBox;
        
        private History history;
        private HistoryData historyData;
        private SelectionHistoryMemento selectionHistoryMemento;
        private MyBitmap myBitmap;
        private ShapeBuilder shapeBuilder;
        private DefinitionEnabledControl tools;
        private TextTools textTools;

        private bool isLineDrawn;
        private bool isShapeDrawn;
        private bool isPressed;
        private bool wasMouseMove;
        private bool isSelectionDrawn;

        public PaintingInAction(Button buttonForLine, Button buttonForBrush, Button buttonForEraser, Button buttonForPipette,
            Button buttonForColorFilling, Button buttonForEllipse, Button buttonForRectangle, Button buttonForSelection, Button buttonForText,
            PictureBox mainPictureBox, History history, HistoryData historyData, MyBitmap myBitmap, DefinitionEnabledControl tools, TextTools textTools)
        {
            this.buttonForLine = buttonForLine;
            this.buttonForBrush = buttonForBrush;
            this.buttonForEraser = buttonForEraser;
            this.buttonForPipette = buttonForPipette;
            this.buttonForColorFilling = buttonForColorFilling;
            this.buttonForEllipse = buttonForEllipse;
            this.buttonForRectangle = buttonForRectangle;
            this.buttonForSelection = buttonForSelection;
            this.buttonForText = buttonForText;
            this.history = history;
            this.historyData = historyData;
            this.myBitmap = myBitmap;
            this.mainPictureBox = mainPictureBox;
            Selection.InitializeField(mainPictureBox);
            selectionHistoryMemento = new SelectionHistoryMemento(history, historyData, myBitmap);
            this.tools = tools;
            this.textTools = textTools;
        }

        /// <summary>
        /// Обновляет ссылки, чтобы два поля класса PaintingInAction продолжали ссылаться на соответствующие поля класса Paint
        /// </summary>
        public void Update(History history, HistoryData historyData)
        {
            this.history = history;
            this.historyData = historyData;
            selectionHistoryMemento.Update(history, historyData);
            textTools.Update(history, historyData);
        }

        /// <summary>
        /// Определяет, какая кнопка была нажата и подготавливает/выполняет соответствующую операцию
        /// </summary>
        public void DefineAction(MouseEventArgs e, ref Color mainColor, ref Color backgroundColor,
            PictureBox pictureBoxForMainColor, PictureBox pictureBoxForBackgroundColor,
            int toolWidth, bool withContour, bool withFilling)
        {
            if (!buttonForPipette.Enabled)
            {
                Pipette.SetColor(e, ref mainColor, ref backgroundColor, mainPictureBox, pictureBoxForMainColor, pictureBoxForBackgroundColor);
                buttonForPipette.Enabled = true;
                tools.DisableControl();
            }
            else if (e.Button == MouseButtons.Left)
            {
                isPressed = true;
                startPoint = e.Location;
                currentPoint = e.Location;
                wasMouseMove = false;

                if (!buttonForSelection.Enabled)
                {
                    MovingRectangle.DetermineIsRectangleMoving(Selection.Region, e);

                    if (Selection.DoesRegionExist)
                    {
                        if (!Selection.Region.Contains(e.Location))
                        {
                            Selection.Deselect(myBitmap);
                            mainPictureBox.Invalidate();
                        }
                        else
                        {
                            MovingRectangle.SetDifferenceBetweenCoordinates(e);
                        }
                    }
                }
                else if (!buttonForText.Enabled)
                {
                    if (textTools.DoesTextBoxExist)
                    {
                        if (!textTools.MyTextBox.Contains(e.Location))
                        {
                            textTools.DeleteTextBox(mainPictureBox);
                            textTools.CreateTextBox(e.Location, mainColor);
                        }
                    }
                    else
                    {
                        textTools.CreateTextBox(e.Location, mainColor);
                    }
                }
                else
                {
                    PrepareSelectedShapeForBuilding(e, ref mainColor, ref backgroundColor, toolWidth, withContour, withFilling);
                }
            }
        }

        /// <summary>
        /// Определяет, какая кнопка была нажата и подготавливает фигуру, соответствующую данной кнопке, к построению
        /// </summary>
        private void PrepareSelectedShapeForBuilding(MouseEventArgs e, ref Color mainColor, ref Color backgroundColor,
            int toolWidth, bool withContour, bool withFilling)
        {
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

        /// <summary>
        /// Выполняет соответствующее действие при перемещении указателя мыши по элементу управления
        /// </summary>
        public void PerformAction(MouseEventArgs e, Color mainColor, Color backgroundColor, Cursor cursor)
        {
            if (isPressed)
            {
                previousPoint = currentPoint;
                currentPoint = e.Location;

                if (previousPoint == currentPoint)
                {
                    return;
                }

                if (!buttonForSelection.Enabled)
                {
                    MovingRectangle.ChangeRectangleCoordinates(e);
                    isSelectionDrawn = true;
                    mainPictureBox.Invalidate();
                }
                else
                {
                    CallSelectedShapeBuilding(e, mainColor, backgroundColor);
                }
            }

            wasMouseMove = true;
        }

        /// <summary>
        /// Определяет, какая фигура строится и вызывает соответствующие методы построения
        /// </summary>
        private void CallSelectedShapeBuilding(MouseEventArgs e, Color mainColor, Color backgroundColor)
        {
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

        /// <summary>
        /// Завершает действие при отпускании кнопки мыши
        /// </summary>
        public void CompleteAction(MouseEventArgs e, Color mainColor, Color backgroundColor, int toolWidth,
            bool withContour, bool withFilling)
        {
            if (isPressed)
            {
                isPressed = false;
                
                if (!buttonForSelection.Enabled)
                {
                    if (Selection.DoesRegionExist)
                    {
                        if (!wasMouseMove)
                        {
                            return;
                        }

                        if (!ImageCapture.DoesRegionBitmapExist)
                        {
                            ImageCapture.GetImageFromSelectedRegion(myBitmap, Selection.Region, mainPictureBox, backgroundColor);
                        }

                        Selection.DrawFrameForRegion();
                        MovingRectangle.CallEventMouseUp();
                    }
                }
                else if (!buttonForText.Enabled)
                {

                }
                else
                {
                    AddSelectedShapeInHistory(e, mainColor, backgroundColor, toolWidth, withContour, withFilling);
                }
            }
        }

        /// <summary>
        /// Добавляет фигуру, которая до опускания кнопки мыши рисовалась, в историю
        /// </summary>
        private void AddSelectedShapeInHistory(MouseEventArgs e, Color mainColor, Color backgroundColor, int toolWidth,
            bool withContour, bool withFilling)
        {
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
            else if (isSelectionDrawn)
            {
                e.Graphics.DrawImage(ImageCapture.RegionBitmap.Bitmap, Selection.Region.Location);
                isSelectionDrawn = false;

                if (MovingRectangle.IsRectangleMoving)
                {
                    Selection.DrawMovingRegion(e);
                }
                else
                {
                    Selection.DrawRegion(startPoint, currentPoint, e);
                }

                Selection.DeleteFrame();
            }
            else if (Selection.IsRegionChanged)
            {
                e.Graphics.DrawImage(ImageCapture.RegionBitmap.Bitmap, Selection.StartingRegionPosition);
                Selection.Region.Draw(e);
            }
            else if (Selection.WasChangeFinished)
            {
                e.Graphics.DrawImage(ImageCapture.RegionBitmap.Bitmap, Selection.Region.Location);
                Selection.Region.Draw(e);
            }
            else if (history.WasHistoryAction && !buttonForSelection.Enabled)
            {
                e.Graphics.DrawImage(ImageCapture.RegionBitmap.Bitmap, ImageCapture.RegionBitmap.Location);
                Selection.Region.Draw(e);
                history.WasHistoryAction = false;
            }
            else if (textTools.DoesTextDraw)
            {
                TextRenderer.DrawText(e.Graphics, textTools.MyTextBox.TextBox.Text, textTools.MyTextBox.TextBox.Font, 
                    textTools.MyTextBox.TextBox.OffsetLocation, textTools.MyTextBox.TextBox.ForeColor, TextFormatFlags.NoPadding);
            }
        }
    }
}
