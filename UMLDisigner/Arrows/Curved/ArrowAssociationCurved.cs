using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    class ArrowAssociationCurved : AbstractArrow
    {
        public override void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawLines(pen, GetPoints(MouseDownPosition, MouseUpPosition).ToArray());

            Point arrowStart = GetPoints(MouseDownPosition, MouseUpPosition).ToArray()[2];
            Point arrowEnd = MouseUpPosition;

            if (arrowStart != arrowEnd)
            {
                graphics.DrawLine(pen, MouseUpPosition, Geometry.GetArrow(arrowEnd, arrowStart)[0]); //отрисовка крыльев стрелки
                graphics.DrawLine(pen, MouseUpPosition, Geometry.GetArrow(arrowEnd, arrowStart)[2]); //отрисовка крыльев стрелки
            }
        }

        public override object Clone()
        {
            return new ArrowAssociationCurved();
        }

    }
}
