using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    class ArrowAggregationPlusCurved : AbstractArrow
    {
        public override void Draw(Graphics graphics, Pen pen)
        {

            Point arrowStart = GetPoints(MouseDownPosition, MouseUpPosition).ToArray()[2];
            Point arrowEnd = MouseUpPosition;

            Point rombStart = MouseDownPosition;
            Point rombEnd = GetPoints(MouseDownPosition, MouseUpPosition).ToArray()[1];

            Point lineStart = Geometry.GetRomb(rombStart, rombEnd)[3]; //Линия начинается от конца ромбика

            if (arrowStart != arrowEnd && rombStart != rombEnd)
            {
                graphics.DrawLines(pen, GetPoints(lineStart, MouseUpPosition).ToArray()); 
                graphics.DrawLine(pen, MouseUpPosition, Geometry.GetArrow(arrowEnd, arrowStart)[0]); //отрисовка крыльев стрелки
                graphics.DrawLine(pen, MouseUpPosition, Geometry.GetArrow(arrowEnd, arrowStart)[2]); //отрисовка крыльев стрелки
                graphics.DrawPolygon(pen, Geometry.GetRomb(rombStart, rombEnd));
            }

        }

        public override object Clone()
        {
            return new ArrowAggregationPlusCurved();
        }
    }
}
