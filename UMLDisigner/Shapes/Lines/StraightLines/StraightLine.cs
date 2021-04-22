using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    class StraightLine : AbstractLine
    {
        public override void Draw(Graphics graphics, Pen pen, Point endPoint, Point startPoint)
        {
            graphics.DrawLine(pen, endPoint, startPoint);
        }
    }
}
