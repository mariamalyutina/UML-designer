using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowСomposition : AbstractArrow
    {

        public ArrowСomposition(Point MouseDownPosition, Point MouseUpPosition)
        {
            this.MouseDownPosition = MouseDownPosition;
            this.MouseUpPosition = MouseUpPosition;
        }
        public ArrowСomposition()
        {

        }
        public override object Clone()
        {
            return new ArrowСomposition(this.MouseDownPosition, this.MouseDownPosition);
        }
        public override void Draw(Graphics graphics, Pen pen)
        {
            SolidBrush brush = new SolidBrush(pen.Color);
            graphics.DrawLine(pen, MouseDownPosition, Geometry.GetRomb(MouseUpPosition, MouseDownPosition)[3]); //рисуем линию до начала ромбика
            graphics.DrawPolygon(pen, Geometry.GetRomb(MouseUpPosition, MouseDownPosition));
            graphics.FillPolygon(brush, Geometry.GetRomb(MouseUpPosition, MouseDownPosition));
        }
    }
}
