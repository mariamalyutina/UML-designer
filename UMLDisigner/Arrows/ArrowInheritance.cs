using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowInheritance : IFigure
    {
        public void Draw(Graphics graphics, Pen pen, Point mouseUpPosition, Point mouseDownPosition)
        {
            graphics.DrawLine(pen, mouseDownPosition, Geometry.GetArrow(mouseUpPosition, mouseDownPosition)[3]);
            graphics.DrawPolygon(pen, Geometry.GetArrow(mouseUpPosition, mouseDownPosition));
        }
    }
}
