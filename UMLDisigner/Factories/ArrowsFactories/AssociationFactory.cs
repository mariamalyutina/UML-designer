using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    class AssociationFactory : AbstractArrowFactory
    {
        public AssociationFactory(bool curved) : base (curved)
        {
        }

        public override IFigure GetShape(Color color, int width)
        {
            _firstCap = new WingsCap();
            Arrow figure = new Arrow(color, width, _lineType, _firstCap, null);
            return figure;
        }
    }
}
