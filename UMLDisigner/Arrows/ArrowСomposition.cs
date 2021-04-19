using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowСomposition : AbstractArrow
    {


        public ArrowСomposition(Color color, int width, AbstractLine lineType)
        {
            Color = color;
            Width = width;
            LineType = lineType;
            _capTypeBeginning = new FilledRombCap();
        }

        public override void Draw(Graphics graphics, int deltaX, int deltaY)
        {
            SetArrow(graphics, false);
        }

        public override object Clone()
        {
            return new ArrowСomposition(this.Color, this.Width, this.LineType);
        }
    }
}
