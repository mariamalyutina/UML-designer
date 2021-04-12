using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowImplementation : AbstractArrow
    {
        public override void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawPolygon(pen, Geometry.GetArrow(MouseUpPosition, MouseDownPosition));
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            graphics.DrawLine(pen, MouseDownPosition, Geometry.GetArrow(MouseUpPosition, MouseDownPosition)[3]); //рисуем до начала отрисовки стрелочки
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid; //возвращение линии к норм типу
        }

        public override object Clone()
        {
            return new ArrowImplementation();
        }
    }
}
