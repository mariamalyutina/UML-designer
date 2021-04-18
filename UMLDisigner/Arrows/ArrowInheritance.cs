using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowInheritance : AbstractArrow
    {
        AbstractCap _capType = new TriangleCap();
        AbstractLine _lineType = new StraightLine();

        public ArrowInheritance(Color color, int width)
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

            Pen pen1 = new Pen(Color, Width);
            _lineType.Draw(graphics, pen1, MouseDownPosition, MouseUpPosition);

            graphics.DrawLine(pen, MouseDownPosition, Geometry.GetArrow(MouseUpPosition, MouseDownPosition)[3]);
            _capType.Draw(graphics, pen1, MouseUpPosition, MouseDownPosition);

            MouseDownPosition = tmpMouseDownPosition;
            MouseUpPosition = tmpMouseUpPosition;

            //if (IsCurved)
            //{
            //    Point arrowStart = GetPoints(MouseDownPosition, MouseUpPosition).ToArray()[2];
            //    Point arrowEnd = MouseUpPosition;

            //    Point lineEnd = Geometry.GetArrow(arrowEnd, arrowStart)[3]; //рисуем до начала отрисовки стрелочки

            //    if (arrowStart != arrowEnd)
            //    {
            //        graphics.DrawPolygon(pen, Geometry.GetArrow(arrowEnd, arrowStart));
            //        graphics.DrawLines(pen, GetPoints(MouseDownPosition, lineEnd).ToArray());
            //    }
            //}
            //else
            //{
            //    graphics.DrawLine(pen, MouseDownPosition, Geometry.GetArrow(MouseUpPosition, MouseDownPosition)[3]);
            //    graphics.DrawPolygon(pen, Geometry.GetArrow(MouseUpPosition, MouseDownPosition));
            //}

        }

        public override object Clone()
        {
            return new ArrowInheritance(this.Color, this.Width)
            {
                MouseDownPosition = this.MouseDownPosition,
                MouseUpPosition = this.MouseUpPosition
            };

        }
    
    }
}
