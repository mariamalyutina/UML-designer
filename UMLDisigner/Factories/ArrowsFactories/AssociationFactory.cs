using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    public class AssociationFactory : AbstractArrowFactory
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

        public override IFigure GetShape(Color color, int width, Point MouseDownPosition, Point MouseUpPosition)
        {
            _firstCap = new WingsCap();
            Arrow figure = new Arrow(color, width, _lineType, _firstCap, null);
            figure.MouseDownPosition = MouseDownPosition;
            figure.MouseUpPosition = MouseUpPosition;
            return figure;
        }
    }
}
