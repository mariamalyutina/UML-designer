using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    class CompositionPlusFactory : AbstractArrowFactory
    {
        public CompositionPlusFactory(bool curved) : base(curved)
        {
        }

        public override IFigure GetShape(Color color, int width)
        {
            _firstCap = new WingsCap();
            _endCap = new FilledRombCap();
            Arrow figure = new Arrow(color, width, _lineType, _firstCap, _endCap);
            return figure;
        }
    }
}
