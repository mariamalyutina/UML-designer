using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class Class3Figure : AbstractClassFigure
    {
        int _topLineHeight = 40;
        int _bottomLineHeight = 40;

        public override void Draw(Graphics graphics, Pen pen, Point mouseUpPosition, Point mouseDownPosition)
        {

            graphics.DrawPolygon(pen, Geometry.GetRectangle(mouseUpPosition, mouseDownPosition));


            if ((mouseDownPosition.Y - mouseUpPosition.Y) > _topLineHeight)
            {
                graphics.DrawLine(pen, new Point(mouseDownPosition.X, mouseUpPosition.Y + _topLineHeight),
                    new Point(mouseUpPosition.X, mouseUpPosition.Y + _topLineHeight));
                if (mouseDownPosition.X - mouseUpPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(mouseUpPosition.X, mouseUpPosition.Y + 10));

                }
                else if (mouseUpPosition.X - mouseDownPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(mouseDownPosition.X, mouseUpPosition.Y + 10));
                }
            }
            else if ((mouseUpPosition.Y - mouseDownPosition.Y) > _topLineHeight)
            {
                graphics.DrawLine(pen, new Point(mouseDownPosition.X, mouseDownPosition.Y + _topLineHeight),
                    new Point(mouseUpPosition.X, mouseDownPosition.Y + _topLineHeight));
                if (mouseDownPosition.X - mouseUpPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(mouseUpPosition.X, mouseDownPosition.Y + 10));
                }
                else if (mouseUpPosition.X - mouseDownPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(mouseDownPosition.X, mouseDownPosition.Y + 10));
                }
            }


            if ((mouseDownPosition.Y - mouseUpPosition.Y) > _bottomLineHeight + _topLineHeight)
            {
                graphics.DrawLine(pen, new Point(mouseDownPosition.X, mouseDownPosition.Y - _bottomLineHeight),
                    new Point(mouseUpPosition.X, mouseDownPosition.Y - _bottomLineHeight));
                if (mouseDownPosition.X - mouseUpPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(mouseUpPosition.X, mouseDownPosition.Y - 20));

                }
                else if (mouseUpPosition.X - mouseDownPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(mouseDownPosition.X, mouseDownPosition.Y - 20));
                }
            }
            else if ((mouseUpPosition.Y - mouseDownPosition.Y) > _bottomLineHeight + _topLineHeight)
            {
                graphics.DrawLine(pen, new Point(mouseDownPosition.X, mouseUpPosition.Y - _bottomLineHeight),
                    new Point(mouseUpPosition.X, mouseUpPosition.Y - _bottomLineHeight));
                if (mouseDownPosition.X - mouseUpPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(mouseUpPosition.X, mouseUpPosition.Y - 20));

                }
                else if (mouseUpPosition.X - mouseDownPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(mouseDownPosition.X, mouseUpPosition.Y - 20));
                }
            }
        }
    }
}