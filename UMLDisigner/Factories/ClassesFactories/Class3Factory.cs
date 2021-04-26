using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    class Class3Factory : AbstractFactory
    {
        public override IFigure GetShape(Color color, int width)
        {
            AbstractClassFigure figure = new Class3Figure(color, width);
            return figure;
        }

        public override IFigure GetShape(Color color, int width, Point MouseDownPosition, Point MouseUpPosition)
        {
            throw new NotImplementedException();
        }
    }
}
