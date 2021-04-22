using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    class ClassStackFactory : AbstractFactory
    {

        public override IFigure GetShape(Color color, int width)
        {
            AbstractClassFigure figure = new ClassStackFigure(color, width);
            return figure;
        }
    }
}
