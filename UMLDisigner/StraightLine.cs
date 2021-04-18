using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    class StraightLine : AbstractLine
    {
        public override void Draw(Graphics graphics, Pen pen, Point startPoint, Point endPoint)
        {
            graphics.DrawLine(pen, startPoint, Geometry.GetArrow(endPoint, startPoint)[3]);
        }
    }
}
