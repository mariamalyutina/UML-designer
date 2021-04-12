using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowAggregation : AbstractArrow
    {
        public ArrowAggregation(Point MouseDownPosition, Point MouseUpPosition)
        {
            this.MouseDownPosition = MouseDownPosition;
            this.MouseUpPosition = MouseUpPosition;
        }
        public ArrowAggregation()
        {
        }
        public override object Clone()
        {
            return new ArrowAggregation(this.MouseDownPosition, this.MouseDownPosition);
        }

        public override void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawLine(pen, MouseDownPosition, Geometry.GetRomb(MouseUpPosition, MouseDownPosition)[3]);
            graphics.DrawPolygon(pen, Geometry.GetRomb(MouseUpPosition, MouseDownPosition));
        }
    }
}
