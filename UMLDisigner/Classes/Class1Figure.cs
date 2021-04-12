using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class Class1Figure : AbstractClassFigure
    {
        public Class1Figure()
        {

        }

        Class1Figure(Point mouseDownPosition, Point mouseUpPosition, Color color, int width, Font font, SolidBrush brush)
        {
            MouseDownPosition = mouseDownPosition;
            MouseUpPosition = mouseUpPosition;
            Color = color;
            Width = width;
            _font = font;
            _brush = brush;
        }

        public override void Draw(Graphics graphics, Pen pen, int deltaX = 0, int deltaY = 0)
        {
            Size delta = new Size(deltaX, deltaY);
            graphics.DrawPolygon(pen, Geometry.GetRectangle(Point.Add(MouseUpPosition, delta), Point.Add(MouseDownPosition, delta)));

            if ((MouseDownPosition.Y - MouseUpPosition.Y) > 20)
            {
                if (MouseDownPosition.X - MouseUpPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(MouseUpPosition.X + deltaX, MouseUpPosition.Y + 10 + deltaY));

                }
                else if (MouseUpPosition.X - MouseDownPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(MouseDownPosition.X + deltaX, MouseUpPosition.Y + 10 + deltaY));
                }
            }
            if ((MouseUpPosition.Y - MouseDownPosition.Y) > 20)
            {
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

        public override object Clone()
        {
            return new Class1Figure(this.MouseDownPosition, this.MouseUpPosition, this.Color, this.Width, this._font, this._brush);
        }
    }
}