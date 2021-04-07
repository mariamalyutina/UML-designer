using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowImplementation : IFigure
    {
        public void Draw(Graphics graphics, Pen pen, Points p)
        {

            graphics.DrawPolygon(pen, new Point[] {p.Positions[1], p.ShouldersArrows[0], p.ShouldersArrows[1] });
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            graphics.DrawLine(pen, p.Positions[0], p.ShouldersArrows[2]);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
        }
    }
}
