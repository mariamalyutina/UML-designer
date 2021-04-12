using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    abstract class AbstractArrow : IFigure
    {
        public Point MouseUpPosition { get; set; }
        public Point MouseDownPosition { get; set; }
        public Color Color { get; set; } = Color.Black;
        public int Width { get; set; } = 1;

        public AbstractArrow(Point MouseDownPosition, Point MouseUpPosition)
        {
            this.MouseDownPosition = MouseDownPosition;
            this.MouseUpPosition = MouseUpPosition;
        }
        public AbstractArrow()
        {

        }

        public abstract object Clone();
        

        public abstract void Draw(Graphics graphics, Pen pen);

        public abstract void Draw(Graphics graphics, Pen pen, int deltaX = 0, int deltaY = 0);
        public bool IsHavingPoint(Point checkedPoint)
        {
            return false;
        }
    }
}
