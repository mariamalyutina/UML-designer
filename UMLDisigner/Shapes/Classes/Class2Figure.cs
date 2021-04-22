using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class Class2Figure : AbstractClassFigure
    {
        int _topLineHeight = 40;

        public Class2Figure(Color color, int width)
        {
            Color = color;
            Width = width;
        }

        public Class2Figure(Point mouseDownPosition, Point mouseUpPosition, Color color, int width)
        {
            MouseDownPosition = mouseDownPosition;
            MouseUpPosition = mouseUpPosition;
            Color = color;
            Width = width;
        }

        public override void Draw(Graphics graphics, int deltaX = 0, int deltaY = 0)
        {
            Pen pen1 = new Pen(Color, Width);
            Size delta = new Size(deltaX, deltaY);
            graphics.DrawPolygon(pen1, Geometry.GetRectangle(Point.Add(MouseUpPosition, delta), Point.Add(MouseDownPosition, delta)));

            if ((MouseDownPosition.Y - MouseUpPosition.Y) > _topLineHeight)
            {
                graphics.DrawLine(pen1, new Point(MouseDownPosition.X + deltaX, MouseUpPosition.Y + _topLineHeight + deltaY),
                    new Point(MouseUpPosition.X + deltaX, MouseUpPosition.Y + _topLineHeight + deltaY));

                if (MouseDownPosition.X - MouseUpPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(MouseUpPosition.X + deltaX, MouseUpPosition.Y + 10 + deltaY));

                }
                else if (MouseUpPosition.X - MouseDownPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(MouseDownPosition.X + deltaX, MouseUpPosition.Y + 10 + deltaY));
                }
            }
            else if ((MouseUpPosition.Y - MouseDownPosition.Y) > _topLineHeight)
            {
                graphics.DrawLine(pen1, new Point(MouseDownPosition.X + deltaX, MouseDownPosition.Y + _topLineHeight + deltaY),
                    new Point(MouseUpPosition.X + deltaX, MouseDownPosition.Y + _topLineHeight + deltaY));

                if (MouseDownPosition.X - MouseUpPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(MouseUpPosition.X + deltaX, MouseDownPosition.Y + 10 + deltaY));
                }
                else if (MouseUpPosition.X - MouseDownPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(MouseDownPosition.X + deltaX, MouseDownPosition.Y + 10 + deltaY));
                }
            }
        }
    }

}