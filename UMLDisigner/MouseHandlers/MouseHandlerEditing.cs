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
        bool _isResizing;


        public MouseHandlerEditing()
        {
            Core = Core.GetInstance(new PictureBox());
            
        }

        public void MouseDown(MouseEventArgs e)
        {
            _isResizing = false;
            _isMoving = false;
            Core.SelectedFigures.Clear();

            foreach (IFigure figure in Core.Figures)
            {
                if (figure.IsHavingPoint(e.Location))
                {
                    Core.SelectedFigures.Add(figure);
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
                    if (!_isResizing)
                    {
                        _isMoving = true;
                        Core.Figure = figure;
                        _pointMovingMouseDownPosition = e.Location;
                        break;
                    }
                    
                }
                else
                {
                    //Core.CrntMH = new MouseHandlerSelect();
                }
            }

            if (_isMoving || _isResizing)
            {
                Core.Brush.Clear();
                Core.Brush.DrawMoveTmpFigure(Core.Figures);
                Core.Figures.Remove(Core.Figure);
                Core.Brush.DrawMoveFigure(Core.Figures);
                Core.Brush.MarkAsSelectedTmp(Core.SelectedFigures);

            }

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
            if (_isMoving || _isResizing)
            {
                Core.Brush.DrawMoveFigure(Core.Figure);
            }
        }

        public void MouseUp(MouseEventArgs e)
        {
            if(_isMoving)
            {
                Size delta = new Size(e.Location.X - _pointMovingMouseDownPosition.X, e.Location.Y - _pointMovingMouseDownPosition.Y);
                Core.Figure.MouseDownPosition = Point.Add(Core.Figure.MouseDownPosition, delta);
                Core.Figure.MouseUpPosition = Point.Add(Core.Figure.MouseUpPosition, delta);
            }

            if (_isMoving || _isResizing)
            {
                Core.Figures.Add(Core.Figure);
                Core.Figure = Core.Factory.GetShape(Core.Brush.Color, Core.Brush.TrackBarWidth);
            }
            if (Core.SelectedFigures.Count > 0)
            {
                Core.Brush.MarkAsSelected(Core.SelectedFigures);
            } 
            else
            {
                Core.Brush.Clear();
                Core.Brush.DrawMoveFigure(Core.Figures);
            }
            _isMoving = false;
            return;
        }
    }
}
