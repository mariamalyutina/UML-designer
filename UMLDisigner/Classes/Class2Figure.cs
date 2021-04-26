using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class Class2Figure : AbstractClassFigure
    {
        int _topLineHeight = 25;

        public Class2Figure(Color color, int width)
        {
            Color = color;
            Width = width;
        }

        public Class2Figure(Point mouseDownPosition, Point mouseUpPosition, Color color, int width,
            List<string> text, int size, int countString = 4)
        {
            MouseDownPosition = mouseDownPosition;
            MouseUpPosition = mouseUpPosition;

            Color = color;
            Width = width;
            Text = text;
            //  Text[0] = "ClassName";
            //  Size = size;
            CountString = countString;
            //_font = font;
            //_brush = brush;
        }

        public override void Draw(Graphics graphics, Pen pen, int deltaX = 0, int deltaY = 0)
        {
          int  tmpMouseDownPositionX = MouseDownPosition.X;
          int  tmpMouseDownPositionY = MouseDownPosition.Y;
          int  tmpMouseUpPositionX = MouseUpPosition.X;
          int tmpMouseUpPositionY = MouseUpPosition.Y;

              Size delta = new Size(deltaX, deltaY);
            graphics.DrawPolygon(pen, Geometry.GetRectangle(Point.Add(MouseUpPosition, delta), Point.Add(MouseDownPosition, delta)));
            int k = 25;
            int indent = 0;
            for (int i = 0; i <= CountString; i++)
            {
                int fac = k * (i);


                if ((tmpMouseDownPositionY - tmpMouseUpPositionY) > fac)
                {
                    if (tmpMouseDownPositionX - tmpMouseUpPositionX > 10+Size)
                    {
                        graphics.DrawLine(pen, new Point(tmpMouseDownPositionX + deltaX, tmpMouseUpPositionY + _topLineHeight + deltaY),
                      new Point(tmpMouseUpPositionX + deltaX, tmpMouseUpPositionY + _topLineHeight + deltaY));
                        graphics.DrawString(Text[i], _font, _brush, new Point(tmpMouseUpPositionX + deltaX + indent, tmpMouseUpPositionY + fac + deltaY));

                    }
                    else if (tmpMouseUpPositionX - tmpMouseDownPositionX > 10 + Size)
                    {
                        graphics.DrawLine(pen, new Point(tmpMouseDownPositionX + deltaX, tmpMouseUpPositionY + deltaY + k), new Point(tmpMouseUpPositionX + deltaX, tmpMouseUpPositionY + deltaY + k));
                        if (tmpMouseUpPositionX - tmpMouseDownPositionX  < Size)
                        {
                            tmpMouseUpPositionY +=10;
                            tmpMouseUpPositionX +=10;

                        }
                        graphics.DrawString(Text[i], _font, _brush, new Point(tmpMouseDownPositionX + deltaX+ indent, tmpMouseUpPositionY + deltaY + fac));
                    }
                }
                if ((tmpMouseUpPositionY - tmpMouseDownPositionY) > fac)
                {
                    if (tmpMouseDownPositionX  - tmpMouseUpPositionX  > 10 + Size)
                    {
                        graphics.DrawLine(pen, new Point(tmpMouseDownPositionX + deltaX, tmpMouseDownPositionY + deltaY + _topLineHeight),
                        new Point(tmpMouseUpPositionX + deltaX, tmpMouseDownPositionY + deltaY + _topLineHeight));
                        graphics.DrawString(Text[i], _font, _brush, new Point(tmpMouseUpPositionX + deltaX+ indent, tmpMouseDownPositionY + deltaY + fac));
                    }
                    else if (tmpMouseUpPositionX - tmpMouseDownPositionX > 10 + Size)
                    {
                        graphics.DrawLine(pen, new Point(tmpMouseDownPositionX + deltaX, tmpMouseDownPositionY + deltaY + _topLineHeight),
                        new Point(tmpMouseUpPositionX + deltaX, tmpMouseDownPositionY + deltaY + _topLineHeight));
                        graphics.DrawString(Text[i], _font, _brush, new Point(tmpMouseDownPositionX + deltaX + indent, tmpMouseDownPositionY + deltaY + fac));
                    }
                }

            }
        }


        public override object Clone()
        {
            return new Class2Figure(this.MouseDownPosition, this.MouseUpPosition, this.Color, this.Width, Text, Size, CountString);
        }
    }

}