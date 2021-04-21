﻿using System;
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
            _firstCap = new FilledRombCap();
            _endCap = new WhiteRombCap();
            Arrow figure = new Arrow(color, width, _lineType, _firstCap, _endCap);
            return figure;
        }

        public override IFigure GetShape(Color color, int Width, Point MouseDownPosition, Point MouseUpPosition)
        {
            throw new NotImplementedException();
        }
    }
}
