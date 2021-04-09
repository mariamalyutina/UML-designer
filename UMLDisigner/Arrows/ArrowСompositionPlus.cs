﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowСompositionPlus : AbstractArrow
    {
        public override void Draw(Graphics graphics, Pen pen)
        {
            SolidBrush brush = new SolidBrush(pen.Color);
            graphics.DrawLine(pen, Geometry.GetRomb(MouseDownPosition, MouseUpPosition)[3], MouseUpPosition);//начинаем прорисовывать линию от конца ромбика
            graphics.DrawLine(pen, MouseUpPosition, Geometry.GetArrow(MouseUpPosition, MouseDownPosition)[0]); //отрисовка крыльев стрелки
            graphics.DrawLine(pen, MouseUpPosition, Geometry.GetArrow(MouseUpPosition, MouseDownPosition)[2]); //отрисовка крыльев стрелки
            graphics.DrawPolygon(pen, Geometry.GetRomb(MouseDownPosition, MouseUpPosition)); //ромбик на конце , меняем местами mouseUp и mouseDown, чтобы ромбик рисовался в конце линии
            graphics.FillPolygon(brush, Geometry.GetRomb(MouseDownPosition, MouseUpPosition));
        }
    }
}