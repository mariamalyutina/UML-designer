using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    class ArrowInheritanceCurved : AbstractArrow
    {
        public override void Draw(Graphics graphics, Pen pen)
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

        public override object Clone()
        {
            return new ArrowInheritanceCurved();
        }
    }
}
