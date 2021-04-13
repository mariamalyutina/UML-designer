using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace UMLDisigner
{
    class ArrowAssociation : AbstractArrow
    {


        public override void Draw(Graphics graphics, Pen pen)
        {
            if (IsCurved)
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
            else
            {
                graphics.DrawLine(pen, MouseDownPosition, MouseUpPosition);
                graphics.DrawLine(pen, MouseUpPosition, Geometry.GetArrow(MouseUpPosition, MouseDownPosition)[0]); //отрисовка крыльев стрелки
                graphics.DrawLine(pen, MouseUpPosition, Geometry.GetArrow(MouseUpPosition, MouseDownPosition)[2]); //отрисовка крыльев стрелки
            }
        }

    }
}
