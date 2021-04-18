using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class Class1Figure : AbstractClassFigure
    {
        //Point mouseDownPosition, Point mouseUpPosition, 

        public Class1Figure(Color color, int width)
        {
            Color = color;
            Width = width;
        }

        public Class1Figure(Point mouseDownPosition, Point mouseUpPosition, Color color, int width)
        {
            MouseDownPosition = mouseDownPosition;
            MouseUpPosition = mouseUpPosition;
            Color = color;
            Width = width;
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
            return new Class3Figure(this.MouseDownPosition, this.MouseUpPosition, this.Color, this.Width);
        }
    }
}