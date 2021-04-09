using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ClassStackFigure : AbstractClassFigure
    {
        public override void Draw(Graphics graphics, Pen pen, Point mouseUpPosition, Point mouseDownPosition)
        {

            SolidBrush _whiteBrush = new SolidBrush(Color.White);
            pen.Width += 1;

            for (int i = 0; i < 5; i++)
            {
                int j = 0;
                graphics.DrawPolygon(pen, Geometry.GetRectangle(mouseUpPosition, mouseDownPosition));
                graphics.FillPolygon(_whiteBrush, Geometry.GetRectangle(mouseUpPosition, mouseDownPosition));
                j += 5;
                mouseDownPosition.X += j;
                mouseUpPosition.X += j;
                mouseDownPosition.Y += j;
                mouseUpPosition.Y += j;
            }

            if ((mouseDownPosition.Y - mouseUpPosition.Y) > 20)
            {
                if (mouseDownPosition.X - mouseUpPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(mouseUpPosition.X, mouseUpPosition.Y + 10));

                }
                else if (mouseUpPosition.X - mouseDownPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(mouseDownPosition.X, mouseUpPosition.Y + 10));
                }
            }
            if ((mouseUpPosition.Y - mouseDownPosition.Y) > 20)
            {
                if (mouseDownPosition.X - mouseUpPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(mouseUpPosition.X, mouseDownPosition.Y + 10));
                }
                else if (mouseUpPosition.X - mouseDownPosition.X > 10)
                {
                    graphics.DrawString("Text", _font, _brush, new Point(mouseDownPosition.X, mouseDownPosition.Y + 10));
                }
            }

        }
    }
}