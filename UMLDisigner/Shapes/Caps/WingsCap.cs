using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    public class WingsCap : AbstractCap
    {
        public override void Draw(Graphics graphics, Pen pen, SolidBrush brush, Point endPoint, Point startPoint)
        {
            if (endPoint != startPoint)
            {
                graphics.DrawLine(pen, endPoint, Geometry.GetArrow(endPoint, startPoint)[0]); //отрисовка крыльев стрелки
                graphics.DrawLine(pen, endPoint, Geometry.GetArrow(endPoint, startPoint)[2]); //отрисовка крыльев стрелки
            }
               
        }
    }
}
