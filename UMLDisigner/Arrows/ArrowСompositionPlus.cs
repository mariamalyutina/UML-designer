using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowСompositionPlus : AbstractArrow
    {

        public ArrowСompositionPlus(Color color, int width, AbstractLine lineType)
        {
            Color = color;
            Width = width;
            LineType = lineType;
            _capTypeBeginning = new WingsCap();
            _capTypeEnding = new FilledRombCap();
        }

        public override void Draw(Graphics graphics, int deltaX, int deltaY)
        {
            SetArrow(graphics, true);
        }

        public override object Clone()
        {
            return new ArrowСompositionPlus(this.Color, this.Width, this.LineType);
        }
    }
}