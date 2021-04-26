using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    public class InheritanceFactory : AbstractArrowFactory
    {
        public InheritanceFactory(bool curved) : base(curved)
        {

        }

        public override IFigure GetShape(Color color, int width)
        {
            _firstCap = new TriangleCap();
            Arrow figure = new Arrow(color, width, _lineType, _firstCap, null);
            return figure;
        }

        public override IFigure GetShape(Color color, int width, Point MouseDownPosition, Point MouseUpPosition)
        {
            _firstCap = new TriangleCap();
            Arrow figure = new Arrow(color, width, _lineType, _firstCap, null);
            figure.MouseDownPosition = MouseDownPosition;
            figure.MouseUpPosition = MouseUpPosition;
            return figure;
        }
    }
}
