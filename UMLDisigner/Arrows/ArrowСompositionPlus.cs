using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowСompositionPlus : AbstractArrow
    {
        public ArrowСompositionPlus()
        {

        }

        public ArrowСompositionPlus(Point mouseDownPosition, Point mouseUpPosition, Color color, int width)
        {
            MouseDownPosition = mouseDownPosition;
            MouseUpPosition = mouseUpPosition;
            Color = color;
            Width = width;
        }

        public override void Draw(Graphics graphics, Pen pen)
        {
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
            
        }

        public override object Clone()
        {
            return new ArrowСompositionPlus(this.MouseDownPosition, this.MouseUpPosition, this.Color, this.Width);
        }
    }
}