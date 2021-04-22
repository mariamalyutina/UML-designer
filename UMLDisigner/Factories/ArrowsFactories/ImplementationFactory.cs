using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    class ImplementationFactory : AbstractArrowFactory
    {
        public ImplementationFactory(bool curved) : base(curved)
        {
            if (curved)
            {
                _lineType = new DashCurvedLine();
            }
            else
            {
                _lineType = new DashStraightLine();
            }
        }

        public override IFigure GetShape(Color color, int width)
        {
            _firstCap = new TriangleCap();
            Arrow figure = new Arrow(color, width, _lineType, _firstCap, null);
            return figure;
        }
    }
}
