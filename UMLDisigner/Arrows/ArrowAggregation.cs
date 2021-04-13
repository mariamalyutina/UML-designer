using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowAggregation : AbstractArrow
    {
        public ArrowAggregation()
        {

        }

        ArrowAggregation(Point mouseDownPosition, Point mouseUpPosition, Color color, int width)
        {
            MouseDownPosition = mouseDownPosition;
            MouseUpPosition = mouseUpPosition;
            Color = color;
            Width = width;
        }

        public override void Draw(Graphics graphics, Pen pen, int deltaX = 0, int deltaY = 0)
        {
            graphics.DrawLine(pen, MouseDownPosition, Geometry.GetRomb(MouseUpPosition, MouseDownPosition)[3]);
            graphics.DrawPolygon(pen, Geometry.GetRomb(MouseUpPosition, MouseDownPosition));

            if (IsCurved)
            {
                Point rombStart = GetPoints(MouseDownPosition, MouseUpPosition).ToArray()[2];
                Point rombEnd = MouseUpPosition;
                Point lineEnd = Geometry.GetRomb(rombEnd, rombStart)[3]; //����� ������������� ���, ��� ���������� ������

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

        public override object Clone()
        {
            return new ArrowAggregation(this.MouseDownPosition, this.MouseUpPosition, this.Color, this.Width); 
        }

    }
}
