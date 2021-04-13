using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowAggregationPlus : AbstractArrow
    {


        public override void Draw(Graphics graphics, Pen pen)
        {
            if (IsCurved)
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
            else
            {
                graphics.DrawLine(pen, Geometry.GetRomb(MouseDownPosition, MouseUpPosition)[3], MouseUpPosition);//начинаем прорисовывать линию от конца ромбика
                graphics.DrawLine(pen, MouseUpPosition, Geometry.GetArrow(MouseUpPosition, MouseDownPosition)[0]); //отрисовка крыльев стрелки
                graphics.DrawLine(pen, MouseUpPosition, Geometry.GetArrow(MouseUpPosition, MouseDownPosition)[2]); //отрисовка крыльев стрелки
                graphics.DrawPolygon(pen, Geometry.GetRomb(MouseDownPosition, MouseUpPosition)); //ромбик на конце , меняем местами mouseUp и mouseDown, чтобы ромбик рисовался в конце линии
            }
        }

    }
}