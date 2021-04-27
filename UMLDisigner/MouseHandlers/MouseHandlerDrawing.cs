using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace UMLDisigner
{
    class MouseHandlerDrawing : IMouseHandler
    {
        public Core Core;

        public MouseHandlerDrawing()
        {
            Core = Core.GetInstance();
        }

        public void MouseDown(MouseEventArgs e)
        {
            Core.Brush.Clear();
            Core.Brush.DrawMoveFigure(Core.Figures);


            Core.Figure.MouseDownPosition = e.Location;
           
        }

        public void MouseMove(MouseEventArgs e)
        {
            Core.Figure.MouseUpPosition = e.Location;
            Core.Brush.DrawMoveFigure(Core.Figure);
        }

        public void MouseUp(MouseEventArgs e)
        {
            Core.Figures.Add(Core.Figure);
            Core.Figure = Core.Factory.GetShape(Core.Brush.Color, Core.Brush.TrackBarWidth);
        }
    }
}
