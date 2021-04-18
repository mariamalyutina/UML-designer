using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowСomposition : AbstractArrow
    {


        public ArrowСomposition(Color color, int width)
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
            else
            {
                graphics.DrawLine(pen, MouseDownPosition, Geometry.GetRomb(MouseUpPosition, MouseDownPosition)[3]); //рисуем линию до начала ромбика
                graphics.DrawPolygon(pen, Geometry.GetRomb(MouseUpPosition, MouseDownPosition));
                graphics.FillPolygon(brush, Geometry.GetRomb(MouseUpPosition, MouseDownPosition));
            }
            MouseDownPosition = tmpMouseDownPosition;
            MouseUpPosition = tmpMouseUpPosition;
        }

        public override object Clone()
        {
            return new ArrowСomposition(this.Color, this.Width)
            {
                MouseDownPosition = this.MouseDownPosition,
                MouseUpPosition = this.MouseUpPosition
            };

        }
    
    }
}
