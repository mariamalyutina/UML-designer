using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowСompositionPlus : IFigure
    {
        public void Draw(Graphics graphics, Pen pen, Points p)
        {
            SolidBrush brush = new SolidBrush(Color.Black);
            double d = Math.Sqrt(Math.Pow(p.Positions[1].X - p.Positions[0].X, 2) + Math.Pow(p.Positions[1].Y - p.Positions[0].Y, 2));

            Point a = new Point((int)(p.Positions[0].X - (p.ArrowAtFront[2].X / d) * 40),
               (int)(p.Positions[0].Y - (p.ArrowAtFront[2].Y / d) * 40));

            graphics.FillPolygon(brush, new Point[] { p.Positions[0], p.ArrowAtFront[0], a, p.ArrowAtFront[1] });
            graphics.DrawPolygon(pen, new Point[] { p.Positions[0], p.ArrowAtFront[0], a, p.ArrowAtFront[1] });
            graphics.DrawLine(pen, a, p.Positions[1]);
            graphics.DrawLine(pen, p.Positions[1], p.ShouldersArrows[0]);
            graphics.DrawLine(pen, p.Positions[1], p.ShouldersArrows[1]);
        }
    }
}