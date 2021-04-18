using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    class TriangleCap : AbstractCap
    {
        public override void Draw(Graphics graphics, Pen pen, Point endPoint, Point startPoint)
        {
            graphics.DrawPolygon(pen, Geometry.GetArrow(endPoint, startPoint));
        }
    }
}
