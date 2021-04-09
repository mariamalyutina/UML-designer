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


        public abstract void Draw(Graphics graphics, Pen pen);
    }
}
