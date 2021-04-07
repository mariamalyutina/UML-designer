using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class Class1 : IFigure
    {
        public void Draw(Graphics graphics, Pen pen, Points p)
        {
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            graphics.DrawPolygon(pen, new Point[] { new Point(p.Positions[0].X, p.Positions[0].Y),new Point(p.Positions[0].X, p.Positions[1].Y),
        new Point(p.Positions[1].X, p.Positions[1].Y),new Point(p.Positions[1].X, p.Positions[0].Y)});

            if ((p.Positions[0].Y - p.Positions[1].Y) > 20)
            {
                if (p.Positions[0].X - p.Positions[1].X > 10)
                {
                    graphics.DrawString("Text", drawFont, drawBrush, new Point(p.Positions[1].X, p.Positions[1].Y + 10));

                }
                else if (p.Positions[1].X - p.Positions[0].X > 10)
                {
                    graphics.DrawString("Text", drawFont, drawBrush, new Point(p.Positions[0].X, p.Positions[1].Y + 10));
                }
            }
            if ((p.Positions[1].Y - p.Positions[0].Y) > 20)
            {
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