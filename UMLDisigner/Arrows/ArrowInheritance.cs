using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowInheritance : AbstractArrow
    {



        public override void Draw(Graphics graphics, Pen pen)
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

    }
}
