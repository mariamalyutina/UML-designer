using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowСompositionPlus : AbstractArrow
    {

        public ArrowСompositionPlus(Color color, int width)
        {
            //MouseDownPosition = mouseDownPosition;
            //MouseUpPosition = mouseUpPosition;
            Color = color;
            Width = width;
        }

        public override void Draw(Graphics graphics, Pen pen, int deltaX = 0, int deltaY = 0)
        {
            Point tmpMouseDownPosition = MouseDownPosition;
            Point tmpMouseUpPosition = MouseUpPosition;
            Size delta = new Size(deltaX, deltaY);
            MouseDownPosition = Point.Add(MouseDownPosition, delta);
            MouseUpPosition = Point.Add(MouseUpPosition, delta);

            SolidBrush brush = new SolidBrush(pen.Color);

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
                    graphics.FillPolygon(brush, Geometry.GetRomb(rombStart, rombEnd));
                }
            }
            else
            {
                graphics.DrawLine(pen, Geometry.GetRomb(MouseDownPosition, MouseUpPosition)[3], MouseUpPosition);//начинаем прорисовывать линию от конца ромбика
                graphics.DrawLine(pen, MouseUpPosition, Geometry.GetArrow(MouseUpPosition, MouseDownPosition)[0]); //отрисовка крыльев стрелки
                graphics.DrawLine(pen, MouseUpPosition, Geometry.GetArrow(MouseUpPosition, MouseDownPosition)[2]); //отрисовка крыльев стрелки
                graphics.DrawPolygon(pen, Geometry.GetRomb(MouseDownPosition, MouseUpPosition)); //ромбик на конце , меняем местами mouseUp и mouseDown, чтобы ромбик рисовался в конце линии
                graphics.FillPolygon(brush, Geometry.GetRomb(MouseDownPosition, MouseUpPosition));
            }
            MouseDownPosition = tmpMouseDownPosition;
            MouseUpPosition = tmpMouseUpPosition; 
        }

        public override object Clone()
        {
            return new ArrowСompositionPlus(this.Color, this.Width)
            {
                MouseDownPosition = this.MouseDownPosition,
                MouseUpPosition = this.MouseUpPosition
            };

        }
    
    }
}