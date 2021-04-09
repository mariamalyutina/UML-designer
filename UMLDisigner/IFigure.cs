using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace UMLDisigner
{
    public interface IFigure
    {
        Point MouseUpPosition { get; set; }
        Point MouseDownPosition { get; set; }

        void Draw(Graphics graphics, Pen pen);
    }
}
