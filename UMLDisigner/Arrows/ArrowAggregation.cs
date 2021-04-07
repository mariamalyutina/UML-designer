using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowAggregation : IFigure
    {
        public void Draw(Graphics graphics, Pen pen, Points p)
        {
            double d = Math.Sqrt(Math.Pow(p.Positions[1].X - p.Positions[0].X, 2) + Math.Pow(p.Positions[1].Y - p.Positions[0].Y, 2));

            Point a = new Point((int)(p.Positions[1].X - (p.ShouldersArrows[3].X / d) * 40),
               (int)(p.Positions[1].Y - (p.ShouldersArrows[3].Y / d) * 40));


            graphics.DrawPolygon(pen, new Point[] { p.Positions[1], p.ShouldersArrows[0], a, p.ShouldersArrows[1] });
            graphics.DrawLine(pen, p.Positions[0], a);
        }
    }
}
