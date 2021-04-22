using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    public abstract class AbstractClassFigure : IFigure
    {
        protected Font _font = new Font("Arial", 16);
        protected SolidBrush _brush = new SolidBrush(Color.Black);

        public Point MouseUpPosition { get; set; }
        public Point MouseDownPosition { get; set; }

        public Color Color { get; set; } = Color.Black;
        public int Width { get; set; } = 1;

        public abstract void Draw(Graphics graphics, int deltaX = 0, int deltaY = 0);

        public bool IsHavingPoint(Point checkedPoint)
        {
            return Geometry.FindPointInClass(MouseUpPosition, MouseDownPosition, checkedPoint);
        }

       
    }
}
