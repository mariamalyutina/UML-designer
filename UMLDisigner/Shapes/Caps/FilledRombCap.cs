using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    public class FilledRombCap : AbstractCap
    {
        AbstractCap rombCap = new WhiteRombCap();

        public override void Draw(Graphics graphics, Pen pen, SolidBrush brush, Point endPoint, Point startPoint)
        {
            if (endPoint != startPoint)
            {
                brush = new SolidBrush(pen.Color);
                rombCap.Draw(graphics, pen, brush, endPoint, startPoint);
            }
        }
    }
}
