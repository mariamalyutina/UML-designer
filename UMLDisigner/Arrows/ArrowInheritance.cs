using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowInheritance : AbstractArrow
    {
        public override void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawLine(pen, MouseDownPosition, Geometry.GetArrow(MouseUpPosition, MouseDownPosition)[3]);
            graphics.DrawPolygon(pen, Geometry.GetArrow(MouseUpPosition, MouseDownPosition));
        }
    }
}
