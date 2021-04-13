using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowInheritance : AbstractArrow
    {



        public ArrowInheritance()
        {
        }

        ArrowInheritance(Point mouseDownPosition, Point mouseUpPosition, Color color, int width)
        {
            MouseDownPosition = mouseDownPosition;
            MouseUpPosition = mouseUpPosition;
            Color = color;
            Width = width;
        }

        public override void Draw(Graphics graphics, Pen pen, int deltaX = 0, int deltaY = 0)
        {
            if (IsCurved)
            {
                Point arrowStart = GetPoints(MouseDownPosition, MouseUpPosition).ToArray()[2];
                Point arrowEnd = MouseUpPosition;

                Point lineEnd = Geometry.GetArrow(arrowEnd, arrowStart)[3]; //рисуем до начала отрисовки стрелочки

                if (arrowStart != arrowEnd)
                {
                    graphics.DrawPolygon(pen, Geometry.GetArrow(arrowEnd, arrowStart));
                    graphics.DrawLines(pen, GetPoints(MouseDownPosition, lineEnd).ToArray());
                }
            }
            else
            {
                graphics.DrawLine(pen, MouseDownPosition, Geometry.GetArrow(MouseUpPosition, MouseDownPosition)[3]);
                graphics.DrawPolygon(pen, Geometry.GetArrow(MouseUpPosition, MouseDownPosition));
            }
            
        }

        public override object Clone()
        {
            return new ArrowInheritance(this.MouseDownPosition, this.MouseUpPosition, this.Color, this.Width);
        }
    }
}
