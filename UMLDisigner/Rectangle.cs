using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class Rectangle : IFigure
    {
        public void Draw(Graphics graphics, Pen pen, Points p)
        {
            graphics.DrawPolygon(pen, new Point[] { new Point(p.Positions[0].X, p.Positions[0].Y),new Point(p.Positions[0].X, p.Positions[1].Y),
        new Point(p.Positions[1].X, p.Positions[1].Y),new Point(p.Positions[1].X, p.Positions[0].Y)});
        }

    }
}