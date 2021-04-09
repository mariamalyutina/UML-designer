using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace UMLDisigner
{
    public interface IFigure
    {
        void Draw(Graphics graphics, Pen pen, Point mouseUpPosition, Point mouseDownPosition);
    }
}
