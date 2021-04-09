using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowImplementation : IFigure
    {
        public void Draw(Graphics graphics, Pen pen, Point mouseUpPosition, Point mouseDownPosition)
        {
            graphics.DrawPolygon(pen, Geometry.GetArrow(mouseUpPosition, mouseDownPosition));
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            graphics.DrawLine(pen, mouseDownPosition, Geometry.GetArrow(mouseUpPosition, mouseDownPosition)[3]); //рисуем до начала отрисовки стрелочки
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid; //возвращение линии к норм типу
        }
    }
}
