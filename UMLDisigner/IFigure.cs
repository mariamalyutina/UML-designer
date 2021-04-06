using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace UMLDisigner
{
    public interface IFigure
    {
        public void Draw(Graphics graphics, Pen pen, Points p);
        
    }
}
