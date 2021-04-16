using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowInheritance : AbstractArrow
    {
        AbstractCap _capType = new TriangleCap();

        public ArrowInheritance(Color color, int width)
        {
            //MouseDownPosition = mouseDownPosition;
            //MouseUpPosition = mouseUpPosition;
            Color = color;
            Width = width;
        }

        public override void Draw(Graphics graphics, Pen pen, int deltaX, int deltaY)
        {
            Pen pen1 = new Pen(Color, Width);
            //Line.Draw();

            graphics.DrawLine(pen, MouseDownPosition, Geometry.GetArrow(MouseUpPosition, MouseDownPosition)[3]);
            _capType.Draw(graphics, pen1, MouseUpPosition, MouseDownPosition);


            //if (IsCurved)
            //{
            //    Point arrowStart = GetPoints(MouseDownPosition, MouseUpPosition).ToArray()[2];
            //    Point arrowEnd = MouseUpPosition;

            //    Point lineEnd = Geometry.GetArrow(arrowEnd, arrowStart)[3]; //рисуем до начала отрисовки стрелочки

            //    if (arrowStart != arrowEnd)
            //    {
            //        graphics.DrawPolygon(pen, Geometry.GetArrow(arrowEnd, arrowStart));
            //        graphics.DrawLines(pen, GetPoints(MouseDownPosition, lineEnd).ToArray());
            //    }
            //}
            //else
            //{
            //    graphics.DrawLine(pen, MouseDownPosition, Geometry.GetArrow(MouseUpPosition, MouseDownPosition)[3]);
            //    graphics.DrawPolygon(pen, Geometry.GetArrow(MouseUpPosition, MouseDownPosition));
            //}
            
        }

        public override object Clone()
        {
            return new ArrowInheritance(this.Color, this.Width);
        }
    }
}
