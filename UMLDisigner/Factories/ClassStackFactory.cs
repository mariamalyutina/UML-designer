using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    class ClassStackFactory : AbstractClassFactory
    {

        public override IFigure GetShape(Color color, int width)
        {
            _classType = new ClassStackFigure();
            Class figure = new Class(color, width, _classType);
            return figure;
        }
    }
}
