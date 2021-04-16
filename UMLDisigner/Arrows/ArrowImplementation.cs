using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowImplementation : AbstractArrow
    {

        public ArrowImplementation(Color color, int width)
        {
            //MouseDownPosition = mouseDownPosition;
            //MouseUpPosition = mouseUpPosition;
            Color = color;
            Width = width;
        }

        public override void Draw(Graphics graphics, Pen pen, int deltaX, int deltaY)
        {
            if (IsCurved)
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
            else
            {
                graphics.DrawPolygon(pen, Geometry.GetArrow(MouseUpPosition, MouseDownPosition));
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                graphics.DrawLine(pen, MouseDownPosition, Geometry.GetArrow(MouseUpPosition, MouseDownPosition)[3]); //рисуем до начала отрисовки стрелочки
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid; //возвращение линии к норм типу
            }
            
        }

        public override object Clone()
        {
            return new ArrowImplementation(this.Color, this.Width);
        }
    }
}
