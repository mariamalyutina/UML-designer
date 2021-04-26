using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    public abstract class AbstractFactory
    {
        public Color Color { get; set; }
        public int Width { get; set; }

        public abstract IFigure GetShape(Color color, int width);
        public abstract IFigure GetShape(Color color, int width, Point MouseDownPosition, Point MouseUpPosition);
    }
}
