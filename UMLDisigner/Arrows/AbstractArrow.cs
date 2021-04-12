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

    }
}
