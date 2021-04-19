using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowAggregationPlus : AbstractArrow

    {

        public ArrowAggregationPlus(Color color, int width, AbstractLine lineType)
        {
            Color = color;
            Width = width;
            LineType = lineType;
            _capTypeBeginning = new WingsCap();
            _capTypeEnding = new WhiteRombCap();
        }

        public override void Draw(Graphics graphics, int deltaX, int deltaY)
        {
            SetArrow(graphics, true);
        }

        public override object Clone()
        {
            return new ArrowAggregationPlus(this.Color, this.Width, this.LineType);

        }

    }
}