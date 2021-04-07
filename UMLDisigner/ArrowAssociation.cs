using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace UMLDisigner
{
    class ArrowAssociation : IFigure
    {
        public void Draw(Graphics graphics, Pen pen, Points p)
        {
            graphics.DrawLine(pen, p.Positions[0], p.Positions[1]);
            graphics.DrawLine(pen, p.Positions[1], p.ShouldersArrows[0]);
            graphics.DrawLine(pen, p.Positions[1], p.ShouldersArrows[1]);
        }


    }
}
