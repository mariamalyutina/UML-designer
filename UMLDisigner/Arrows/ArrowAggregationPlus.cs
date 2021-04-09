using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowAggregationPlus : IFigure
    {
        public void Draw(Graphics graphics, Pen pen, Point mouseUpPosition, Point mouseDownPosition)
        {
            graphics.DrawLine(pen, Geometry.GetRomb(mouseDownPosition, mouseUpPosition)[3], mouseUpPosition);//начинаем прорисовывать линию от конца ромбика
            graphics.DrawLine(pen, mouseUpPosition, Geometry.GetArrow(mouseUpPosition, mouseDownPosition)[0]); //отрисовка крыльев стрелки
            graphics.DrawLine(pen, mouseUpPosition, Geometry.GetArrow(mouseUpPosition, mouseDownPosition)[2]); //отрисовка крыльев стрелки
            graphics.DrawPolygon(pen, Geometry.GetRomb(mouseDownPosition, mouseUpPosition)); //ромбик на конце , меняем местами mouseUp и mouseDown, чтобы ромбик рисовался в конце линии
        }
    }
}