using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowСomposition : IFigure
    {
        public void Draw(Graphics graphics, Pen pen, Point mouseUpPosition, Point mouseDownPosition)
        {
            SolidBrush brush = new SolidBrush(pen.Color);
            graphics.DrawLine(pen, mouseDownPosition, Geometry.GetRomb(mouseUpPosition, mouseDownPosition)[3]); //рисуем линию до начала ромбика
            graphics.DrawPolygon(pen, Geometry.GetRomb(mouseUpPosition, mouseDownPosition));
            graphics.FillPolygon(brush, Geometry.GetRomb(mouseUpPosition, mouseDownPosition));
        }
    }
}
