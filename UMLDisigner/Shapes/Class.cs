using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    class Class : IFigure
    {
        public Point MouseUpPosition { get; set; }
        public Point MouseDownPosition { get; set; }

        public Color Color { get; set; }
        public int Width { get; set; }

        AbstractClassFigure _classType;

        public Class(Color color, int width, AbstractClassFigure classType)
        {
            Color = color;
            Width = width;
            _classType = classType;
        }

        public void Draw(Graphics graphics, int deltaX = 0, int deltaY = 0)
        {
            _classType.Draw(graphics, deltaX, deltaY);
        }

        public bool IsHavingPoint(Point checkedPoint)
        {
            throw new NotImplementedException();
        }


    }
}
