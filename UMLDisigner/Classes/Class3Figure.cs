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

        public override void Draw(Graphics graphics, Pen pen)
        {

            graphics.DrawPolygon(pen, Geometry.GetRectangle(MouseUpPosition, MouseDownPosition));


            if ((MouseDownPosition.Y - MouseUpPosition.Y) > _topLineHeight)
            {
                graphics.DrawLine(pen, new Point(MouseDownPosition.X, MouseUpPosition.Y + _topLineHeight),
                    new Point(MouseUpPosition.X, MouseUpPosition.Y + _topLineHeight));
                if (MouseDownPosition.X - MouseUpPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(MouseUpPosition.X, MouseUpPosition.Y + 10));

                }
                else if (MouseUpPosition.X - MouseDownPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(MouseDownPosition.X, MouseUpPosition.Y + 10));
                }
            }
            else if ((MouseUpPosition.Y - MouseDownPosition.Y) > _topLineHeight)
            {
                graphics.DrawLine(pen, new Point(MouseDownPosition.X, MouseDownPosition.Y + _topLineHeight),
                    new Point(MouseUpPosition.X, MouseDownPosition.Y + _topLineHeight));
                if (MouseDownPosition.X - MouseUpPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(MouseUpPosition.X, MouseDownPosition.Y + 10));
                }
                else if (MouseUpPosition.X - MouseDownPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(MouseDownPosition.X, MouseDownPosition.Y + 10));
                }
            }


            if ((MouseDownPosition.Y - MouseUpPosition.Y) > _bottomLineHeight + _topLineHeight)
            {
                graphics.DrawLine(pen, new Point(MouseDownPosition.X, MouseDownPosition.Y - _bottomLineHeight),
                    new Point(MouseUpPosition.X, MouseDownPosition.Y - _bottomLineHeight));
                if (MouseDownPosition.X - MouseUpPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(MouseUpPosition.X, MouseDownPosition.Y - 20));

                }
                else if (MouseUpPosition.X - MouseDownPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(MouseDownPosition.X, MouseDownPosition.Y - 20));
                }
            }
            else if ((MouseUpPosition.Y - MouseDownPosition.Y) > _bottomLineHeight + _topLineHeight)
            {
                graphics.DrawLine(pen, new Point(MouseDownPosition.X, MouseUpPosition.Y - _bottomLineHeight),
                    new Point(MouseUpPosition.X, MouseUpPosition.Y - _bottomLineHeight));
                if (MouseDownPosition.X - MouseUpPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(MouseUpPosition.X, MouseUpPosition.Y - 20));

                }
                else if (MouseUpPosition.X - MouseDownPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(MouseDownPosition.X, MouseUpPosition.Y - 20));
                }
            }
        }
    }
}