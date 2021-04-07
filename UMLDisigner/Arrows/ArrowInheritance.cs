using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
   public class ArrowInheritance : IFigure
    {
        public void Draw(Graphics graphics, Pen pen, Points p)
        {
            graphics.DrawPolygon(pen, new Point[] { p.Positions[1], p.ShouldersArrows[0], p.ShouldersArrows[1] });
            graphics.DrawLine(pen, p.Positions[0], p.ShouldersArrows[2]);
        }
    }
}
