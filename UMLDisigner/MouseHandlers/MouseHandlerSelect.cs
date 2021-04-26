using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UMLDisigner
{
   
    class MouseHandlerSelect : IMouseHandler
    {
        public Core Core;
        private IFigure _select;

        public MouseHandlerSelect(Point mouseDownPosition)
        {
            Core = Core.GetInstance(new PictureBox());
            _select = new SelectingRectangle();
            _select.MouseDownPosition = mouseDownPosition;
        }

        public void MouseDown(MouseEventArgs e)
        {
            //Core.Brush.Clear();
            //Core.Brush.DrawMoveFigure(Core.Figures);
            //_select.MouseDownPosition = e.Location;

        }

        public void MouseMove(MouseEventArgs e)
        {
            _select.MouseUpPosition = e.Location;
            Core.Brush.DrawMoveFigure(_select);
        }

        public void MouseUp(MouseEventArgs e)
        {
            Core.Brush.Clear();
            Core.Brush.DrawMoveFigure(Core.Figures);

            foreach (IFigure figure in Core.Figures)
            {
                foreach(Point p in figure.GetFigurePoints())
                {
                    if(_select.IsHavingPoint(p))
                    {
                        Core.SelectedFigures.Add(figure);
                        break;
                    }
                }
            }
            if (Core.SelectedFigures.Count > 0)
            {
                Core.Brush.MarkAsSelected(Core.SelectedFigures);
            }
            Core.CrntMH = new MouseHandlerEditing();
        }
    }
}
