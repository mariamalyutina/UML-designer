using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowAggregation : AbstractArrow
    {
        public ArrowAggregation(Color color, int width, AbstractLine lineType)
        {
            Color = color;
            Width = width;
            LineType = lineType;
            _capTypeBeginning = new WhiteRombCap();
        }

        public override void Draw(Graphics graphics, int deltaX, int deltaY)
        {
            Point tmpMouseDownPosition = MouseDownPosition;
            Point tmpMouseUpPosition = MouseUpPosition;
            Size delta = new Size(deltaX, deltaY);
            MouseDownPosition = Point.Add(MouseDownPosition, delta);
            MouseUpPosition = Point.Add(MouseUpPosition, delta);
            SetArrow(graphics, false);
            MouseDownPosition = tmpMouseDownPosition;
            MouseUpPosition = tmpMouseUpPosition;
        }

        public override object Clone()
        {
            return new ArrowAggregation(this.Color, this.Width, this.LineType);

        }

    }
}
