using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowСomposition : AbstractArrow
    {
        public ArrowСomposition()
        {

        }

        public ArrowСomposition(Point mouseDownPosition, Point mouseUpPosition, Color color, int width)
        {
            MouseDownPosition = mouseDownPosition;
            MouseUpPosition = mouseUpPosition;
            Color = color;
            Width = width;
        }

        public override void Draw(Graphics graphics, Pen pen, int deltaX = 0, int deltaY = 0)
        {
            SolidBrush brush = new SolidBrush(pen.Color);
            graphics.DrawLine(pen, MouseDownPosition, Geometry.GetRomb(MouseUpPosition, MouseDownPosition)[3]); //рисуем линию до начала ромбика
            graphics.DrawPolygon(pen, Geometry.GetRomb(MouseUpPosition, MouseDownPosition));
            graphics.FillPolygon(brush, Geometry.GetRomb(MouseUpPosition, MouseDownPosition));
        }

        public override object Clone()
        {
            return new ArrowСomposition(this.MouseDownPosition, this.MouseUpPosition, this.Color, this.Width);
        }
    }
}
