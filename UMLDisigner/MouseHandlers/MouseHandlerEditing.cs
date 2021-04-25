using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UMLDisigner
{
    class MouseHandlerEditing : IMouseHandler
    {
        public Core Core;
        Point _pointMovingMouseDownPosition;
        bool _isEnd;
        bool _isMoving;
        


        public MouseHandlerEditing()
        {
            Core = Core.GetInstance(new PictureBox());
        }

        public void MouseDown(MouseEventArgs e)
        {
            bool _isResizing = false;

            foreach (IFigure figure in Core.Figures)
            {
                if (figure.IsHavingPoint(e.Location))
                {
                    if (figure is Arrow)
                    {
                        if (Math.Abs(figure.MouseDownPosition.X - e.X) < 10 && Math.Abs(figure.MouseDownPosition.Y - e.Y) < 10)
                        {
                            _isEnd = true;
                            _isResizing = true;
                            Core.Figure = figure;
                            break;
                        }
                        if (Math.Abs(figure.MouseUpPosition.X - e.X) < 10 && Math.Abs(figure.MouseUpPosition.Y - e.Y) < 10)
                        {
                            _isEnd = false;
                            _isResizing = true;
                            Core.Figure = figure;
                            break;
                        }
                    }
                    else if (figure is AbstractClassFigure)
                    {
                        Point[] Rectangle = Geometry.GetRectangle(figure.MouseUpPosition, figure.MouseDownPosition);

                        for (int i = 0; i < 4; ++i)
                        {
                            if (Math.Abs(Rectangle[i].X - e.X) < 10 && Math.Abs(Rectangle[i].Y - e.Y) < 10)
                            {
                                if (i == 0)
                                {
                                    Point tmp = figure.MouseDownPosition;
                                    figure.MouseDownPosition = figure.MouseUpPosition;
                                    figure.MouseUpPosition = tmp;
                                }
                                if (i == 1)
                                {
                                    figure.MouseDownPosition = Rectangle[3];
                                    figure.MouseUpPosition = Rectangle[1];
                                }
                                if (i == 3)
                                {
                                    figure.MouseDownPosition = Rectangle[1];
                                    figure.MouseUpPosition = Rectangle[3];
                                }
                                _isResizing = true;
                                Core.Figure = figure;
                                break;
                            }
                        }
                    }
                    if (!_isResizing)
                    {
                        _isMoving = true;
                        Core.Figure = figure;
                        _pointMovingMouseDownPosition = e.Location;
                        break;
                    }
                }

            }
            Core.Brush.Clear();
            Core.Brush.DrawMoveTmpFigure(Core.Figures);
            Core.Figures.Remove(Core.Figure);
            Core.Brush.DrawMoveFigure(Core.Figures);
        }

        public void MouseMove(MouseEventArgs e)
        {
            if (_isMoving)
            {
                int deltaX = e.Location.X - _pointMovingMouseDownPosition.X;
                int deltaY = e.Location.Y - _pointMovingMouseDownPosition.Y;
                Core.Brush.DrawMoveFigure(Core.Figure, deltaX, deltaY);
                return;
            }
            if (_isEnd)
            {
                Core.Figure.MouseDownPosition = e.Location;
            }
            else 
            {
                Core.Figure.MouseUpPosition = e.Location;
            }
            

            Core.Brush.DrawMoveFigure(Core.Figure);
        }

        public void MouseUp(MouseEventArgs e)
        {
            if(_isMoving)
            {
                Size delta = new Size(e.Location.X - _pointMovingMouseDownPosition.X, e.Location.Y - _pointMovingMouseDownPosition.Y);
                Core.Figure.MouseDownPosition = Point.Add(Core.Figure.MouseDownPosition, delta);
                Core.Figure.MouseUpPosition = Point.Add(Core.Figure.MouseUpPosition, delta);
                _isMoving = false;
            }
            

            Core.Figures.Add(Core.Figure);
            Core.Figure = Core.Factory.GetShape(Core.Brush.Color, Core.Brush.TrackBarWidth);

            return;
        }
    }
}
