using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowAggregation : AbstractArrow
    {

        public override void Draw(Graphics graphics, Pen pen)
        {

            if (IsCurved)
            {
                Point rombStart = GetPoints(MouseDownPosition, MouseUpPosition).ToArray()[2];
                Point rombEnd = MouseUpPosition;
                Point lineEnd = Geometry.GetRomb(rombEnd, rombStart)[3]; //лини€ заканчиваетс€ там, где начинаетс€ ромбик

                if (rombStart != rombEnd)
                {
                    graphics.DrawLines(pen, GetPoints(MouseDownPosition, lineEnd).ToArray());
                    graphics.DrawPolygon(pen, Geometry.GetRomb(rombEnd, rombStart));
                }
            } 
            else
            {
                graphics.DrawLine(pen, MouseDownPosition, Geometry.GetRomb(MouseUpPosition, MouseDownPosition)[3]);
                graphics.DrawPolygon(pen, Geometry.GetRomb(MouseUpPosition, MouseDownPosition));
            }
        }

    }
}
