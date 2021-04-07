﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class Class3 : IFigure
    {
        public void Draw(Graphics graphics, Pen pen, Points p)
        {
            int topLineHeight = 30;
            int bottomLineHeight = 30;
            graphics.DrawPolygon(pen, new Point[] { new Point(p.Positions[0].X, p.Positions[0].Y),new Point(p.Positions[0].X, p.Positions[1].Y),
        new Point(p.Positions[1].X, p.Positions[1].Y),new Point(p.Positions[1].X, p.Positions[0].Y)});
            
            
            if ((p.Positions[0].Y - p.Positions[1].Y) > topLineHeight)
            {
                graphics.DrawLine(pen, new Point(p.Positions[0].X, p.Positions[1].Y + topLineHeight),
                    new Point(p.Positions[1].X, p.Positions[1].Y + topLineHeight));
            }
            else if ((p.Positions[1].Y - p.Positions[0].Y) > topLineHeight)
            {
                graphics.DrawLine(pen, new Point(p.Positions[0].X, p.Positions[0].Y + topLineHeight),
                    new Point(p.Positions[1].X, p.Positions[0].Y + topLineHeight));
            }
            
            
            if ((p.Positions[0].Y - p.Positions[1].Y) > bottomLineHeight + topLineHeight)
            {
                graphics.DrawLine(pen, new Point(p.Positions[0].X, p.Positions[0].Y - bottomLineHeight),
                    new Point(p.Positions[1].X, p.Positions[0].Y - bottomLineHeight));
            }
            else if ((p.Positions[1].Y - p.Positions[0].Y) > bottomLineHeight + topLineHeight)
            {
                graphics.DrawLine(pen, new Point(p.Positions[0].X, p.Positions[1].Y - bottomLineHeight),
                    new Point(p.Positions[1].X, p.Positions[1].Y - bottomLineHeight));
            }
        }
    }
}

