using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ClassStackFigure : AbstractClassFigure
    {
        public ClassStackFigure(Color color, int width)
        {
            Color = color;
            Width = width;
        }

        public ClassStackFigure(Point mouseDownPosition, Point mouseUpPosition, Color color, int width)
        {
            MouseDownPosition = mouseDownPosition;
            MouseUpPosition = mouseUpPosition;
            Color = color;
            Width = width;
        }

        public override void Draw(Graphics graphics, int deltaX = 0, int deltaY = 0)
        {
            Pen pen1 = new Pen(Color, Width);
            SolidBrush _whiteBrush = new SolidBrush(Color.White);
            pen1.Width += 1;
            int j = 0;
            for (int i = 0; i < 5; i++, j += 5)
            {
                int crntMouseDownX = MouseDownPosition.X + j + deltaX;
                int crntMouseDownY = MouseDownPosition.Y + j + deltaY;
                int crntMouseUpX = MouseUpPosition.X + j + deltaX;
                int crntMouseUpY = MouseUpPosition.Y + j + deltaY;
                graphics.DrawPolygon(pen1, Geometry.GetRectangle(new Point(crntMouseDownX, crntMouseDownY), new Point(crntMouseUpX, crntMouseUpY)));
                graphics.FillPolygon(_whiteBrush, Geometry.GetRectangle(new Point(crntMouseDownX, crntMouseDownY), new Point(crntMouseUpX, crntMouseUpY)));
            }

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
            return new ClassStackFigure(this.MouseDownPosition, this.MouseUpPosition, this.Color, this.Width);
        }
    }
}