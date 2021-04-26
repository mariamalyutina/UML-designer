using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    public class WhiteRombCap : AbstractCap
    {

        public override void Draw(Graphics graphics, Pen pen, SolidBrush brush, Point endPoint, Point startPoint)
        {
            if (endPoint != startPoint)
            {
                graphics.FillPolygon(brush, Geometry.GetRomb(endPoint, startPoint));
                graphics.DrawPolygon(pen, Geometry.GetRomb(endPoint, startPoint));
            }
        }
    }
}
