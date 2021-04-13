using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowImplementation : AbstractArrow
    {
        public ArrowImplementation()
        {

        }

        ArrowImplementation(Point mouseDownPosition, Point mouseUpPosition, Color color, int width)
        {
            MouseDownPosition = mouseDownPosition;
            MouseUpPosition = mouseUpPosition;
            Color = color;
            Width = width;
        }

        public override void Draw(Graphics graphics, Pen pen, int deltaX = 0, int deltaY = 0)
        {
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            graphics.DrawLine(pen, MouseDownPosition, Geometry.GetArrow(MouseUpPosition, MouseDownPosition)[3]); //рисуем до начала отрисовки стрелочки
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid; //возвращение линии к норм типу
            graphics.DrawPolygon(pen, Geometry.GetArrow(MouseUpPosition, MouseDownPosition));
           
            
        }

        public override object Clone()
        {
            return new ArrowImplementation(this.MouseDownPosition, this.MouseUpPosition, this.Color, this.Width);
        }
    }
}
