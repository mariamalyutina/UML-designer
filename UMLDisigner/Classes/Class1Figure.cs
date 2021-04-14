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

        public override void Draw(Graphics graphics, Pen pen)
        {
            //Size delta = new Size(deltaX, deltaY);
            graphics.DrawPolygon(pen, Geometry.GetRectangle(MouseUpPosition, MouseDownPosition));

            if ((MouseDownPosition.Y - MouseUpPosition.Y) > 20)
            {
                if (MouseDownPosition.X - MouseUpPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(MouseUpPosition.X, MouseUpPosition.Y + 10));

                }
                else if (MouseUpPosition.X - MouseDownPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(MouseDownPosition.X, MouseUpPosition.Y + 10));
                }
            }
            if ((MouseUpPosition.Y - MouseDownPosition.Y) > 20)
            {
                if (MouseDownPosition.X - MouseUpPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(MouseUpPosition.X, MouseDownPosition.Y + 10));
                }
                else if (MouseUpPosition.X - MouseDownPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(MouseDownPosition.X, MouseDownPosition.Y + 10));
                }
            }
        }

        public override object Clone()
        {
            return new Class1Figure(this.MouseDownPosition, this.MouseUpPosition, this.Color, this.Width, this._font, this._brush);
        }
    }
}