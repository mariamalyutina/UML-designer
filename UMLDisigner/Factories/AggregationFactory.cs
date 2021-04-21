using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    class AggregationFactory : AbstractArrowFactory
    {
        public AggregationFactory(bool curved) : base(curved)
        {
        }

        public override IFigure GetShape(Color color, int width)
        {
            _firstCap = new WhiteRombCap();
            Arrow figure = new Arrow(color, width, _lineType, _firstCap, null);
            return figure;
        }

        public override IFigure GetShape(Color color, int Width, Point MouseDownPosition, Point MouseUpPosition)
        {
            throw new NotImplementedException();
        }
    }
}
