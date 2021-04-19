using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    class WhiteRombCap : AbstractCap
    {
        public override void Draw(Graphics graphics, Pen pen, Point endPoint, Point startPoint)
        {
            if (endPoint != startPoint)
            {
                SolidBrush _whiteBrush = new SolidBrush(Color.White);
                graphics.FillPolygon(_whiteBrush, Geometry.GetRomb(endPoint, startPoint));
                graphics.DrawPolygon(pen, Geometry.GetRomb(endPoint, startPoint));
            }
        }
    }
}
