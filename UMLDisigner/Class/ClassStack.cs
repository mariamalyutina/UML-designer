using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ClassStack : IFigure
    {
        public void Draw(Graphics graphics, Pen pen, Points p)
        {
            Font drawFont = new Font("Arial", 16);

            SolidBrush brush = new SolidBrush(Color.White);
            Point[] P;
            pen.Width += 1;

            for (int i = 0; i < 5; i++)
            {
                int j = 0;
                P = new Point[] { new Point(p.Positions[0].X, p.Positions[0].Y),new Point(p.Positions[0].X, p.Positions[1].Y),
        new Point(p.Positions[1].X, p.Positions[1].Y),new Point(p.Positions[1].X, p.Positions[0].Y)};
                graphics.DrawPolygon(pen, P);
                graphics.FillPolygon(brush, P);
                j += 5;
                p.Positions[0].X += j;
                p.Positions[1].X += j;
                p.Positions[0].Y += j;
                p.Positions[1].Y += j;
            }
            brush = new SolidBrush(Color.Black);
            if ((p.Positions[0].Y - p.Positions[1].Y) > 20)
            {
                if (p.Positions[0].X - p.Positions[1].X > 10)
                {
                    graphics.DrawString("Text", drawFont, brush, new Point(p.Positions[1].X, p.Positions[1].Y + 10));

                }
                else if (p.Positions[1].X - p.Positions[0].X > 10)
                {
                    graphics.DrawString("Text", drawFont, brush, new Point(p.Positions[0].X, p.Positions[1].Y + 10));
                }
            }
            if ((p.Positions[1].Y - p.Positions[0].Y) > 20)
            {
                if (p.Positions[0].X - p.Positions[1].X > 10)
                {
                    graphics.DrawString("Text", drawFont, brush, new Point(p.Positions[1].X, p.Positions[0].Y + 10));
                }
                else if (p.Positions[1].X - p.Positions[0].X > 10)
                {
                    graphics.DrawString("Text", drawFont, brush, new Point(p.Positions[0].X, p.Positions[0].Y + 10));
                }
            }

        }
    }
}