using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    class ArrowСompositionCurved : AbstractArrow
    {
        public override void Draw(Graphics graphics, Pen pen)
        {
            SolidBrush brush = new SolidBrush(pen.Color);

            Point rombStart = GetPoints(MouseDownPosition, MouseUpPosition).ToArray()[2];
            Point rombEnd = MouseUpPosition;
            Point lineEnd = Geometry.GetRomb(rombEnd, rombStart)[3]; //линия заканчивается там, где начинается ромбик

            if (rombStart != rombEnd)
            {
                graphics.DrawPolygon(pen, Geometry.GetRomb(rombEnd, rombStart));
                graphics.FillPolygon(brush, Geometry.GetRomb(rombEnd, rombStart));
                graphics.DrawLines(pen, GetPoints(MouseDownPosition, lineEnd).ToArray());
            }
        }

        public override object Clone()
        {
            return new ArrowСompositionCurved();
        }
    }
}
