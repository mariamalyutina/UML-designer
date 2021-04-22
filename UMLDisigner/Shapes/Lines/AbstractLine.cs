using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    public abstract class AbstractLine
    {
        public abstract void Draw(Graphics graphics, Pen pen, Point endPoint, Point startPoint);
    }
}
