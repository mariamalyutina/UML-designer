using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class Class2 : IFigure
    {
        public void Draw(Graphics graphics, Pen pen, Points p)
        {
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            int topLineHeight = 30;
            graphics.DrawPolygon(pen, new Point[] { new Point(p.Positions[0].X, p.Positions[0].Y),new Point(p.Positions[0].X, p.Positions[1].Y),
        new Point(p.Positions[1].X, p.Positions[1].Y),new Point(p.Positions[1].X, p.Positions[0].Y)});
            if ((p.Positions[0].Y - p.Positions[1].Y) > topLineHeight)
            {
                graphics.DrawLine(pen, new Point(p.Positions[0].X, p.Positions[1].Y + topLineHeight),
                    new Point(p.Positions[1].X, p.Positions[1].Y + topLineHeight));
                if (p.Positions[0].X - p.Positions[1].X > 10)
                {
                    graphics.DrawString("Text", drawFont, drawBrush, new Point(p.Positions[1].X, p.Positions[1].Y + 10));

                }
                else if (p.Positions[1].X - p.Positions[0].X > 10)
                {
                    graphics.DrawString("Text", drawFont, drawBrush, new Point(p.Positions[0].X, p.Positions[1].Y + 10));
                }
            }
            else if ((p.Positions[1].Y - p.Positions[0].Y) > topLineHeight)
            {
                graphics.DrawLine(pen, new Point(p.Positions[0].X, p.Positions[0].Y + topLineHeight),
                    new Point(p.Positions[1].X, p.Positions[0].Y + topLineHeight));
                if (p.Positions[0].X - p.Positions[1].X > 10)
                {
                    graphics.DrawString("Text", drawFont, drawBrush, new Point(p.Positions[1].X, p.Positions[0].Y + 10));
                }
                else if (p.Positions[1].X - p.Positions[0].X > 10)
                {
                    graphics.DrawString("Text", drawFont, drawBrush, new Point(p.Positions[0].X, p.Positions[0].Y + 10));
                }
            }
        }
    }
}