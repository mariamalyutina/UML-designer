using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    abstract class AbstractCap 
    {
        public abstract void Draw(Graphics graphics, Pen pen, Point startPoint, Point endPoint);
    }
}
