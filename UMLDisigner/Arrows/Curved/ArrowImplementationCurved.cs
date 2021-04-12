using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    class ArrowImplementationCurved : AbstractArrow
    {
        public override void Draw(Graphics graphics, Pen pen)
        {
            Point arrowStart = GetPoints(MouseDownPosition, MouseUpPosition).ToArray()[2];
            Point arrowEnd = MouseUpPosition;

            Point lineEnd = Geometry.GetArrow(arrowEnd, arrowStart)[3]; //рисуем до начала отрисовки стрелочки

            if (arrowStart != arrowEnd)
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                graphics.DrawLines(pen, GetPoints(MouseDownPosition, lineEnd).ToArray());
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid; //возвращение линии к норм типу
                graphics.DrawPolygon(pen, Geometry.GetArrow(arrowEnd, arrowStart));
            }


        }
    }
}
