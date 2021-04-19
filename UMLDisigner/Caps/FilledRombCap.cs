using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    class FilledRombCap : AbstractCap
    {
        public override void Draw(Graphics graphics, Pen pen, Point endPoint, Point startPoint)
        {
            if (endPoint != startPoint)
            {
                SolidBrush _brush = new SolidBrush(pen.Color);
                graphics.FillPolygon(_brush, Geometry.GetRomb(endPoint, startPoint));
                graphics.DrawPolygon(pen, Geometry.GetRomb(endPoint, startPoint));
            }
        }
    }
}
