using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ClassStackFigure : AbstractClassFigure
    {

        public ClassStackFigure()
        {

        }

        ClassStackFigure(Point mouseDownPosition, Point mouseUpPosition, Color color, int width, Font font, SolidBrush brush)
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

            SolidBrush _whiteBrush = new SolidBrush(Color.White);
            pen.Width += 1;
            int j = 0;
            for (int i = 0; i < 5; i++, j += 5)
            {
                int crntMouseDownX = MouseDownPosition.X + j;
                int crntMouseDownY = MouseDownPosition.Y + j;
                int crntMouseUpX = MouseUpPosition.X + j;
                int crntMouseUpY = MouseUpPosition.Y + j;
                graphics.DrawPolygon(pen, Geometry.GetRectangle(new Point (crntMouseDownX, crntMouseDownY), new Point(crntMouseUpX, crntMouseUpY)));
                graphics.FillPolygon(_whiteBrush, Geometry.GetRectangle(new Point(crntMouseDownX, crntMouseDownY), new Point(crntMouseUpX, crntMouseUpY)));
            }

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
            return new ClassStackFigure(this.MouseDownPosition, this.MouseUpPosition, this.Color, this.Width, this._font, this._brush);
        }
    }
}